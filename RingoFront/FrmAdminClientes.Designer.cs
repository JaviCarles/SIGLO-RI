namespace RingoFront
{
    partial class FrmAdminClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminClientes));
            groupBoxPersona = new GroupBox();
            checkObservaciones = new CheckBox();
            checkAnulados = new CheckBox();
            label21 = new Label();
            btnBuscar = new Button();
            comboCiudad = new ComboBox();
            bindingSourceCiudades = new BindingSource(components);
            label3 = new Label();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            comboFilas = new ComboBox();
            bindingSourcePersonas = new BindingSource(components);
            dataGridPersonas = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            EstadoPersona = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            Modificar = new DataGridViewButtonColumn();
            groupBoxRegistro = new GroupBox();
            btnRegistrar = new Button();
            TituloRegistro2 = new Label();
            TituloRegistro1 = new Label();
            groupBoxBotones = new GroupBox();
            btnConsultar = new Button();
            btnSalir = new Button();
            groupBoxHeader = new GroupBox();
            Titulo = new Label();
            linkPrimerPagina = new LinkLabel();
            linkPagAnterior = new LinkLabel();
            linkPagina1 = new LinkLabel();
            linkPagina2 = new LinkLabel();
            linkPagina3 = new LinkLabel();
            linkPagina4 = new LinkLabel();
            flowLayoutPanelLinks = new FlowLayoutPanel();
            linkPagina5 = new LinkLabel();
            linkPaginaSiguiente = new LinkLabel();
            linkUltimaPagina = new LinkLabel();
            label1 = new Label();
            txtPag = new Label();
            btnEliminar = new Button();
            btnListadoXls = new Button();
            groupBoxPersona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceCiudades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcePersonas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPersonas).BeginInit();
            groupBoxRegistro.SuspendLayout();
            groupBoxBotones.SuspendLayout();
            groupBoxHeader.SuspendLayout();
            flowLayoutPanelLinks.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxPersona
            // 
            groupBoxPersona.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPersona.Controls.Add(checkObservaciones);
            groupBoxPersona.Controls.Add(checkAnulados);
            groupBoxPersona.Controls.Add(label21);
            groupBoxPersona.Controls.Add(btnBuscar);
            groupBoxPersona.Controls.Add(comboCiudad);
            groupBoxPersona.Controls.Add(label3);
            groupBoxPersona.Controls.Add(txtDni);
            groupBoxPersona.Controls.Add(txtNombre);
            groupBoxPersona.Controls.Add(label6);
            groupBoxPersona.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            groupBoxPersona.Location = new Point(0, 72);
            groupBoxPersona.Name = "groupBoxPersona";
            groupBoxPersona.Padding = new Padding(26, 22, 26, 22);
            groupBoxPersona.Size = new Size(1211, 202);
            groupBoxPersona.TabIndex = 5;
            groupBoxPersona.TabStop = false;
            groupBoxPersona.Text = "       Datos Personales";
            // 
            // checkObservaciones
            // 
            checkObservaciones.AutoSize = true;
            checkObservaciones.Location = new Point(826, 86);
            checkObservaciones.Margin = new Padding(3, 2, 3, 2);
            checkObservaciones.Name = "checkObservaciones";
            checkObservaciones.Size = new Size(162, 20);
            checkObservaciones.TabIndex = 25;
            checkObservaciones.Text = "Con Observaciones";
            checkObservaciones.UseVisualStyleBackColor = true;
            // 
            // checkAnulados
            // 
            checkAnulados.AutoSize = true;
            checkAnulados.Location = new Point(826, 52);
            checkAnulados.Margin = new Padding(3, 2, 3, 2);
            checkAnulados.Name = "checkAnulados";
            checkAnulados.Size = new Size(136, 20);
            checkAnulados.TabIndex = 4;
            checkAnulados.Text = "Incluir Anulados";
            checkAnulados.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(72, 133);
            label21.Name = "label21";
            label21.Size = new Size(76, 16);
            label21.TabIndex = 24;
            label21.Text = "Localidad";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.GradientActiveCaption;
            btnBuscar.BackgroundImage = Properties.Resources.Captura_de_pantalla_2024_10_31_092501;
            btnBuscar.BackgroundImageLayout = ImageLayout.None;
            btnBuscar.Location = new Point(761, 75);
            btnBuscar.Margin = new Padding(3, 2, 3, 2);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(34, 29);
            btnBuscar.TabIndex = 5;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // comboCiudad
            // 
            comboCiudad.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboCiudad.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboCiudad.DataSource = bindingSourceCiudades;
            comboCiudad.DisplayMember = "NombreCiudad";
            comboCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCiudad.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            comboCiudad.FormattingEnabled = true;
            comboCiudad.Location = new Point(72, 156);
            comboCiudad.Margin = new Padding(3, 2, 3, 2);
            comboCiudad.Name = "comboCiudad";
            comboCiudad.Size = new Size(216, 26);
            comboCiudad.TabIndex = 3;
            comboCiudad.ValueMember = "IdCiudad";
            // 
            // bindingSourceCiudades
            // 
            bindingSourceCiudades.DataSource = typeof(RingoEntidades.Ciudades);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 52);
            label3.Name = "label3";
            label3.Size = new Size(83, 16);
            label3.TabIndex = 7;
            label3.Text = "DNI cliente";
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            txtDni.Location = new Point(74, 82);
            txtDni.MaxLength = 10;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(152, 24);
            txtDni.TabIndex = 1;
            txtDni.TextAlign = HorizontalAlignment.Center;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            txtNombre.Location = new Point(268, 83);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.MaxLength = 99;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(475, 24);
            txtNombre.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(268, 52);
            label6.Name = "label6";
            label6.Size = new Size(153, 16);
            label6.TabIndex = 0;
            label6.Text = "Nombres o Apellidos";
            // 
            // comboFilas
            // 
            comboFilas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFilas.FormattingEnabled = true;
            comboFilas.Location = new Point(39, 288);
            comboFilas.Margin = new Padding(3, 2, 3, 2);
            comboFilas.Name = "comboFilas";
            comboFilas.Size = new Size(40, 23);
            comboFilas.TabIndex = 6;
            comboFilas.SelectedIndexChanged += comboFilas_SelectedIndexChanged;
            // 
            // bindingSourcePersonas
            // 
            bindingSourcePersonas.DataSource = typeof(RingoEntidades.Personas);
            // 
            // dataGridPersonas
            // 
            dataGridPersonas.AllowUserToAddRows = false;
            dataGridPersonas.AllowUserToDeleteRows = false;
            dataGridPersonas.AllowUserToOrderColumns = true;
            dataGridPersonas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridPersonas.AutoGenerateColumns = false;
            dataGridPersonas.BackgroundColor = SystemColors.ControlLightLight;
            dataGridPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPersonas.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn7, EstadoPersona, dataGridViewTextBoxColumn6, Modificar });
            dataGridPersonas.DataSource = bindingSourcePersonas;
            dataGridPersonas.Location = new Point(39, 312);
            dataGridPersonas.Margin = new Padding(3, 2, 3, 2);
            dataGridPersonas.Name = "dataGridPersonas";
            dataGridPersonas.ReadOnly = true;
            dataGridPersonas.RowHeadersVisible = false;
            dataGridPersonas.RowHeadersWidth = 51;
            dataGridPersonas.Size = new Size(981, 248);
            dataGridPersonas.TabIndex = 7;
            dataGridPersonas.CellContentClick += dataGridPersonas_CellContentClick;
            dataGridPersonas.CellMouseEnter += dataGridPersonas_CellMouseEnter;
            dataGridPersonas.CellMouseLeave += dataGridPersonas_CellMouseLeave;
            dataGridPersonas.CellPainting += dataGridPersonas_CellPainting;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "Dni";
            dataGridViewTextBoxColumn1.FillWeight = 8F;
            dataGridViewTextBoxColumn1.HeaderText = "Dni";
            dataGridViewTextBoxColumn1.MinimumWidth = 100;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            dataGridViewTextBoxColumn2.FillWeight = 10F;
            dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            dataGridViewTextBoxColumn2.MinimumWidth = 150;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.DataPropertyName = "Apellidos";
            dataGridViewTextBoxColumn3.FillWeight = 10F;
            dataGridViewTextBoxColumn3.HeaderText = "Apellidos";
            dataGridViewTextBoxColumn3.MinimumWidth = 150;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "Cuil";
            dataGridViewTextBoxColumn4.FillWeight = 8F;
            dataGridViewTextBoxColumn4.HeaderText = "Cuil";
            dataGridViewTextBoxColumn4.MinimumWidth = 100;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn5.DataPropertyName = "FechaNacimiento";
            dataGridViewTextBoxColumn5.FillWeight = 8F;
            dataGridViewTextBoxColumn5.HeaderText = "FechaNacimiento";
            dataGridViewTextBoxColumn5.MinimumWidth = 100;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn7.DataPropertyName = "DetalleFiscal";
            dataGridViewTextBoxColumn7.FillWeight = 12F;
            dataGridViewTextBoxColumn7.HeaderText = "DetalleFiscal";
            dataGridViewTextBoxColumn7.MinimumWidth = 150;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // EstadoPersona
            // 
            EstadoPersona.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EstadoPersona.DataPropertyName = "EstadoPersona";
            EstadoPersona.FillWeight = 10F;
            EstadoPersona.HeaderText = "Estado";
            EstadoPersona.MinimumWidth = 130;
            EstadoPersona.Name = "EstadoPersona";
            EstadoPersona.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn6.DataPropertyName = "Observaciones";
            dataGridViewTextBoxColumn6.FillWeight = 14F;
            dataGridViewTextBoxColumn6.HeaderText = "Observaciones";
            dataGridViewTextBoxColumn6.MinimumWidth = 150;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Modificar
            // 
            Modificar.FlatStyle = FlatStyle.Popup;
            Modificar.HeaderText = "";
            Modificar.MinimumWidth = 40;
            Modificar.Name = "Modificar";
            Modificar.ReadOnly = true;
            Modificar.Resizable = DataGridViewTriState.False;
            Modificar.Width = 40;
            // 
            // groupBoxRegistro
            // 
            groupBoxRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxRegistro.Controls.Add(btnRegistrar);
            groupBoxRegistro.Controls.Add(TituloRegistro2);
            groupBoxRegistro.Controls.Add(TituloRegistro1);
            groupBoxRegistro.Location = new Point(56, 383);
            groupBoxRegistro.Margin = new Padding(3, 2, 3, 2);
            groupBoxRegistro.Name = "groupBoxRegistro";
            groupBoxRegistro.Padding = new Padding(3, 2, 3, 2);
            groupBoxRegistro.Size = new Size(915, 125);
            groupBoxRegistro.TabIndex = 7;
            groupBoxRegistro.TabStop = false;
            groupBoxRegistro.Visible = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Bottom;
            btnRegistrar.BackColor = SystemColors.GradientActiveCaption;
            btnRegistrar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnRegistrar.Location = new Point(382, 83);
            btnRegistrar.Margin = new Padding(3, 2, 3, 2);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(130, 38);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Visible = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // TituloRegistro2
            // 
            TituloRegistro2.Anchor = AnchorStyles.Top;
            TituloRegistro2.AutoSize = true;
            TituloRegistro2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            TituloRegistro2.Location = new Point(349, 42);
            TituloRegistro2.Name = "TituloRegistro2";
            TituloRegistro2.Size = new Size(195, 25);
            TituloRegistro2.TabIndex = 1;
            TituloRegistro2.Text = "Desea Registrarla?";
            TituloRegistro2.Visible = false;
            // 
            // TituloRegistro1
            // 
            TituloRegistro1.Anchor = AnchorStyles.Top;
            TituloRegistro1.AutoSize = true;
            TituloRegistro1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            TituloRegistro1.Location = new Point(233, 8);
            TituloRegistro1.Name = "TituloRegistro1";
            TituloRegistro1.Size = new Size(418, 25);
            TituloRegistro1.TabIndex = 0;
            TituloRegistro1.Text = "La Persona con el Dni ingresado no existe";
            TituloRegistro1.Visible = false;
            // 
            // groupBoxBotones
            // 
            groupBoxBotones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxBotones.Controls.Add(btnConsultar);
            groupBoxBotones.Controls.Add(btnSalir);
            groupBoxBotones.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            groupBoxBotones.Location = new Point(0, 608);
            groupBoxBotones.Margin = new Padding(3, 2, 3, 2);
            groupBoxBotones.Name = "groupBoxBotones";
            groupBoxBotones.Padding = new Padding(3, 2, 3, 2);
            groupBoxBotones.Size = new Size(1060, 68);
            groupBoxBotones.TabIndex = 8;
            groupBoxBotones.TabStop = false;
            // 
            // btnConsultar
            // 
            btnConsultar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConsultar.BackColor = SystemColors.GradientActiveCaption;
            btnConsultar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnConsultar.Location = new Point(39, 20);
            btnConsultar.Margin = new Padding(3, 2, 3, 2);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(207, 30);
            btnConsultar.TabIndex = 9;
            btnConsultar.Text = "Detalles de Cliente";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnSalir.Location = new Point(813, 20);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(207, 30);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // groupBoxHeader
            // 
            groupBoxHeader.Controls.Add(Titulo);
            groupBoxHeader.Dock = DockStyle.Top;
            groupBoxHeader.Location = new Point(0, 0);
            groupBoxHeader.Name = "groupBoxHeader";
            groupBoxHeader.Padding = new Padding(3, 2, 3, 2);
            groupBoxHeader.Size = new Size(1060, 50);
            groupBoxHeader.TabIndex = 9;
            groupBoxHeader.TabStop = false;
            // 
            // Titulo
            // 
            Titulo.AutoSize = true;
            Titulo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            Titulo.Location = new Point(46, 29);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(197, 20);
            Titulo.TabIndex = 2;
            Titulo.Text = "Administración Clientes";
            Titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkPrimerPagina
            // 
            linkPrimerPagina.AutoSize = true;
            linkPrimerPagina.Location = new Point(3, 0);
            linkPrimerPagina.Name = "linkPrimerPagina";
            linkPrimerPagina.Size = new Size(23, 15);
            linkPrimerPagina.TabIndex = 11;
            linkPrimerPagina.TabStop = true;
            linkPrimerPagina.Text = "<<";
            linkPrimerPagina.LinkClicked += primerLinkPagina;
            // 
            // linkPagAnterior
            // 
            linkPagAnterior.AutoSize = true;
            linkPagAnterior.Location = new Point(32, 0);
            linkPagAnterior.Name = "linkPagAnterior";
            linkPagAnterior.Size = new Size(15, 15);
            linkPagAnterior.TabIndex = 12;
            linkPagAnterior.TabStop = true;
            linkPagAnterior.Text = "<";
            linkPagAnterior.LinkClicked += paginaAnterior;
            // 
            // linkPagina1
            // 
            linkPagina1.AutoSize = true;
            linkPagina1.Location = new Point(53, 0);
            linkPagina1.Name = "linkPagina1";
            linkPagina1.Size = new Size(15, 15);
            linkPagina1.TabIndex = 13;
            linkPagina1.TabStop = true;
            linkPagina1.Text = "1";
            linkPagina1.LinkClicked += clickPaginas;
            // 
            // linkPagina2
            // 
            linkPagina2.AutoSize = true;
            linkPagina2.Location = new Point(74, 0);
            linkPagina2.Name = "linkPagina2";
            linkPagina2.Size = new Size(15, 15);
            linkPagina2.TabIndex = 14;
            linkPagina2.TabStop = true;
            linkPagina2.Text = "2";
            linkPagina2.LinkClicked += clickPaginas;
            // 
            // linkPagina3
            // 
            linkPagina3.AutoSize = true;
            linkPagina3.Location = new Point(95, 0);
            linkPagina3.Name = "linkPagina3";
            linkPagina3.Size = new Size(15, 15);
            linkPagina3.TabIndex = 15;
            linkPagina3.TabStop = true;
            linkPagina3.Text = "3";
            linkPagina3.LinkClicked += clickPaginas;
            // 
            // linkPagina4
            // 
            linkPagina4.AutoSize = true;
            linkPagina4.Location = new Point(116, 0);
            linkPagina4.Name = "linkPagina4";
            linkPagina4.Size = new Size(15, 15);
            linkPagina4.TabIndex = 16;
            linkPagina4.TabStop = true;
            linkPagina4.Text = "4";
            linkPagina4.LinkClicked += clickPaginas;
            // 
            // flowLayoutPanelLinks
            // 
            flowLayoutPanelLinks.Controls.Add(linkPrimerPagina);
            flowLayoutPanelLinks.Controls.Add(linkPagAnterior);
            flowLayoutPanelLinks.Controls.Add(linkPagina1);
            flowLayoutPanelLinks.Controls.Add(linkPagina2);
            flowLayoutPanelLinks.Controls.Add(linkPagina3);
            flowLayoutPanelLinks.Controls.Add(linkPagina4);
            flowLayoutPanelLinks.Controls.Add(linkPagina5);
            flowLayoutPanelLinks.Controls.Add(linkPaginaSiguiente);
            flowLayoutPanelLinks.Controls.Add(linkUltimaPagina);
            flowLayoutPanelLinks.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            flowLayoutPanelLinks.Location = new Point(39, 576);
            flowLayoutPanelLinks.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelLinks.Name = "flowLayoutPanelLinks";
            flowLayoutPanelLinks.Size = new Size(207, 24);
            flowLayoutPanelLinks.TabIndex = 34;
            // 
            // linkPagina5
            // 
            linkPagina5.AutoSize = true;
            linkPagina5.Location = new Point(137, 0);
            linkPagina5.Name = "linkPagina5";
            linkPagina5.Size = new Size(15, 15);
            linkPagina5.TabIndex = 17;
            linkPagina5.TabStop = true;
            linkPagina5.Text = "5";
            linkPagina5.LinkClicked += clickPaginas;
            // 
            // linkPaginaSiguiente
            // 
            linkPaginaSiguiente.AutoSize = true;
            linkPaginaSiguiente.Location = new Point(158, 0);
            linkPaginaSiguiente.Name = "linkPaginaSiguiente";
            linkPaginaSiguiente.Size = new Size(15, 15);
            linkPaginaSiguiente.TabIndex = 18;
            linkPaginaSiguiente.TabStop = true;
            linkPaginaSiguiente.Text = ">";
            linkPaginaSiguiente.LinkClicked += paginaSiguiente;
            // 
            // linkUltimaPagina
            // 
            linkUltimaPagina.AutoSize = true;
            linkUltimaPagina.Location = new Point(179, 0);
            linkUltimaPagina.Name = "linkUltimaPagina";
            linkUltimaPagina.Size = new Size(23, 15);
            linkUltimaPagina.TabIndex = 19;
            linkUltimaPagina.TabStop = true;
            linkUltimaPagina.Text = ">>";
            linkUltimaPagina.LinkClicked += linkUltima;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(885, 577);
            label1.Name = "label1";
            label1.Size = new Size(56, 16);
            label1.TabIndex = 35;
            label1.Text = "Página";
            // 
            // txtPag
            // 
            txtPag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPag.AutoSize = true;
            txtPag.BackColor = Color.Transparent;
            txtPag.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            txtPag.ForeColor = Color.Black;
            txtPag.Location = new Point(975, 577);
            txtPag.Name = "txtPag";
            txtPag.Size = new Size(15, 16);
            txtPag.TabIndex = 36;
            txtPag.Text = "1";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
            btnEliminar.Location = new Point(980, 279);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(34, 29);
            btnEliminar.TabIndex = 37;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnListadoXls
            // 
            btnListadoXls.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnListadoXls.BackColor = Color.Transparent;
            btnListadoXls.Image = (Image)resources.GetObject("btnListadoXls.Image");
            btnListadoXls.Location = new Point(810, 568);
            btnListadoXls.Margin = new Padding(3, 2, 3, 2);
            btnListadoXls.Name = "btnListadoXls";
            btnListadoXls.Size = new Size(34, 29);
            btnListadoXls.TabIndex = 38;
            btnListadoXls.UseVisualStyleBackColor = false;
            btnListadoXls.Click += btnListadoXls_Click;
            // 
            // FrmAdminClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1060, 675);
            Controls.Add(btnListadoXls);
            Controls.Add(comboFilas);
            Controls.Add(txtPag);
            Controls.Add(btnEliminar);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanelLinks);
            Controls.Add(groupBoxHeader);
            Controls.Add(groupBoxBotones);
            Controls.Add(groupBoxRegistro);
            Controls.Add(dataGridPersonas);
            Controls.Add(groupBoxPersona);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FrmAdminClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ABMC Clientes";
            Load += FrmAdminClientes_Load;
            Shown += FrmAdminClientes_Shown;
            groupBoxPersona.ResumeLayout(false);
            groupBoxPersona.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceCiudades).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcePersonas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPersonas).EndInit();
            groupBoxRegistro.ResumeLayout(false);
            groupBoxRegistro.PerformLayout();
            groupBoxBotones.ResumeLayout(false);
            groupBoxHeader.ResumeLayout(false);
            groupBoxHeader.PerformLayout();
            flowLayoutPanelLinks.ResumeLayout(false);
            flowLayoutPanelLinks.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxPersona;
        private Label label3;
        private TextBox txtDni;
        private TextBox txtNombre;
        private Label label6;
        private Label label21;
        private ComboBox comboCiudad;
        private Button btnBuscar;
        private BindingSource bindingSourcePersonas;
        private DataGridView dataGridPersonas;
        private GroupBox groupBoxRegistro;
        private Label TituloRegistro1;
        private Button btnRegistrar;
        private Label TituloRegistro2;
        private GroupBox groupBoxBotones;
        private Button btnConsultar;
        private GroupBox groupBoxHeader;
        private Label Titulo;
        private Button btnSalir;
        private BindingSource bindingSourceCiudades;
        private CheckBox checkAnulados;
        private ComboBox comboFilas;
        private LinkLabel linkPrimerPagina;
        private LinkLabel linkPagAnterior;
        private LinkLabel linkPagina1;
        private LinkLabel linkPagina2;
        private LinkLabel linkPagina3;
        private LinkLabel linkPagina4;
        private FlowLayoutPanel flowLayoutPanelLinks;
        private LinkLabel linkPagina5;
        private LinkLabel linkPaginaSiguiente;
        private Label label1;
        private Label txtPag;
        private LinkLabel linkUltimaPagina;
        private DataGridViewTextBoxColumn dniDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apellidosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cuilDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaNacimientoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn detalleFiscalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private Button btnEliminar;
        private CheckBox checkObservaciones;
        private Button btnListadoXls;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn EstadoPersona;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewButtonColumn Modificar;
    }
}