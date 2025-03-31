namespace RingoFront
{
    partial class FrmFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturacion));
            groupBoxTitulo = new GroupBox();
            txtTotal = new TextBox();
            label7 = new Label();
            txtVuelto = new TextBox();
            label6 = new Label();
            label5 = new Label();
            comboBoxTipoFac = new ComboBox();
            tipoFacturaBindingSource = new BindingSource(components);
            btnBuscarVenta = new Button();
            txtNroVenta = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBoxGuardarSalir = new GroupBox();
            btnSalir = new Button();
            btbGuardar = new Button();
            groupBox1 = new GroupBox();
            comboBoxDomicilios = new ComboBox();
            comboBoxTelefonos = new ComboBox();
            lblDomicilio = new Label();
            lblTelefono = new Label();
            txtNombreApellido = new TextBox();
            lblNombreApellido = new Label();
            txtDNI = new TextBox();
            labelDNI = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            codigosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descripcionProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioVentaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            detallesBindingSource = new BindingSource(components);
            groupBoxFactura = new GroupBox();
            numMonto = new NumericUpDown();
            label4 = new Label();
            txtCupon = new TextBox();
            label3 = new Label();
            comboBoxTarjetas = new ComboBox();
            tarjetasBindingSource = new BindingSource(components);
            lblEntidadBancaria = new Label();
            comboBoxEntidadBancaria = new ComboBox();
            entidadesTarjetasBindingSource = new BindingSource(components);
            lblMonto = new Label();
            lblMedioDePago = new Label();
            comboBoxMedioPago = new ComboBox();
            mediosPagosBindingSource = new BindingSource(components);
            groupBoxTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tipoFacturaBindingSource).BeginInit();
            groupBoxGuardarSalir.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detallesBindingSource).BeginInit();
            groupBoxFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tarjetasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)entidadesTarjetasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mediosPagosBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBoxTitulo
            // 
            groupBoxTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxTitulo.Controls.Add(txtTotal);
            groupBoxTitulo.Controls.Add(label7);
            groupBoxTitulo.Controls.Add(txtVuelto);
            groupBoxTitulo.Controls.Add(label6);
            groupBoxTitulo.Controls.Add(label5);
            groupBoxTitulo.Controls.Add(comboBoxTipoFac);
            groupBoxTitulo.Controls.Add(btnBuscarVenta);
            groupBoxTitulo.Controls.Add(txtNroVenta);
            groupBoxTitulo.Controls.Add(label2);
            groupBoxTitulo.Location = new Point(12, 55);
            groupBoxTitulo.Name = "groupBoxTitulo";
            groupBoxTitulo.Size = new Size(1384, 114);
            groupBoxTitulo.TabIndex = 0;
            groupBoxTitulo.TabStop = false;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Segoe UI", 11F);
            txtTotal.Location = new Point(826, 61);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(143, 32);
            txtTotal.TabIndex = 16;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(826, 28);
            label7.Name = "label7";
            label7.Size = new Size(126, 25);
            label7.TabIndex = 15;
            label7.Text = "TOTAL VENTA";
            // 
            // txtVuelto
            // 
            txtVuelto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtVuelto.Enabled = false;
            txtVuelto.Font = new Font("Segoe UI", 11F);
            txtVuelto.Location = new Point(1135, 62);
            txtVuelto.Name = "txtVuelto";
            txtVuelto.Size = new Size(143, 32);
            txtVuelto.TabIndex = 14;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(1135, 27);
            label6.Name = "label6";
            label6.Size = new Size(136, 25);
            label6.TabIndex = 13;
            label6.Text = "VUELTO A DAR";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(518, 27);
            label5.Name = "label5";
            label5.Size = new Size(135, 25);
            label5.TabIndex = 12;
            label5.Text = "TIPO FACTURA";
            // 
            // comboBoxTipoFac
            // 
            comboBoxTipoFac.Anchor = AnchorStyles.Top;
            comboBoxTipoFac.DataSource = tipoFacturaBindingSource;
            comboBoxTipoFac.DisplayMember = "TipoFactura";
            comboBoxTipoFac.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoFac.Font = new Font("Segoe UI", 11F);
            comboBoxTipoFac.FormattingEnabled = true;
            comboBoxTipoFac.Location = new Point(518, 60);
            comboBoxTipoFac.Name = "comboBoxTipoFac";
            comboBoxTipoFac.Size = new Size(134, 33);
            comboBoxTipoFac.TabIndex = 11;
            comboBoxTipoFac.ValueMember = "IdTipoFactura";
            // 
            // tipoFacturaBindingSource
            // 
            tipoFacturaBindingSource.DataSource = typeof(RingoEntidades.TiposFacturas);
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.BackgroundImage = (Image)resources.GetObject("btnBuscarVenta.BackgroundImage");
            btnBuscarVenta.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarVenta.Location = new Point(334, 56);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(43, 37);
            btnBuscarVenta.TabIndex = 10;
            btnBuscarVenta.UseVisualStyleBackColor = true;
            btnBuscarVenta.Click += btnBuscarVenta_Click;
            // 
            // txtNroVenta
            // 
            txtNroVenta.Font = new Font("Segoe UI", 11F);
            txtNroVenta.Location = new Point(59, 57);
            txtNroVenta.Name = "txtNroVenta";
            txtNroVenta.Size = new Size(255, 32);
            txtNroVenta.TabIndex = 3;
            txtNroVenta.KeyPress += NumericTextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(59, 24);
            label2.Name = "label2";
            label2.Size = new Size(141, 25);
            label2.TabIndex = 2;
            label2.Text = "NRO DE VENTA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(71, 23);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "FACTURACIÓN";
            // 
            // groupBoxGuardarSalir
            // 
            groupBoxGuardarSalir.Controls.Add(btnSalir);
            groupBoxGuardarSalir.Controls.Add(btbGuardar);
            groupBoxGuardarSalir.Dock = DockStyle.Bottom;
            groupBoxGuardarSalir.Location = new Point(0, 858);
            groupBoxGuardarSalir.Name = "groupBoxGuardarSalir";
            groupBoxGuardarSalir.Size = new Size(1384, 85);
            groupBoxGuardarSalir.TabIndex = 1;
            groupBoxGuardarSalir.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(1205, 26);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(143, 29);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btbGuardar
            // 
            btbGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btbGuardar.Location = new Point(59, 26);
            btbGuardar.Name = "btbGuardar";
            btbGuardar.Size = new Size(143, 29);
            btbGuardar.TabIndex = 0;
            btbGuardar.Text = "GUARDAR";
            btbGuardar.UseVisualStyleBackColor = true;
            btbGuardar.Click += btbGuardar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(comboBoxDomicilios);
            groupBox1.Controls.Add(comboBoxTelefonos);
            groupBox1.Controls.Add(lblDomicilio);
            groupBox1.Controls.Add(lblTelefono);
            groupBox1.Controls.Add(txtNombreApellido);
            groupBox1.Controls.Add(lblNombreApellido);
            groupBox1.Controls.Add(txtDNI);
            groupBox1.Controls.Add(labelDNI);
            groupBox1.Location = new Point(12, 224);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1384, 219);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "          DATOS DEL CLIENTE";
            // 
            // comboBoxDomicilios
            // 
            comboBoxDomicilios.Font = new Font("Segoe UI", 11F);
            comboBoxDomicilios.FormattingEnabled = true;
            comboBoxDomicilios.Location = new Point(662, 176);
            comboBoxDomicilios.Name = "comboBoxDomicilios";
            comboBoxDomicilios.Size = new Size(461, 33);
            comboBoxDomicilios.TabIndex = 10;
            // 
            // comboBoxTelefonos
            // 
            comboBoxTelefonos.Font = new Font("Segoe UI", 11F);
            comboBoxTelefonos.FormattingEnabled = true;
            comboBoxTelefonos.Location = new Point(54, 176);
            comboBoxTelefonos.Name = "comboBoxTelefonos";
            comboBoxTelefonos.Size = new Size(255, 33);
            comboBoxTelefonos.TabIndex = 9;
            // 
            // lblDomicilio
            // 
            lblDomicilio.AutoSize = true;
            lblDomicilio.Font = new Font("Segoe UI", 11F);
            lblDomicilio.Location = new Point(662, 128);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(106, 25);
            lblDomicilio.TabIndex = 6;
            lblDomicilio.Text = "DOMICILIO";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 11F);
            lblTelefono.Location = new Point(54, 128);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(102, 25);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "TELEFONO";
            // 
            // txtNombreApellido
            // 
            txtNombreApellido.Enabled = false;
            txtNombreApellido.Font = new Font("Segoe UI", 11F);
            txtNombreApellido.Location = new Point(662, 71);
            txtNombreApellido.Name = "txtNombreApellido";
            txtNombreApellido.Size = new Size(461, 32);
            txtNombreApellido.TabIndex = 3;
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Font = new Font("Segoe UI", 11F);
            lblNombreApellido.Location = new Point(662, 37);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(198, 25);
            lblNombreApellido.TabIndex = 2;
            lblNombreApellido.Text = "NOMBRE  Y APELLIDO";
            // 
            // txtDNI
            // 
            txtDNI.Enabled = false;
            txtDNI.Font = new Font("Segoe UI", 11F);
            txtDNI.Location = new Point(54, 71);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(255, 32);
            txtDNI.TabIndex = 1;
            // 
            // labelDNI
            // 
            labelDNI.AutoSize = true;
            labelDNI.Font = new Font("Segoe UI", 11F);
            labelDNI.Location = new Point(54, 37);
            labelDNI.Name = "labelDNI";
            labelDNI.Size = new Size(44, 25);
            labelDNI.TabIndex = 0;
            labelDNI.Text = "DNI";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(12, 482);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1384, 225);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "         PRENDAS";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { codigosDataGridViewTextBoxColumn, descripcionProductoDataGridViewTextBoxColumn, precioVentaDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn, subTotalDataGridViewTextBoxColumn });
            dataGridView1.DataSource = detallesBindingSource;
            dataGridView1.Location = new Point(46, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1290, 189);
            dataGridView1.TabIndex = 0;
            // 
            // codigosDataGridViewTextBoxColumn
            // 
            codigosDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            codigosDataGridViewTextBoxColumn.DataPropertyName = "Codigos";
            codigosDataGridViewTextBoxColumn.FillWeight = 15F;
            codigosDataGridViewTextBoxColumn.HeaderText = "Codigo Prenda";
            codigosDataGridViewTextBoxColumn.MinimumWidth = 100;
            codigosDataGridViewTextBoxColumn.Name = "codigosDataGridViewTextBoxColumn";
            codigosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionProductoDataGridViewTextBoxColumn
            // 
            descripcionProductoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descripcionProductoDataGridViewTextBoxColumn.DataPropertyName = "DescripcionProducto";
            descripcionProductoDataGridViewTextBoxColumn.FillWeight = 50F;
            descripcionProductoDataGridViewTextBoxColumn.HeaderText = "Descripcion de Producto";
            descripcionProductoDataGridViewTextBoxColumn.MinimumWidth = 180;
            descripcionProductoDataGridViewTextBoxColumn.Name = "descripcionProductoDataGridViewTextBoxColumn";
            descripcionProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            precioVentaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            precioVentaDataGridViewTextBoxColumn.DataPropertyName = "PrecioVenta";
            precioVentaDataGridViewTextBoxColumn.FillWeight = 13F;
            precioVentaDataGridViewTextBoxColumn.HeaderText = "Precio de Venta";
            precioVentaDataGridViewTextBoxColumn.MinimumWidth = 100;
            precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            precioVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn.FillWeight = 8F;
            cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn.MinimumWidth = 80;
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            subTotalDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            subTotalDataGridViewTextBoxColumn.FillWeight = 14F;
            subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
            subTotalDataGridViewTextBoxColumn.MinimumWidth = 100;
            subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            subTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // detallesBindingSource
            // 
            detallesBindingSource.DataSource = typeof(RingoEntidades.DetallesVentas);
            // 
            // groupBoxFactura
            // 
            groupBoxFactura.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxFactura.Controls.Add(numMonto);
            groupBoxFactura.Controls.Add(label4);
            groupBoxFactura.Controls.Add(txtCupon);
            groupBoxFactura.Controls.Add(label3);
            groupBoxFactura.Controls.Add(comboBoxTarjetas);
            groupBoxFactura.Controls.Add(lblEntidadBancaria);
            groupBoxFactura.Controls.Add(comboBoxEntidadBancaria);
            groupBoxFactura.Controls.Add(lblMonto);
            groupBoxFactura.Controls.Add(lblMedioDePago);
            groupBoxFactura.Controls.Add(comboBoxMedioPago);
            groupBoxFactura.Location = new Point(12, 727);
            groupBoxFactura.Name = "groupBoxFactura";
            groupBoxFactura.Size = new Size(1384, 125);
            groupBoxFactura.TabIndex = 4;
            groupBoxFactura.TabStop = false;
            groupBoxFactura.Text = "         FACTURA";
            // 
            // numMonto
            // 
            numMonto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numMonto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            numMonto.Location = new Point(1160, 80);
            numMonto.Margin = new Padding(3, 4, 3, 4);
            numMonto.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numMonto.Name = "numMonto";
            numMonto.Size = new Size(176, 34);
            numMonto.TabIndex = 15;
            numMonto.ValueChanged += numMonto_ValueChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(950, 52);
            label4.Name = "label4";
            label4.Size = new Size(158, 25);
            label4.TabIndex = 9;
            label4.Text = "CUPÓN DE PAGO";
            // 
            // txtCupon
            // 
            txtCupon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCupon.Font = new Font("Segoe UI", 11F);
            txtCupon.Location = new Point(949, 83);
            txtCupon.Name = "txtCupon";
            txtCupon.Size = new Size(153, 32);
            txtCupon.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(358, 52);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 7;
            label3.Text = "TARJETA";
            // 
            // comboBoxTarjetas
            // 
            comboBoxTarjetas.DataSource = tarjetasBindingSource;
            comboBoxTarjetas.DisplayMember = "Tarjeta";
            comboBoxTarjetas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTarjetas.Font = new Font("Segoe UI", 11F);
            comboBoxTarjetas.FormattingEnabled = true;
            comboBoxTarjetas.Location = new Point(359, 81);
            comboBoxTarjetas.Name = "comboBoxTarjetas";
            comboBoxTarjetas.Size = new Size(195, 33);
            comboBoxTarjetas.TabIndex = 6;
            comboBoxTarjetas.ValueMember = "IdTarjeta";
            comboBoxTarjetas.SelectedIndexChanged += comboBoxTarjetas_SelectedIndexChanged;
            // 
            // tarjetasBindingSource
            // 
            tarjetasBindingSource.DataSource = typeof(RingoEntidades.Tarjetas);
            // 
            // lblEntidadBancaria
            // 
            lblEntidadBancaria.AutoSize = true;
            lblEntidadBancaria.Font = new Font("Segoe UI", 11F);
            lblEntidadBancaria.Location = new Point(598, 52);
            lblEntidadBancaria.Name = "lblEntidadBancaria";
            lblEntidadBancaria.Size = new Size(183, 25);
            lblEntidadBancaria.TabIndex = 5;
            lblEntidadBancaria.Text = "ENTIDAD BANCARIA";
            // 
            // comboBoxEntidadBancaria
            // 
            comboBoxEntidadBancaria.DataSource = entidadesTarjetasBindingSource;
            comboBoxEntidadBancaria.DisplayMember = "EntidadFinanciera";
            comboBoxEntidadBancaria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEntidadBancaria.Font = new Font("Segoe UI", 11F);
            comboBoxEntidadBancaria.FormattingEnabled = true;
            comboBoxEntidadBancaria.Location = new Point(599, 81);
            comboBoxEntidadBancaria.Name = "comboBoxEntidadBancaria";
            comboBoxEntidadBancaria.Size = new Size(291, 33);
            comboBoxEntidadBancaria.TabIndex = 4;
            comboBoxEntidadBancaria.ValueMember = "IdEntidadTarjeta";
            // 
            // entidadesTarjetasBindingSource
            // 
            entidadesTarjetasBindingSource.DataSource = typeof(RingoEntidades.EntidadesTarjetas);
            // 
            // lblMonto
            // 
            lblMonto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Segoe UI", 11F);
            lblMonto.Location = new Point(1160, 52);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(80, 25);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "MONTO";
            // 
            // lblMedioDePago
            // 
            lblMedioDePago.AutoSize = true;
            lblMedioDePago.Font = new Font("Segoe UI", 11F);
            lblMedioDePago.Location = new Point(46, 52);
            lblMedioDePago.Name = "lblMedioDePago";
            lblMedioDePago.Size = new Size(153, 25);
            lblMedioDePago.TabIndex = 1;
            lblMedioDePago.Text = "MEDIO DE PAGO";
            // 
            // comboBoxMedioPago
            // 
            comboBoxMedioPago.DataSource = mediosPagosBindingSource;
            comboBoxMedioPago.DisplayMember = "FormaPago";
            comboBoxMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMedioPago.Font = new Font("Segoe UI", 11F);
            comboBoxMedioPago.FormattingEnabled = true;
            comboBoxMedioPago.Location = new Point(47, 81);
            comboBoxMedioPago.Name = "comboBoxMedioPago";
            comboBoxMedioPago.Size = new Size(276, 33);
            comboBoxMedioPago.TabIndex = 0;
            comboBoxMedioPago.ValueMember = "IdMedioPago";
            comboBoxMedioPago.SelectedIndexChanged += comboBoxMedioPago_SelectedIndexChanged;
            // 
            // mediosPagosBindingSource
            // 
            mediosPagosBindingSource.DataSource = typeof(RingoEntidades.MediosPagos);
            // 
            // FrmFacturacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 943);
            Controls.Add(groupBoxFactura);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxGuardarSalir);
            Controls.Add(groupBoxTitulo);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFacturacion";
            Text = "FrmFacturacion";
            Load += FrmFacturacion_Load;
            Shown += Frm_Shown;
            groupBoxTitulo.ResumeLayout(false);
            groupBoxTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tipoFacturaBindingSource).EndInit();
            groupBoxGuardarSalir.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)detallesBindingSource).EndInit();
            groupBoxFactura.ResumeLayout(false);
            groupBoxFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ((System.ComponentModel.ISupportInitialize)tarjetasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)entidadesTarjetasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)mediosPagosBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxTitulo;
        private Label label1;
        private GroupBox groupBoxGuardarSalir;
        private Button btnSalir;
        private Button btbGuardar;
        private GroupBox groupBox1;
        private Label lblDomicilio;
        private Label lblTelefono;
        private TextBox txtNombreApellido;
        private Label lblNombreApellido;
        private TextBox txtDNI;
        private Label labelDNI;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private GroupBox groupBoxFactura;
        private Label lblMedioDePago;
        private ComboBox comboBoxMedioPago;
        private Label lblEntidadBancaria;
        private ComboBox comboBoxEntidadBancaria;
        private Label lblMonto;
        private BindingSource mediosPagosBindingSource;
        private BindingSource entidadesTarjetasBindingSource;
        private TextBox txtNroVenta;
        private Label label2;
        private Button btnBuscarVenta;
        private Label label3;
        private ComboBox comboBoxTarjetas;
        private Label label4;
        private TextBox txtCupon;
        private BindingSource tarjetasBindingSource;
        private Label label5;
        private ComboBox comboBoxTipoFac;
        private BindingSource tipoFacturaBindingSource;
        private TextBox txtVuelto;
        private Label label6;
        private BindingSource detallesBindingSource;
        private DataGridViewTextBoxColumn codigosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private ComboBox comboBoxDomicilios;
        private ComboBox comboBoxTelefonos;
        private TextBox txtTotal;
        private Label label7;
        private NumericUpDown numMonto;
    }
}