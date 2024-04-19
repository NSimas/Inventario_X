using Inventario_X.Models;

namespace Inventario_X.Repositorios.Interfaces
{
    public interface IItemRepositorio
    {
        Task<List<ItemModel>> BuscarTodosItens();
        Task<ItemModel> BuscarItemID(int id);
        Task<ItemModel> AdicionarItem(ItemModel item);
        Task<ItemModel?> AtualizarItem(ItemModel item, int id);
        Task<bool?> ApagarItem(int id);
    }
}
