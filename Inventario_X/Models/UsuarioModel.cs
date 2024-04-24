using System.ComponentModel.DataAnnotations;

namespace Inventario_X.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public int CodigoUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int? Telefone { get; set; }
        public string? Senha { get; set; }
    }
}
