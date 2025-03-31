namespace RingoFront
{
    partial class frmRegistrarVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarVentas));
            label9 = new Label();
            groupBoxDatosCliente = new GroupBox();
            btnBuscarVenta = new Button();
            comboTelefono = new ComboBox();
            contactosBindingSource = new BindingSource(components);
            comboDomicilio = new ComboBox();
            domiciliosBindingSource = new BindingSource(components);
            lblTelefono = new Label();
            lblDomicilio = new Label();
            checkEnvio = new CheckBox();
            button2 = new Button();
            txtDniCliente = new TextBox();
            txtApellidoCliente = new TextBox();
            label3 = new Label();
            txtNombreCliente = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnBuscarPrenda = new Button();
            btnAgregarProducto = new Button();
            txtPrecioPrenda = new TextBox();
            btnQuitarProducto = new Button();
            label7 = new Label();
            numUpDownCantPrendas = new NumericUpDown();
            label6 = new Label();
            cmbPrendas = new ComboBox();
            bindingSourceDetallesPrendas = new BindingSource(components);
            label5 = new Label();
            txtNumVenta = new TextBox();
            label4 = new Label();
            dataGridViewCarrito = new DataGridView();
            descripcionProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            id = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            bindingSourceDetallesVentas = new BindingSource(components);
            label8 = new Label();
            btnRegistrarVenta = new Button();
            button1 = new Button();
            txtTotal = new TextBox();
            label10 = new Label();
            groupBox2 = new GroupBox();
            groupBoxDatosCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)contactosBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)domiciliosBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numUpDownCantPrendas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetallesPrendas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetallesVentas).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label9.Location = new Point(33, 33);
            label9.Name = "label9";
            label9.Size = new Size(157, 23);
            label9.TabIndex = 37;
            label9.Text = "Registrar Venta";
            // 
            // groupBoxDatosCliente
            // 
            groupBoxDatosCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxDatosCliente.BackColor = Color.Transparent;
            groupBoxDatosCliente.Controls.Add(btnBuscarVenta);
            groupBoxDatosCliente.Controls.Add(comboTelefono);
            groupBoxDatosCliente.Controls.Add(comboDomicilio);
            groupBoxDatosCliente.Controls.Add(lblTelefono);
            groupBoxDatosCliente.Controls.Add(lblDomicilio);
            groupBoxDatosCliente.Controls.Add(checkEnvio);
            groupBoxDatosCliente.Controls.Add(button2);
            groupBoxDatosCliente.Controls.Add(txtDniCliente);
            groupBoxDatosCliente.Controls.Add(txtApellidoCliente);
            groupBoxDatosCliente.Controls.Add(label3);
            groupBoxDatosCliente.Controls.Add(txtNombreCliente);
            groupBoxDatosCliente.Controls.Add(label2);
            groupBoxDatosCliente.Controls.Add(label1);
            groupBoxDatosCliente.Location = new Point(1, 80);
            groupBoxDatosCliente.Name = "groupBoxDatosCliente";
            groupBoxDatosCliente.Padding = new Padding(30, 29, 30, 29);
            groupBoxDatosCliente.Size = new Size(1576, 204);
            groupBoxDatosCliente.TabIndex = 38;
            groupBoxDatosCliente.TabStop = false;
            groupBoxDatosCliente.Text = "          Datos Cliente";
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.BackgroundImage = (Image)resources.GetObject("btnBuscarVenta.BackgroundImage");
            btnBuscarVenta.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarVenta.Location = new Point(918, 66);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(43, 37);
            btnBuscarVenta.TabIndex = 14;
            btnBuscarVenta.UseVisualStyleBackColor = true;
            btnBuscarVenta.Click += btnBuscarVenta_Click;
            // 
            // comboTelefono
            // 
            comboTelefono.DataSource = contactosBindingSource;
            comboTelefono.DisplayMember = "NumeroCompleto";
            comboTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            comboTelefono.FormattingEnabled = true;
            comboTelefono.Location = new Point(601, 148);
            comboTelefono.Name = "comboTelefono";
            comboTelefono.Size = new Size(290, 36);
            comboTelefono.TabIndex = 13;
            comboTelefono.ValueMember = "IdContacto";
            comboTelefono.Visible = false;
            // 
            // contactosBindingSource
            // 
            contactosBindingSource.DataSource = typeof(RingoEntidades.Contactos);
            // 
            // comboDomicilio
            // 
            comboDomicilio.DataSource = domiciliosBindingSource;
            comboDomicilio.DisplayMember = "DomicilioCompleto";
            comboDomicilio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            comboDomicilio.FormattingEnabled = true;
            comboDomicilio.Location = new Point(53, 148);
            comboDomicilio.Name = "comboDomicilio";
            comboDomicilio.Size = new Size(481, 36);
            comboDomicilio.TabIndex = 12;
            comboDomicilio.ValueMember = "IdDomicilio";
            comboDomicilio.Visible = false;
            // 
            // domiciliosBindingSource
            // 
            domiciliosBindingSource.DataSource = typeof(RingoEntidades.Domicilios);
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.BackColor = Color.Transparent;
            lblTelefono.Location = new Point(601, 113);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(67, 20);
            lblTelefono.TabIndex = 11;
            lblTelefono.Text = "Telefono";
            lblTelefono.Visible = false;
            // 
            // lblDomicilio
            // 
            lblDomicilio.AutoSize = true;
            lblDomicilio.BackColor = Color.Transparent;
            lblDomicilio.Location = new Point(51, 113);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(74, 20);
            lblDomicilio.TabIndex = 9;
            lblDomicilio.Text = "Domicilio";
            lblDomicilio.Visible = false;
            // 
            // checkEnvio
            // 
            checkEnvio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkEnvio.AutoSize = true;
            checkEnvio.Location = new Point(1094, 157);
            checkEnvio.Name = "checkEnvio";
            checkEnvio.Size = new Size(148, 24);
            checkEnvio.TabIndex = 8;
            checkEnvio.Text = "Envío a Domicilio";
            checkEnvio.UseVisualStyleBackColor = true;
            checkEnvio.CheckedChanged += checkEnvio_CheckedChanged;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(1037, 66);
            button2.Name = "button2";
            button2.Size = new Size(218, 40);
            button2.TabIndex = 6;
            button2.Text = "Agregar Cliente";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtDniCliente
            // 
            txtDniCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtDniCliente.Location = new Point(55, 66);
            txtDniCliente.MaxLength = 9;
            txtDniCliente.Name = "txtDniCliente";
            txtDniCliente.Size = new Size(132, 34);
            txtDniCliente.TabIndex = 5;
            txtDniCliente.KeyPress += NumericTextBox_KeyPress;
            // 
            // txtApellidoCliente
            // 
            txtApellidoCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtApellidoCliente.Location = new Point(601, 67);
            txtApellidoCliente.Name = "txtApellidoCliente";
            txtApellidoCliente.Size = new Size(290, 34);
            txtApellidoCliente.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(51, 35);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 4;
            label3.Text = "DNI";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtNombreCliente.Location = new Point(223, 67);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(310, 34);
            txtNombreCliente.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(601, 36);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 1;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(223, 36);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombres";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnBuscarPrenda);
            groupBox1.Controls.Add(btnAgregarProducto);
            groupBox1.Controls.Add(txtPrecioPrenda);
            groupBox1.Controls.Add(btnQuitarProducto);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(numUpDownCantPrendas);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cmbPrendas);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtNumVenta);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(1, 289);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1576, 176);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "          Datos Venta";
            // 
            // btnBuscarPrenda
            // 
            btnBuscarPrenda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarPrenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscarPrenda.Location = new Point(1037, 62);
            btnBuscarPrenda.Name = "btnBuscarPrenda";
            btnBuscarPrenda.Size = new Size(218, 40);
            btnBuscarPrenda.TabIndex = 9;
            btnBuscarPrenda.Text = "Buscar Prenda";
            btnBuscarPrenda.UseVisualStyleBackColor = true;
            btnBuscarPrenda.Click += btnBuscarPrenda_Click;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarProducto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregarProducto.Location = new Point(1037, 119);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(218, 40);
            btnAgregarProducto.TabIndex = 8;
            btnAgregarProducto.Text = "Agregar a la lista";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // txtPrecioPrenda
            // 
            txtPrecioPrenda.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtPrecioPrenda.Location = new Point(849, 65);
            txtPrecioPrenda.Name = "txtPrecioPrenda";
            txtPrecioPrenda.Size = new Size(150, 34);
            txtPrecioPrenda.TabIndex = 7;
            txtPrecioPrenda.KeyPress += NumericTextBox_KeyPress;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarProducto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQuitarProducto.Location = new Point(1285, 119);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(218, 40);
            btnQuitarProducto.TabIndex = 42;
            btnQuitarProducto.Text = "Quitar de la lista";
            btnQuitarProducto.UseVisualStyleBackColor = true;
            btnQuitarProducto.Click += btnQuitarProducto_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(847, 33);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 6;
            label7.Text = "Precio";
            // 
            // numUpDownCantPrendas
            // 
            numUpDownCantPrendas.Font = new Font("Segoe UI", 12F);
            numUpDownCantPrendas.Location = new Point(713, 64);
            numUpDownCantPrendas.Name = "numUpDownCantPrendas";
            numUpDownCantPrendas.Size = new Size(103, 34);
            numUpDownCantPrendas.TabIndex = 5;
            numUpDownCantPrendas.KeyPress += NumericTextBox_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(713, 33);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 4;
            label6.Text = "Cantidad";
            // 
            // cmbPrendas
            // 
            cmbPrendas.DataSource = bindingSourceDetallesPrendas;
            cmbPrendas.DisplayMember = "Descripcion";
            cmbPrendas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrendas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            cmbPrendas.FormattingEnabled = true;
            cmbPrendas.Location = new Point(223, 63);
            cmbPrendas.Name = "cmbPrendas";
            cmbPrendas.Size = new Size(464, 36);
            cmbPrendas.TabIndex = 3;
            cmbPrendas.ValueMember = "Value";
            // 
            // bindingSourceDetallesPrendas
            // 
            bindingSourceDetallesPrendas.DataSource = typeof(Item);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(223, 33);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 2;
            label5.Text = "Prenda";
            // 
            // txtNumVenta
            // 
            txtNumVenta.Enabled = false;
            txtNumVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtNumVenta.Location = new Point(53, 65);
            txtNumVenta.Name = "txtNumVenta";
            txtNumVenta.Size = new Size(134, 34);
            txtNumVenta.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(53, 33);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 0;
            label4.Text = "Venta N°";
            // 
            // dataGridViewCarrito
            // 
            dataGridViewCarrito.AllowUserToAddRows = false;
            dataGridViewCarrito.AllowUserToDeleteRows = false;
            dataGridViewCarrito.AllowUserToOrderColumns = true;
            dataGridViewCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCarrito.AutoGenerateColumns = false;
            dataGridViewCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCarrito.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarrito.Columns.AddRange(new DataGridViewColumn[] { descripcionProductoDataGridViewTextBoxColumn, id, cantidadDataGridViewTextBoxColumn, subTotalDataGridViewTextBoxColumn, PrecioVenta });
            dataGridViewCarrito.DataSource = bindingSourceDetallesVentas;
            dataGridViewCarrito.Location = new Point(53, 503);
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.ReadOnly = true;
            dataGridViewCarrito.RowHeadersVisible = false;
            dataGridViewCarrito.RowHeadersWidth = 51;
            dataGridViewCarrito.Size = new Size(1472, 241);
            dataGridViewCarrito.TabIndex = 40;
            // 
            // descripcionProductoDataGridViewTextBoxColumn
            // 
            descripcionProductoDataGridViewTextBoxColumn.DataPropertyName = "DescripcionProducto";
            descripcionProductoDataGridViewTextBoxColumn.HeaderText = "Prenda";
            descripcionProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            descripcionProductoDataGridViewTextBoxColumn.Name = "descripcionProductoDataGridViewTextBoxColumn";
            descripcionProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // id
            // 
            id.DataPropertyName = "IdDetalleVenta";
            id.HeaderText = "id venta";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
            subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            subTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PrecioVenta
            // 
            PrecioVenta.HeaderText = "Precio Venta";
            PrecioVenta.MinimumWidth = 6;
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.ReadOnly = true;
            // 
            // bindingSourceDetallesVentas
            // 
            bindingSourceDetallesVentas.DataSource = typeof(RingoEntidades.DetallesVentas);
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(54, 463);
            label8.Name = "label8";
            label8.Size = new Size(146, 28);
            label8.TabIndex = 41;
            label8.Text = "Carrito Prendas";
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRegistrarVenta.Location = new Point(54, 769);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(179, 40);
            btnRegistrarVenta.TabIndex = 43;
            btnRegistrarVenta.Text = "Registrar";
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(906, 769);
            button1.Name = "button1";
            button1.Size = new Size(179, 40);
            button1.TabIndex = 44;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.Location = new Point(119, 16);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(125, 34);
            txtTotal.TabIndex = 46;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Forte", 9F);
            label10.Location = new Point(11, 29);
            label10.Name = "label10";
            label10.Size = new Size(64, 16);
            label10.TabIndex = 47;
            label10.Text = "TOTAL  $";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(1275, 749);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 77);
            groupBox2.TabIndex = 48;
            groupBox2.TabStop = false;
            // 
            // frmRegistrarVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1576, 847);
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(label8);
            Controls.Add(dataGridViewCarrito);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxDatosCliente);
            Controls.Add(label9);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmRegistrarVentas";
            Text = "Registrar Ventas";
            Load += frmRegistrarVentas_Load;
            Shown += Frm_Shown;
            groupBoxDatosCliente.ResumeLayout(false);
            groupBoxDatosCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)contactosBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)domiciliosBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numUpDownCantPrendas).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetallesPrendas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetallesVentas).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private GroupBox groupBoxDatosCliente;
        private Label label1;
        private Label label2;
        private TextBox txtNombreCliente;
        private TextBox txtDniCliente;
        private Label label3;
        private TextBox txtApellidoCliente;
        private GroupBox groupBox1;
        private Label label5;
        private TextBox txtNumVenta;
        private Label label4;
        private ComboBox cmbPrendas;
        private NumericUpDown numUpDownCantPrendas;
        private Label label6;
        private TextBox txtPrecioPrenda;
        private Label label7;
        private Button btnAgregarProducto;
        private DataGridView dataGridViewCarrito;
        private Label label8;
        private Button btnQuitarProducto;
        private Button btnRegistrarVenta;
        private Button button1;
        private Button button2;
        private TextBox txtTotal;
        private Label label10;
        private GroupBox groupBox2;
        private Button btnBuscarPrenda;
        private BindingSource bindingSourceDetallesPrendas;
        private BindingSource bindingSourceDetallesVentas;
        private DataGridViewTextBoxColumn descripcionProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private CheckBox checkEnvio;
        private Label lblTelefono;
        private Label lblDomicilio;
        private ComboBox comboTelefono;
        private ComboBox comboDomicilio;
        private BindingSource domiciliosBindingSource;
        private BindingSource contactosBindingSource;
        private Button btnBuscarVenta;
    }
}