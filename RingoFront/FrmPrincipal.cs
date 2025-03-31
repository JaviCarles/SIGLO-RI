using Microsoft.Identity.Client;
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
using static RingoFront.DiseñoUI;

namespace RingoFront
{
    public partial class FrmPrincipal : Form
    {
        string temaGuardado = Properties.Settings.Default.TemaSeleccionado;

        public FrmPrincipal()
        {
            InitializeComponent();

        }

        //Sobrecarga para ajustar la imagen de fondo
        protected override void OnLoad(EventArgs e)
        {
            DiseñoUI.temaSeleccionado(temaGuardado);
            base.OnLoad(e);
            DiseñoUI.diseñoFront(this);


            comboTemas.ComboBox.DataSource = Enum.GetValues(typeof(TemaAplicacion));
            comboTemas.SelectedItem = (TemaAplicacion)Enum.Parse(typeof(TemaAplicacion), temaGuardado);




            /*  foreach (Control ctl in this.Controls)
              {
                  if (ctl is MdiClient)
                  {
                      // Obtengo el tamaño de la pantalla del cliente
                      var screenSize = Screen.PrimaryScreen.Bounds.Size;

                      // Redimensiono la imagen de fondo
                      Image backgroundImage = Properties.Resources.Logo_Ringo_11;
                      backgroundImage = new Bitmap(backgroundImage, screenSize);

                      ctl.BackgroundImage = backgroundImage;
                      ctl.BackgroundImageLayout = ImageLayout.Zoom; // Ajusto al contenedor
                      break;
                  }
              }*/
        }


        private void cmbTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtén el tema seleccionado
            TemaAplicacion temaSeleccionado = (TemaAplicacion)comboTemas.SelectedItem;



            // Guarda el tema seleccionado en las configuraciones de la aplicación
            Properties.Settings.Default.TemaSeleccionado = temaSeleccionado.ToString();
            Properties.Settings.Default.Save();

        }
        public void registrarPrenda(EnumModoForm modo)
        {
            Form myForm = Application.OpenForms["FrmRegistrarPrenda"] as Form;

            if (myForm == null) // El formulario no está abierto
            {
                FrmRegistrarPrenda frmRegistrarPrenda = new FrmRegistrarPrenda();
                frmRegistrarPrenda.modoPrenda = modo;
                frmRegistrarPrenda.MdiParent = this;
                frmRegistrarPrenda.Show();
            }
            else if (((FrmRegistrarPrenda)myForm).modoPrenda == EnumModoForm.Alta)
            {
                myForm.Focus();
            }
            else if (((FrmRegistrarPrenda)myForm).modoPrenda == EnumModoForm.Modificacion)
            {
                myForm.Focus();
            }
        }

        public void consultarPrenda(EnumModoForm modo)
        {
            Form myForm = Application.OpenForms["FrmAdminPrendas"] as Form;

            if (myForm == null) // El formulario no está abierto
            {
                FrmAdminPrendas frmAdminPrendas = new FrmAdminPrendas();
                frmAdminPrendas.modo = modo;
                frmAdminPrendas.MdiParent = this;
                frmAdminPrendas.Dock = DockStyle.Fill;
                frmAdminPrendas.Show();
            }
            else if (((FrmAdminPrendas)myForm).modo == modo)
            {
                myForm.Focus();
            }
            else
            {
                myForm.Close();
                FrmAdminPrendas frmAdminPrendas = new FrmAdminPrendas();
                frmAdminPrendas.modo = modo;
                frmAdminPrendas.MdiParent = this;
                frmAdminPrendas.Dock = DockStyle.Fill;
                frmAdminPrendas.Show();
            }

        }

        public void consultarPrendaParaVentas()
        {

            FrmAdminPrendas frmAdminPrendas = new FrmAdminPrendas();
            frmAdminPrendas.MdiParent = this;
            frmAdminPrendas.Dock = DockStyle.Fill;
            frmAdminPrendas.modo = EnumModoForm.Venta;
            frmAdminPrendas.Show();
        }

        public void registrarCliente()
        {
            FrmEditClientes frmEditClientes = new FrmEditClientes();
            frmEditClientes.MdiParent = this;
            frmEditClientes.Dock = DockStyle.Fill;
            frmEditClientes.modo = EnumModoForm.Alta;
            frmEditClientes.Show();
        }

