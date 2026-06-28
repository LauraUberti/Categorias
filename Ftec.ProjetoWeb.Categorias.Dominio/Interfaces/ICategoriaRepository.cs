using Ftec.ProjetoWeb.Categorias.Dominio.Entidades;

namespace Ftec.ProjetoWeb.Categorias.Dominio.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int id);
        Task AddAsync(Categoria categoria);
        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int id);
    }
}