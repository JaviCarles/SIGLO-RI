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
    public partial class frmAnomalia : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta;
        public EstadosPrendas? _estadoPrenda = null;
        private List<Estados>? _estados = null;
        private int maximo = 0;
        private EstadosPrendas? _estadoNuevo = null;
        private Estados? _estadoSeleccionado = null;
        private bool seleccionado = false;

        public frmAnomalia()
        {
            InitializeComponent();
        }

        private void frmAnomalia_Load(object sender, EventArgs e)
        {
            if (modo == EnumModoForm.Alta)
            {
                cargaDatos();
            }
            DiseñoUI.diseñoFront(this);
        }

        private void cargaDatos()
        {
            if (_estadoPrenda == null)
            {
                MessageBox.Show("Error al cargar la prenda detallada para la carga de anomalia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _estadoPrenda.EstadosHistorias = PrendasNegocio.getEstadoHistoria(_estadoPrenda.IdEstadoHistoria);

            if (_estadoPrenda.EstadosHistorias == null)
            {
                MessageBox.Show("Error al cargar el estado e la prenda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            cargarEstados();
            cmbEstado.SelectedValue = _estadoPrenda.EstadosHistorias.IdEstadoActual;
            txtCodigo.Text = _estadoPrenda.CodigoDetalle ?? "";
            maximo = _estadoPrenda.CantidadEstado;
            numCantidad.Value = maximo;
            string descripcion = _estadoPrenda.DescripcionPrenda ?? "";
            descripcion += _estadoPrenda.NroTalle ?? "";
            descripcion += _estadoPrenda.Color ?? "";
            txtDescripcion.Text = descripcion;
        }

        private void cargarEstados()
        {
            _estados = PrendasNegocio.GetEstadosIndolePrenda();
            if (_estados == null)
            {
                MessageBox.Show("Error al cargar estados de prendas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _estados.RemoveAll(e => e.Estado == "Reservada" || e.Estado == "Vendida" || e.Estado == "Pendiente");
            bindingEstados.Clear();
            bindingEstados.DataSource = _estados;

        }

        private void validarCantidad()
        {
            if (maximo == 0)
            {
                MessageBox.Show("Error: No hay stock para cargar anomalías", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (numCantidad.Value > maximo)
            {
                MessageBox.Show("No se pueden cargar más prendas que el stock actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                numCantidad.Value = maximo;
                return;
            }
            if (numCantidad.Value < 0)
            {
                MessageBox.Show("No se pueden cargar cantidades negativas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                numCantidad.Value = 0;
                return;
            }
        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            validarCantidad();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (!validarPrenda(ref mensaje))
            {
                MessageBox.Show("Error:" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            recolectarInfo();
            if (!PrendasNegocio.registrarAnomalia(_estadoSeleccionado, _estadoPrenda, _estadoNuevo, ref mensaje))
            {
                MessageBox.Show("Error:" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                MessageBox.Show("Registrado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();

        }

        private bool validarPrenda(ref string mensaje)
        {
            if (_estadoPrenda == null)
            {
                mensaje += "\nNo hay prenda para modificar";
            }

            if (String.IsNullOrWhiteSpace(txtFalla.Text))
            {
                mensaje += "\nIngrese una falla u observacion por favor";
            }

            if (numCantidad.Value == 0)
            {
                mensaje += "\nIngrese una cantidad por favor";
            }

            if (!seleccionado)
            {
                mensaje += "\nSeleccione un estado por favor";
            }

            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }
            return true;
        }

        private void recolectarInfo()
        {
            _estadoNuevo = new EstadosPrendas();
            _estadoNuevo.DetallesPrendas = _estadoPrenda.DetallesPrendas;
            _estadoNuevo.Prendas = _estadoPrenda.Prendas;
            _estadoNuevo.EstadosHistorias = _estadoPrenda.EstadosHistorias;
            _estadoNuevo.IdEstadosPrendas = _estadoPrenda.IdEstadosPrendas;
            _estadoNuevo.IdEstadoHistoria = _estadoPrenda.IdEstadoHistoria;
            _estadoNuevo.IdPrenda = _estadoPrenda.IdPrenda;
            _estadoNuevo.IdDetallePrenda = _estadoPrenda.IdDetallePrenda;
            _estadoNuevo.CantidadEstado = (int)numCantidad.Value;
            _estadoNuevo.Observaciones = txtDescripcion.Text.Trim();
            _estadoSeleccionado = (Estados)cmbEstado.SelectedItem;
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_estados != null)
            {
                _estadoSeleccionado = (Estados)cmbEstado.SelectedItem;
            }
            if (_estadoSeleccionado != null)
            {
                seleccionado = true;
            }
        }
    }
}
