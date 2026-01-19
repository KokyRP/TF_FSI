using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NRepuesto
    {
        private DRepuestos dRepuestos = new DRepuestos();
        public List<Repuestos> ListarTodo()
        {
            return dRepuestos.ListarTodo();
        }
        public void Registrar(Repuestos repuesto)
        {
            dRepuestos.Registrar(repuesto);
        }
        public void Modificar(Repuestos repuestoModificado)
        {
            dRepuestos.Modificar(repuestoModificado);
        }
        public void QuitarDelInventario(int idRepuesto, int cantidadUsada)
        {
            dRepuestos.QuitarDelInventario(idRepuesto, cantidadUsada);
        }
        public void DevolverAlInventario(int idRepuesto, int cantidadUsada)
        {
            dRepuestos.DevolverAlInventario(idRepuesto, cantidadUsada);    
        }
        public void Eliminar(int idRepuesto)
        {
            dRepuestos.Eliminar(idRepuesto);
        }
    }
}
