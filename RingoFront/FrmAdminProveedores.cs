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
    public partial class FrmAdminProveedores : Form
    {
        public EnumModoForm modo;
        List<string>? credenciales = new();

        private List<ProveedorConsulta>? _proveedorConsultas = null;
        private List<Proveedores>? _proveedores = null;
        private List<Contactos>? _contactos = null;
        public Proveedores? _proveedor = null;
        public ProveedorConsulta? _proveedorConsulta = null;

        public FrmAdminProveedores()
        {
            InitializeComponent();
        }

        private void AdminProveedores_Load(object sender, EventArgs e)
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

        //Activar btn Edit y guardar prov seleccionado
        private void activarEdicion()
        {
            try
            {
                _proveedorConsulta = (ProveedorConsulta)bindingProveedoresCons.Current;
            }
            catch (Exception)
            {
                _proveedorConsulta = null;
            }
            btnEditar.Enabled = _proveedorConsulta != null;
            txtDetalles.Text = btnEditar.Enabled ? (_proveedorConsulta.detalles ?? "") : "";
        }

        //-----Métodoos de Búsqueda-----//
        //Buscar Contactos
        private void buscarContactos()
        {
            bindingContactos.Clear();
            if (_proveedor == null)
            {
                return;
            }
            _contactos = null;
            _contactos = ProveedoresNegocio.ContactosPorProveedor(_proveedor);
            cargarGrillaContactos();
        }

        //Cargar grilla contactos
        private void cargarGrillaContactos()
        {
            if (_contactos == null)
            {
                return;
            }
            bindingContactos.DataSource = _contactos;
            dataGridContactos.Refresh();
        }

        //Cargar grilla de proveedores
        private void cargarGrillaProveedores()
        {
            if (_proveedorConsultas == null)
            {
                return;
            }
            bindingProveedoresCons.DataSource = _proveedorConsultas;
            dataGridProveedores.Refresh();
        }

        //Buscar proveedores validador
        private bool buscarProveedores(ref string mensaje)
        {
            //faltó check de buscar proveedores dados de baja
            bool baja = false;
            List<string>? datosProveedor = listarPalabras(txtRazonSocial.Text);
            List<string>? datosPrenda = listarPalabras(txtPrenda.Text);

            _proveedores = null;
            _proveedorConsulta = null;
            _proveedor = null;
            //método de busqueda
            _proveedores = ProveedoresNegocio.ConsultarProveedores(datosProveedor, datosPrenda, baja, ref mensaje);
            if (_proveedores == null)
            {
                return false;
            }
            if (!transformarListaProveedores())
            {
                mensaje = "Error al transformar proveedores en listado";
                return false;
            }

            return true;
        }

        //Tranformar lista para grilla
        private bool transformarListaProveedores()
        {
            _proveedorConsultas = new();
            if (_proveedores.Count == 0)
            {
                return false;
            }
            bool exito = true;
            foreach (Proveedores p in _proveedores)
            {
                if (p.Empresas == null)
                {
                    exito = false;
                }
                ProveedorConsulta nuevo = new(p, p.Empresas?.Domicilios);
                _proveedorConsultas.Add(nuevo);
            }
            return exito;
        }

        // Listar palabras para búsqueda
        private List<string>? listarPalabras(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
            {
                return null;
            }

            List<string> list = palabra.Split(' ').ToList();
            return list;
        }

        //-----Botones-----//
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bindingProveedoresCons.Clear();
            string mensaje = string.Empty;
            if (!buscarProveedores(ref mensaje))
            {
                MessageBox.Show("Error: \n" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cargarGrillaProveedores();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _proveedorConsulta = (ProveedorConsulta)bindingProveedoresCons.Current;
            if (_proveedores == null)
            {
                return;
            }
            if (_proveedorConsulta == null)
            { return; }
            _proveedor = _proveedores.FirstOrDefault(p => p.IdProveedor == _proveedorConsulta.idProveedor);
            if (_proveedor == null)
            {
                return;
            }
            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (padre == null)
            {
                padre = new FrmPrincipal();
            }
            FrmRegistrarProveedor abierto = Application.OpenForms.OfType<FrmRegistrarProveedor>().FirstOrDefault();
            if (abierto != null)
            {
                abierto.Close();
            }

            
            FrmRegistrarProveedor frmRegistrarProveedor = new FrmRegistrarProveedor();
            frmRegistrarProveedor.modo = EnumModoForm.Modificacion;
            frmRegistrarProveedor._proveedor = _proveedor;
            frmRegistrarProveedor.MdiParent = padre;
            frmRegistrarProveedor.Dock = DockStyle.Fill;
            
            frmRegistrarProveedor.Show();
        }

        private void bindingProveedoresCons_CurrentItemChanged(object sender, EventArgs e)
        {
            _proveedorConsulta = (ProveedorConsulta)bindingProveedoresCons.Current;
            if (_proveedores == null)
            {
                return;
            }
            if(_proveedorConsulta == null)
            {  return; }
            _proveedor = _proveedores.FirstOrDefault(p => p.IdProveedor == _proveedorConsulta.idProveedor);
            if (_proveedor == null)
            {
                return;
            }
            buscarContactos();
            txtDetalles.Text = _proveedor.DetalleProveedor ?? "";
        }
    }
}
