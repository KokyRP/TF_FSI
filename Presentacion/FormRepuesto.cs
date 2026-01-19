using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormRepuesto : Form
    {
        private NRepuesto nRepuesto = new NRepuesto();
        public FormRepuesto()
        {
            InitializeComponent();
            MostrarRepuestos(nRepuesto.ListarTodo());
        }
        private void MostrarRepuestos(List<Repuestos> repuestos)
        {
            dgRepuestos.DataSource = null;
            if (repuestos.Count == 0)
            {
                return;
            }
            else
            {
                dgRepuestos.DataSource = repuestos;
                dgRepuestos.Columns["Eliminado"].Visible = false;
                dgRepuestos.Columns["Mantenimiento_Repuesto"].Visible = false;
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "" || tbDescripcion.Text == "" || tbPrecio.Text == "" || tbCantInventario.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (!decimal.TryParse(tbPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número");
                return;
            }
            if (!int.TryParse(tbCantInventario.Text, out int cantInventario))
            {
                MessageBox.Show("La cantidad en inventario debe ser un número entero");
                return;
            }

            Repuestos repuesto = new Repuestos()
            {
                Nombre = tbNombre.Text,
                Descripcion = tbDescripcion.Text,
                Precio = precio,
                Cantidad_Inventario = cantInventario,
                Eliminado = false
            };

            nRepuesto.Registrar(repuesto);
            MostrarRepuestos(nRepuesto.ListarTodo());
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgRepuestos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un repuesto");
                return;
            }
            if (tbNombre.Text == "" || tbDescripcion.Text == "" || tbPrecio.Text == "" || tbCantInventario.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (!decimal.TryParse(tbPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número");

            }
            if (!int.TryParse(tbCantInventario.Text, out int cantInventario))
            {
                MessageBox.Show("La cantidad en inventario debe ser un número entero");
                return;
            }
            int idRepuesto = int.Parse(dgRepuestos.SelectedRows[0].Cells[0].Value.ToString());
            Repuestos repuesto = new Repuestos()
            {
                ID_Repuesto = idRepuesto,
                Nombre = tbNombre.Text,
                Descripcion = tbDescripcion.Text,
                Precio = precio,
                Cantidad_Inventario = cantInventario,
                Eliminado = false
            };

            nRepuesto.Modificar(repuesto);
            MostrarRepuestos(nRepuesto.ListarTodo());
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgRepuestos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un repuesto");
                return;
            }
            int idRepuesto = int.Parse(dgRepuestos.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult dialog = MessageBox.Show("Deseas eliminar el repuesto con id: " + idRepuesto, "", MessageBoxButtons.YesNo);
            if (dialog.Equals(DialogResult.Yes))
            {
                nRepuesto.Eliminar(idRepuesto);
                MostrarRepuestos(nRepuesto.ListarTodo());
            }            
        }
        private void LimpiarCampos()
        {
            tbNombre.Text = "";
            tbDescripcion.Text = "";
            tbPrecio.Text = "";
            tbCantInventario.Text = "";
        }
    }
}
