using Ftec.ProjetoWeb.Categorias.Aplicacao.DTOs;
using Ftec.ProjetoWeb.Categorias.Dominio.Interfaces;
using Ftec.ProjetoWeb.Categorias.Dominio.Entidades;

namespace Ftec.ProjetoWeb.Categorias.Aplicacao.Servicos
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoriaDto>> ListarTodas()
        {
            var categorias = await _repository.GetAllAsync();
            return categorias.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao,
                ParentId = c.ParentId
            });
        }

        public async Task Adicionar(CategoriaDto dto)
        {
            var categoria = new Categoria
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                ParentId = dto.ParentId
            };
            await _repository.AddAsync(categoria);
        }

        public async Task Remover(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task Atualizar(CategoriaDto dto)
        {
            // 1. Busca a entidade original no banco
            var categoria = await _repository.GetByIdAsync(dto.Id);
            if (categoria == null) throw new Exception("Categoria não encontrada.");

            // 2. Atualiza os campos
            categoria.Nome = dto.Nome;
            categoria.Descricao = dto.Descricao;
            categoria.ParentId = dto.ParentId;

            // 3. Salva no banco
            await _repository.UpdateAsync(categoria);
        }
    }
}