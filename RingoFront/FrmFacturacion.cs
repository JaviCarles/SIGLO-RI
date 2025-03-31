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
    public partial class FrmFacturacion : Form
    {
        List<string>? credenciales = new();
        public EnumModoForm modo = EnumModoForm.Alta;
        public List<TarjetasEntidades>? _tarjetasEntidades = new();
        public List<DetallesVentas>? _detallesVentas = new();
        TarjetasEntidades? _tarjetaEntidad = new();
        MediosPagos? medioDePago = new();
        VentaConsulta? VentaConsulta = null;
        List<Contactos>? _contactos = new();
        List<Domicilios>? _domicilios = new();
        Clientes? cliente = new();
        Facturas? factura = new();
        decimal? total = null;
        decimal pago = 0;
        private FondosCajas? caja = null;
        public bool _envio = false;
        private string _domicilioEnvio = string.Empty;
        private string _telefonoEnvio = string.Empty;

        public FrmFacturacion()
        {
            InitializeComponent();
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            
            cargarTipoFacturas();
            cargarTarjetasEntidades();
            activarCombosTarjetas(false);

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
                declararFondoCaja();
            }
        }

        public void declararFondoCaja()
        {
            dialogFondoCaja cargaDeFondo = new dialogFondoCaja();
            cargaDeFondo.primeroDelDia = true;
            cargaDeFondo.ShowDialog();
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


        /*
         *Metodos de carga de selectores 
         *Se traen los selectores y se ponen las interacciones entre ellos
         */
        public void cargarTipoFacturas()
        {
            tipoFacturaBindingSource.Clear();
            List<TiposFacturas> tiposFacturas = VentasNegocio.getTiposFacturas();
            tipoFacturaBindingSource.DataSource = tiposFacturas;
        }

        public void cargarTarjetasEntidades()
        {
            _tarjetasEntidades = VentasNegocio.getTarjetasEntidades();
            cargarComboMedioPago();
            cargarComboTarjetas();
        }

        public void activarCombosTarjetas(bool activo)
        {
            comboBoxEntidadBancaria.Enabled = activo;
            comboBoxTarjetas.Enabled = activo;
        }

        public void cargarComboMedioPago()
        {
            List<MediosPagos> list = new List<MediosPagos>();
            list = VentasNegocio.getMediosPago();
            mediosPagosBindingSource.DataSource = list;
            comboBoxMedioPago.SelectedIndex = 0;
            medioDePago = mediosPagosBindingSource.Current as MediosPagos;
        }

        public void cargarComboTarjetas()
        {
            tarjetasBindingSource.Clear();
            if (_tarjetasEntidades == null || _tarjetasEntidades.Count == 0)
            {
                return;
            }
            List<Tarjetas> tarjetasUnicas = _tarjetasEntidades.GroupBy(te => te.IdTarjeta).Select(group => group.First().Tarjetas).ToList();
            if (tarjetasUnicas.Count == 0)
            {
                return;
            }
            tarjetasBindingSource.DataSource = tarjetasUnicas.OrderBy(t => t.Tarjeta);
            comboBoxTarjetas.SelectedIndex = 0;
            cargarComboEntidadFinanciera();
        }

        public void cargarComboEntidadFinanciera()
        {
            entidadesTarjetasBindingSource.Clear();
            if (_tarjetasEntidades == null || _tarjetasEntidades.Count == 0)
            {
                return;
            }
            if (tarjetasBindingSource.Count == 0)
            {
                return;
            }
            Tarjetas t = (Tarjetas)comboBoxTarjetas.SelectedItem;
            List<EntidadesTarjetas>? list = _tarjetasEntidades.Where(TE => TE.IdTarjeta == t.IdTarjeta).Select(TE => TE.EntidadesTarjetas).ToList();
            if (list.Count == 0)
            {
                return;
            }
            entidadesTarjetasBindingSource.DataSource = list.OrderBy(e => e.EntidadFinanciera);
            comboBoxEntidadBancaria.SelectedIndex = 0;
        }

        public void cargarTelefonos()
        {
            comboBoxTelefonos.Items.Clear();
            List<string>? contactosAntes = VentasNegocio.getTelefonosCliente(cliente);
            List<string> contactos = new List<string>();
            if (!_envio || String.IsNullOrWhiteSpace(_telefonoEnvio))
            {
                comboBoxTelefonos.DataSource = contactosAntes ?? new();
                return;
            }
            int indice = 0;
            if (contactosAntes != null)
            {
                indice = contactosAntes.IndexOf(_telefonoEnvio);
                if (indice == -1)
                {
                    contactos.Add(_telefonoEnvio);
                    contactos.AddRange(contactosAntes);
                    indice = 0;
                }
            }

            comboBoxTelefonos.DataSource = contactos;
            //comboBoxTelefonos.SelectedIndex = indice;
            comboBoxTelefonos.Enabled = false;
        }

        public void cargarDomicilios()
        {
            comboBoxDomicilios.Items.Clear();
            List<string>? domiciliosAntes = VentasNegocio.getDomiciliosCliente(cliente);
            List<string> domicilios = new List<string>();
            if (!_envio || String.IsNullOrWhiteSpace(_domicilioEnvio))
            {
                comboBoxDomicilios.DataSource = domiciliosAntes ?? new();
                return;
            }
            int indice = 0;
            if (domiciliosAntes != null)
            {
                indice = domiciliosAntes.IndexOf(_domicilioEnvio);
                if (indice == -1)
                {
                    domicilios.Add(_domicilioEnvio);
                    domicilios.AddRange(domiciliosAntes);
                    indice = 0;
                }
            }

            comboBoxDomicilios.DataSource = domicilios;
          //  comboBoxDomicilios.SelectedIndex = indice;
            comboBoxDomicilios.Enabled = false;
        }

        // Método para verificar si hay envío y extraer la información
        private void VerificarYExtraerEnvio()
        {
            _envio = false;
            _domicilioEnvio = string.Empty;
            _telefonoEnvio = string.Empty;
            if (VentaConsulta == null)
            {
                return;
            }

            if (VentaConsulta.Venta == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(VentaConsulta.Venta.ObservacionesVenta) && VentaConsulta.Venta.ObservacionesVenta.Contains("Envío"))
            {
                _envio = true;

                // Extraer domicilio y teléfono
                int start = VentaConsulta.Venta.ObservacionesVenta.IndexOf(":") + 2;
                int middle = VentaConsulta.Venta.ObservacionesVenta.IndexOf("/");
                int end = VentaConsulta.Venta.ObservacionesVenta.Length;

                if (start != -1 && middle != -1 && end != -1)
                {
                    _domicilioEnvio = VentaConsulta.Venta.ObservacionesVenta.Substring(start, middle - start).Trim();
                    _telefonoEnvio = VentaConsulta.Venta.ObservacionesVenta.Substring(middle + 1, end - middle - 1).Trim();
                }
            }

        }


        public void cargarGrillaDetalles()
        {
            if (_detallesVentas == null)
            {
                return;
            }
            detallesBindingSource.Clear();
            detallesBindingSource.DataSource = _detallesVentas;
            total = _detallesVentas.Sum(d => d.SubTotal);
            txtTotal.Text = total != null ? "$" + total.ToString() : "";

        }

        /*
         * Métodos de cambio de estado de controles
         * como los indices de los selectores o letras de textbox
         */
        private void comboBoxMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediosPagos pago = (MediosPagos)comboBoxMedioPago.SelectedItem;
            bool conTarjeta = false;
            if (pago != null)
            {
                conTarjeta = pago.FormaPago.Contains("Tarjeta");
            }
            activarCombosTarjetas(conTarjeta);
            cargarComboTarjetas();
        }

        private void comboBoxTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboEntidadFinanciera();
        }

        private void calcularVuelto()
        {
            if (total == null)
            {
                return;
            }
            decimal vuelto = pago - (decimal)total;
            if (comboBoxMedioPago.Text == "Efectivo")
            {
                txtVuelto.Text = vuelto.ToString();
            }
            else
            {
                txtVuelto.Text = "";
            }
        }

        /*
         * Métodos de vuelta desde otros formularios
         */
        public void traerDesdeConsulta(VentaConsulta v)
        {
            VentaConsulta = v;
            _detallesVentas = v.DetallesVenta;
            cargaDeCliente();
            cargarGrillaDetalles();
            txtNroVenta.Text = v.NumeroVenta.ToString();
            string mensaje = VentasNegocio.CambiarEstadoVenta(VentaConsulta.Venta, "En Proceso De Cobro");
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargaDeCliente()
        {
            if (VentaConsulta == null || VentaConsulta.Cliente == null)
            {
                MessageBox.Show("Error al traer la venta o el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cliente = VentaConsulta.Cliente;

            if (cliente.Personas == null)
            {
                MessageBox.Show("Error al asignar una persona a la venta, Verifique el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtDNI.Text = cliente.DNI;
            txtNombreApellido.Text = cliente.NombreCompleto;
            VerificarYExtraerEnvio();
            cargarTelefonos();
            cargarDomicilios();
        }

        public void traerFondoCajas(FondosCajas? declarado)
        {
            caja = declarado;
        }

        /*
         * Métodos de recopilamiento de campos
         */
        private bool recolectarCampos(ref string mensaje)
        {
            factura = new();
            string domicilio = comboBoxDomicilios.Text;
            string telefono = comboBoxTelefonos.Text;
            pago = numMonto.Value;
            
            if (VentaConsulta == null)
            {
                mensaje = "No hay venta cargada en la facturación";
                return false;
            }
            if (VentaConsulta.Cliente == null)
            {
                mensaje = "No hay clientes registrados en la venta";
                return false;
            }
            cliente = VentaConsulta.Cliente;
            if (VentaConsulta.Venta == null)
            {
                mensaje = "No hay ventas registradas";
                return false;
            }

            string observacionEnvio = "";
            string mensajeEnvío = "";
            if (_envio)
            {
                observacionEnvio = $"Envío: {comboBoxDomicilios.Text.Trim()} / {comboBoxTelefonos.Text.Trim()}";
                if (String.IsNullOrWhiteSpace(comboBoxDomicilios.Text.Trim()))
                {
                    mensajeEnvío = "\nFalta ingresar la dirección de envío";
                }
                if (String.IsNullOrWhiteSpace(comboBoxTelefonos.Text.Trim()))
                {
                    mensajeEnvío += "\nFalta ingresar un teléfono de contacto";
                }
            }

            if (!String.IsNullOrWhiteSpace(mensajeEnvío))
            {
                mensaje = "Seleccionó envío a domicilio pero no ingresó la siguiente información" + mensajeEnvío;
                return false;
            }
            VentaConsulta.Venta.ObservacionesVenta = observacionEnvio;

            if (VentaConsulta.DetallesVenta == null)
            {
                mensaje = "No hay productos registrados";
                return false;
            }

            factura.IdTipoFactura = (int)comboBoxTipoFac.SelectedValue;

            medioDePago = (MediosPagos)mediosPagosBindingSource.Current;
            if (medioDePago == null)
            {
                mensaje = "No se ha seleccionado un medio de pago";
                return false;
            }
            factura.IdMedioPago = (int)comboBoxMedioPago.SelectedValue;
            factura.NumeroFactura = comboBoxTipoFac.Text + "001-" + txtNroVenta.Text;
            if (comboBoxMedioPago.Text != "Efectivo")
            {
                factura.cuponTarjeta = txtCupon.Text.Trim();
            }

            pago = numMonto.Value;
            decimal totalMonto = (decimal)total;
            if (totalMonto == 0)
            {
                mensaje = "Problemas con el monto a cobrar";
                return false;
            }
            total = totalMonto;
            if (total > pago)
            {
                mensaje = "Falta cubrir la totalidad del monto a pagar";
                return false;
            }
            factura.Total = totalMonto;

            int actual = (int)comboBoxTarjetas.SelectedValue;
            int banco = (int)comboBoxEntidadBancaria.SelectedValue;
            _tarjetaEntidad = _tarjetasEntidades.Where(t => t.IdTarjeta == actual && t.IdEntidadTarjeta == banco).FirstOrDefault();

            if (_tarjetaEntidad == null)
            {
                MessageBox.Show("Error al recuperar la tarjeta o entidad bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            factura.IdTarjetaEntidad = _tarjetaEntidad.IdTarjetaEntidad;
            VentaConsulta.Venta.Facturas = factura;
            return true;

        }

        /*
         * Métodoos de botones
         */

        //Validador numerico
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (padre == null)
                return;
            FrmAdminVentas frmAdminVentas = new FrmAdminVentas();
            frmAdminVentas.ventasDesdeFacturacion(txtNroVenta.Text.Trim());
            frmAdminVentas.MdiParent = padre;
            frmAdminVentas.Dock = DockStyle.Fill;
            frmAdminVentas.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (VentaConsulta != null)
            {
                string estado = string.Empty;
                DialogResult anular = MessageBox.Show("¿Desea anular la venta? (Si elige NO seguirá en curso)", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (anular == DialogResult.Yes)
                {
                    estado = "Anulada";
                }
                else if (anular == DialogResult.No)
                {
                    estado = "Finalizada";
                }
                else
                {
                    return;
                }
                string mensaje = VentasNegocio.CambiarEstadoVenta(VentaConsulta.Venta, estado);
                if (!String.IsNullOrWhiteSpace(mensaje))
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (estado == "Anulada")
                {
                    if (!VentasNegocio.volverPrendasAStock(_detallesVentas, VentaConsulta.NumeroVenta.ToString(), ref mensaje))
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.Close();
        }

        private void numMonto_ValueChanged(object sender, EventArgs e)
        {
            pago = numMonto.Value;
            medioDePago = (MediosPagos)mediosPagosBindingSource.Current;
            calcularVuelto();
        }

        private void btbGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (!recolectarCampos(ref mensaje))
            {
                MessageBox.Show("Error: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_envio)
            {
                if (String.IsNullOrWhiteSpace(_telefonoEnvio) && String.IsNullOrWhiteSpace(_domicilioEnvio))
                {
                    MessageBox.Show("Error: La venta es con envío a domicilio pero faltan datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            bool exito = VentasNegocio.RegistrarFacturaCompleta(VentaConsulta.Venta, _detallesVentas, _envio, _telefonoEnvio, _domicilioEnvio, ref mensaje);
            if (!exito)
            {
                MessageBox.Show("Error: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mensaje = "El registro fue exitoso, se generará la factura";
            caja = VentasNegocio.FondoCajaCreadoHoy();
            if (caja == null)
            {
                declararFondoCaja();
            }
            bool dinero = true;
            if (comboBoxMedioPago.Text == "Efectivo")
            {
                caja.MontoFondo += (decimal)total;
                dinero = VentasNegocio.setMontoFondoCajas(caja);
            }
            if (!dinero)
            {
                MessageBox.Show("Error: Problemas al registrar movimiento de cajas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            FacturaC imprimir = new FacturaC();
            imprimir.GenerarFacturaC(cliente.Personas, comboBoxDomicilios.Text, _detallesVentas, factura.Total, "Factura_" + factura.NumeroFactura, _envio);
            this.Close();
        }
    }
}
