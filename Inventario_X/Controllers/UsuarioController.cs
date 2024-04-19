using Inventario_X.Models;
using Inventario_X.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario_X.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> ListarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarUsuario(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarUsuarioID(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AdicionarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuarioAdicionado = await _usuarioRepositorio.AdicionarUsuario(usuarioModel);
            return Ok(usuarioAdicionado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> EditarUsuario([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuarioEditado = await _usuarioRepositorio.AtualizarUsuario(usuarioModel, id);
            return Ok(usuarioEditado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarUsuario(int id)
        {
            bool? usuarioApagado = await _usuarioRepositorio.ApagarUsuario(id);
            return Ok(usuarioApagado);
        }
    }
}