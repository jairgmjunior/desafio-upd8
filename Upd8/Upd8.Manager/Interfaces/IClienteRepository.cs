using Upd8.Core.Domain;

namespace Upd8.Manager.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente?> GetClienteAsync(int id);
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<Cliente> DeleteClienteAsync(int id);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
    }
}
