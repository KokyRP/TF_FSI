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
    public partial class FormMecanicos : Form
    {
        private NMecanico nMecanico = new NMecanico();
        public FormMecanicos()
        {
            InitializeComponent();
            MostrarMecanicos(nMecanico.ListarTodo());
        }
        public void MostrarMecanicos(List<Mecanicos> mecanicos)
        {
            dgMecanicos.DataSource = null;
            if (mecanicos.Count == 0)
            {
                return;
            }
            else
            {
                dgMecanicos.DataSource = mecanicos;
                dgMecanicos.Columns["Eliminado"].Visible = false;
                dgMecanicos.Columns["Mantenimientos"].Visible = false;
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
            Mecanicos mecanico = new Mecanicos()
            {
                DNI = int.Parse(tbDNI.Text),
                Nombre = tbNombre.Text,
                Telefono = tbTelefono.Text,
                Email = tbEmail.Text,
                Direccion = tbDireccion.Text,
                Eliminado = false
            };
            bool registrar = nMecanico.Registrar(mecanico);
            if (registrar)
            {
                MessageBox.Show("Registrado Correctamente");
                MostrarMecanicos(nMecanico.ListarTodo());
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("DNI repetido");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgMecanicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un mecanico");
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
            int idMecanico = int.Parse(dgMecanicos.SelectedRows[0].Cells[0].Value.ToString());
            Mecanicos mecanico = new Mecanicos()
            {
                ID_Mecanico = idMecanico,
                DNI = int.Parse(tbDNI.Text),
                Nombre = tbNombre.Text,
                Telefono = tbTelefono.Text,
                Email = tbEmail.Text,
                Direccion = tbDireccion.Text,
                Eliminado = false
            };
            nMecanico.Modificar(mecanico);
            MostrarMecanicos(nMecanico.ListarTodo());
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgMecanicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un mecanico");
                return;
            }
            int idMecanico = int.Parse(dgMecanicos.SelectedRows[0].Cells[0].Value.ToString());
            int DNI = int.Parse(dgMecanicos.SelectedRows[0].Cells["DNI"].Value.ToString());
            DialogResult dialog = MessageBox.Show("Deseas eliminar al mecanico con DNI: " + DNI, "", MessageBoxButtons.YesNo);
            if (dialog.Equals(DialogResult.Yes))
            {
                nMecanico.Eliminar(idMecanico);
                MostrarMecanicos(nMecanico.ListarTodo());
            }

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
