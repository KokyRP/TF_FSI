using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DMantenimientoxRepuesto
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public List<Mantenimiento_Repuesto> ListarTodo(int idMantenimiento)
        {
            return dbcontext.Mantenimiento_Repuesto
                .Where(m=>m.ID_Mantenimiento==idMantenimiento)
                .ToList();
        }
        public void Registrar(Mantenimiento_Repuesto mantenimiento_Repuesto)
        {
            dbcontext.Mantenimiento_Repuesto.Add(mantenimiento_Repuesto);
            dbcontext.SaveChanges();
        }
        public void Eliminar(int idMantenimiento)
        {
            Mantenimiento_Repuesto mantenimiento_repuesto = dbcontext.Mantenimiento_Repuesto.FirstOrDefault(m => m.ID_Mantenimiento == idMantenimiento);
            dbcontext.Mantenimiento_Repuesto.Remove(mantenimiento_repuesto);
            dbcontext.SaveChanges();
        }
    }
}
