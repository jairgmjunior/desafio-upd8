using Upd8.Core.Shared.ViewModels;

namespace Upd8.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task<IEnumerable<ClienteResponseViewModel>> GetClientesAsync();
        Task<ClienteResponseViewModel?> GetClienteAsync(int id);
        Task<ClienteResponseViewModel> InsereClienteAsync(NovoClienteViewModel cliente);
        Task<ClienteResponseViewModel> UpdateClienteAsync(AtualizaClienteViewModel cliente);
        Task<ClienteResponseViewModel> DeletaClienteAsync(int id);
    }
}
