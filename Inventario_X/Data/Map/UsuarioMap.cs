using Inventario_X.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario_X.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CodigoUsuario).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(15);

        }
    }
}
