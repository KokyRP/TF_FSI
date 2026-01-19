using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Reportes
    {
        private TallerMecanicoEntities dbcontext = new TallerMecanicoEntities();
        public decimal ObtenerMontoPorMesEspecifico(DateTime FechaEspecifica)
        {
            int anioEspecifico = FechaEspecifica.Year;
            int mesEspecifico = FechaEspecifica.Month;
            var mantenimientosDelMes = dbcontext.Mantenimientos
                .Where(m => m.Fecha.Year == anioEspecifico && m.Fecha.Month == mesEspecifico && m.Eliminado == false)
                .Include(m => m.Servicios)
                .Include(m => m.Mantenimiento_Repuesto)
                .ToList();
            decimal totalMonto = 0;
            foreach (var mantenimiento in mantenimientosDelMes)
            {
                totalMonto += (decimal)mantenimiento.Servicios.Costo;
                foreach (var mantenimientoRepuesto in mantenimiento.Mantenimiento_Repuesto)
                {
                    var repuesto = dbcontext.Repuestos
                        .Where(r => r.ID_Repuesto == mantenimientoRepuesto.ID_Repuesto)
                        .FirstOrDefault();
                    if (repuesto != null)
                    {
                        totalMonto += (decimal)repuesto.Precio * (decimal)mantenimientoRepuesto.Cantidad_Usada;
                    }
                }
            }
            return totalMonto;
        }
        public decimal ObtenerMontoPorDiaEspecifico(DateTime FechaEspecifica)
        {
            int anioEspecifico = FechaEspecifica.Year;
            int mesEspecifico = FechaEspecifica.Month;
            int diaEspecifico = FechaEspecifica.Day;
            var mantenimientosDelMes = dbcontext.Mantenimientos
                .Where(m => m.Fecha.Year == anioEspecifico && m.Fecha.Month == mesEspecifico && m.Fecha.Day == diaEspecifico && m.Eliminado == false)
                .Include(m => m.Servicios)
                .Include(m => m.Mantenimiento_Repuesto)
                .ToList();
            decimal totalMonto = 0;
            foreach (var mantenimiento in mantenimientosDelMes)
            {
                totalMonto += (decimal)mantenimiento.Servicios.Costo;
                foreach (var mantenimientoRepuesto in mantenimiento.Mantenimiento_Repuesto)
                {
                    var repuesto = dbcontext.Repuestos
                        .Where(r => r.ID_Repuesto == mantenimientoRepuesto.ID_Repuesto)
                        .FirstOrDefault();
                    if (repuesto != null)
                    {
                        totalMonto += (decimal)repuesto.Precio * (decimal)mantenimientoRepuesto.Cantidad_Usada;
                    }
                }
            }
            return totalMonto;
        }
        public List<Mantenimientos> ObtenerMantenimientosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return dbcontext.Mantenimientos
                .Where(m => m.Fecha >= fechaInicio && m.Fecha <= fechaFin && m.Eliminado == false)
                .ToList();
        }
        public List<Mantenimientos> ObtenerHistorialDeVehiculosPorCliente(int idCliente)
        {
            return dbcontext.Mantenimientos
                .Where(m => m.Vehiculos.ID_Cliente == idCliente && m.Eliminado == false)
                .Include(m => m.Vehiculos)
                .Include(m => m.Servicios)
                .ToList();
        }
        public class RepuestoMasUsadoDTO
        {
            public int ID_Repuesto { get; set; }
            public int Cantidad_Usada { get; set; }
        }

        public List<RepuestoMasUsadoDTO> ObtenerRepuestosMasUsados()
        {
            return dbcontext.Mantenimiento_Repuesto
                .GroupBy(mr => mr.ID_Repuesto)
                .Select(group => new RepuestoMasUsadoDTO
                {
                    ID_Repuesto = group.Key,
                    Cantidad_Usada = group.Sum(mr => (int)mr.Cantidad_Usada)
                })
                .OrderByDescending(x => x.Cantidad_Usada)
                .ToList();
        }
        public class MecanicoMantenimientosDTO
        {
            public int ID_Mecanico { get; set; }
            public string Nombre { get; set; }
            public int TotalMantenimientos { get; set; }
        }
        public List<MecanicoMantenimientosDTO> ObtenerMantenimientosPorMecanico()
        {
            return dbcontext.Mantenimientos
                .Where(m => m.Eliminado == false)
                .GroupBy(m => m.Mecanicos.ID_Mecanico)
                .Select(group => new MecanicoMantenimientosDTO
                {
                    ID_Mecanico = group.Key,
                    Nombre = group.FirstOrDefault().Mecanicos.Nombre,
                    TotalMantenimientos = group.Count()
                })
                .OrderByDescending(x => x.TotalMantenimientos)
                .ToList();
        }
        public class ServicioMasSolicitadoDTO
        {
            public int ID_Servicio { get; set; }
            public string Descripcion { get; set; }
            public int TotalSolicitudes { get; set; }
        }

        public List<ServicioMasSolicitadoDTO> ObtenerServiciosMasSolicitados()
        {
            return dbcontext.Mantenimientos
                .Where(m => m.Eliminado == false)
                .GroupBy(m => m.ID_Servicio)
                .Select(group => new ServicioMasSolicitadoDTO
                {
                    ID_Servicio = (int)group.Key,
                    Descripcion = group.FirstOrDefault().Servicios.Descripcion,
                    TotalSolicitudes = group.Count()
                })
                .OrderByDescending(x => x.TotalSolicitudes)
                .ToList();
        }

    }
}
