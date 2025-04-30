using SggApp.DAL.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SggApp.BLL.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObtenerTodosAsync();
        Task<Categoria> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Categoria categoria);
        Task ActualizarAsync(Categoria categoria);
        Task EliminarAsync(int id);
    }
}
 
