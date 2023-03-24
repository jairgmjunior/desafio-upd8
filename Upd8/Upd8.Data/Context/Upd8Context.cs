using Microsoft.EntityFrameworkCore;
using Upd8.Core.Domain;
using Upd8.Data.Configuration;

namespace Upd8.Data.Context
{
    public class Upd8Context : DbContext
    {
        public Upd8Context(DbContextOptions options): base(options) 
        { 
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new CidadeConfiguration());
        }
    }
}
