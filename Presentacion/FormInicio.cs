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
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            FormMantenimiento form = new FormMantenimiento();
            form.Show();
        }

        private void btnCobranzas_Click(object sender, EventArgs e)
        {
            FormCobranzas form = new FormCobranzas();
            form.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormReportes form = new FormReportes(); 
            form.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes form = new FormClientes();
            form.Show();
        }

        private void btnMecanicos_Click(object sender, EventArgs e)
        {
            FormMecanicos form = new FormMecanicos();
            form.Show();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            FormServicios form = new FormServicios();
            form.Show();
        }

        private void btnRepuestos_Click(object sender, EventArgs e)
        {
            FormRepuesto form = new FormRepuesto();
            form.Show();
        }
    }
}
