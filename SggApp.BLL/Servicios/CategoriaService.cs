using SggApp.BLL.Interfaces;
using SggApp.DAL.Entidades;
using SggApp.DAL.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SggApp.BLL.Servicios
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodosAsync()
        {
            return await _categoriaRepository.GetAllAsync();
        }

        public async Task<Categoria> ObtenerPorIdAsync(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }

        public async Task AgregarAsync(Categoria categoria)
        {
            await _categoriaRepository.AddAsync(categoria);
        }

        public async Task ActualizarAsync(Categoria categoria)
        {
            _categoriaRepository.Update(categoria);
        }

        public async Task EliminarAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria != null)
            {
                _categoriaRepository.Delete(categoria);
            }
        }
    }
}
 
