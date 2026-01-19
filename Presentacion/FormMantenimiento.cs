using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormMantenimiento : Form
    {
        private NMantenimiento nMantenimiento = new NMantenimiento();
        private NMecanico nMecanico = new NMecanico();
        private NVehiculo nVehiculo = new NVehiculo();
        private NServicios nServicios = new NServicios();
        public FormMantenimiento()
        {
            InitializeComponent();
            CargarMecanicos(nMecanico.ListarTodo());
            CargarVehiculos(nVehiculo.ListarTodos());
            CargarServicios(nServicios.ListarTodo());
            MostrarMantenimientos(nMantenimiento.ListarTodo());
        }
        private void CargarMecanicos(List<Mecanicos> mecanicos)
        {
            cbMecanico.DataSource = null;
            if (mecanicos.Count == 0)
            {
                return;
            }
            else
            {
                cbMecanico.DataSource = mecanicos;
                cbMecanico.DisplayMember = "Nombre";
                cbMecanico.ValueMember = "ID_Mecanico";
            }
        }
        private void CargarVehiculos(List<Vehiculos> vehiculos)
        {
            cbVehiculo.DataSource = null;
            if (vehiculos.Count == 0)
            {
                return;
            }
            else
            {
                cbVehiculo.DataSource = vehiculos;
                cbVehiculo.DisplayMember = "Placa";
                cbVehiculo.ValueMember = "ID_Vehiculo";
            }
        }
        private void CargarServicios(List<Servicios> servicios)
        {
            cbServicio.DataSource = null;
            if (servicios.Count == 0)
            {
                return;
            }
            else
            {
                cbServicio.DataSource = servicios;
                cbServicio.DisplayMember = "Descripcion";
                cbServicio.ValueMember = "ID_Servicio";
            }
        }
        private void MostrarMantenimientos(List<Mantenimientos> mantenimientos)
        {
            dgMantenimientos.DataSource = null;
            if (mantenimientos.Count == 0)
            {
                return;
            }
            else
            {
                dgMantenimientos.DataSource = mantenimientos;
                dgMantenimientos.Columns["Eliminado"].Visible = false;
                dgMantenimientos.Columns["Mantenimiento_Repuesto"].Visible = false;
                dgMantenimientos.Columns["Mecanicos"].Visible = false;
                dgMantenimientos.Columns["Servicios"].Visible = false;
                dgMantenimientos.Columns["Vehiculos"].Visible = false;
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbMecanico.Text == "" || cbServicio.Text == "" || cbVehiculo.Text == "" || dtpFecha.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos");
                return;
            }
            int idMecanico = int.Parse(cbMecanico.SelectedValue.ToString());
            int idVehiculo = int.Parse(cbVehiculo.SelectedValue.ToString());
            int idServicio = int.Parse(cbServicio.SelectedValue.ToString());
            Mantenimientos mantenimiento = new Mantenimientos()
            {
                ID_Mecanico = idMecanico,
                ID_Vehiculo = idVehiculo,
                ID_Servicio = idServicio,
                Fecha = dtpFecha.Value,
                Eliminado = false
            };
            nMantenimiento.Registrar(mantenimiento);
            MostrarMantenimientos(nMantenimiento.ListarTodo());
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cbMecanico.Text = "";
            cbServicio.Text = "";
            cbVehiculo.Text = "";
            dtpFecha.Text = "";
        }

        private void btnAsignarRepuestos_Click(object sender, EventArgs e)
        {
            if (dgMantenimientos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un Mantenimiento");
                return;
            }
            int idMantenimiento = int.Parse(dgMantenimientos.SelectedRows[0].Cells[0].Value.ToString());
            FormMantenimiento_Repuesto form = new FormMantenimiento_Repuesto(idMantenimiento);
            form.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgMantenimientos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un mantenimiento");
                return;
            }
            if (cbMecanico.Text == "" || cbServicio.Text == "" || cbVehiculo.Text == "" || dtpFecha.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos");
                return;
            }
            int idMantenimiento = int.Parse(dgMantenimientos.SelectedRows[0].Cells[0].ToString());
            int idMecanico = int.Parse(cbMecanico.SelectedValue.ToString());
            int idVehiculo = int.Parse(cbVehiculo.SelectedValue.ToString());
            int idServicio = int.Parse(cbServicio.SelectedValue.ToString());
            Mantenimientos mantenimiento = new Mantenimientos()
            {
                ID_Mantenimiento = idMantenimiento,
                ID_Mecanico = idMecanico,
                ID_Vehiculo = idVehiculo,
                ID_Servicio = idServicio,
                Fecha = dtpFecha.Value,
                Eliminado = false
            };
            nMantenimiento.Modificar(mantenimiento);
            MostrarMantenimientos(nMantenimiento.ListarTodo());
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgMantenimientos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un mantenimiento");
                return;
            }
            int idMantenimiento = int.Parse(dgMantenimientos.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult dialog = MessageBox.Show("Deseas eliminar el mantenimiento con ID: " + idMantenimiento, "", MessageBoxButtons.YesNo);
            if (dialog.Equals(DialogResult.Yes))
            {
                nMantenimiento.Eliminar(idMantenimiento); 
                MostrarMantenimientos(nMantenimiento.ListarTodo());
            }
        }
    }
}
