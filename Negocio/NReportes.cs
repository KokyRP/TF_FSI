using Datos;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using static Datos.Reportes;

namespace Negocio
{
    public class NReportes
    {
        private Reportes reportes = new Reportes();
        public decimal ObtenerMontoPorMesEspecifico(DateTime FechaEspecifica)
        {
            return reportes.ObtenerMontoPorMesEspecifico(FechaEspecifica);
        }
        public decimal ObtenerMontoPorDiaEspecifico(DateTime FechaEspecifica)
        {
            return reportes.ObtenerMontoPorDiaEspecifico(FechaEspecifica);
        }
        public List<Mantenimientos> ObtenerMantenimientosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return reportes.ObtenerMantenimientosPorFecha(fechaInicio, fechaFin);
        }
        public List<Mantenimientos> ObtenerHistorialDeVehiculosPorCliente(int idCliente)
        {
            return reportes.ObtenerHistorialDeVehiculosPorCliente(idCliente);
        }
        public List<RepuestoMasUsadoDTO> ObtenerRepuestosMasUsados()
        {
            return reportes.ObtenerRepuestosMasUsados();
        }
        public List<MecanicoMantenimientosDTO> ObtenerMantenimientosPorMecanico()
        {
            return reportes.ObtenerMantenimientosPorMecanico();
        }
        public List<ServicioMasSolicitadoDTO> ObtenerServiciosMasSolicitados()
        {
            return reportes.ObtenerServiciosMasSolicitados();
        }
    }
}