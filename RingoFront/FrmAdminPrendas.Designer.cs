namespace RingoFront
{
    partial class FrmAdminPrendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminPrendas));
            labelAdminPrendas = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dataGridViewPrenda = new DataGridView();
            codigoPrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descripcionPrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            IdPrenda = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            SubCategoria = new DataGridViewTextBoxColumn();
            TelaPrenda = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            nombreProveedor = new DataGridViewTextBoxColumn();
            bindingSourcePrendas = new BindingSource(components);
            bindingSourceDetallesPrenda = new BindingSource(components);
            btnEditar = new Button();
            label2 = new Label();
            dataGridViewDetallesPrenda = new DataGridView();
            codigoDetalleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadEstadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            colorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descripcionTalleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            observacionesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            costoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioVentaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoActualDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSourceEstados = new BindingSource(components);
            checkStock = new CheckBox();
            btnSalir = new Button();
            idDetallePrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idPrendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idTalleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            talleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codigoPrendaDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            btnVenta = new Button();
            btnListadoXls = new Button();
            btnPdf = new Button();
            btnAnomalia = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcePrendas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetallesPrenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetallesPrenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceEstados).BeginInit();
            SuspendLayout();
            // 
            // labelAdminPrendas
            // 
            labelAdminPrendas.AutoSize = true;
            labelAdminPrendas.BackColor = Color.Transparent;
            labelAdminPrendas.Font = new Font("Rockwell", 12F, FontStyle.Bold);
            labelAdminPrendas.Location = new Point(65, 9);
            labelAdminPrendas.Name = "labelAdminPrendas";
            labelAdminPrendas.Size = new Size(249, 24);
            labelAdminPrendas.TabIndex = 0;
            labelAdminPrendas.Text = "Administración Prendas";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 14F);
            txtBuscar.Location = new Point(66, 63);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar...";
            txtBuscar.Size = new Size(717, 39);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscar.Location = new Point(811, 61);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(39, 39);
            btnBuscar.TabIndex = 2;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += buscarPrenda;
            // 
            // dataGridViewPrenda
            // 
            dataGridViewPrenda.AllowUserToAddRows = false;
            dataGridViewPrenda.AllowUserToDeleteRows = false;
            dataGridViewPrenda.AllowUserToOrderColumns = true;
            dataGridViewPrenda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewPrenda.AutoGenerateColumns = false;
            dataGridViewPrenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPrenda.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewPrenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPrenda.Columns.AddRange(new DataGridViewColumn[] { codigoPrendaDataGridViewTextBoxColumn, descripcionPrendaDataGridViewTextBoxColumn, IdPrenda, Categoria, SubCategoria, TelaPrenda, Cantidad, nombreProveedor });
            dataGridViewPrenda.DataSource = bindingSourcePrendas;
            dataGridViewPrenda.GridColor = SystemColors.AppWorkspace;
            dataGridViewPrenda.Location = new Point(66, 117);
            dataGridViewPrenda.Name = "dataGridViewPrenda";
            dataGridViewPrenda.ReadOnly = true;
            dataGridViewPrenda.RowHeadersVisible = false;
            dataGridViewPrenda.RowHeadersWidth = 51;
            dataGridViewPrenda.Size = new Size(1264, 308);
            dataGridViewPrenda.TabIndex = 3;
            dataGridViewPrenda.SelectionChanged += dataGridViewPrenda_SelectionChanged;
            // 
            // codigoPrendaDataGridViewTextBoxColumn
            // 
            codigoPrendaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            codigoPrendaDataGridViewTextBoxColumn.DataPropertyName = "CodigoPrenda";
            codigoPrendaDataGridViewTextBoxColumn.FillWeight = 8F;
            codigoPrendaDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoPrendaDataGridViewTextBoxColumn.MinimumWidth = 70;
            codigoPrendaDataGridViewTextBoxColumn.Name = "codigoPrendaDataGridViewTextBoxColumn";
            codigoPrendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionPrendaDataGridViewTextBoxColumn
            // 
            descripcionPrendaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descripcionPrendaDataGridViewTextBoxColumn.DataPropertyName = "DescripcionPrenda";
            descripcionPrendaDataGridViewTextBoxColumn.FillWeight = 20F;
            descripcionPrendaDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            descripcionPrendaDataGridViewTextBoxColumn.MinimumWidth = 180;
            descripcionPrendaDataGridViewTextBoxColumn.Name = "descripcionPrendaDataGridViewTextBoxColumn";
            descripcionPrendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // IdPrenda
            // 
            IdPrenda.DataPropertyName = "IdPrenda";
            IdPrenda.HeaderText = "IdPrenda";
            IdPrenda.MinimumWidth = 6;
            IdPrenda.Name = "IdPrenda";
            IdPrenda.ReadOnly = true;
            IdPrenda.Visible = false;
            // 
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Categoria.DataPropertyName = "Categoria";
            Categoria.FillWeight = 15F;
            Categoria.HeaderText = "Categoria";
            Categoria.MinimumWidth = 150;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // SubCategoria
            // 
            SubCategoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SubCategoria.DataPropertyName = "SubCategoria";
            SubCategoria.FillWeight = 15F;
            SubCategoria.HeaderText = "SubCategoria";
            SubCategoria.MinimumWidth = 150;
            SubCategoria.Name = "SubCategoria";
            SubCategoria.ReadOnly = true;
            // 
            // TelaPrenda
            // 
            TelaPrenda.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TelaPrenda.DataPropertyName = "TelaPrenda";
            TelaPrenda.FillWeight = 14F;
            TelaPrenda.HeaderText = "Telas";
            TelaPrenda.MinimumWidth = 100;
            TelaPrenda.Name = "TelaPrenda";
            TelaPrenda.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cantidad.DataPropertyName = "Cantidad";
            Cantidad.FillWeight = 8F;
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 70;
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // nombreProveedor
            // 
            nombreProveedor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nombreProveedor.DataPropertyName = "nombreProveedor";
            nombreProveedor.FillWeight = 20F;
            nombreProveedor.HeaderText = "Proveedor";
            nombreProveedor.MinimumWidth = 180;
            nombreProveedor.Name = "nombreProveedor";
            nombreProveedor.ReadOnly = true;
            // 
            // bindingSourcePrendas
            // 
            bindingSourcePrendas.DataSource = typeof(RingoEntidades.Prendas);
            // 
            // bindingSourceDetallesPrenda
            // 
            bindingSourceDetallesPrenda.DataSource = typeof(RingoEntidades.DetallesPrendas);
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = SystemColors.ButtonHighlight;
            btnEditar.BackgroundImage = (Image)resources.GetObject("btnEditar.BackgroundImage");
            btnEditar.BackgroundImageLayout = ImageLayout.Stretch;
            btnEditar.Location = new Point(1133, 61);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(39, 39);
            btnEditar.TabIndex = 4;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(62, 475);
            label2.Name = "label2";
            label2.Size = new Size(105, 32);
            label2.TabIndex = 5;
            label2.Text = "Detalles";
            // 
            // dataGridViewDetallesPrenda
            // 
            dataGridViewDetallesPrenda.AllowUserToAddRows = false;
            dataGridViewDetallesPrenda.AllowUserToDeleteRows = false;
            dataGridViewDetallesPrenda.AllowUserToOrderColumns = true;
            dataGridViewDetallesPrenda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewDetallesPrenda.AutoGenerateColumns = false;
            dataGridViewDetallesPrenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDetallesPrenda.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewDetallesPrenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetallesPrenda.Columns.AddRange(new DataGridViewColumn[] { codigoDetalleDataGridViewTextBoxColumn, cantidadEstadoDataGridViewTextBoxColumn, colorDataGridViewTextBoxColumn, descripcionTalleDataGridViewTextBoxColumn, observacionesDataGridViewTextBoxColumn, costoDataGridViewTextBoxColumn, precioVentaDataGridViewTextBoxColumn, estadoActualDataGridViewTextBoxColumn });
            dataGridViewDetallesPrenda.DataSource = bindingSourceEstados;
            dataGridViewDetallesPrenda.Location = new Point(66, 513);
            dataGridViewDetallesPrenda.Name = "dataGridViewDetallesPrenda";
            dataGridViewDetallesPrenda.ReadOnly = true;
            dataGridViewDetallesPrenda.RowHeadersVisible = false;
            dataGridViewDetallesPrenda.RowHeadersWidth = 51;
            dataGridViewDetallesPrenda.Size = new Size(1264, 247);
            dataGridViewDetallesPrenda.TabIndex = 6;
            dataGridViewDetallesPrenda.CellClick += dataGridViewDetallesPrenda_CellClick;
            // 
            // codigoDetalleDataGridViewTextBoxColumn
            // 
            codigoDetalleDataGridViewTextBoxColumn.DataPropertyName = "CodigoDetalle";
            codigoDetalleDataGridViewTextBoxColumn.FillWeight = 51.98527F;
            codigoDetalleDataGridViewTextBoxColumn.HeaderText = "Codigo Detalle";
            codigoDetalleDataGridViewTextBoxColumn.MinimumWidth = 6;
            codigoDetalleDataGridViewTextBoxColumn.Name = "codigoDetalleDataGridViewTextBoxColumn";
            codigoDetalleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadEstadoDataGridViewTextBoxColumn
            // 
            cantidadEstadoDataGridViewTextBoxColumn.DataPropertyName = "CantidadEstado";
            cantidadEstadoDataGridViewTextBoxColumn.FillWeight = 51.98527F;
            cantidadEstadoDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadEstadoDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadEstadoDataGridViewTextBoxColumn.Name = "cantidadEstadoDataGridViewTextBoxColumn";
            cantidadEstadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            colorDataGridViewTextBoxColumn.FillWeight = 51.98527F;
            colorDataGridViewTextBoxColumn.HeaderText = "Color";
            colorDataGridViewTextBoxColumn.MinimumWidth = 6;
            colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            colorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionTalleDataGridViewTextBoxColumn
            // 
            descripcionTalleDataGridViewTextBoxColumn.DataPropertyName = "DescripcionTalle";
            descripcionTalleDataGridViewTextBoxColumn.FillWeight = 51.98527F;
            descripcionTalleDataGridViewTextBoxColumn.HeaderText = "Talle";
            descripcionTalleDataGridViewTextBoxColumn.MinimumWidth = 6;
            descripcionTalleDataGridViewTextBoxColumn.Name = "descripcionTalleDataGridViewTextBoxColumn";
            descripcionTalleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacionesDataGridViewTextBoxColumn
            // 
            observacionesDataGridViewTextBoxColumn.DataPropertyName = "Observaciones";
            observacionesDataGridViewTextBoxColumn.FillWeight = 51.98527F;
            observacionesDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            observacionesDataGridViewTextBoxColumn.MinimumWidth = 6;
            observacionesDataGridViewTextBoxColumn.Name = "observacionesDataGridViewTextBoxColumn";
            observacionesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoDataGridViewTextBoxColumn
            // 
            costoDataGridViewTextBoxColumn.DataPropertyName = "Costo";
            costoDataGridViewTextBoxColumn.FillWeight = 51.98527F;
            costoDataGridViewTextBoxColumn.HeaderText = "Precio Costo";
            costoDataGridViewTextBoxColumn.MinimumWidth = 6;
            costoDataGridViewTextBoxColumn.Name = "costoDataGridViewTextBoxColumn";
            costoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            precioVentaDataGridViewTextBoxColumn.DataPropertyName = "PrecioVenta";
            precioVentaDataGridViewTextBoxColumn.FillWeight = 51.98527F;
            precioVentaDataGridViewTextBoxColumn.HeaderText = "Precio Venta";
            precioVentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            precioVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoActualDataGridViewTextBoxColumn
            // 
            estadoActualDataGridViewTextBoxColumn.DataPropertyName = "EstadoActual";
            estadoActualDataGridViewTextBoxColumn.FillWeight = 51.98527F;
            estadoActualDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoActualDataGridViewTextBoxColumn.MinimumWidth = 6;
            estadoActualDataGridViewTextBoxColumn.Name = "estadoActualDataGridViewTextBoxColumn";
            estadoActualDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceEstados
            // 
            bindingSourceEstados.DataSource = typeof(RingoEntidades.EstadosPrendas);
            // 
            // checkStock
            // 
            checkStock.AutoSize = true;
            checkStock.BackColor = Color.Transparent;
            checkStock.Location = new Point(917, 73);
            checkStock.Margin = new Padding(3, 4, 3, 4);
            checkStock.Name = "checkStock";
            checkStock.Size = new Size(95, 24);
            checkStock.TabIndex = 7;
            checkStock.Text = " Sin Stock";
            checkStock.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom;
            btnSalir.Location = new Point(577, 786);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(249, 45);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // idDetallePrendaDataGridViewTextBoxColumn
            // 
            idDetallePrendaDataGridViewTextBoxColumn.DataPropertyName = "IdDetallePrenda";
            idDetallePrendaDataGridViewTextBoxColumn.HeaderText = "IdDetallePrenda";
            idDetallePrendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDetallePrendaDataGridViewTextBoxColumn.Name = "idDetallePrendaDataGridViewTextBoxColumn";
            idDetallePrendaDataGridViewTextBoxColumn.Width = 70;
            // 
            // idPrendaDataGridViewTextBoxColumn
            // 
            idPrendaDataGridViewTextBoxColumn.DataPropertyName = "IdPrenda";
            idPrendaDataGridViewTextBoxColumn.HeaderText = "IdPrenda";
            idPrendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            idPrendaDataGridViewTextBoxColumn.Name = "idPrendaDataGridViewTextBoxColumn";
            idPrendaDataGridViewTextBoxColumn.Width = 69;
            // 
            // idTalleDataGridViewTextBoxColumn
            // 
            idTalleDataGridViewTextBoxColumn.DataPropertyName = "IdTalle";
            idTalleDataGridViewTextBoxColumn.HeaderText = "IdTalle";
            idTalleDataGridViewTextBoxColumn.MinimumWidth = 6;
            idTalleDataGridViewTextBoxColumn.Name = "idTalleDataGridViewTextBoxColumn";
            idTalleDataGridViewTextBoxColumn.Width = 70;
            // 
            // prendaDataGridViewTextBoxColumn
            // 
            prendaDataGridViewTextBoxColumn.DataPropertyName = "Prenda";
            prendaDataGridViewTextBoxColumn.HeaderText = "Prenda";
            prendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            prendaDataGridViewTextBoxColumn.Name = "prendaDataGridViewTextBoxColumn";
            prendaDataGridViewTextBoxColumn.Width = 70;
            // 
            // talleDataGridViewTextBoxColumn
            // 
            talleDataGridViewTextBoxColumn.DataPropertyName = "Talle";
            talleDataGridViewTextBoxColumn.HeaderText = "Talle";
            talleDataGridViewTextBoxColumn.MinimumWidth = 6;
            talleDataGridViewTextBoxColumn.Name = "talleDataGridViewTextBoxColumn";
            talleDataGridViewTextBoxColumn.Width = 69;
            // 
            // codigoPrendaDataGridViewTextBoxColumn1
            // 
            codigoPrendaDataGridViewTextBoxColumn1.DataPropertyName = "CodigoPrenda";
            codigoPrendaDataGridViewTextBoxColumn1.HeaderText = "CodigoPrenda";
            codigoPrendaDataGridViewTextBoxColumn1.MinimumWidth = 6;
            codigoPrendaDataGridViewTextBoxColumn1.Name = "codigoPrendaDataGridViewTextBoxColumn1";
            codigoPrendaDataGridViewTextBoxColumn1.ReadOnly = true;
            codigoPrendaDataGridViewTextBoxColumn1.Width = 70;
            // 
            // btnVenta
            // 
            btnVenta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVenta.Location = new Point(65, 795);
            btnVenta.Margin = new Padding(3, 4, 3, 4);
            btnVenta.Name = "btnVenta";
            btnVenta.Size = new Size(249, 45);
            btnVenta.TabIndex = 9;
            btnVenta.Text = "Seleccionar Prenda";
            btnVenta.UseVisualStyleBackColor = true;
            btnVenta.Visible = false;
            btnVenta.Click += btnVenta_Click;
            // 
            // btnListadoXls
            // 
            btnListadoXls.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnListadoXls.BackColor = SystemColors.ButtonHighlight;
            btnListadoXls.BackgroundImage = (Image)resources.GetObject("btnListadoXls.BackgroundImage");
            btnListadoXls.BackgroundImageLayout = ImageLayout.Stretch;
            btnListadoXls.Location = new Point(1211, 61);
            btnListadoXls.Margin = new Padding(3, 4, 3, 4);
            btnListadoXls.Name = "btnListadoXls";
            btnListadoXls.Size = new Size(39, 39);
            btnListadoXls.TabIndex = 39;
            btnListadoXls.UseVisualStyleBackColor = false;
            btnListadoXls.Click += btnListadoXls_Click;
            // 
            // btnPdf
            // 
            btnPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPdf.BackColor = SystemColors.ButtonHighlight;
            btnPdf.BackgroundImage = (Image)resources.GetObject("btnPdf.BackgroundImage");
            btnPdf.BackgroundImageLayout = ImageLayout.Stretch;
            btnPdf.Location = new Point(1291, 61);
            btnPdf.Margin = new Padding(3, 4, 3, 4);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(39, 39);
            btnPdf.TabIndex = 40;
            btnPdf.UseVisualStyleBackColor = false;
            btnPdf.Click += btnPdf_Click;
            // 
            // btnAnomalia
            // 
            btnAnomalia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnomalia.BackColor = SystemColors.ButtonHighlight;
            btnAnomalia.BackgroundImageLayout = ImageLayout.Stretch;
            btnAnomalia.Location = new Point(1010, 461);
            btnAnomalia.Name = "btnAnomalia";
            btnAnomalia.Size = new Size(303, 39);
            btnAnomalia.TabIndex = 41;
            btnAnomalia.Text = "REGISTRAR ANOMALÍA";
            btnAnomalia.UseVisualStyleBackColor = false;
            btnAnomalia.Click += btnAnomalia_Click;
            // 
            // FrmAdminPrendas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1402, 853);
            Controls.Add(btnAnomalia);
            Controls.Add(btnPdf);
            Controls.Add(btnListadoXls);
            Controls.Add(btnVenta);
            Controls.Add(btnSalir);
            Controls.Add(checkStock);
            Controls.Add(dataGridViewDetallesPrenda);
            Controls.Add(label2);
            Controls.Add(btnEditar);
            Controls.Add(dataGridViewPrenda);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(labelAdminPrendas);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FrmAdminPrendas";
            Text = "Prendas";
            Load += FrmAdminPrendas_Load;
            Shown += Frm_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcePrendas).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetallesPrenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetallesPrenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceEstados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAdminPrendas;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dataGridViewPrenda;
        private BindingSource bindingSourceDetallesPrenda;
        private Button btnEditar;
        private BindingSource bindingSourcePrendas;
        private Label label2;
        internal DataGridView dataGridViewDetallesPrenda;
        private CheckBox checkStock;
        private Button btnSalir;
        private DataGridViewTextBoxColumn idDetallePrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idPrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idTalleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn talleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codigoPrendaDataGridViewTextBoxColumn1;
        private Button btnVenta;
        private Button btnListadoXls;
        private Button btnPdf;
        private Button btnAnomalia;
        private DataGridViewTextBoxColumn codigoPrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionPrendaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn IdPrenda;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn SubCategoria;
        private DataGridViewTextBoxColumn TelaPrenda;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn nombreProveedor;
        private BindingSource bindingSourceEstados;
        private DataGridViewTextBoxColumn codigoDetalleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadEstadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionTalleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoActualDataGridViewTextBoxColumn;
    }
}