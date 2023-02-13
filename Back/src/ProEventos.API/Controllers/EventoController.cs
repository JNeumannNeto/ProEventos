using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;
//using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> evento = new Evento[]{
        new Evento(){
            EventoId = 1,
            Tema = "Angular 11 e .NET 5",
            Local = "Belo Horizonte",
            Lote = "1o Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemURL = "imagem.png"
        },
        new Evento(){
            EventoId = 2,
            Tema = "Angular e suas novidades",
            Local = "Blumenau",
            Lote = "2o Lote",
            QtdPessoas = 150,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemURL = "imagem2.png"
        }
    };
    public EventoController()
    {
        
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> Get(int id)
    {
        return evento.Where(evento => evento.EventoId == id);
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
