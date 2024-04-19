using Inventario_X.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario_X.Data.Map
{
    public class ItemMap : IEntityTypeConfiguration<ItemModel>
    {

        public void Configure(EntityTypeBuilder<ItemModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CodigoItem).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(700);
            builder.Property(x => x.Quantidade).IsRequired();

        }
    }
}
