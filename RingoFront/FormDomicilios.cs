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
    public partial class FormDomicilios : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta;
        List<string>? credenciales = new();
        public List<Domicilios>? _domicilios = new List<Domicilios>();
        private List<Ciudades>? _ciudades1 = new();
        private List<Provincias>? _provincias1 = new();
        private List<Barrios>? _barrios1 = new();
        private List<Ciudades>? _ciudades2 = new();
        private List<Provincias>? _provincias2 = new();
        private List<Barrios>? _barrios2 = new();
        private List<Ciudades>? _ciudades3 = new();
        private List<Provincias>? _provincias3 = new();
        private List<Barrios>? _barrios3 = new();
        private Domicilios? _Domicilio1 = new Domicilios();
        private Domicilios? _Domicilio2 = new Domicilios();
        private Domicilios? _Domicilio3 = new Domicilios();
        private bool[] activos = { false, false };
        private int altura = 360;
        private int[] alturasGroup = { 0, 0 };
        //para cargas
        string calle = "";
        string nroCasa = "";
        string piso = "";
        string depto = "";
        string observaciones = "";
        string codPostal = "";
        private Barrios? _barrio = new Barrios();
        private Provincias? _provincia = new Provincias();
        private Ciudades? _ciudad = new Ciudades();

        public FormDomicilios()
        {
            InitializeComponent();
        }

        private void FormDomicilios_Load(object sender, EventArgs e)
        {
            credenciales = LoginUsuario.CredencialesActivas();
            if (!comprobarCredenciales())
            {
                MessageBox.Show("Su usuario no tiene permiso para acceder a esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            visibilizarDomicilios();
            visibilidadControles();
            cargarComboProvincias();
            if (modo == EnumModoForm.Alta)
            {
                cargarComboBarrios(1);
                cargarComboCiudadesAlta(1);
            }
            else
            {
                cargarDomicilios();
            }

            DiseñoUI.diseñoFront(this);
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


        private void cargarDomicilios()
        {
            if (_domicilios == null)
                return;
            if (_domicilios.Count > 0)
            {
                txtCalle1.Text = _domicilios[0].Calle ?? "";
                txtAltura1.Text = _domicilios[0].Altura ?? "";
                txtPiso1.Text = _domicilios[0].Piso ?? "";
                txtDepto1.Text = _domicilios[0].Departamento ?? "";
                txtObservaciones1.Text = _domicilios[0].ObservacionesBarrio ?? "";
                _ciudad = _domicilios[0].IdCiudad != null ? DomiciliosMetodos.CiudadPorDomicilio(_domicilios[0]) : _domicilios[0].Ciudades;
                if (_ciudad != null)
                    comboProvincia1.SelectedValue = _ciudad.IdProvincia;
                cargarComboCiudadesAlta(1);
                cargarComboBarrios(1);
            }
            if (_domicilios.Count > 1)
            {
                txtCalle2.Text = _domicilios[1].Calle ?? "";
                txtAltura2.Text = _domicilios[1].Altura ?? "";
                txtPiso2.Text = _domicilios[1].Piso ?? "";
                txtDepto2.Text = _domicilios[1].Departamento ?? "";
                txtObservaciones2.Text = _domicilios[1].ObservacionesBarrio ?? "";
                _ciudad = _domicilios[1].IdCiudad != null ? DomiciliosMetodos.CiudadPorDomicilio(_domicilios[1]) : _domicilios[1].Ciudades;
                if (_ciudad != null)
                    comboProvincia2.SelectedValue = _ciudad.IdProvincia;
                cargarComboCiudadesAlta(2);
                cargarComboBarrios(2);
            }
            if (_domicilios.Count > 2)
            {
                txtCalle3.Text = _domicilios[2].Calle ?? "";
                txtAltura3.Text = _domicilios[2].Altura ?? "";
                txtPiso3.Text = _domicilios[2].Piso ?? "";
                txtDepto3.Text = _domicilios[2].Departamento ?? "";
                txtObservaciones3.Text = _domicilios[2].ObservacionesBarrio ?? "";
                _ciudad = _domicilios[2].IdCiudad != null ? DomiciliosMetodos.CiudadPorDomicilio(_domicilios[2]) : _domicilios[2].Ciudades;
                if (_ciudad != null)
                    comboBoxProvincia3.SelectedValue = _ciudad.IdProvincia;
                cargarComboCiudadesAlta(3);
                cargarComboBarrios(3);
            }
        }

        private void visibilizarDomicilios()
        {
            if (_domicilios != null && _domicilios.Count > 0)
            {
                if (_domicilios.Count > 1)
                    activos[0] = true;
                else
                    activos[0] = false;

                if (_domicilios.Count > 2)
                    activos[1] = true;
                else
                    activos[1] = false;
            }
        }

        private void visibilidadControles()
        {

            groupBoxDomicilio2.Visible = activos[0];
            foreach (Control control in groupBoxDomicilio2.Controls)
            {
                control.Visible = activos[0];
            }
            if (!activos[0])
                btnSumaDomicilios2.Text = "MÁS DOMICILIOS";

            groupBoxDomicilio3.Visible = activos[1];
            foreach (Control control in groupBoxDomicilio3.Controls)
            {
                control.Visible = activos[1];
            }

            ajustarAltura();
        }

        private void cargarComboProvincias()
        {
            _provincias1 = DomiciliosMetodos.ProvinciasTodas();
            _provincias2 = _provincias3 = _provincias1;
            bindingSourceProvincias1.DataSource = _provincias1;
            bindingSourceProvincias2.DataSource = _provincias2;
            bindingSourceProvincias3.DataSource = _provincias3;
            comboProvincia1.SelectedIndex = 0;
            comboProvincia2.SelectedIndex = 0;
            comboBoxProvincia3.SelectedIndex = 0;
        }

        private void cargarComboCiudadesAlta(int nro)
        {
            List<Ciudades>? ciudades = new();
            switch (nro)
            {
                case 1:
                    _provincia = (Provincias)comboProvincia1.SelectedItem;
                    _ciudades1 = new();
                    ciudades = DomiciliosMetodos.CiudadesPorProvincia(_provincia);
                    if (modo == EnumModoForm.Modificacion)
                    {
                        if (_domicilios.Count >= nro)
                        {
                            if (_domicilios[nro - 1].IdCiudad != null)
                                _ciudad = DomiciliosMetodos.CiudadPorDomicilio(_domicilios[nro - 1]);
                            else
                                _ciudad = _domicilios[nro - 1].Ciudades;
                        }

                        if (_ciudad != null)
                            _ciudades1.Add(_ciudad);
                    }
                    if (ciudades != null)
                        _ciudades1.AddRange(ciudades);
                    bindingSourceCiudades1.DataSource = _ciudades1;
                    if (_ciudades1 != null)
                    {
                        _ciudad = (Ciudades)comboCiudad1.SelectedItem;
                        if (_ciudad != null)
                            txtCodPostal1.Text = _ciudad.CodigoPostal?.ToString() ?? "";
                    }
                    break;
                case 2:
                    _provincia = (Provincias)comboProvincia2.SelectedItem;
                    _ciudades2 = new();
                    ciudades = DomiciliosMetodos.CiudadesPorProvincia(_provincia);
                    if (modo == EnumModoForm.Modificacion)
                    {
                        if (_domicilios.Count >= nro)
                        {
                            if (_domicilios[nro - 1].IdCiudad != null)
                                _ciudad = DomiciliosMetodos.CiudadPorDomicilio(_domicilios[nro - 1]);
                            else
                                _ciudad = _domicilios[nro - 1].Ciudades;
                        }
                        if (_ciudad != null)
                            _ciudades2.Add(_ciudad);
                    }
                    if (ciudades != null)
                        _ciudades2.AddRange(ciudades);
                    bindingSourceCiudades2.DataSource = _ciudades2;
                    if (_ciudades2 != null)
                    {
                        _ciudad = (Ciudades)comboCiudad2.SelectedItem;
                        if (_ciudad != null)
                            txtCodPostal2.Text = _ciudad.CodigoPostal?.ToString() ?? "";
                    }
                    _ciudad = new();
                    break;
                case 3:
                    _provincia = (Provincias)comboBoxProvincia3.SelectedItem;
                    _ciudades3 = new();
                    ciudades = DomiciliosMetodos.CiudadesPorProvincia(_provincia);
                    if (modo == EnumModoForm.Modificacion)
                    {
                        if (_domicilios.Count >= nro)
                        {
                            if (_domicilios[nro - 1].IdCiudad != null)
                                _ciudad = DomiciliosMetodos.CiudadPorDomicilio(_domicilios[nro - 1]);
                            else
                                _ciudad = _domicilios[nro - 1].Ciudades;
                        }
                        if (_ciudad != null)
                            _ciudades3.Add(_ciudad);
                    }
                    if (ciudades != null)
                        _ciudades3.AddRange(ciudades);
                    bindingSourceCiudades3.DataSource = _ciudades3;
                    if (_ciudades3 != null)
                    {
                        _ciudad = (Ciudades)comboBoxCiudad3.SelectedItem;
                        if (_ciudad != null)
                            txtCodPostal3.Text = _ciudad.CodigoPostal?.ToString() ?? "";
                    }
                    _ciudad = new();
                    break;
                default:
                    _provincia = (Provincias)comboProvincia1.SelectedItem;
                    _ciudades1 = new();
                    ciudades = DomiciliosMetodos.CiudadesPorProvincia(_provincia);
                    if (modo == EnumModoForm.Modificacion)
                    {
                        if (_domicilios.Count >= nro)
                        {
                            if (_domicilios[nro - 1].IdCiudad != null)
                                _ciudad = DomiciliosMetodos.CiudadPorDomicilio(_domicilios[nro - 1]);
                            else
                                _ciudad = _domicilios[nro - 1].Ciudades;
                        }
                        if (_ciudad != null)
                            _ciudades1.Add(_ciudad);
                    }
                    if (ciudades != null)
                        _ciudades1.AddRange(ciudades);
                    bindingSourceCiudades1.DataSource = _ciudades1;
                    if (_ciudades1 != null)
                    {
                        _ciudad = (Ciudades)comboCiudad1.SelectedItem;
                        txtCodPostal1.Text = _ciudad.CodigoPostal?.ToString() ?? "";
                    }
                    _ciudad = new();
                    break;
            }
        }



        private void cargarComboBarrios(int nro)
        {
            List<Barrios>? barrios = new();
            switch (nro)
            {
                case 1:
                    if (_ciudades1 != null && _ciudades1.Count > 0)
                        _ciudad = (Ciudades)comboCiudad1.SelectedItem;

                    if (_ciudad != null)
                    {
                        barrios = DomiciliosMetodos.BarriosPorCiudad(_ciudad);
                        txtCodPostal1.Text = _ciudad.CodigoPostal?.ToString() ?? "";
                    }
                    _barrios1 = new();
                    if (_domicilios.Count > 0)
                    {
                        Barrios? nuevo = _domicilios[nro - 1].Barrios;
                        if (nuevo != null)
                            _barrios1.Add(nuevo);

                    }
                    if (barrios != null)
                        _barrios1.AddRange(barrios);
                    bindingSourceBarrios1.DataSource = _barrios1;
                    _barrio = new();
                    break;
                case 2:
                    if (_ciudades2 != null && _ciudades2.Count > 0)
                        _ciudad = (Ciudades)comboCiudad2.SelectedItem;

                    if (_ciudad != null)
                    {
                        barrios = DomiciliosMetodos.BarriosPorCiudad(_ciudad);
                        txtCodPostal2.Text = _ciudad.CodigoPostal?.ToString() ?? "";
                    }
                    _barrios2 = new();
                    if (_domicilios.Count > 1)
                    {
                        _barrio = _domicilios[nro - 1].Barrios;
                        if (_barrio != null)
                            _barrios2.Add(_barrio);
                    }
                    if (barrios != null)
                        _barrios2.AddRange(barrios);
                    bindingSourceBarrios2.DataSource = _barrios2;
                    _barrio = new();
                    break;
                case 3:
                    if (_ciudades3 != null && _ciudades3.Count > 0)
                        _ciudad = (Ciudades)comboCiudad1.SelectedItem;

                    if (_ciudad != null)
                    {
                        barrios = DomiciliosMetodos.BarriosPorCiudad(_ciudad);
                        txtCodPostal3.Text = _ciudad.CodigoPostal?.ToString() ?? "";
                    }
                    _barrios3 = new();
                    if (_domicilios.Count > 2)
                    {
                        _barrio = _domicilios[nro - 1].Barrios;
                        if (_barrio != null)
                            _barrios3.Add(_barrio);
                    }
                    if (barrios != null)
                        _barrios3.AddRange(barrios);
                    bindingSourceBarrios3.DataSource = _barrios3;
                    _barrio = new();
                    break;
                default:
                    if (_ciudades1 != null)
                        _ciudad = (from c in _ciudades1 where c.NombreCiudad.Equals(comboCiudad1.Text.Trim()) select c).FirstOrDefault();

                    if (_ciudad != null)
                    {
                        barrios = DomiciliosMetodos.BarriosPorCiudad(_ciudad);
                        txtCodPostal1.Text = _ciudad.CodigoPostal?.ToString() ?? "";
                    }
                    _barrios1 = new();
                    if (_domicilios.Count > 0)
                    {
                        Barrios? nuevo = _domicilios[nro - 1].Barrios;
                        if (nuevo != null)
                            _barrios1.Add(nuevo);

                    }
                    if (barrios != null)
                        _barrios1.AddRange(barrios);
                    bindingSourceBarrios1.DataSource = _barrios1;
                    _barrio = new();
                    break;
            }
        }

        private void ajustarAltura()
        {
            altura = 360;
            for (int i = 0; i < alturasGroup.Length; i++)
            {
                alturasGroup[i] = 0;
            }
            if (groupBoxDomicilio2.Visible)
                alturasGroup[0] = groupBoxDomicilio2.Height;
            if (groupBoxDomicilio3.Visible)
                alturasGroup[1] = groupBoxDomicilio3.Height;

            foreach (int alto in alturasGroup)
            {
                altura += alto + 20;
            }

            this.Height = altura;
        }


        private void limpiarCarga()
        {
            calle = "";
            nroCasa = "";
            piso = "";
            depto = "";
            observaciones = "";
            codPostal = "";
            _barrio = new();
            _ciudad = new();
            _provincia = new();
        }

        private string capitalizar(string palabra)
        {
            string[] resultado = palabra.ToLower().Split(' ');
            for (int i = 0; i < resultado.Length; i++)
            {
                if (!String.IsNullOrEmpty(resultado[i]))
                {
                    resultado[i] = char.ToUpper(resultado[i][0]) + resultado[i].Substring(1);
                }
            }

            return String.Join(' ', resultado);
        }

        private bool guardarDomicilio(ref string mensaje, int nro, Barrios? b, Ciudades? c, Provincias? p)
        {
            Domicilios? domicilio = new Domicilios();
            int cuentaErrores = 0;
            if (!String.IsNullOrWhiteSpace(calle))
                domicilio.Calle = capitalizar(calle);
            else
                cuentaErrores++;
            if (!String.IsNullOrWhiteSpace(nroCasa))
                domicilio.Altura = nroCasa.Trim();
            else
                cuentaErrores++;
            if (!String.IsNullOrWhiteSpace(piso))
                domicilio.Piso = piso.Trim();
            else
                cuentaErrores++;
            if (!String.IsNullOrWhiteSpace(depto))
                domicilio.Departamento = depto.Trim();
            else
                cuentaErrores++;
            if (!String.IsNullOrWhiteSpace(observaciones))
                domicilio.ObservacionesBarrio = capitalizar(observaciones);
            else
                cuentaErrores++;
            if (b != null)
            {
                if (c != null)
                {
                    if (c.IdCiudad != null)
                        b.IdCiudad = (int)c.IdCiudad;
                    else
                        b.IdCiudad = 0;
                }
                if (b.IdBarrio != null)
                    domicilio.IdBarrio = b.IdBarrio;
                domicilio.Barrios = b;

            }
            else
                cuentaErrores++;

            if (c != null)
            {
                if (c.IdCiudad != null)
                {
                    domicilio.IdCiudad = c.IdCiudad;
                }
                if (!String.IsNullOrWhiteSpace(codPostal))
                    c.CodigoPostal = int.Parse(codPostal);
                if (p != null)
                {
                    c.IdProvincia = (int)p.IdProvincia;
                    c.Provincias = p;

                }
                else
                    cuentaErrores++;
                domicilio.Ciudades = c;
            }
            else
                cuentaErrores++;



            if (cuentaErrores < 8)
                _domicilios.Add(domicilio);
            else
            {
                mensaje = "No se puede guardar. El domicilio " + nro + " está totalmente vacío";
                return false;
            }

            return true;
        }

        private bool guardarDatos(ref string Mensaje)
        {
            _domicilios = new();
            if (!guardarDomicilio1(ref Mensaje))
                return false;
            if (!guardarDomicilio2(ref Mensaje))
                return false;
            if (!guardarDomicilio3(ref Mensaje))
                return false;
            return true;
        }

        private bool guardarDomicilio1(ref string mensaje)
        {
            limpiarCarga();
            calle = txtCalle1.Text.Trim();
            nroCasa = txtAltura1.Text.Trim();
            piso = txtPiso1.Text.Trim();
            depto = txtDepto1.Text.Trim();
            codPostal = txtCodPostal1.Text.Trim();
            observaciones = txtObservaciones1.Text.Trim();
            _provincia = (Provincias)comboProvincia1.SelectedItem;

            string texto = comboCiudad1.Text.Trim();
            if (!String.IsNullOrEmpty(texto) && _ciudades1 != null && _ciudades1.Count > 0)
                _ciudad = (from c in _ciudades1 where c.NombreCiudad != null && c.NombreCiudad.ToLower() == texto.ToLower() select c).FirstOrDefault();
            else
                _ciudad = null;
            if (_ciudad == null && !String.IsNullOrWhiteSpace(texto))
            {
                _ciudad = new();
                _ciudad.NombreCiudad = texto;
                if (!String.IsNullOrWhiteSpace(codPostal))
                    _ciudad.CodigoPostal = int.Parse(codPostal);
                _ciudad.IdCiudad = null;
                _ciudad.IdProvincia = (int)_provincia.IdProvincia;
            }

            texto = comboBarrio1.Text.Trim();
            if (!String.IsNullOrEmpty(texto) && _barrios1 != null && _barrios1.Count > 0)
                _barrio = (from barrio in _barrios1 where barrio.NombreBarrio != null && barrio.NombreBarrio.ToLower() == texto.ToLower() select barrio).FirstOrDefault();
            else
                _barrio = null;

            if (_barrio == null && !String.IsNullOrWhiteSpace(texto))
            {
                _barrio = new();
                _barrio.NombreBarrio = texto;
                _barrio.IdBarrio = null;
            }

            if (_barrio != null)
            {
                if (_ciudad != null)
                {
                    if (_ciudad.IdCiudad != null)
                        _barrio.IdCiudad = (int)_ciudad.IdCiudad;
                    else
                        _barrio.IdCiudad = 0;
                }
                else
                {
                    _provincia = null;
                    _barrio = null;
                    mensaje += "\nNo se puede ingresar un barrio sin Ciudad!";
                    mensaje += "\nSin ciudad tampoco se registra una provincia";
                }
            }
            else
            {
                if (_ciudad == null)
                {
                    _provincia = null;
                    mensaje += "\n No se registra Provincia sin Ciudad";
                }
            }
            return guardarDomicilio(ref mensaje, 1, _barrio, _ciudad, _provincia);
        }

        private bool guardarDomicilio2(ref string mensaje)
        {
            if (!txtCalle2.Visible)
                return true;
            limpiarCarga();
            calle = txtCalle2.Text.Trim();
            nroCasa = txtAltura2.Text.Trim();
            piso = txtPiso2.Text.Trim();
            depto = txtDepto2.Text.Trim();
            observaciones = txtObservaciones2.Text.Trim();
            codPostal = txtCodPostal2.Text.Trim();
            _provincia = (Provincias)comboProvincia2.SelectedItem;

            string texto = comboCiudad2.Text.Trim();
            if (!String.IsNullOrEmpty(texto) && _ciudades2 != null && _ciudades2.Count > 0)
                _ciudad = comboCiudad2.Items.Cast<Ciudades>().FirstOrDefault(c => c.NombreCiudad != null && c.NombreCiudad.Equals(texto));
            else
                _ciudad = null;
            if (_ciudad == null && !String.IsNullOrWhiteSpace(texto))
            {
                _ciudad = new();
                _ciudad.NombreCiudad = texto;
                if (!String.IsNullOrWhiteSpace(codPostal))
                    _ciudad.CodigoPostal = int.Parse(codPostal);
                _ciudad.IdCiudad = null;
                _ciudad.IdProvincia = (int)_provincia.IdProvincia;
            }

            texto = comboBarrio2.Text.Trim();
            if (!String.IsNullOrEmpty(texto) && _barrios2 != null && _barrios2.Count > 0)
                _barrio = (from barrio in _barrios2 where barrio.NombreBarrio != null && barrio.NombreBarrio.ToLower() == texto.ToLower() select barrio).FirstOrDefault();
            else
                _barrio = null;

            if (_barrio == null && !String.IsNullOrWhiteSpace(texto))
            {
                _barrio = new();
                _barrio.NombreBarrio = texto;
                _barrio.IdBarrio = null;
            }

            if (_barrio != null)
            {
                if (_ciudad != null)
                {
                    if (_ciudad.IdCiudad != null)
                        _barrio.IdCiudad = (int)_ciudad.IdCiudad;
                    else
                        _barrio.IdCiudad = 0;
                }
                else
                {
                    _provincia = null;
                    _barrio = null;
                    mensaje += "\nNo se puede ingresar un barrio sin Ciudad!";
                    mensaje += "\nSin ciudad tampoco se registra una provincia";
                }
            }
            else
            {
                if (_ciudad == null)
                {
                    _provincia = null;
                    mensaje += "\n No se registra Provincia sin Ciudad";
                }
            }
            return guardarDomicilio(ref mensaje, 2, _barrio, _ciudad, _provincia);
        }

        private bool guardarDomicilio3(ref string mensaje)
        {
            if (!txtCalle3.Visible)
                return true;
            limpiarCarga();
            calle = txtCalle3.Text.Trim();
            nroCasa = txtAltura3.Text.Trim();
            piso = txtPiso3.Text.Trim();
            depto = txtDepto3.Text.Trim();
            observaciones = txtObservaciones3.Text.Trim();
            codPostal = txtCodPostal3.Text.Trim();
            _provincia = (Provincias)comboBoxProvincia3.SelectedItem;

            string texto = comboBoxCiudad3.Text.Trim();
            if (!String.IsNullOrEmpty(texto) && _ciudades3 != null && _ciudades3.Count > 0)
                _ciudad = comboBoxCiudad3.Items.Cast<Ciudades>().FirstOrDefault(c => c.NombreCiudad != null && c.NombreCiudad.Equals(texto));
            else
                _ciudad = null;
            if (_ciudad == null && !String.IsNullOrWhiteSpace(texto))
            {
                _ciudad = new();
                _ciudad.NombreCiudad = texto;
                if (!String.IsNullOrWhiteSpace(codPostal))
                    _ciudad.CodigoPostal = int.Parse(codPostal);
                _ciudad.IdCiudad = null;
                _ciudad.IdProvincia = (int)_provincia.IdProvincia;
            }

            texto = comboBoxBarrio3.Text.Trim();
            if (!String.IsNullOrEmpty(texto) && _barrios3 != null && _barrios3.Count > 0)
                _barrio = (from barrio in _barrios3 where barrio.NombreBarrio != null && barrio.NombreBarrio.ToLower() == texto.ToLower() select barrio).FirstOrDefault();
            else
                _barrio = null;

            if (_barrio == null && !String.IsNullOrWhiteSpace(texto))
            {
                _barrio = new();
                _barrio.NombreBarrio = texto;
                _barrio.IdBarrio = null;
            }

            if (_barrio != null)
            {
                if (_ciudad != null)
                {
                    if (_ciudad.IdCiudad != null)
                        _barrio.IdCiudad = (int)_ciudad.IdCiudad;
                    else
                        _barrio.IdCiudad = 0;
                }
                else
                {
                    _provincia = null;
                    _barrio = null;
                    mensaje += "\nNo se puede ingresar un barrio sin Ciudad!";
                    mensaje += "\nSin ciudad tampoco se registra una provincia";
                }
            }
            else
            {
                if (_ciudad == null)
                {
                    _provincia = null;
                    mensaje += "\n No se registra Provincia sin Ciudad";
                }
            }
            return guardarDomicilio(ref mensaje, 3, _barrio, _ciudad, _provincia);
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            string Mensaje = "";
            if (guardarDatos(ref Mensaje))
            {
                FrmEditClientes frm = Application.OpenForms.OfType<FrmEditClientes>().FirstOrDefault();
                frm.grillaDomicilioAlta(_domicilios, true);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Ocurrieron los siguientes errores" + Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSumaDomicilios1_Click(object sender, EventArgs e)
        {
            string textoBoton = btnSumaDomicilios1.Text;
            if (textoBoton == "MÁS DOMICILIOS")
            {
                btnSumaDomicilios1.Text = "QUITAR SIGUIENTE";
                activos[0] = true;
                btnSumaDomicilios2.Text = "MÁS DOMICILIOS";
                cargarComboBarrios(2);
                cargarComboCiudadesAlta(2);
            }
            else
            {
                btnSumaDomicilios1.Text = "MÁS DOMICILIOS";
                btnSumaDomicilios2.Text = "MÁS DOMICILIOS";
                activos[0] = false;
            }
            visibilidadControles();
        }

        private void btnSumaDomicilios2_Click(object sender, EventArgs e)
        {
            string textoBoton = btnSumaDomicilios2.Text;
            if (textoBoton == "MÁS DOMICILIOS")
            {
                btnSumaDomicilios2.Text = "QUITAR SIGUIENTE";
                btnSumaDomicilios1.Text = "MÁS DOMICILIOS";
                btnSumaDomicilios1.Enabled = false;
                activos[1] = true;
                cargarComboBarrios(3);
                cargarComboCiudadesAlta(3);
            }
            else
            {
                btnSumaDomicilios2.Text = "MÁS DOMICILIOS";
                btnSumaDomicilios1.Text = "QUITAR SIGUIENTE";
                btnSumaDomicilios1.Enabled = true;
                activos[1] = false;
            }
            visibilidadControles();
        }

        private void comboProvincia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboCiudadesAlta(1);
            cargarComboBarrios(1);
        }

        private void comboProvincia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboCiudadesAlta(2);
            cargarComboBarrios(2);
        }

        private void comboBoxProvincia3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboCiudadesAlta(3);
            cargarComboBarrios(3);
        }

        private void comboCiudad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboBarrios(1);
        }

        private void comboCiudad2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboBarrios(2);
        }

        private void comboBoxCiudad3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboBarrios(3);
        }
    }
}
