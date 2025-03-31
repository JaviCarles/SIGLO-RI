namespace RingoFront
{
    partial class FrmAdminProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminProveedores));
            btnBuscar = new Button();
            txtRazonSocial = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            dataGridProveedores = new DataGridView();
            cuitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            razonSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            direccionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            localidadProvinciaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            condicionFiscalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingProveedoresCons = new BindingSource(components);
            label2 = new Label();
            btnEditar = new Button();
            btnSalir = new Button();
            txtPrenda = new TextBox();
            bindingContactos = new BindingSource(components);
            label3 = new Label();
            txtDetalles = new TextBox();
            dataGridContactos = new DataGridView();
            tipoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codAreaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreRedSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioRedSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingProveedoresCons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingContactos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridContactos).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscar.Location = new Point(667, 109);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(45, 35);
            btnBuscar.TabIndex = 53;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Font = new Font("Segoe UI", 12F);
            txtRazonSocial.ForeColor = SystemColors.WindowText;
            txtRazonSocial.Location = new Point(42, 109);
            txtRazonSocial.Margin = new Padding(5, 3, 5, 3);
            txtRazonSocial.MaxLength = 99;
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.PlaceholderText = "Ingrese Razón Social o CUIT";
            txtRazonSocial.Size = new Size(594, 34);
            txtRazonSocial.TabIndex = 52;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1400, 85);
            groupBox1.TabIndex = 54;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 32);
            label1.Name = "label1";
            label1.Size = new Size(181, 20);
            label1.TabIndex = 0;
            label1.Text = "Administración Proveedor";
            // 
            // dataGridProveedores
            // 
            dataGridProveedores.AllowUserToAddRows = false;
            dataGridProveedores.AllowUserToDeleteRows = false;
            dataGridProveedores.AllowUserToOrderColumns = true;
            dataGridProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProveedores.AutoGenerateColumns = false;
            dataGridProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProveedores.BackgroundColor = Color.White;
            dataGridProveedores.ColumnHeadersHeight = 29;
            dataGridProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridProveedores.Columns.AddRange(new DataGridViewColumn[] { cuitDataGridViewTextBoxColumn, razonSocialDataGridViewTextBoxColumn, direccionDataGridViewTextBoxColumn, localidadProvinciaDataGridViewTextBoxColumn, condicionFiscalDataGridViewTextBoxColumn, estadoDataGridViewTextBoxColumn });
            dataGridProveedores.DataSource = bindingProveedoresCons;
            dataGridProveedores.Location = new Point(42, 164);
            dataGridProveedores.Name = "dataGridProveedores";
            dataGridProveedores.ReadOnly = true;
            dataGridProveedores.RowHeadersVisible = false;
            dataGridProveedores.RowHeadersWidth = 51;
            dataGridProveedores.Size = new Size(1317, 283);
            dataGridProveedores.TabIndex = 55;
            // 
            // cuitDataGridViewTextBoxColumn
            // 
            cuitDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cuitDataGridViewTextBoxColumn.DataPropertyName = "cuit";
            cuitDataGridViewTextBoxColumn.FillWeight = 15F;
            cuitDataGridViewTextBoxColumn.HeaderText = "CUIT";
            cuitDataGridViewTextBoxColumn.MinimumWidth = 100;
            cuitDataGridViewTextBoxColumn.Name = "cuitDataGridViewTextBoxColumn";
            cuitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            razonSocialDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            razonSocialDataGridViewTextBoxColumn.DataPropertyName = "razonSocial";
            razonSocialDataGridViewTextBoxColumn.FillWeight = 20F;
            razonSocialDataGridViewTextBoxColumn.HeaderText = "Razón Social";
            razonSocialDataGridViewTextBoxColumn.MinimumWidth = 150;
            razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            direccionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            direccionDataGridViewTextBoxColumn.DataPropertyName = "direccion";
            direccionDataGridViewTextBoxColumn.FillWeight = 20F;
            direccionDataGridViewTextBoxColumn.HeaderText = "Dirección";
            direccionDataGridViewTextBoxColumn.MinimumWidth = 150;
            direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localidadProvinciaDataGridViewTextBoxColumn
            // 
            localidadProvinciaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            localidadProvinciaDataGridViewTextBoxColumn.DataPropertyName = "localidadProvincia";
            localidadProvinciaDataGridViewTextBoxColumn.FillWeight = 20F;
            localidadProvinciaDataGridViewTextBoxColumn.HeaderText = "Localidad-Provincia";
            localidadProvinciaDataGridViewTextBoxColumn.MinimumWidth = 150;
            localidadProvinciaDataGridViewTextBoxColumn.Name = "localidadProvinciaDataGridViewTextBoxColumn";
            localidadProvinciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // condicionFiscalDataGridViewTextBoxColumn
            // 
            condicionFiscalDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            condicionFiscalDataGridViewTextBoxColumn.DataPropertyName = "condicionFiscal";
            condicionFiscalDataGridViewTextBoxColumn.FillWeight = 15F;
            condicionFiscalDataGridViewTextBoxColumn.HeaderText = "Cond. Fiscal";
            condicionFiscalDataGridViewTextBoxColumn.MinimumWidth = 120;
            condicionFiscalDataGridViewTextBoxColumn.Name = "condicionFiscalDataGridViewTextBoxColumn";
            condicionFiscalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            estadoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            estadoDataGridViewTextBoxColumn.FillWeight = 10F;
            estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoDataGridViewTextBoxColumn.MinimumWidth = 100;
            estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingProveedoresCons
            // 
            bindingProveedoresCons.DataSource = typeof(ProveedorConsulta);
            bindingProveedoresCons.CurrentItemChanged += bindingProveedoresCons_CurrentItemChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(42, 545);
            label2.Name = "label2";
            label2.Size = new Size(210, 20);
            label2.TabIndex = 56;
            label2.Text = "CONTACTOS DEL PROVEEDOR";
            // 
            // btnEditar
            // 
            btnEditar.BackColor = SystemColors.ButtonHighlight;
            btnEditar.BackgroundImage = (Image)resources.GetObject("btnEditar.BackgroundImage");
            btnEditar.BackgroundImageLayout = ImageLayout.Stretch;
            btnEditar.Location = new Point(737, 109);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(40, 36);
            btnEditar.TabIndex = 58;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSalir.Location = new Point(640, 781);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(125, 29);
            btnSalir.TabIndex = 59;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // txtPrenda
            // 
            txtPrenda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrenda.Font = new Font("Segoe UI", 12F);
            txtPrenda.ForeColor = SystemColors.WindowText;
            txtPrenda.Location = new Point(809, 109);
            txtPrenda.Margin = new Padding(5, 3, 5, 3);
            txtPrenda.MaxLength = 99;
            txtPrenda.Name = "txtPrenda";
            txtPrenda.PlaceholderText = "Ingrese Descripción de prenda que provee";
            txtPrenda.Size = new Size(549, 34);
            txtPrenda.TabIndex = 61;
            // 
            // bindingContactos
            // 
            bindingContactos.DataSource = typeof(RingoEntidades.Contactos);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(42, 464);
            label3.Name = "label3";
            label3.Size = new Size(193, 20);
            label3.TabIndex = 63;
            label3.Text = "DETALLES DEL PROVEEDOR";
            // 
            // txtDetalles
            // 
            txtDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDetalles.Enabled = false;
            txtDetalles.Font = new Font("Segoe UI", 12F);
            txtDetalles.ForeColor = SystemColors.WindowText;
            txtDetalles.Location = new Point(42, 487);
            txtDetalles.Margin = new Padding(5, 3, 5, 3);
            txtDetalles.MaxLength = 99;
            txtDetalles.Name = "txtDetalles";
            txtDetalles.Size = new Size(1316, 34);
            txtDetalles.TabIndex = 64;
            // 
            // dataGridContactos
            // 
            dataGridContactos.AllowUserToAddRows = false;
            dataGridContactos.AllowUserToDeleteRows = false;
            dataGridContactos.AllowUserToOrderColumns = true;
            dataGridContactos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridContactos.AutoGenerateColumns = false;
            dataGridContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridContactos.BackgroundColor = Color.White;
            dataGridContactos.ColumnHeadersHeight = 29;
            dataGridContactos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridContactos.Columns.AddRange(new DataGridViewColumn[] { tipoDataGridViewTextBoxColumn, codAreaDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, nombreRedSocialDataGridViewTextBoxColumn, usuarioRedSocialDataGridViewTextBoxColumn });
            dataGridContactos.DataSource = bindingContactos;
            dataGridContactos.Location = new Point(42, 575);
            dataGridContactos.Name = "dataGridContactos";
            dataGridContactos.ReadOnly = true;
            dataGridContactos.RowHeadersVisible = false;
            dataGridContactos.RowHeadersWidth = 51;
            dataGridContactos.Size = new Size(1317, 172);
            dataGridContactos.TabIndex = 65;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            tipoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            tipoDataGridViewTextBoxColumn.FillWeight = 7F;
            tipoDataGridViewTextBoxColumn.HeaderText = "Tipo Tel.";
            tipoDataGridViewTextBoxColumn.MinimumWidth = 80;
            tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codAreaDataGridViewTextBoxColumn
            // 
            codAreaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            codAreaDataGridViewTextBoxColumn.DataPropertyName = "codArea";
            codAreaDataGridViewTextBoxColumn.FillWeight = 7F;
            codAreaDataGridViewTextBoxColumn.HeaderText = "Cod. Area";
            codAreaDataGridViewTextBoxColumn.MinimumWidth = 80;
            codAreaDataGridViewTextBoxColumn.Name = "codAreaDataGridViewTextBoxColumn";
            codAreaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            telefonoDataGridViewTextBoxColumn.FillWeight = 15F;
            telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            telefonoDataGridViewTextBoxColumn.MinimumWidth = 100;
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.FillWeight = 25F;
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 150;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreRedSocialDataGridViewTextBoxColumn
            // 
            nombreRedSocialDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nombreRedSocialDataGridViewTextBoxColumn.DataPropertyName = "NombreRedSocial";
            nombreRedSocialDataGridViewTextBoxColumn.FillWeight = 20F;
            nombreRedSocialDataGridViewTextBoxColumn.HeaderText = "Red Social";
            nombreRedSocialDataGridViewTextBoxColumn.MinimumWidth = 130;
            nombreRedSocialDataGridViewTextBoxColumn.Name = "nombreRedSocialDataGridViewTextBoxColumn";
            nombreRedSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRedSocialDataGridViewTextBoxColumn
            // 
            usuarioRedSocialDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            usuarioRedSocialDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRedSocial";
            usuarioRedSocialDataGridViewTextBoxColumn.FillWeight = 25F;
            usuarioRedSocialDataGridViewTextBoxColumn.HeaderText = "Usuario Red Social";
            usuarioRedSocialDataGridViewTextBoxColumn.MinimumWidth = 150;
            usuarioRedSocialDataGridViewTextBoxColumn.Name = "usuarioRedSocialDataGridViewTextBoxColumn";
            usuarioRedSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmAdminProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1400, 831);
            Controls.Add(dataGridContactos);
            Controls.Add(txtDetalles);
            Controls.Add(label3);
            Controls.Add(txtPrenda);
            Controls.Add(btnSalir);
            Controls.Add(btnEditar);
            Controls.Add(label2);
            Controls.Add(dataGridProveedores);
            Controls.Add(groupBox1);
            Controls.Add(btnBuscar);
            Controls.Add(txtRazonSocial);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAdminProveedores";
            Text = "AdminProveedores";
            Load += AdminProveedores_Load;
            Shown += Frm_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingProveedoresCons).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingContactos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridContactos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private TextBox txtRazonSocial;
        private GroupBox groupBox1;
        private Label label1;
        private DataGridView dataGridProveedores;
        private Label label2;
        private Button btnEditar;
        private Button btnSalir;
        private TextBox txtPrenda;
        private BindingSource bindingProveedoresCons;
        private BindingSource bindingContactos;
        private Label label3;
        private TextBox txtDetalles;
        private DataGridView dataGridContactos;
        private DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codAreaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreRedSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioRedSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cuitDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn localidadProvinciaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn condicionFiscalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
    }
}