using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NVehiculo
    {
        private DVehiculos dVehiculos = new DVehiculos();
        public List<Vehiculos> ListarTodo(int idCliente)
        {
            return dVehiculos.ListarTodo(idCliente);
        }
        public List<Vehiculos> ListarTodos()
        {
            return dVehiculos.ListarTodos();
        }
        public bool Registrar(Vehiculos vehiculo)
        {
            return dVehiculos.Registrar(vehiculo);
        }
        public void Modificar(Vehiculos vehiculoModificado)
        {
            dVehiculos.Modificar(vehiculoModificado);
        }
        public void Eliminar(int idVehiculo)
        {
            dVehiculos.Eliminar(idVehiculo);
        }
    }
}
