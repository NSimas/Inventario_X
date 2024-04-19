using Inventario_X.Models;
using Inventario_X.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario_X.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepositorio _itemRepositorio;

        public ItemController(IItemRepositorio itemRepositorio)
        {
            _itemRepositorio = itemRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemModel>>> BuscarTodosItens()
        {
            List<ItemModel> itens = await _itemRepositorio.BuscarTodosItens();
            return Ok(itens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ItemModel>>> BuscarItem(int id)
        {
            ItemModel item = await _itemRepositorio.BuscarItemID(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> AdicionarItem([FromBody] ItemModel itemModel)
        {
            ItemModel itemdicionado = await _itemRepositorio.AdicionarItem(itemModel);
            return Ok(itemdicionado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemModel>> AtualizarItem([FromBody] ItemModel itemModel, int id)
        {
            itemModel.Id = id;
            ItemModel? itemEditado = await _itemRepositorio.AtualizarItem(itemModel, id);
            return Ok(itemEditado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarItem(int id)
        {
            bool? itemApagado = await _itemRepositorio.ApagarItem(id);
            return Ok(itemApagado);
        }
    }
}