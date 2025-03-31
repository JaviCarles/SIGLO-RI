namespace RingoFront
{
    partial class FrmReporteSeleccionado
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
            btnSalir = new Button();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            btnCrearPdf = new Button();
            dataGridComprasPorClientes = new DataGridView();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apellidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Dni = new DataGridViewTextBoxColumn();
            cantidadComprasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            montoTotalComprasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clienteParaReporteBindingSource = new BindingSource(components);
            lblTituloReporte = new Label();
            lblFecha = new Label();
            lblNombre = new Label();
            labelDesde = new Label();
            labelHasta = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridComprasPorClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteParaReporteBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSalir.Location = new Point(1080, 774);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(136, 29);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.BackColor = Color.Transparent;
            formsPlot1.BackgroundImage = Properties.Resources.fondo_verde_amarillo;
            formsPlot1.BackgroundImageLayout = ImageLayout.Zoom;
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(681, 230);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(776, 515);
            formsPlot1.TabIndex = 2;
            // 
            // btnCrearPdf
            // 
            btnCrearPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCrearPdf.Location = new Point(248, 774);
            btnCrearPdf.Name = "btnCrearPdf";
            btnCrearPdf.Size = new Size(127, 29);
            btnCrearPdf.TabIndex = 3;
            btnCrearPdf.Text = "Crear PDF";
            btnCrearPdf.UseVisualStyleBackColor = true;
            btnCrearPdf.Click += btnCrearPdf_Click;
            // 
            // dataGridComprasPorClientes
            // 
            dataGridComprasPorClientes.AllowUserToAddRows = false;
            dataGridComprasPorClientes.AllowUserToDeleteRows = false;
            dataGridComprasPorClientes.AllowUserToOrderColumns = true;
            dataGridComprasPorClientes.AutoGenerateColumns = false;
            dataGridComprasPorClientes.BackgroundColor = Color.White;
            dataGridComprasPorClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridComprasPorClientes.Columns.AddRange(new DataGridViewColumn[] { nombreDataGridViewTextBoxColumn, apellidoDataGridViewTextBoxColumn, Dni, cantidadComprasDataGridViewTextBoxColumn, montoTotalComprasDataGridViewTextBoxColumn });
            dataGridComprasPorClientes.DataSource = clienteParaReporteBindingSource;
            dataGridComprasPorClientes.Location = new Point(12, 230);
            dataGridComprasPorClientes.Name = "dataGridComprasPorClientes";
            dataGridComprasPorClientes.ReadOnly = true;
            dataGridComprasPorClientes.RowHeadersWidth = 51;
            dataGridComprasPorClientes.Size = new Size(629, 489);
            dataGridComprasPorClientes.TabIndex = 4;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            apellidoDataGridViewTextBoxColumn.MinimumWidth = 6;
            apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            apellidoDataGridViewTextBoxColumn.ReadOnly = true;
            apellidoDataGridViewTextBoxColumn.Width = 115;
            // 
            // Dni
            // 
            Dni.DataPropertyName = "Dni";
            Dni.HeaderText = "Dni";
            Dni.MinimumWidth = 6;
            Dni.Name = "Dni";
            Dni.ReadOnly = true;
            Dni.Width = 115;
            // 
            // cantidadComprasDataGridViewTextBoxColumn
            // 
            cantidadComprasDataGridViewTextBoxColumn.DataPropertyName = "CantidadCompras";
            cantidadComprasDataGridViewTextBoxColumn.HeaderText = "Compras";
            cantidadComprasDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadComprasDataGridViewTextBoxColumn.Name = "cantidadComprasDataGridViewTextBoxColumn";
            cantidadComprasDataGridViewTextBoxColumn.ReadOnly = true;
            cantidadComprasDataGridViewTextBoxColumn.Width = 77;
            // 
            // montoTotalComprasDataGridViewTextBoxColumn
            // 
            montoTotalComprasDataGridViewTextBoxColumn.DataPropertyName = "MontoTotalCompras";
            montoTotalComprasDataGridViewTextBoxColumn.HeaderText = "Monto Total $";
            montoTotalComprasDataGridViewTextBoxColumn.MinimumWidth = 6;
            montoTotalComprasDataGridViewTextBoxColumn.Name = "montoTotalComprasDataGridViewTextBoxColumn";
            montoTotalComprasDataGridViewTextBoxColumn.ReadOnly = true;
            montoTotalComprasDataGridViewTextBoxColumn.Width = 130;
            // 
            // clienteParaReporteBindingSource
            // 
            clienteParaReporteBindingSource.DataSource = typeof(RingoEntidades.ClienteParaReporte);
            // 
            // lblTituloReporte
            // 
            lblTituloReporte.AutoSize = true;
            lblTituloReporte.BackColor = Color.Transparent;
            lblTituloReporte.Location = new Point(53, 36);
            lblTituloReporte.Name = "lblTituloReporte";
            lblTituloReporte.Size = new Size(62, 20);
            lblTituloReporte.TabIndex = 5;
            lblTituloReporte.Text = "Reporte";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Location = new Point(993, 36);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(54, 20);
            lblFecha.TabIndex = 6;
            lblFecha.Text = "Fecha: ";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Location = new Point(53, 108);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(105, 20);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Realizado por:";
            // 
            // labelDesde
            // 
            labelDesde.AutoSize = true;
            labelDesde.Location = new Point(16, 37);
            labelDesde.Name = "labelDesde";
            labelDesde.Size = new Size(51, 20);
            labelDesde.TabIndex = 8;
            labelDesde.Text = "Desde";
            // 
            // labelHasta
            // 
            labelHasta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelHasta.AutoSize = true;
            labelHasta.Location = new Point(458, 37);
            labelHasta.Name = "labelHasta";
            labelHasta.Size = new Size(47, 20);
            labelHasta.TabIndex = 9;
            labelHasta.Text = "Hasta";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(labelDesde);
            groupBox1.Controls.Add(labelHasta);
            groupBox1.Location = new Point(754, 140);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(660, 70);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Período";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 182);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 11;
            label1.Text = "Compras por clientes";
            // 
            // FrmReporteSeleccionado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1469, 839);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(lblNombre);
            Controls.Add(lblFecha);
            Controls.Add(lblTituloReporte);
            Controls.Add(dataGridComprasPorClientes);
            Controls.Add(btnCrearPdf);
            Controls.Add(formsPlot1);
            Controls.Add(btnSalir);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReporteSeleccionado";
            Text = "REPORTE";
            Load += FrmReporteSeleccionado_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridComprasPorClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteParaReporteBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSalir;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Button btnCrearPdf;
        private DataGridView dataGridComprasPorClientes;
        private Label lblTituloReporte;
        private Label lblFecha;
        private Label lblNombre;
        private BindingSource clienteParaReporteBindingSource;
        private Label labelDesde;
        private Label labelHasta;
        private GroupBox groupBox1;
        private Label label1;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Dni;
        private DataGridViewTextBoxColumn cantidadComprasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn montoTotalComprasDataGridViewTextBoxColumn;
    }
}