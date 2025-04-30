using SggApp.DAL.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SggApp.BLL.Interfaces
{
    public interface IPresupuestoService
    {
        Task<IEnumerable<Presupuesto>> ObtenerTodosAsync();
        Task<Presupuesto> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Presupuesto presupuesto);
        Task ActualizarAsync(Presupuesto presupuesto);
        Task EliminarAsync(int id);
    }
}
 
