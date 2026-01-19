using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Cobranzas
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public class ClienteIngresosDTO
        {
            public int ID_Cliente { get; set; }
            public int DNI { get; set; }
            public decimal Pago_Total { get; set; }
        }
        public List<ClienteIngresosDTO> ObtenerIngresosClientes()
        {
            return dbcontext.Mantenimientos
                .Where(m => m.Eliminado==false) 
                .GroupBy(m => m.Vehiculos.Clientes.ID_Cliente) 
                .Select(group => new ClienteIngresosDTO
                {
                    ID_Cliente = group.Key, 
                    DNI = group.FirstOrDefault().Vehiculos.Clientes.DNI,
                    Pago_Total = group.Sum(m =>
                        (m.Servicios.Costo ?? 0) + 
                        (m.Mantenimiento_Repuesto.Any() ? 
                            m.Mantenimiento_Repuesto.Sum(mr =>
                                (mr.Cantidad_Usada ?? 0) * (mr.Repuestos.Precio ?? 0)
                            ) : 0)
                    )
                })
                .OrderByDescending(c => c.Pago_Total) 
                .ToList(); 
        }

        public List<ClienteIngresosDTO> ObtenerIngresosPorCliente(int DNI)
        {
            return dbcontext.Mantenimientos
                .Where(m => m.Eliminado==false && m.Vehiculos.Clientes.DNI == DNI) 
                .GroupBy(m => m.Vehiculos.Clientes.ID_Cliente)
                .Select(group => new ClienteIngresosDTO
                {
                    ID_Cliente = group.Key, 
                    DNI = group.FirstOrDefault().Vehiculos.Clientes.DNI,
                    Pago_Total = group.Sum(m =>
                        (m.Servicios.Costo ?? 0) + 
                        (m.Mantenimiento_Repuesto.Any() ? 
                            m.Mantenimiento_Repuesto.Sum(mr =>
                                (mr.Cantidad_Usada ?? 0) * (mr.Repuestos.Precio ?? 0)
                            ) : 0) 
                    )
                })
                .OrderByDescending(c => c.Pago_Total)
                .ToList();
        }
    }
}
