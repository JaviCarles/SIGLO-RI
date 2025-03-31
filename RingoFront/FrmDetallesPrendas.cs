using Microsoft.EntityFrameworkCore.Metadata;
using RingoEntidades;
using RingoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using GroupBox = System.Windows.Forms.GroupBox;
using TextBox = System.Windows.Forms.TextBox;

namespace RingoFront
{
    public partial class FrmDetallesPrendas : Form
    {
        private int contadorReplicas = 1; // Contador para llevar el seguimiento de las réplicas
        public EnumModoForm modo = EnumModoForm.Alta;
        public List<DetallesPrendas> listadetallesPrendas = new List<DetallesPrendas>();
        public List<List<Talles>?> listaTalles = new();
        public List<Estados> _estados = new();
        Estados? _estadoActual = new Estados();
        public List<EstadosPrendas>? _estadosPrendas = new();
        public Prendas? _prenda = new();
        List<string>? credenciales = new();
        public DetallesPrendas? detPrendas = new DetallesPrendas();
        public string codigoAnterior = "";

        public EstadosPrendas? _estadoModificacion = null;

        public FrmDetallesPrendas()
        {
            InitializeComponent();
        }

        private void cargarDatosAlta()
        {
            if (String.IsNullOrWhiteSpace(codigoAnterior))
            {
                txtCodigoDetalle.Text = _prenda.CodigoPrenda + "01";
            } else
            {
                int codigo = 0;
                if (!int.TryParse(codigoAnterior, out codigo))
                {
                    txtCodigoDetalle.Text = _prenda.CodigoPrenda + "1000";
                }
                if (codigo > 0)
                {
                    codigo++;
                    txtCodigoDetalle.Text = codigo.ToString();
                }
            }
            
            txtVenta.Text = _prenda.PrecioVenta.ToString();
            txtCosto.Text = _prenda.Costo.ToString();
            comboBoxColor.SelectedIndex = 0;
            if (listadetallesPrendas.Count > 0)
            {
                txtVenta.Text = listadetallesPrendas[0].PrecioVenta.ToString();
                txtCosto.Text = listadetallesPrendas[0].CostoPrenda.ToString();
            }

        }

