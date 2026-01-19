using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NServicios
    {
        private DServicios dServicios = new DServicios();
        public List<Servicios> ListarTodo()
        {
            return dServicios.ListarTodo();
        }
        public void Registrar(Servicios servicio)
        {
            dServicios.Registrar(servicio);
        }
        public void Modificar(Servicios servicioModificado)
        {
            dServicios.Modificar(servicioModificado);
        }
        public void Eliminar(int idServicio)
        {
            dServicios.Eliminar(idServicio);
        }
    }
}
