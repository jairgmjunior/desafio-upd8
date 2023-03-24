using Microsoft.EntityFrameworkCore;
using Upd8.Core.Domain;
using Upd8.Core.Enums;
using Upd8.Data.Context;
using Upd8.Manager.Interfaces;

namespace Upd8.Data.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly Upd8Context _context;

        public CidadeRepository(Upd8Context context)
        {
            _context = context;
        }

        public async Task<Cidade?> GetCidadePorCodigoIbge(string codigo)
        {
            return await _context.Cidades.FirstOrDefaultAsync(p => p.CodigoIbge == codigo);
        }

        public async Task<List<Cidade>> GetCidadesPaginadasPorEstado(int pageSize, int pageNum, string searchTerm, EEStado estado)
        {
            var teste =  await _context.Cidades
                                .OrderBy(c => c.Nome)
                                .Where(p => p.Estado == estado)
                                .Where(p => p.Nome.ToUpper().Contains(searchTerm.ToUpper()))
                                .Skip((pageNum - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return teste;
        }
    }
}
