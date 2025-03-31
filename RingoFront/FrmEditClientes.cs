using RingoEntidades;
using RingoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RingoFront
{
    public partial class FrmEditClientes : Form
    {
        //Modos y credenciales
        public EnumModoForm modo = EnumModoForm.Alta;
        List<string>? credenciales = new();

        //Listas para combos
        private List<CondicionesFiscales>? _condicionesFiscales = new();
        private List<Estados>? _estados = new();
        private List<Provincias>? _provincias = new();
        private List<Ciudades>? _ciudades = new();
        private List<Barrios>? _barrios = new();
        //Listas para no acceder a la BD
        private List<Barrios>? _barriosTodos = null;
        private List<Ciudades>? _ciudadesTodas = null;


        private List<RedesSociales>? _redesSociales = new();
        private List<Domicilios> _domicilios = new();
        private List<Contactos>? _contactos = new();
        public Personas? _persona = new();
        public Clientes? _cliente = new();
        private CondicionesFiscales? _condicionFiscal = new();
        private Estados? _estado = new();
        private Provincias? _provincia = new();
        private Ciudades? _ciudad = new();
        private Barrios? _barrio = new();
        private RedesSociales? _redSocial = new();
        private Domicilios? _domicilio = new();
        private Contactos? _contacto = new();
        private UsersRedesSociales? _userRedesSociales = new();
        private List<int> alturas = new List<int> { 0, 0 };
        public bool registrarConVenta = false;

        private int altura = 750;

        public FrmEditClientes()
        {
            InitializeComponent();
        }

        private void FrmEditClientes_Load(object sender, EventArgs e)
        {
            cargarCombosDomiciliarios();
            if (modo == EnumModoForm.Modificacion)
            {
                InicioModificacion();
            }
            else if (modo == EnumModoForm.Consulta)
            {
                InicioConsulta();
            }
            else
            {
                InicioAlta();
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

        //Método perfeccionado para el alta de los combos ciudad, provincia y barrios al inicio
        private void cargarCombosDomiciliarios()
        {
            //Primero limpio las fuentes de datos y las listas (provincia se limpia en otro método)
            bindingSourceBarrio.Clear();
            bindingSourceLocalidad.Clear();
            _barrios = new();
            _ciudades = new();
            _provincias = new();

            //Traigo barrio genérico que tendrá dentro provincia y ciudad (si no existen los crea)
            Barrios genericos = DomiciliosMetodos.getGenericosDomicilios();
            if (genericos == null)
            {
                return;
            }

            //Cargo la lista de provincias con la ggenérica
            _provincias.Add(genericos.Ciudades.Provincias);

            //Cargo la ciudad genérica en la lista de ciudades
            Ciudades c = new Ciudades();
            c.IdCiudad = genericos.IdCiudad;
            c.IdProvincia = genericos.Ciudades.IdProvincia;
            _ciudades.Add(c);

            //Nulifico en el genérico para evitar problemas en el registro
            genericos.Ciudades = null;

            //Añado el barrio genérico al combo de barrios
            _barrios.Add(genericos);

            //Cargo el resto de provincias al combo
            cargarComboProvincias();

            //Conecto las fuentes de datos de barrios y ciudades
            bindingSourceLocalidad.DataSource = _ciudades;
            bindingSourceBarrio.DataSource = _barrios;
        }

        private void cargarComboProvincias()
        {
            bindingSourceProvincias.Clear();
            List<Provincias>? provincias = DomiciliosMetodos.ProvinciasTodas();
            if (provincias != null)
            {
                _provincias.AddRange(provincias);
            }
            bindingSourceProvincias.DataSource = _provincias;
        }

        private void CargaContactos()
        {
            _contactos = new();
            _contactos = ContactosMetodos.ContactosPorPersona(_persona);
            if (_contactos != null)
            {
                bindingSourceContactos.DataSource = _contactos;
                dataGridView1.Visible = true;
            }
            else
                dataGridView1.Visible = false;
            if (modo == EnumModoForm.Modificacion)
            {
                if (_contactos != null && _contactos.Count > 0)
                    linkContactos.Visible = true;
                else
                    btnContactos.Visible = true;
            }
            if (modo == EnumModoForm.Consulta)
            {
                if (_contactos != null && _contactos.Count > 0)
                    groupContac.Visible = true;
                else
                    groupContac.Visible = false;
            }

        }

        private void CargaDomicilios()
        {
            _domicilios = new();
            _domicilios = DomiciliosMetodos.DomiciliosPersona(_persona);
            if (_domicilios != null)
            {
                bindingSourceDomicilio.DataSource = _domicilios;
                dataGridDomicilios.Visible = true;
            }
            else
                dataGridDomicilios.Visible = false;
            if (modo == EnumModoForm.Modificacion)
            {
                if (_domicilios != null && _domicilios.Count > 0)
                    linkDomicilios.Visible = true;
                else
                    btnDomicilio.Visible = true;
            }
            if (modo == EnumModoForm.Consulta)
            {
                if (_domicilios != null && _domicilios.Count > 0)
                    groupDomi.Visible = true;
                else
                    groupDomi.Visible = false;
            }

        }

        private void InicioModificacion()
        {
            if (_persona == null)
            {
                HabilitarControlesPersona(false);
                btnRegistrar.Enabled = true;
                btnRegistrar.Text = "Buscar";
                txtDni.Enabled = true;
                btnContactos.Visible = false;
                return;
            }
            CargarPersona();
            CargaContactos();
            CargaDomicilios();
            cargarCFEstado();
            HabilitarControlesPersona(true);
            btnRegistrar.Enabled = true;
            btnRegistrar.Text = "Modificar";
        }

        private void cargarCFEstado()
        {
            _condicionesFiscales = PersonasMetodos.ConsultarCondicionesFiscales();
            _condicionFiscal = _condicionesFiscales.Where(c => c.IdCondicionFiscal.Equals(_persona.IdCondicionFiscal)).FirstOrDefault();
            condicionesFiscalesBindingSource.DataSource = _condicionesFiscales;
            if (_persona.IdCondicionFiscal != null && _condicionFiscal != null)
            {
                comboFiscal.SelectedIndex = _condicionesFiscales.IndexOf(_condicionFiscal);
            }
            _estado = PersonasMetodos.EstadoPorPersona(_persona);
            _estados = PersonasMetodos.EstadosPorIndole("Personas");
            bindingSourceEstados.DataSource = _estados;
            comboEstado.DataSource = bindingSourceEstados;
            if (_persona.IdEstado != null && _estados != null)
            {
                comboEstado.SelectedValue = _persona.IdEstado;
                
            }
                
        }

        private void InicioConsulta()
        {
            CargarPersona();
            CargaContactos();
            CargaDomicilios();
            cargarCFEstado();
            HabilitarControlesPersona(false);
            btnRegistrar.Enabled = false;
        }

        private void InicioAlta()
        {
            HabilitarControlesPersona(true);
            CargarComboCndFiscal();
            ComboEstadosAlta();
            btnContactos.Visible = true;
            btnDomicilio.Visible = true;
            if (_persona != null)
            {
                if (_persona.Dni != null)
                {
                    txtDni.Text = _persona.Dni.ToString();
                    txtDniCuil.Text = _persona.Dni.ToString();
                }
            }
        }

        private void CargarPersona()
        {
            txtApellido.Text = _persona.Apellidos;
            txtNombre.Text = _persona.Nombre;
            txtDni.Text = _persona.Dni;
            if (_persona.Cuil != null)
            {
                if (!String.IsNullOrWhiteSpace(_persona.Cuil))
                {
                    txtPreCuil.Text = _persona.Cuil.Substring(0, 2);
                    txtDniCuil.Text = _persona.Cuil.Substring(2, _persona.Cuil.Length - 3);
                    txtPosCuil.Text = _persona.Cuil.Substring(_persona.Cuil.Length - 1);
                }
            }

            if (_persona.FechaNacimiento != null)
            {
                dateNacimiento.Text = _persona.FechaNacimiento.ToString();
            }
            if (_persona.Observaciones != null)
                txtObservaciones.Text = _persona.Observaciones;
        }


        public void grillaDomicilioAlta(List<Domicilios>? domicilios, bool visibildad)
        {
            dataGridDomicilios.Visible = visibildad;
            linkDomicilios.Visible = visibildad;
            btnDomicilio.Visible = !visibildad;
            _domicilios = new();
            _domicilios = domicilios;
            bindingSourceDomicilio.DataSource = _domicilios;
            dataGridDomicilios.Refresh();
        }

        public void grillaContactoAlta(List<Contactos>? contactos, bool visibildad)
        {
            dataGridView1.Visible = visibildad;
            linkContactos.Visible = visibildad;
            btnContactos.Visible = !visibildad;
            _contactos = new();
            _contactos = contactos;
            bindingSourceContactos.DataSource = _contactos;
            dataGridView1.Refresh();
        }

        private void CargarComboCndFiscal()
        {
            if (_condicionesFiscales != null)
                _condicionesFiscales.Clear();
            _condicionesFiscales = PersonasMetodos.ConsultarCondicionesFiscales();
            if (_condicionesFiscales == null)
            {
                comboFiscal.Text = "Sin Cond. Fiscal";
                comboFiscal.Enabled = false;
            }
            else
            {
                comboFiscal.DataSource = _condicionesFiscales;
                int? idFiscal = (from condicion in _condicionesFiscales
                                 where condicion.IdCondicionFiscal != null && condicion.DetalleFiscal != null
                                 && condicion.DetalleFiscal.Contains("Consumidor")
                                 select condicion.IdCondicionFiscal).FirstOrDefault();
                comboFiscal.SelectedValue = idFiscal;
                if ((int)comboFiscal.SelectedValue != 0)
                    _condicionFiscal = (CondicionesFiscales)comboFiscal.SelectedItem;
                else
                {
                    _condicionFiscal = new CondicionesFiscales();
                    _condicionFiscal.IdCondicionFiscal = 0;
                    _condicionFiscal.DetalleFiscal = "Ninguna";

                }
            }
        }

        private void ComboEstadosAlta()
        {
            if (_estados != null)
                _estados.Clear();
            _estados = PersonasMetodos.EstadosPorIndole("Personas");
            if (_estados != null && _estados.Count > 0)
            {
                bindingSourceEstados.DataSource = _estados;
                Estados? alta = new Estados();
                alta = (from estado in _estados
                        where estado.Estado != null && estado.Estado.Contains("Alta")
                        select estado).FirstOrDefault();
                _estado = alta;
                if (alta != null)
                {
                    comboEstado.SelectedItem = alta;
                    _estado = alta;
                }  
                else
                {
                    _estado = new();
                    _estado.IdEstado = 0;
                    _estado.Indole = "Personas";
                    _estado.Estado = "Nueva";
                }

                comboEstado.Enabled = false;


            }
            else
            {
                comboEstado.Text = "Sin Estados";
                comboEstado.Enabled = false;
            }
        }

        private void HabilitarControlesPersona(bool habilitar)
        {
            comboFiscal.Enabled = habilitar;
            comboEstado.Enabled = habilitar;
            dateNacimiento.Enabled = habilitar;
            txtDni.Enabled = habilitar;
            txtPosCuil.Enabled = habilitar;
            txtPreCuil.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtObservaciones.Enabled = habilitar;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Inserciones
        private string InsertarDomicilio(int nro)
        {
            string mensaje = "\nDomicilio " + nro + ": ";
            int resultado = 0;

            if (_domicilio == null)
            {
                mensaje = "No se registró ninguno";
            }
            else
            {
                resultado = DomiciliosMetodos.InsertDomicilio(_domicilio);
                if (resultado == 0)
                    mensaje += "Error, no se pudo registrar";
                mensaje += "Registrado correctamente con el ID " + resultado;
            }
            return mensaje;
        }

        private string InsertarContacto(int nro)
        {
            string mensaje = "\nContacto " + nro + ": ";
            if (_contacto == null)
            {
                mensaje = "No se registró ninguno";
                return mensaje;
            }

            int resultado = 0;
            if (_contacto.IdUserRedSocial != null)
                _contacto.UsersRedesSociales = null;
            if (_contacto.UsersRedesSociales != null)
            {
                _contacto.UsersRedesSociales.RedesSociales = null;
            }

            resultado = ContactosMetodos.InsertContacto(_contacto);
            if (resultado == 0)
                mensaje += "Error, no se pudo registrar";
            else
                mensaje += "\nRegistrado correctamente con el ID " + resultado;

            return mensaje;
        }

        private bool InsertarPersona(ref string mensaje)
        {
            bool exito = false;
            mensaje += "\nPersona: ";
            if (_persona == null)
            {
                mensaje += "\nError: No se puede insertar una persona vacía";
                return false;
            }
            if (_condicionFiscal == null || _estado == null)
            {
                mensaje += "\nError: Debe Ingresarse un Estado y Condicion Fiscal";
                return false;
            }
            int? resultado = 0;
            resultado = PersonasMetodos.InsertarPersona(_persona);
            if (resultado < 1)
            {
                if (resultado == 0)
                    mensaje += "\nNo se pudo registrar la persona en la BD";
                else
                    mensaje += "\nLa persona con el dni " + _persona.Dni + " (o que lo contiene) ya existe en la base de datos";
                return false;
            }
            else
            {
                mensaje += "\nSe registro con éxito a la Persona con el id de persona " + resultado;
                _persona.IdPersona = resultado;
                int cliente = 0;
                Clientes? clienteNuevo = new();
                clienteNuevo.IdPersona = (int)resultado;
                cliente = PersonasMetodos.InsertarCliente(clienteNuevo);
                if (cliente < 1)
                    mensaje += "\nError al registrar a la persona como cliente";
                else
                    exito = true;
            }
            return exito;
        }


        private void RecrearObjetos()
        {
            _estado = new();
            _barrio = new();
            _ciudad = new();
            _provincia = new();
            _condicionFiscal = new();
            _redSocial = new();
            _userRedesSociales = new();
            _domicilio = new();
        }

        //Creo métodos para transformar todos los datos escritos en objetos
        private void LLenarCondicionFiscal()
        {
            if (comboFiscal.SelectedIndex != 0)
                _condicionFiscal = (CondicionesFiscales)comboFiscal.SelectedItem;
        }

        private void LlenarEstado()
        {
            if (comboEstado.SelectedIndex != 0)
                _estado = (Estados)comboEstado.SelectedItem;
        }

        private bool LlenarObjetosPersona()
        {
            string txt = "";
            LLenarCondicionFiscal();
            LlenarEstado();
            _persona.Dni = txtDni.Text.ToString().Trim();
            _persona.Nombre = txtNombre.Text.Trim();
            _persona.Apellidos = txtApellido.Text.Trim();
            if (String.IsNullOrWhiteSpace(_persona.Dni) || String.IsNullOrWhiteSpace(_persona.Apellidos) || String.IsNullOrWhiteSpace(_persona.Nombre))
                return false;
            if (dateNacimiento.Value.Date != DateTime.Now.Date)
                _persona.FechaNacimiento = dateNacimiento.Value;
            txt += txtPreCuil.Text.ToString().Trim();
            txt += txtDni.Text.ToString().Trim();
            txt += txtPosCuil.Text.ToString().Trim();

            _persona.Cuil = txt;
            _persona.Observaciones = txtObservaciones.Text.Trim();
            int? id = 0;
            id = _condicionFiscal.IdCondicionFiscal;
            if (id != null)
                _persona.IdCondicionFiscal = (int)id;
            else
                _persona.IdCondicionFiscal = 1;
            id = _estado.IdEstado;
            if (id != null)
                _persona.IdEstado = (int)id;
            else
                _persona.IdEstado = 1;
            return true;
        }

        private bool IdPersonaEnDomicilio(ref string mensaje)
        {
            if (_persona.IdPersona == null)
            {
                mensaje += "La persona no está registrada correctamente";
                return false;
            }
            if (_domicilios == null || _domicilios.Count == 0)
            {
                mensaje += "No hay domicilios a registrar o modificar";
                return false;
            }
            for (int i = 0; i < _domicilios.Count; i++)
            {
                _domicilios[i].IdPersona = _persona.IdPersona;
            }
            return true;
        }

        private bool IdPersonaEnContacto(ref string mensaje)
        {
            /*if (_persona.IdPersona == null)
            {
                mensaje += "La persona no está registrada correctamente";
                return false;
            }*/
            if (_contactos == null || _contactos.Count == 0)
            {
                mensaje += "No hay contactos a registrar o modificar";
                return false;
            }
            for (int i = 0; i < _contactos.Count; i++)
            {
                _contactos[i].IdPersona = _persona.IdPersona;
            }
            return true;
        }

        private bool ModificarPersona(ref string mensaje)
        {
            if (_persona == null)
            {
                mensaje += "No hay cliente a modificar";
                return false;
            }

            if (_persona.IdPersona == null)
            {
                mensaje += "La persona no está registrada, utilice la opción nuevo cliente";
                return false;
            }

            return PersonasMetodos.UpdatePersona(_persona);
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


        private void GuardarCliente()
        {
            RecrearObjetos();
            if (!LlenarObjetosPersona())
            {
                MessageBox.Show("Faltan Completar Campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            string mensaje = "";

            if (modo == EnumModoForm.Alta)
            {
                if (ExisteDni())
                {
                    crearLogOperacion("Alta_Cliente", mensaje, false);
                    MessageBox.Show("Ya existe un cliente con el DNI ingresado. Se traerán los datos del mismo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!InsertarPersona(ref mensaje))
                {
                    crearLogOperacion("Alta_Cliente", mensaje, false);
                    MessageBox.Show("Se detectaron los siguientes Errores" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (IdPersonaEnDomicilio(ref mensaje))
                {
                    for (int i = 0; i < _domicilios.Count; i++)
                    {
                        _domicilio = new();
                        _domicilio = _domicilios[i];
                        mensaje += InsertarDomicilio(i + 1);
                    }
                }
                if (IdPersonaEnContacto(ref mensaje))
                {
                    for (int i = 0; i < _contactos.Count; i++)
                    {
                        _contacto = new();
                        _contacto = _contactos[i];
                        mensaje += InsertarContacto(i + 1);
                    }
                }
                crearLogOperacion("Alta_Cliente", mensaje, true);
                
                if (registrarConVenta)
                {
                    volverAVenta();
                } else
                {
                    MessageBox.Show("Registro del cliente exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
                
            }
            else
            {
                if (ModificarPersona(ref mensaje))
                {
                    mensaje = "Datos personales modificados con éxito \n";
                    if (IdPersonaEnDomicilio(ref mensaje))
                    {
                        List<string>? mensajesDomicilios = new();
                        mensajesDomicilios = DomiciliosMetodos.UpdateDomicilios(_domicilios);
                        if (mensajesDomicilios != null && mensajesDomicilios.Count > 0)
                        {
                            foreach (string m in mensajesDomicilios)
                                mensaje += m;
                        }
                    }
                    if (IdPersonaEnContacto(ref mensaje))
                    {
                        List<string>? mensajesContactos = new();
                        mensajesContactos = ContactosMetodos.UpdateContactos(_contactos);
                        if (mensajesContactos != null && mensajesContactos.Count > 0)
                        {
                            foreach (string m in mensajesContactos)
                                mensaje += m;
                        }
                    }
                }
                else
                {
                    crearLogOperacion("Modificacion_Cliente", mensaje, false);
                    MessageBox.Show("Se detectaron los siguientes Errores" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                crearLogOperacion("Modificacion_Cliente", mensaje, true);
                MessageBox.Show("Modificación del cliente exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
        }

        public void volverAVenta ()
        {
            if (_persona == null)
            {
                return;
            }
            Clientes? cliente = PersonasMetodos.BuscarClientes(_persona);
            if (cliente == null)
            {
                return;
            }
            DialogResult res = MessageBox.Show("Cliente registrado ¿Desea agregarlo a la venta?", "Exito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            FrmAdminClientes consulta = Application.OpenForms.OfType<FrmAdminClientes>().FirstOrDefault();
            frmRegistrarVentas frmRegistrarVentas = Application.OpenForms.OfType<frmRegistrarVentas>().FirstOrDefault();
            if (res == DialogResult.Yes)
            {
                if (consulta != null)
                {
                    consulta.Close();
                }
                if (frmRegistrarVentas != null)
                {
                    frmRegistrarVentas.VolverDeBuscarClientes(cliente);
                    this.Close();
                }
            } else
            {
                if (consulta == null)
                {
                    return;
                }
                Personas p = new Personas();
                p.Dni = _persona.Dni;
                consulta._persona = p;
                consulta.modo = EnumModoForm.Venta;
                this.Close();
            }
            return;
        }

        private bool ExisteDni()
        {
            Personas? control = new();
            string dni = "";
            dni = txtDni.Text.Trim();
            if (String.IsNullOrEmpty(dni))
                return false;
            control = PersonasMetodos.PersonaPorDni(dni);
            if (control == null)
                return false;
            else
            {
                _persona = control;
                modo = EnumModoForm.Modificacion;
                List<Contactos>? contactos = new();
                List<Domicilios>? domicilios = new();
                contactos = ContactosMetodos.ContactosPorPersona(_persona);
                domicilios = DomiciliosMetodos.DomiciliosPersona(_persona);
                grillaContactoAlta(contactos, true);
                grillaDomicilioAlta(domicilios, true);

            }
            return true;
        }

        private void BorrarTodo()
        {
            _condicionesFiscales = null;
            _estados = null;
            _persona = null;
            _cliente = null;
            _condicionFiscal = null;
            _estado = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            BorrarTodo();
            Close();
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            FrmPrincipal form = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;//para que el form se abra en el principal como hijo.

            if (form == null)
            {
                form = new FrmPrincipal();
            }


            FormContactos frm = new FormContactos();
            if (_contactos != null && _contactos.Count > 0)
            {
                frm._contactos = _contactos;
                frm.modo = EnumModoForm.Modificacion;
            }
            frm.MdiParent = form;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnDomicilio_Click(object sender, EventArgs e)
        {
            FrmPrincipal form = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;//para que el form se abra en el principal como hijo.

            if (form == null)
            {
                form = new FrmPrincipal();
            }

            FormDomicilios frm = new FormDomicilios();
            if (_domicilios != null && _domicilios.Count > 0)
            {
                frm._domicilios = _domicilios;
                frm.modo = EnumModoForm.Modificacion;
            }
            else
            {
                frm.modo = EnumModoForm.Alta;
            }
            frm.MdiParent = form;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (btnRegistrar.Text == "Buscar")
            {
                if (ExisteDni())
                    InicioModificacion();
                else
                    MessageBox.Show("No existe un cliente con el Dni ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GuardarCliente();
                BorrarTodo();
                Close();
            }

        }

        private void txtDni_Leave(object sender, EventArgs e)
        {
            if (ExisteDni())
            {
                MessageBox.Show("Ya existe un cliente con el DNI ingresado. Se traerán los datos del mismo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmEditClientes_Load(sender, e);
                return;
            }

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            txtDniCuil.Text = txtDni.Text;
        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_estados == null || _estados.Count == 0)
            {
                return;
            }
            _estado = (Estados)comboEstado.SelectedItem;
            if (_estado == null)
            {
                return;
            }
            if (_persona == null)
            {
                return;
            }
            _persona.IdEstado = (int)_estado.IdEstado;
            if (_estado.Estado != "Con Observaciones")
            {
                txtObservaciones.Text = "";
                txtObservaciones.Enabled = false;
            }
            else
            {
                txtObservaciones.Enabled = true;
            }
            if (_estado.Estado == "Baja")
            {
                txtObservaciones.Text = "Fecha de Baja: " + DateTime.Now.ToString();
                txtObservaciones.Enabled = false;
            }
        }
    }
}