        private void cargarDatosModificacion()
        {
            if (_estadoModificacion == null || _estadoModificacion.DetallesPrendas == null || _prenda == null)
            {
                MessageBox.Show("Error al cargar el detalle de prenda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            txtCodigoDetalle.Text = _estadoModificacion.DetallesPrendas.CodigoDetalle;
            txtCodigoPrenda.Text = _prenda.CodigoPrenda;
            comboBoxColor.Text = _estadoModificacion.DetallesPrendas.Color;
            txtVenta.Text = _estadoModificacion.DetallesPrendas.PrecioVenta.ToString();
            txtCosto.Text = _estadoModificacion.DetallesPrendas.CostoPrenda.ToString();
            numUpDownDetallePrenda.Value = _estadoModificacion.CantidadEstado;
        }

        private void activarIterador()
        {
            bool alta = modo == EnumModoForm.Alta;
            btnAgregarDetalleNuevo.Enabled = alta;
            btnQuitarDetalle.Enabled = alta;
            btnGuardar.Text = alta ? "Añadir" : "Modificar";
            txtCodigoDetalle.Enabled = false;
        }

        private void btnAgregarDetalleNuevo_Click(object sender, EventArgs e)
        {

            if (contadorReplicas < 10) // Limitamos a 10 réplicas
            {
                // Clona el groupBoxDetalle
                GroupBox nuevoGroupBox = new GroupBox();
                nuevoGroupBox.Text = "Detalle de prenda " + (contadorReplicas + 1); // Cambia el texto según tus necesidades
                nuevoGroupBox.Name = "groupBoxDetalle" + contadorReplicas; // Asigna un nombre único
                nuevoGroupBox.Location = new Point(groupBoxDetalle.Location.X, groupBoxDetalle.Location.Y +
                (groupBoxDetalle.Height + 10) * contadorReplicas); // Ajusta la posición
                nuevoGroupBox.Size = groupBoxDetalle.Size; // Ajusta el tamaño
                nuevoGroupBox.BackColor = groupBoxDetalle.BackColor;

                //Le damos la altura al formulario junto con el panel
                //alturaForm += nuevoGroupBox.Height;
                //alturaPanel += nuevoGroupBox.Height;

                int contadorComboBox = 0;
                // Clona los controles internos del groupBoxDetalle y agrégalos al nuevo GroupBox
                foreach (Control control in groupBoxDetalle.Controls)
                {
                    Control nuevoControl = (Control)Activator.CreateInstance(control.GetType());
                    /*   */
                    BindingSource bindingTalle = new BindingSource();
                    bindingTalle.DataSource = bindingSourceTalles.DataSource;
                    BindingSource bindingColor = new BindingSource();
                    bindingColor.DataSource = comboBoxColor.Items;
                    BindingSource bindingEstados = new BindingSource();
                    bindingEstados.DataSource = bindingSourceEstados.DataSource;

                    if (control is NumericUpDown)
                    {
                        NumericUpDown numericUpDown = (NumericUpDown)nuevoControl;
                        numericUpDown.Location = control.Location;
                        numericUpDown.Size = control.Size;
                        numericUpDown.Name = control.Name + contadorReplicas.ToString();
                        nuevoControl = numericUpDown;
                    }
                    else if (control is TextBox)
                    {
                        TextBox txt = (TextBox)nuevoControl;
                        txt.Location = control.Location;
                        txt.Size = control.Size;
                        txt.Name = control.Name + contadorReplicas.ToString();
                        txt.KeyPress += NumericTextBox_KeyPress;
                        if (control.Name == "txtCodigoDetalle")
                        {
                            int codigo = Convert.ToInt32(control.Text) + contadorReplicas;
                            txt.Text = codigo.ToString();
                            txt.Enabled = false;
                        }
                        if (control.Name == "txtVenta")
                        {
                            txt.Text = _prenda.PrecioVenta.ToString();
                        }
                        if (control.Name == "txtCosto")
                        {
                            txt.Text = _prenda.Costo.ToString();
                        }
                        if (control.Name == "txtCodigoPrenda")
                        { txt.Visible = false; }

                        nuevoControl = txt;

                    }
                    else if (control is ComboBox)
                    {
                        if (contadorComboBox == 1)
                        {
                            ComboBox cbx = (ComboBox)nuevoControl;
                            cbx.DataSource = bindingColor;
                            cbx.Location = control.Location;
                            cbx.Size = control.Size;
                            cbx.Name = control.Name + contadorReplicas.ToString();
                            nuevoControl = cbx;
                            contadorComboBox = 0;
                            nuevoControl = cbx;
                        }
                        else if (contadorComboBox == 2)
                        {
                            ComboBox cbx = (ComboBox)nuevoControl;
                            cbx.Name = control.Name + contadorReplicas.ToString();
                            cbx.DataSource = bindingTalle;
                            cbx.DisplayMember = "DescripcionTalle";
                            cbx.Location = control.Location;
                            cbx.Size = control.Size;
                            nuevoControl = cbx;
                            contadorComboBox = 1;
                            nuevoControl = cbx;
                        }
                        else
                        {
                            ComboBox cbx = (ComboBox)nuevoControl;
                            cbx.Name = control.Name + contadorReplicas.ToString();
                            cbx.DataSource = bindingEstados;
                            cbx.DisplayMember = "Estado";
                            cbx.ValueMember = "IdEstado";
                            cbx.Location = control.Location;
                            cbx.Size = control.Size;
                            nuevoControl = cbx;
                            contadorComboBox = 2;
                            nuevoControl = cbx;
                            if (modo == EnumModoForm.Alta)
                                nuevoControl.Enabled = false;
                        }

                    }
                    else if (control is Label originalLabel)
                    {
                        Label nuevoLabel = new Label();
                        nuevoLabel.Text = originalLabel.Text; // Copia el texto
                        nuevoLabel.Font = originalLabel.Font;
                        nuevoLabel.Location = originalLabel.Location; // Copia la posición
                        nuevoLabel.Size = originalLabel.Size; // Copia el tamaño
                                                              // Copia otras propiedades relevantes (por ejemplo, Font, Color, etc.) según tus necesidades
                        if (originalLabel.Name == "lblCodPrenda")
                        {
                            nuevoLabel.Visible = false;
                        }
                        nuevoControl = nuevoLabel;
                    }
                    else
                    {
                        nuevoControl.Location = control.Location;
                        nuevoControl.Size = control.Size;
                        nuevoControl.Name = control.Name + contadorReplicas;
                    }

                    // Agrega el control clonado al nuevo GroupBox
                    nuevoGroupBox.Controls.Add(nuevoControl);
                }

                // this.Height = alturaForm;
                //panel1.Height = alturaPanel;
                // Agrega el nuevo GroupBox al formulario
                //this.Controls.Add(nuevoGroupBox);

                // Agrega el nuevo GroupBox al Panel
                panel1.Controls.Add(nuevoGroupBox);

                contadorReplicas++; // Incrementa el contador
            }
            else
            {
                MessageBox.Show("No se pueden agregar más de 10 Detalles por vez.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DiseñoUI.diseñoFront(this);
        }

        private void CargarComboEstados()
        {
            _estados = new();
            _estados = PrendasNegocio.GetEstadosIndolePrenda();

            if (_estados.Count < 1)
            {
                _estados.Add(CrearEstadoGenerico());
            }
            bindingSourceEstados.DataSource = _estados;
            cmbEstado.DataSource = bindingSourceEstados;

            if (modo == EnumModoForm.Alta)
            {
                _estadoActual = _estados.FirstOrDefault(e => e.Estado.Equals("Apta"));
            }
            else
            {
                _estadoActual = _estados.FirstOrDefault(e => e.IdEstado == _estadoModificacion.EstadosHistorias.IdEstadoActual);
            }
            if (_estadoActual != null)
            {
                cmbEstado.SelectedItem = _estadoActual;
            }

            cmbEstado.Enabled = modo != EnumModoForm.Alta;
            //el DisplayMember y el ValueMember se configuran en las propiedades para el primero
        }


        private Estados CrearEstadoGenerico()
        {
            Estados nuevo = new Estados();
            nuevo.Estado = "Apta";
            nuevo.Indole = "Prendas";
            int id = PrendasNegocio.InsertEstado(nuevo);
            nuevo.IdEstado = id > 0 ? id : 1;
            return nuevo;
        }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (listadetallesPrendas == null)
            {
                listadetallesPrendas = new();
            }
            
            if (_estadosPrendas == null)
            {
                _estadosPrendas = new();
            }

            if (modo == EnumModoForm.Alta)
            {
                _estadosPrendas = new();
            }
            
            int? cont = null;
            FlowLayoutPanel flowLayoutPanel = this.panel1;
            foreach (Control groupBox in flowLayoutPanel.Controls)
            {
                if (groupBox is GroupBox)
                {
                    DetallesPrendas detallesPrendas = new DetallesPrendas();
                    EstadosPrendas estadoDetalle = new();
                    if (modo == EnumModoForm.Modificacion && _estadoModificacion != null)
                    {
                        estadoDetalle = _estadoModificacion;
                        detallesPrendas = _estadoModificacion.DetallesPrendas ?? new();
                    }
                    foreach (Control control in groupBox.Controls)
                    {
                        if (control is TextBox textBox)
                        {

                            if (textBox.Name == "txtCodigoDetalle" + cont)
                            {
                                if (String.IsNullOrEmpty(textBox.Text))
                                {
                                    MessageBox.Show("Falta agregar el código de detalle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                detallesPrendas.CodigoDetalle = textBox.Text;
                            }
                            else if (textBox.Name == "txtCosto" + cont)
                            {
                                if (String.IsNullOrEmpty(textBox.Text))
                                {
                                    MessageBox.Show("Falta agregar el costo de la prenda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                detallesPrendas.CostoPrenda = decimal.Parse(textBox.Text);
                            }
                            else if (textBox.Name == "txtVenta" + cont)
                            {
                                if (String.IsNullOrEmpty(textBox.Text))
                                {
                                    MessageBox.Show("Falta agregar el precio de venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                detallesPrendas.PrecioVenta = decimal.Parse(textBox.Text);
                            }
                        }
                        if (control is ComboBox comboBox)
                        {
                            if (comboBox.Name == "comboBoxColor" + cont)
                            {
                                detallesPrendas.Color = comboBox.Text.Trim();
                            }
                            else if (comboBox.Name == "comboBoxTalle" + cont)
                            {
                                detallesPrendas.Talle = (Talles)comboBox.SelectedItem;
                                detallesPrendas.IdTalle = detallesPrendas.Talle.IdTalle;
                            }
                            else if (comboBox.Name == "cmbEstado" + cont)
                            {
                                if (modo == EnumModoForm.Modificacion)
                                {
                                    if (estadoDetalle.EstadosHistorias != null)
                                    {
                                        estadoDetalle.EstadosHistorias.IdEstadoAnterior = _estadoModificacion.EstadosHistorias.IdEstadoActual;
                                        estadoDetalle.EstadosHistorias.IdEstadoActual = (int)comboBox.SelectedValue;
                                        estadoDetalle.EstadosHistorias.EstadosActuales = (Estados)comboBox.SelectedItem;
                                        estadoDetalle.EstadosHistorias.FechaCambioEstado = DateTime.Now;
                                    }
                                } else
                                {
                                    EstadosHistorias estadosHistorias = new();
                                    estadosHistorias.IdEstadoAnterior = null;
                                    estadosHistorias.IdEstadoActual = (int)comboBox.SelectedValue;
                                    estadosHistorias.FechaCambioEstado = DateTime.Now;
                                    estadosHistorias.EstadosActuales = (Estados)comboBox.SelectedItem;
                                    estadoDetalle.EstadosHistorias = estadosHistorias;
                                    estadoDetalle.IdPrenda = 0;
                                    estadoDetalle.Observaciones = "";
                                    estadoDetalle.DetallesPrendas = detallesPrendas;
                                }
                                

                            }
                        }
                        if (control is NumericUpDown numericUpDown)
                        {
                            detallesPrendas.CantidadPrenda = (int)numericUpDown.Value;
                            estadoDetalle.CantidadEstado = (int)numericUpDown.Value;
                        }
                    }
                    if (_prenda.IdPrenda != null)
                    {
                        detallesPrendas.IdPrenda = (int)_prenda.IdPrenda;
                    }
                    estadoDetalle.DetallesPrendas = detallesPrendas;
                    _estadoModificacion = estadoDetalle;
                    listadetallesPrendas.Add(detallesPrendas);
                    _estadosPrendas.Add(estadoDetalle);
                }
                if (cont == null)
                {
                    cont = 0;
                }
                cont++;
            }
            string mensaje = cantidadesCorrectas();
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmRegistrarPrenda form = Application.OpenForms["FrmRegistrarPrenda"] as FrmRegistrarPrenda;
            if (form != null)
            {
                if (modo == EnumModoForm.Modificacion)
                {
                    form._detallesModificados = new();
                    form._detallesModificados = _estadosPrendas;
                } else
                {
                    if (form._detallesRegistrar == null || form._detallesRegistrar.Count == 0)
                    {
                        form._detallesRegistrar = _estadosPrendas;
                    } else
                    {
                        form._detallesRegistrar.AddRange(_estadosPrendas);
                    }
                }
                form.volverDeDetalles();
                this.Close();
            }
        }

        private string cantidadesCorrectas()
        {
            if (modo == EnumModoForm.Modificacion)
            {
                return "";
            }
            string mensaje = "";
            if (listadetallesPrendas.Count == 0)
                return mensaje;
            string indices = "";
            int contador = 0;
            for (int i = 0; i < listadetallesPrendas.Count; i++)
            {
                if (listadetallesPrendas[i].CantidadPrenda == 0)
                {
                    indices += i == listadetallesPrendas.Count - 1 ? (i + 1) + " " : (i + 1) + ", ";
                    contador++;
                }
            }
            if (String.IsNullOrWhiteSpace(indices))
                return mensaje;
            if (contador > 1)
                mensaje = "Error, los detalles número " + indices + "no tienen cantidad ingresada, por favor ingrese cantidad";
            else
                mensaje = "Error, el detalle número " + indices + "no tiene cantidad ingresada, por favor ingrese cantidad";

            return mensaje;
        }

        private void cargarComboTalle(int posicion)
        {
            bindingSourceTalles.Clear();
            List<Talles>? talles = new();
            talles = PrendasNegocio.getTalles();
            if (talles != null)
            {
                if (modo != EnumModoForm.Modificacion)
                {
                    listaTalles.Add(talles);
                    bindingSourceTalles.DataSource = listaTalles[posicion];
                } else
                {
                    bindingSourceTalles.DataSource = talles;
                }
                if (_estadoModificacion == null)
                {
                    return;
                }
                if (_estadoModificacion.DetallesPrendas == null)
                {
                    return;
                }
                Talles? actual = talles.FirstOrDefault(t => t.IdTalle == _estadoModificacion.DetallesPrendas.IdTalle);
                if (actual != null)
                {
                    comboBoxTalle.SelectedItem = actual;
                }
                
                
            }
        }

        private void FrmDetallesPrendas_Load(object sender, EventArgs e)
        {
            credenciales = LoginUsuario.CredencialesActivas();
            if (!comprobarCredenciales())
            {
                MessageBox.Show("Su usuario no tiene permiso para acceder a esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (modo == EnumModoForm.Alta)
            {
                cargarDatosAlta();
            } else
            {
                cargarDatosModificacion();
            }

            cargarComboTalle(0);
            CargarComboEstados();
            activarIterador();
            //  CargarComboEstados();
            DiseñoUI.diseñoFront(this);
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnQuitarDetalle_Click(object sender, EventArgs e)
        {

            if (contadorReplicas < 2)
            {
                return;
            }
            foreach (Control groupBox in panel1.Controls)
            {
                if (groupBox.Name == "groupBoxDetalle" + (contadorReplicas - 1))
                {
                    panel1.Controls.Remove(groupBox);
                }

            }
            contadorReplicas--;
        }


    }
}
