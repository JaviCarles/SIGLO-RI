using RingoEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RingoNegocio;



namespace RingoFront
{
    public partial class FrmAdminPrendas : Form
    {
        public EnumModoForm modo = EnumModoForm.Consulta;
        List<Prendas>? _prendas = new List<Prendas>();
        Prendas? _prenda = new Prendas();
        List<string>? credenciales = new();
        List<DetallesPrendas>? _detallesPrendas = new List<DetallesPrendas>();
        List<DetallesPrendas>? _detallesPrendas1 = new List<DetallesPrendas>();
        List<EstadosPrendas>? _estadosPrendas = new();
        DetallesPrendas? _detallePrenda = new DetallesPrendas();
        EstadosPrendas? _estadoPrenda = null;

        bool eventoInvocado = false;

        public FrmAdminPrendas()
        {
            InitializeComponent();
        }

        private void buscarPrenda(object sender, EventArgs e)
        {
            bindingSourcePrendas.Clear();
            string prenda = txtBuscar.Text;
            string limpieza = string.Empty;
            if (prenda == "limpiar stock")
            {
                limpieza = PrendasNegocio.limpiarStock();
            }
            _prendas = PrendasNegocio.getPrenda(prenda, checkStock.Checked);
            
            if (_prendas != null && _prendas.Count > 0)
            {
                _prenda = _prendas[0];
            } else
            {
                _prendas = new();
            }

            bindingSourcePrendas.DataSource = _prendas;

            if (!String.IsNullOrWhiteSpace(limpieza))
            {

                MessageBox.Show(limpieza, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

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
            if (credenciales.Contains("Pren120"))
                return true;
            if (credenciales.Contains("Admin024"))
                return true;
            if (credenciales.Contains("Geren240"))
                return true;
            if (credenciales.Contains("Pren096"))
                return true;
            if (credenciales.Contains("Merca216"))
                return true;
            return false;
        }

        private void dataGridViewPrenda_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridViewPrenda.CurrentRow;
            if (filaSeleccionada != null)
            {
                //int idPrendaSeleccionada = Convert.ToInt32(filaSeleccionada.Cells["IdPrenda"].Value);
                _prenda = new();
                _prenda = bindingSourcePrendas.Current as Prendas;
                //_prenda.IdPrenda = idPrendaSeleccionada;
                _estadosPrendas = new();
                _estadosPrendas = PrendasNegocio.GetEstadosPrendas(_prenda, checkStock.Checked);
                
                bindingSourceEstados.Clear();
                bindingSourceEstados.DataSource = _estadosPrendas;
            } else
            {
                _prenda = null;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAdminPrendas_Load(object sender, EventArgs e)
        {
            btnVenta.Visible = modo == EnumModoForm.Venta;
            btnEditar.Visible = modo == EnumModoForm.Consulta;

            DiseñoUI.diseñoFront(this);
            //labelAdminPrendas.Font = new Font(labelAdminPrendas.Font.FontFamily, 18f, FontStyle.Bold);
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            _estadoPrenda = new();
            _detallePrenda = new();
            string mensaje = "";
            
            if (_prenda == null)
            {
                MessageBox.Show("No se seleccionó una prenda, no se puede continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_estadosPrendas == null || _estadosPrendas.Count == 0)
            {
                MessageBox.Show("La prenda no tiene estados registrados, no se puede seleccionar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow filaSeleccionada = dataGridViewDetallesPrenda.CurrentRow;
            if (filaSeleccionada != null)
            {
                _estadoPrenda = bindingSourceEstados.Current as EstadosPrendas;
            }
            if (_estadoPrenda == null)
            {
                mensaje = "Elija una prenda detallada por favor";
                return;
            }
            if (_estadoPrenda.Prendas == null)
                mensaje += "\nNo se pudo recuperar la prenda";
            else
                _prenda = _estadoPrenda.Prendas;

            if (_estadoPrenda.DetallesPrendas == null)
                mensaje += "\nNo se pudo recuperar el detalle de la prenda";

            
            _detallePrenda = _estadoPrenda.DetallesPrendas;

            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                MessageBox.Show("No se puede continuar por los siguientes errores: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult res = MessageBox.Show("Se agregará " + _prenda.DescripcionPrenda, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            frmRegistrarVentas frmVentas = Application.OpenForms.OfType<frmRegistrarVentas>().FirstOrDefault();
            if (frmVentas == null)
                return;
            List<EstadosPrendas>? estadosPrendas = frmVentas._estadosPrendas;
            EstadosPrendas? estados = null;
            if (estadosPrendas.Count > 0)
            {
                estados = estadosPrendas.Where(e => e.IdEstadosPrendas == _estadoPrenda.IdEstadosPrendas).FirstOrDefault();
            }
            if (estados != null)
            {
                MessageBox.Show("La prenda que intenta agregar ya fue agregada en la venta. Seleccione una prenda diferente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmVentas._estadoPrenda = _estadoPrenda;
            frmVentas.CargarPrendas(sender, e);
            this.Close();

        }

        private void dataGridViewDetallesPrenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que se haya hecho clic en una fila válida
            {
                eventoInvocado = true;
                _estadoPrenda = bindingSourceEstados.Current as EstadosPrendas;
            } else
            {
                eventoInvocado = false;
                _estadoPrenda = null;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_prenda == null)
            {
                MessageBox.Show("No se ha seleccionado una prenda a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult res = MessageBox.Show($"¿Desea modificar {_prenda.DescripcionPrenda}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.No)
            {
                return;
            }

            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (padre == null)
            {
                padre = new FrmPrincipal();
            }
            FrmRegistrarPrenda abierto = Application.OpenForms.OfType<FrmRegistrarPrenda>().FirstOrDefault();
            if (abierto != null)
            {
                abierto.Close();
            }
            FrmRegistrarPrenda edit = new FrmRegistrarPrenda();
            edit._prenda = _prenda;

            if (_estadoPrenda != null)
            {
                edit._estadoSeleccionado = _estadoPrenda;
            }

            checkStock.Checked = true;
            List<EstadosPrendas>? estadosPrendas = PrendasNegocio.GetEstadosPrendas(_prenda, true);
            if (estadosPrendas != null)
            {
                _estadosPrendas = estadosPrendas.Where(e => e.EstadoActual != null && e.EstadoActual != "Vendida" && e.EstadoActual != "Reservada").ToList();
            } else
            {
                _estadosPrendas = new List<EstadosPrendas>();
            }
            
            edit._estadosNoModificados = _estadosPrendas;
            edit.modoPrenda = EnumModoForm.Modificacion;
            edit.MdiParent = padre;
            edit.Dock = DockStyle.Fill;
            edit.Show();
            this.Close();

        }

        private void btnListadoXls_Click(object sender, EventArgs e)
        {
            if (_prendas == null || _prendas.Count == 0)
            {
                MessageBox.Show("No hay prendas para emitir un listado, por favor haga una búsqueda primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<EstadosPrendas>? listado = PrendasNegocio.GetEstadosPrendas(_prendas, checkStock.Checked);
            if (listado == null || listado.Count == 0)
            {
                MessageBox.Show("No hay prendas para emitir un listado, por favor haga una búsqueda primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string filtro = txtBuscar.Text.Trim();
            ListadosExcel.ExportEstadosPrendasToExcel(listado, filtro);
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (_prendas == null || _prendas.Count == 0)
            {
                MessageBox.Show("No hay prendas para emitir un listado, por favor haga una búsqueda primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<EstadosPrendas>? listado = PrendasNegocio.GetEstadosPrendas(_prendas, checkStock.Checked);
            if (listado == null || listado.Count == 0)
            {
                MessageBox.Show("No hay prendas para emitir un listado, por favor haga una búsqueda primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string filtro = txtBuscar.Text.Trim();
            ListadosPdf.ExportEstadosPrendasToPdf(listado, filtro);
        }

        private void btnAnomalia_Click(object sender, EventArgs e)
        {
            if (_estadosPrendas == null)
            {
                return;
            }
            if (!eventoInvocado)
            {
                MessageBox.Show("Seleccione una prenda detallada para registrar una anomalia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            
            if(padre == null)
                padre = new FrmPrincipal();
            
            frmAnomalia frm = Application.OpenForms.OfType<frmAnomalia>().FirstOrDefault();
            if (frm != null)
                frm.Close();
            
            frmAnomalia frmAnomalia = new frmAnomalia();
            frmAnomalia._estadoPrenda = _estadoPrenda;
            frmAnomalia.MdiParent = padre;
            frmAnomalia.Dock = DockStyle.Fill;
            frmAnomalia.Show();
        }
    }
}