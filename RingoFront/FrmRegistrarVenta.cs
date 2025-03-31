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
    public partial class frmRegistrarVentas : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta;
        List<string>? credenciales = new();
        public List<DetallesVentas>? _detallesVentas = new();
        private Ventas? _venta = new();
        private List<Item>? prendas = new();
        public Clientes? _cliente = null;
        public Personas? _persona = null;
        private bool clienteActivo = false;
        private bool personaValida = false;
        string _dni = "";
        string _apellido = "";
        string _nombres = "";
        private int _IdResponsableVenta = 0;
        public Prendas? _prenda = new();
        public EstadosPrendas? _estadoPrenda = new();
        public List<EstadosPrendas?> _estadosPrendas = new();
        public List<EstadosPrendas>? estadosSeleccionados = new();
        public List<DetallesPrendas>? _detallesPrendas = new();
        string _descripcionPrenda = "";
        public decimal _subTotal = 0;
        public decimal _total = 0;
        public int _cantidad = 0;
        private bool _envio = false;
        private string contactoEnvio = "";
        private string domicilioEnvio = "";

        public frmRegistrarVentas()
        {
            InitializeComponent();
        }

        private void frmRegistrarVentas_Load(object sender, EventArgs e)
        {
            _IdResponsableVenta = LoginUsuario.IdUsuarioActivo();
            DiseñoUI.diseñoFront(this);
            generarNroVenta();
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

        public void CargarPrendas(object sender, EventArgs e)
        {
            if (_estadoPrenda == null)
            {
                return;
            }

            if (prendas == null)
            {
                prendas = new();
            }

            if (_estadosPrendas == null)
            {
                _estadosPrendas = new();
            }

            _estadosPrendas.Add(_estadoPrenda);
            string estado = _estadoPrenda.EstadoActual == "Apta" ? "" : _estadoPrenda.EstadoActual;
            string prenda = $"{_estadoPrenda.DescripcionPrenda} {_estadoPrenda.Color} talle: {_estadoPrenda.DescripcionTalle} {estado}";
            Item p = new Item(prenda, (int)_estadoPrenda.IdEstadosPrendas);
            prendas.Add(p);
            bindingSourceDetallesPrendas.DataSource = null;
            bindingSourceDetallesPrendas.DataSource = prendas;
            cmbPrendas.SelectedItem = p;
            txtPrecioPrenda.Text = _estadoPrenda.PrecioVenta.ToString();

        }

        private bool comprobarCredenciales()
        {
            if (credenciales == null || credenciales.Count == 0)
            {
                return false;
            }

            if (credenciales.Contains("Total384"))
            {
                return true;
            }

            if (credenciales.Contains("Admin024"))
            {
                return true;
            }

            if (credenciales.Contains("Geren240"))
            {
                return true;
            }

            return false;
        }

        private void SumarTotal()
        {
            if (_detallesVentas.Count > 0)
            {
                _total = (decimal)_detallesVentas.Sum(d => d.SubTotal);
            }
            else
            {
                _total = 0;
            }

            txtTotal.Text = _total.ToString();
        }

        //Método para validar el dni bienb escrito antes de buscar al cliente por el mismo
        private bool dniCorrecto(ref string mensaje)
        {
            //Primero se obtienen los datos en los campos
            _dni = txtDniCliente.Text.Trim();

            //Si el dni está vacío, tiene caracteres de más o de menos o no es un número devuelvo falso con su respectivo error
            if (String.IsNullOrWhiteSpace(_dni))
            {
                mensaje += "Ingrese el Dni del cliente";
                return false;
            }
            if (_dni.Length < 7 || _dni.Length > 9)
            {
                mensaje += "No ingresó un Dni válido debe tener entre 7 y 9 dígitos";
                return false;
            }
            int d = 0;
            if (!int.TryParse(_dni, out d))
            {
                mensaje += "El Dni solo admite valores numéricos";
                return false;
            }
            
            //Sigo recolectando los campos
            _apellido = txtApellidoCliente.Text.Trim();
            _nombres = txtNombreCliente.Text.Trim();

            return true;
        }

        //Método para verificar que el dni ingresado pertenezca a una persona válida
        private bool buscarCliente(ref string mensaje)
        {
            //Inicio el comprobador de persona en false
            personaValida = false;
            _persona = null;

            //Valido el dni (porque lo usa para buscar al cliente, tambien recolecta los otros campos)
            if (!dniCorrecto(ref mensaje))
            {
                return false;
            }

            //Creo una persona nueva
            _persona = new();

            //Busco a la persona con el dni en la BD
            _persona = PersonasMetodos.PersonaPorDni(_dni);

            //Si no existe preparo todo para registrarlo
            if (_persona == null)
            {
                //Aviso que no está registrada
                mensaje += "No hay personas registradas con ese Dni, ";

                //Creo los objetos cliente y persona nuevos
                _cliente = new();
                _persona = new();

                //Les cargo los datos que necesito para registrarlos
                _persona.Dni = _dni;
                _persona.Apellidos = _apellido;
                _persona.Nombre = _nombres;

                //Si nombre o apellido, que son obligatorios, estan vacíos, retorno en falso con el error
                if (String.IsNullOrWhiteSpace(_persona.Nombre) || String.IsNullOrWhiteSpace(_persona.Apellidos))
                {
                    mensaje += "por favor complete nombre y apellido para registrar un cliente nuevo";
                    _persona = null;
                    return false;
                } else
                {
                    //Si ninguno está vacío habilito y muestro un mensaje de promesa de registro
                    mensaje += "Se registrará un nuevo cliente";
                    personaValida = true;
                }

                //Pongo la persona en cliente así se registran ambos y devuelvo el exito
                _cliente.Personas = _persona;
                return true;
            }

            //Si se encontró una persona con ese dni, la uso para ver si existe como cliente (puede ser empleado)
            _cliente = new();
            _cliente = PersonasMetodos.BuscarClientes(_persona);

            //Si no es cliente informo la situeción y me preparo para registrarlo
            if (_cliente == null)
            {
                mensaje += "Hay una persona registradas con ese Dni pero no es un cliente, se registrará como uno";
                _cliente = new();
                _cliente.IdPersona = (int)_persona.IdPersona;
                _cliente.Personas = _persona;

                //valido a la persona
                personaValida = true;

                return true;
            }

            //Si también encontró al cliente le cargo el nombre en los textbox y devuelvo true
            txtNombreCliente.Text = _persona.Nombre;
            txtApellidoCliente.Text = _persona.Apellidos;

            //Agrego ese cliente a la venta
            _venta.Clientes = _cliente;
            _venta.IdCliente = (int)_cliente.IdCliente;

            //Valido a la persona
            personaValida = true;
            return true;
        }

        private void AgregarCliente()
        {
            //Primero creo el mensaje de error
            string mensaje = "";

            //Busco a la persona y si no preparo todo para registrarla
            if (!buscarCliente(ref mensaje))
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (_persona.IdPersona == null)
            {
                DialogResult res = MessageBox.Show("¿Confirma registrar al nuevo cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    personaValida = false;
                    clienteActivo = false;
                    return;
                }
                _persona = new();
                _cliente = new();
                _persona.Dni = _dni;
                _persona.Apellidos = _apellido;
                _persona.Nombre = _nombres;
                _cliente.Personas = _persona;
            }
        }

        private void IrABusquedaCliente()
        {
            string mensaje = "";

            if (_cliente != null && _persona?.Dni == txtDniCliente.Text)
            {
                mensaje = "El Cliente con ese Dni existe ¿Desea igualmente abrir el formulario de búsqueda?";
            }
            else
            {
                mensaje = "¿Desea abrir el formulario de búsqueda de clientes?";
            }
            DialogResult res = MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (padre == null)
            {
                MessageBox.Show("Error no se puede acceder al menú principal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmAdminClientes frmAdminClientes = Application.OpenForms.OfType<FrmAdminClientes>().FirstOrDefault();
            if (frmAdminClientes == null)
            {
                frmAdminClientes= new FrmAdminClientes();
            }
            _persona = new();
            _persona.Dni = txtDniCliente.Text.Trim();
            _persona.Nombre = txtNombreCliente.Text.Trim();
            _persona.Apellidos = txtApellidoCliente.Text.Trim();
            frmAdminClientes._persona = _persona;
            frmAdminClientes.modo = EnumModoForm.Venta;
            frmAdminClientes.MdiParent = padre;
            frmAdminClientes.Dock = DockStyle.Fill;
            frmAdminClientes.Show();

        }

        public void VolverDeBuscarClientes(Clientes? cliente)
        {
            if (cliente == null)
            {
                _cliente = null;
                return;
            }
            if (cliente.Personas == null)
            {
                _cliente = null;
                return;
            }

            _cliente = cliente;
            _persona = cliente.Personas;
            _nombres = _persona.Nombre;
            _apellido = _persona.Apellidos;
            _dni = _persona.Dni;
            personaValida = true;
            desactivarCamposCliente();

            txtDniCliente.Text = _dni;
            txtApellidoCliente.Text = _apellido;
            txtNombreCliente.Text = _nombres;
            cargarComboContactos();
            cargarComboDomicilios();
        }

        private void mostrarEnvío(bool envio)
        {
            _envio = envio;
            lblDomicilio.Visible = _envio;
            lblTelefono.Visible = _envio;
            comboDomicilio.Visible = _envio;
            comboTelefono.Visible = _envio;
        }

        private void desactivarCamposCliente()
        {
            personaValida = _cliente != null && _persona != null;
            clienteActivo = button2.Text != "CAMBIAR CLIENTE" && personaValida;
            if (!clienteActivo)
            {
                txtApellidoCliente.Text = "";
                txtNombreCliente.Text = "";
                _persona = null;
                txtDniCliente.Text = "";
            }
            txtDniCliente.Enabled = !clienteActivo;
            txtApellidoCliente.Enabled = !clienteActivo;
            txtNombreCliente.Enabled = !clienteActivo;
            button2.Text = !clienteActivo ? "AGREGAR CLIENTE" : "CAMBIAR CLIENTE";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != "CAMBIAR CLIENTE")
            {
                AgregarCliente();
            }
            desactivarCamposCliente();
        }

        private void generarNroVenta()
        {
            _venta = new();
            _venta.NumeroVenta = VentasNegocio.GenerarNumeroVenta();
            txtNumVenta.Text = _venta.NumeroVenta.ToString();
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dniEnter();
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form myForm = Application.OpenForms["FrmAdminPrendas"] as Form;
            if (myForm != null)
            {
                if (((FrmAdminPrendas)myForm).modo == EnumModoForm.Venta)
                {
                    myForm.Close();
                }
            }
            this.Close();
        }

        private void dniEnter ()
        {
            string mensaje = "";
            if (String.IsNullOrWhiteSpace(txtDniCliente.Text.Trim()))
            {
                return;
            }
            if (!buscarCliente(ref mensaje))
            {
                return;
            }
            desactivarCamposCliente();
            cargarComboContactos();
            cargarComboDomicilios();
        }

        private void btnBuscarPrenda_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (frmPrincipal == null)
            {
                return;
            }
            frmPrincipal.consultarPrenda(EnumModoForm.Venta);
            /*frmPrincipal.consultarPrendaParaVentas();*/
        }

        private void actualizarGrillaCarrito(object sender, EventArgs e)
        {
            if (_detallesVentas == null)
            {
                return;
            }

            int index = 0;
            // este método actualiza la la grilla del carrito.
            for (int i = 0; i < _detallesVentas.Count; i++)
            {
                _detallesVentas[i].IdDetalleVenta = i + 1;
            }
            bindingSourceDetallesVentas.DataSource = null;
            bindingSourceDetallesVentas.DataSource = _detallesVentas;
            // Recorrer todas las filas de la grilla
            foreach (DataGridViewRow fila in dataGridViewCarrito.Rows)
            {
                // Recorrer todas las celdas de la fila
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    // Verificar si el nombre de la columna es "Precio"
                    if (dataGridViewCarrito.Columns[celda.ColumnIndex].Name == "PrecioVenta" && index < _detallesVentas.Count)
                    {
                        celda.Value = _detallesVentas[index].DetallesPrendas.PrecioVenta.ToString();
                        index++;
                    }
                }
            }
            //dataGridViewCarrito.Refresh();
            SumarTotal();
        }

        private void cargarComboDomicilios()
        {
            if (_persona == null)
            {
                return;
            }
            domiciliosBindingSource.Clear();
            List<Domicilios>? domicilios = DomiciliosMetodos.DomiciliosPersona(_persona) ?? new();
            domiciliosBindingSource.DataSource = domicilios;
        }

        private void cargarComboContactos()
        {
            if (_persona == null)
            {
                return;
            }
            contactosBindingSource.Clear();
            List<Contactos>? contactos = ContactosMetodos.ContactosPorPersona(_persona) ?? new();
            contactosBindingSource.DataSource = contactos;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (!agregarDetalle(ref mensaje, sender, e))
            {
                MessageBox.Show("No se pudo agregar la prenda al carrito por los siguientes errores: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public bool agregarDetalle(ref string mensaje, object sender, EventArgs e)
        {
            //Si no hay detalles creados creo la lista
            if (_detallesVentas == null)
            {
                _detallesVentas = new();
            }

            //Busco el item seleccionado
            Item? item = (Item)cmbPrendas.SelectedItem;
            mensaje = "";

            //Si no hay ninguno es error
            if (item == null)
            {
                mensaje = "\nNo ha cargado ninguna prenda. Búsquela con el botón 'Buscar Prenda'";
                return false;
            }

            //Veo si hay estados seleccionados (prendas), si no creo la lista
            if (estadosSeleccionados == null)
            {
                estadosSeleccionados = new();
            }

            //Busco si la prenda del item está cargada en los estados seleccionados
            EstadosPrendas? estadoPrenda = estadosSeleccionados.FirstOrDefault(e => e.IdEstadosPrendas == item.Value);

            //Hago un booleano para usar más adelante
            bool cargada = estadoPrenda != null;

            //Si la prenda no está seleccionada la busco des entre las para seleccionar
            if (!cargada)
            {
                estadoPrenda = _estadosPrendas.FirstOrDefault(e => e.IdEstadosPrendas == item.Value);
            }
            
            //Si aún así no la encuentra es error
            if (estadoPrenda == null)
            {
                mensaje += "\nNo se ha añadido ninguna prenda. Problemas al traer la búsqueda";
                return false;
            }

            //Accedo al detalle de prenda para modificar las cantidades
            DetallesPrendas detallePrenda = estadoPrenda.DetallesPrendas;

            //Para detalles de venta si no está en el carrito la prenda lo creo nuevo, sino lo selecciono de su listas
            DetallesVentas detalle = cargada ? _detallesVentas.FirstOrDefault(d => d.IdVenta == estadoPrenda.IdEstadosPrendas) : new();

            //Si la prenda no esta cargada en el carrito le cargo los datos al detalle de venta
            if (!cargada)
            {
                detalle.DescripcionProducto = item.Descripcion;
                
            }
            
            //Traigo la cantidad del detalle de venta y para descontar al detalle de prenda y a la prenda
            int cantidad = (int)numUpDownCantPrendas.Value;
            int cantidadDescontar = (int)numUpDownCantPrendas.Value;

            //Si ya está cargada solo le sumo la cantidad al detalle de ventas
            cantidad += cargada ? detalle.Cantidad : 0;
            
            //Seteo la cantidad máxima
            int cantidadMaxima = estadoPrenda.CantidadEstado;

            //Si no seleccionó cantidad devuelve error
            if (cantidad == 0)
            {
                mensaje += "Ingrese una cantidad";
                return false;
            }

            //Procuro que no exceda la cantidad máxima
            if (cantidad > cantidadMaxima)
            {
                mensaje += "Las prendas ingresadas superan al stock actual";
                return false;
            }
            detalle.Cantidad = cantidad;


            //Corroboro y seteo el precio
            string pre = txtPrecioPrenda.Text.Trim();
            decimal precio = 0;
            try
            {
                precio = decimal.Parse(pre);
            }
            catch (Exception ex)
            {
                mensaje += "\n Error con el precio. Informe: " + ex.Message;
            }

            //No dejo que sea 0
            if (precio <= 0)
            {
                mensaje += "\nFalta ingresar el precio de venta";
            }

            //Si vuelvo a agregar una prenda que ya estaba cargada y el precio es diferente le cambio el precio a todas
            if (cargada && precio != detallePrenda.PrecioVenta)
            {
                MessageBox.Show("Atención si el precio es diferente al mismo detalle agregado previamente, el mismo será reemplazado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Le pongo el precio al detalle de prenda (Si ya estaba se reemplaza)
            detallePrenda.PrecioVenta = precio;

            //Si hay un error hasta ahora el mensaje no va a estar vacío
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            //Seteo los datos del detalle de venta
            detalle.IdDetallePrenda = estadoPrenda.IdDetallePrenda;
            detalle.IdPrenda = estadoPrenda.IdPrenda;
            detalle.DetallesPrendas = detallePrenda;
            detalle.SubTotal = cantidad * precio;

            //El Id de venta lo uso para guardar el estado que estoy vendiendo en ese detalle
            detalle.IdVenta = (int)estadoPrenda.IdEstadosPrendas;

            //Descuento los Stocks
            estadoPrenda.Prendas.Cantidad -= cantidadDescontar;
            estadoPrenda.DetallesPrendas.CantidadPrenda -= cantidadDescontar;
            
            //Si no estaba cargada la anexo a las listas (Estados seleccionados y detallles de venta)
            if (!cargada)
            {
                estadosSeleccionados.Add(estadoPrenda);
                _detallesVentas.Add(detalle);
                
            }
            
            actualizarGrillaCarrito(sender, e);


            return true;
        }



        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridViewCarrito.CurrentRow;

            if (filaSeleccionada != null)
            {
                int id = Convert.ToInt32(filaSeleccionada.Cells["id"].Value);
                DetallesVentas? detalle = _detallesVentas.FirstOrDefault(d => d.IdDetalleVenta == id);
                if (detalle != null)
                {
                    EstadosPrendas? estado = estadosSeleccionados.FirstOrDefault(ep => ep.IdEstadosPrendas == detalle.IdVenta);
                    if (estado != null)
                    {
                        EstadosPrendas? estadoLista = _estadosPrendas.FirstOrDefault(ep => ep.IdEstadosPrendas == estado.IdEstadosPrendas);
                        estadosSeleccionados.Remove(estado);
                    }

                    _detallesVentas.Remove(detalle);
                }
                else
                {
                    MessageBox.Show("Error: No se puede retirar el item seleccionado ¡Contacte al administrador!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            actualizarGrillaCarrito(sender, e);
            bindingSourceDetallesPrendas.DataSource = null;
            bindingSourceDetallesPrendas.DataSource = prendas;
        }

        private bool llenarObjetoVenta(ref string mensaje)
        {
            AgregarCliente();
            if (!clienteActivo)
            {
                mensaje += "\nProblemas con el cliente. Verifique de cargar los datos correspondientes y presionar AGREGAR CLIENTE";
                return false;
            }
            _venta = new();
            if (_cliente.IdCliente != null)
            {
                _venta.IdCliente = (int)_cliente.IdCliente;
            }
            else
            {
                _venta.Clientes = _cliente;
            }

            string nro = txtNumVenta.Text.Trim();
            int num = 0;
            if (!int.TryParse(nro, out num))
            {
                mensaje += "\nProblemas con el número de venta, se registra como cero";
            }

            _venta.NumeroVenta = num;
            _venta.IdResponsableVenta = _IdResponsableVenta;
            _venta.FechaVenta = DateTime.Now;
            return true;

        }

        private bool acomodarCantidadesEstados(ref string mensaje)
        {
            bool exito = true;
            foreach (EstadosPrendas estado in estadosSeleccionados)
            {
                try
                {
                    int cantidad = _detallesVentas.Where(d => d.IdVenta == estado.IdEstadosPrendas).Select(d => d.Cantidad).FirstOrDefault();
                    estado.CantidadEstado -= cantidad;
                    if (cantidad == 0)
                    {
                        exito = false;
                        mensaje += $"\nNo se pudo descontar la cantida de la prenda {estado.Prendas.DescripcionPrenda}";
                    }
                } catch (Exception ex)
                {
                    mensaje += $"\nNo se pudo descontar la cantida de la prenda {estado.Prendas.DescripcionPrenda}\nError: {ex.Message}";
                    exito = false;
                }
                
            }
            return exito;
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            //Controlo las listas
            string mensaje = "";
            if (_detallesVentas == null || _detallesVentas.Count == 0)
            {
                mensaje += "\nNo hay prendas añadidas al carrito";
            }

            if (_estadosPrendas.Count == 0)
            {
                mensaje += "\nNo hay Estados en las prendas para vender";
            }

            if (estadosSeleccionados == null || estadosSeleccionados.Count == 0)
            {
                mensaje += "\nNo hay Estados en las prendas para vender";
            }

            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                MessageBox.Show("La venta no se puede registrar debido a los siguientes errores:" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!acomodarCantidadesEstados(ref mensaje))
            {
                MessageBox.Show("La venta no se puede registrar debido a los siguientes errores:" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Si todas tienen algo inicio creando la entidad venta
            if (!llenarObjetoVenta(ref mensaje))
            {
                MessageBox.Show("La venta no se puede registrar debido a los siguientes errores:" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_venta == null)
            {
                MessageBox.Show("Error al obtener información de la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Pido confirmación
            DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            //Veo si tiene envío
            string observacionEnvio = "";
            string mensajeEnvío = "";
            if (checkEnvio.Checked)
            {
                //Si tiene controlo que tenga dirección y teléfono cargados
                observacionEnvio = $"Envío: {comboDomicilio.Text.Trim()} / {comboTelefono.Text.Trim()}";
                if (String.IsNullOrWhiteSpace(comboDomicilio.Text.Trim()))
                {
                    mensajeEnvío = "\nFalta ingresar la dirección de envío";
                }
                if (String.IsNullOrWhiteSpace(comboTelefono.Text.Trim()))
                {
                    mensajeEnvío += "\nFalta ingresar un teléfono de contacto";
                }
            }

            //Si falta alguno aviso y cancelo
            if (!String.IsNullOrWhiteSpace(mensajeEnvío))
            {
                MessageBox.Show("Seleccionó envío a domicilio pero no ingresó la siguiente información"+mensajeEnvío, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Aviso la información de envio y pido confirmación
            if (!String.IsNullOrWhiteSpace(observacionEnvio))
            {
                DialogResult envio = MessageBox.Show($"Se registrará el envío a domicilio con la siguiente información\n{observacionEnvio}¿Los datos son correctos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (envio == DialogResult.No)
                {
                    return;
                }
                else
                {
                    //Guardo la información de envío en las observaciones de la venta
                    _venta.ObservacionesVenta = observacionEnvio;
                }
            } else
            {
                _venta.ObservacionesVenta = "";
            }
            
            //Registro la venta pelada y si da error cancelo todo
            int idVenta = 0;
            idVenta = VentasNegocio.RegistrarNuevaVenta(_venta, ref mensaje);
            if (idVenta == 0)
            {
                MessageBox.Show("La venta no se puede registrar debido a los siguientes errores:" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Hago los estados reservada y descuento el stock
            //Traigo los id en matriz para ver si hay errores y acceder a los ids de reservas y aptas
            List<List<int>>? matrizIds = VentasNegocio.ReservarStock(estadosSeleccionados, _venta.NumeroVenta.ToString(), ref mensaje);

            //Si no se llenó la matriz el error es grave
            if (matrizIds == null)
            {
                MessageBox.Show("La venta no se puede registrar debido a los siguientes errores:" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Ahora creo los detalles de la venta
            List<int>? idDetalles = VentasNegocio.RegistrarDetallesVenta(_detallesVentas, idVenta, matrizIds , ref mensaje);

            //Si no se creó la lista también es grave
            if (idDetalles == null || idDetalles.Count == 0)
            {
                MessageBox.Show("La venta no se puede registrar debido a los siguientes errores:" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //Finalizo cambiando el estado a la venta
            string mensajeEstado = VentasNegocio.CambiarEstadoVenta(_venta, "Finalizada");
            mensaje += mensajeEstado;

            //Pregunto si quiere cobrarla
            DialogResult terminar = MessageBox.Show("La venta fué registrada con éxito ¿Desea cobrarla ahora mismo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (!String.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("Se notifican los siguientes detalles:" + mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (terminar == DialogResult.No)
            {
                this.Close();
                return;
            }
            int nroVenta = int.Parse(txtNumVenta.Text);
            _venta = VentasNegocio.getVentaPorNumeroVenta(nroVenta);
            _detallesVentas = VentasNegocio.GetDetallesVentas(_venta);
            VentaConsulta v = new(_venta.Empleados, _venta.Clientes, _venta, _detallesVentas, _venta.Estados);

            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (padre == null)
            {
                padre = new FrmPrincipal();
            }
            FrmFacturacion frmFacturacion = Application.OpenForms.OfType<FrmFacturacion>().FirstOrDefault();
            if (frmFacturacion != null)
            {
                frmFacturacion.Close();
            }  
            FrmFacturacion facturar = new FrmFacturacion();
            facturar.MdiParent = padre;
            facturar.Dock = DockStyle.Fill;
            facturar.traerDesdeConsulta(v);
            facturar.Show();
            this.Close();

        }

        private void checkEnvio_CheckedChanged(object sender, EventArgs e)
        {
            mostrarEnvío(checkEnvio.Checked);
        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            IrABusquedaCliente();
        }
    }
}
