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
    public partial class FrmCerrarCaja : Form
    {

        List<string>? credenciales = new();
        private bool declarado = false;
        private FondosCajas? caja = null;
        private bool impreso = false;
        private bool cerrar = false;

        public List<CajasConsulta>? cajasConsultas = null;
        public List<CajasConsulta>? cajasConsultasSeleccionados = null;
        List<MediosPagos>? mediosPagos = null;

        public decimal montoDeclarado = 0;
        public decimal totalCobrado = 0;
        public decimal diferencia = 0;
        public int totalFacturas = 0;

        public FrmCerrarCaja()
        {
            InitializeComponent();
        }

        private void FrmCerrarCaja_Load(object sender, EventArgs e)
        {
            DiseñoUI.diseñoFront(this);
        }

        private void Frm_Shown(object sender, EventArgs e)
        {
            credenciales = LoginUsuario.CredencialesActivas();
            if (!comprobarCredenciales())
            {
                MessageBox.Show("Su usuario no tiene permiso para acceder a esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            caja = VentasNegocio.FondoCajaCreadoHoy();
            if (caja == null)
            {
                MessageBox.Show("No se abrió la caja en el día de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //declararFondoCaja();
                this.Close();
            }
        }

        private void textBoxNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, tecla de control y Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool comprobarCredenciales()
        {
            if (credenciales == null || credenciales.Count == 0)
                return false;
            if (credenciales.Contains("Total384"))
                return true;
            if (credenciales.Contains("Clien072"))
                return true;
            if (credenciales.Contains("Admin024"))
                return true;
            if (credenciales.Contains("Geren240"))
                return true;
            return false;
        }

        public void declararFondoCaja()
        {
            dialogFondoCaja cargaDeFondo = new dialogFondoCaja();
            cargaDeFondo.primeroDelDia = true;
            cargaDeFondo.ShowDialog();
        }

        private void activarControles()
        {
            comboMediosPagos.Enabled = declarado;
            btnDeclarar.Enabled = !declarado;
            btnImprimir.Enabled = cajasConsultas != null;
        }

        private bool calcularDiferencia(ref string mensaje)
        {
            montoDeclarado = 0;
            totalCobrado = 0;
            string declarar = txtDeclarado.Text.Trim();
            totalCobrado = caja.MontoFondo;
            if (!decimal.TryParse(declarar, out montoDeclarado))
            {
                mensaje = "Error al convertir el monto declarado";
                return false;
            }
            if (montoDeclarado < 0 || totalCobrado < 0)
            {
                mensaje = "No se pueden declarar fondos negativos";
                return false;
            }

            diferencia = montoDeclarado - totalCobrado;
            if (diferencia < 0)
            {
                mensaje = $"Tiene un faltante de cajas de ${diferencia}";
            }
            if (diferencia < 0)
            {
                mensaje = $"Tiene un sobrante de cajas de ${diferencia}";
            }

            txtDiferencia.Text = diferencia.ToString();
            txtFondoCajas.Text = totalCobrado.ToString();
            return true;
        }

        private void medioPagoGenerico()
        {
            mediosPagos = new();
            MediosPagos todos = new();
            todos.FormaPago = "Todos";
            todos.IdMedioPago = 0;
            mediosPagos.Add(todos);
        }

        private void mediosPagoUtilizados()
        {
            bindingMediosPagos.Clear();
            medioPagoGenerico();
            if (cajasConsultas == null || cajasConsultas.Count == 0)
            {
                bindingMediosPagos.DataSource = mediosPagos;
                return;
            }

            List<MediosPagos> mediosDesorden = new List<MediosPagos>();
            List<int> lista = new List<int>();
            foreach (CajasConsulta ca in cajasConsultas)
            {
                try
                {
                    if (!lista.Contains((int)ca.idMedioPago))
                    {
                        MediosPagos me = new MediosPagos();
                        me.FormaPago = ca.MedioDePago;
                        me.IdMedioPago = ca.idMedioPago;
                        mediosDesorden.Add(me);
                    }
                    lista.Add((int)ca.idMedioPago);
                }
                catch (Exception) { }
            }

            List<MediosPagos> mediosOrden = mediosDesorden.OrderBy(m => m.FormaPago).ToList();
            mediosPagos.AddRange(mediosOrden);
            bindingMediosPagos.DataSource = mediosPagos;
        }

        private void btnDeclarar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDeclarado.Text))
            {
                MessageBox.Show("Debe ingresar un monto declarado, aunque sea cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult res = MessageBox.Show($"Está declarando un total de  ${txtDeclarado.Text}\n¿Desea confirmar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            string mensaje = "";
            declarado = calcularDiferencia(ref mensaje);
            if (!declarado)
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            declarado = true;
            cajasConsultas = FinanzasNegocio.getMovimientosCaja(DateTime.Now, ref mensaje);
            if (cajasConsultas == null)
            {
                MessageBox.Show("No se encontraron movimientos de cobro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnImprimir.Enabled = true;
                return;
            }
            medioPagoGenerico();
            activarControles();
            mediosPagoUtilizados();
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            if (cerrar)
            {
                return;
            }
            cajasConsultaBindingSource.DataSource = null;
            if (cajasConsultas == null)
            {
                cajasConsultas = new();
            }
            if (comboMediosPagos.Text == "Todos")
            {
                cajasConsultasSeleccionados = cajasConsultas;
            }
            else
            {
                cajasConsultasSeleccionados = cajasConsultas.Where(c => c.idMedioPago == (int)comboMediosPagos.SelectedValue).ToList();
            }

            cajasConsultaBindingSource.DataSource = cajasConsultasSeleccionados;
            dataGridPersonas.Refresh();
            try
            {
                decimal total = cajasConsultasSeleccionados.Sum(c => (decimal)c.TotalFactura);
                txtTotal.Text = "$" + total;
            }
            catch (Exception) { }

        }

        private void comboMediosPagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!declarado)
            {
                MessageBox.Show("Debe declarar correcctamente un monto antes de imprimir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult res = MessageBox.Show($"¿Desea Imprimir el Ciere de Cajas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            CierreDeCajas impresion = new CierreDeCajas();
            impreso = impresion.imprimirCierreCajas(cajasConsultas, totalCobrado, montoDeclarado);
            if (!impreso)
            {
                MessageBox.Show("Error al generar PDF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (!impreso)
            {
                DialogResult res = MessageBox.Show($"No se ha generado el archivo de cierre \n¿Desea Cerrar Igualmente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }
                cerrar = true;
                this.Close();
            } else
            {
                cerrar = true;
                this.Close();
            }
        }
    }
}
