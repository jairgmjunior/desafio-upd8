using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Upd8.Web.Dtos;
using Upd8.Web.Enums;
using Upd8.Web.Services.Interfaces;

namespace Upd8.Web.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api";
        private readonly JsonSerializerOptions _options;

        public CidadeService(IHttpClientFactory factory)
        {
            _clientFactory = factory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<CidadeDto>> GetCidadesPorEstado(int pageSize, int pageNum, string searchTerm, EEStado estado)
        {
            var api = _clientFactory.CreateClient("Upd8ApiCidade");

            var query = $"?pageSize={pageSize}&pageNum={pageNum}&searchTerm={searchTerm}&estado={estado}";

            using var response = await api.GetAsync($"{apiEndpoint}/GetCidadesPaginadas/" + query);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var apiResponse = await response.Content.ReadAsStreamAsync();
               
                var cidadesDto = await JsonSerializer.DeserializeAsync<IEnumerable<CidadeDto>>(apiResponse, _options);
                return cidadesDto!.ToList();
            }

            return new List<CidadeDto>();
        }

        public async Task<CidadeDto> GetCidadePorCodigoIbge(string codigoIbge)
        {
            var api = _clientFactory.CreateClient("Upd8ApiCidade");

            var query = $"?codigoIbge={codigoIbge}";

            using var response = await api.GetAsync($"{apiEndpoint}/GetCidadePorCodigoIbge/" + query);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                var cidadeDto = await JsonSerializer.DeserializeAsync<CidadeDto>(apiResponse, _options);

                return cidadeDto!;
            }

            return null;
        }
    }
}
