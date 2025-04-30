using SggApp.DAL.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SggApp.BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task EliminarAsync(int id);
    }
}
 
