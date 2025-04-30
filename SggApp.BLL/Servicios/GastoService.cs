using SggApp.BLL.Interfaces;
using SggApp.DAL.Entidades;
using SggApp.DAL.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SggApp.BLL.Servicios
{
    public class GastoService : IGastoService
    {
        private readonly GastoRepository _gastoRepository;

        public GastoService(GastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }

        public async Task<IEnumerable<Gasto>> ObtenerTodosAsync()
        {
            return await _gastoRepository.GetAllAsync();
        }

        public async Task<Gasto> ObtenerPorIdAsync(int id)
        {
            return await _gastoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Gasto>> ObtenerPorUsuarioAsync(int usuarioId)
        {
            return await _gastoRepository.GetByConditionAsync(g => g.UsuarioId == usuarioId);
        }

        public async Task AgregarAsync(Gasto gasto)
        {
            await _gastoRepository.AddAsync(gasto);
        }

        public async Task ActualizarAsync(Gasto gasto)
        {
            _gastoRepository.Update(gasto);
        }

        public async Task EliminarAsync(int id)
        {
            var gasto = await _gastoRepository.GetByIdAsync(id);
            if (gasto != null)
            {
                _gastoRepository.Delete(gasto);
            }
        }
    }
}
 
