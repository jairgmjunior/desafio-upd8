using AutoMapper;
using Microsoft.Extensions.Logging;
using Upd8.Core.Domain;
using Upd8.Core.Shared.ViewModels;
using Upd8.Manager.Interfaces;

namespace Upd8.Manager.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository _repository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteManager> _logger;

        public ClienteManager(IClienteRepository repository, ICidadeRepository cidadeRepository, IMapper mapper, ILogger<ClienteManager> logger)
        {
            _repository = repository;
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ClienteResponseViewModel>> GetClientesAsync()
        {
            var clientes = await _repository.GetClientesAsync();

            var response = new List<ClienteResponseViewModel>();

            clientes.ToList().ForEach(cliente =>
            {
                response.Add(ClienteResponseViewModel.ToMapResponse(cliente));
            });

            return response;
        }

        public async Task<ClienteResponseViewModel?> GetClienteAsync(int id)
        {
            var cliente = await _repository.GetClienteAsync(id);


            return ClienteResponseViewModel.ToMapResponse(cliente);
        }

        public async Task<ClienteResponseViewModel> InsereClienteAsync(NovoClienteViewModel novoCliente)
        {
            _logger.LogInformation("Chamada de negócio para inserir um cliente.");

            var cliente = _mapper.Map<Cliente>(novoCliente);

            var cidade = await GetCidade(novoCliente.Endereco.CodigoIbge);

            cliente.Endereco.Cidade = cidade;

            var clienteResponse = await _repository.InsertClienteAsync(cliente);

            return ClienteResponseViewModel.ToMapResponse(clienteResponse);
        }

        private async Task<Cidade?> GetCidade(string codigo)
        {
            return await _cidadeRepository.GetCidadePorCodigoIbge(codigo);
        }

        public async Task<ClienteResponseViewModel> UpdateClienteAsync(AtualizaClienteViewModel atualizaCliente)
        {
            var client = _mapper.Map<Cliente>(atualizaCliente);

            var cidade = await GetCidade(atualizaCliente.Endereco.CodigoIbge);

            client.Endereco.Cidade = cidade;

            var clienteResponse = await _repository.UpdateClienteAsync(client);

            return ClienteResponseViewModel.ToMapResponse(clienteResponse);
        }

        public async Task<ClienteResponseViewModel> DeletaClienteAsync(int id)
        {
            var cliente = await _repository.DeleteClienteAsync(id);

            return ClienteResponseViewModel.ToMapResponse(cliente);
        }
        
    }
}
