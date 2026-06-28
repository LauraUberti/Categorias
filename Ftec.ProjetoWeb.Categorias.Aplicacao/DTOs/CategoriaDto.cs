namespace Ftec.ProjetoWeb.Categorias.Aplicacao.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int? ParentId { get; set; }
    }
}