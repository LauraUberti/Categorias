using Microsoft.AspNetCore.Mvc;
using Ftec.ProjetoWeb.Categorias.Aplicacao.Servicos;
using Ftec.ProjetoWeb.Categorias.Aplicacao.DTOs;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly CategoriaService _service;

    public CategoriaController(CategoriaService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.ListarTodas());

    [HttpPost]
    public async Task<IActionResult> Create(CategoriaDto dto)
    {
        await _service.Adicionar(dto);
        return CreatedAtAction(nameof(GetAll), new { id = dto.Id }, dto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Remover(id);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoriaDto dto)
    {
        if (id != dto.Id) return BadRequest("ID do registro inválido.");

        await _service.Atualizar(dto); 
        return NoContent();
    }
}