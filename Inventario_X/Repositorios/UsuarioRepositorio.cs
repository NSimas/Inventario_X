using Inventario_X.Data;
using Inventario_X.Models;
using Inventario_X.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Inventario_X.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly Inventario_XDBContext _dbContext;

        public UsuarioRepositorio(Inventario_XDBContext Inventario_XDBContext)
        {
            _dbContext = Inventario_XDBContext;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> BuscarUsuarioID(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel?> AtualizarUsuario(UsuarioModel usuario, int id)
        {

            UsuarioModel usuarioPorId = await BuscarUsuarioID(id);

            if (usuarioPorId == null)
            {
                return null;
            }

            usuarioPorId.CodigoUsuario = usuario.CodigoUsuario;
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Telefone = usuario.Telefone;
            usuarioPorId.Senha = usuario.Senha;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;

        }

        public async Task<bool?> ApagarUsuario(int id)
        {

            UsuarioModel usuarioPorId = await BuscarUsuarioID(id);

            if (usuarioPorId == null)
            {
                return false;
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
