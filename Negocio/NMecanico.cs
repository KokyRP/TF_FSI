using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NMecanico
    {
        private DMecanico dMecanico = new DMecanico();
        public List<Mecanicos> ListarTodo()
        {
            return dMecanico.ListarTodo();
        }
        public bool Registrar(Mecanicos mecanico)
        {
            return dMecanico.Registrar(mecanico);
        }
        public void Modificar(Mecanicos mecanicoModificado)
        {
            dMecanico.Modificar(mecanicoModificado);
        }
        public void Eliminar(int idMecanico)
        {
            dMecanico.Eliminar(idMecanico);
        }
    }
}
