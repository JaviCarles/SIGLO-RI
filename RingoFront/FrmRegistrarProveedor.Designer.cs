namespace RingoFront
{
    partial class FrmRegistrarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrarProveedor));
            labelTitulo = new Label();
            label1 = new Label();
            txtDniCuit = new TextBox();
            txtPreCuit = new TextBox();
            txtPosCuit = new TextBox();
            groupBoxCuit = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            txtRazonSocial = new TextBox();
            label4 = new Label();
            cbxCondicionFiscal = new ComboBox();
            bindingCondFisc = new BindingSource(components);
            label5 = new Label();
            label6 = new Label();
            cbxEstados = new ComboBox();
            bindingEstados = new BindingSource(components);
            label7 = new Label();
            txtDetallesProv = new TextBox();
            label16 = new Label();
            txtObsBarrio = new TextBox();
            label15 = new Label();
            cbxBarrio = new ComboBox();
            bindingBarrios = new BindingSource(components);
            label14 = new Label();
            txtCodPostal = new TextBox();
            label13 = new Label();
            cbxCiudad = new ComboBox();
            bindingCiudades = new BindingSource(components);
            label12 = new Label();
            cbxProvincia = new ComboBox();
            bindingProvincias = new BindingSource(components);
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            txtDepto = new TextBox();
            txtPiso = new TextBox();
            txtAltura = new TextBox();
            label8 = new Label();
            txtCalle = new TextBox();
            lblContactos = new Label();
            lblDomicilio = new Label();
            dataGridView1 = new DataGridView();
            esFijoDataGridViewTextBoxColumn = new DataGridViewCheckBoxColumn();
            codAreaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioRedSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreRedSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingContactos = new BindingSource(components);
            btnAgregarContactos = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            bindingCategorias = new BindingSource(components);
            bindingSubCategorias = new BindingSource(components);
            dateTimeFechaInicio = new DateTimePicker();
            label17 = new Label();
            btnBuscar = new Button();
            groupBoxCuit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingCondFisc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingEstados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingBarrios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingCiudades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingProvincias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingContactos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSubCategorias).BeginInit();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.BackColor = Color.Transparent;
            labelTitulo.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            labelTitulo.Location = new Point(34, 18);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(235, 23);
            labelTitulo.TabIndex = 21;
            labelTitulo.Text = "REGISTRAR PROVEEDOR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(59, 58);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 28);
            label1.TabIndex = 22;
            label1.Text = "C.U.I.T.";
            // 
            // txtDniCuit
            // 
            txtDniCuit.Font = new Font("Segoe UI", 12F);
            txtDniCuit.ForeColor = SystemColors.WindowText;
            txtDniCuit.Location = new Point(90, 10);
            txtDniCuit.Margin = new Padding(4, 3, 4, 3);
            txtDniCuit.MaxLength = 9;
            txtDniCuit.Name = "txtDniCuit";
            txtDniCuit.Size = new Size(167, 34);
            txtDniCuit.TabIndex = 23;
            txtDniCuit.KeyPress += NumericTextBox_KeyPress;
            // 
            // txtPreCuit
            // 
            txtPreCuit.Font = new Font("Segoe UI", 12F);
            txtPreCuit.ForeColor = SystemColors.WindowText;
            txtPreCuit.Location = new Point(7, 10);
            txtPreCuit.Margin = new Padding(4, 3, 4, 3);
            txtPreCuit.MaxLength = 2;
            txtPreCuit.Name = "txtPreCuit";
            txtPreCuit.Size = new Size(41, 34);
            txtPreCuit.TabIndex = 24;
            txtPreCuit.KeyPress += NumericTextBox_KeyPress;
            // 
            // txtPosCuit
            // 
            txtPosCuit.Font = new Font("Segoe UI", 12F);
            txtPosCuit.ForeColor = SystemColors.WindowText;
            txtPosCuit.Location = new Point(293, 11);
            txtPosCuit.Margin = new Padding(4, 3, 4, 3);
            txtPosCuit.MaxLength = 1;
            txtPosCuit.Name = "txtPosCuit";
            txtPosCuit.Size = new Size(45, 34);
            txtPosCuit.TabIndex = 25;
            txtPosCuit.KeyPress += NumericTextBox_KeyPress;
            // 
            // groupBoxCuit
            // 
            groupBoxCuit.Controls.Add(label3);
            groupBoxCuit.Controls.Add(label2);
            groupBoxCuit.Controls.Add(txtPreCuit);
            groupBoxCuit.Controls.Add(txtPosCuit);
            groupBoxCuit.Controls.Add(txtDniCuit);
            groupBoxCuit.Location = new Point(57, 82);
            groupBoxCuit.Name = "groupBoxCuit";
            groupBoxCuit.Size = new Size(345, 45);
            groupBoxCuit.TabIndex = 26;
            groupBoxCuit.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(265, 13);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(20, 28);
            label3.TabIndex = 27;
            label3.Text = "-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(56, 13);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(20, 28);
            label2.TabIndex = 26;
            label2.Text = "-";
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRazonSocial.Font = new Font("Segoe UI", 12F);
            txtRazonSocial.ForeColor = SystemColors.WindowText;
            txtRazonSocial.Location = new Point(446, 92);
            txtRazonSocial.Margin = new Padding(4, 3, 4, 3);
            txtRazonSocial.MaxLength = 99;
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(412, 34);
            txtRazonSocial.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(446, 58);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(156, 28);
            label4.TabIndex = 28;
            label4.Text = "RAZÓN SOCIAL";
            // 
            // cbxCondicionFiscal
            // 
            cbxCondicionFiscal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbxCondicionFiscal.DataSource = bindingCondFisc;
            cbxCondicionFiscal.DisplayMember = "DetalleFiscal";
            cbxCondicionFiscal.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCondicionFiscal.Font = new Font("Segoe UI", 12F);
            cbxCondicionFiscal.FormattingEnabled = true;
            cbxCondicionFiscal.ItemHeight = 28;
            cbxCondicionFiscal.Location = new Point(964, 193);
            cbxCondicionFiscal.Margin = new Padding(4, 3, 4, 3);
            cbxCondicionFiscal.Name = "cbxCondicionFiscal";
            cbxCondicionFiscal.Size = new Size(283, 36);
            cbxCondicionFiscal.TabIndex = 29;
            cbxCondicionFiscal.ValueMember = "IdCondicionFiscal";
            // 
            // bindingCondFisc
            // 
            bindingCondFisc.DataSource = typeof(RingoEntidades.CondicionesFiscales);
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Transparent;
            label5.Location = new Point(964, 162);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(194, 28);
            label5.TabIndex = 30;
            label5.Text = "CONDICION FISCAL";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(964, 59);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 28);
            label6.TabIndex = 31;
            label6.Text = "ESTADO";
            // 
            // cbxEstados
            // 
            cbxEstados.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbxEstados.DataSource = bindingEstados;
            cbxEstados.DisplayMember = "Estado";
            cbxEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEstados.Enabled = false;
            cbxEstados.Font = new Font("Segoe UI", 12F);
            cbxEstados.FormattingEnabled = true;
            cbxEstados.ItemHeight = 28;
            cbxEstados.Location = new Point(964, 90);
            cbxEstados.Margin = new Padding(4, 3, 4, 3);
            cbxEstados.Name = "cbxEstados";
            cbxEstados.Size = new Size(283, 36);
            cbxEstados.TabIndex = 32;
            cbxEstados.ValueMember = "IdEstado";
            // 
            // bindingEstados
            // 
            bindingEstados.DataSource = typeof(RingoEntidades.Estados);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(57, 140);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(105, 28);
            label7.TabIndex = 33;
            label7.Text = "DETALLES";
            // 
            // txtDetallesProv
            // 
            txtDetallesProv.Enabled = false;
            txtDetallesProv.Font = new Font("Segoe UI", 12F);
            txtDetallesProv.Location = new Point(57, 175);
            txtDetallesProv.Margin = new Padding(4, 3, 4, 3);
            txtDetallesProv.MaxLength = 219;
            txtDetallesProv.Multiline = true;
            txtDetallesProv.Name = "txtDetallesProv";
            txtDetallesProv.Size = new Size(338, 100);
            txtDetallesProv.TabIndex = 34;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label16.ForeColor = Color.Transparent;
            label16.Location = new Point(446, 501);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(252, 28);
            label16.TabIndex = 48;
            label16.Text = "OBSERVACIONES BARRIO";
            // 
            // txtObsBarrio
            // 
            txtObsBarrio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtObsBarrio.Font = new Font("Segoe UI", 12F);
            txtObsBarrio.ForeColor = SystemColors.WindowText;
            txtObsBarrio.Location = new Point(446, 534);
            txtObsBarrio.Margin = new Padding(4, 3, 4, 3);
            txtObsBarrio.MaxLength = 149;
            txtObsBarrio.Name = "txtObsBarrio";
            txtObsBarrio.Size = new Size(799, 34);
            txtObsBarrio.TabIndex = 36;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label15.ForeColor = Color.Transparent;
            label15.Location = new Point(60, 501);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(86, 28);
            label15.TabIndex = 47;
            label15.Text = "BARRIO";
            // 
            // cbxBarrio
            // 
            cbxBarrio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxBarrio.DataSource = bindingBarrios;
            cbxBarrio.DisplayMember = "NombreBarrio";
            cbxBarrio.Font = new Font("Segoe UI", 12F);
            cbxBarrio.FormattingEnabled = true;
            cbxBarrio.ItemHeight = 28;
            cbxBarrio.Location = new Point(60, 532);
            cbxBarrio.Margin = new Padding(4, 3, 4, 3);
            cbxBarrio.Name = "cbxBarrio";
            cbxBarrio.Size = new Size(324, 36);
            cbxBarrio.TabIndex = 46;
            cbxBarrio.ValueMember = "IdBarrio";
            // 
            // bindingBarrios
            // 
            bindingBarrios.DataSource = typeof(RingoEntidades.Barrios);
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label14.ForeColor = Color.Transparent;
            label14.Location = new Point(964, 420);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(168, 28);
            label14.TabIndex = 45;
            label14.Text = "CODIGO POSTAL";
            // 
            // txtCodPostal
            // 
            txtCodPostal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCodPostal.Font = new Font("Segoe UI", 12F);
            txtCodPostal.ForeColor = SystemColors.WindowText;
            txtCodPostal.Location = new Point(964, 455);
            txtCodPostal.Margin = new Padding(4, 3, 4, 3);
            txtCodPostal.MaxLength = 9;
            txtCodPostal.Name = "txtCodPostal";
            txtCodPostal.Size = new Size(281, 34);
            txtCodPostal.TabIndex = 44;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label13.ForeColor = Color.Transparent;
            label13.Location = new Point(445, 418);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(123, 28);
            label13.TabIndex = 43;
            label13.Text = "LOCALIDAD";
            // 
            // cbxCiudad
            // 
            cbxCiudad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbxCiudad.DataSource = bindingCiudades;
            cbxCiudad.DisplayMember = "NombreCiudad";
            cbxCiudad.Font = new Font("Segoe UI", 12F);
            cbxCiudad.FormattingEnabled = true;
            cbxCiudad.ItemHeight = 28;
            cbxCiudad.Location = new Point(446, 453);
            cbxCiudad.Margin = new Padding(4, 3, 4, 3);
            cbxCiudad.Name = "cbxCiudad";
            cbxCiudad.Size = new Size(472, 36);
            cbxCiudad.TabIndex = 42;
            cbxCiudad.ValueMember = "IdCiudad";
            cbxCiudad.SelectedIndexChanged += cbxCiudad_SelectedIndexChanged;
            // 
            // bindingCiudades
            // 
            bindingCiudades.DataSource = typeof(RingoEntidades.Ciudades);
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.ForeColor = Color.Transparent;
            label12.Location = new Point(54, 420);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(119, 28);
            label12.TabIndex = 37;
            label12.Text = "PROVINCIA";
            // 
            // cbxProvincia
            // 
            cbxProvincia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxProvincia.DataSource = bindingProvincias;
            cbxProvincia.DisplayMember = "NombreProvincia";
            cbxProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProvincia.Font = new Font("Segoe UI", 12F);
            cbxProvincia.FormattingEnabled = true;
            cbxProvincia.ItemHeight = 28;
            cbxProvincia.Location = new Point(60, 453);
            cbxProvincia.Margin = new Padding(4, 3, 4, 3);
            cbxProvincia.Name = "cbxProvincia";
            cbxProvincia.Size = new Size(324, 36);
            cbxProvincia.TabIndex = 36;
            cbxProvincia.ValueMember = "IdProvincia";
            cbxProvincia.SelectedIndexChanged += cbxProvincia_SelectedIndexChanged;
            // 
            // bindingProvincias
            // 
            bindingProvincias.DataSource = typeof(RingoEntidades.Provincias);
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.ForeColor = Color.Transparent;
            label11.Location = new Point(964, 344);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(173, 28);
            label11.TabIndex = 41;
            label11.Text = "DEPARTAMENTO";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.ForeColor = Color.Transparent;
            label10.Location = new Point(703, 344);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(150, 28);
            label10.TabIndex = 40;
            label10.Text = "PISO / SECTOR";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.ForeColor = Color.Transparent;
            label9.Location = new Point(446, 344);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(141, 28);
            label9.TabIndex = 39;
            label9.Text = "ALTURA/NRO";
            // 
            // txtDepto
            // 
            txtDepto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDepto.Font = new Font("Segoe UI", 12F);
            txtDepto.ForeColor = SystemColors.WindowText;
            txtDepto.Location = new Point(962, 375);
            txtDepto.Margin = new Padding(4, 3, 4, 3);
            txtDepto.MaxLength = 9;
            txtDepto.Name = "txtDepto";
            txtDepto.Size = new Size(283, 34);
            txtDepto.TabIndex = 38;
            // 
            // txtPiso
            // 
            txtPiso.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPiso.Font = new Font("Segoe UI", 12F);
            txtPiso.ForeColor = SystemColors.WindowText;
            txtPiso.Location = new Point(703, 375);
            txtPiso.Margin = new Padding(4, 3, 4, 3);
            txtPiso.MaxLength = 9;
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(215, 34);
            txtPiso.TabIndex = 37;
            // 
            // txtAltura
            // 
            txtAltura.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAltura.Font = new Font("Segoe UI", 12F);
            txtAltura.ForeColor = SystemColors.WindowText;
            txtAltura.Location = new Point(446, 375);
            txtAltura.Margin = new Padding(4, 3, 4, 3);
            txtAltura.MaxLength = 9;
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(195, 34);
            txtAltura.TabIndex = 28;
            txtAltura.KeyPress += NumericTextBox_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = Color.Transparent;
            label8.Location = new Point(59, 344);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(69, 28);
            label8.TabIndex = 36;
            label8.Text = "CALLE";
            // 
            // txtCalle
            // 
            txtCalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCalle.Font = new Font("Segoe UI", 12F);
            txtCalle.ForeColor = SystemColors.WindowText;
            txtCalle.Location = new Point(59, 375);
            txtCalle.Margin = new Padding(4, 3, 4, 3);
            txtCalle.MaxLength = 99;
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(324, 34);
            txtCalle.TabIndex = 28;
            // 
            // lblContactos
            // 
            lblContactos.AutoSize = true;
            lblContactos.BackColor = Color.Transparent;
            lblContactos.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblContactos.ForeColor = Color.Transparent;
            lblContactos.Location = new Point(54, 595);
            lblContactos.Margin = new Padding(4, 0, 4, 0);
            lblContactos.Name = "lblContactos";
            lblContactos.Size = new Size(175, 37);
            lblContactos.TabIndex = 36;
            lblContactos.Text = "CONTACTOS";
            // 
            // lblDomicilio
            // 
            lblDomicilio.AutoSize = true;
            lblDomicilio.BackColor = Color.Transparent;
            lblDomicilio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDomicilio.ForeColor = Color.Transparent;
            lblDomicilio.Location = new Point(59, 300);
            lblDomicilio.Margin = new Padding(4, 0, 4, 0);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(161, 37);
            lblDomicilio.TabIndex = 37;
            lblDomicilio.Text = "DOMICILIO";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { esFijoDataGridViewTextBoxColumn, codAreaDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, usuarioRedSocialDataGridViewTextBoxColumn, nombreRedSocialDataGridViewTextBoxColumn });
            dataGridView1.DataSource = bindingContactos;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Cooper Black", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(57, 641);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Cooper Black", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new Font("Georgia", 7.8F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Size = new Size(1187, 228);
            dataGridView1.TabIndex = 38;
            // 
            // esFijoDataGridViewTextBoxColumn
            // 
            esFijoDataGridViewTextBoxColumn.DataPropertyName = "esFijo";
            esFijoDataGridViewTextBoxColumn.HeaderText = "Tel. Fijo";
            esFijoDataGridViewTextBoxColumn.MinimumWidth = 6;
            esFijoDataGridViewTextBoxColumn.Name = "esFijoDataGridViewTextBoxColumn";
            esFijoDataGridViewTextBoxColumn.ReadOnly = true;
            esFijoDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            esFijoDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            esFijoDataGridViewTextBoxColumn.Width = 50;
            // 
            // codAreaDataGridViewTextBoxColumn
            // 
            codAreaDataGridViewTextBoxColumn.DataPropertyName = "codArea";
            codAreaDataGridViewTextBoxColumn.HeaderText = "Cod. Area";
            codAreaDataGridViewTextBoxColumn.MinimumWidth = 6;
            codAreaDataGridViewTextBoxColumn.Name = "codAreaDataGridViewTextBoxColumn";
            codAreaDataGridViewTextBoxColumn.ReadOnly = true;
            codAreaDataGridViewTextBoxColumn.Width = 80;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            telefonoDataGridViewTextBoxColumn.MinimumWidth = 6;
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            telefonoDataGridViewTextBoxColumn.Width = 120;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRedSocialDataGridViewTextBoxColumn
            // 
            usuarioRedSocialDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            usuarioRedSocialDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRedSocial";
            usuarioRedSocialDataGridViewTextBoxColumn.HeaderText = "Usuario Red Social";
            usuarioRedSocialDataGridViewTextBoxColumn.MinimumWidth = 6;
            usuarioRedSocialDataGridViewTextBoxColumn.Name = "usuarioRedSocialDataGridViewTextBoxColumn";
            usuarioRedSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreRedSocialDataGridViewTextBoxColumn
            // 
            nombreRedSocialDataGridViewTextBoxColumn.DataPropertyName = "NombreRedSocial";
            nombreRedSocialDataGridViewTextBoxColumn.HeaderText = "Red Social";
            nombreRedSocialDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreRedSocialDataGridViewTextBoxColumn.Name = "nombreRedSocialDataGridViewTextBoxColumn";
            nombreRedSocialDataGridViewTextBoxColumn.ReadOnly = true;
            nombreRedSocialDataGridViewTextBoxColumn.Width = 180;
            // 
            // bindingContactos
            // 
            bindingContactos.DataSource = typeof(RingoEntidades.Contactos);
            // 
            // btnAgregarContactos
            // 
            btnAgregarContactos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarContactos.BackColor = SystemColors.ActiveCaption;
            btnAgregarContactos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregarContactos.Location = new Point(950, 586);
            btnAgregarContactos.Margin = new Padding(4, 3, 4, 3);
            btnAgregarContactos.Name = "btnAgregarContactos";
            btnAgregarContactos.Size = new Size(285, 37);
            btnAgregarContactos.TabIndex = 39;
            btnAgregarContactos.Text = "AGREGAR CONTACTOS";
            btnAgregarContactos.UseVisualStyleBackColor = false;
            btnAgregarContactos.Click += btnAgregarContactos_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            btnGuardar.Enabled = false;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.Location = new Point(60, 951);
            btnGuardar.Margin = new Padding(4, 3, 4, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(229, 38);
            btnGuardar.TabIndex = 40;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.Location = new Point(1007, 951);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(229, 38);
            btnCancelar.TabIndex = 41;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // bindingCategorias
            // 
            bindingCategorias.DataSource = typeof(RingoEntidades.CategoriasPrendas);
            // 
            // bindingSubCategorias
            // 
            bindingSubCategorias.DataSource = typeof(RingoEntidades.SubCategoriasPrendas);
            // 
            // dateTimeFechaInicio
            // 
            dateTimeFechaInicio.Font = new Font("Cooper Black", 12F);
            dateTimeFechaInicio.Location = new Point(446, 193);
            dateTimeFechaInicio.MaxDate = new DateTime(2200, 1, 4, 0, 0, 0, 0);
            dateTimeFechaInicio.MinDate = new DateTime(1759, 12, 30, 0, 0, 0, 0);
            dateTimeFechaInicio.Name = "dateTimeFechaInicio";
            dateTimeFechaInicio.Size = new Size(472, 30);
            dateTimeFechaInicio.TabIndex = 49;
            dateTimeFechaInicio.Value = new DateTime(2024, 9, 19, 2, 24, 39, 0);
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label17.ForeColor = Color.Transparent;
            label17.Location = new Point(446, 162);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(276, 28);
            label17.TabIndex = 50;
            label17.Text = "FECHA INICIO ACTIVIDADES";
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscar.Location = new Point(875, 92);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(43, 36);
            btnBuscar.TabIndex = 51;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // FrmRegistrarProveedor
            // 
            AutoScaleDimensions = new SizeF(10F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1314, 1016);
            Controls.Add(btnBuscar);
            Controls.Add(label17);
            Controls.Add(dateTimeFechaInicio);
            Controls.Add(label16);
            Controls.Add(txtObsBarrio);
            Controls.Add(label15);
            Controls.Add(cbxBarrio);
            Controls.Add(label14);
            Controls.Add(txtCodPostal);
            Controls.Add(btnCancelar);
            Controls.Add(label13);
            Controls.Add(btnGuardar);
            Controls.Add(cbxCiudad);
            Controls.Add(btnAgregarContactos);
            Controls.Add(label12);
            Controls.Add(cbxProvincia);
            Controls.Add(dataGridView1);
            Controls.Add(lblDomicilio);
            Controls.Add(label11);
            Controls.Add(lblContactos);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtDetallesProv);
            Controls.Add(txtDepto);
            Controls.Add(label7);
            Controls.Add(txtPiso);
            Controls.Add(cbxEstados);
            Controls.Add(txtAltura);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(txtCalle);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cbxCondicionFiscal);
            Controls.Add(label4);
            Controls.Add(txtRazonSocial);
            Controls.Add(groupBoxCuit);
            Controls.Add(labelTitulo);
            DoubleBuffered = true;
            Font = new Font("Cooper Black", 9F);
            ForeColor = Color.Transparent;
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = false;
            Name = "FrmRegistrarProveedor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Proveedor";
            Load += FrmRegistrarProveedor_Load;
            Shown += Frm_Shown;
            groupBoxCuit.ResumeLayout(false);
            groupBoxCuit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingCondFisc).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingEstados).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingBarrios).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingCiudades).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingProvincias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingContactos).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingCategorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSubCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label label1;
        private TextBox txtDniCuit;
        private TextBox txtPreCuit;
        private TextBox txtPosCuit;
        private GroupBox groupBoxCuit;
        private Label label3;
        private Label label2;
        private TextBox txtRazonSocial;
        private Label label4;
        internal ComboBox cbxCondicionFiscal;
        private Label label5;
        private Label label6;
        internal ComboBox cbxEstados;
        private Label label7;
        private TextBox txtDetallesProv;
        private Label label8;
        private TextBox txtCalle;
        private TextBox txtDepto;
        private TextBox txtPiso;
        private TextBox txtAltura;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox txtObsBarrio;
        private Label label15;
        internal ComboBox cbxBarrio;
        private Label label14;
        private TextBox txtCodPostal;
        private Label label13;
        internal ComboBox cbxCiudad;
        private Label label12;
        internal ComboBox cbxProvincia;
        private Label label16;
        private Label lblContactos;
        private Label lblDomicilio;
        private DataGridView dataGridView1;
        private Button btnAgregarContactos;
        private Button btnGuardar;
        private Button btnCancelar;
        private BindingSource bindingProvincias;
        private BindingSource bindingCiudades;
        private BindingSource bindingBarrios;
        private BindingSource bindingContactos;
        private BindingSource bindingCondFisc;
        private BindingSource bindingEstados;
        private DataGridViewCheckBoxColumn esFijoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codAreaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioRedSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreRedSocialDataGridViewTextBoxColumn;
        private BindingSource bindingCategorias;
        private BindingSource bindingSubCategorias;
        private DateTimePicker dateTimeFechaInicio;
        private Label label17;
        private Button btnBuscar;
    }
}