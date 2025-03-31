namespace RingoFront
{
    partial class FrmReporteVentasProveedores
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
            label1 = new Label();
            lblUsuario = new Label();
            lblFecha = new Label();
            groupBox1 = new GroupBox();
            lblHasta = new Label();
            lblDesde = new Label();
            label4 = new Label();
            dataGridPrendasPorProve = new DataGridView();
            nombreProveedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadPrendasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantPrendasPorProveedorBindingSource = new BindingSource(components);
            label7 = new Label();
            label8 = new Label();
            dataGridVentasPorProve = new DataGridView();
            nombreProveedorDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cantidadPrendasVendidasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prendasVendidasPorProveedorBindingSource = new BindingSource(components);
            groupBox2 = new GroupBox();
            btnSalir = new Button();
            btnCrearPdf = new Button();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            lblTotalPrendas = new Label();
            lblTotalVentas = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPrendasPorProve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cantPrendasPorProveedorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridVentasPorProve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prendasVendidasPorProveedorBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(53, 26);
            label1.Name = "label1";
            label1.Size = new Size(269, 20);
            label1.TabIndex = 0;
            label1.Text = "REPORTE DE VENTAS POR PROVEEDOR";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(41, 23);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(123, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "REALIZADO POR:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Location = new Point(896, 36);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(57, 20);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "FECHA:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblHasta);
            groupBox1.Controls.Add(lblDesde);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblUsuario);
            groupBox1.Location = new Point(12, 73);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1305, 63);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // lblHasta
            // 
            lblHasta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(964, 23);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(59, 20);
            lblHasta.TabIndex = 7;
            lblHasta.Text = "HASTA ";
            // 
            // lblDesde
            // 
            lblDesde.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(551, 25);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(59, 20);
            lblDesde.TabIndex = 6;
            lblDesde.Text = "DESDE ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(428, 23);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 3;
            label4.Text = "PERÍODO:";
            // 
            // dataGridPrendasPorProve
            // 
            dataGridPrendasPorProve.AllowUserToAddRows = false;
            dataGridPrendasPorProve.AllowUserToDeleteRows = false;
            dataGridPrendasPorProve.AutoGenerateColumns = false;
            dataGridPrendasPorProve.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPrendasPorProve.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridPrendasPorProve.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPrendasPorProve.Columns.AddRange(new DataGridViewColumn[] { nombreProveedorDataGridViewTextBoxColumn, cantidadPrendasDataGridViewTextBoxColumn });
            dataGridPrendasPorProve.DataSource = cantPrendasPorProveedorBindingSource;
            dataGridPrendasPorProve.Location = new Point(302, 195);
            dataGridPrendasPorProve.Name = "dataGridPrendasPorProve";
            dataGridPrendasPorProve.ReadOnly = true;
            dataGridPrendasPorProve.RowHeadersWidth = 51;
            dataGridPrendasPorProve.Size = new Size(359, 267);
            dataGridPrendasPorProve.TabIndex = 4;
            // 
            // nombreProveedorDataGridViewTextBoxColumn
            // 
            nombreProveedorDataGridViewTextBoxColumn.DataPropertyName = "NombreProveedor";
            nombreProveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            nombreProveedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreProveedorDataGridViewTextBoxColumn.Name = "nombreProveedorDataGridViewTextBoxColumn";
            nombreProveedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadPrendasDataGridViewTextBoxColumn
            // 
            cantidadPrendasDataGridViewTextBoxColumn.DataPropertyName = "CantidadPrendas";
            cantidadPrendasDataGridViewTextBoxColumn.HeaderText = "Total Prendas";
            cantidadPrendasDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadPrendasDataGridViewTextBoxColumn.Name = "cantidadPrendasDataGridViewTextBoxColumn";
            cantidadPrendasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantPrendasPorProveedorBindingSource
            // 
            cantPrendasPorProveedorBindingSource.DataSource = typeof(RingoEntidades.CantPrendasPorProveedor);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(302, 153);
            label7.Name = "label7";
            label7.Size = new Size(210, 20);
            label7.TabIndex = 5;
            label7.Text = "PRENDAS POR PROVEEDORES";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(302, 509);
            label8.Name = "label8";
            label8.Size = new Size(198, 20);
            label8.TabIndex = 6;
            label8.Text = "VENTAS POR PROVEEDORES";
            // 
            // dataGridVentasPorProve
            // 
            dataGridVentasPorProve.AllowUserToAddRows = false;
            dataGridVentasPorProve.AllowUserToDeleteRows = false;
            dataGridVentasPorProve.AutoGenerateColumns = false;
            dataGridVentasPorProve.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridVentasPorProve.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridVentasPorProve.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVentasPorProve.Columns.AddRange(new DataGridViewColumn[] { nombreProveedorDataGridViewTextBoxColumn1, cantidadPrendasVendidasDataGridViewTextBoxColumn });
            dataGridVentasPorProve.DataSource = prendasVendidasPorProveedorBindingSource;
            dataGridVentasPorProve.Location = new Point(302, 548);
            dataGridVentasPorProve.Name = "dataGridVentasPorProve";
            dataGridVentasPorProve.ReadOnly = true;
            dataGridVentasPorProve.RowHeadersWidth = 51;
            dataGridVentasPorProve.Size = new Size(359, 264);
            dataGridVentasPorProve.TabIndex = 7;
            // 
            // nombreProveedorDataGridViewTextBoxColumn1
            // 
            nombreProveedorDataGridViewTextBoxColumn1.DataPropertyName = "NombreProveedor";
            nombreProveedorDataGridViewTextBoxColumn1.HeaderText = "Proveedor";
            nombreProveedorDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nombreProveedorDataGridViewTextBoxColumn1.Name = "nombreProveedorDataGridViewTextBoxColumn1";
            nombreProveedorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cantidadPrendasVendidasDataGridViewTextBoxColumn
            // 
            cantidadPrendasVendidasDataGridViewTextBoxColumn.DataPropertyName = "CantidadPrendasVendidas";
            cantidadPrendasVendidasDataGridViewTextBoxColumn.HeaderText = "Prendas Vendidas";
            cantidadPrendasVendidasDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadPrendasVendidasDataGridViewTextBoxColumn.Name = "cantidadPrendasVendidasDataGridViewTextBoxColumn";
            cantidadPrendasVendidasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prendasVendidasPorProveedorBindingSource
            // 
            prendasVendidasPorProveedorBindingSource.DataSource = typeof(RingoEntidades.PrendasVendidasPorProveedor);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSalir);
            groupBox2.Controls.Add(btnCrearPdf);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.Location = new Point(0, 859);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1329, 72);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(976, 24);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(226, 29);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCrearPdf
            // 
            btnCrearPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCrearPdf.Location = new Point(147, 24);
            btnCrearPdf.Name = "btnCrearPdf";
            btnCrearPdf.Size = new Size(226, 29);
            btnCrearPdf.TabIndex = 0;
            btnCrearPdf.Text = "GUARDAR EN PDF";
            btnCrearPdf.UseVisualStyleBackColor = true;
            btnCrearPdf.Click += btnCrearPdf_Click;
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top;
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(675, 160);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(639, 327);
            formsPlot1.TabIndex = 9;
            // 
            // formsPlot2
            // 
            formsPlot2.Anchor = AnchorStyles.Top;
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Location = new Point(675, 516);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(639, 327);
            formsPlot2.TabIndex = 10;
            // 
            // lblTotalPrendas
            // 
            lblTotalPrendas.AutoSize = true;
            lblTotalPrendas.BackColor = Color.Transparent;
            lblTotalPrendas.Location = new Point(12, 277);
            lblTotalPrendas.Name = "lblTotalPrendas";
            lblTotalPrendas.Size = new Size(119, 20);
            lblTotalPrendas.TabIndex = 11;
            lblTotalPrendas.Text = "TOTAL PRENDAS";
            // 
            // lblTotalVentas
            // 
            lblTotalVentas.AutoSize = true;
            lblTotalVentas.BackColor = Color.Transparent;
            lblTotalVentas.Location = new Point(12, 606);
            lblTotalVentas.Name = "lblTotalVentas";
            lblTotalVentas.Size = new Size(126, 20);
            lblTotalVentas.TabIndex = 12;
            lblTotalVentas.Text = "TOTAL VENDIDAS";
            // 
            // FrmReporteVentasProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 931);
            Controls.Add(lblTotalVentas);
            Controls.Add(lblTotalPrendas);
            Controls.Add(formsPlot2);
            Controls.Add(formsPlot1);
            Controls.Add(groupBox2);
            Controls.Add(dataGridVentasPorProve);
            Controls.Add(lblFecha);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dataGridPrendasPorProve);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReporteVentasProveedores";
            Text = "FrmReporteVentasProveedores";
            Load += FrmReporteVentasProveedores_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPrendasPorProve).EndInit();
            ((System.ComponentModel.ISupportInitialize)cantPrendasPorProveedorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridVentasPorProve).EndInit();
            ((System.ComponentModel.ISupportInitialize)prendasVendidasPorProveedorBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblUsuario;
        private Label lblFecha;
        private GroupBox groupBox1;
        private Label label4;
        private Label lblHasta;
        private Label lblDesde;
        private DataGridView dataGridPrendasPorProve;
        private Label label7;
        private Label label8;
        private DataGridView dataGridVentasPorProve;
        private GroupBox groupBox2;
        private Button btnSalir;
        private Button btnCrearPdf;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private BindingSource cantPrendasPorProveedorBindingSource;
        private BindingSource prendasVendidasPorProveedorBindingSource;
        private Label lblTotalPrendas;
        private Label lblTotalVentas;
        private DataGridViewTextBoxColumn nombreProveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadPrendasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProveedorDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cantidadPrendasVendidasDataGridViewTextBoxColumn;
    }
}