namespace Inventario_X.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public int CodigoItem { get; set; }
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}
