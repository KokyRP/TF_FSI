using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class DMecanico
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public List<Mecanicos> ListarTodo()
        {
            return dbcontext.Mecanicos
                .Where(m => m.Eliminado == false)
                .ToList();
        }
        public bool Registrar(Mecanicos mecanico)
        {
            if (dbcontext.Mecanicos.Any(c => c.DNI == mecanico.DNI && c.Eliminado == false))
            {
                return false;
            }
            else
            {
                dbcontext.Mecanicos.Add(mecanico);
                dbcontext.SaveChanges();
                return true;
            }
        }
        public void Modificar(Mecanicos mecanicoModificado)
        {
            Mecanicos mecanico = dbcontext.Mecanicos.Find(mecanicoModificado.ID_Mecanico);
            mecanico.DNI = mecanicoModificado.DNI;
            mecanico.Nombre = mecanicoModificado.Nombre;
            mecanico.Telefono = mecanicoModificado.Telefono;
            mecanico.Email = mecanicoModificado.Email;
            mecanico.Direccion = mecanicoModificado.Direccion;
            dbcontext.SaveChanges();
        }
        public void Eliminar(int idMecanico)
        {
            Mecanicos mecanico = dbcontext.Mecanicos.Find(idMecanico);
            mecanico.Eliminado = true;
            dbcontext.SaveChanges();
        }
    }
}
