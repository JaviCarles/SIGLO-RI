using RingoEntidades;
using RingoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RingoFront
{
    public partial class FormContactos : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta;
        public List<Contactos>? _contactos = new List<Contactos>();
        private List<RedesSociales>? _redesSociales = new();
        List<string>? rs = new List<string>();
        List<string>? credenciales = new();
        private Contactos? _contacto = new Contactos();
        private RedesSociales? _redSocial = new RedesSociales();
        private UsersRedesSociales? _userRedSocial = new UsersRedesSociales();
        private bool[] activos = { false, false, false, false, false };
        private int altura = 300;
        private int[] alturasGroup = { 0, 0, 0, 0, 0 };
        //para cargas
        bool fijo = false;
        string area = "";
        string telefono = "";
        string correo = "";
        string usuarioRs = "";
        int idRedSocial = 1;

        public FormContactos()
        {
            InitializeComponent();
        }

        private void FormContactos_Load(object sender, EventArgs e)
        {

            credenciales = LoginUsuario.CredencialesActivas();
            if (!comprobarCredenciales())
            {
                MessageBox.Show("Su usuario no tiene permiso para acceder a esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            cargarComboRedesSociales();
            if (modo == EnumModoForm.Alta)
                visibilidadControles();
            else
            {
                visibilidadContactosModificacion();
                visibilidadControles();
                cargarContactos();
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

        private void cargarContactos()
        {
            if (_contactos == null)
                return;
            if (_contactos.Count > 0)
            {
                checkFijo1.Checked = _contactos[0].esFijo == null ? false : (bool)_contactos[0].esFijo;
                string cArea = _contactos[0].codArea == null ? "" : _contactos[0].codArea;
                if (!String.IsNullOrWhiteSpace(cArea))
                    cArea = checkFijo1.Checked ? cArea.Substring(1) : cArea.Substring(3);
                txtAreaTelefono1.Text = cArea;
                txtNroTelefono1.Text = _contactos[0].Telefono == null ? "" : _contactos[0].Telefono;
                txtCorreo1.Text = _contactos[0].Email == null ? "" : _contactos[0].Email;
                txtUserRedSocial1.Text = _contactos[0].UsuarioRedSocial == null ? "" : _contactos[0].UsuarioRedSocial;
                if (!String.IsNullOrWhiteSpace(txtUserRedSocial1.Text))
                {
                    _redSocial = null;
                    _redSocial = comboRedesSociales1.Items.Cast<RedesSociales>().Where(r => 
                                    r.NombreRedSocial.Equals(_contactos[0].NombreRedSocial)).FirstOrDefault();
                    if (_redSocial != null)
                        comboRedesSociales1.SelectedValue = _redSocial.IdRedSocial;
                }
            }

            if (_contactos.Count > 1)
            {
                checkFijo2.Checked = _contactos[1].esFijo == null ? false : (bool)_contactos[1].esFijo;
                string cArea = _contactos[1].codArea == null ? "" : _contactos[1].codArea;
                if (!String.IsNullOrWhiteSpace(cArea))
                    cArea = checkFijo2.Checked ? cArea.Substring(1) : cArea.Substring(3);
                txtAreaTelefono2.Text = cArea;
                txtNroTelefono2.Text = _contactos[1].Telefono == null ? "" : _contactos[1].Telefono;
                txtCorreo2.Text = _contactos[1].Email == null ? "" : _contactos[1].Email;
                txtUserRedSocial2.Text = _contactos[1].UsuarioRedSocial == null ? "" : _contactos[1].UsuarioRedSocial;
                if (!String.IsNullOrWhiteSpace(txtUserRedSocial2.Text))
                {
                    _redSocial = null;
                    _redSocial = comboRedesSociales2.Items.Cast<RedesSociales>().Where(r =>
                                    r.NombreRedSocial.Equals(_contactos[1].NombreRedSocial)).FirstOrDefault();
                    if (_redSocial != null)
                        comboRedesSociales2.SelectedValue = _redSocial.IdRedSocial;
                }
            }

            if (_contactos.Count > 2)
            {
                checkFijo3.Checked = _contactos[2].esFijo == null ? false : (bool)_contactos[2].esFijo;
                string cArea = _contactos[2].codArea == null ? "" : _contactos[2].codArea;
                if (!String.IsNullOrWhiteSpace(cArea))
                    cArea = checkFijo3.Checked ? cArea.Substring(1) : cArea.Substring(3);
                txtAreaTelefono3.Text = cArea;
                txtNroTelefono3.Text = _contactos[2].Telefono == null ? "" : _contactos[2].Telefono;
                txtCorreo3.Text = _contactos[2].Email == null ? "" : _contactos[2].Email;
                txtUserRedSocial3.Text = _contactos[2].UsuarioRedSocial == null ? "" : _contactos[2].UsuarioRedSocial;
                if (!String.IsNullOrWhiteSpace(txtUserRedSocial3.Text))
                {
                    _redSocial = null;
                    _redSocial = comboRedesSociales3.Items.Cast<RedesSociales>().Where(r =>
                                    r.NombreRedSocial.Equals(_contactos[2].NombreRedSocial)).FirstOrDefault();
                    if (_redSocial != null)
                        comboRedesSociales3.SelectedValue = _redSocial.IdRedSocial;
                }
            }

            if (_contactos.Count > 3)
            {
                checkFijo4.Checked = _contactos[3].esFijo == null ? false : (bool)_contactos[3].esFijo;
                string cArea = _contactos[3].codArea == null ? "" : _contactos[3].codArea;
                if (!String.IsNullOrWhiteSpace(cArea))
                    cArea = checkFijo4.Checked ? cArea.Substring(1) : cArea.Substring(3);
                txtAreaTelefono4.Text = cArea;
                txtNroTelefono4.Text = _contactos[3].Telefono == null ? "" : _contactos[3].Telefono;
                txtCorreo4.Text = _contactos[3].Email == null ? "" : _contactos[3].Email;
                txtUserRedSocial4.Text = _contactos[3].UsuarioRedSocial == null ? "" : _contactos[3].UsuarioRedSocial;
                if (!String.IsNullOrWhiteSpace(txtUserRedSocial4.Text))
                {
                    _redSocial = null;
                    _redSocial = comboRedesSociales4.Items.Cast<RedesSociales>().Where(r =>
                                    r.NombreRedSocial.Equals(_contactos[3].NombreRedSocial)).FirstOrDefault();
                    if (_redSocial != null)
                        comboRedesSociales4.SelectedValue = _redSocial.IdRedSocial;
                }
            }

            if (_contactos.Count > 4)
            {
                checkFijo5.Checked = _contactos[4].esFijo == null ? false : (bool)_contactos[4].esFijo;
                string cArea = _contactos[4].codArea == null ? "" : _contactos[4].codArea;
                if (!String.IsNullOrWhiteSpace(cArea))
                    cArea = checkFijo5.Checked ? cArea.Substring(1) : cArea.Substring(3);
                txtAreaTelefono5.Text = cArea;
                txtNroTelefono5.Text = _contactos[4].Telefono == null ? "" : _contactos[4].Telefono;
                txtCorreo5.Text = _contactos[4].Email == null ? "" : _contactos[4].Email;
                txtUserRedSocial5.Text = _contactos[4].UsuarioRedSocial == null ? "" : _contactos[4].UsuarioRedSocial;
                if (!String.IsNullOrWhiteSpace(txtUserRedSocial5.Text))
                {
                    _redSocial = comboRedesSociales5.Items.Cast<RedesSociales>().Where(r =>
                                    r.NombreRedSocial.Equals(_contactos[4].NombreRedSocial)).FirstOrDefault();
                    if (_redSocial != null)
                        comboRedesSociales5.SelectedValue = _redSocial.IdRedSocial;
                }
            }

            if (_contactos.Count > 5)
            {
                checkFijo6.Checked = _contactos[5].esFijo == null ? false : (bool)_contactos[5].esFijo;
                string cArea = _contactos[5].codArea == null ? "" : _contactos[5].codArea;
                if (!String.IsNullOrWhiteSpace(cArea))
                    cArea = checkFijo6.Checked ? cArea.Substring(1) : cArea.Substring(3);
                txtAreaTelefono6.Text = cArea;
                txtNroTelefono6.Text = _contactos[5].Telefono == null ? "" : _contactos[5].Telefono;
                txtCorreo6.Text = _contactos[5].Email == null ? "" : _contactos[5].Email;
                txtUserRedSocial6.Text = _contactos[5].UsuarioRedSocial == null ? "" : _contactos[5].UsuarioRedSocial;
                if (!String.IsNullOrWhiteSpace(txtUserRedSocial6.Text))
                {
                    _redSocial = comboRedesSociales6.Items.Cast<RedesSociales>().Where(r =>
                                    r.NombreRedSocial.Equals(_contactos[5].NombreRedSocial)).FirstOrDefault();
                    if (_redSocial != null)
                        comboRedesSociales6.SelectedValue = _redSocial.IdRedSocial;
                }
            }
        }

        private void visibilidadContactosModificacion()
        {
            if (_contactos != null && _contactos.Count > 0)
            {
                int largo = int.Min(_contactos.Count, 6);
                for (int i = 0;  i < largo; i++)
                {
                    activos[i] = false;
                    if (i > 0)
                        activos[i-1] = true;
                }
            } 
        }

        private void visibilidadControles()
        {

            groupBoxContacto2.Visible = activos[0];
            foreach (Control control in groupBoxContacto2.Controls)
            {
                control.Visible = activos[0];
            }
            if (!activos[0])
                btnSumaContactos2.Text = "MÁS CONTACTOS";
            else
            {
                btnSumaContactos1.Text = "QUITAR SIGUIENTE";
            }
                

            groupBoxContacto3.Visible = activos[1];
            foreach (Control control in groupBoxContacto3.Controls)
            {
                control.Visible = activos[1];
            }
            if (!activos[1])
                btnSumaContactos3.Text = "MÁS CONTACTOS";
            else
            {
                btnSumaContactos1.Text = "MÁS CONTACTOS";
                btnSumaContactos1.Enabled = false;
                btnSumaContactos2.Text = "QUITAR SIGUIENTE";
            }

            groupBoxContacto4.Visible = activos[2];
            foreach (Control control in groupBoxContacto4.Controls)
            {
                control.Visible = activos[2];
            }
            if (!activos[2])
                btnSumaContactos4.Text = "MÁS CONTACTOS";
            else
            {
                btnSumaContactos2.Text = "MÁS CONTACTOS";
                btnSumaContactos2.Enabled = false;
                btnSumaContactos3.Text = "QUITAR SIGUIENTE";
            }

            groupBoxContacto5.Visible = activos[3];
            foreach (Control control in groupBoxContacto5.Controls)
            {
                control.Visible = activos[3];
            }
            if (!activos[3])
                btnSumaContactos5.Text = "MÁS CONTACTOS";
            else
            {
                btnSumaContactos3.Text = "MÁS CONTACTOS";
                btnSumaContactos3.Enabled = false;
                btnSumaContactos4.Text = "QUITAR SIGUIENTE";
            }

            groupBoxContacto6.Visible = activos[4];
            foreach (Control control in groupBoxContacto6.Controls)
            {
                control.Visible = activos[4];
            }
            ajustarAltura();
        }

        private void cargarComboRedesSociales()
        {
            List<RedesSociales>? redes = new List<RedesSociales>();
            redes = ContactosMetodos.redesSociales();
            bindingSourceRS1.DataSource = redes;
            bindingSourceRS2.DataSource = redes;
            bindingSourceRS3.DataSource = redes;
            bindingSourceRS4.DataSource = redes;
            bindingSourceRS5.DataSource = redes;
            bindingSourceRS6.DataSource = redes;
        }

        private void ajustarAltura()
        {
            altura = 300;
            for (int i = 0; i < alturasGroup.Length; i++)
            {
                alturasGroup[i] = 0;
            }
            if (groupBoxContacto2.Visible)
                alturasGroup[0] = groupBoxContacto2.Height;
            if (groupBoxContacto3.Visible)
                alturasGroup[1] = groupBoxContacto3.Height;
            if (groupBoxContacto4.Visible)
                alturasGroup[2] = groupBoxContacto4.Height;
            if (groupBoxContacto5.Visible)
                alturasGroup[3] = groupBoxContacto5.Height;
            if (groupBoxContacto6.Visible)
                alturasGroup[4] = groupBoxContacto6.Height;

            foreach (int alto in alturasGroup)
            {
                altura += alto + 20;
            }

            this.Height = altura;
        }


        private void limpiarCarga()
        {
            fijo = false;
            area = "";
            telefono = "";
            correo = "";
            usuarioRs = "";
            idRedSocial = 1;
            _contacto = new();
        }

        private bool guardarContacto (ref string mensaje, int nro)
        {
            Contactos? contacto = new Contactos();
            if (modo == EnumModoForm.Modificacion)
                contacto = _contacto;
            UsersRedesSociales? usuario = new();

            if (!String.IsNullOrWhiteSpace(area))
            {
                area = fijo ? ("0" + area) : ("+54" + area);
            }
            if (!String.IsNullOrWhiteSpace(telefono) && !String.IsNullOrWhiteSpace(area))
            {
                contacto.codArea = area;
                contacto.Telefono = telefono;
            } else if (!String.IsNullOrWhiteSpace(telefono))
            {
                contacto.codArea = fijo ? "03446" : "+543446";
                contacto.Telefono = telefono;
            }
            if (contacto.Telefono != null)
            {
                contacto.esFijo = fijo;
            }

            if (!String.IsNullOrWhiteSpace(correo))
                contacto.Email = correo;
            if (!String.IsNullOrWhiteSpace(usuarioRs))
            {
                usuario.IdRedSocial = idRedSocial;
                usuario.UsuarioRedSocial = usuarioRs;
                usuario.RedesSociales = _redSocial;
                contacto.UsersRedesSociales = usuario;
            } else
            {
                _contacto.IdUserRedSocial = null;
                _contacto.UsersRedesSociales = null;
            }
            if (String.IsNullOrWhiteSpace(telefono) && String.IsNullOrWhiteSpace(correo) && String.IsNullOrWhiteSpace(usuarioRs))
            {
                mensaje += "\nTodos los campos del contacto "+nro+" están vacíos";
                return false;
            }
            _contactos.Add(contacto);

            return true;
        }

        private bool guardarDatos (ref string Mensaje)
        {
            _contactos = new();
            if (!guardarContacto1(ref Mensaje))
                return false;
            if (!guardarContacto2(ref Mensaje))
                return false;
            if (!guardarContacto3(ref Mensaje))
                return false;
            if (!guardarContacto4(ref Mensaje))
                return false;
            if (!guardarContacto5(ref Mensaje))
                return false;
            if (!guardarContacto6(ref Mensaje))
                return false;
            return true;
        }

        private bool guardarContacto1 (ref string mensaje)
        {
            limpiarCarga();
            if (modo == EnumModoForm.Modificacion)
            {
                if (_contactos.Count > 0)
                    _contacto = _contactos[0];
            }
            fijo = checkFijo1.Checked;
            area = txtAreaTelefono1.Text.Trim();
            telefono = txtNroTelefono1.Text.Trim();
            correo = txtCorreo1.Text.Trim();
            usuarioRs = txtUserRedSocial1.Text.Trim();
            _redSocial = (RedesSociales)comboRedesSociales1.SelectedItem;
            return guardarContacto(ref mensaje, 1);
        }

        private bool guardarContacto2(ref string mensaje)
        {
            if (!txtAreaTelefono2.Visible)
                return true;
            limpiarCarga();
            if (modo == EnumModoForm.Modificacion)
            {
                if (_contactos.Count > 1)
                    _contacto = _contactos[1];
            }
            fijo = checkFijo2.Checked;
            area = txtAreaTelefono2.Text.Trim();
            telefono = txtNroTelefono2.Text.Trim();
            correo = txtCorreo2.Text.Trim();
            usuarioRs = txtUserRedSocial2.Text.Trim();
            _redSocial = (RedesSociales)comboRedesSociales2.SelectedItem;
            return guardarContacto(ref mensaje, 2);
        }

        private bool guardarContacto3(ref string mensaje)
        {
            if (!txtAreaTelefono3.Visible)
                return true;
            limpiarCarga();
            if (modo == EnumModoForm.Modificacion)
            {
                if (_contactos.Count > 2)
                    _contacto = _contactos[2];
            }
            fijo = checkFijo3.Checked;
            area = txtAreaTelefono3.Text.Trim();
            telefono = txtNroTelefono3.Text.Trim();
            correo = txtCorreo3.Text.Trim();
            usuarioRs = txtUserRedSocial3.Text.Trim();
            _redSocial = (RedesSociales)comboRedesSociales3.SelectedItem;
            return guardarContacto(ref mensaje, 3);
        }

        private bool guardarContacto4(ref string mensaje)
        {
            if (!txtAreaTelefono4.Visible)
                return true;
            limpiarCarga();
            if (modo == EnumModoForm.Modificacion)
            {
                if (_contactos.Count > 3)
                    _contacto = _contactos[3];
            }
            fijo = checkFijo4.Checked;
            area = txtAreaTelefono4.Text.Trim();
            telefono = txtNroTelefono4.Text.Trim();
            correo = txtCorreo4.Text.Trim();
            usuarioRs = txtUserRedSocial4.Text.Trim();
            _redSocial = (RedesSociales)comboRedesSociales4.SelectedItem;
            return guardarContacto(ref mensaje, 4);
        }

        private bool guardarContacto5(ref string mensaje)
        {
            if (!txtAreaTelefono5.Visible)
                return true;
            limpiarCarga();
            if (modo == EnumModoForm.Modificacion)
            {
                if (_contactos.Count > 4)
                    _contacto = _contactos[4];
            }
            fijo = checkFijo5.Checked;
            area = txtAreaTelefono5.Text.Trim();
            telefono = txtNroTelefono5.Text.Trim();
            correo = txtCorreo5.Text.Trim();
            usuarioRs = txtUserRedSocial5.Text.Trim();
            _redSocial = (RedesSociales)comboRedesSociales5.SelectedItem;
            return guardarContacto(ref mensaje, 5);
        }

        private bool guardarContacto6(ref string mensaje)
        {
            if (!txtAreaTelefono6.Visible)
                return true;
            limpiarCarga();
            if (modo == EnumModoForm.Modificacion)
            {
                if (_contactos.Count > 5)
                    _contacto = _contactos[5];
            }
            fijo = checkFijo6.Checked;
            area = txtAreaTelefono6.Text.Trim();
            telefono = txtNroTelefono6.Text.Trim();
            correo = txtCorreo6.Text.Trim();
            usuarioRs = txtUserRedSocial6.Text.Trim();
            _redSocial = (RedesSociales)comboRedesSociales6.SelectedItem;
            return guardarContacto(ref mensaje, 6);
        }

        private void btnSumaContactos1_Click(object sender, EventArgs e)
        {
            string textoBoton = btnSumaContactos1.Text;
            if (textoBoton == "MÁS CONTACTOS")
            {
                btnSumaContactos1.Text = "QUITAR SIGUIENTE";
                activos[0] = true;
            }
            else
            {
                btnSumaContactos1.Text = "MÁS CONTACTOS";
                btnSumaContactos2.Text = "MÁS CONTACTOS";
                activos[0] = false;
            }
            visibilidadControles();
        }

        private void btnSumaContactos2_Click(object sender, EventArgs e)
        {
            string textoBoton = btnSumaContactos2.Text;
            if (textoBoton == "MÁS CONTACTOS")
            {
                btnSumaContactos2.Text = "QUITAR SIGUIENTE";
                activos[1] = true;
                btnSumaContactos1.Text = "MÁS CONTACTOS";
                btnSumaContactos1.Enabled = false;
            }
            else
            {
                btnSumaContactos2.Text = "MÁS CONTACTOS";
                btnSumaContactos3.Text = "MÁS CONTACTOS";
                activos[1] = false;
                btnSumaContactos1.Text = "QUITAR SIGUIENTE";
                btnSumaContactos1.Enabled = true;
            }
            visibilidadControles();
        }

        private void btnSumaContactos3_Click(object sender, EventArgs e)
        {
            string textoBoton = btnSumaContactos3.Text;
            if (textoBoton == "MÁS CONTACTOS")
            {
                btnSumaContactos3.Text = "QUITAR SIGUIENTE";
                activos[2] = true;
                btnSumaContactos2.Text = "MÁS CONTACTOS";
                btnSumaContactos2.Enabled = false;
            }
            else
            {
                btnSumaContactos3.Text = "MÁS CONTACTOS";
                btnSumaContactos4.Text = "MÁS CONTACTOS";
                activos[2] = false;
                btnSumaContactos2.Text = "QUITAR SIGUIENTE";
                btnSumaContactos2.Enabled = true;
            }
            visibilidadControles();
        }

        private void btnSumaContactos4_Click(object sender, EventArgs e)
        {
            string textoBoton = btnSumaContactos4.Text;
            if (textoBoton == "MÁS CONTACTOS")
            {
                btnSumaContactos4.Text = "QUITAR SIGUIENTE";
                activos[3] = true;
                btnSumaContactos3.Text = "MÁS CONTACTOS";
                btnSumaContactos3.Enabled = false;
            }
            else
            {
                btnSumaContactos4.Text = "MÁS CONTACTOS";
                btnSumaContactos5.Text = "MÁS CONTACTOS";
                activos[3] = false;
                btnSumaContactos3.Text = "QUITAR SIGUIENTE";
                btnSumaContactos3.Enabled = true;
            }
            visibilidadControles();
        }

        private void btnSumaContactos5_Click(object sender, EventArgs e)
        {
            string textoBoton = btnSumaContactos5.Text;
            if (textoBoton == "MÁS CONTACTOS")
            {
                btnSumaContactos5.Text = "QUITAR SIGUIENTE";
                activos[4] = true;
                btnSumaContactos4.Text = "MÁS CONTACTOS";
                btnSumaContactos4.Enabled = false;
            }
            else
            {
                btnSumaContactos5.Text = "MÁS CONTACTOS";
                activos[4] = false;
                btnSumaContactos4.Text = "QUITAR SIGUIENTE";
                btnSumaContactos4.Enabled = true;
            }
            visibilidadControles();
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
                frm.grillaContactoAlta(_contactos, true);
                this.Close();
            } else
            {
                MessageBox.Show("Error: Ocurrieron los siguientes errores"+Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkFijo1_CheckedChanged(object sender, EventArgs e)
        {
            labelQuince1.Visible = !checkFijo1.Checked;
        }

        private void checkFijo2_CheckedChanged(object sender, EventArgs e)
        {
            labelQuince2.Visible = !checkFijo2.Checked;
        }

        private void checkFijo3_CheckedChanged(object sender, EventArgs e)
        {
            labelQuince3.Visible = !checkFijo3.Checked;
        }

        private void checkFijo4_CheckedChanged(object sender, EventArgs e)
        {
            labelQuince4.Visible = !checkFijo4.Checked;
        }

        private void checkFijo5_CheckedChanged(object sender, EventArgs e)
        {
            labelQuince5.Visible = !checkFijo5.Checked;
        }

        private void checkFijo6_CheckedChanged(object sender, EventArgs e)
        {
            labelQuince6.Visible = !checkFijo6.Checked;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_Validating(object sender, CancelEventArgs e)
        {

            TextBox currenttb = (TextBox)sender;
            if (currenttb.Text.Length > 0)
            {
                Regex emailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
                if (!emailRegex.IsMatch(currenttb.Text))
                {
                    MessageBox.Show("El E-mail ingresado no tiene el formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }


        }


    }

    

}
