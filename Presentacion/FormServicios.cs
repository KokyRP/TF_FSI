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
    public partial class FormServicios : Form
    {
        private NServicios nServicios = new NServicios();
        public FormServicios()
        {
            InitializeComponent();
            MostrarServicios(nServicios.ListarTodo());
        }
        private void MostrarServicios(List<Servicios> servicios)
        {
            dgServicios.DataSource = null;
            if (servicios.Count == 0)
            {
                return;
            }
            else
            {
                dgServicios.DataSource = servicios;
                dgServicios.Columns["Eliminado"].Visible = false;
                dgServicios.Columns["Mantenimientos"].Visible = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tbDescripcion.Text == "" || tbCosto.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (!decimal.TryParse(tbCosto.Text, out decimal costo))
            {
                MessageBox.Show("El costo debe ser un número");
                return;
            }
            Servicios servicio = new Servicios()
            { 
                Descripcion = tbDescripcion.Text,
                Costo = costo,
                Eliminado = false
            };
            nServicios.Registrar(servicio);
            MostrarServicios(nServicios.ListarTodo());
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgServicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un servicio");
                return;
            }
            if (tbDescripcion.Text == "" || tbCosto.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (!decimal.TryParse(tbCosto.Text, out decimal costo))
            {
                MessageBox.Show("El costo debe ser un número");
                return;
            }
            int idServicios = int.Parse(dgServicios.SelectedRows[0].Cells[0].Value.ToString());
            Servicios servicio = new Servicios()
            {
                ID_Servicio = idServicios,
                Descripcion = tbDescripcion.Text,
                Costo = costo,
                Eliminado = false
            };
            nServicios.Modificar(servicio);
            MostrarServicios(nServicios.ListarTodo());
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgServicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un servicio");
                return;
            }
            int idServicios = int.Parse(dgServicios.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult dialog = MessageBox.Show("Deseas eliminar el servicio con id: " + idServicios, "", MessageBoxButtons.YesNo);
            if (dialog.Equals(DialogResult.Yes))
            {
                nServicios.Eliminar(idServicios);
                MostrarServicios(nServicios.ListarTodo());
            }
        }
        private void LimpiarCampos()
        {
            tbDescripcion.Text = "";
            tbCosto.Text = "";
        }
    }
}
