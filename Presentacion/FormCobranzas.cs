using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormCobranzas : Form
    {
        private DClientes dClientes = new DClientes();
        private NCobranzas nCobranzas = new NCobranzas();
        public FormCobranzas()
        {
            InitializeComponent();
            MostrarClientesYCobranzas();
        }
        private void MostrarClientesYCobranzas()
        {
            dgClienteCobranzas.DataSource = nCobranzas.ObtenerIngresosClientes();
        }

        private void btnCobranzasPorDni_Click(object sender, EventArgs e)
        {
            if (tbDNICliente.Text == "")
            {
                dgClienteCobranzas.DataSource = nCobranzas.ObtenerIngresosClientes();
            }
            else
            {
                int DNI = Convert.ToInt32(tbDNICliente.Text);
                dgClienteCobranzas.DataSource = nCobranzas.ObtenerIngresosPorCliente(DNI);
            }
        }
    }
}
