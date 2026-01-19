using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormVehiculos : Form
    {
        private int idCliente;
        private NVehiculo nVehiculo = new NVehiculo();
        public FormVehiculos(int idCliente, string nombreCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            lblNombreCliente.Text = nombreCliente;
            MostrarVehiculos(nVehiculo.ListarTodo(idCliente));

        }
        public void MostrarVehiculos(List<Vehiculos> vehiculos)
        {
            dgVehiculos.DataSource = null;
            if (vehiculos.Count == 0)
            {
                return;
            }
            else
            {
                dgVehiculos.DataSource = vehiculos;
                dgVehiculos.Columns["Eliminado"].Visible = false;
                dgVehiculos.Columns["Clientes"].Visible = false;
                dgVehiculos.Columns["Mantenimientos"].Visible = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tbPlaca.Text == "" || tbModelo.Text == "" || tbMarca.Text == "" || tbAño.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (!int.TryParse(tbAño.Text, out int anio))
            {
                MessageBox.Show("El Año debe ser un número entero");
                return;
            }
            Vehiculos vehiculo = new Vehiculos()
            {
                Placa = tbPlaca.Text,
                Marca = tbMarca.Text,
                Modelo = tbModelo.Text,
                Año = anio,
                ID_Cliente = idCliente,
                Eliminado = false
            };
            bool registrar = nVehiculo.Registrar(vehiculo);
            if (registrar)
            {
                MessageBox.Show("Registrado Correctamente");
                MostrarVehiculos(nVehiculo.ListarTodo(idCliente));
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Placa repetida");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tbPlaca.Text == "" || tbModelo.Text == "" || tbMarca.Text == "" || tbAño.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (!int.TryParse(tbAño.Text, out int anio))
            {
                MessageBox.Show("El Año debe ser un número entero");
                return;
            }
            if (dgVehiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un Vehiculo");
                return;
            }
            int idVehiculo = int.Parse(dgVehiculos.SelectedRows[0].Cells[0].Value.ToString());
            Vehiculos vehiculo = new Vehiculos()
            {
                ID_Vehiculo = idVehiculo,
                Placa = tbPlaca.Text,
                Marca = tbMarca.Text,
                Modelo = tbModelo.Text,
                Año = anio,
                ID_Cliente = idCliente,
                Eliminado = false
            };
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgVehiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un Vehiculo");
                return;
            }
            int idVehiculo = int.Parse(dgVehiculos.SelectedRows[0].Cells[0].Value.ToString());
            int placa = int.Parse(dgVehiculos.SelectedRows[0].Cells["Placa"].Value.ToString());
            DialogResult dialog = MessageBox.Show("Deseas eliminar el vehiculo con placa: " + placa, "", MessageBoxButtons.YesNo);
            if (dialog.Equals(DialogResult.Yes))
            {
                nVehiculo.Eliminar(idVehiculo);
                MostrarVehiculos(nVehiculo.ListarTodo(idCliente));
            }
        }
        private void LimpiarCampos()
        {
            tbPlaca.Text = "";
            tbModelo.Text = "";
            tbMarca.Text = "";
            tbAño.Text = "";
        }
    }
}
