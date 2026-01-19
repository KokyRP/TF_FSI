using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormClientes : Form
    {
        private NCliente nCliente = new NCliente();
        public FormClientes()
        {
            InitializeComponent();
            MostrarClientes(nCliente.ListarTodo());
        }
        public void MostrarClientes(List<Clientes> clientes)
        {
            dgClientes.DataSource = null;
            if (clientes.Count == 0)
            {
                return;
            }
            else
            {
                dgClientes.DataSource = clientes;
                dgClientes.Columns["Eliminado"].Visible = false;
                dgClientes.Columns["Vehiculos"].Visible = false;
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tbDNI.Text == "" || tbNombre.Text == "" || tbTelefono.Text == "" || tbEmail.Text == "" || tbDireccion.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (tbDNI.Text.Length != 8 || !int.TryParse(tbDNI.Text, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número entero de 8 dígitos");
                return;
            }
            if (!int.TryParse(tbTelefono.Text, out int telefono))
            {
                MessageBox.Show("El Teléfono debe ser un número entero");
                return;
            }
            Clientes clientes = new Clientes()
            {
                DNI = int.Parse(tbDNI.Text),
                Nombre = tbNombre.Text,
                Telefono = tbTelefono.Text,
                Email = tbEmail.Text,
                Direccion = tbDireccion.Text,
                Eliminado = false
            };
            bool registrar = nCliente.Registrar(clientes);
            if (registrar)
            {
                MessageBox.Show("Registrado Correctamente");
                MostrarClientes(nCliente.ListarTodo());
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("DNI repetido");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un Cliente");
                return;
            }
            if (tbDNI.Text == "" || tbNombre.Text == "" || tbTelefono.Text == "" || tbEmail.Text == "" || tbDireccion.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            if (tbDNI.Text.Length != 8 || !int.TryParse(tbDNI.Text, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número entero de 8 dígitos");
                return;
            }
            if (!int.TryParse(tbTelefono.Text, out int telefono))
            {
                MessageBox.Show("El Teléfono debe ser un número entero");
                return;
            }
            int idCliente = int.Parse(dgClientes.SelectedRows[0].Cells[0].Value.ToString());
            Clientes cliente = new Clientes()
            {
                ID_Cliente = idCliente,
                DNI = int.Parse(tbDNI.Text),
                Nombre = tbNombre.Text,
                Telefono = tbTelefono.Text,
                Email = tbEmail.Text,
                Direccion = tbDireccion.Text,
                Eliminado = false
            };
            nCliente.Modificar(cliente);
            MostrarClientes(nCliente.ListarTodo());
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un Cliente");
                return;
            }
            int idCliente = int.Parse(dgClientes.SelectedRows[0].Cells[0].Value.ToString());
            int DNI = int.Parse(dgClientes.SelectedRows[0].Cells["DNI"].Value.ToString());
            DialogResult dialog = MessageBox.Show("Deseas eliminar al cliente con DNI: " + DNI, "", MessageBoxButtons.YesNo);
            if (dialog.Equals(DialogResult.Yes))
            {
                nCliente.Eliminar(idCliente);
                MostrarClientes(nCliente.ListarTodo());
            }

        }

        private void btnVerVehiculos_Click(object sender, EventArgs e)
        {
            if (dgClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un Cliente");
                return;
            }
            int idCliente = int.Parse(dgClientes.SelectedRows[0].Cells[0].Value.ToString());
            string nombreCliente = dgClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();
            FormVehiculos form = new FormVehiculos(idCliente, nombreCliente);
            form.Show();
        }
        private void LimpiarCampos()
        {
            tbDireccion.Text = "";
            tbDNI.Text = "";
            tbEmail.Text = "";
            tbNombre.Text = "";
            tbTelefono.Text = "";
        }

    }
}
