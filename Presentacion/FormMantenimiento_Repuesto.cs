using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormMantenimiento_Repuesto : Form
    {
        private int idMantenimiento;
        private NMantenimientoxRepuesto nMantenimientoxRepuesto = new NMantenimientoxRepuesto();
        private NRepuesto nRepuesto = new NRepuesto();
        public FormMantenimiento_Repuesto(int idMantenimiento)
        {
            InitializeComponent();
            this.idMantenimiento = idMantenimiento;
            CargarRepuestos(nRepuesto.ListarTodo());
            MostrarMantenimientoxRepuesto(nMantenimientoxRepuesto.ListarTodo(idMantenimiento));
        }
        private void CargarRepuestos(List<Repuestos> repuestos)
        {
            cbRepuestos.DataSource = null;
            if (repuestos.Count == 0)
            {
                return;
            }
            else
            {
                cbRepuestos.DataSource = repuestos;
                cbRepuestos.DisplayMember = "Nombre";
                cbRepuestos.ValueMember = "ID_Repuesto";
            }
        }
        private void MostrarMantenimientoxRepuesto(List<Mantenimiento_Repuesto> mantenimiento_repuestos)
        {
            dgMantenimiento_Repuestos.DataSource = null;
            if (mantenimiento_repuestos.Count == 0)
            {
                return;
            }
            else
            {
                dgMantenimiento_Repuestos.DataSource = mantenimiento_repuestos;
                dgMantenimiento_Repuestos.Columns["Mantenimientos"].Visible = false;
                dgMantenimiento_Repuestos.Columns["Repuestos"].Visible = false;
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cbRepuestos.Text == "" || tbCantidadUsada.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            if (!int.TryParse(tbCantidadUsada.Text, out int cantidad_usada))
            {
                MessageBox.Show("La cantidad usada debe ser un número entero");
                return;
            }

            int idRepuestos = int.Parse(cbRepuestos.SelectedValue.ToString());

            Mantenimiento_Repuesto mantenimiento_repuesto = new Mantenimiento_Repuesto()
            {
                ID_Mantenimiento = idMantenimiento,
                ID_Repuesto = idRepuestos,
                Cantidad_Usada = cantidad_usada
            };

            try
            {
                nMantenimientoxRepuesto.Registrar(mantenimiento_repuesto);
                MessageBox.Show("Registrado correctamente");
                MostrarMantenimientoxRepuesto(nMantenimientoxRepuesto.ListarTodo(idMantenimiento));
                nRepuesto.QuitarDelInventario(idRepuestos, cantidad_usada);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            if (dgMantenimiento_Repuestos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un mantenimiento");
                return;
            }
            int idRepuestos = int.Parse(dgMantenimiento_Repuestos.SelectedRows[0].Cells["ID_Repuesto"].Value.ToString());
            int cantidad_usada = int.Parse(dgMantenimiento_Repuestos.SelectedRows[0].Cells["Cantidad_Usada"].Value.ToString());
            DialogResult dialog = MessageBox.Show("¿Deseas eliminar la asignación?", "", MessageBoxButtons.YesNo);
            if (dialog.Equals(DialogResult.Yes))
            {
                nRepuesto.DevolverAlInventario(idRepuestos, cantidad_usada);
                nMantenimientoxRepuesto.Eliminar(idMantenimiento);
                MostrarMantenimientoxRepuesto(nMantenimientoxRepuesto.ListarTodo(idMantenimiento));
            }
        }
    }
}
