using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NMantenimiento
    {
        private DMantenimiento dMantenimiento = new DMantenimiento();
        public List<Mantenimientos> ListarTodo()
        {
            return dMantenimiento.ListarTodo();
        }
        public void Registrar(Mantenimientos mantenimiento)
        {
            dMantenimiento.Registrar(mantenimiento);
        }
        public void Modificar(Mantenimientos mantenimiento)
        {
            dMantenimiento.Modificar(mantenimiento);
        }
        public void Eliminar(int idMantenimiento)
        {
            dMantenimiento.Eliminar(idMantenimiento);
        }
    }
}