        public void consultarCliente()
        {
            FrmAdminClientes formHijoExistente = Application.OpenForms.OfType<FrmAdminClientes>().FirstOrDefault();
            if (formHijoExistente != null)
            {
                // El formulario ya está abierto, ciérralo si es necesario
                formHijoExistente.Close();
            }

            // Crea una nueva instancia del formulario hijo
            FrmAdminClientes formHijo = new FrmAdminClientes();
            formHijo.MdiParent = this;
            formHijo.Dock = DockStyle.Fill;
            formHijo.modo = EnumModoForm.Consulta;
            formHijo.StartPosition = FormStartPosition.CenterParent;
            formHijo.Show();
        }

        public void buscarClienteConDatos(Personas? persona, EnumModoForm modo)
        {
            FrmAdminClientes formHijoExistente = Application.OpenForms.OfType<FrmAdminClientes>().FirstOrDefault();
            if (formHijoExistente != null)
            {
                // El formulario ya está abierto, ciérralo si es necesario
                formHijoExistente.Close();
            }

            // Crea una nueva instancia del formulario hijo
            FrmAdminClientes formHijo = new FrmAdminClientes();
            formHijo.MdiParent = this;
            formHijo.Dock = DockStyle.Fill;
            formHijo.modo = modo;
            formHijo._persona = persona;
            formHijo.StartPosition = FormStartPosition.CenterParent;
            formHijo.Show();

        }

        public void modificarCliente()
        {
            FrmEditClientes modificar = new FrmEditClientes();
            modificar.MdiParent = this;
            modificar.Dock = DockStyle.Fill;
            modificar.modo = EnumModoForm.Modificacion;
            modificar._persona = null;
            modificar.Show();
        }

        public void registrarVenta(EnumModoForm modo)
        {
            Form myForm = Application.OpenForms["frmRegistrarVentas"] as Form;

            if (myForm == null) // El formulario no está abierto
            {
                frmRegistrarVentas frmRegistrarVentas = new frmRegistrarVentas();
                frmRegistrarVentas.modo = modo;
                frmRegistrarVentas.MdiParent = this;
                frmRegistrarVentas.Dock = DockStyle.Fill;
                frmRegistrarVentas.Show();
            }
            else if (((frmRegistrarVentas)myForm).modo == EnumModoForm.Alta)
            {
                myForm.Focus();
            }

        }

        public void consultarVenta(EnumModoForm modo)
        {
            Form myForm = Application.OpenForms["frmAdminVentas"] as Form;

            if (myForm == null) // El formulario no está abierto
            {
                FrmAdminVentas frmAdminVentas = new FrmAdminVentas();
                frmAdminVentas.modo = modo;
                frmAdminVentas.MdiParent = this;
                frmAdminVentas.Dock = DockStyle.Fill;
                frmAdminVentas.Show();
            }
            else if (((FrmAdminVentas)myForm).modo == EnumModoForm.Consulta)
            {
                myForm.Focus();
            }

        }

        public void registrarProveedor()
        {
            FrmRegistrarProveedor frmRegistrarProveedor = new FrmRegistrarProveedor();
            frmRegistrarProveedor.MdiParent = this;
            frmRegistrarProveedor.Dock = DockStyle.Fill;
            frmRegistrarProveedor.modo = EnumModoForm.Alta;
            frmRegistrarProveedor.Show();
        }

        public void modificarProveedor()
        {
            FrmRegistrarProveedor frmRegistrarProveedor = new FrmRegistrarProveedor();
            frmRegistrarProveedor.MdiParent = this;
            frmRegistrarProveedor.Dock = DockStyle.Fill;
            frmRegistrarProveedor.modo = EnumModoForm.Modificacion;
            frmRegistrarProveedor.Show();
        }

