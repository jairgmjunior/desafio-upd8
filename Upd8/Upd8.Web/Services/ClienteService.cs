using System.Net;
using System.Text;
using System.Text.Json;
using Upd8.Web.Dtos;
using Upd8.Web.Models;
using Upd8.Web.Services.Interfaces;

namespace Upd8.Web.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/cliente/";
        private readonly JsonSerializerOptions _options;

        public ClienteService(IHttpClientFactory factory)
        {
            _clientFactory= factory;
            _options= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ClienteViewModel>> GetClientesAsync()
        {
            var retorno = new List<ClienteViewModel>();

            var api = _clientFactory.CreateClient("Upd8Api");

            using var response = await api.GetAsync(apiEndpoint);

            if(response.IsSuccessStatusCode) 
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var apiResponse = await response.Content.ReadAsStreamAsync();
                var clientesDto = await JsonSerializer.DeserializeAsync<IEnumerable<ResponseClienteDto>>(apiResponse, _options);

                if (clientesDto.Any())
                {
                    clientesDto.ToList().ForEach(p =>
                    {
                        retorno.Add(ClienteViewModel.Bind(p));
                    });
                }
            }

            return retorno;
        }

        public async Task<ClienteViewModel> GetClienteAsync(int id)
        {
            var api = _clientFactory.CreateClient("Upd8Api");

            using var response = await api.GetAsync(apiEndpoint + id);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var apiResponse = await response.Content.ReadAsStreamAsync();
                var clienteDto = await JsonSerializer.DeserializeAsync<ResponseClienteDto>(apiResponse, _options);

                var viewModel = ClienteViewModel.Bind(clienteDto);

                return viewModel;

            }

            return new ClienteViewModel();
        }

        public async Task<ClienteViewModel> InsertClienteAsync(ClienteViewModel cliente)
        {
            var api = _clientFactory.CreateClient("Upd8Api");

            var dto = ClienteViewModel.Bind(cliente);
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            using var response = await api.PostAsync(apiEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                var clienteDto = await JsonSerializer.DeserializeAsync<ResponseClienteDto>(apiResponse, _options);

                if (clienteDto != null)
                {
                    return ClienteViewModel.Bind(clienteDto);

                }
            }

            return cliente;
        }

        public async Task<ClienteViewModel> UpdateClienteAsync(ClienteViewModel cliente)
        {
            var api = _clientFactory.CreateClient("Upd8Api");

            var dto = ClienteViewModel.BindUpdate(cliente);
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            using var response = await api.PutAsync(apiEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                var clienteDto = await JsonSerializer.DeserializeAsync<ResponseClienteDto>(apiResponse, _options);

                if (clienteDto != null)
                {
                    return ClienteViewModel.Bind(clienteDto);

                }
            }

            return cliente;
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var api = _clientFactory.CreateClient("Upd8Api");

            using var response = await api.DeleteAsync(apiEndpoint + id);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        

        
    }
}
