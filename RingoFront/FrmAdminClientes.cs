using RingoEntidades;
using RingoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RingoFront
{
    public partial class FrmAdminClientes : Form
    {
        public EnumModoForm modo = EnumModoForm.Consulta;
        List<string>? credenciales = new();
        List<Ciudades>? _ciudades = new List<Ciudades>();
        List<Personas>? _personas = null;
        List<Clientes> _clientes = new List<Clientes>();
        List<Personas>? _personasPorFila = new List<Personas>();
        public Personas _persona = new Personas();
        Clientes? _cliente = new Clientes();
        private int currentMouseOverRow = -1;
        private int totalPaginas = 0; //Cantidad total de páginas
        private int rowsPerPage = 0; // Filas por página
        private int currentPage = 0; // Página actual
        List<int> cantidadFilas = new List<int>() { 10, 20, 30, 50, 100, 300, 1000 };
        private int filaInicio = 1;
        List<int> valoresLikns = new List<int>() { 0, 0, 0, 0, 0 };
        List<string> textosLinks = new List<string>() { "", "", "", "", "" };
        private int idCiudad = 0;
        bool registrarClienteVenta = false;

        public FrmAdminClientes()
        {
            InitializeComponent();

        }

        private void FrmAdminClientes_Load(object sender, EventArgs e)
        {
            btnConsultar.Enabled = false;

            DiseñoUI.diseñoFront(this);//aplicamos tema.
            CargarComboCiudades();
            ComboFilas();
            

        }

        private bool CargarPersona()
        {
            if (_persona == null)
                return false;

            txtDni.Text = _persona.Dni;
            txtNombre.Text = String.IsNullOrWhiteSpace(_persona.Nombre) ? _persona.Apellidos : _persona.Nombre;

            if (String.IsNullOrWhiteSpace(txtDni.Text) && String.IsNullOrWhiteSpace(txtNombre.Text))
                return false;
            return true;
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


        private void BuscarPersonas()
        {
            Registro(false);
            if (modo == EnumModoForm.Consulta)
                _persona = new();
            if (_personas != null)
                _personas.Clear();
            try
            {
                idCiudad = (int)comboCiudad.SelectedValue;
            }
            catch (Exception) { }

            bool anulados = checkAnulados.Checked;
            bool observaciones = checkObservaciones.Checked;
            string dniPersona = txtDni.Text.Trim();
            string nombres = txtNombre.Text.Trim();
            string mensaje = "\nPosibles errores:";
            validarDni(ref mensaje, dniPersona);
            validarNombres(ref mensaje, nombres);
            string mensajeBusqueda = "";
            _personas = PersonasMetodos.PersonasCompleto(_persona, anulados, idCiudad, observaciones, ref mensajeBusqueda);
            if (_personas == null || _personas.Count == 0)
            {
                if (!String.IsNullOrEmpty(_persona.Dni) && _persona.Dni.Length >= 7)
                {
                    
                    if (modo != EnumModoForm.Venta)
                    {
                        modo = EnumModoForm.Alta;
                    } else
                    {
                        registrarClienteVenta = true;
                    }
                    Registro(true);

                }
                else
                {
                    comboCiudad.SelectedIndex = 0;
                    checkAnulados.Checked = false;
                    _persona = new();
                    MessageBox.Show($"Consulta Sin resultados{mensaje}\n{mensajeBusqueda}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (_personas.Count > 0)
                btnConsultar.Enabled = true;
            else
                btnConsultar.Enabled = false;

        }

        private void validarNombres(ref string mensaje, string nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
            {
                int espacio = nombre.IndexOf(" ");
                if (espacio > -1)
                {
                    string sub1 = nombre.Substring(0, espacio);
                    string sub2 = nombre.Substring(++espacio);
                    _persona.Nombre = sub1;
                    _persona.Apellidos = sub2;
                }
                else
                {
                    _persona.Apellidos = nombre;
                    _persona.Nombre = nombre;
                }

                _persona.Observaciones = nombre;
            }
            else
            {
                _persona.Apellidos = "";
                _persona.Nombre = "";
                _persona.Observaciones = "";
            }
        }

        private void validarDni(ref string mensaje, string dni)
        {
            int Dni = 0;
            _persona.Dni = "";
            if (!String.IsNullOrEmpty(dni) && int.TryParse(dni, out Dni))
            {
                _persona.Dni = dni;
            }
            else if (!String.IsNullOrEmpty(dni))
            {
                mensaje += "\n*Dni en formato incorrecto";
            }

        }

        private void CargarComboCiudades()
        {
            bindingSourceCiudades.Clear();
            _ciudades = new();
            Ciudades ciudadCero = new Ciudades();
            ciudadCero.IdCiudad = 0;
            ciudadCero.NombreCiudad = "Localidades";
            List<Ciudades>? ciudades = new List<Ciudades>();
            ciudades = DomiciliosMetodos.Ciudades();
            _ciudades.Add(ciudadCero);
            if (ciudades != null)
                _ciudades.AddRange(ciudades);
            else
                comboCiudad.Enabled = false;
            bindingSourceCiudades.DataSource = _ciudades;
            comboCiudad.SelectedIndex = 0;
        }

        private void Registro(bool visible)
        {
            groupBoxRegistro.Visible = visible;
            TituloRegistro1.Visible = visible;
            TituloRegistro2.Visible = visible;
            btnRegistrar.Visible = visible;
            dataGridPersonas.Visible = !visible;
            btnConsultar.Visible = !visible;
            dataGridPersonas.Visible = !visible;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            BuscarPersonas();
            refreshComboFilas();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            _persona = new();
            _persona.Dni = txtDni.Text.Trim();
            _cliente = new();

            FrmPrincipal frmPrincipal = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (frmPrincipal == null)
            {
                frmPrincipal = new FrmPrincipal();
            }
            FrmEditClientes abierto = Application.OpenForms.OfType<FrmEditClientes>().FirstOrDefault();
            if (abierto != null)
            {
                abierto.Close();
            }
            FrmEditClientes registrar = new FrmEditClientes();
            registrar._persona = _persona;
            registrar._cliente = _cliente;
            registrar.registrarConVenta = registrarClienteVenta;
            registrar.MdiParent = frmPrincipal;
            registrar.modo = EnumModoForm.Alta;
            registrar.Dock = DockStyle.Fill;
            registrar.Show();
        }

        // Método para consultar la persona seleccionada
        public void ConsultarPersona(object sender, EventArgs e)
        {
            // Obtiene el índice de la fila actualmente seleccionada en el DataGridView
            int selectedRowIndex = dataGridPersonas.SelectedCells[0].RowIndex;

            // Obtiene el objeto Personas asociado con la fila seleccionada
            Personas selectedPersona = (Personas)dataGridPersonas.Rows[selectedRowIndex].DataBoundItem;

            // Asigna la persona seleccionada al objeto _persona
            _persona = selectedPersona;
            _cliente = PersonasMetodos.BuscarClientes(_persona);
            if (_cliente != null)
            {
                if (_persona != null)
                {
                    _cliente.Personas = _persona;
                    _cliente.IdPersona = (int)_persona.IdPersona;
                }
            }

            if (_persona == null || _cliente == null)
            {
                MessageBox.Show("No ha seleccionado ningún cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (modo == EnumModoForm.Venta)
            {
                frmRegistrarVentas frmRegistrarVentas = Application.OpenForms.OfType<frmRegistrarVentas>().FirstOrDefault();
                if (frmRegistrarVentas != null)
                {
                    frmRegistrarVentas.VolverDeBuscarClientes(_cliente);
                    this.Close();
                }
                return;
            }
            else
            {
                FrmPrincipal frmPrincipal = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
                if (frmPrincipal != null)
                {
                    frmPrincipal.abrirEditClientesConParametros(sender, e, _persona, _cliente, EnumModoForm.Consulta);
                }
            }



        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarPersona(sender, e);
        }

        private void dataGridPersonas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string imagePath = Path.Combine(Application.StartupPath, @"..\..\..\Resources\lapiz.png");
            Image img = Image.FromFile(imagePath);

            if (e.ColumnIndex == dataGridPersonas.Columns["Modificar"].Index)
            {
                if (e.RowIndex == currentMouseOverRow)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    // Calcula la posición para centrar la imagen en la celda
                    Point pt = new Point(e.CellBounds.Location.X + (e.CellBounds.Width - img.Width) / 2,
                                         e.CellBounds.Location.Y + (e.CellBounds.Height - img.Height) / 2);

                    // Dibuja la imagen en la celda
                    e.Graphics.DrawImage(img, pt);
                    e.Handled = true;
                }

            }
            else if (e.ColumnIndex == dataGridPersonas.Columns["Modificar"].Index && e.RowIndex != currentMouseOverRow)
            {
                // No dibuja nada, efectivamente haciendo que el botón sea 'invisible'
                e.Handled = true;
            }
        }

        private void dataGridPersonas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el mouse esté sobre una fila válida
            if (e.RowIndex >= 0)
            {
                currentMouseOverRow = e.RowIndex;
                // Redibuja la fila para mostrar el botón
                dataGridPersonas.InvalidateRow(e.RowIndex);
            }
        }

        private void dataGridPersonas_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el mouse esté saliendo de una fila válida
            if (e.RowIndex >= 0)
            {
                currentMouseOverRow = -1;
                // Redibuja la fila para ocultar el botón
                dataGridPersonas.InvalidateRow(e.RowIndex);
            }
        }

        private void dataGridPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic sea en la columna 'Modificar' y en una fila válida
            if (e.RowIndex >= 0 && dataGridPersonas.Columns[e.ColumnIndex].Name == "Modificar")
            {
                // Obtiene el objeto Personas asociado con la fila seleccionada
                _persona = (Personas)dataGridPersonas.Rows[e.RowIndex].DataBoundItem;
                _cliente = PersonasMetodos.BuscarClientes(_persona);

                FrmPrincipal frmPrincipal = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
                if (frmPrincipal != null)
                {
                    frmPrincipal.abrirEditClientesConParametros(sender, e, _persona, _cliente, EnumModoForm.Modificacion);
                }
            }
        }

        private void refreshGrid()
        {
            UpdateDataGridView();
            bindingSourcePersonas.DataSource = _personasPorFila;
        }

        // Método para actualizar el DataGridView según la página actual
        private void UpdateDataGridView()
        {
            if (_personas != null)
            {
                if (_personas.Count > rowsPerPage)
                {
                    int filaInicio = (currentPage - 1) * rowsPerPage;
                    _personasPorFila = _personas.Skip(filaInicio).Take(Math.Min(rowsPerPage, _personas.Count - filaInicio)).ToList();
                }
                else
                {
                    _personasPorFila = _personas;
                }

            }
            else if (_personas == null || _personas.Count == 0)
            {
                currentPage = 0;
                totalPaginas = 0;
            }
            txtPag.Text = currentPage.ToString();

        }

        private void ComboFilas()
        {
            comboFilas.DataSource = cantidadFilas;
            comboFilas.SelectedIndex = 2;
            refreshComboFilas();
        }

        private void refreshComboFilas()
        {
            rowsPerPage = (int)comboFilas.SelectedItem;
            GetTotalPages();
            UpdatePageLinks();
            refreshGrid();
        }

        // Método para calcular la cantidad total de páginas
        private void GetTotalPages()
        {
            if (_personas == null)
                totalPaginas = 0;
            else if (_personas.Count == 0)
                totalPaginas = 0;
            else
                totalPaginas = (int)Math.Ceiling((double)_personas.Count / rowsPerPage);
            if (totalPaginas == 0)
                currentPage = 0;
        }

        // Método para actualizar las etiquetas de enlace
        private void UpdatePageLinks()
        {
            linksTexto();
            if (currentPage == 0 || totalPaginas == 0)
            {
                linkPrimerPagina.Enabled = false;
                linkPagAnterior.Enabled = false;
                linkPaginaSiguiente.Enabled = false;
                linkUltimaPagina.Enabled = false;
            }
            else
            {
                linkPrimerPagina.Enabled = true;
                linkPagAnterior.Enabled = true;
                linkPaginaSiguiente.Enabled = true;
                linkUltimaPagina.Enabled = true;
            }
            if (totalPaginas == currentPage)
                linkPaginaSiguiente.Enabled = false;
            if (currentPage == 1)
            {
                linkPagAnterior.Enabled = false;
                linkPrimerPagina.Enabled = false;
            }

            if (totalPaginas == 1 || currentPage == totalPaginas)
                linkUltimaPagina.Visible = false;

        }

        private void linksNumeros()
        {
            int x = currentPage == totalPaginas ? totalPaginas - 4 : currentPage - 2;
            x = Math.Max(1, x);
            for (int i = 0; i < 5; i++)
            {
                valoresLikns[i] = x;
                x++;
                if (totalPaginas < valoresLikns[i] || totalPaginas == 0)
                    valoresLikns[i] = 0;

                if (valoresLikns[i] == 0)
                    textosLinks[i] = "";
                else
                    textosLinks[i] = valoresLikns[i].ToString();
            }
        }

        private void linksTexto()
        {
            linksNumeros();

            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case (0):
                        linkPagina1.Text = textosLinks[0];
                        linkPagina1.Visible = !String.IsNullOrWhiteSpace(textosLinks[i]);
                        break;
                    case (1):
                        linkPagina2.Text = textosLinks[i];
                        linkPagina2.Visible = !String.IsNullOrWhiteSpace(textosLinks[i]);
                        break;
                    case (2):
                        linkPagina3.Text = textosLinks[i];
                        linkPagina3.Visible = !String.IsNullOrWhiteSpace(textosLinks[i]);
                        break;
                    case (3):
                        linkPagina4.Text = textosLinks[i];
                        linkPagina4.Visible = !String.IsNullOrWhiteSpace(textosLinks[i]);
                        break;
                    case (4):
                        linkPagina5.Text = textosLinks[i];
                        linkPagina5.Visible = !String.IsNullOrWhiteSpace(textosLinks[i]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void comboFilas_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshComboFilas();
        }

        private void paginaAnterior(object sender, LinkLabelLinkClickedEventArgs e)
        {
            currentPage--;
            refreshComboFilas(); // Actualiza las etiquetas de enlace
        }

        private void paginaSiguiente(object sender, LinkLabelLinkClickedEventArgs e)
        {
            currentPage++;
            refreshComboFilas(); // Actualiza las etiquetas de enlace
        }

        private void primerLinkPagina(object sender, LinkLabelLinkClickedEventArgs e)
        {
            currentPage = 1;
            refreshComboFilas(); // Actualiza las etiquetas de enlace
        }

        private void linkUltima(object sender, LinkLabelLinkClickedEventArgs e)
        {
            currentPage = totalPaginas;
            refreshComboFilas(); // Actualiza las etiquetas de enlace
        }

        private void clickPaginas(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int selectedPage = Convert.ToInt32(((LinkLabel)sender).Text);
            currentPage = selectedPage; // Actualiza la página actual
            refreshComboFilas(); // Actualiza las etiquetas de enlace
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtiene el índice de la fila actualmente seleccionada en el DataGridView
            int selectedRowIndex = 0; ;
            try
            {
                selectedRowIndex = dataGridPersonas.SelectedCells[0].RowIndex;
            }
            catch (Exception)
            {
                return;
            }

            // Obtiene el objeto Personas asociado con la fila seleccionada
            Personas selectedPersona = (Personas)dataGridPersonas.Rows[selectedRowIndex].DataBoundItem;

            // Asigna la persona seleccionada al objeto _persona
            _persona = selectedPersona;
            _cliente = PersonasMetodos.BuscarClientes(_persona);
            if (_cliente != null)
            {
                if (_persona != null)
                {
                    _cliente.Personas = _persona;
                    _cliente.IdPersona = (int)_persona.IdPersona;
                }
            }
            else
            {
                return;
            }
            Estados? estado = PersonasMetodos.GetEstadoPorNombre("Baja");
            if (estado == null)
            {
                MessageBox.Show("Error al recuperar el estado de baja de persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _persona.IdEstado = (int)estado.IdEstado;
            DialogResult baja = MessageBox.Show("Se procederá a dar de baja al cliente ¿Desea continuar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (baja == DialogResult.No)
            {
                return;
            }
            _persona.Observaciones = "Fecha baja: " + DateTime.Now.ToString();
            if (!PersonasMetodos.UpdatePersona(_persona))
            {
                MessageBox.Show("Error al modificar el estado de baja de persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult eliminar = MessageBox.Show("Se dió de baja al cliente si continua se eliminará definitivamente de los registros ¿Desea continuar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (eliminar == DialogResult.No)
            {
                return;
            }
            string mensaje = PersonasMetodos.DeleteCliente(_cliente);
            MessageBox.Show("Resultados de eliminar al cliente: \n" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

        }

        private void btnListadoXls_Click(object sender, EventArgs e)
        {
            if (_personas == null || _personas.Count == 0)
            {
                MessageBox.Show("No hay clientes para emitir listado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string filtroDni = txtDni.Text.Trim();
            string filtroNombre = txtNombre.Text.Trim();
            string filtroCiudad = comboCiudad.Text.Trim();
            ListadosExcel.ExportPersonasToExcel(_personas, filtroDni, filtroNombre, filtroCiudad);
        }

        private void FrmAdminClientes_Shown(object sender, EventArgs e)
        {
            credenciales = LoginUsuario.CredencialesActivas();
            if (!comprobarCredenciales())
            {
                MessageBox.Show("Su usuario no tiene permiso para acceder a esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (modo == EnumModoForm.Venta)
            {
                btnConsultar.Text = "Seleccionar";
                if (CargarPersona())
                {
                    BuscarPersonas();
                }
            }
        }
    }
}
