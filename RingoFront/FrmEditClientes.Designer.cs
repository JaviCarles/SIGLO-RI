namespace RingoFront
{
    partial class FrmEditClientes
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
            groupBox1 = new GroupBox();
            txtPosCuil = new TextBox();
            txtPreCuil = new TextBox();
            txtDniCuil = new TextBox();
            label3 = new Label();
            txtDni = new TextBox();
            groupDomi = new GroupBox();
            linkDomicilios = new LinkLabel();
            btnDomicilio = new Button();
            dataGridDomicilios = new DataGridView();
            calleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pisoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            departamentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreBarrioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            observacionesBarrioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            NombreCiudad = new DataGridViewTextBoxColumn();
            codigoPostalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSourceDomicilio = new BindingSource(components);
            btnContactos = new Button();
            bindingSourceBarrio = new BindingSource(components);
            bindingSourceLocalidad = new BindingSource(components);
            bindingSourceProvincias = new BindingSource(components);
            txtNombre = new TextBox();
            label6 = new Label();
            bindingSourceRedes = new BindingSource(components);
            btnRegistrar = new Button();
            label5 = new Label();
            txtApellido = new TextBox();
            labelEstado = new Label();
            groupBoxPersona = new GroupBox();
            label1 = new Label();
            txtObservaciones = new TextBox();
            labelObservaciones = new Label();
            comboFiscal = new ComboBox();
            condicionesFiscalesBindingSource = new BindingSource(components);
            label8 = new Label();
            dateNacimiento = new DateTimePicker();
            label7 = new Label();
            comboEstado = new ComboBox();
            bindingSourceEstados = new BindingSource(components);
            btnCancelar = new Button();
            groupContac = new GroupBox();
            dataGridView1 = new DataGridView();
            codAreaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioRedSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreRedSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSourceContactos = new BindingSource(components);
            linkContactos = new LinkLabel();
            groupBox3 = new GroupBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupDomi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridDomicilios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDomicilio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceBarrio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProvincias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceRedes).BeginInit();
            groupBoxPersona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)condicionesFiscalesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceEstados).BeginInit();
            groupContac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceContactos).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPosCuil);
            groupBox1.Controls.Add(txtPreCuil);
            groupBox1.Controls.Add(txtDniCuil);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(282, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 76);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // txtPosCuil
            // 
            txtPosCuil.Location = new Point(165, 36);
            txtPosCuil.MaxLength = 2;
            txtPosCuil.Name = "txtPosCuil";
            txtPosCuil.Size = new Size(26, 26);
            txtPosCuil.TabIndex = 2;
            txtPosCuil.KeyPress += NumericTextBox_KeyPress;
            // 
            // txtPreCuil
            // 
            txtPreCuil.Location = new Point(4, 36);
            txtPreCuil.MaxLength = 3;
            txtPreCuil.Name = "txtPreCuil";
            txtPreCuil.Size = new Size(32, 26);
            txtPreCuil.TabIndex = 1;
            txtPreCuil.KeyPress += NumericTextBox_KeyPress;
            // 
            // txtDniCuil
            // 
            txtDniCuil.Enabled = false;
            txtDniCuil.Location = new Point(41, 36);
            txtDniCuil.MaxLength = 10;
            txtDniCuil.Name = "txtDniCuil";
            txtDniCuil.Size = new Size(118, 26);
            txtDniCuil.TabIndex = 7;
            txtDniCuil.TextAlign = HorizontalAlignment.Center;
            txtDniCuil.KeyPress += NumericTextBox_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 14);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 1;
            label3.Text = "CUIL / CUIT";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(92, 54);
            txtDni.MaxLength = 10;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(118, 26);
            txtDni.TabIndex = 3;
            txtDni.TextAlign = HorizontalAlignment.Center;
            txtDni.TextChanged += txtDni_TextChanged;
            txtDni.KeyPress += NumericTextBox_KeyPress;
            txtDni.Leave += txtDni_Leave;
            // 
            // groupDomi
            // 
            groupDomi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupDomi.Controls.Add(linkDomicilios);
            groupDomi.Controls.Add(btnDomicilio);
            groupDomi.Controls.Add(dataGridDomicilios);
            groupDomi.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            groupDomi.Location = new Point(4, 482);
            groupDomi.Name = "groupDomi";
            groupDomi.Padding = new Padding(0);
            groupDomi.Size = new Size(1046, 184);
            groupDomi.TabIndex = 2;
            groupDomi.TabStop = false;
            groupDomi.Text = "      Datos de Domicilio";
            // 
            // linkDomicilios
            // 
            linkDomicilios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            linkDomicilios.AutoSize = true;
            linkDomicilios.Location = new Point(917, -4);
            linkDomicilios.Name = "linkDomicilios";
            linkDomicilios.Size = new Size(106, 16);
            linkDomicilios.TabIndex = 9;
            linkDomicilios.TabStop = true;
            linkDomicilios.Text = "Ir a Domicilios";
            linkDomicilios.Visible = false;
            linkDomicilios.Click += btnDomicilio_Click;
            // 
            // btnDomicilio
            // 
            btnDomicilio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDomicilio.BackColor = SystemColors.GradientActiveCaption;
            btnDomicilio.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnDomicilio.Location = new Point(822, 83);
            btnDomicilio.Margin = new Padding(0);
            btnDomicilio.Name = "btnDomicilio";
            btnDomicilio.Size = new Size(187, 39);
            btnDomicilio.TabIndex = 8;
            btnDomicilio.Text = "Agregar domicilio";
            btnDomicilio.UseVisualStyleBackColor = false;
            btnDomicilio.Visible = false;
            btnDomicilio.Click += btnDomicilio_Click;
            // 
            // dataGridDomicilios
            // 
            dataGridDomicilios.AllowUserToAddRows = false;
            dataGridDomicilios.AllowUserToDeleteRows = false;
            dataGridDomicilios.AllowUserToOrderColumns = true;
            dataGridDomicilios.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridDomicilios.AutoGenerateColumns = false;
            dataGridDomicilios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridDomicilios.BackgroundColor = SystemColors.ControlLightLight;
            dataGridDomicilios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDomicilios.Columns.AddRange(new DataGridViewColumn[] { calleDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, pisoDataGridViewTextBoxColumn, departamentoDataGridViewTextBoxColumn, nombreBarrioDataGridViewTextBoxColumn, observacionesBarrioDataGridViewTextBoxColumn, NombreCiudad, codigoPostalDataGridViewTextBoxColumn });
            dataGridDomicilios.DataSource = bindingSourceDomicilio;
            dataGridDomicilios.Location = new Point(55, 32);
            dataGridDomicilios.Name = "dataGridDomicilios";
            dataGridDomicilios.ReadOnly = true;
            dataGridDomicilios.RowHeadersVisible = false;
            dataGridDomicilios.RowHeadersWidth = 51;
            dataGridDomicilios.Size = new Size(725, 128);
            dataGridDomicilios.TabIndex = 7;
            // 
            // calleDataGridViewTextBoxColumn
            // 
            calleDataGridViewTextBoxColumn.DataPropertyName = "Calle";
            calleDataGridViewTextBoxColumn.HeaderText = "Calle";
            calleDataGridViewTextBoxColumn.MinimumWidth = 6;
            calleDataGridViewTextBoxColumn.Name = "calleDataGridViewTextBoxColumn";
            calleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            alturaDataGridViewTextBoxColumn.HeaderText = "Nro";
            alturaDataGridViewTextBoxColumn.MinimumWidth = 6;
            alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            alturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pisoDataGridViewTextBoxColumn
            // 
            pisoDataGridViewTextBoxColumn.DataPropertyName = "Piso";
            pisoDataGridViewTextBoxColumn.HeaderText = "Piso";
            pisoDataGridViewTextBoxColumn.MinimumWidth = 6;
            pisoDataGridViewTextBoxColumn.Name = "pisoDataGridViewTextBoxColumn";
            pisoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departamentoDataGridViewTextBoxColumn
            // 
            departamentoDataGridViewTextBoxColumn.DataPropertyName = "Departamento";
            departamentoDataGridViewTextBoxColumn.HeaderText = "Dto";
            departamentoDataGridViewTextBoxColumn.MinimumWidth = 6;
            departamentoDataGridViewTextBoxColumn.Name = "departamentoDataGridViewTextBoxColumn";
            departamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreBarrioDataGridViewTextBoxColumn
            // 
            nombreBarrioDataGridViewTextBoxColumn.DataPropertyName = "NombreBarrio";
            nombreBarrioDataGridViewTextBoxColumn.HeaderText = "Barrio";
            nombreBarrioDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreBarrioDataGridViewTextBoxColumn.Name = "nombreBarrioDataGridViewTextBoxColumn";
            nombreBarrioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacionesBarrioDataGridViewTextBoxColumn
            // 
            observacionesBarrioDataGridViewTextBoxColumn.DataPropertyName = "ObservacionesBarrio";
            observacionesBarrioDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            observacionesBarrioDataGridViewTextBoxColumn.MinimumWidth = 6;
            observacionesBarrioDataGridViewTextBoxColumn.Name = "observacionesBarrioDataGridViewTextBoxColumn";
            observacionesBarrioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NombreCiudad
            // 
            NombreCiudad.DataPropertyName = "NombreCiudad";
            NombreCiudad.HeaderText = "Localidad";
            NombreCiudad.MinimumWidth = 6;
            NombreCiudad.Name = "NombreCiudad";
            NombreCiudad.ReadOnly = true;
            // 
            // codigoPostalDataGridViewTextBoxColumn
            // 
            codigoPostalDataGridViewTextBoxColumn.DataPropertyName = "CodigoPostal";
            codigoPostalDataGridViewTextBoxColumn.HeaderText = "Cod Postal";
            codigoPostalDataGridViewTextBoxColumn.MinimumWidth = 6;
            codigoPostalDataGridViewTextBoxColumn.Name = "codigoPostalDataGridViewTextBoxColumn";
            codigoPostalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceDomicilio
            // 
            bindingSourceDomicilio.DataSource = typeof(RingoEntidades.Domicilios);
            // 
            // btnContactos
            // 
            btnContactos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnContactos.BackColor = SystemColors.GradientActiveCaption;
            btnContactos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnContactos.Location = new Point(822, 77);
            btnContactos.Margin = new Padding(0);
            btnContactos.Name = "btnContactos";
            btnContactos.Size = new Size(187, 38);
            btnContactos.TabIndex = 7;
            btnContactos.Text = "Agregar Contactos";
            btnContactos.UseVisualStyleBackColor = false;
            btnContactos.Click += btnContactos_Click;
            // 
            // bindingSourceBarrio
            // 
            bindingSourceBarrio.DataSource = typeof(RingoEntidades.Barrios);
            // 
            // bindingSourceLocalidad
            // 
            bindingSourceLocalidad.DataSource = typeof(RingoEntidades.Ciudades);
            // 
            // bindingSourceProvincias
            // 
            bindingSourceProvincias.DataSource = typeof(RingoEntidades.Provincias);
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(94, 116);
            txtNombre.MaxLength = 99;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(255, 26);
            txtNombre.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(92, 92);
            label6.Name = "label6";
            label6.Size = new Size(80, 20);
            label6.TabIndex = 0;
            label6.Text = "Nombres";
            // 
            // bindingSourceRedes
            // 
            bindingSourceRedes.DataSource = typeof(RingoEntidades.RedesSociales);
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRegistrar.BackColor = SystemColors.GradientActiveCaption;
            btnRegistrar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnRegistrar.Location = new Point(70, -2);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(131, 32);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 92);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 1;
            label5.Text = "Apellidos";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(410, 116);
            txtApellido.MaxLength = 99;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(249, 26);
            txtApellido.TabIndex = 2;
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(785, 92);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(66, 20);
            labelEstado.TabIndex = 0;
            labelEstado.Text = "Estado";
            // 
            // groupBoxPersona
            // 
            groupBoxPersona.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPersona.Controls.Add(txtDni);
            groupBoxPersona.Controls.Add(label1);
            groupBoxPersona.Controls.Add(txtObservaciones);
            groupBoxPersona.Controls.Add(labelObservaciones);
            groupBoxPersona.Controls.Add(comboFiscal);
            groupBoxPersona.Controls.Add(label8);
            groupBoxPersona.Controls.Add(dateNacimiento);
            groupBoxPersona.Controls.Add(label7);
            groupBoxPersona.Controls.Add(txtApellido);
            groupBoxPersona.Controls.Add(label5);
            groupBoxPersona.Controls.Add(txtNombre);
            groupBoxPersona.Controls.Add(comboEstado);
            groupBoxPersona.Controls.Add(label6);
            groupBoxPersona.Controls.Add(labelEstado);
            groupBoxPersona.Controls.Add(groupBox1);
            groupBoxPersona.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            groupBoxPersona.Location = new Point(4, 66);
            groupBoxPersona.Name = "groupBoxPersona";
            groupBoxPersona.RightToLeft = RightToLeft.No;
            groupBoxPersona.Size = new Size(1046, 214);
            groupBoxPersona.TabIndex = 4;
            groupBoxPersona.TabStop = false;
            groupBoxPersona.Text = "       Datos Personales";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 32);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 8;
            label1.Text = "DNI";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(94, 175);
            txtObservaciones.MaxLength = 199;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(670, 26);
            txtObservaciones.TabIndex = 5;
            // 
            // labelObservaciones
            // 
            labelObservaciones.AutoSize = true;
            labelObservaciones.Location = new Point(92, 153);
            labelObservaciones.Name = "labelObservaciones";
            labelObservaciones.Size = new Size(127, 20);
            labelObservaciones.TabIndex = 6;
            labelObservaciones.Text = "Observaciones";
            // 
            // comboFiscal
            // 
            comboFiscal.DataSource = condicionesFiscalesBindingSource;
            comboFiscal.DisplayMember = "DetalleFiscal";
            comboFiscal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFiscal.FormattingEnabled = true;
            comboFiscal.Location = new Point(785, 51);
            comboFiscal.Name = "comboFiscal";
            comboFiscal.Size = new Size(159, 28);
            comboFiscal.TabIndex = 6;
            comboFiscal.ValueMember = "IdCondicionFiscal";
            // 
            // condicionesFiscalesBindingSource
            // 
            condicionesFiscalesBindingSource.DataSource = typeof(RingoEntidades.CondicionesFiscales);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(781, 29);
            label8.Name = "label8";
            label8.Size = new Size(108, 20);
            label8.TabIndex = 5;
            label8.Text = "Cond. Fiscal";
            // 
            // dateNacimiento
            // 
            dateNacimiento.Format = DateTimePickerFormat.Short;
            dateNacimiento.Location = new Point(570, 54);
            dateNacimiento.MaxDate = new DateTime(2600, 12, 31, 0, 0, 0, 0);
            dateNacimiento.MinDate = new DateTime(1910, 1, 1, 0, 0, 0, 0);
            dateNacimiento.Name = "dateNacimiento";
            dateNacimiento.Size = new Size(134, 26);
            dateNacimiento.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(570, 32);
            label7.Name = "label7";
            label7.Size = new Size(125, 20);
            label7.TabIndex = 5;
            label7.Text = "Fecha de Nac.";
            // 
            // comboEstado
            // 
            comboEstado.DataSource = bindingSourceEstados;
            comboEstado.DisplayMember = "Estado";
            comboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEstado.FormattingEnabled = true;
            comboEstado.Location = new Point(785, 114);
            comboEstado.Name = "comboEstado";
            comboEstado.Size = new Size(159, 28);
            comboEstado.TabIndex = 4;
            comboEstado.ValueMember = "IdEstado";
            comboEstado.SelectedIndexChanged += comboEstado_SelectedIndexChanged;
            // 
            // bindingSourceEstados
            // 
            bindingSourceEstados.DataSource = typeof(RingoEntidades.Estados);
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.BackColor = SystemColors.GradientActiveCaption;
            btnCancelar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnCancelar.Location = new Point(833, -2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 32);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // groupContac
            // 
            groupContac.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupContac.Controls.Add(dataGridView1);
            groupContac.Controls.Add(linkContactos);
            groupContac.Controls.Add(btnContactos);
            groupContac.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            groupContac.Location = new Point(4, 286);
            groupContac.Margin = new Padding(70, 3, 3, 3);
            groupContac.Name = "groupContac";
            groupContac.Padding = new Padding(70, 3, 70, 3);
            groupContac.Size = new Size(1046, 179);
            groupContac.TabIndex = 6;
            groupContac.TabStop = false;
            groupContac.Text = "       Datos Contacto";
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { codAreaDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, usuarioRedSocialDataGridViewTextBoxColumn, nombreRedSocialDataGridViewTextBoxColumn });
            dataGridView1.DataSource = bindingSourceContactos;
            dataGridView1.Location = new Point(55, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(725, 123);
            dataGridView1.TabIndex = 9;
            // 
            // codAreaDataGridViewTextBoxColumn
            // 
            codAreaDataGridViewTextBoxColumn.DataPropertyName = "codArea";
            codAreaDataGridViewTextBoxColumn.HeaderText = "Cod. Area";
            codAreaDataGridViewTextBoxColumn.MinimumWidth = 6;
            codAreaDataGridViewTextBoxColumn.Name = "codAreaDataGridViewTextBoxColumn";
            codAreaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            telefonoDataGridViewTextBoxColumn.MinimumWidth = 6;
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRedSocialDataGridViewTextBoxColumn
            // 
            usuarioRedSocialDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRedSocial";
            usuarioRedSocialDataGridViewTextBoxColumn.HeaderText = "Usuario Red Social";
            usuarioRedSocialDataGridViewTextBoxColumn.MinimumWidth = 6;
            usuarioRedSocialDataGridViewTextBoxColumn.Name = "usuarioRedSocialDataGridViewTextBoxColumn";
            usuarioRedSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreRedSocialDataGridViewTextBoxColumn
            // 
            nombreRedSocialDataGridViewTextBoxColumn.DataPropertyName = "NombreRedSocial";
            nombreRedSocialDataGridViewTextBoxColumn.HeaderText = "Nombre Red Social";
            nombreRedSocialDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreRedSocialDataGridViewTextBoxColumn.Name = "nombreRedSocialDataGridViewTextBoxColumn";
            nombreRedSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceContactos
            // 
            bindingSourceContactos.DataSource = typeof(RingoEntidades.Contactos);
            // 
            // linkContactos
            // 
            linkContactos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            linkContactos.AutoSize = true;
            linkContactos.Location = new Point(861, 2);
            linkContactos.Name = "linkContactos";
            linkContactos.Size = new Size(102, 16);
            linkContactos.TabIndex = 8;
            linkContactos.TabStop = true;
            linkContactos.Text = "Ir a Contactos";
            linkContactos.Visible = false;
            linkContactos.Click += btnContactos_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(1060, 61);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(43, 24);
            label2.Name = "label2";
            label2.Size = new Size(161, 21);
            label2.TabIndex = 0;
            label2.Text = "REGISTRAR CLIENTES";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(btnRegistrar);
            groupBox2.Controls.Add(btnCancelar);
            groupBox2.Location = new Point(4, 684);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1035, 37);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            // 
            // FrmEditClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 723);
            Controls.Add(groupBox3);
            Controls.Add(groupBoxPersona);
            Controls.Add(groupBox2);
            Controls.Add(groupContac);
            Controls.Add(groupDomi);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FrmEditClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alta Clientes";
            Load += FrmEditClientes_Load;
            Shown += Frm_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupDomi.ResumeLayout(false);
            groupDomi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridDomicilios).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDomicilio).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceBarrio).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProvincias).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceRedes).EndInit();
            groupBoxPersona.ResumeLayout(false);
            groupBoxPersona.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)condicionesFiscalesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceEstados).EndInit();
            groupContac.ResumeLayout(false);
            groupContac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceContactos).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private TextBox txtDni;
        private TextBox txtPosCuil;
        private TextBox txtPreCuil;
        private Label label3;
        private Label labelEstado;
        private GroupBox groupDomi;
        private TextBox txtNombre;
        private Label label6;
        private TextBox txtApellido;
        private Label label5;
        private GroupBox groupBoxPersona;
        private ComboBox comboEstado;
        private ComboBox comboFiscal;
        private Label label8;
        private DateTimePicker dateNacimiento;
        private Label label7;
        private TextBox txtObservaciones;
        private Label labelObservaciones;
        private Button btnCancelar;
        private Button btnRegistrar;
        private BindingSource condicionesFiscalesBindingSource;
        private BindingSource bindingSourceEstados;
        private BindingSource bindingSourceDomicilio;
        private BindingSource bindingSourceBarrio;
        private BindingSource bindingSourceLocalidad;
        private BindingSource bindingSourceProvincias;
        private BindingSource bindingSourceRedes;
        private Label label1;
        private TextBox txtDniCuil;
        private DataGridView dataGridDomicilios;
        private GroupBox groupContac;
        private Button btnContactos;
        private Button btnDomicilio;
        private GroupBox groupBox2;
        private LinkLabel linkContactos;
        private LinkLabel linkDomicilios;
        private DataGridView dataGridView1;
        private BindingSource bindingSourceContactos;
        private DataGridViewTextBoxColumn codAreaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioRedSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreRedSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn calleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pisoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn departamentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreBarrioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn observacionesBarrioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn NombreCiudad;
        private DataGridViewTextBoxColumn codigoPostalDataGridViewTextBoxColumn;
        private GroupBox groupBox3;
        private Label label2;
    }
}