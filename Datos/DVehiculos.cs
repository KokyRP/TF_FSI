using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class DVehiculos
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public List<Vehiculos> ListarTodo(int idCliente)
        {
            return dbcontext.Vehiculos
                .Where(v => v.ID_Cliente == idCliente && v.Eliminado == false)
                .ToList();
        }
        public List<Vehiculos> ListarTodos()
        {
            return dbcontext.Vehiculos
                .Where(v=> v.Eliminado == false)
                .ToList();
        }
        public bool Registrar(Vehiculos vehiculo)
        {
            if (dbcontext.Vehiculos.Any(v => v.Placa == vehiculo.Placa && v.Eliminado == false))
            {
                return false;
            }
            else
            {
                dbcontext.Vehiculos.Add(vehiculo);
                dbcontext.SaveChanges();
                return true;
            }
        }
        public void Modificar(Vehiculos vehiculoModificado)
        {
            Vehiculos vehiculo = dbcontext.Vehiculos.Find(vehiculoModificado.ID_Cliente);
            vehiculo.Placa = vehiculoModificado.Placa;
            vehiculo.Marca = vehiculoModificado.Marca;
            vehiculo.Modelo = vehiculoModificado.Modelo;
            vehiculo.Año = vehiculoModificado.Año;
            dbcontext.SaveChanges();
        }
        public void Eliminar(int idVehiculo)
        {
            Vehiculos vehiculo = dbcontext.Vehiculos.Find(idVehiculo);
            vehiculo.Eliminado= true; 
            dbcontext.SaveChanges();
        }
    }
}
