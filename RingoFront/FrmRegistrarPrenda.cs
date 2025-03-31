using Microsoft.Data.SqlClient;
using RingoEF;
using RingoEntidades;
using RingoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RingoFront
{
    public partial class FrmRegistrarPrenda : Form
    {
        public EnumModoForm modoPrenda = EnumModoForm.Alta;
        private int currentMouseOverRow = -1;
        public Prendas? _prenda = new Prendas();
        private List<CategoriaSubCategoria>? _categoriasSubCategorias = new();
        private CategoriasPrendas? _categoria = new CategoriasPrendas();
        private SubCategoriasPrendas? _subCategoria = new SubCategoriasPrendas();
        public List<EstadosPrendas>? _estados = new();
        public List<EstadosPrendas>? _estadosNoModificados = new();
        public List<EstadosPrendas>? _detallesModificados = new();
        public List<EstadosPrendas>? _detallesBorrados = new();
        public List<EstadosPrendas>? _detallesRegistrar = new();
        public EstadosPrendas? _estadoSeleccionado = null;
        private List<DetallesPrendas>? _detalles = new();
        private Telas? _tela = new Telas();
        private List<Telas>? _telas = new List<Telas>();
        private List<SubCategoriasPrendas>? _subCategorias = new List<SubCategoriasPrendas>();
        private List<CategoriasPrendas>? _categorias = new List<CategoriasPrendas>();
        private Talles talles = new Talles();
        private int cantidadPrendas = 0;
        public int cantidadDetalles = 0;
        List<string>? credenciales = new();
        private List<Proveedores>? proveedores = new();
        bool cambiarCosto = false;
        bool cambiarPrecio = false;
        string codigoMasAlto = "";
        public string precioAnterior = "0";
        public string costoAnterior = "0";
        bool cerrar = false;


        public FrmRegistrarPrenda()
        {

            InitializeComponent();

        }

        public void cargarComboProveedores()
        {
            bindingSourceProveedores.Clear();
            proveedores = PrendasNegocio.getProveedores();
            bindingSourceProveedores.DataSource = proveedores;
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

        private void RegistrarPrenda_Load(object sender, EventArgs e) // Debo corregir este código en capas
        {
            //Pone visible o invisible las columnas editar o borrar si esta en alta
            ConfigurarColumnasSegunModo();

            // Asigna los datos al ComboBox de Proveedores
            cargarComboProveedores();

            // Asigna los datos al ComboBox de Categoria 
            CargarComboCategoriaAlta();

            // Asigna los datos al ComboBox de SubCategoria
            CargarComboSubCategoriaAlta();

            // Asigna los datos al ComboBox de Telas 
            CargarComboTelasAlta();

            if (modoPrenda == EnumModoForm.Alta)
            {
                txtCodigoPrenda.Text = PrendasNegocio.codigoSugerido();
            } else
            {
                cargarPrenda();
            }
            DiseñoUI.diseñoFront(this);
            this.Dock = DockStyle.Fill;
        }

        private void Frm_Shown(object sender, EventArgs e)
        {
            credenciales = LoginUsuario.CredencialesActivas();
            if (!comprobarCredenciales())
            {
                MessageBox.Show("Su usuario no tiene permiso para acceder a esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (cerrar)
            {
                this.Close();
            }
        }

        private void cargarPrenda()
        {
            if (_prenda == null)
            {
                MessageBox.Show("No se puede editar, falta la prenda a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_estadosNoModificados != null && _estadosNoModificados.Count > 0)
            {
                cantidadDetalles = _estadosNoModificados.Where(e => e.EstadoActual != null && 
                                        (e.EstadoActual == "Apta" || e.EstadoActual == "Outlet")).Sum(e => e.CantidadEstado);
                if (cantidadDetalles < _prenda.Cantidad)
                {
                    cantidadDetalles = _prenda.Cantidad;
                } else
                {
                    _prenda.Cantidad = cantidadDetalles;
                }
            }
            try
            {
                txtCodigoPrenda.Text = _prenda.CodigoPrenda;
                txtDescripcionPrenda.Text = _prenda.DescripcionPrenda;
                costoAnterior = _prenda.Costo.ToString();
                txtPrecioCosto.Text = costoAnterior;
                precioAnterior = _prenda.PrecioVenta.ToString();
                txtPrecioVenta.Text = precioAnterior;
                numCantidad.Value = _prenda.Cantidad;
            } catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: \n"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrar = true;
                return;
            }
            
            numCantidad.Enabled = false;

            
            if (_prenda.IdProveedor != null && proveedores != null)
            {
                Proveedores? prov = proveedores.FirstOrDefault(p => p.IdProveedor == _prenda.IdProveedor);
                if (prov != null)
                {
                    bindingSourceProveedores.DataSource = proveedores;
                    comboBoxProveedor.SelectedItem = prov;
                } else
                {
                    prov = new();
                    prov.IdProveedor = _prenda.IdProveedor;
                    Empresas emp = new();
                    emp.RazonSocial = "Desconocido o Inactivo";
                    prov.Empresas = emp;
                    proveedores.Add(prov);
                    bindingSourceProveedores.DataSource = proveedores;
                    comboBoxProveedor.SelectedItem = prov;
                }
            }
            if (_prenda.IdCateSubCate != null && _categoriasSubCategorias != null)
            {
                CategoriaSubCategoria?  cateSubCate = _categoriasSubCategorias.FirstOrDefault(cs => cs.IdCateSubCate == _prenda.IdCateSubCate);
                bindingSourceCategorias.DataSource = _categorias;
                bindingSourceSubCategorias.DataSource = _subCategorias;
                if (cateSubCate != null)
                {

                    if (cateSubCate.CategoriasPrendas != null)
                    {
                        cbxCategoria.SelectedItem = cateSubCate.CategoriasPrendas;
                    }
                    if (cateSubCate.SubCategoriasPrendas != null)
                    {
                        cbxSubCategoria.SelectedItem = cateSubCate.SubCategoriasPrendas;
                    }
                }
            }

            if (_prenda.IdTela != null && _telas != null)
            {
                Telas? tela = _telas.FirstOrDefault(t => t.IdTela == _prenda.IdTela);
                if (tela != null)
                {
                    bindingSourceTelas.DataSource = _telas;
                    cbxTela.SelectedItem = tela;
                } else
                {
                    tela = new();
                    tela.Tela = "Tela No Registrada";
                    tela.IdTela = _prenda.IdTela;
                    _telas.Add(tela);
                    bindingSourceTelas.DataSource = _telas;
                    cbxTela.SelectedItem = tela;
                }
            }
            cargarGrillaDetalles();

        }


        public void cantidadMinima()
        {
            int cantidad = (int)numCantidad.Value;
            if (cantidad < 0)
            {
                numCantidad.Value = 0;
                MessageBox.Show("La cantidad de prendas a registrar no puede ser inferior a 0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cantidad < cantidadDetalles)
            {
                numCantidad.Value = cantidadDetalles;
                MessageBox.Show("La cantidad de prendas a registrar no puede ser inferior a la suma de detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cantidadPrendas = cantidad;
            }
        }

        public void cargarGrillaDetalles()
        {
            //La lista _estados tiene que llegar cargada si o si porque se va a equiparar con _detalles
            _estados = new();

            if (_detallesRegistrar != null && _detallesRegistrar.Count > 0)
            {
                _estados.AddRange(_detallesRegistrar);
                _detalles = _detallesRegistrar.Where(e => e.DetallesPrendas != null).Select(e => e.DetallesPrendas).ToList();
            }
            if (_detallesModificados != null && _detallesModificados.Count > 0)
            {
                _estados.AddRange(_detallesModificados);
            }
            if (_estadosNoModificados != null && _estadosNoModificados.Count > 0)
            {
                _estados.AddRange(_estadosNoModificados);
            }
            string codigoMayor = "";
            int codigoUltimo = 0;
            try
            {
                codigoMayor = _estados.OrderByDescending(e => e.CodigoDetalle).Select(e => e.CodigoDetalle).FirstOrDefault();
                codigoUltimo = int.Parse(codigoMayor) + 1;
            } catch (Exception)
            {
                codigoMayor = _prenda.CodigoPrenda + "1000";
            }
            codigoMasAlto = codigoMayor;

            estadosPrendasBindingSource.DataSource = _estados;
            if (_detalles == null)
            {
                _detalles = _estados.Where(e => e.DetallesPrendas != null && e.EstadoActual != null && e.EstadoActual == "Apta").Select(e => e.DetallesPrendas).ToList();
            }
            int cantidadTotal = 0;
            cantidadTotal = _estados.Sum(e => e.CantidadEstado);
            _prenda.Cantidad = Math.Max(_prenda.Cantidad, cantidadTotal);
            numCantidad.Value = _prenda.Cantidad;

            dataGridView1.Refresh();

        }

        private void limpiarCampos()
        {
            txtCodigoPrenda.Text = "";
            txtDescripcionPrenda.Text = "";
            cantidadDetalles = 0;
            cantidadPrendas = 0;
            numCantidad.Value = 0;
            _detalles = null;
            _estados = new();
            estadosPrendasBindingSource.Clear();
            estadosPrendasBindingSource.DataSource = _estados;
            dataGridView1.Refresh();
            txtCodigoPrenda.Text = PrendasNegocio.codigoSugerido();

        }

        public void CargarComboCategoriaAlta()
        {
            bindingSourceCategorias.Clear();
            _categoriasSubCategorias = new();
            _categoriasSubCategorias = PrendasNegocio.GetCateSubCate();
            _categorias = new();
            CategoriaGenerica();
            _categorias = PrendasNegocio.GetCategorias(_categoriasSubCategorias);
            if (_categorias == null || _categorias.Count == 0)
            {
                bindingSourceCategorias.DataSource = _categoria;
                cbxCategoria.SelectedIndex = 0;
            }
            else
            {
                bindingSourceCategorias.DataSource = _categorias;
                cbxCategoria.SelectedIndex = 0;
            }
        }

        public void CargarComboSubCategoriaAlta()
        {
            _subCategorias = new();
            SubCategoriaGenerica();
            bindingSourceSubCategorias.Clear();
            _categoria = (CategoriasPrendas)cbxCategoria.SelectedItem;
            if (_categoria != null)
            {
                _subCategorias.Clear();
                if (_categoria.IdCategoriaPrenda > 0)
                {
                    _subCategorias = PrendasNegocio.GetSubCategorias(_categoria, _categoriasSubCategorias);
                }
                else
                {
                    bindingSourceSubCategorias.DataSource = _subCategoria;
                }
            }

            if (_subCategorias == null || _subCategorias.Count == 0)
            {
                bindingSourceSubCategorias.DataSource = _subCategoria;
            }
            else
            {
                bindingSourceSubCategorias.DataSource = _subCategorias;
                _subCategoria = (SubCategoriasPrendas)cbxSubCategoria.SelectedItem;
            }
        }

        public void CargarComboTelasAlta()
        {
            TelaGenerica();
            _telas = PrendasNegocio.GetTelas();
            if (_telas == null)
            {
                bindingSourceTelas.DataSource = _tela;
                cbxTela.SelectedIndex = 0;
            }
            else
            {
                if (_telas.Count > 0)
                    bindingSourceTelas.DataSource = _telas;
                else
                    bindingSourceTelas.DataSource = _tela;
                _tela = new();
                _tela = (Telas)cbxTela.SelectedItem;
            }
        }

        private void CambiarComboSubCategoria()
        {
            CargarComboSubCategoriaAlta();
        }

        private void TelaGenerica()
        {
            _tela = new Telas();
            _tela.IdTela = null;
            _tela.Tela = "Sin Datos";
        }

        private void LlenarObjetoTela()
        {
            string texto = cbxTela.Text.Trim();
            _tela = cbxTela.Items.Cast<Telas>().FirstOrDefault(t => t.Tela == texto);
            if (_tela == null && !String.IsNullOrWhiteSpace(texto))
            {
                _tela = new Telas();
                _tela.IdTela = null;
                _tela.Tela = texto;
                return;
            }
            else if (String.IsNullOrWhiteSpace(texto))
                TelaGenerica();
            if (_tela.IdTela == null)
                _prenda.Telas = _tela;
            else
                _prenda.IdTela = _tela.IdTela;
        }

        private void CategoriaGenerica()
        {
            _categoria = new();
            _categoria.IdCategoriaPrenda = 0;
            _categoria.Categoria = " --- ";
        }

        private void SubCategoriaGenerica()
        {
            _subCategoria = new();
            _subCategoria.IdSubCategoriaPrenda = 0;
            _subCategoria.SubCategoria = " --- ";
        }

        private void LlenarObjetosCategoriasSubCategorias()
        {
            CategoriaSubCategoria? nueva = new CategoriaSubCategoria();
            nueva.IdCateSubCate = 0;
            _categoria = (CategoriasPrendas)cbxCategoria.SelectedItem;
            _subCategoria = (SubCategoriasPrendas)cbxSubCategoria.SelectedItem;

            nueva.IdSubCategoriaPrenda = _subCategoria.IdSubCategoriaPrenda;
            if (_categoria.IdCategoriaPrenda == 0)
            {
                nueva.IdCategoriaPrenda = null;
                _categoria.IdCategoriaPrenda = null;
                nueva.CategoriasPrendas = _categoria;
                nueva.IdCateSubCate = null;
            }
            else
            {
                nueva.IdCategoriaPrenda = _categoria.IdCategoriaPrenda;
            }
            if (_subCategoria.IdSubCategoriaPrenda == 0)
            {
                nueva.IdSubCategoriaPrenda = null;
                nueva.IdCateSubCate = null;
                _subCategoria.IdSubCategoriaPrenda = null;
                nueva.SubCategoriasPrendas = _subCategoria;
            }
            else
            {
                nueva.IdSubCategoriaPrenda = _subCategoria.IdSubCategoriaPrenda;
            }

            if (nueva.IdCateSubCate == null)
            {
                _prenda.IdCateSubCate = null;
                _prenda.CategoriaSubCategoria = nueva;
            }
            else
            {
                nueva = new();
                nueva = _categoriasSubCategorias.FirstOrDefault(cs => cs.IdSubCategoriaPrenda == _subCategoria.IdSubCategoriaPrenda
                            && cs.IdCategoriaPrenda == _categoria.IdCategoriaPrenda);
                if (nueva != null)
                    _prenda.IdCateSubCate = nueva.IdCateSubCate;
            }

        }

        //Método para Modificacion
        public void GuardarCambios()
        {
            string mensaje = "";
            //cargo los datos ingresados en un objeto prenda y valido
            if (!ValidarPrenda(ref mensaje))
            {
                MessageBox.Show("Atención: Se encontraron los siguientes errores \n" + mensaje,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPrecioCosto.Text != costoAnterior)
            {
                DialogResult precios = MessageBox.Show("Se ha detectado que cambió el precio de la prenda genérica \n¿Desea aplicarlo a todas las prendas detalladas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                cambiarPrecio = precios == DialogResult.Yes;
            }
            if (txtPrecioVenta.Text != precioAnterior)
            {
                DialogResult costo = MessageBox.Show("Se ha detectado que cambió el costo de la prenda genérica \n¿Desea aplicarlo a todas las prendas detalladas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                cambiarPrecio = costo == DialogResult.Yes;
            }
            
            DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            LlenarObjetosCategoriasSubCategorias();
            LlenarObjetoTela();
            if (!PrendasNegocio.updatePrendas(_prenda, true, cambiarPrecio, cambiarCosto, _detallesModificados, _detallesRegistrar, _detallesBorrados, ref mensaje))
            {
                MessageBox.Show("Error, se presentaron las siguientes dificultades"+mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Se guardaron los cambios exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            limpiarCampos();
        }


        private void btnGuardarPrenda_Click(object sender, EventArgs e)
        {
            if (modoPrenda == EnumModoForm.Alta)
            {
                Guardar();
            } else
            {
                GuardarCambios();
                this.Close();
            }
            
        }

        //Método para registrar nueva
        public void Guardar()
        {

            string mensaje = "";
            string mensajeAcumulador = "";
            //cargo los datos ingresados en un objeto prenda y valido
            if (!ValidarPrenda(ref mensaje))
            {
                MessageBox.Show("Atención: Se encontraron los siguientes errores \n" + mensaje,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            LlenarObjetosCategoriasSubCategorias();
            LlenarObjetoTela();
            if (!InsertarPrenda(ref mensaje))
            {
                MessageBox.Show("Atención: Se encontraron los siguientes errores \n" + mensaje,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                mensaje += mensajeAcumulador;
                limpiarCampos();
            }
            MessageBox.Show("Registro Exitoso ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool ValidarPrenda(ref string mensaje)
        {
            mensaje = "";
            string descripcion = txtDescripcionPrenda.Text.Trim();
            string codigo = txtCodigoPrenda.Text.Trim();
            if (modoPrenda == EnumModoForm.Alta)
            {
                _prenda = new();
            }
            
            _prenda.Cantidad = cantidadPrendas;
            string precioVenta = txtPrecioVenta.Text.Trim();
            string precioCosto = txtPrecioCosto.Text.Trim();

            _prenda.IdProveedor = (int)comboBoxProveedor.SelectedValue;
            if (_prenda.IdProveedor == 0)
            {
                _prenda.IdProveedor = null;
            }


            if (String.IsNullOrWhiteSpace(precioCosto))
                mensaje += "\nError: Falta ingresar el costo de la prenda";
            else
            {
                int costo = Convert.ToInt32(precioCosto);
                cambiarCosto = costo != _prenda.Costo;
                _prenda.Costo = int.Parse(precioCosto);
            }

            if (String.IsNullOrWhiteSpace(precioVenta))
                mensaje += "\nError: Falta ingresar el precio de venta";
            else
            {
                int pvp = Convert.ToInt32(precioVenta);
                cambiarPrecio = pvp != _prenda.PrecioVenta;
                _prenda.PrecioVenta = int.Parse(precioVenta);
            }
            if (String.IsNullOrWhiteSpace(codigo))
                mensaje += "\nError: Codigo Vacío";
            else
                _prenda.CodigoPrenda = codigo;

            if (String.IsNullOrWhiteSpace(descripcion))
                mensaje += "\nError: Descripción Vacía";
            else
                _prenda.DescripcionPrenda = descripcion.ToLower();

            if (!String.IsNullOrEmpty(mensaje))
                return false;

            if (modoPrenda == EnumModoForm.Alta)
            {
                Prendas? nueva = PrendasNegocio.VerificarPrendas(_prenda);
                if (nueva != null)
                {
                    mensaje += "\nError: ya existe una prenda con el código o descripción idénticos";
                    _prenda = null;
                    return false;
                }
            }
            
            mensaje = "";
            return true;
        }

        //Inserciones
        private bool InsertarPrenda(ref string mensaje)
        {
            mensaje = "";
            if (_prenda == null)
            {
                mensaje += "\nError: no se obtuvieron datos de la prenda";
                return false;
            }
            /*
            _prenda.IdSubCategoriaPrenda = (int)_subCategoria.IdSubCategoriaPrenda;
            _prenda.IdTela = (int)_tela.IdTela;
            */
            int resultado = 0;

            resultado = PrendasNegocio.InsertarPrenda(_prenda, _estados);
            if (resultado == 0)
            {
                mensaje += "\nError: Error al Registrar la Prenda";
                return false;
            }
            else
            {
                mensaje = "La prenda se registró correctamente con el ID: " + resultado;
                return true;
            }
        }


        //Validacion que sea número
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelarPrenda_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Funciona cuando cambia la categoria
        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarComboSubCategoria();
        }

        private void btnAgregarDetalles_Click(object sender, EventArgs e)
        {
            if (modoPrenda == EnumModoForm.Alta)
            {
                string mensaje = "";
                if (!ValidarPrenda(ref mensaje))
                {
                    MessageBox.Show("Atención: No se pueden agregar detalles sin solucionar los siguientes errores \n" + mensaje,
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            FrmPrincipal form = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;//para que el form se abra en el principal como hijo.

            if (form == null)
            {
                form = new FrmPrincipal();
            }

            FrmDetallesPrendas abierto = Application.OpenForms.OfType<FrmDetallesPrendas>().FirstOrDefault();
            if (abierto != null)
            {
                abierto.Close();
            }

            FrmDetallesPrendas frmDetalles = new FrmDetallesPrendas();
            frmDetalles._prenda = _prenda;
            frmDetalles._estadosPrendas = _detallesRegistrar ?? new();
            frmDetalles.modo = EnumModoForm.Alta;
            frmDetalles.MdiParent = form;
            frmDetalles.Dock = DockStyle.Fill;

            _detalles = _detallesRegistrar.Select(e => e.DetallesPrendas).ToList();

            if (_detalles != null && _detalles.Count > 0)
            {
                frmDetalles.listadetallesPrendas = _detalles;
            }
            if (modoPrenda == EnumModoForm.Modificacion)
            {
                frmDetalles.codigoAnterior = codigoMasAlto;
            }
            frmDetalles.Show();
        }

        public void volverDeDetalles()
        {
            if (_prenda == null)
            {
                return;
            }
            cargarGrillaDetalles();
        }

        /*
        public void agregarDetallesPrendas()
        {
            Form myForm = Application.OpenForms["FrmDetallesPrendas"] as Form;

            if (myForm == null) // El formulario no está abierto
            {

                FrmDetallesPrendas frmDetalles = new FrmDetallesPrendas();
                frmDetalles._prenda = _prenda;
                frmDetalles.listadetallesPrendas = _detalles;


                FrmPrincipal form = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;//para que el form se abra en el principal como hijo.

                if (form != null)
                {
                    frmDetalles.MdiParent = form;
                    frmDetalles.Dock = DockStyle.Fill;
                }

                if (_detalles != null && _detalles.Count > 0)
                {
                    frmDetalles.listadetallesPrendas = _detalles;
                }
                frmDetalles.Show();
            }
            else if (((FrmDetallesPrendas)myForm).modo == EnumModoForm.Modificacion)
            {
                myForm.Close();

                FrmDetallesPrendas frmDetalles = new FrmDetallesPrendas();
                frmDetalles._prenda = _prenda;
                frmDetalles.listadetallesPrendas = _detalles;


                FrmPrincipal form = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;//para que el form se abra en el principal como hijo.

                if (form != null)
                {
                    frmDetalles.MdiParent = form;
                    frmDetalles.Dock = DockStyle.Fill;
                }

                if (_detalles != null && _detalles.Count > 0)
                {
                    frmDetalles.listadetallesPrendas = _detalles;
                }
                frmDetalles.Show();
            }
            else
            {
                myForm.Focus();
            }
        }
        */

        private void abrirModificarDetalle()
        {
            if (_estadoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un estado a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult res = MessageBox.Show("¿Seguro que quiere editar este detalle?", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            bool removido = false;
            if (_detallesRegistrar != null)
            {
                removido = _detallesRegistrar.Remove(_estadoSeleccionado);
            }
            if (_estadosNoModificados != null)
            {
                removido = _estadosNoModificados.Remove(_estadoSeleccionado);
            }
            if (_detallesModificados != null)
            {
                removido = _detallesModificados.Remove(_estadoSeleccionado);
            } else
            {
                _detallesModificados = new();
            }
            if (_estados != null)
            {
                removido = _estados.Remove(_estadoSeleccionado);
            }
            if (!removido)
            {
                MessageBox.Show("Ha ocurrido un error moviendo el detalle a la lista para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmPrincipal padre = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (padre == null)
            {
                padre = new FrmPrincipal();
            }
            FrmDetallesPrendas abierto = Application.OpenForms.OfType<FrmDetallesPrendas>().FirstOrDefault();
            if (abierto != null)
            {
                abierto.Close();
            }

            FrmDetallesPrendas detalles = new FrmDetallesPrendas();
            detalles._prenda = _prenda;
            detalles.modo = EnumModoForm.Modificacion;
            detalles.MdiParent = padre;
            detalles.Dock = DockStyle.Fill;
            detalles._estadosPrendas = _detallesModificados;
            detalles._estadoModificacion = _estadoSeleccionado;
            detalles.Show();
            return;
        }

        private void eliminarDetalle()
        {
            if (_estadoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un estado a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult res = MessageBox.Show("Si está ligado a una venta solo se anulará\n¿Seguro que quiere eliminar este detalle?", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            bool eraNuevo = false;
            bool removido = false;
            if (_detallesRegistrar != null)
            {
                removido = _detallesRegistrar.Remove(_estadoSeleccionado);
                if (removido)
                {
                    eraNuevo = true;
                }
            }
            if (_estadosNoModificados != null)
            {
                removido = _estadosNoModificados.Remove(_estadoSeleccionado);  
            }
            if (_detallesModificados != null)
            {
                removido = _detallesModificados.Remove(_estadoSeleccionado);
            }
            if (_estados != null)
            {
                removido = _estados.Remove(_estadoSeleccionado);
            }
            if (!removido)
            {
                MessageBox.Show("Ha ocurrido un error eliminando el detalle de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_detallesBorrados == null)
            {
                _detallesBorrados = new();
            }
            if (!eraNuevo)
            {
                _detallesBorrados.Add(_estadoSeleccionado);
            }
            
            cargarGrillaDetalles();
        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            cantidadMinima();
        }

        private void ConfigurarColumnasSegunModo()
        {
            dataGridView1.Columns["Modificar"].Visible = modoPrenda != EnumModoForm.Alta;
            dataGridView1.Columns["Eliminar"].Visible = modoPrenda != EnumModoForm.Alta;
        }


        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (modoPrenda == EnumModoForm.Alta)
            {
                return;
            }
            string rutaLapiz = Path.Combine(Application.StartupPath, @"..\..\..\Resources\lapiz.png");
            Image lapiz = Image.FromFile(rutaLapiz);

            string rutaCesto = Path.Combine(Application.StartupPath, @"..\..\..\Resources\cesto.png");
            Image cesto = Image.FromFile(rutaCesto);

            if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index)
            {
                if (e.RowIndex == currentMouseOverRow)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    // Calcula la posición para centrar la imagen en la celda
                    Point pt = new Point(e.CellBounds.Location.X + (e.CellBounds.Width - lapiz.Width) / 2,
                                         e.CellBounds.Location.Y + (e.CellBounds.Height - lapiz.Height) / 2);

                    // Dibuja la imagen en la celda
                    e.Graphics.DrawImage(lapiz, pt);
                    e.Handled = true;
                }

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index && e.RowIndex != currentMouseOverRow)
            {
                // No dibuja nada, efectivamente haciendo que el botón sea 'invisible'
                e.Handled = true;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
            {
                if (e.RowIndex == currentMouseOverRow)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    // Calcula la posición para centrar la imagen en la celda
                    Point pt = new Point(e.CellBounds.Location.X + (e.CellBounds.Width - cesto.Width) / 2,
                                         e.CellBounds.Location.Y + (e.CellBounds.Height - cesto.Height) / 2);

                    // Dibuja la imagen en la celda
                    e.Graphics.DrawImage(cesto, pt);
                    e.Handled = true;
                }

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex != currentMouseOverRow)
            {
                // No dibuja nada, efectivamente haciendo que el botón sea 'invisible'
                e.Handled = true;
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el mouse esté sobre una fila válida
            if (e.RowIndex >= 0)
            {
                currentMouseOverRow = e.RowIndex;
                // Redibuja la fila para mostrar el botón
                dataGridView1.InvalidateRow(e.RowIndex);
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el mouse esté saliendo de una fila válida
            if (e.RowIndex >= 0)
            {
                currentMouseOverRow = -1;
                // Redibuja la fila para ocultar el botón
                dataGridView1.InvalidateRow(e.RowIndex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic sea en la columna 'Modificar' y en una fila válida
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Modificar")
            {
                // Obtiene el objeto Personas asociado con la fila seleccionada

                _estadoSeleccionado = (EstadosPrendas)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                abrirModificarDetalle();
                return;
            }
            // Lo miidmo con eliminar
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // Obtiene el objeto Personas asociado con la fila seleccionada

                _estadoSeleccionado = (EstadosPrendas)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                eliminarDetalle();
                return;
            }
        }
    }
}
