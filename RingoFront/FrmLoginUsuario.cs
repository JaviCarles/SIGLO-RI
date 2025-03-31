using RingoEntidades;
using RingoNegocio;

namespace RingoFront
{
    public partial class FrmLoginUsuario : Form
    {
        List<Usuarios> usuariolista = new List<Usuarios>();
        public FrmLoginUsuario()
        {
            InitializeComponent();
            this.AcceptButton = btnIngresar; // aca definimos que la tecla Enter realiza la funcion del boton btnIngresar.
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            buscarUsuario();
        }

        private void buscarUsuario()
        {
            // recuperar texto de los text box
            string usuarioBuscar = txtUsuario.Text.Trim().ToUpper();
            string contraseniaBuscar = txtContrasenia.Text;

            //crear un Objeto usuarios vacio llamado parametro
            Usuarios parametro = new Usuarios();

            // Verificamos que no hayan espacios en blanco o ingreso nulo
            if (!String.IsNullOrWhiteSpace(usuarioBuscar) && !String.IsNullOrWhiteSpace(contraseniaBuscar))
            {
                // insertamos los text box en las properties del objeto Usuarios llamado 'parametro'
                parametro.NombreUsuario = usuarioBuscar;
                parametro.ClaveUsuario = contraseniaBuscar;

                //llamamos al metodo login de la capa negocio enviandole el objeto Usuarios 'parametro' como parametro

                if (LoginUsuario.login(parametro)) //el metodo login devuelve true o false
                {
                    //si devuelve true debe abrir el 'FrmPrincipal' y cerrar el login
                    this.Visible = false;
                    FrmPrincipal frm = new FrmPrincipal();
                    frm.ShowDialog();

                    MessageBox.Show("Gracias por usar SIGLO RI");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrectas");
                }
            }

            else
            {
                MessageBox.Show("Ingrese Usuario y Contraseña .");
            }
        }

        private void enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarUsuario();
            }
        }

    }

}