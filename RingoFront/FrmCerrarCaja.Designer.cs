namespace RingoFront
{
    partial class FrmCerrarCaja
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
            labelCierreCajas = new Label();
            label3 = new Label();
            txtDeclarado = new TextBox();
            btnDeclarar = new Button();
            label21 = new Label();
            comboMediosPagos = new ComboBox();
            bindingMediosPagos = new BindingSource(components);
            label1 = new Label();
            txtFondoCajas = new TextBox();
            labelDiferencia = new Label();
            txtDiferencia = new TextBox();
            dataGridPersonas = new DataGridView();
            horaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            vendedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            medioDePagoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tarjetaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bancoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalFacturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cajasConsultaBindingSource = new BindingSource(components);
            btnImprimir = new Button();
            txtTotal = new TextBox();
            label4 = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingMediosPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPersonas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cajasConsultaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // labelCierreCajas
            // 
            labelCierreCajas.AutoSize = true;
            labelCierreCajas.BackColor = Color.Transparent;
            labelCierreCajas.Font = new Font("Rockwell", 12F, FontStyle.Bold);
            labelCierreCajas.Location = new Point(27, 39);
            labelCierreCajas.Name = "labelCierreCajas";
            labelCierreCajas.Size = new Size(164, 24);
            labelCierreCajas.TabIndex = 1;
            labelCierreCajas.Text = "Cierre de Cajas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(27, 88);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 9;
            label3.Text = "Efectivo Real";
            // 
            // txtDeclarado
            // 
            txtDeclarado.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            txtDeclarado.Location = new Point(27, 112);
            txtDeclarado.Margin = new Padding(3, 4, 3, 4);
            txtDeclarado.MaxLength = 10;
            txtDeclarado.Name = "txtDeclarado";
            txtDeclarado.Size = new Size(137, 28);
            txtDeclarado.TabIndex = 8;
            txtDeclarado.TextAlign = HorizontalAlignment.Center;
            txtDeclarado.KeyPress += textBoxNumeros_KeyPress;
            // 
            // btnDeclarar
            // 
            btnDeclarar.BackColor = SystemColors.GradientActiveCaption;
            btnDeclarar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnDeclarar.Location = new Point(216, 110);
            btnDeclarar.Name = "btnDeclarar";
            btnDeclarar.Size = new Size(168, 32);
            btnDeclarar.TabIndex = 10;
            btnDeclarar.Text = "Declarar";
            btnDeclarar.UseVisualStyleBackColor = false;
            btnDeclarar.Click += btnDeclarar_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Location = new Point(27, 171);
            label21.Name = "label21";
            label21.Size = new Size(110, 20);
            label21.TabIndex = 26;
            label21.Text = "Medio de Pago";
            // 
            // comboMediosPagos
            // 
            comboMediosPagos.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboMediosPagos.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboMediosPagos.DataSource = bindingMediosPagos;
            comboMediosPagos.DisplayMember = "FormaPago";
            comboMediosPagos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMediosPagos.Enabled = false;
            comboMediosPagos.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            comboMediosPagos.FormattingEnabled = true;
            comboMediosPagos.Location = new Point(27, 201);
            comboMediosPagos.Name = "comboMediosPagos";
            comboMediosPagos.Size = new Size(246, 30);
            comboMediosPagos.TabIndex = 25;
            comboMediosPagos.ValueMember = "IdMedioPago";
            comboMediosPagos.SelectedIndexChanged += comboMediosPagos_SelectedIndexChanged;
            // 
            // bindingMediosPagos
            // 
            bindingMediosPagos.DataSource = typeof(RingoEntidades.MediosPagos);
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(443, 171);
            label1.Name = "label1";
            label1.Size = new Size(159, 20);
            label1.TabIndex = 28;
            label1.Text = "Efectivo Contabilizado";
            // 
            // txtFondoCajas
            // 
            txtFondoCajas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFondoCajas.Enabled = false;
            txtFondoCajas.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            txtFondoCajas.Location = new Point(462, 201);
            txtFondoCajas.Margin = new Padding(3, 4, 3, 4);
            txtFondoCajas.MaxLength = 10;
            txtFondoCajas.Name = "txtFondoCajas";
            txtFondoCajas.Size = new Size(232, 28);
            txtFondoCajas.TabIndex = 27;
            txtFondoCajas.TextAlign = HorizontalAlignment.Center;
            // 
            // labelDiferencia
            // 
            labelDiferencia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDiferencia.AutoSize = true;
            labelDiferencia.BackColor = Color.Transparent;
            labelDiferencia.Location = new Point(791, 171);
            labelDiferencia.Name = "labelDiferencia";
            labelDiferencia.Size = new Size(77, 20);
            labelDiferencia.TabIndex = 30;
            labelDiferencia.Text = "Diferencia";
            // 
            // txtDiferencia
            // 
            txtDiferencia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDiferencia.Enabled = false;
            txtDiferencia.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            txtDiferencia.Location = new Point(766, 201);
            txtDiferencia.Margin = new Padding(3, 4, 3, 4);
            txtDiferencia.MaxLength = 10;
            txtDiferencia.Name = "txtDiferencia";
            txtDiferencia.Size = new Size(233, 28);
            txtDiferencia.TabIndex = 29;
            txtDiferencia.TextAlign = HorizontalAlignment.Center;
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
            dataGridPersonas.Columns.AddRange(new DataGridViewColumn[] { horaDataGridViewTextBoxColumn, vendedorDataGridViewTextBoxColumn, medioDePagoDataGridViewTextBoxColumn, tarjetaDataGridViewTextBoxColumn, bancoDataGridViewTextBoxColumn, totalFacturaDataGridViewTextBoxColumn });
            dataGridPersonas.DataSource = cajasConsultaBindingSource;
            dataGridPersonas.Location = new Point(27, 257);
            dataGridPersonas.Name = "dataGridPersonas";
            dataGridPersonas.ReadOnly = true;
            dataGridPersonas.RowHeadersVisible = false;
            dataGridPersonas.RowHeadersWidth = 51;
            dataGridPersonas.Size = new Size(973, 331);
            dataGridPersonas.TabIndex = 31;
            // 
            // horaDataGridViewTextBoxColumn
            // 
            horaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            horaDataGridViewTextBoxColumn.DataPropertyName = "Hora";
            horaDataGridViewTextBoxColumn.FillWeight = 10F;
            horaDataGridViewTextBoxColumn.HeaderText = "Hora";
            horaDataGridViewTextBoxColumn.MinimumWidth = 80;
            horaDataGridViewTextBoxColumn.Name = "horaDataGridViewTextBoxColumn";
            horaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendedorDataGridViewTextBoxColumn
            // 
            vendedorDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            vendedorDataGridViewTextBoxColumn.DataPropertyName = "Vendedor";
            vendedorDataGridViewTextBoxColumn.FillWeight = 20F;
            vendedorDataGridViewTextBoxColumn.HeaderText = "Vendedor";
            vendedorDataGridViewTextBoxColumn.MinimumWidth = 150;
            vendedorDataGridViewTextBoxColumn.Name = "vendedorDataGridViewTextBoxColumn";
            vendedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // medioDePagoDataGridViewTextBoxColumn
            // 
            medioDePagoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            medioDePagoDataGridViewTextBoxColumn.DataPropertyName = "MedioDePago";
            medioDePagoDataGridViewTextBoxColumn.FillWeight = 20F;
            medioDePagoDataGridViewTextBoxColumn.HeaderText = "Medio De Pago";
            medioDePagoDataGridViewTextBoxColumn.MinimumWidth = 180;
            medioDePagoDataGridViewTextBoxColumn.Name = "medioDePagoDataGridViewTextBoxColumn";
            medioDePagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tarjetaDataGridViewTextBoxColumn
            // 
            tarjetaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tarjetaDataGridViewTextBoxColumn.DataPropertyName = "Tarjeta";
            tarjetaDataGridViewTextBoxColumn.FillWeight = 15F;
            tarjetaDataGridViewTextBoxColumn.HeaderText = "Tarjeta";
            tarjetaDataGridViewTextBoxColumn.MinimumWidth = 120;
            tarjetaDataGridViewTextBoxColumn.Name = "tarjetaDataGridViewTextBoxColumn";
            tarjetaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bancoDataGridViewTextBoxColumn
            // 
            bancoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bancoDataGridViewTextBoxColumn.DataPropertyName = "Banco";
            bancoDataGridViewTextBoxColumn.FillWeight = 20F;
            bancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            bancoDataGridViewTextBoxColumn.MinimumWidth = 180;
            bancoDataGridViewTextBoxColumn.Name = "bancoDataGridViewTextBoxColumn";
            bancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalFacturaDataGridViewTextBoxColumn
            // 
            totalFacturaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            totalFacturaDataGridViewTextBoxColumn.DataPropertyName = "TotalFactura";
            totalFacturaDataGridViewTextBoxColumn.FillWeight = 15F;
            totalFacturaDataGridViewTextBoxColumn.HeaderText = "Monto en $";
            totalFacturaDataGridViewTextBoxColumn.MinimumWidth = 100;
            totalFacturaDataGridViewTextBoxColumn.Name = "totalFacturaDataGridViewTextBoxColumn";
            totalFacturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cajasConsultaBindingSource
            // 
            cajasConsultaBindingSource.DataSource = typeof(CajasConsulta);
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(27, 673);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(289, 29);
            btnImprimir.TabIndex = 36;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Segoe UI", 14F);
            txtTotal.Location = new Point(801, 607);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(198, 39);
            txtTotal.TabIndex = 35;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(696, 619);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 34;
            label4.Text = "TOTAL";
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(711, 673);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(289, 29);
            btnSalir.TabIndex = 33;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmCerrarCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 747);
            Controls.Add(btnImprimir);
            Controls.Add(txtTotal);
            Controls.Add(label4);
            Controls.Add(btnSalir);
            Controls.Add(dataGridPersonas);
            Controls.Add(labelDiferencia);
            Controls.Add(txtDiferencia);
            Controls.Add(label1);
            Controls.Add(txtFondoCajas);
            Controls.Add(label21);
            Controls.Add(comboMediosPagos);
            Controls.Add(btnDeclarar);
            Controls.Add(label3);
            Controls.Add(txtDeclarado);
            Controls.Add(labelCierreCajas);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCerrarCaja";
            Text = "Cerrar Caja";
            Load += FrmCerrarCaja_Load;
            Shown += Frm_Shown;
            ((System.ComponentModel.ISupportInitialize)bindingMediosPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPersonas).EndInit();
            ((System.ComponentModel.ISupportInitialize)cajasConsultaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCierreCajas;
        private Label label3;
        private TextBox txtDeclarado;
        private Button btnDeclarar;
        private Label label21;
        private ComboBox comboMediosPagos;
        private Label label1;
        private TextBox txtFondoCajas;
        private Label labelDiferencia;
        private TextBox txtDiferencia;
        private DataGridView dataGridPersonas;
        private Button btnImprimir;
        private TextBox txtTotal;
        private Label label4;
        private Button btnSalir;
        private BindingSource cajasConsultaBindingSource;
        private BindingSource bindingMediosPagos;
        private DataGridViewTextBoxColumn horaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn vendedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn medioDePagoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tarjetaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bancoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalFacturaDataGridViewTextBoxColumn;
    }
}