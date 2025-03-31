namespace RingoFront
{
    partial class FormContactosProveedores
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
            lblContactosProveed = new Label();
            checkFijo = new CheckBox();
            txtUserRedSocial = new TextBox();
            labelURS = new Label();
            txtCorreo = new TextBox();
            labelCorreo = new Label();
            labelQuince = new Label();
            labelCero = new Label();
            txtNroTelefono = new TextBox();
            labelTel = new Label();
            txtAreaTelefono = new TextBox();
            comboRedesSociales = new ComboBox();
            bindingSourceRedes = new BindingSource(components);
            labelRS = new Label();
            groupBoxContacto = new GroupBox();
            groupBoxTitulo = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            btnQuitarDetalle = new Button();
            btnAgregarDetalleNuevo = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSourceRedes).BeginInit();
            groupBoxContacto.SuspendLayout();
            groupBoxTitulo.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblContactosProveed
            // 
            lblContactosProveed.AutoSize = true;
            lblContactosProveed.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblContactosProveed.Location = new Point(57, 44);
            lblContactosProveed.Name = "lblContactosProveed";
            lblContactosProveed.Size = new Size(218, 25);
            lblContactosProveed.TabIndex = 0;
            lblContactosProveed.Text = "Contactos Proveedores";
            // 
            // checkFijo
            // 
            checkFijo.Anchor = AnchorStyles.Top;
            checkFijo.AutoSize = true;
            checkFijo.Location = new Point(93, 67);
            checkFijo.Margin = new Padding(3, 4, 3, 4);
            checkFijo.Name = "checkFijo";
            checkFijo.Size = new Size(117, 24);
            checkFijo.TabIndex = 28;
            checkFijo.Text = "Telefono Fijo";
            checkFijo.UseVisualStyleBackColor = true;
            checkFijo.CheckedChanged += checkFijo_CheckedChanged;
            // 
            // txtUserRedSocial
            // 
            txtUserRedSocial.Anchor = AnchorStyles.Top;
            txtUserRedSocial.Font = new Font("Segoe UI", 12F);
            txtUserRedSocial.Location = new Point(719, 170);
            txtUserRedSocial.Margin = new Padding(3, 4, 3, 4);
            txtUserRedSocial.MaxLength = 99;
            txtUserRedSocial.Name = "txtUserRedSocial";
            txtUserRedSocial.Size = new Size(329, 34);
            txtUserRedSocial.TabIndex = 27;
            // 
            // labelURS
            // 
            labelURS.Anchor = AnchorStyles.Top;
            labelURS.AutoSize = true;
            labelURS.Location = new Point(718, 133);
            labelURS.Name = "labelURS";
            labelURS.Size = new Size(133, 20);
            labelURS.TabIndex = 26;
            labelURS.Text = "Usuario Red Social";
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Top;
            txtCorreo.Font = new Font("Segoe UI", 12F);
            txtCorreo.Location = new Point(719, 63);
            txtCorreo.Margin = new Padding(3, 4, 3, 4);
            txtCorreo.MaxLength = 99;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(325, 34);
            txtCorreo.TabIndex = 25;
            txtCorreo.Validating += txtCorreo1_Validating;
            // 
            // labelCorreo
            // 
            labelCorreo.Anchor = AnchorStyles.Top;
            labelCorreo.AutoSize = true;
            labelCorreo.Location = new Point(719, 23);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(132, 20);
            labelCorreo.TabIndex = 24;
            labelCorreo.Text = "Correo Electrónico";
            // 
            // labelQuince
            // 
            labelQuince.Anchor = AnchorStyles.Top;
            labelQuince.AutoSize = true;
            labelQuince.Font = new Font("Microsoft Sans Serif", 9.75F);
            labelQuince.ForeColor = SystemColors.ButtonShadow;
            labelQuince.Location = new Point(442, 67);
            labelQuince.Name = "labelQuince";
            labelQuince.Size = new Size(27, 20);
            labelQuince.TabIndex = 19;
            labelQuince.Text = "15";
            // 
            // labelCero
            // 
            labelCero.Anchor = AnchorStyles.Top;
            labelCero.AutoSize = true;
            labelCero.Font = new Font("Microsoft Sans Serif", 9.75F);
            labelCero.ForeColor = SystemColors.ButtonShadow;
            labelCero.Location = new Point(258, 67);
            labelCero.Name = "labelCero";
            labelCero.Size = new Size(37, 20);
            labelCero.TabIndex = 18;
            labelCero.Text = "+54";
            // 
            // txtNroTelefono
            // 
            txtNroTelefono.Anchor = AnchorStyles.Top;
            txtNroTelefono.Font = new Font("Segoe UI", 12F);
            txtNroTelefono.Location = new Point(508, 64);
            txtNroTelefono.Margin = new Padding(3, 4, 3, 4);
            txtNroTelefono.MaxLength = 9;
            txtNroTelefono.Name = "txtNroTelefono";
            txtNroTelefono.Size = new Size(121, 34);
            txtNroTelefono.TabIndex = 23;
            txtNroTelefono.KeyPress += NumericTextBox_KeyPress;
            // 
            // labelTel
            // 
            labelTel.Anchor = AnchorStyles.Top;
            labelTel.AutoSize = true;
            labelTel.Location = new Point(418, 23);
            labelTel.Name = "labelTel";
            labelTel.Size = new Size(93, 20);
            labelTel.TabIndex = 22;
            labelTel.Text = "Teléfono nro";
            // 
            // txtAreaTelefono
            // 
            txtAreaTelefono.Anchor = AnchorStyles.Top;
            txtAreaTelefono.Font = new Font("Segoe UI", 12F);
            txtAreaTelefono.Location = new Point(337, 63);
            txtAreaTelefono.Margin = new Padding(3, 4, 3, 4);
            txtAreaTelefono.MaxLength = 5;
            txtAreaTelefono.Name = "txtAreaTelefono";
            txtAreaTelefono.Size = new Size(67, 34);
            txtAreaTelefono.TabIndex = 21;
            txtAreaTelefono.KeyPress += NumericTextBox_KeyPress;
            // 
            // comboRedesSociales
            // 
            comboRedesSociales.Anchor = AnchorStyles.Top;
            comboRedesSociales.DataSource = bindingSourceRedes;
            comboRedesSociales.DisplayMember = "NombreRedSocial";
            comboRedesSociales.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRedesSociales.Font = new Font("Segoe UI", 12F);
            comboRedesSociales.FormattingEnabled = true;
            comboRedesSociales.Location = new Point(355, 169);
            comboRedesSociales.Margin = new Padding(3, 4, 3, 4);
            comboRedesSociales.Name = "comboRedesSociales";
            comboRedesSociales.Size = new Size(237, 36);
            comboRedesSociales.TabIndex = 20;
            comboRedesSociales.ValueMember = "IdRedSocial";
            // 
            // bindingSourceRedes
            // 
            bindingSourceRedes.DataSource = typeof(RingoEntidades.RedesSociales);
            // 
            // labelRS
            // 
            labelRS.Anchor = AnchorStyles.Top;
            labelRS.AutoSize = true;
            labelRS.Location = new Point(354, 132);
            labelRS.Name = "labelRS";
            labelRS.Size = new Size(79, 20);
            labelRS.TabIndex = 17;
            labelRS.Text = "Red Social";
            // 
            // groupBoxContacto
            // 
            groupBoxContacto.Controls.Add(checkFijo);
            groupBoxContacto.Controls.Add(labelRS);
            groupBoxContacto.Controls.Add(comboRedesSociales);
            groupBoxContacto.Controls.Add(txtUserRedSocial);
            groupBoxContacto.Controls.Add(txtAreaTelefono);
            groupBoxContacto.Controls.Add(labelURS);
            groupBoxContacto.Controls.Add(labelTel);
            groupBoxContacto.Controls.Add(txtCorreo);
            groupBoxContacto.Controls.Add(txtNroTelefono);
            groupBoxContacto.Controls.Add(labelCorreo);
            groupBoxContacto.Controls.Add(labelCero);
            groupBoxContacto.Controls.Add(labelQuince);
            groupBoxContacto.Dock = DockStyle.Top;
            groupBoxContacto.Location = new Point(3, 3);
            groupBoxContacto.Name = "groupBoxContacto";
            groupBoxContacto.Size = new Size(1120, 232);
            groupBoxContacto.TabIndex = 30;
            groupBoxContacto.TabStop = false;
            groupBoxContacto.Text = "Contacto n°: 1";
            // 
            // groupBoxTitulo
            // 
            groupBoxTitulo.Controls.Add(lblContactosProveed);
            groupBoxTitulo.Dock = DockStyle.Top;
            groupBoxTitulo.Location = new Point(0, 0);
            groupBoxTitulo.Name = "groupBoxTitulo";
            groupBoxTitulo.Size = new Size(1123, 103);
            groupBoxTitulo.TabIndex = 31;
            groupBoxTitulo.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(groupBoxContacto);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 103);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1123, 700);
            flowLayoutPanel1.TabIndex = 32;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnQuitarDetalle);
            groupBox2.Controls.Add(btnAgregarDetalleNuevo);
            groupBox2.Controls.Add(btnCancelar);
            groupBox2.Controls.Add(btnGuardar);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.Location = new Point(0, 663);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1123, 140);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            // 
            // btnQuitarDetalle
            // 
            btnQuitarDetalle.BackColor = SystemColors.ActiveCaption;
            btnQuitarDetalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQuitarDetalle.Location = new Point(165, 49);
            btnQuitarDetalle.Name = "btnQuitarDetalle";
            btnQuitarDetalle.Size = new Size(59, 36);
            btnQuitarDetalle.TabIndex = 5;
            btnQuitarDetalle.Text = "-";
            btnQuitarDetalle.UseVisualStyleBackColor = false;
            btnQuitarDetalle.Click += btnQuitarDetalle_Click;
            // 
            // btnAgregarDetalleNuevo
            // 
            btnAgregarDetalleNuevo.BackColor = SystemColors.ActiveCaption;
            btnAgregarDetalleNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregarDetalleNuevo.Location = new Point(57, 48);
            btnAgregarDetalleNuevo.Name = "btnAgregarDetalleNuevo";
            btnAgregarDetalleNuevo.Size = new Size(59, 36);
            btnAgregarDetalleNuevo.TabIndex = 3;
            btnAgregarDetalleNuevo.Text = "+";
            btnAgregarDetalleNuevo.UseVisualStyleBackColor = false;
            btnAgregarDetalleNuevo.Click += btnAgregarDetalleNuevo_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancelar.Location = new Point(917, 48);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 43);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.Location = new Point(363, 48);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 43);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Añadir";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormContactosProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 803);
            Controls.Add(groupBox2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(groupBoxTitulo);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormContactosProveedores";
            Load += FormContactosProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSourceRedes).EndInit();
            groupBoxContacto.ResumeLayout(false);
            groupBoxContacto.PerformLayout();
            groupBoxTitulo.ResumeLayout(false);
            groupBoxTitulo.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblContactosProveed;
        private CheckBox checkFijo;
        private TextBox txtUserRedSocial;
        private Label labelURS;
        private TextBox txtCorreo;
        private Label labelCorreo;
        private Label labelQuince;
        private Label labelCero;
        private TextBox txtNroTelefono;
        private Label labelTel;
        private TextBox txtAreaTelefono;
        private ComboBox comboRedesSociales;
        private Label labelRS;
        private GroupBox groupBoxContacto;
        private GroupBox groupBoxTitulo;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox2;
        internal Button btnQuitarDetalle;
        internal Button btnAgregarDetalleNuevo;
        internal Button btnCancelar;
        internal Button btnGuardar;
        private BindingSource bindingSourceRedes;
    }
}