using RingoEntidades;
using RingoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RingoFront
{
    public partial class dialogFondoCaja : Form
    {
        private FondosCajas caja = new FondosCajas();
        private decimal fondo = 0;
        public bool primeroDelDia = false;
        private bool resta = false;

        public dialogFondoCaja()
        {
            InitializeComponent();
        }

        private void dialogFondoCaja_Load(object sender, EventArgs e)
        {
            if (primeroDelDia)
            {
                primerFondo();
            }
            DiseñoUI.diseñoFront(this);
        }

        private void primerFondo()
        {
            caja = new();
            txtFondo.Text = "0";
            comboBoxOperacion.Text = "Ingreso Efectivo";
            comboBoxOperacion.Enabled = false;
            btnCancelar.Enabled = false;
        }


        /*
         * Métodos de controles y botones
         */
        private void numMonto_ValueChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            string t = txtFondo.Text;
            if (!decimal.TryParse(t, out total))
            {
                txtFondo.Text = "0";
            }
            resta = comboBoxOperacion.Text.Contains("Retiro");
            if (resta)
            {
                total -= numMonto.Value;
            }
            else
            {
                total += numMonto.Value;
            }

            txtFondo.Text = total.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxOperacion_TextChanged(object sender, EventArgs e)
        {
            resta = comboBoxOperacion.Text.Contains("Retiro");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            decimal montoTotal = 0;
            string total = txtFondo.Text;
            if (!decimal.TryParse(total, out montoTotal))
            {
                MessageBox.Show("Problemas al convertir el monto a número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (montoTotal < 0)
            {
                MessageBox.Show($"Tiene un sobrante de ${Math.Abs(montoTotal)}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            string mensaje = "";
            if (primeroDelDia)
            {
                caja = VentasNegocio.registrarFondoCajas(montoTotal, ref mensaje);
            }
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                MessageBox.Show("Problemas al registrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (padre == null)
            {
                this.Close();
            }

            FrmFacturacion frmFacturacion = Application.OpenForms.OfType<FrmFacturacion>().FirstOrDefault();
            if (frmFacturacion == null)
            {
                frmFacturacion = new FrmFacturacion();
            }
            frmFacturacion.traerFondoCajas(caja);
            frmFacturacion.Show();
            this.Close();
        }
    }
}
