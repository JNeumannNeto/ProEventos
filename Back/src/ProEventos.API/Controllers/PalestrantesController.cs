using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PalestrantesController : ControllerBase
{
    private readonly IPalestrantesService _palestranteService;
    public PalestrantesController(IPalestrantesService palestranteService)
    {
        this._palestranteService = palestranteService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var palestrantes = await _palestranteService.GetAllPalestrantesAsync(true);
            if(palestrantes == null) return NotFound("Nenhum palestrante encontrado.");

            return Ok(palestrantes);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar palestrantes. Erro: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var palestrante = await _palestranteService.GetPalestranteByIdAsync(id, true);
            if(palestrante == null) return NotFound("Nenhum palestrante encontrado.");

            return Ok(palestrante);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar palestrante. Erro: {ex.Message}");
        }
    }

    [HttpGet("{tema}")]
    public async Task<IActionResult> GetByNome(string nome)
    {
        try
        {
            var palestrantes = await _palestranteService.GetAllPalestrantesByNomeAsync(nome, true);
            if(palestrantes == null) return NotFound("Nenhum palestrante encontrado por nome.");

            return Ok(palestrantes);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar palestrantes. Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Palestrante model)
    {
        try
        {
            var palestrante = await _palestranteService.AddPalestrante(model);
            if(palestrante == null) return BadRequest("Erro ao tentar adicionar palestrante.");

            return Ok(palestrante);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar palestrante. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Palestrante model)
    {
        try
        {
            var palestrante = await _palestranteService.UpdatePalestrante(id, model);
            if(palestrante == null) return BadRequest("Erro ao tentar alterar palestrante.");

            return Ok(palestrante);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar alterar palestrante. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if(await _palestranteService.DeletePalestrante(id)){
                return Ok("Deletado");
            }
            else{
                return BadRequest("Palestrante não deletado.");
            }
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar deletar palestrante. Erro: {ex.Message}");
        }
    }
}
