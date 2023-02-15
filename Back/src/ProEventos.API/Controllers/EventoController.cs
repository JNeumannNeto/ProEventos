using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;
//using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private readonly DataContext _context;
    public EventoController(DataContext context)
    {
        _context = context;

    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> Get(int id)
    {
        return _context.Eventos.Where(evento => evento.EventoId == id);
    }

    [HttpPost]
    public String Post()
    {
        return "post value";
    }

    [HttpPut("{id}")]
    public String Put(int id)
    {
        return $"put value {id}";
    }

    [HttpDelete("{id}")]
    public String Delete(int id)
    {
        return $"Delete value {id}";
    }
}
