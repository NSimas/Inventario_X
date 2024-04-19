using Microsoft.EntityFrameworkCore;

using Inventario_X.Models;
using Inventario_X.Data.Map;

namespace Inventario_X.Data
{
    //configuração das tabelas e do banco
    public class Inventario_XDBContext : DbContext
    {
        public Inventario_XDBContext(DbContextOptions<Inventario_XDBContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ItemModel> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ItemMap());

            base.OnModelCreating(modelBuilder);

        }
    }
}
