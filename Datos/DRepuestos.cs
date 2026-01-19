using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DRepuestos
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public List<Repuestos> ListarTodo()
        {
            return dbcontext.Repuestos
            .Where(c => c.Eliminado == false)
            .ToList();
        }
        public void Registrar(Repuestos repuesto)
        {
            dbcontext.Repuestos.Add(repuesto);
            dbcontext.SaveChanges();
        }
        public void Modificar(Repuestos repuestoModificado)
        {
            Repuestos repuesto = dbcontext.Repuestos.Find(repuestoModificado.ID_Repuesto);
            repuesto.Nombre = repuestoModificado.Nombre;
            repuesto.Descripcion = repuestoModificado.Descripcion;
            repuesto.Precio=repuestoModificado.Precio;
            repuesto.Cantidad_Inventario=repuestoModificado.Cantidad_Inventario;
            dbcontext.SaveChanges();
        }
        public void QuitarDelInventario(int idRepuesto, int cantidadUsada)
        {
            Repuestos repuesto = dbcontext.Repuestos.Find(idRepuesto);
            repuesto.Cantidad_Inventario -= cantidadUsada;
            dbcontext.SaveChanges();
        }
        public void DevolverAlInventario(int idRepuesto, int cantidadUsada)
        {
            Repuestos repuesto = dbcontext.Repuestos.Find(idRepuesto);
            repuesto.Cantidad_Inventario += cantidadUsada;
            dbcontext.SaveChanges();
        }
        public void Eliminar(int idRepuesto)
        {
            Repuestos repuesto = dbcontext.Repuestos.Find(idRepuesto);
            repuesto.Eliminado = true;
            dbcontext.SaveChanges();
        }
    }
}
