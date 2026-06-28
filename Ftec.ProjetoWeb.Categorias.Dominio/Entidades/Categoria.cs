namespace Ftec.ProjetoWeb.Categorias.Dominio.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int? ParentId { get; set; }

        // Propriedade de navegação
        public Categoria? Parent { get; set; }
    }
}