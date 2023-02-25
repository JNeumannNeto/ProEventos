using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    //Cria um contexto a partir do EF Core, que é usado no Startup.cs
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options){}
        public DbSet <Evento> Eventos { get; set; }
        public DbSet <Lote> Lotes { get; set; }
        public DbSet <Palestrante> Palestrantes { get; set; }
        public DbSet <PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet <RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            //Para que toda vez que um Evento seja deletado, tambem as redes sociais dele sejam deletadas.
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            //Para que toda vez que um Palestrante seja deletado, tambem as redes sociais dele sejam deletadas.
            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);

            //Isso eh necessario quando uma tabela tem mais de uma chave estrangeira. 
            //No caso, em RedesSociais há Eventos e há Palestrantes. 
        }
    }
}