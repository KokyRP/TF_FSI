using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class DMantenimiento
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public List<Mantenimientos> ListarTodo()
        {
            return dbcontext.Mantenimientos
                .Where(m => m.Eliminado == false)
                .ToList();
        }
        public void Registrar(Mantenimientos mantenimiento)
        {
            dbcontext.Mantenimientos.Add(mantenimiento);
            dbcontext.SaveChanges();
        }
        public void Modificar(Mantenimientos mantenimientoModificado)
        {
            Mantenimientos mantenimiento = dbcontext.Mantenimientos.Find(mantenimientoModificado.ID_Mantenimiento);
            mantenimiento.ID_Mecanico = mantenimientoModificado.ID_Mecanico;
            mantenimiento.ID_Vehiculo = mantenimientoModificado.ID_Vehiculo;
            mantenimiento.ID_Servicio = mantenimientoModificado.ID_Servicio;
            mantenimiento.Fecha = mantenimientoModificado.Fecha;
            dbcontext.SaveChanges();
        }
        public void Eliminar(int idMantenimiento)
        {
            Mantenimientos mantenimientos = dbcontext.Mantenimientos.Find(idMantenimiento);
            mantenimientos.Eliminado = true;
            dbcontext.SaveChanges();
        }
    }
}