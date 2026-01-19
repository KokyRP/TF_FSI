using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCliente
    {
        private DClientes dClientes = new DClientes();
        public List<Clientes> ListarTodo()
        {
            return dClientes.ListarTodo();
        }
        public bool Registrar(Clientes clientes)
        {
            return dClientes.Registrar(clientes);
        }
        public void Modificar(Clientes clienteModificado)
        {
            dClientes.Modificar(clienteModificado);
        }
        public void Eliminar(int idCliente)
        {
            dClientes.Eliminar(idCliente);
        }
    }
}
