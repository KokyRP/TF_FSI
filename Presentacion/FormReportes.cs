using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormReportes : Form
    {
        private NReportes nReportes = new NReportes();
        private NCliente nCliente = new NCliente();
        public FormReportes()
        {
            InitializeComponent();
            CargarClientes(nCliente.ListarTodo());
        }
        private void CargarClientes(List<Clientes> clientes)
        {
            cbClientes.DataSource = null;
            if (clientes.Count == 0)
            {
                return;
            }
            else
            {
                cbClientes.DataSource = clientes;
                cbClientes.DisplayMember = "Nombre";
                cbClientes.ValueMember = "ID_Cliente";
            }
        }
        private void btnMontoPorDiaEspecifico_Click(object sender, EventArgs e)
        {
            if (dtpDia.Text == "")
            {
                MessageBox.Show("Ingrese el Dia Especifico");
                return;
            }
            decimal monto = nReportes.ObtenerMontoPorDiaEspecifico(dtpDia.Value);
            lblMontoPorDiaEspecifico.Text = "S/. " + monto.ToString();
        }

        private void btnMontoPorMesEspecifico_Click(object sender, EventArgs e)
        {
            if (dtpMes.Text == "")
            {
                MessageBox.Show("Ingrese el Mes Especifico");
                return;
            }
            decimal monto = nReportes.ObtenerMontoPorMesEspecifico(dtpMes.Value);
            lblMontoPorMesEspecifico.Text = "S/. " + monto.ToString();
        }

        private void btnListarMantenimientosEnRangoDeFechas_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicioMant.Text == "" || dtpFechaFinMant.Text == "")
            {
                MessageBox.Show("Ingrese ambas Fechas");
                return;
            }
            dgMantenimientosPorFecha.DataSource = nReportes.ObtenerMantenimientosPorFecha(dtpFechaInicioMant.Value, dtpFechaFinMant.Value);
            dgMantenimientosPorFecha.Columns["Eliminado"].Visible = false;
            dgMantenimientosPorFecha.Columns["Mantenimiento_Repuesto"].Visible = false;
            dgMantenimientosPorFecha.Columns["Mecanicos"].Visible = false;
            dgMantenimientosPorFecha.Columns["Servicios"].Visible = false;
            dgMantenimientosPorFecha.Columns["Vehiculos"].Visible = false;
        }

        private void btnObtenerListaVehiculosPorCliente_Click(object sender, EventArgs e)
        {
            if (cbClientes.Text == "")
            {
                MessageBox.Show("Ingrese un Cliente");
                return;
            }
            int idCliente = Convert.ToInt32(cbClientes.SelectedValue);

            // Obtener la lista de vehículos por cliente
            dgVehiculosPorCliente.DataSource = nReportes.ObtenerHistorialDeVehiculosPorCliente(idCliente);
            dgVehiculosPorCliente.Columns["Eliminado"].Visible = false;
            dgVehiculosPorCliente.Columns["Mantenimiento_Repuesto"].Visible = false;
            dgVehiculosPorCliente.Columns["Mecanicos"].Visible = false;
            dgVehiculosPorCliente.Columns["Servicios"].Visible = false;
            dgVehiculosPorCliente.Columns["Vehiculos"].Visible = false;
        }

        private void btnListarRepuestosOrdenados_Click(object sender, EventArgs e)
        {
            dgListaRepuestosOrdenandos.DataSource = nReportes.ObtenerRepuestosMasUsados();
        }

        private void btnObtenerMantenimientosPorMecanico_Click(object sender, EventArgs e)
        {
            dgObtenerMantenimientosPorMecanico.DataSource = nReportes.ObtenerMantenimientosPorMecanico();
        }

        private void btnListaServiciosOrdenado_Click(object sender, EventArgs e)
        {
            dgListaServiciosOrdenado.DataSource = nReportes.ObtenerServiciosMasSolicitados();
        }
    }
}
