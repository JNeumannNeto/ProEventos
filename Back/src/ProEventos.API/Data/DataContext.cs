using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    //Cria um contexto a partir do EF Core, que é usado no Startup.cs
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet <Evento> Eventos { get; set; }
    }
}