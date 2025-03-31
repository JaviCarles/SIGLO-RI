namespace RingoFront
{
    partial class FrmRegistrarPrenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnCancelarPrenda = new Button();
            label1 = new Label();
            txtCodigoPrenda = new TextBox();
            label2 = new Label();
            cbxCategoria = new ComboBox();
            bindingSourceCategorias = new BindingSource(components);
            label3 = new Label();
            cbxTela = new ComboBox();
            bindingSourceTelas = new BindingSource(components);
            label4 = new Label();
            btnGuardarPrenda = new Button();
            bindingSourceSubCategorias = new BindingSource(components);
            label6 = new Label();
            cbxSubCategoria = new ComboBox();
            txtDescripcionPrenda = new TextBox();
            dataGridView1 = new DataGridView();
            Eliminar = new DataGridViewButtonColumn();
            Modificar = new DataGridViewButtonColumn();
            codigoDetalleDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cantidadEstadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            colorDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            descripcionTalleDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nroTalleDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            precioVentaDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            costoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoActualDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadosPrendasBindingSource = new BindingSource(components);
            lblDetalles = new Label();
            label5 = new Label();
            numCantidad = new NumericUpDown();
            btnAgregarDetalles = new Button();
            label7 = new Label();
            label8 = new Label();
            txtPrecioVenta = new TextBox();
            txtPrecioCosto = new TextBox();
            label9 = new Label();
            idDetallePrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idPrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idTalleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codigoDetalleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioVentaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            colorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadPrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            costoPrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            talleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nroTalleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descripcionTalleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codigoPrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descripcionPrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            label10 = new Label();
            comboBoxProveedor = new ComboBox();
            bindingSourceProveedores = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bindingSourceCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTelas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceSubCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)estadosPrendasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProveedores).BeginInit();
            SuspendLayout();
            // 
            // btnCancelarPrenda
            // 
            btnCancelarPrenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelarPrenda.BackColor = SystemColors.ActiveCaption;
            btnCancelarPrenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelarPrenda.Location = new Point(1098, 683);
            btnCancelarPrenda.Margin = new Padding(4, 3, 4, 3);
            btnCancelarPrenda.Name = "btnCancelarPrenda";
            btnCancelarPrenda.Size = new Size(229, 38);
            btnCancelarPrenda.TabIndex = 8;
            btnCancelarPrenda.Text = "CANCELAR";
            btnCancelarPrenda.UseVisualStyleBackColor = false;
            btnCancelarPrenda.Click += btnCancelarPrenda_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(68, 64);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 21);
            label1.TabIndex = 1;
            label1.Text = "CÓDIGO GENÉRICO";
            // 
            // txtCodigoPrenda
            // 
            txtCodigoPrenda.Enabled = false;
            txtCodigoPrenda.Font = new Font("Segoe UI", 12F);
            txtCodigoPrenda.ForeColor = SystemColors.WindowText;
            txtCodigoPrenda.Location = new Point(72, 96);
            txtCodigoPrenda.Margin = new Padding(4, 3, 4, 3);
            txtCodigoPrenda.Name = "txtCodigoPrenda";
            txtCodigoPrenda.Size = new Size(236, 29);
            txtCodigoPrenda.TabIndex = 1;
            txtCodigoPrenda.KeyPress += NumericTextBox_KeyPress;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Cooper Black", 12F);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(601, 67);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 19);
            label2.TabIndex = 3;
            label2.Text = "CATEGORIA";
            // 
            // cbxCategoria
            // 
            cbxCategoria.Anchor = AnchorStyles.Top;
            cbxCategoria.DataSource = bindingSourceCategorias;
            cbxCategoria.DisplayMember = "Categoria";
            cbxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCategoria.Font = new Font("Segoe UI", 12F);
            cbxCategoria.FormattingEnabled = true;
            cbxCategoria.ItemHeight = 21;
            cbxCategoria.Location = new Point(604, 96);
            cbxCategoria.Margin = new Padding(4, 3, 4, 3);
            cbxCategoria.Name = "cbxCategoria";
            cbxCategoria.Size = new Size(236, 29);
            cbxCategoria.TabIndex = 2;
            cbxCategoria.ValueMember = "IdCategoriaPrenda";
            cbxCategoria.SelectedIndexChanged += cbxCategoria_SelectedIndexChanged;
            // 
            // bindingSourceCategorias
            // 
            bindingSourceCategorias.DataSource = typeof(RingoEntidades.CategoriasPrendas);
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(600, 253);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(47, 21);
            label3.TabIndex = 5;
            label3.Text = "TELA";
            // 
            // cbxTela
            // 
            cbxTela.Anchor = AnchorStyles.Top;
            cbxTela.DataSource = bindingSourceTelas;
            cbxTela.DisplayMember = "Tela";
            cbxTela.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTela.Font = new Font("Segoe UI", 12F);
            cbxTela.FormattingEnabled = true;
            cbxTela.Location = new Point(604, 286);
            cbxTela.Margin = new Padding(4, 3, 4, 3);
            cbxTela.Name = "cbxTela";
            cbxTela.Size = new Size(236, 29);
            cbxTela.TabIndex = 3;
            cbxTela.ValueMember = "IdTela";
            // 
            // bindingSourceTelas
            // 
            bindingSourceTelas.DataSource = typeof(RingoEntidades.Telas);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(70, 160);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(115, 21);
            label4.TabIndex = 6;
            label4.Text = "DESCRIPCIÓN";
            // 
            // btnGuardarPrenda
            // 
            btnGuardarPrenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardarPrenda.BackColor = SystemColors.ActiveCaption;
            btnGuardarPrenda.BackgroundImageLayout = ImageLayout.Stretch;
            btnGuardarPrenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardarPrenda.Location = new Point(72, 683);
            btnGuardarPrenda.Margin = new Padding(4, 3, 4, 3);
            btnGuardarPrenda.Name = "btnGuardarPrenda";
            btnGuardarPrenda.Size = new Size(229, 38);
            btnGuardarPrenda.TabIndex = 7;
            btnGuardarPrenda.Text = "GUARDAR";
            btnGuardarPrenda.UseVisualStyleBackColor = false;
            btnGuardarPrenda.Click += btnGuardarPrenda_Click;
            // 
            // bindingSourceSubCategorias
            // 
            bindingSourceSubCategorias.DataSource = typeof(RingoEntidades.SubCategoriasPrendas);
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(600, 158);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(128, 21);
            label6.TabIndex = 10;
            label6.Text = "SUBCATEGORIA";
            // 
            // cbxSubCategoria
            // 
            cbxSubCategoria.Anchor = AnchorStyles.Top;
            cbxSubCategoria.DataSource = bindingSourceSubCategorias;
            cbxSubCategoria.DisplayMember = "SubCategoria";
            cbxSubCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSubCategoria.Font = new Font("Segoe UI", 12F);
            cbxSubCategoria.FormattingEnabled = true;
            cbxSubCategoria.ItemHeight = 21;
            cbxSubCategoria.Location = new Point(604, 190);
            cbxSubCategoria.Margin = new Padding(4, 3, 4, 3);
            cbxSubCategoria.Name = "cbxSubCategoria";
            cbxSubCategoria.Size = new Size(236, 29);
            cbxSubCategoria.TabIndex = 9;
            cbxSubCategoria.ValueMember = "IdSubCategoriaPrenda";
            // 
            // txtDescripcionPrenda
            // 
            txtDescripcionPrenda.Font = new Font("Segoe UI", 12F);
            txtDescripcionPrenda.Location = new Point(74, 192);
            txtDescripcionPrenda.Margin = new Padding(4, 3, 4, 3);
            txtDescripcionPrenda.Multiline = true;
            txtDescripcionPrenda.Name = "txtDescripcionPrenda";
            txtDescripcionPrenda.Size = new Size(406, 193);
            txtDescripcionPrenda.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Eliminar, Modificar, codigoDetalleDataGridViewTextBoxColumn1, cantidadEstadoDataGridViewTextBoxColumn, colorDataGridViewTextBoxColumn1, descripcionTalleDataGridViewTextBoxColumn1, nroTalleDataGridViewTextBoxColumn1, precioVentaDataGridViewTextBoxColumn1, costoDataGridViewTextBoxColumn, estadoActualDataGridViewTextBoxColumn });
            dataGridView1.DataSource = estadosPrendasBindingSource;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Cooper Black", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(72, 445);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Cooper Black", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 30;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Font = new Font("Cooper Black", 7.9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Size = new Size(1256, 211);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;
            dataGridView1.CellMouseLeave += dataGridView1_CellMouseLeave;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            // 
            // Eliminar
            // 
            Eliminar.FillWeight = 1F;
            Eliminar.HeaderText = "";
            Eliminar.MinimumWidth = 40;
            Eliminar.Name = "Eliminar";
            Eliminar.ReadOnly = true;
            // 
            // Modificar
            // 
            Modificar.FillWeight = 1F;
            Modificar.HeaderText = "";
            Modificar.MinimumWidth = 40;
            Modificar.Name = "Modificar";
            Modificar.ReadOnly = true;
            // 
            // codigoDetalleDataGridViewTextBoxColumn1
            // 
            codigoDetalleDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            codigoDetalleDataGridViewTextBoxColumn1.DataPropertyName = "CodigoDetalle";
            codigoDetalleDataGridViewTextBoxColumn1.FillWeight = 10F;
            codigoDetalleDataGridViewTextBoxColumn1.HeaderText = "Codigo";
            codigoDetalleDataGridViewTextBoxColumn1.MinimumWidth = 80;
            codigoDetalleDataGridViewTextBoxColumn1.Name = "codigoDetalleDataGridViewTextBoxColumn1";
            codigoDetalleDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cantidadEstadoDataGridViewTextBoxColumn
            // 
            cantidadEstadoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cantidadEstadoDataGridViewTextBoxColumn.DataPropertyName = "CantidadEstado";
            cantidadEstadoDataGridViewTextBoxColumn.FillWeight = 10F;
            cantidadEstadoDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadEstadoDataGridViewTextBoxColumn.MinimumWidth = 60;
            cantidadEstadoDataGridViewTextBoxColumn.Name = "cantidadEstadoDataGridViewTextBoxColumn";
            cantidadEstadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn1
            // 
            colorDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colorDataGridViewTextBoxColumn1.DataPropertyName = "Color";
            colorDataGridViewTextBoxColumn1.FillWeight = 15F;
            colorDataGridViewTextBoxColumn1.HeaderText = "Color";
            colorDataGridViewTextBoxColumn1.MinimumWidth = 100;
            colorDataGridViewTextBoxColumn1.Name = "colorDataGridViewTextBoxColumn1";
            colorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // descripcionTalleDataGridViewTextBoxColumn1
            // 
            descripcionTalleDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descripcionTalleDataGridViewTextBoxColumn1.DataPropertyName = "DescripcionTalle";
            descripcionTalleDataGridViewTextBoxColumn1.FillWeight = 15F;
            descripcionTalleDataGridViewTextBoxColumn1.HeaderText = "Talle";
            descripcionTalleDataGridViewTextBoxColumn1.MinimumWidth = 100;
            descripcionTalleDataGridViewTextBoxColumn1.Name = "descripcionTalleDataGridViewTextBoxColumn1";
            descripcionTalleDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nroTalleDataGridViewTextBoxColumn1
            // 
            nroTalleDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nroTalleDataGridViewTextBoxColumn1.DataPropertyName = "NroTalle";
            nroTalleDataGridViewTextBoxColumn1.FillWeight = 10F;
            nroTalleDataGridViewTextBoxColumn1.HeaderText = "NroTalle";
            nroTalleDataGridViewTextBoxColumn1.MinimumWidth = 70;
            nroTalleDataGridViewTextBoxColumn1.Name = "nroTalleDataGridViewTextBoxColumn1";
            nroTalleDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // precioVentaDataGridViewTextBoxColumn1
            // 
            precioVentaDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            precioVentaDataGridViewTextBoxColumn1.DataPropertyName = "PrecioVenta";
            precioVentaDataGridViewTextBoxColumn1.FillWeight = 13F;
            precioVentaDataGridViewTextBoxColumn1.HeaderText = "Precio Venta";
            precioVentaDataGridViewTextBoxColumn1.MinimumWidth = 80;
            precioVentaDataGridViewTextBoxColumn1.Name = "precioVentaDataGridViewTextBoxColumn1";
            precioVentaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // costoDataGridViewTextBoxColumn
            // 
            costoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            costoDataGridViewTextBoxColumn.DataPropertyName = "Costo";
            costoDataGridViewTextBoxColumn.FillWeight = 12F;
            costoDataGridViewTextBoxColumn.HeaderText = "Costo";
            costoDataGridViewTextBoxColumn.MinimumWidth = 80;
            costoDataGridViewTextBoxColumn.Name = "costoDataGridViewTextBoxColumn";
            costoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoActualDataGridViewTextBoxColumn
            // 
            estadoActualDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            estadoActualDataGridViewTextBoxColumn.DataPropertyName = "EstadoActual";
            estadoActualDataGridViewTextBoxColumn.FillWeight = 15F;
            estadoActualDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoActualDataGridViewTextBoxColumn.MinimumWidth = 100;
            estadoActualDataGridViewTextBoxColumn.Name = "estadoActualDataGridViewTextBoxColumn";
            estadoActualDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadosPrendasBindingSource
            // 
            estadosPrendasBindingSource.DataSource = typeof(RingoEntidades.EstadosPrendas);
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.BackColor = Color.Transparent;
            lblDetalles.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDetalles.ForeColor = Color.Transparent;
            lblDetalles.Location = new Point(66, 403);
            lblDetalles.Margin = new Padding(4, 0, 4, 0);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(113, 30);
            lblDetalles.TabIndex = 12;
            lblDetalles.Text = "DETALLES";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(1086, 254);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 21);
            label5.TabIndex = 13;
            label5.Text = "CANTIDAD";
            // 
            // numCantidad
            // 
            numCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            numCantidad.Location = new Point(1092, 288);
            numCantidad.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(236, 29);
            numCantidad.TabIndex = 14;
            numCantidad.ValueChanged += numCantidad_ValueChanged;
            // 
            // btnAgregarDetalles
            // 
            btnAgregarDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarDetalles.BackColor = SystemColors.ActiveCaption;
            btnAgregarDetalles.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregarDetalles.Location = new Point(1091, 378);
            btnAgregarDetalles.Margin = new Padding(4, 3, 4, 3);
            btnAgregarDetalles.Name = "btnAgregarDetalles";
            btnAgregarDetalles.Size = new Size(237, 42);
            btnAgregarDetalles.TabIndex = 15;
            btnAgregarDetalles.Text = "AGREGAR DETALLES";
            btnAgregarDetalles.UseVisualStyleBackColor = false;
            btnAgregarDetalles.Click += btnAgregarDetalles_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(1080, 158);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(138, 21);
            label7.TabIndex = 16;
            label7.Text = " PRECIO COSTO $";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(1086, 62);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(135, 21);
            label8.TabIndex = 17;
            label8.Text = "PRECIO VENTA $";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrecioVenta.Font = new Font("Segoe UI", 12F);
            txtPrecioVenta.Location = new Point(1091, 96);
            txtPrecioVenta.Margin = new Padding(4, 3, 4, 3);
            txtPrecioVenta.MaxLength = 10;
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(236, 29);
            txtPrecioVenta.TabIndex = 18;
            txtPrecioVenta.KeyPress += NumericTextBox_KeyPress;
            // 
            // txtPrecioCosto
            // 
            txtPrecioCosto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrecioCosto.Font = new Font("Segoe UI", 12F);
            txtPrecioCosto.Location = new Point(1091, 192);
            txtPrecioCosto.Margin = new Padding(4, 3, 4, 3);
            txtPrecioCosto.MaxLength = 10;
            txtPrecioCosto.Name = "txtPrecioCosto";
            txtPrecioCosto.Size = new Size(236, 29);
            txtPrecioCosto.TabIndex = 19;
            txtPrecioCosto.KeyPress += NumericTextBox_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label9.Location = new Point(31, 19);
            label9.Name = "label9";
            label9.Size = new Size(158, 19);
            label9.TabIndex = 20;
            label9.Text = "AGREGAR PRENDAS";
            // 
            // idDetallePrendaDataGridViewTextBoxColumn
            // 
            idDetallePrendaDataGridViewTextBoxColumn.DataPropertyName = "IdDetallePrenda";
            idDetallePrendaDataGridViewTextBoxColumn.HeaderText = "IdDetallePrenda";
            idDetallePrendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDetallePrendaDataGridViewTextBoxColumn.Name = "idDetallePrendaDataGridViewTextBoxColumn";
            idDetallePrendaDataGridViewTextBoxColumn.Width = 90;
            // 
            // idPrendaDataGridViewTextBoxColumn
            // 
            idPrendaDataGridViewTextBoxColumn.DataPropertyName = "IdPrenda";
            idPrendaDataGridViewTextBoxColumn.HeaderText = "IdPrenda";
            idPrendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            idPrendaDataGridViewTextBoxColumn.Name = "idPrendaDataGridViewTextBoxColumn";
            idPrendaDataGridViewTextBoxColumn.Width = 89;
            // 
            // idTalleDataGridViewTextBoxColumn
            // 
            idTalleDataGridViewTextBoxColumn.DataPropertyName = "IdTalle";
            idTalleDataGridViewTextBoxColumn.HeaderText = "IdTalle";
            idTalleDataGridViewTextBoxColumn.MinimumWidth = 6;
            idTalleDataGridViewTextBoxColumn.Name = "idTalleDataGridViewTextBoxColumn";
            idTalleDataGridViewTextBoxColumn.Width = 90;
            // 
            // codigoDetalleDataGridViewTextBoxColumn
            // 
            codigoDetalleDataGridViewTextBoxColumn.DataPropertyName = "CodigoDetalle";
            codigoDetalleDataGridViewTextBoxColumn.HeaderText = "CodigoDetalle";
            codigoDetalleDataGridViewTextBoxColumn.MinimumWidth = 6;
            codigoDetalleDataGridViewTextBoxColumn.Name = "codigoDetalleDataGridViewTextBoxColumn";
            codigoDetalleDataGridViewTextBoxColumn.Width = 89;
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            precioVentaDataGridViewTextBoxColumn.DataPropertyName = "PrecioVenta";
            precioVentaDataGridViewTextBoxColumn.HeaderText = "PrecioVenta";
            precioVentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            precioVentaDataGridViewTextBoxColumn.Width = 90;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            colorDataGridViewTextBoxColumn.HeaderText = "Color";
            colorDataGridViewTextBoxColumn.MinimumWidth = 6;
            colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            colorDataGridViewTextBoxColumn.Width = 89;
            // 
            // cantidadPrendaDataGridViewTextBoxColumn
            // 
            cantidadPrendaDataGridViewTextBoxColumn.DataPropertyName = "CantidadPrenda";
            cantidadPrendaDataGridViewTextBoxColumn.HeaderText = "CantidadPrenda";
            cantidadPrendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadPrendaDataGridViewTextBoxColumn.Name = "cantidadPrendaDataGridViewTextBoxColumn";
            cantidadPrendaDataGridViewTextBoxColumn.Width = 90;
            // 
            // costoPrendaDataGridViewTextBoxColumn
            // 
            costoPrendaDataGridViewTextBoxColumn.DataPropertyName = "CostoPrenda";
            costoPrendaDataGridViewTextBoxColumn.HeaderText = "CostoPrenda";
            costoPrendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            costoPrendaDataGridViewTextBoxColumn.Name = "costoPrendaDataGridViewTextBoxColumn";
            costoPrendaDataGridViewTextBoxColumn.Width = 89;
            // 
            // prendaDataGridViewTextBoxColumn
            // 
            prendaDataGridViewTextBoxColumn.DataPropertyName = "Prenda";
            prendaDataGridViewTextBoxColumn.HeaderText = "Prenda";
            prendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            prendaDataGridViewTextBoxColumn.Name = "prendaDataGridViewTextBoxColumn";
            prendaDataGridViewTextBoxColumn.Width = 90;
            // 
            // talleDataGridViewTextBoxColumn
            // 
            talleDataGridViewTextBoxColumn.DataPropertyName = "Talle";
            talleDataGridViewTextBoxColumn.HeaderText = "Talle";
            talleDataGridViewTextBoxColumn.MinimumWidth = 6;
            talleDataGridViewTextBoxColumn.Name = "talleDataGridViewTextBoxColumn";
            talleDataGridViewTextBoxColumn.Width = 89;
            // 
            // nroTalleDataGridViewTextBoxColumn
            // 
            nroTalleDataGridViewTextBoxColumn.DataPropertyName = "NroTalle";
            nroTalleDataGridViewTextBoxColumn.HeaderText = "NroTalle";
            nroTalleDataGridViewTextBoxColumn.MinimumWidth = 6;
            nroTalleDataGridViewTextBoxColumn.Name = "nroTalleDataGridViewTextBoxColumn";
            nroTalleDataGridViewTextBoxColumn.ReadOnly = true;
            nroTalleDataGridViewTextBoxColumn.Width = 90;
            // 
            // descripcionTalleDataGridViewTextBoxColumn
            // 
            descripcionTalleDataGridViewTextBoxColumn.DataPropertyName = "DescripcionTalle";
            descripcionTalleDataGridViewTextBoxColumn.HeaderText = "DescripcionTalle";
            descripcionTalleDataGridViewTextBoxColumn.MinimumWidth = 6;
            descripcionTalleDataGridViewTextBoxColumn.Name = "descripcionTalleDataGridViewTextBoxColumn";
            descripcionTalleDataGridViewTextBoxColumn.ReadOnly = true;
            descripcionTalleDataGridViewTextBoxColumn.Width = 89;
            // 
            // codigoPrendaDataGridViewTextBoxColumn
            // 
            codigoPrendaDataGridViewTextBoxColumn.DataPropertyName = "CodigoPrenda";
            codigoPrendaDataGridViewTextBoxColumn.HeaderText = "CodigoPrenda";
            codigoPrendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            codigoPrendaDataGridViewTextBoxColumn.Name = "codigoPrendaDataGridViewTextBoxColumn";
            codigoPrendaDataGridViewTextBoxColumn.ReadOnly = true;
            codigoPrendaDataGridViewTextBoxColumn.Width = 90;
            // 
            // descripcionPrendaDataGridViewTextBoxColumn
            // 
            descripcionPrendaDataGridViewTextBoxColumn.DataPropertyName = "DescripcionPrenda";
            descripcionPrendaDataGridViewTextBoxColumn.HeaderText = "DescripcionPrenda";
            descripcionPrendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            descripcionPrendaDataGridViewTextBoxColumn.Name = "descripcionPrendaDataGridViewTextBoxColumn";
            descripcionPrendaDataGridViewTextBoxColumn.ReadOnly = true;
            descripcionPrendaDataGridViewTextBoxColumn.Width = 89;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label10.Location = new Point(601, 347);
            label10.Name = "label10";
            label10.Size = new Size(97, 20);
            label10.TabIndex = 21;
            label10.Text = "PROVEEDOR";
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.Anchor = AnchorStyles.Top;
            comboBoxProveedor.DataSource = bindingSourceProveedores;
            comboBoxProveedor.DisplayMember = "RazonSocial";
            comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProveedor.Font = new Font("Segoe UI", 12F);
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Location = new Point(604, 384);
            comboBoxProveedor.Margin = new Padding(4, 3, 4, 3);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(236, 29);
            comboBoxProveedor.TabIndex = 22;
            comboBoxProveedor.ValueMember = "idEmpresa";
            // 
            // bindingSourceProveedores
            // 
            bindingSourceProveedores.DataSource = typeof(RingoEntidades.Proveedores);
            // 
            // FrmRegistrarPrenda
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1402, 768);
            ControlBox = false;
            Controls.Add(comboBoxProveedor);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtPrecioCosto);
            Controls.Add(txtPrecioVenta);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnAgregarDetalles);
            Controls.Add(numCantidad);
            Controls.Add(label5);
            Controls.Add(lblDetalles);
            Controls.Add(dataGridView1);
            Controls.Add(cbxSubCategoria);
            Controls.Add(label6);
            Controls.Add(btnGuardarPrenda);
            Controls.Add(txtDescripcionPrenda);
            Controls.Add(label4);
            Controls.Add(cbxTela);
            Controls.Add(label3);
            Controls.Add(cbxCategoria);
            Controls.Add(label2);
            Controls.Add(txtCodigoPrenda);
            Controls.Add(label1);
            Controls.Add(btnCancelarPrenda);
            DoubleBuffered = true;
            Font = new Font("Cooper Black", 9F);
            ForeColor = Color.Transparent;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistrarPrenda";
            StartPosition = FormStartPosition.CenterParent;
            Text = "REGISTRAR PRENDA";
            Load += RegistrarPrenda_Load;
            Shown += Frm_Shown;
            ((System.ComponentModel.ISupportInitialize)bindingSourceCategorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTelas).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceSubCategorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)estadosPrendasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarPrenda;
        private Label label1;
        private TextBox txtCodigoPrenda;
        private Label label2;
        internal ComboBox cbxCategoria;
        private Label label3;
        private ComboBox cbxTela;
        private Label label4;
        private Button btnGuardarPrenda;
        private BindingSource bindingSourceTelas;
        internal BindingSource bindingSourceCategorias;
        internal BindingSource bindingSourceSubCategorias;
        private Label label6;
        private ComboBox cbxSubCategoria;
        private TextBox txtDescripcionPrenda;
        private DataGridView dataGridView1;
        private Label lblDetalles;
        private Label label5;
        private NumericUpDown numCantidad;
        private Button btnAgregarDetalles;
        private Label label7;
        private Label label8;
        private TextBox txtPrecioVenta;
        private TextBox txtPrecioCosto;
        private Label label9;
        private DataGridViewTextBoxColumn idDetallePrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idPrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idTalleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codigoDetalleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadPrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn costoPrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn talleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nroTalleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionTalleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codigoPrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionPrendaDataGridViewTextBoxColumn;
        private Label label10;
        private ComboBox comboBoxProveedor;
        private BindingSource bindingSourceProveedores;
        private BindingSource estadosPrendasBindingSource;
        private DataGridViewButtonColumn Eliminar;
        private DataGridViewButtonColumn Modificar;
        private DataGridViewTextBoxColumn codigoDetalleDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cantidadEstadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn descripcionTalleDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nroTalleDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoActualDataGridViewTextBoxColumn;
    }
}