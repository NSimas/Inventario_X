using Inventario_X.Data;
using Inventario_X.Models;
using Inventario_X.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Inventario_X.Repositorios
{
    public class ItemRepositorio : IItemRepositorio
    {

        private readonly Inventario_XDBContext _dbContext;

        public ItemRepositorio(Inventario_XDBContext Inventario_XDBContext)
        {
            _dbContext = Inventario_XDBContext;
        }

        public async Task<List<ItemModel>> BuscarTodosItens()
        {
            return await _dbContext.Itens.ToListAsync();
        }

        public async Task<ItemModel> BuscarItemID(int id)
        {
            return await _dbContext.Itens.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ItemModel> AdicionarItem(ItemModel item)
        {
            await _dbContext.Itens.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return item;
        }

        public async Task<ItemModel?> AtualizarItem(ItemModel item, int id)
        {

            ItemModel itemPorId = await BuscarItemID(id);

            if (itemPorId == null)
            {
                return null;
            }

            itemPorId.CodigoItem = item.CodigoItem;
            itemPorId.Descricao = item.Descricao;
            itemPorId.Quantidade = item.Quantidade;

            _dbContext.Itens.Update(itemPorId);
            await _dbContext.SaveChangesAsync();

            return itemPorId;

        }

        public async Task<bool?> ApagarItem(int id)
        {

            ItemModel itemPorId = await BuscarItemID(id);

            if (itemPorId == null)
            {
                return false;
            }

            _dbContext.Itens.Remove(itemPorId);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
