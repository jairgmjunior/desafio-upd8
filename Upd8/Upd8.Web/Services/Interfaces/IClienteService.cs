using Upd8.Web.Dtos;
using Upd8.Web.Models;

namespace Upd8.Web.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> GetClientesAsync();
        Task<ClienteViewModel> GetClienteAsync(int id);
        Task<ClienteViewModel> InsertClienteAsync(ClienteViewModel cliente);
        Task<bool> DeleteClienteAsync(int id);
        Task<ClienteViewModel> UpdateClienteAsync(ClienteViewModel cliente);
    }
}
