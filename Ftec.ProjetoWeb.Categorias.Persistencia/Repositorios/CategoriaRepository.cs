using Ftec.ProjetoWeb.Categorias.Dominio.Entidades;
using Ftec.ProjetoWeb.Categorias.Dominio.Interfaces;
using Ftec.ProjetoWeb.Categorias.Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Ftec.ProjetoWeb.Categorias.Persistencia.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync() =>
            await _context.Categorias.ToListAsync();

        public async Task<Categoria?> GetByIdAsync(int id) =>
            await _context.Categorias.FindAsync(id);

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cat = await GetByIdAsync(id);
            if (cat != null)
            {
                _context.Categorias.Remove(cat);
                await _context.SaveChangesAsync();
            }
        }
    }
}