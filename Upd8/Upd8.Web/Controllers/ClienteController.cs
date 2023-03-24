using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using Upd8.Web.Enums;
using Upd8.Web.Models;
using Upd8.Web.Services.Interfaces;

namespace Upd8.Web.Controllers
{
    public class ClienteController : CustomControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ICidadeService _cidadeService;

        public ClienteController(IClienteService clienteService, ICidadeService cidadeService)
        {
            _clienteService = clienteService;
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> Index()
        {
            var result = await _clienteService.GetClientesAsync();

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente(ClienteViewModel model)
        {
            if(ModelState.IsValid)
            {
                var viewModel = await _clienteService.InsertClienteAsync(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCliente(int id)
        {
            var viewModel = await _clienteService.GetClienteAsync(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCliente(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var viewModel = await _clienteService.UpdateClienteAsync(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var isExcluido = await _clienteService.DeleteClienteAsync(id);

            if (!isExcluido)
                return View("Error");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetCidadesPorEstado(int pageSize, int pageNum, string searchTerm, EEStado estado)
        {
            if (searchTerm == null) searchTerm = " ";

            var lista = await _cidadeService.GetCidadesPorEstado(pageSize, pageNum, searchTerm, estado);

            var retorno = lista.OrderBy(x => x.Nome)
                .Select(p => new Select2Item
                {
                    Id = p.CodigoIbge,
                    Text = $"{p.Nome}"
                })
                .ToList();

            //Criando o objeto de retorno
            var result = new
            {
                Total = retorno.Count(),
                Results = retorno.Skip((pageNum * pageSize) - 100).Take(pageSize)
            };

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCidadePorCodigoIbge(string codigoIbge)
        {
            if (string.IsNullOrEmpty(codigoIbge)) return Json("");

            var cidade = await _cidadeService.GetCidadePorCodigoIbge(codigoIbge);

            var retorno = new Select2Item
                        {
                            Id = cidade.CodigoIbge,
                            Text = $"{cidade.Nome}"
                        };

            return Json(retorno);
        }

        
    }
}
