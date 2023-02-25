using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventosController : ControllerBase
{
    private readonly IEventosService _eventoService;
    public EventosController(IEventosService eventoService)
    {
        this._eventoService = eventoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if(eventos == null) return NotFound("Nenhum evento encontrado.");

            return Ok(eventos);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var evento = await _eventoService.GetEventoByIdAsync(id, true);
            if(evento == null) return NotFound("Nenhum evento encontrado.");

            return Ok(evento);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
        }
    }

    [HttpGet("tema/{tema}")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if(eventos == null) return NotFound("Nenhum evento encontrado por tema.");

            return Ok(eventos);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
        try
        {
            var evento = await _eventoService.AddEvento(model);
            if(evento == null) return BadRequest("Erro ao tentar adicionar evento.");

            return Ok(evento);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
        try
        {
            var evento = await _eventoService.UpdateEvento(id, model);
            if(evento == null) return BadRequest("Erro ao tentar alterar evento.");

            return Ok(evento);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar alterar evento. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if(await _eventoService.DeleteEvento(id)){
                return Ok("Deletado");
            }
            else{
                return BadRequest("Evento não deletado.");
            }
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar deletar evento. Erro: {ex.Message}");
        }
    }
}
