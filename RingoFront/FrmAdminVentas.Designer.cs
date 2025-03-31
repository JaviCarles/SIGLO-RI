namespace RingoFront
{
    partial class FrmAdminVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminVentas));
            label1 = new Label();
            groupBoxBuscarVenta = new GroupBox();
            checkEnvio = new CheckBox();
            btnDespacho = new Button();
            checkSinCobrar = new CheckBox();
            checkCobradas = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            dateTimeHasta = new DateTimePicker();
            dateTimeDesde = new DateTimePicker();
            btnBuscarVenta = new Button();
            txtBuscarVenta = new TextBox();
            dataGridVerVentas = new DataGridView();
            nroVenta = new DataGridViewTextBoxColumn();
            fechaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dniClienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombresClienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombresVendedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            observacionesVentaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoVentaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSourceVentas = new BindingSource(components);
            btnSalir = new Button();
            label4 = new Label();
            txtTotal = new TextBox();
            btnCobrar = new Button();
            bindingSourceDetalles = new BindingSource(components);
            dataGridDetalles = new DataGridView();
            Codigos = new DataGridViewTextBoxColumn();
            descripcionProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioVentaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            groupBoxBuscarVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridVerVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridDetalles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(64, 25);
            label1.Name = "label1";
            label1.Size = new Size(225, 28);
            label1.TabIndex = 0;
            label1.Text = "Administración Ventas";
            // 
            // groupBoxBuscarVenta
            // 
            groupBoxBuscarVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxBuscarVenta.Controls.Add(checkEnvio);
            groupBoxBuscarVenta.Controls.Add(btnDespacho);
            groupBoxBuscarVenta.Controls.Add(checkSinCobrar);
            groupBoxBuscarVenta.Controls.Add(checkCobradas);
            groupBoxBuscarVenta.Controls.Add(label3);
            groupBoxBuscarVenta.Controls.Add(label2);
            groupBoxBuscarVenta.Controls.Add(dateTimeHasta);
            groupBoxBuscarVenta.Controls.Add(dateTimeDesde);
            groupBoxBuscarVenta.Controls.Add(btnBuscarVenta);
            groupBoxBuscarVenta.Controls.Add(txtBuscarVenta);
            groupBoxBuscarVenta.Location = new Point(0, 69);
            groupBoxBuscarVenta.Name = "groupBoxBuscarVenta";
            groupBoxBuscarVenta.Padding = new Padding(30, 29, 30, 29);
            groupBoxBuscarVenta.Size = new Size(1363, 157);
            groupBoxBuscarVenta.TabIndex = 1;
            groupBoxBuscarVenta.TabStop = false;
            // 
            // checkEnvio
            // 
            checkEnvio.AutoSize = true;
            checkEnvio.Location = new Point(1137, 56);
            checkEnvio.Margin = new Padding(3, 2, 3, 2);
            checkEnvio.Name = "checkEnvio";
            checkEnvio.Size = new Size(166, 24);
            checkEnvio.TabIndex = 19;
            checkEnvio.Text = "Con Envío Pendiente";
            checkEnvio.UseVisualStyleBackColor = true;
            checkEnvio.CheckedChanged += checkEnvio_CheckedChanged;
            // 
            // btnDespacho
            // 
            btnDespacho.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDespacho.Location = new Point(1125, 101);
            btnDespacho.Name = "btnDespacho";
            btnDespacho.Size = new Size(177, 33);
            btnDespacho.TabIndex = 18;
            btnDespacho.Text = "Confirmar Entrega";
            btnDespacho.UseVisualStyleBackColor = true;
            btnDespacho.Visible = false;
            btnDespacho.Click += btnDespacho_Click;
            // 
            // checkSinCobrar
            // 
            checkSinCobrar.AutoSize = true;
            checkSinCobrar.Location = new Point(976, 57);
            checkSinCobrar.Name = "checkSinCobrar";
            checkSinCobrar.Size = new Size(98, 24);
            checkSinCobrar.TabIndex = 17;
            checkSinCobrar.Text = "Sin cobrar";
            checkSinCobrar.UseVisualStyleBackColor = true;
            checkSinCobrar.CheckedChanged += checkSinCobrar_CheckedChanged;
            // 
            // checkCobradas
            // 
            checkCobradas.AutoSize = true;
            checkCobradas.Location = new Point(819, 56);
            checkCobradas.Name = "checkCobradas";
            checkCobradas.Size = new Size(94, 24);
            checkCobradas.TabIndex = 16;
            checkCobradas.Text = "Cobradas";
            checkCobradas.UseVisualStyleBackColor = true;
            checkCobradas.CheckedChanged += checkCobradas_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(430, 29);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 15;
            label3.Text = "HASTA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(64, 29);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 14;
            label2.Text = "DESDE";
            // 
            // dateTimeHasta
            // 
            dateTimeHasta.Font = new Font("Segoe UI", 9F);
            dateTimeHasta.Location = new Point(430, 53);
            dateTimeHasta.Name = "dateTimeHasta";
            dateTimeHasta.Size = new Size(340, 27);
            dateTimeHasta.TabIndex = 13;
            // 
            // dateTimeDesde
            // 
            dateTimeDesde.Location = new Point(64, 53);
            dateTimeDesde.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dateTimeDesde.Name = "dateTimeDesde";
            dateTimeDesde.Size = new Size(250, 27);
            dateTimeDesde.TabIndex = 12;
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.BackgroundImage = (Image)resources.GetObject("btnBuscarVenta.BackgroundImage");
            btnBuscarVenta.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarVenta.Location = new Point(819, 96);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(43, 37);
            btnBuscarVenta.TabIndex = 9;
            btnBuscarVenta.UseVisualStyleBackColor = true;
            btnBuscarVenta.Click += btnBuscarVenta_Click;
            // 
            // txtBuscarVenta
            // 
            txtBuscarVenta.Font = new Font("Segoe UI", 14F);
            txtBuscarVenta.Location = new Point(64, 95);
            txtBuscarVenta.Name = "txtBuscarVenta";
            txtBuscarVenta.PlaceholderText = "Buscar...";
            txtBuscarVenta.Size = new Size(706, 39);
            txtBuscarVenta.TabIndex = 8;
            // 
            // dataGridVerVentas
            // 
            dataGridVerVentas.AllowUserToAddRows = false;
            dataGridVerVentas.AllowUserToDeleteRows = false;
            dataGridVerVentas.AllowUserToOrderColumns = true;
            dataGridVerVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridVerVentas.AutoGenerateColumns = false;
            dataGridVerVentas.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridVerVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVerVentas.Columns.AddRange(new DataGridViewColumn[] { nroVenta, fechaDataGridViewTextBoxColumn, dniClienteDataGridViewTextBoxColumn, nombresClienteDataGridViewTextBoxColumn, nombresVendedorDataGridViewTextBoxColumn, observacionesVentaDataGridViewTextBoxColumn, estadoVentaDataGridViewTextBoxColumn });
            dataGridVerVentas.DataSource = bindingSourceVentas;
            dataGridVerVentas.Location = new Point(64, 245);
            dataGridVerVentas.Name = "dataGridVerVentas";
            dataGridVerVentas.ReadOnly = true;
            dataGridVerVentas.RowHeadersVisible = false;
            dataGridVerVentas.RowHeadersWidth = 51;
            dataGridVerVentas.Size = new Size(1239, 272);
            dataGridVerVentas.TabIndex = 2;
            dataGridVerVentas.SelectionChanged += dataGridVerVentas_SelectionChanged;
            // 
            // nroVenta
            // 
            nroVenta.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            nroVenta.DataPropertyName = "NumeroVenta";
            nroVenta.HeaderText = "Nro de Venta";
            nroVenta.MinimumWidth = 6;
            nroVenta.Name = "nroVenta";
            nroVenta.ReadOnly = true;
            nroVenta.Width = 130;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            fechaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            fechaDataGridViewTextBoxColumn.HeaderText = "Fecha de Venta";
            fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            fechaDataGridViewTextBoxColumn.ReadOnly = true;
            fechaDataGridViewTextBoxColumn.Width = 130;
            // 
            // dniClienteDataGridViewTextBoxColumn
            // 
            dniClienteDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dniClienteDataGridViewTextBoxColumn.DataPropertyName = "DniCliente";
            dniClienteDataGridViewTextBoxColumn.HeaderText = "Dni Cliente";
            dniClienteDataGridViewTextBoxColumn.MinimumWidth = 6;
            dniClienteDataGridViewTextBoxColumn.Name = "dniClienteDataGridViewTextBoxColumn";
            dniClienteDataGridViewTextBoxColumn.ReadOnly = true;
            dniClienteDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombresClienteDataGridViewTextBoxColumn
            // 
            nombresClienteDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nombresClienteDataGridViewTextBoxColumn.DataPropertyName = "NombresCliente";
            nombresClienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            nombresClienteDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombresClienteDataGridViewTextBoxColumn.Name = "nombresClienteDataGridViewTextBoxColumn";
            nombresClienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombresVendedorDataGridViewTextBoxColumn
            // 
            nombresVendedorDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nombresVendedorDataGridViewTextBoxColumn.DataPropertyName = "NombresVendedor";
            nombresVendedorDataGridViewTextBoxColumn.HeaderText = "Vendedor";
            nombresVendedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombresVendedorDataGridViewTextBoxColumn.Name = "nombresVendedorDataGridViewTextBoxColumn";
            nombresVendedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacionesVentaDataGridViewTextBoxColumn
            // 
            observacionesVentaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            observacionesVentaDataGridViewTextBoxColumn.DataPropertyName = "ObservacionesVenta";
            observacionesVentaDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            observacionesVentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            observacionesVentaDataGridViewTextBoxColumn.Name = "observacionesVentaDataGridViewTextBoxColumn";
            observacionesVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoVentaDataGridViewTextBoxColumn
            // 
            estadoVentaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            estadoVentaDataGridViewTextBoxColumn.DataPropertyName = "EstadoVenta";
            estadoVentaDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoVentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            estadoVentaDataGridViewTextBoxColumn.Name = "estadoVentaDataGridViewTextBoxColumn";
            estadoVentaDataGridViewTextBoxColumn.ReadOnly = true;
            estadoVentaDataGridViewTextBoxColumn.Width = 150;
            // 
            // bindingSourceVentas
            // 
            bindingSourceVentas.DataSource = typeof(VentaConsulta);
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(1101, 874);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(201, 29);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(1011, 819);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 15;
            label4.Text = "TOTAL";
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Segoe UI", 14F);
            txtTotal.Location = new Point(1104, 804);
            txtTotal.Name = "txtTotal";
            txtTotal.PlaceholderText = "Buscar...";
            txtTotal.Size = new Size(198, 39);
            txtTotal.TabIndex = 16;
            // 
            // btnCobrar
            // 
            btnCobrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCobrar.Location = new Point(64, 874);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(201, 29);
            btnCobrar.TabIndex = 17;
            btnCobrar.Text = "COBRAR";
            btnCobrar.UseVisualStyleBackColor = true;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // bindingSourceDetalles
            // 
            bindingSourceDetalles.DataSource = typeof(RingoEntidades.DetallesVentas);
            // 
            // dataGridDetalles
            // 
            dataGridDetalles.AllowUserToAddRows = false;
            dataGridDetalles.AllowUserToDeleteRows = false;
            dataGridDetalles.AllowUserToOrderColumns = true;
            dataGridDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridDetalles.AutoGenerateColumns = false;
            dataGridDetalles.BackgroundColor = Color.White;
            dataGridDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDetalles.Columns.AddRange(new DataGridViewColumn[] { Codigos, descripcionProductoDataGridViewTextBoxColumn, precioVentaDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn, subTotalDataGridViewTextBoxColumn });
            dataGridDetalles.DataSource = bindingSourceDetalles;
            dataGridDetalles.Location = new Point(64, 543);
            dataGridDetalles.Margin = new Padding(3, 4, 3, 4);
            dataGridDetalles.Name = "dataGridDetalles";
            dataGridDetalles.ReadOnly = true;
            dataGridDetalles.RowHeadersVisible = false;
            dataGridDetalles.RowHeadersWidth = 51;
            dataGridDetalles.Size = new Size(1239, 255);
            dataGridDetalles.TabIndex = 18;
            // 
            // Codigos
            // 
            Codigos.DataPropertyName = "Codigos";
            Codigos.HeaderText = "Codigo";
            Codigos.MinimumWidth = 6;
            Codigos.Name = "Codigos";
            Codigos.ReadOnly = true;
            Codigos.Width = 120;
            // 
            // descripcionProductoDataGridViewTextBoxColumn
            // 
            descripcionProductoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descripcionProductoDataGridViewTextBoxColumn.DataPropertyName = "DescripcionProducto";
            descripcionProductoDataGridViewTextBoxColumn.HeaderText = "Descripcion Producto";
            descripcionProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            descripcionProductoDataGridViewTextBoxColumn.Name = "descripcionProductoDataGridViewTextBoxColumn";
            descripcionProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            precioVentaDataGridViewTextBoxColumn.DataPropertyName = "PrecioVenta";
            precioVentaDataGridViewTextBoxColumn.HeaderText = "Precio Venta";
            precioVentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            precioVentaDataGridViewTextBoxColumn.ReadOnly = true;
            precioVentaDataGridViewTextBoxColumn.Width = 140;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            cantidadDataGridViewTextBoxColumn.Width = 70;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
            subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            subTotalDataGridViewTextBoxColumn.ReadOnly = true;
            subTotalDataGridViewTextBoxColumn.Width = 180;
            // 
            // FrmAdminVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1365, 933);
            Controls.Add(dataGridDetalles);
            Controls.Add(btnCobrar);
            Controls.Add(txtTotal);
            Controls.Add(label4);
            Controls.Add(btnSalir);
            Controls.Add(dataGridVerVentas);
            Controls.Add(groupBoxBuscarVenta);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAdminVentas";
            Text = "FrmAdminVentas";
            Load += FrmAdminVentas_Load;
            Shown += Frm_Shown;
            groupBoxBuscarVenta.ResumeLayout(false);
            groupBoxBuscarVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridVerVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBoxBuscarVenta;
        private Button btnBuscarVenta;

        private TextBox txtBuscarVenta;
        private Label label2;
        private DateTimePicker dateTimeHasta;
        private DateTimePicker dateTimeDesde;
        private Label label3;

        private DataGridView dataGridVerVentas;
        private CheckBox checkSinCobrar;
        private CheckBox checkCobradas;
        private Button btnSalir;
        private BindingSource bindingSourceVentas;
        private Label label4;
        private TextBox txtTotal;
        private Button btnCobrar;
        private BindingSource bindingSourceDetalles;
        private DataGridView dataGridDetalles;
        private DataGridViewTextBoxColumn nroVenta;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dniClienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombresClienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombresVendedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn observacionesVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoVentaDataGridViewTextBoxColumn;
        private Button btnDespacho;
        private CheckBox checkEnvio;
        private DataGridViewTextBoxColumn Codigos;
        private DataGridViewTextBoxColumn descripcionProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
    }
}