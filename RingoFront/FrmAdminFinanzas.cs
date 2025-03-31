using Microsoft.Identity.Client;
using RingoDatos;
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
    public partial class FrmAdminFinanzas : Form
    {
        DateTime fecha;
        List<DetallesLibrosDiarios> list = new List<DetallesLibrosDiarios>();
        public FrmAdminFinanzas()
        {
            InitializeComponent();
        }

        private void FrmAdminFinanzas_Load(object sender, EventArgs e)
        {
            fecha = dateTimeFecha.Value;
            getMovimientosFinancieros(fecha);
            ingresoEgresoMargenTotal();

            DiseñoUI.diseñoFront(this);
        }

        public void getMovimientosFinancieros(DateTime fecha)
        {

            try
            {
                list = VentasNegocio.getMovimientosFinancieros(fecha);
                detallesLibrosDiariosBindingSource.DataSource = list;
                dataGridMovimientos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la capa de diseño (front) en el método getMovimientosFinancieros(DateTime fecha)");
            }
        }

        private void dateTimeFecha_ValueChanged(object sender, EventArgs e)
        {
            fecha = dateTimeFecha.Value;
            getMovimientosFinancieros(fecha);
            ingresoEgresoMargenTotal();
        }

        public void ingresoEgresoMargenTotal()
        {
            decimal egresoTotal = 0, ingresoTotal = 0, margenTotal = 0;

            foreach (var item in list)
            {
                egresoTotal += item.Egreso;
                ingresoTotal += item.Ingreso;
                margenTotal += item.Margen;
            }

            lblIngreso.Text = "Ingreso del día: " + ingresoTotal.ToString();
            lblEgreso.Text = "Egreso del día: " + egresoTotal.ToString();
            lblMargen.Text = "Margen del día: " + margenTotal.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
