using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static Datos.Cobranzas;

namespace Negocio
{
    public class NCobranzas
    {
        private Cobranzas cobranzas = new Cobranzas();
        public List<ClienteIngresosDTO> ObtenerIngresosClientes()
        {
            return cobranzas.ObtenerIngresosClientes();
        }
        public List<ClienteIngresosDTO> ObtenerIngresosPorCliente(int DNI)
        {
            return cobranzas.ObtenerIngresosPorCliente(DNI);
        }
    }
}
