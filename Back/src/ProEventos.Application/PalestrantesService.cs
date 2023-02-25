using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class PalestrantesService : IPalestrantesService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPalestrantePersist _palestrantePersist;
        public PalestrantesService(IGeralPersist geralPersist, IPalestrantePersist palestrantePersist)
        {
            this._geralPersist = geralPersist;
            this._palestrantePersist = palestrantePersist;
        }
        public async Task<Palestrante> AddPalestrante(Palestrante model)
        {
            try
            {
                _geralPersist.Add<Palestrante>(model);
                if(await _geralPersist.SaveChangesAsync()){
                    return await _palestrantePersist.GetPalestranteByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (System.Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }       

        public async Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, false);
                if( palestrante == null) return null;

                model.Id = palestrante.Id;

                _geralPersist.Update(model);
                if(await _geralPersist.SaveChangesAsync()){
                    return await _palestrantePersist.GetPalestranteByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePalestrante(int palestranteId)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, false);

                if( palestrante == null) throw new Exception("Palestrante para delete não foi encontrado.");

                _geralPersist.Delete<Palestrante>(palestrante);
                 return await _geralPersist.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetAllPalestrantesAsync(false);
                if(palestrantes == null) return null;

                return palestrantes;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, includeEventos);
                if(palestrante == null) return null;

                return palestrante;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetAllPalestrantesByNomeAsync(nome, includeEventos);
                if(palestrantes == null) return null;

                return palestrantes;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}