using Upd8.Core.Domain;
using Upd8.Core.Enums;

namespace Upd8.Manager.Interfaces
{
    public interface ICidadeRepository
    {
        Task<Cidade?> GetCidadePorCodigoIbge(string codigo);
        Task<List<Cidade>> GetCidadesPaginadasPorEstado(int pageSize, int pageNum, string searchTerm, EEStado estado);
    }
}
