using Microsoft.EntityFrameworkCore;
using Upd8.Core.Domain;
using Upd8.Data.Context;
using Upd8.Manager.Interfaces;

namespace Upd8.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Upd8Context _context;

        public ClienteRepository(Upd8Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes
                                 .Include(p => p.Endereco.Cidade)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Cliente?> GetClienteAsync(int id)
        {
            return await _context.Clientes
                                 .Include(p => p.Endereco)
                                 .Include(p => p.Endereco.Cidade)
                                 .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);

            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteDb = await _context.Clientes
                                 .Include(p => p.Endereco)
                                 .Include(p => p.Endereco.Cidade)
                                 .SingleOrDefaultAsync(p => p.Id == cliente.Id);

            if (clienteDb == null)
            {
                return null;
            }

            _context.Entry(clienteDb).CurrentValues.SetValues(cliente);

            clienteDb.Endereco = cliente.Endereco;            

            await _context.SaveChangesAsync();
            return clienteDb;
        }

        public async Task<Cliente> DeleteClienteAsync(int id)
        {
            var client = await _context.Clientes
                                 .Include(p => p.Endereco)
                                 .Include(p => p.Endereco.Cidade)
                                 .SingleOrDefaultAsync(p => p.Id == id);

            if (client == null) return null;

            var clienteRemovido = _context.Remove(client);
            await _context.SaveChangesAsync();

            return clienteRemovido.Entity;
        }
    }
}
