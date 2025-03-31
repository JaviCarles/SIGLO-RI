namespace RingoFront
{
    partial class FrmReporteComparativo
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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            lblNombre = new Label();
            lblFecha = new Label();
            lblTituloReporte = new Label();
            dataGridViewAño1 = new DataGridView();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadVentasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mesParaReporteBindingSource = new BindingSource(components);
            dataGridViewAño2 = new DataGridView();
            nombreDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cantidadVentasDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            mesParaReporteBindingSource1 = new BindingSource(components);
            btnSalir = new Button();
            btnPdf = new Button();
            lblAño1 = new Label();
            lblAño2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAño1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mesParaReporteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAño2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mesParaReporteBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(677, 223);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(704, 374);
            formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            formsPlot2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Location = new Point(677, 612);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(704, 361);
            formsPlot2.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Location = new Point(54, 99);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(257, 20);
            lblNombre.TabIndex = 10;
            lblNombre.Text = "Realizado por: VERÓNICA MENDOZA";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Location = new Point(1002, 35);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(54, 20);
            lblFecha.TabIndex = 9;
            lblFecha.Text = "Fecha: ";
            // 
            // lblTituloReporte
            // 
            lblTituloReporte.AutoSize = true;
            lblTituloReporte.BackColor = Color.Transparent;
            lblTituloReporte.Location = new Point(54, 35);
            lblTituloReporte.Name = "lblTituloReporte";
            lblTituloReporte.Size = new Size(305, 20);
            lblTituloReporte.TabIndex = 8;
            lblTituloReporte.Text = "REPORTE DE VENTAS ANUAL COMPARATIVO";
            // 
            // dataGridViewAño1
            // 
            dataGridViewAño1.AllowUserToAddRows = false;
            dataGridViewAño1.AllowUserToDeleteRows = false;
            dataGridViewAño1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewAño1.AutoGenerateColumns = false;
            dataGridViewAño1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAño1.BackgroundColor = Color.White;
            dataGridViewAño1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAño1.Columns.AddRange(new DataGridViewColumn[] { nombreDataGridViewTextBoxColumn, cantidadVentasDataGridViewTextBoxColumn });
            dataGridViewAño1.DataSource = mesParaReporteBindingSource;
            dataGridViewAño1.Location = new Point(275, 236);
            dataGridViewAño1.Name = "dataGridViewAño1";
            dataGridViewAño1.ReadOnly = true;
            dataGridViewAño1.RowHeadersWidth = 51;
            dataGridViewAño1.Size = new Size(337, 331);
            dataGridViewAño1.TabIndex = 11;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Mes";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadVentasDataGridViewTextBoxColumn
            // 
            cantidadVentasDataGridViewTextBoxColumn.DataPropertyName = "CantidadVentas";
            cantidadVentasDataGridViewTextBoxColumn.HeaderText = "Cantidad Ventas";
            cantidadVentasDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadVentasDataGridViewTextBoxColumn.Name = "cantidadVentasDataGridViewTextBoxColumn";
            cantidadVentasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mesParaReporteBindingSource
            // 
            mesParaReporteBindingSource.DataSource = typeof(RingoEntidades.MesParaReporte);
            // 
            // dataGridViewAño2
            // 
            dataGridViewAño2.AllowUserToAddRows = false;
            dataGridViewAño2.AllowUserToDeleteRows = false;
            dataGridViewAño2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewAño2.AutoGenerateColumns = false;
            dataGridViewAño2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAño2.BackgroundColor = Color.White;
            dataGridViewAño2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAño2.Columns.AddRange(new DataGridViewColumn[] { nombreDataGridViewTextBoxColumn1, cantidadVentasDataGridViewTextBoxColumn1 });
            dataGridViewAño2.DataSource = mesParaReporteBindingSource1;
            dataGridViewAño2.Location = new Point(275, 625);
            dataGridViewAño2.Name = "dataGridViewAño2";
            dataGridViewAño2.ReadOnly = true;
            dataGridViewAño2.RowHeadersWidth = 51;
            dataGridViewAño2.Size = new Size(337, 320);
            dataGridViewAño2.TabIndex = 12;
            // 
            // nombreDataGridViewTextBoxColumn1
            // 
            nombreDataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn1.HeaderText = "Mes";
            nombreDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            nombreDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cantidadVentasDataGridViewTextBoxColumn1
            // 
            cantidadVentasDataGridViewTextBoxColumn1.DataPropertyName = "CantidadVentas";
            cantidadVentasDataGridViewTextBoxColumn1.HeaderText = "Cantidad Ventas";
            cantidadVentasDataGridViewTextBoxColumn1.MinimumWidth = 6;
            cantidadVentasDataGridViewTextBoxColumn1.Name = "cantidadVentasDataGridViewTextBoxColumn1";
            cantidadVentasDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // mesParaReporteBindingSource1
            // 
            mesParaReporteBindingSource1.DataSource = typeof(RingoEntidades.MesParaReporte);
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(1124, 993);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(191, 29);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnPdf
            // 
            btnPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPdf.Location = new Point(121, 993);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(190, 29);
            btnPdf.TabIndex = 15;
            btnPdf.Text = "Crear PDF";
            btnPdf.UseVisualStyleBackColor = true;
            btnPdf.Click += btnPdf_Click;
            // 
            // lblAño1
            // 
            lblAño1.AutoSize = true;
            lblAño1.BackColor = Color.Transparent;
            lblAño1.Location = new Point(54, 236);
            lblAño1.Name = "lblAño1";
            lblAño1.Size = new Size(45, 20);
            lblAño1.TabIndex = 16;
            lblAño1.Text = "AÑO ";
            // 
            // lblAño2
            // 
            lblAño2.AutoSize = true;
            lblAño2.BackColor = Color.Transparent;
            lblAño2.Location = new Point(54, 625);
            lblAño2.Name = "lblAño2";
            lblAño2.Size = new Size(45, 20);
            lblAño2.TabIndex = 17;
            lblAño2.Text = "AÑO ";
            // 
            // FrmReporteComparativo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1451, 1055);
            Controls.Add(lblAño2);
            Controls.Add(lblAño1);
            Controls.Add(btnPdf);
            Controls.Add(btnSalir);
            Controls.Add(dataGridViewAño2);
            Controls.Add(dataGridViewAño1);
            Controls.Add(lblNombre);
            Controls.Add(lblFecha);
            Controls.Add(lblTituloReporte);
            Controls.Add(formsPlot2);
            Controls.Add(formsPlot1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReporteComparativo";
            Text = "FrmReporteComparativo";
            Load += FrmReporteComparativo_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAño1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mesParaReporteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAño2).EndInit();
            ((System.ComponentModel.ISupportInitialize)mesParaReporteBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private Label lblNombre;
        private Label lblFecha;
        private Label lblTituloReporte;
        private DataGridView dataGridViewAño1;
        private DataGridView dataGridViewAño2;
        private Button btnSalir;
        private Button btnPdf;
        private Label lblAño1;
        private Label lblAño2;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadVentasDataGridViewTextBoxColumn;
        private BindingSource mesParaReporteBindingSource;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cantidadVentasDataGridViewTextBoxColumn1;
        private BindingSource mesParaReporteBindingSource1;
    }
}