        public void consultarProveedor()
        {
            FrmAdminProveedores frmConsultarProveedor = new FrmAdminProveedores();
            frmConsultarProveedor.MdiParent = this;
            frmConsultarProveedor.Dock = DockStyle.Fill;
            frmConsultarProveedor.modo = EnumModoForm.Consulta;
            frmConsultarProveedor.Show();
        }


        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            registrarPrenda(EnumModoForm.Alta);
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            consultarCliente();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            registrarCliente();
        }

        public void abrirEditClientesConParametros(object sender, EventArgs e, Personas p, Clientes c, EnumModoForm modo)
        {
            FrmEditClientes frmEditClientes = new FrmEditClientes();
            frmEditClientes.MdiParent = this;
            frmEditClientes.Dock = DockStyle.Fill;
            frmEditClientes._persona = p;
            frmEditClientes._cliente = c;
            frmEditClientes.modo = modo;
            frmEditClientes.Show();
        }

        public void abrirEditContactosConParametros(object sender, EventArgs e, EnumModoForm modo)
        {
            FormContactos frmContactos = new FormContactos();
            frmContactos.MdiParent = this;
            frmContactos.Dock = DockStyle.Fill;
            frmContactos.modo = modo;
            frmContactos.Show();
        }

        public void crearFactura()
        {
            Form myForm = Application.OpenForms["FrmFacturacion"] as Form;

            if (myForm == null) // El formulario no está abierto
            {
                FrmFacturacion frmFactura = new FrmFacturacion();
                frmFactura.MdiParent = this;
                frmFactura.Dock = DockStyle.Fill;
                //frmFactura.modo = modo;
                frmFactura.Show();
            }
            else //if (((FrmFacturacion)myForm).modo == EnumModoForm.Consulta)
            {
                myForm.Focus();
            }


        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultarPrenda(EnumModoForm.Consulta);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificarCliente();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registrarVenta(EnumModoForm.Alta);
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)//Consultar venta.
        {
            consultarVenta(EnumModoForm.Consulta);
        }

        private void btnPrendas_Click(object sender, EventArgs e)
        {
            if (panelBotonesPrendas.Visible == false)
            {
                panelBotonesPrendas.Visible = true;
            }
            else
            {
                panelBotonesPrendas.Visible = false;
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (panelBotonesClientes.Visible == false)
            {
                panelBotonesClientes.Visible = true;
            }
            else
            {
                panelBotonesClientes.Visible = false;
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (!panelBotonesVentas.Visible)
            {
                panelBotonesVentas.Visible = true;
            }
            else
            {
                panelBotonesVentas.Visible = false;
            }
        }

        private void btnAgregrarPrenda_Click(object sender, EventArgs e)
        {
            registrarPrenda(EnumModoForm.Alta);
        }

        private void button5_Click(object sender, EventArgs e)//es el boton consultar prenda del menu lateral
        {
            consultarPrenda(EnumModoForm.Consulta);
        }

        private void btnAgregarCientes_Click(object sender, EventArgs e)
        {
            registrarCliente();
        }

        private void btnConsultarClientes_Click(object sender, EventArgs e)
        {
            consultarCliente();
        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            registrarVenta(EnumModoForm.Alta);
        }

        private void btnConsultarVenta_Click(object sender, EventArgs e)
        {
            consultarVenta(EnumModoForm.Consulta);
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            registrarProveedor();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            modificarProveedor();
        }

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (!panelBotonesProveedores.Visible)
            {
                panelBotonesProveedores.Visible = true;
            }
            else
            {
                panelBotonesProveedores.Visible = false;
            }

        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            registrarProveedor();
        }

        private void btnConsultarProveedor_Click(object sender, EventArgs e)
        {
            consultarProveedor();
        }

        private void btnFacturación_Click(object sender, EventArgs e)
        {
            crearFactura();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!panelBotonesReportes.Visible)
            {
                panelBotonesReportes.Visible = true;
            }
            else
            {
                panelBotonesReportes.Visible = false;
            }
        }

        private void btnReportesVentas_Click(object sender, EventArgs e)
        {

            Form myForm = Application.OpenForms["FrmReportesVentas"] as Form;

            if (myForm == null) // El formulario no está abierto
            {
                FrmReportesVentas frmReportes = new FrmReportesVentas();

                frmReportes.MdiParent = this;
                frmReportes.Dock = DockStyle.Fill;
                frmReportes.Show();
            }
            else
            {
                myForm.Focus();
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            Form myForm = Application.OpenForms["FrmCerrarCaja"] as Form;

            if (myForm == null) // El formulario no está abierto
            {
                FrmCerrarCaja frmCerrarCaja = new FrmCerrarCaja();

                frmCerrarCaja.MdiParent = this;
                frmCerrarCaja.Dock = DockStyle.Fill;
                frmCerrarCaja.Show();
            }
            else
            {
                myForm.Focus();
            }
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            Form myForm = Application.OpenForms["FrmAdminFinanzas"] as Form;

            if (myForm == null) // El formulario no está abierto
            {
                FrmAdminFinanzas frmAdminFinanzas = new FrmAdminFinanzas(); 

                frmAdminFinanzas.MdiParent = this;
                frmAdminFinanzas.Dock = DockStyle.Fill;
                frmAdminFinanzas.Show();
            }
            else
            {
                myForm.Focus();
            }
        }
    }
}
