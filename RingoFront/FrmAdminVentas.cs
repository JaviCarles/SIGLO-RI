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
    public partial class FrmAdminVentas : Form
    {
        List<string>? credenciales = new();
        public EnumModoForm modo = EnumModoForm.Consulta;
        private List<VentaConsulta>? _listaVentas = new();
        public List<Ventas>? _ventas = new();
        public VentaConsulta? _ventaSeleccionadaGrilla = null;
        public Ventas? _venta = new();
        public List<DetallesVentas>? _detallesVentas = new();
        private List<FacturaC>? _listaFacturas = new();
        public Facturas? factura = new();
        private DateTime _fechaDesde = DateTime.MinValue;
        private DateTime _fechaHasta = DateTime.MaxValue;
        private string textoBuscado = string.Empty;
        private bool cobrado = false;
        private bool noCobrado = false;
        private decimal _total = 0;

        public FrmAdminVentas()
        {
            InitializeComponent();
        }

        private void FrmAdminVentas_Load(object sender, EventArgs e)
        {
            DiseñoUI.diseñoFront(this);
            checkSinCobrar.Checked = true;
           
            _fechaDesde = DateTime.Now.AddDays(-1);
            _fechaHasta = DateTime.Now.AddDays(1);
            dateTimeDesde.Value = _fechaDesde;
            dateTimeHasta.Value = _fechaHasta;
        }

        private void Frm_Shown(object sender, EventArgs e)
        {
            credenciales = LoginUsuario.CredencialesActivas();
            if (!comprobarCredenciales())
            {
                MessageBox.Show("Su usuario no tiene permiso para acceder a esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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

        public void ventasDesdeFacturacion(string nroVenta)
        {
            txtBuscarVenta.Text = nroVenta;
            modo = EnumModoForm.Alta;
            dateTimeDesde.Value = DateTime.Now.AddDays(-1);
            dateTimeHasta.Value = DateTime.Now.AddDays(1);
            checkCobradas.Checked = false;
            checkSinCobrar.Checked = true;
        }

        private void llenarCampos()
        {
            DateTime fechaHoy = DateTime.Today;
            _fechaDesde = dateTimeDesde.Value == fechaHoy ? DateTime.MinValue : dateTimeDesde.Value;
            _fechaHasta = dateTimeHasta.Value == fechaHoy ? DateTime.MaxValue : dateTimeHasta.Value;
            textoBuscado = txtBuscarVenta.Text.Trim();
            cobrado = checkCobradas.Checked;
            noCobrado = checkSinCobrar.Checked;
        }

        private bool buscarVentas(ref string mensaje)
        {
            llenarCampos();
            string msg = "";
            _ventas = VentasNegocio.GetVentasComleto(_fechaDesde, _fechaHasta, textoBuscado, cobrado, noCobrado, checkEnvio.Checked, ref msg);
            if (_ventas == null || _ventas.Count == 0)
            {
                mensaje += msg;
                return false;
            }
            return true;
        }

        private int llenarListaVentas(ref string mensaje)
        {
            if (_ventas == null || _ventas.Count == 0)
            {
                mensaje += "\nNo se pueden traer ventas a la grilla";
                return 0;
            }

            _listaVentas = new();
            foreach (Ventas venta in _ventas)
            {
                _ventaSeleccionadaGrilla = new(venta.Empleados, venta.Clientes, venta, null, venta.Estados);
                _listaVentas.Add(_ventaSeleccionadaGrilla);

            }
            return _listaVentas.Count;
        }

        private void refrescarGrillaVentas(object sender, EventArgs e)
        {
            bindingSourceVentas.Clear();
            bindingSourceVentas.DataSource = _listaVentas;
            dataGridVerVentas.Refresh();
        }

        private bool getDetallesVentas()
        {
            _detallesVentas = new();
            if (_venta == null)
            {
                return false;
            }
            _detallesVentas = VentasNegocio.GetDetallesVentas(_venta);
            if (_detallesVentas == null || _detallesVentas.Count == 0)
            {
                _total = 0;
                txtTotal.Text = string.Empty;
                return false;
            }
            _total = (decimal)_detallesVentas.Sum(d => d.SubTotal);
            txtTotal.Text = _total.ToString();
            return true;
        }

        private void refrescarGrillaDetalles(object sender, EventArgs e)
        {
            bindingSourceDetalles.Clear();
            bindingSourceDetalles.DataSource = _detallesVentas;
            dataGridDetalles.Refresh();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            llenarCampos();
            if (!buscarVentas(ref mensaje))
            {
                MessageBox.Show("Error al buscar ventas" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (llenarListaVentas(ref mensaje) == 0)
            {
                MessageBox.Show("Error al cargar ventas en grilla" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            refrescarGrillaVentas(sender, e);
        }

        private void dataGridVerVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (_ventas == null)
                return;

            DataGridViewRow filaSeleccionada = dataGridVerVentas.CurrentRow;
            if (filaSeleccionada != null)
            {
                int nroVentaSeleccionada = Convert.ToInt32(filaSeleccionada.Cells["nroVenta"].Value);

                _venta = _ventas.FirstOrDefault(v => v.NumeroVenta == nroVentaSeleccionada);
            }

            if (_venta == null)
            {
                return;
            }

            if (!getDetallesVentas())
            {
                return;
            }
            if (_venta.Estados != null)
            {
                btnDespacho.Visible = _venta.Estados.Estado == "Envio Pendiente";
            }

            refrescarGrillaDetalles(sender, e);
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            VentaConsulta? venta = (VentaConsulta)bindingSourceVentas.Current;
            if (venta == null)
            {
                MessageBox.Show("No ha seleccionado ninguna venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (venta.EstadoVenta != "Finalizada" && venta.EstadoVenta != "En Proceso De Cobro")
            {
                MessageBox.Show($"Una venta con el estado {venta.EstadoVenta} no se puede cobrar", "Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            venta.DetallesVenta = _detallesVentas;
            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (padre == null)
                return;
            FrmFacturacion frmFacturacion = Application.OpenForms.OfType<FrmFacturacion>().FirstOrDefault();
            if (frmFacturacion == null)
            {
                frmFacturacion = new FrmFacturacion();
                frmFacturacion.MdiParent = padre;
                frmFacturacion.Dock = DockStyle.Fill;
            }
            frmFacturacion.traerDesdeConsulta(venta);
            frmFacturacion.Show();
            this.Close();
        }

        private void checkEnvio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEnvio.Checked)
            {
                checkCobradas.Checked = false;
                checkSinCobrar.Checked = false;
            }
            else
            {
                checkSinCobrar.Checked = true;
            }
        }

        private void checkSinCobrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSinCobrar.Checked)
            {
                checkCobradas.Checked = false;
                checkEnvio.Checked = false;
            }
        }

        private void checkCobradas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCobradas.Checked)
            {
                checkSinCobrar.Checked = false;
            }
        }

        private void btnDespacho_Click(object sender, EventArgs e)
        {
            if (_venta ==  null)
            {
                MessageBox.Show("Hubo un problema al cargar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult res = MessageBox.Show("¿Confirma la entrega de esta Venta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            string mensaje = "";
            if (!VentasNegocio.entregarVentaConEnvio(_venta, ref mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Se registró con éxito la entrega de la venta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
