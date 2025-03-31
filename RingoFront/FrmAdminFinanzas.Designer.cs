namespace RingoFront
{
    partial class FrmAdminFinanzas
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
            lblConsFinanzas = new Label();
            groupBox1 = new GroupBox();
            dataGridMovimientos = new DataGridView();
            detallesLibrosDiariosBindingSource = new BindingSource(components);
            dateTimeFecha = new DateTimePicker();
            lblIngreso = new Label();
            lblEgreso = new Label();
            lblMargen = new Label();
            btnSalir = new Button();
            label1 = new Label();
            fechaYHora = new DataGridViewTextBoxColumn();
            ingresoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            egresoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            margenDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            medioPagoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridMovimientos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detallesLibrosDiariosBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblConsFinanzas
            // 
            lblConsFinanzas.AutoSize = true;
            lblConsFinanzas.BackColor = Color.Transparent;
            lblConsFinanzas.Location = new Point(89, 40);
            lblConsFinanzas.Name = "lblConsFinanzas";
            lblConsFinanzas.Size = new Size(164, 20);
            lblConsFinanzas.TabIndex = 0;
            lblConsFinanzas.Text = "CONSULTAR FINANZAS";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblConsFinanzas);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1414, 88);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // dataGridMovimientos
            // 
            dataGridMovimientos.AllowUserToAddRows = false;
            dataGridMovimientos.AllowUserToDeleteRows = false;
            dataGridMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridMovimientos.AutoGenerateColumns = false;
            dataGridMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMovimientos.BackgroundColor = Color.White;
            dataGridMovimientos.BorderStyle = BorderStyle.Fixed3D;
            dataGridMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridMovimientos.Columns.AddRange(new DataGridViewColumn[] { fechaYHora, ingresoDataGridViewTextBoxColumn, egresoDataGridViewTextBoxColumn, margenDataGridViewTextBoxColumn, medioPagoDataGridViewTextBoxColumn });
            dataGridMovimientos.DataSource = detallesLibrosDiariosBindingSource;
            dataGridMovimientos.Location = new Point(170, 207);
            dataGridMovimientos.Name = "dataGridMovimientos";
            dataGridMovimientos.ReadOnly = true;
            dataGridMovimientos.RowHeadersWidth = 51;
            dataGridMovimientos.Size = new Size(1077, 443);
            dataGridMovimientos.TabIndex = 2;
            // 
            // detallesLibrosDiariosBindingSource
            // 
            detallesLibrosDiariosBindingSource.DataSource = typeof(RingoEntidades.DetallesLibrosDiarios);
            // 
            // dateTimeFecha
            // 
            dateTimeFecha.Location = new Point(170, 125);
            dateTimeFecha.Name = "dateTimeFecha";
            dateTimeFecha.Size = new Size(355, 27);
            dateTimeFecha.TabIndex = 3;
            dateTimeFecha.ValueChanged += dateTimeFecha_ValueChanged;
            // 
            // lblIngreso
            // 
            lblIngreso.Anchor = AnchorStyles.Left;
            lblIngreso.AutoSize = true;
            lblIngreso.BackColor = Color.Transparent;
            lblIngreso.Location = new Point(170, 701);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(77, 20);
            lblIngreso.TabIndex = 4;
            lblIngreso.Text = "INGRESO :";
            // 
            // lblEgreso
            // 
            lblEgreso.Anchor = AnchorStyles.None;
            lblEgreso.AutoSize = true;
            lblEgreso.BackColor = Color.Transparent;
            lblEgreso.Location = new Point(611, 701);
            lblEgreso.Name = "lblEgreso";
            lblEgreso.Size = new Size(70, 20);
            lblEgreso.TabIndex = 5;
            lblEgreso.Text = "EGRESO :";
            // 
            // lblMargen
            // 
            lblMargen.Anchor = AnchorStyles.Right;
            lblMargen.AutoSize = true;
            lblMargen.BackColor = Color.Transparent;
            lblMargen.Location = new Point(1045, 701);
            lblMargen.Name = "lblMargen";
            lblMargen.Size = new Size(77, 20);
            lblMargen.TabIndex = 6;
            lblMargen.Text = "MARGEN :";
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom;
            btnSalir.Location = new Point(614, 769);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(165, 29);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(583, 132);
            label1.Name = "label1";
            label1.Size = new Size(176, 20);
            label1.TabIndex = 8;
            label1.Text = "SELECCIONE UNA FECHA";
            // 
            // fechaYHora
            // 
            fechaYHora.DataPropertyName = "Fecha";
            fechaYHora.HeaderText = "Fecha";
            fechaYHora.MinimumWidth = 6;
            fechaYHora.Name = "fechaYHora";
            fechaYHora.ReadOnly = true;
            // 
            // ingresoDataGridViewTextBoxColumn
            // 
            ingresoDataGridViewTextBoxColumn.DataPropertyName = "Ingreso";
            ingresoDataGridViewTextBoxColumn.HeaderText = "Ingreso";
            ingresoDataGridViewTextBoxColumn.MinimumWidth = 6;
            ingresoDataGridViewTextBoxColumn.Name = "ingresoDataGridViewTextBoxColumn";
            ingresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // egresoDataGridViewTextBoxColumn
            // 
            egresoDataGridViewTextBoxColumn.DataPropertyName = "Egreso";
            egresoDataGridViewTextBoxColumn.HeaderText = "Egreso";
            egresoDataGridViewTextBoxColumn.MinimumWidth = 6;
            egresoDataGridViewTextBoxColumn.Name = "egresoDataGridViewTextBoxColumn";
            egresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // margenDataGridViewTextBoxColumn
            // 
            margenDataGridViewTextBoxColumn.DataPropertyName = "Margen";
            margenDataGridViewTextBoxColumn.HeaderText = "Margen";
            margenDataGridViewTextBoxColumn.MinimumWidth = 6;
            margenDataGridViewTextBoxColumn.Name = "margenDataGridViewTextBoxColumn";
            margenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // medioPagoDataGridViewTextBoxColumn
            // 
            medioPagoDataGridViewTextBoxColumn.DataPropertyName = "MedioPago";
            medioPagoDataGridViewTextBoxColumn.HeaderText = "MedioPago";
            medioPagoDataGridViewTextBoxColumn.MinimumWidth = 6;
            medioPagoDataGridViewTextBoxColumn.Name = "medioPagoDataGridViewTextBoxColumn";
            medioPagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmAdminFinanzas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 828);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            Controls.Add(lblMargen);
            Controls.Add(lblEgreso);
            Controls.Add(lblIngreso);
            Controls.Add(dateTimeFecha);
            Controls.Add(dataGridMovimientos);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAdminFinanzas";
            Text = "Finanzas";
            Load += FrmAdminFinanzas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridMovimientos).EndInit();
            ((System.ComponentModel.ISupportInitialize)detallesLibrosDiariosBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConsFinanzas;
        private GroupBox groupBox1;
        private DataGridView dataGridMovimientos;
        private DateTimePicker dateTimeFecha;
        private Label lblIngreso;
        private Label lblEgreso;
        private Label lblMargen;
        private Button btnSalir;
        private Label label1;
        private BindingSource detallesLibrosDiariosBindingSource;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaYHora;
        private DataGridViewTextBoxColumn ingresoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn egresoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn margenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn medioPagoDataGridViewTextBoxColumn;
    }
}