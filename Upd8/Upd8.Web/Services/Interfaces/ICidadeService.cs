using Upd8.Web.Dtos;
using Upd8.Web.Enums;

namespace Upd8.Web.Services.Interfaces
{
    public interface ICidadeService
    {
        Task<List<CidadeDto>> GetCidadesPorEstado(int pageSize, int pageNum, string searchTerm, EEStado estado);
        Task<CidadeDto> GetCidadePorCodigoIbge(string codigoIbge);
    }
}
