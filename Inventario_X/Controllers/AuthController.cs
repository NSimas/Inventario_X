using Inventario_X.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventario_X.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpPost]

        public IActionResult Auth(string username, string password)
        {
            //Aqui está fixo o usuário e senha, mas o correto é buscar no
            //banco de dados, conferir se o cargo dele é algo com autorização
            //de administração, se está ativo, se houver outro tipo de
            //verificação na regra de negócio, etc., essa engine de autenticação
            //é apenas um exemplo para o projeto funcionar.
            if (username == "teste@email.com" && password == "SenhaSenha@123123")
            {
                var token = TokenService.GenerateToken(new Models.UsuarioModel());
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
