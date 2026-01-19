using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class DServicios
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public List<Servicios> ListarTodo()
        {
            return dbcontext.Servicios
            .Where(c => c.Eliminado == false)
            .ToList();
        }
        public void Registrar(Servicios servicio)
        {
            dbcontext.Servicios.Add(servicio);
            dbcontext.SaveChanges();
        }
        public void Modificar(Servicios servicioModificado)
        {
            Servicios servicio = dbcontext.Servicios.Find(servicioModificado.ID_Servicio);
            servicio.Descripcion = servicioModificado.Descripcion;
            servicio.Costo = servicioModificado.Costo;
            dbcontext.SaveChanges();
        }
        public void Eliminar(int idServicio)
        {
            Servicios servicio = dbcontext.Servicios.Find(idServicio);
            servicio.Eliminado = true;
            dbcontext.SaveChanges();
        }
    }
}
