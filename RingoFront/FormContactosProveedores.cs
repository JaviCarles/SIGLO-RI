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

namespace RingoFront
{
    public partial class FormContactosProveedores : Form
    {
        public List<Contactos>? _contactos = null;
        private List<RedesSociales>? _redesSociales = null;
        public EnumModoForm modo = EnumModoForm.Alta;
        private int contadorReplicas = 1; // Contador para llevar el seguimiento de las réplicas

        //Valores de carga
        private bool fijo = false;
        private string area = "";
        private string telefono = "";
        private string email = "";
        private string userRedSocial = "";
        private RedesSociales? redSocial = null;
        private string quince = "15";
        private string cero = "+54";

        public FormContactosProveedores()
        {
            InitializeComponent();
        }

        private void FormContactosProveedores_Load(object sender, EventArgs e)
        {
            cargarComboRedesSociales();
            cargarPrimerContacto();
            if (modo == EnumModoForm.Modificacion)
            {
                cargarContactos(sender, e);
            }

            DiseñoUI.diseñoFront(this);
        }

        //Validador numérico
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //-----Cargas de datos-----//
        //Redes Sociales (primer combo y lista)
        private void cargarComboRedesSociales()
        {
            _redesSociales = ContactosMetodos.redesSociales();
            bindingSourceRedes.Clear();
            if (_redesSociales == null)
            {
                _redesSociales = new();
                MessageBox.Show("Hubo un problema al recuperar las redes sociales, consulte al administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bindingSourceRedes.DataSource = _redesSociales;
            comboRedesSociales.Refresh();
        }

        //Primer contacto si está en modificación
        private void cargarPrimerContacto()
        {
            if (_contactos == null || _contactos.Count == 0)
            {
                //Si no hay contactos no cargo nada y pongo en modo alta
                modo = EnumModoForm.Alta;
                return;
            }
            //Reciclo el método para tomar los contactos y pongo el modo modificación ya que traje contactos
            tomarContacto(0);
            modo = EnumModoForm.Modificacion;

            //Cargo los campos iniciales
            txtAreaTelefono.Text = area;
            txtNroTelefono.Text = telefono;
            labelCero.Text = cero;
            labelQuince.Text = quince;
            checkFijo.Checked = fijo;
            txtCorreo.Text = email;
            txtUserRedSocial.Text = userRedSocial;
            if (redSocial != null)
            {
                comboRedesSociales.SelectedItem = redSocial;
            }
        }

        //Carga de contactos en modificación
        private void cargarContactos(object sender, EventArgs e)
        {
            if (_contactos == null || _contactos.Count <= 1)
            {
                return;
            }

            for (int i = 1; i < _contactos.Count; i++)
            {
                btnAgregarDetalleNuevo_Click(sender, e);
            }
        }

        //Método que ordena y agrupa los datos de contactos para que no queden desparramados
        private bool ordenarContactos()
        {
            if (_contactos == null || _contactos.Count < 1)
            {
                return false;
            }

            var telefonos = _contactos
                .Where(c => !string.IsNullOrWhiteSpace(c.Telefono))
                .Select(c => new { c.esFijo, c.codArea, c.Telefono })
                .ToList();

            var emails = _contactos
                .Where(c => !string.IsNullOrWhiteSpace(c.Email))
                .Select(c => c.Email)
                .ToList();

            var usersRedesSociales = _contactos
                .Where(c => c.UsersRedesSociales != null)
                .Select(c => c.UsersRedesSociales)
                .ToList();
            List<Contactos> contactosAgrupados = new List<Contactos>();
            for (int i = 0; i < Math.Max(telefonos.Count, Math.Max(emails.Count, usersRedesSociales.Count)); i++)
            {
                Contactos contacto = new Contactos();
                contacto.esFijo = i < telefonos.Count ? telefonos[i].esFijo : null;
                contacto.codArea = i < telefonos.Count ? telefonos[i].codArea : null;
                contacto.Telefono = i < telefonos.Count ? telefonos[i].Telefono : null;
                contacto.Email = i < emails.Count ? emails[i] : null;
                contacto.UsersRedesSociales = i < usersRedesSociales.Count ? usersRedesSociales[i] : null;
                contactosAgrupados.Add(contacto);
            }
            _contactos.Clear();
            _contactos = contactosAgrupados;

                /*

                //estos acumuladores van a ir sumando si no está vacío, en el momento que haya uno vacío va a quedar atrás de i
                int ultimoTelefono = 0;
                int ultimoCorreo = 0;
                int ultimoUserRS = 0;

                //Los que quedan totalmente vacíos los voy a borrar con esta lista de indices
                List<int> indicesABorrar = new List<int>();

                for (int i = 0; i < _contactos.Count; i++)
                {

                    //creo una variable en cero y si no nulifico el contacto y tiene algo escrito se suma, sino queda en cero
                    int borrarSiCero = 0;

                    //cargo los datos del contacto en la posicion i en las variables fijas
                    tomarContacto(i);
                    if (!String.IsNullOrWhiteSpace(telefono))
                    {

                        //Acá suma a borrar si cero para que no borre este índice si tiene algo
                        borrarSiCero++;

                        //Si el teléfono en el ínice ultimotelefono tiene algo entonces le sumo 1 para no sobreescribir
                        if (_contactos[ultimoTelefono].Telefono != null)
                        {
                            ultimoTelefono++;
                        }

                        //Comparo si el indice -1 del ultimo teléfono es menor al que estoy parado
                        //O sea si el anterior al que estamos parados está vacío.
                        if (ultimoTelefono <= i)
                        {
                            //Si lo está le agrego el teléfono actual
                            _contactos[ultimoTelefono].Telefono = telefono;
                            _contactos[ultimoTelefono].codArea = area;
                            _contactos[ultimoTelefono].esFijo = fijo;

                            //Una vez agregado nulifico el actual y le resto a borrarSiCero para que borre el índice actual que quedó nulo
                            //(Ojo, borrarSiCero va a borrar si no suma nada en los 3 campos: telefono, email y userRS)
                            _contactos[i].Telefono = null;
                            _contactos[i].codArea = null;
                            _contactos[i].esFijo = null;
                            borrarSiCero--;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(email))
                    {
                        borrarSiCero++;

                        if (_contactos[ultimoCorreo].Email != null)
                        {
                            ultimoCorreo++;
                        }

                        if (ultimoCorreo < i)
                        {
                            _contactos[ultimoCorreo].Email = email;
                            _contactos[i].Email = null;
                            borrarSiCero--;
                        }

                    }

                    if (!String.IsNullOrWhiteSpace(userRedSocial))
                    {
                        borrarSiCero++;

                        if (_contactos[ultimoUserRS].UsersRedesSociales != null)
                        {
                            ultimoUserRS++;
                        }

                        if (ultimoUserRS < i)
                        {
                            _contactos[ultimoUserRS].UsersRedesSociales = _contactos[i].UsersRedesSociales;
                            _contactos[i].UsersRedesSociales = null;
                            borrarSiCero--;
                        }
                    }

                    //Si en ninguno sumó a borrarSiCero agrego el índice al listado para borrar
                    if (borrarSiCero == 0)
                    {
                        indicesABorrar.Add(i);
                    }
                }
                List<Contactos>? cont = new();
                //Una vez finalizado borro los índices
                for (int i = 0; i < _contactos.Count; i++)
                {
                    if (!indicesABorrar.Contains(i))
                    {
                        cont.Add(_contactos[i]);
                    }
                }

                _contactos = cont;
                //----ver problema----//
                //No agrega cuenta de red social cuando está sola sin teléfono
                */

            return true;
        }

        //-----Métodos de botones-----//
        //Método de carga de contactos
        private void tomarContacto(int indice)
        {
            //Limpio las variables donde trasladaré los datos a los campos
            fijo = false;
            area = "";
            telefono = "";
            email = "";
            userRedSocial = "";
            redSocial = null;
            int idRedSocial = 0;
            quince = "15";
            cero = "+54";

            //Si no hay contactos o si hay menos de los que busco mantengo todo limpio y vuelvo así se cargan vacíos
            if (_contactos == null || _contactos.Count <= indice)
            {
                return;
            }

            //Lo mismo si por alguna casualidad el contacto en el indice es null
            Contactos contacto = _contactos[indice];
            if (contacto == null)
            {
                return;
            }

            //Recolecto la info en las variables
            fijo = contacto.esFijo ?? false;
            telefono = contacto.Telefono ?? "";
            area = contacto.codArea ?? "";
            if (!String.IsNullOrWhiteSpace(telefono))
            {
                int inicioArea = fijo ? 1 : 3;
                int inicioTel = fijo ? 0 : 1;
                quince = fijo ? "" : "15";
                cero = fijo ? "0" : "+54";
                //Transformo los tipos de teléfono con su formato si es fijo o no
                if (area.Length > inicioArea)
                {
                    area = contacto.codArea.Substring(inicioArea);
                }
                if (telefono.Length > inicioTel)
                {
                    telefono = contacto.Telefono.Substring(inicioTel);
                }
            }
            email = contacto.Email ?? "";
            //Las redes sociales son objetos dentro del contacto, chequeo si hay user
            if (contacto.UsersRedesSociales != null)
            {
                userRedSocial = contacto.UsersRedesSociales.UsuarioRedSocial;
                idRedSocial = contacto.UsersRedesSociales.IdRedSocial;
            }
            //Si había un user de red social el id va a ser mayor que cero asi que la busco en la lista
            if (idRedSocial > 0)
            {
                redSocial = _redesSociales.FirstOrDefault(r => r.IdRedSocial != null && r.IdRedSocial == idRedSocial);
            }
            
        }

        //Salir
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //El nombre lo dice
        private void btnAgregarDetalleNuevo_Click(object sender, EventArgs e)
        {
            if (contadorReplicas < 10)
            {
                //Toma los contactos si hay, si no limpia los campos
                tomarContacto(contadorReplicas - 1);
                GroupBox nuevoGroupBox = new GroupBox();
                nuevoGroupBox.Text = "Contacto n°: " + (contadorReplicas + 1); // Cambia el texto según tus necesidades
                nuevoGroupBox.Name = "groupBoxContacto" + contadorReplicas; // Asigna un nombre único
                nuevoGroupBox.Location = new Point(groupBoxContacto.Location.X, groupBoxContacto.Location.Y +
                (groupBoxContacto.Height + 10) * contadorReplicas); // Ajusta la posición
                nuevoGroupBox.Size = groupBoxContacto.Size; // Ajusta el tamaño
                nuevoGroupBox.BackColor = groupBoxContacto.BackColor;

                // Clona los controles internos del groupBoxDetalle y agrégalos al nuevo GroupBox
                foreach (Control control in groupBoxContacto.Controls)
                {
                    Control nuevoControl = (Control)Activator.CreateInstance(control.GetType());
                    /*   */
                    BindingSource bindingRedesSociales = new BindingSource();
                    bindingRedesSociales.DataSource = _redesSociales;

                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)nuevoControl;
                        txt.Location = control.Location;
                        txt.Size = control.Size;
                        txt.Name = control.Name + contadorReplicas.ToString();
                        txt.Font = control.Font;
                        if (control.Name == "txtCorreo")
                        {
                            txt.Text = email;
                            txt.Validating += txtCorreo1_Validating;
                        }
                        if (control.Name == "txtUserRedSocial")
                        {
                            txt.Text = userRedSocial;
                        }
                        if (control.Name == "txtAreaTelefono")
                        {
                            txt.Text = area;
                            txt.KeyPress += NumericTextBox_KeyPress;
                        }
                        if (control.Name == "txtNroTelefono")
                        {
                            txt.Text = telefono;
                            txt.KeyPress += NumericTextBox_KeyPress;
                        }

                        nuevoControl = txt;

                    }
                    else if (control is ComboBox)
                    {
                        ComboBox cbx = (ComboBox)nuevoControl;
                        cbx.DataSource = bindingRedesSociales;
                        cbx.DisplayMember = "NombreRedSocial";
                        cbx.ValueMember = "IdRedSocial";
                        cbx.Location = control.Location;
                        cbx.Size = control.Size;
                        cbx.Name = control.Name + contadorReplicas.ToString();
                        if (redSocial != null)
                        {
                            cbx.SelectedItem = redSocial;
                        }
                        nuevoControl = cbx;

                    }
                    else if (control is Label originalLabel)
                    {
                        Label nuevoLabel = new Label();
                        nuevoLabel.Text = originalLabel.Text; // Copia el texto
                        nuevoLabel.Name = control.Name + contadorReplicas.ToString();
                        nuevoLabel.Font = originalLabel.Font;
                        nuevoLabel.Location = originalLabel.Location; // Copia la posición
                        nuevoLabel.Size = originalLabel.Size; // Copia el tamaño
                                                              // Copia otras propiedades relevantes (por ejemplo, Font, Color, etc.) según tus necesidades
                        if (originalLabel.Name == "labelCero")
                        {
                            nuevoLabel.Text = cero;
                        }
                        if (originalLabel.Name == "labelQuince")
                        {
                            nuevoLabel.Text = quince;
                        }
                        nuevoControl = nuevoLabel;
                    }
                    else if (control is CheckBox originalCheckBox)
                    {
                        CheckBox nuevoCheckBox = new CheckBox();
                        nuevoCheckBox.Name = control.Name + contadorReplicas.ToString();
                        nuevoCheckBox.Font = originalCheckBox.Font;
                        nuevoCheckBox.Text = originalCheckBox.Text;
                        nuevoCheckBox.Location = originalCheckBox.Location;
                        nuevoCheckBox.Size = originalCheckBox.Size;
                        nuevoCheckBox.Checked = fijo;
                        nuevoCheckBox.CheckedChanged += cambiarCheck;
                        nuevoControl = nuevoCheckBox;
                    }
                    else
                    {
                        nuevoControl.Location = control.Location;
                        nuevoControl.Size = control.Size;
                        nuevoControl.Name = control.Name + contadorReplicas;
                    }
                    nuevoGroupBox.Controls.Add(nuevoControl);
                }
                flowLayoutPanel1.Controls.Add(nuevoGroupBox);
                contadorReplicas++;
            }
            else
            {
                MessageBox.Show("No se pueden agregar más de 10 Detalles por vez.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DiseñoUI.diseñoFront(this);
        }

        private void Txt_Validating(object? sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        //Validar que el texto ingresado en la casilla de correo sea un correo válido
        private void txtCorreo1_Validating(object sender, CancelEventArgs e)
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

        //Quitar detalle de contacto quita el último
        private void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            if (contadorReplicas < 2)
            {
                return;
            }
            foreach (Control groupBox in flowLayoutPanel1.Controls)
            {
                if (groupBox.Name == "groupBoxContacto" + (contadorReplicas - 1))
                {
                    flowLayoutPanel1.Controls.Remove(groupBox);
                }

            }
            contadorReplicas--;
        }

        //Método que le cambia el texto al 0 y al 15 si está o no checkeado el check de fijo en el primer contacto
        private void checkFijo_CheckedChanged(object sender, EventArgs e)
        {

            if (checkFijo.Checked)
            {
                labelQuince.Text = "";
                labelCero.Text = "0";
            }
            else
            {
                labelQuince.Text = "15";
                labelCero.Text = "+54";
            }
            return;

        }

        //Método que le cambia el texto al 0 y al 15 si está o no checkeado el check de fijo en el resto de los contactos
        private void cambiarCheck(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                // Obtener el GroupBox padre del CheckBox
                GroupBox parentGroupBox = checkBox.Parent as GroupBox;
                if (parentGroupBox != null)
                {
                    // Buscar los labels dentro del GroupBox padre
                    Label lblQuince = parentGroupBox.Controls.Find("labelQuince" + checkBox.Name.Replace("checkFijo", ""), true).FirstOrDefault() as Label;
                    Label lblCero = parentGroupBox.Controls.Find("labelCero" + checkBox.Name.Replace("checkFijo", ""), true).FirstOrDefault() as Label;

                    if (lblQuince != null && lblCero != null)
                    {
                        if (checkBox.Checked)
                        {
                            lblQuince.Text = "";
                            lblCero.Text = "0";
                        }
                        else
                        {
                            lblQuince.Text = "15";
                            lblCero.Text = "+54";
                        }
                    }
                }
            }
        }

        //Método para guardar los contactos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Confirma guardar? \n(Se ordenaran los espacios vacíos)", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            _contactos = new();
            int? contador = null;
            foreach (Control groupBox in flowLayoutPanel1.Controls)
            {
                if (groupBox is GroupBox)
                {
                    Contactos? contacto = new();
                    UsersRedesSociales? user = new();
                    RedesSociales? red = new();
                    foreach (Control control in groupBox.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            if (textBox.Name == "txtCorreo" + contador)
                            {
                                string mail = textBox.Text.Trim();
                                if (!String.IsNullOrWhiteSpace(mail))
                                {
                                    contacto.Email = mail;
                                }
                            }

                            if (textBox.Name == "txtNroTelefono" + contador)
                            {
                                string num = textBox.Text.Trim();
                                if (!String.IsNullOrWhiteSpace(num))
                                {
                                    contacto.Telefono = num;
                                }
                            }

                            if (textBox.Name == "txtAreaTelefono" + contador)
                            {
                                string codArea = textBox.Text.Trim();
                                if (!String.IsNullOrWhiteSpace(codArea))
                                {
                                    contacto.codArea = codArea;
                                }
                                else
                                {
                                    contacto.codArea = "3446";
                                }

                            }

                            if (textBox.Name == "txtUserRedSocial" + contador)
                            {
                                string username = textBox.Text.Trim();
                                if (!String.IsNullOrWhiteSpace(username))
                                {
                                    user.UsuarioRedSocial = username;
                                } else
                                {
                                    user = null;
                                }
                            }

                        } 
                        else if (control is ComboBox comboBox)
                        {
                            red = comboBox.SelectedItem as RedesSociales;
                        } 
                        else if (control is CheckBox originalCheckBox)
                        {
                            contacto.esFijo = originalCheckBox.Checked;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(contacto.Telefono))
                    {
                        cero = (contacto.esFijo ?? false) ? "0" : "+54";
                        quince = (contacto.esFijo ?? false) ? "" : "15";
                        contacto.Telefono = quince + contacto.Telefono;
                        contacto.codArea = cero + contacto.codArea;
                    } else
                    {
                        contacto.codArea = null;

                    }
                    if (user != null)
                    {
                        user.RedesSociales = red;
                        user.IdRedSocial = (int)red.IdRedSocial;
                        contacto.UsersRedesSociales = user;
                    }
                    if (contador == null)
                    {
                        contador = 0;
                    }
                    contador++;

                    _contactos.Add(contacto);

                }


            }
            
            if (!ordenarContactos())
            {
                return;
            }
            FrmRegistrarProveedor form = Application.OpenForms["FrmRegistrarProveedor"] as FrmRegistrarProveedor;

            if (form != null)
            {
                form.TraerContactos(_contactos);
                this.Close();
            }


        }
    }
}
