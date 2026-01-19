using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class DClientes
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public List<Clientes> ListarTodo()
        {
            return dbcontext.Clientes
            .Where(c => c.Eliminado == false)
            .ToList();
        }
        public bool Registrar(Clientes cliente)
        {
            if (dbcontext.Clientes.Any(c => c.DNI == cliente.DNI && c.Eliminado == false))
            {
                return false;
            }
            else
            {
                dbcontext.Clientes.Add(cliente);
                dbcontext.SaveChanges();
                return true;
            }
        }
        public void Modificar(Clientes clienteModificado)
        {
            Clientes cliente = dbcontext.Clientes.Find(clienteModificado.ID_Cliente);
            cliente.DNI = clienteModificado.DNI;
            cliente.Nombre = clienteModificado.Nombre;
            cliente.Telefono = clienteModificado.Telefono;
            cliente.Email = clienteModificado.Email;
            cliente.Direccion = clienteModificado.Direccion;
            dbcontext.SaveChanges();
        }
        public void Eliminar(int idCliente)
        {
            Clientes cliente = dbcontext.Clientes.Find(idCliente);
            cliente.Eliminado = true;

            // Marcar los vehículos del cliente como eliminados
            foreach (var vehiculo in cliente.Vehiculos)
            {
                vehiculo.Eliminado = true;
            }
            dbcontext.SaveChanges();
        }
    }
}
