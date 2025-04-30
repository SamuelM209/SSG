using SggApp.DAL.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SggApp.BLL.Interfaces
{
    public interface IMonedaService
    {
        Task<IEnumerable<Moneda>> ObtenerTodosAsync();
        Task<Moneda> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Moneda moneda);
        Task ActualizarAsync(Moneda moneda);
        Task EliminarAsync(int id);
    }
}
 
