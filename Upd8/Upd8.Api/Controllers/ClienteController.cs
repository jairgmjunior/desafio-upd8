using Microsoft.AspNetCore.Mvc;
using SerilogTimings;
using Upd8.Core.Shared.ViewModels;
using Upd8.Manager.Interfaces;


namespace Upd8.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteManager clienteManager, ILogger<ClienteController> logger)
        {
            _clienteManager = clienteManager;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos clientes cadastrados na base.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            //throw new Exception("Erro teste");
            return Ok(await _clienteManager.GetClientesAsync());
        }

        /// <summary>
        /// Retorna um cliente consultado pelo id.
        /// </summary>
        /// <param name="id" example="123">Id do cliente</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _clienteManager.GetClienteAsync(id));
        }

        /// <summary>
        /// Insere um novo cliente
        /// </summary>
        /// <param name="client"></param>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponseViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoClienteViewModel client)
        {
            _logger.LogInformation("Objeto recebido {@client}", client);

            ClienteResponseViewModel clienteDb;

            using (Operation.Time("Tempo de adição de um novo client"))
            {
                _logger.LogInformation("requisitado a inserção de um novo cliente");
                clienteDb = await _clienteManager.InsereClienteAsync(client);
            }

            return CreatedAtAction(nameof(Get), new { id = clienteDb.Id }, clienteDb);
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="client"></param>
        [HttpPut]
        [ProducesResponseType(typeof(ClienteResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(AtualizaClienteViewModel client)
        {
            _logger.LogInformation("Atualizando {@client}", client);

            var clientDb = await _clienteManager.UpdateClienteAsync(client);
            
            if (clientDb == null) return NotFound();

            return Ok(clientDb);
        }

        /// <summary>
        /// Deleta um cliente pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um cliente o mesmo será removido permanentemente da base</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClienteResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteExcluido = await _clienteManager.DeletaClienteAsync(id);

            if (clienteExcluido == null) return NotFound();

            return NoContent();
        }
    }
}
