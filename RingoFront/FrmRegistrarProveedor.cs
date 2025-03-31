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
    public partial class FrmRegistrarProveedor : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta;
        List<string>? credenciales = new();
        public Proveedores? _proveedor = null;
        //Listas del proveedor
        public List<CategoriaSubCategoria>? _categoriasComercializadas = new();
        private List<Estados>? _estados = new();
        private List<CondicionesFiscales>? _condicionesFiscales = new();
        //Campos
        private string? _preCuit = null;
        private string? _dniCuit = null;
        private string? _posCuit = null;
        private string? _cuit = null;
        private string? _razonSocial = null;
        private string? _detalles = null;
        private DateTime? _inicioActividades = null;

        //Lista de contactos del proveedor
        private List<Contactos>? _contactos = new();
        public List<Contactos>? _contactosNuevos = new();

        //domicilio del proveedor
        private Domicilios? _domicilio = new();

        //Listas del domicilio
        //Listas de comboBox       
        private List<Barrios>? _barrios = null;
        private List<Ciudades>? _ciudades = null;
        private List<Provincias>? _provincias = null;
        //Listas de todos para evitar acceso continuo a la BD
        private List<Barrios>? _barriosTodos = null;
        private List<Ciudades>? _ciudadesTodas = null;


        //Datos del domicilio
        //Entidades
        private Provincias? _provincia = null;
        private Ciudades? _ciudad = null;
        private Barrios? _barrio = null;
        //genéricas
        private Ciudades? ciudadGenerica = null;
        private Barrios? barrioGenerico = null;

        //Campos
        private string? _calle = null;
        private string? _altura = null;
        private string? _piso = null;
        private string? _depto = null;
        private string? _observacionesBarrio = null;
        private string? _codPostal = null;



        public FrmRegistrarProveedor()
        {
            InitializeComponent();
        }

        //-----Validadores-----//
        //Validador de credenciales
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

        //Validador numérico
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Carga de formulario
        private void FrmRegistrarProveedor_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            cargarCombosDomiciliosGenericos();
            cargarComboCondFiscal();
            cargarComboEstados();
            if (modo == EnumModoForm.Alta)
            {
                activarCamposAlta(false);
            }
            else
            {
                string mensaje = string.Empty;
                if (cargarProveedor(ref mensaje))
                {
                    cargarDomicilio();
                    cargarContactos();
                }
                else
                {
                    activarCamposAlta(false);
                    txtPreCuit.Enabled = true;
                    txtDniCuit.Enabled = true;
                    txtPosCuit.Enabled = true;
                }
                if (modo == EnumModoForm.Consulta)
                {
                    labelTitulo.Text = "CONSULTAR PROVEEDOR";
                    activarCamposAlta(false);
                    txtRazonSocial.Enabled = false;
                    btnGuardar.Enabled = false;
                }
                else
                {
                    labelTitulo.Text = "MODIFICAR PROVEEDOR";
                    if (_proveedor != null)
                    {
                        activarCamposAlta(true);
                    }
                    txtRazonSocial.Enabled = true;
                    btnBuscar_Click(sender, e);
                }
            }
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
        }

        //-----Métodos de carga-----//
        //Método perfeccionado para el alta de los combos ciudad, provincia y barrios al inicio
        private void cargarCombosDomiciliosGenericos()
        {
            //Primero limpio las fuentes de datos y las listas (provincia se limpia en otro método)
            bindingBarrios.Clear();
            bindingCiudades.Clear();
            _barrios = new();
            _ciudades = new();
            _provincias = new();


            //Traigo barrio genérico que tendrá dentro provincia y ciudad (si no existen los crea)
            Barrios? genericos = DomiciliosMetodos.getGenericosDomicilios();
            if (genericos != null)
            {
                if (genericos.Ciudades != null)
                {
                    ciudadGenerica = new Ciudades();
                    ciudadGenerica.IdCiudad = genericos.IdCiudad;
                    ciudadGenerica.NombreCiudad = genericos.Ciudades.NombreCiudad;
                }
                genericos.Ciudades = null;
                barrioGenerico = genericos;
            }

            //Cargo todas las listas
            _ciudadesTodas = DomiciliosMetodos.CiudadesTodas();
            _barriosTodos = DomiciliosMetodos.BarriosTodos();

            //Cargo provincias al combo
            cargarComboProvincias();

            //Cargo la ciudad genérica en la lista de ciudades
            Ciudades c = ciudadGenerica ?? new();
            _ciudades.Add(c);

            //Añado el barrio genérico al combo de barrios
            Barrios b = barrioGenerico ?? new();
            _barrios.Add(b);

            //Conecto las fuentes de datos de barrios y ciudades
            bindingCiudades.DataSource = _ciudades;
            bindingBarrios.DataSource = _barrios;
        }

        private void cargarComboProvincias()
        {
            List<Provincias>? provincias = DomiciliosMetodos.ProvinciasTodas();
            if (provincias != null)
            {
                Provincias? nula = provincias.FirstOrDefault(p => p.NombreProvincia == "---");
                if (nula == null)
                {
                    _provincias.AddRange(provincias);
                } else
                {
                    _provincias = provincias;
                }
                
            }
            bindingProvincias.DataSource = _provincias;
        }


        //Cargar combo ciudades
        private void cargarComboCiudades()
        {
            _provincia = new();
            //Recupero la provincia seleccionada
            if (_provincias == null)
            {
                return;
            }
            _provincia = _provincias.FirstOrDefault(p => p.NombreProvincia == cbxProvincia.Text);
            bindingCiudades.Clear();
            _ciudades = new();
            if (_provincia == null)
            {
                _provincia = _provincias.FirstOrDefault(p => p.NombreProvincia == "---");
                if (_provincia == null)
                {
                    return;
                }
            }
            if (ciudadGenerica != null && _provincia.NombreProvincia != "---")
            {
                _ciudades.Add(ciudadGenerica);
            }
            
            //si las ciudades ya cargadas estan no voy a la BD
            List<Ciudades>? ciudades = new();
            if (_ciudadesTodas != null && _ciudadesTodas.Count > 0)
            {
                ciudades = _ciudadesTodas.Where(c => c.IdProvincia == (int)_provincia.IdProvincia).ToList();
            } else
            {
                //Si no hay cargados busco en la BD
                ciudades = DomiciliosMetodos.CiudadesPorProvincia(_provincia) ?? new();
            }
            //añado lo que sea que haya encontrado a la lista del binding
            _ciudades.AddRange(ciudades);
            bindingCiudades.DataSource = _ciudades;
            if (_ciudades.Count > 0)
            {
                cbxCiudad.SelectedIndex = 0;
            }

            //cargo la ciudad actual al listado para cambiar los barrios
            _ciudad = new();
            _ciudad = (Ciudades)cbxCiudad.SelectedItem;
            _codPostal = _ciudad != null ? (_ciudad.CodigoPostal.ToString() ?? "") : "";
            txtCodPostal.Text = _ciudad != null ? (_ciudad.CodigoPostal.ToString() ?? "") : "";
            txtCodPostal.Enabled = String.IsNullOrWhiteSpace(_codPostal);
            cargarComboBarrios();
        }

        //Cargar combo barrios
        private void cargarComboBarrios()
        {
            _ciudad = new();
            _ciudad = (Ciudades)cbxCiudad.SelectedItem;
            bindingBarrios.Clear();
            _barrios = new();
            if (_ciudad == null)
            {
                _ciudad = ciudadGenerica;
            }
            if (barrioGenerico != null && _ciudad.NombreCiudad != "---")
            {
                _barrios.Add(barrioGenerico);
            }
            List<Barrios>? barrios = new();
            if (_barriosTodos != null && _barriosTodos.Count > 0)
            {
                barrios = _barriosTodos.Where(b => b.IdCiudad == (int)_ciudad.IdCiudad).OrderBy(b => b.NombreBarrio).ToList();
            } else
            {
                barrios = DomiciliosMetodos.BarriosPorCiudad(_ciudad);
            }
            if (barrios != null)
            {
                _barrios.AddRange(barrios);
            }
            bindingBarrios.DataSource = _barrios;
        }

        //Cargar combo estados
        private void cargarComboEstados()
        {
            bindingEstados.Clear();
            _estados = new();
            _estados = PersonasMetodos.EstadosPorIndole("Proveedores");
            bindingEstados.DataSource = _estados;
            if (_estados ==  null)
            {
                return;
            }

            if (modo == EnumModoForm.Alta)
            {
                Estados? estado = cbxEstados.Items.Cast<Estados>().FirstOrDefault(e => e.Estado == "Alta");
                if (estado != null)
                {
                    cbxEstados.SelectedItem = estado;
                }
            } else
            {
                if (_proveedor != null)
                {
                    Estados? est = _estados.FirstOrDefault(e => e.IdEstado == _proveedor.IdEstado);
                    if (est != null)
                    {
                        cbxEstados.SelectedItem = est;
                    }
                }
            }
            
            cbxEstados.Enabled = modo == EnumModoForm.Modificacion;
        }

        //Cargar combo condiciones Fiscales
        private void cargarComboCondFiscal()
        {
            _condicionesFiscales = new();
            _condicionesFiscales = PersonasMetodos.ConsultarCondicionesFiscales();
            CondicionesFiscales? consFinal = null;
            if (_condicionesFiscales != null && _condicionesFiscales.Count > 0)
            {
                consFinal = _condicionesFiscales.FirstOrDefault(c => c.DetalleFiscal.Equals("Consumidor Final", StringComparison.OrdinalIgnoreCase));
            }
            if (consFinal != null)
            {
                _condicionesFiscales.Remove(consFinal);
            }
            bindingCondFisc.Clear();
            bindingCondFisc.DataSource = _condicionesFiscales;
            cbxCondicionFiscal.Enabled = modo != EnumModoForm.Consulta;
        }

        //Cargar contactos en grilla
        public void TraerContactos(List<Contactos>? c)
        {
            bindingContactos.Clear();
            if (c == null)
            {
                bindingContactos.DataSource = null;
                dataGridView1.Refresh();
                return;
            }
            _contactosNuevos = c;
            bindingContactos.DataSource = _contactosNuevos;
            dataGridView1.Refresh();
        }

        //Cargar datos d proveedor para modificacion
        private bool cargarProveedor(ref string mensaje)
        {
            if (_proveedor == null)
            {
                mensaje = "No se pudo encontrar al proveedor seleccionado.";
                return false;
            }
            if (_proveedor.Empresas == null)
            {
                mensaje = "No se pudo extraer información del proveedor seleccionado.";
                return false;
            }
            txtRazonSocial.Text = _proveedor.Empresas.RazonSocial;
            _cuit = _proveedor.Empresas.Cuit ?? "";
            if (String.IsNullOrWhiteSpace(_cuit))
            {
                txtPreCuit.Text = "";
                txtDniCuit.Text = "";
                txtPosCuit.Text = "";
            }
            else
            {
                txtPreCuit.Text = _cuit.Substring(0, 2);
                txtDniCuit.Text = _cuit.Substring(3, _cuit.Length - 5);
                txtPosCuit.Text = _cuit.Substring(_cuit.Length - 1);
            }
            txtDetallesProv.Text = _proveedor.DetalleProveedor ?? "";
            if (_estados != null)
            {
                cbxEstados.SelectedValue = _proveedor.IdEstado;
            }
            if (_condicionesFiscales != null)
            {
                cbxCondicionFiscal.SelectedValue = _proveedor.Empresas.IdCondicionFiscal;
            }
            return true;
        }

        private void cargarDomicilio()
        {
            _domicilio = ProveedoresNegocio.DomicilioPorProveedor(_proveedor);
            if (_domicilio != null)
            {
                txtCalle.Text = _domicilio.Calle ?? "";
                txtAltura.Text = _domicilio.Altura ?? "";
                txtPiso.Text = _domicilio.Piso ?? "";
                txtDepto.Text = _domicilio.Departamento ?? "";
                if (_domicilio.Ciudades == null)
                {
                    return;
                }
                cbxProvincia.SelectedValue = _domicilio.Ciudades.IdProvincia;
                cbxProvincia.Refresh();
                cargarComboCiudades();
                cbxCiudad.SelectedValue = _domicilio.IdCiudad;
                cbxCiudad.Refresh();
                cargarComboBarrios();
                if (_domicilio.IdBarrio == null)
                {
                    return;
                }
                cbxBarrio.SelectedValue = _domicilio.IdBarrio;
                
            }
        }

        private void cargarContactos()
        {
            if (_proveedor == null)
            {
                return;
            }
            if (_proveedor.Empresas == null)
            {
                return;
            }
            bindingContactos.Clear();
            _contactos = null;
            _contactos = ProveedoresNegocio.ContactosPorProveedor(_proveedor);
            if (_contactos == null)
            {
                _contactos = new();
            }
            bindingContactos.DataSource = _contactos;
            dataGridView1.Refresh();
        }

        //-----Validadores-----//
        private void cbxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboCiudades();
        }

        private void cbxCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboBarrios();
        }

        private void activarCamposAlta(bool habilitar)
        {
            txtPreCuit.Enabled = habilitar;
            txtPosCuit.Enabled = habilitar;
            txtDniCuit.Enabled = habilitar;
            txtRazonSocial.Enabled = !habilitar;
           
            if(modo == EnumModoForm.Modificacion)
                txtRazonSocial.Enabled = habilitar; 
            
            dateTimeFechaInicio.Enabled = habilitar;
            txtDetallesProv.Enabled = habilitar;
            txtCalle.Enabled = habilitar;
            txtAltura.Enabled = habilitar;
            txtPiso.Enabled = habilitar;
            txtDepto.Enabled = habilitar;
            txtObsBarrio.Enabled = habilitar;
            cbxProvincia.Enabled = habilitar;
            cbxBarrio.Enabled = habilitar;
            cbxCiudad.Enabled = habilitar;
            txtCodPostal.Enabled = habilitar;
            btnAgregarContactos.Enabled = habilitar;
        }

        private bool existeProveedor(ref string mensaje)
        {
            recolectarCuitYRazonSocial();
            string msg = string.Empty;
            int idProv = ProveedoresNegocio.existe(_razonSocial, _cuit, ref msg);
            mensaje = msg;
            if (idProv > 0)
            {
                
                if (modo == EnumModoForm.Alta)
                {
                    _proveedor = new();
                    _proveedor.IdProveedor = idProv;
                    _proveedor = ProveedoresNegocio.GetProveedorPorId(idProv);
                    mensaje = "El proveedor con la razon social ingresada ya existe, ingrese otro por favor";
                    return true;
                }
                if (modo == EnumModoForm.Modificacion)
                {
                    if (_proveedor.IdProveedor != idProv)
                    {
                        mensaje = "El cuit o razon social ingresados están siendo utilizados por otro proveedor";
                        return true;
                    } else
                    {
                        return false;
                    }
                }
                
                return _proveedor != null;

            }
            else
            {
                if (modo == EnumModoForm.Alta)
                {
                    _proveedor = new();
                    _proveedor.IdProveedor = null;
                }
                return false;
            }

        }

        //-----Métodos de recoleccion y limpieza de campos-----//
        private void limpiarCampos()
        {
            txtPreCuit.Text = string.Empty;
            txtPosCuit.Text = string.Empty;
            txtDniCuit.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtDetallesProv.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtAltura.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtDepto.Text = string.Empty;
            bindingContactos.Clear();
            _contactos = new();
            bindingContactos.DataSource = _contactos;
        }

        private void recolectarCuitYRazonSocial()
        {
            _preCuit = txtPreCuit.Text.Trim();
            _posCuit = txtPosCuit.Text.Trim();
            _dniCuit = txtDniCuit.Text.Trim();

            if (String.IsNullOrWhiteSpace(_preCuit) || String.IsNullOrWhiteSpace(_dniCuit) || String.IsNullOrWhiteSpace(_posCuit))
            {
                _cuit = null;
            }
            else
            {
                _cuit = $"{_preCuit}-{_dniCuit}-{_posCuit}";
            }

            _razonSocial = txtRazonSocial.Text.Trim();
        }

        private bool recolectarProveedor(ref string mensaje)
        {
            Empresas? empresa;
            if (modo == EnumModoForm.Alta)
            {
                _proveedor = new();
                empresa = new();
            }
            else if (_proveedor == null)
            {
                _proveedor = new();
                empresa = new();
            }
            else
            {
                empresa = _proveedor.Empresas ?? new();
            }
            if (String.IsNullOrWhiteSpace(_razonSocial))
            {
                mensaje += "\nLa razón social es obligatoria para el proveedor";
                return false;
            }

            empresa.RazonSocial = _razonSocial;
            empresa.Cuit = _cuit;
            _detalles = txtDetallesProv.Text.Trim();
            _proveedor.DetalleProveedor = _detalles;
            string fecha = dateTimeFechaInicio.Text.Trim();
            try
            {
                _inicioActividades = DateTime.Parse(fecha);
                if (_inicioActividades < DateTime.Today)
                {
                    empresa.InicioActividades = _inicioActividades;
                }
                else
                {
                    empresa.InicioActividades = null;
                }
            }
            catch (Exception ex)
            {
                mensaje += $"\nSe presentaron los siguientes problemas con la fecha \n{ex.Message}";
            }
            _proveedor.IdEstado = (int)cbxEstados.SelectedValue;
            empresa.IdCondicionFiscal = (int)cbxCondicionFiscal.SelectedValue;
            mensaje += recolectarDomicilio(empresa);
            empresa.Domicilios = _domicilio;
            _proveedor.Empresas = empresa;
            return true;
        }

        private string recolectarDomicilio(Empresas empresa)
        {
            string mensaje = "";
            if (empresa.Domicilios == null || modo == EnumModoForm.Alta)
            {
                _domicilio = new();
            } else
            {
                _domicilio = empresa.Domicilios;
            }
            
            _calle = txtCalle.Text.Trim();
            if (!String.IsNullOrWhiteSpace(_calle))
            {
                _domicilio.Calle = _calle;
            }
            _altura = txtAltura.Text.Trim();
            if (!String.IsNullOrWhiteSpace(_altura))
            {
                _domicilio.Altura = _altura;
            }
            _piso = txtPiso.Text.Trim();
            if (!String.IsNullOrWhiteSpace(_piso))
            {
                _domicilio.Piso = _piso;
            }
            _depto = txtDepto.Text.Trim();
            if (!String.IsNullOrWhiteSpace(_depto))
            {
                _domicilio.Departamento = _depto;
            }
            _observacionesBarrio = txtObsBarrio.Text.Trim();
            if (!String.IsNullOrWhiteSpace(_observacionesBarrio))
            {
                _domicilio.ObservacionesBarrio = _observacionesBarrio;
            }
            _provincia = (Provincias)cbxProvincia.SelectedItem;
            if (_provincia == null)
            {
                _ciudad = _domicilio.Ciudades = null;
                _barrio = _domicilio.Barrios = null;
                _codPostal = null;
                _domicilio.IdBarrio = null;
                _domicilio.IdCiudad = null;
                return "Domicilio sin provincia, no se cargan ni ciudad ni barrio";
            }
            _ciudad = null;
            _barrio = null;
            string nombreCiudad = cbxCiudad.Text.Trim();
            string nombreBarrio = cbxBarrio.Text.Trim();
            int cp = 0;
            if (String.IsNullOrWhiteSpace(nombreCiudad))
            {
                _codPostal = null;
                _ciudad = _domicilio.Ciudades = null;
                _barrio = _domicilio.Barrios = null;
                _domicilio.IdBarrio = null;
                _domicilio.IdCiudad = null;
                return "Domicilio sin ciudad, no se cargan ni provincia ni barrio";
            }
            _codPostal = txtCodPostal.Text.Trim() ?? "";
            if (!int.TryParse(_codPostal, out cp))
            {
                _codPostal = "";
            }

            if (_ciudades != null)
            {
                _ciudad = _ciudades.FirstOrDefault(c => c.NombreCiudad.Equals(nombreCiudad, StringComparison.OrdinalIgnoreCase));
            }
            if (_ciudad == null)
            {
                _ciudad = new();
                _ciudad.NombreCiudad = nombreCiudad;
                _ciudad.CodigoPostal = cp == 0 ? null : cp;
                _ciudad.IdProvincia = (int)_provincia.IdProvincia;
                mensaje += "\nLa ciudad ingresada no existe en la provincia, se registra nueva";
            }
            if (_ciudad.IdCiudad != null)
            {
                _domicilio.IdCiudad = _ciudad.IdCiudad;
                _domicilio.Ciudades = null;
            } else
            {
                _domicilio.Ciudades = _ciudad;
            }

            if (String.IsNullOrWhiteSpace(nombreBarrio))
            {
                _barrio = null;
                _barrio = _domicilio.Barrios = null;
                _domicilio.IdBarrio = null;
                return mensaje;
            }
            if (_barrios != null)
            {
                _barrio = _barrios.FirstOrDefault(b => b.NombreBarrio.Equals(nombreBarrio, StringComparison.OrdinalIgnoreCase));
            }
            if (_barrio == null)
            {
                _barrio = new();
                _barrio.NombreBarrio = nombreBarrio;
                _barrio.IdBarrio = null;

                if (_domicilio.IdCiudad != null)
                {
                    _barrio.IdCiudad = (int)_domicilio.IdCiudad;
                    _domicilio.Ciudades = null;
                    _ciudad = null;
                }
                mensaje += "\nEl barrio ingresado no existe en la ciudad, se registra nuevo";
            }
            if (_barrio.IdBarrio != null)
            {
                _domicilio.IdBarrio = _barrio.IdBarrio;
                _domicilio.Barrios = null;
            }
            else
            {
                _domicilio.Barrios = _barrio;
            }
            if (String.IsNullOrWhiteSpace(cbxBarrio.Text))
            {
                _barrio = null;
                _domicilio.Barrios = null;
                _domicilio.IdBarrio = null;
            }
            return mensaje;

        }

        //-----Métodos de Botones-----//
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarContactos_Click(object sender, EventArgs e)
        {
            FormContactosProveedores contactosProveedores = new FormContactosProveedores();
            if (_contactosNuevos == null || _contactosNuevos.Count == 0)
            {
                _contactosNuevos = _contactos;
            }
            contactosProveedores._contactos = _contactosNuevos;

            FrmPrincipal form = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;//para que el form se abra en el principal como hijo.

            if (form != null)
            {
                contactosProveedores.MdiParent = form;
                contactosProveedores.Dock = DockStyle.Fill;
                contactosProveedores.Show();
            }
        }


        //Hago un txt con la info de la operación realizada
        private void crearLogOperacion(string operacion, string mensaje, bool exito)
        {
            // Obtener la fecha actual en un formato adecuado para el nombre del archivo
            string fechaActual = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            //Le sumo si es correcto o fallido al mensaje
            string info = exito ? "¡¡¡Operacion exitosa!!!\n" : "***Operacion fallida***\n";

            // Obtener la ruta de la carpeta principal del proyecto
            string rutaCarpetaProyecto = AppDomain.CurrentDomain.BaseDirectory;

            // Definir la ruta de la carpeta logs
            string rutaCarpetaLogs = Path.Combine(rutaCarpetaProyecto, "logs");

            // Verificar si la carpeta logs existe, si no, crearla
            if (!Directory.Exists(rutaCarpetaLogs))
            {
                Directory.CreateDirectory(rutaCarpetaLogs);
            }

            // Crear el nombre del archivo usando la operación y la fecha actual
            string nombreArchivo = $"{operacion}_{fechaActual}.txt";

            // Definir la ruta completa del archivo en la carpeta logs
            string rutaArchivo = Path.Combine(rutaCarpetaLogs, nombreArchivo);

            // Escribir el contenido del mensaje en el archivo de texto
            File.WriteAllText(rutaArchivo, info + mensaje);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (existeProveedor(ref mensaje))
            {
                if (modo == EnumModoForm.Alta)
                {
                    MessageBox.Show("Error" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //FrmRegistrarProveedor_Load(sender, e);
                if (modo == EnumModoForm.Modificacion)
                {
                    MessageBox.Show("Error" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (_proveedor == null)
            {
                MessageBox.Show("Error" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!recolectarProveedor(ref mensaje))
            {
                MessageBox.Show("Error" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            bool correcto = false;
            if (modo == EnumModoForm.Alta)
            {
                correcto = ProveedoresNegocio.InsertProveedor(_proveedor, _contactosNuevos, ref mensaje);
            }
            
            if (modo == EnumModoForm.Modificacion)
            {
                correcto = ProveedoresNegocio.UpdateProveedor(_proveedor, _contactos, _contactosNuevos, ref mensaje);
            }
            string operacion = modo == EnumModoForm.Alta ? "Alta_Proveedor" : "Modificación_Proveedor";
            crearLogOperacion(operacion, mensaje, !correcto);

            if (!correcto)
            {
                MessageBox.Show("Error" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                mensaje = modo == EnumModoForm.Alta ? "¡Registro exitoso!" : "¡Modificación exitosa!";
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (existeProveedor(ref mensaje))
            {
                MessageBox.Show("Error" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                              
            } else
            {
                activarCamposAlta(true);
            }
            btnGuardar.Enabled = true;
        }
    }
}
