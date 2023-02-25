using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence
{
    public class PalestrantesPersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantesPersist (ProEventosContext context)
        {
            this._context = context;

            //Implementa para todo o service o no tracking do objeto
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            //Ao inves, adicionar em cada metodo o .AsNoTracking() para poder controlar quando se quer realmente aplicar o NoTracking.
        }
        
        //PALESTRANTES
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(includeEventos){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(includeEventos){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where( e => e.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(includeEventos){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where( e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}