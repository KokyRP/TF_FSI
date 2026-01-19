using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NMantenimientoxRepuesto
    {
        private DMantenimientoxRepuesto dMantenimientoxRepuesto = new DMantenimientoxRepuesto();
        public List<Mantenimiento_Repuesto> ListarTodo(int idMantenimiento)
        {
            return dMantenimientoxRepuesto.ListarTodo(idMantenimiento);
        }
        public void Registrar(Mantenimiento_Repuesto mantenimiento_Repuesto)
        {
            dMantenimientoxRepuesto.Registrar(mantenimiento_Repuesto);
        }
        public void Eliminar(int idMantenimiento)
        {
            dMantenimientoxRepuesto.Eliminar(idMantenimiento);
        }
    }
}
