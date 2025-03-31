namespace RingoFront
{
    partial class FrmReporteDeVentasPorCategoria
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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            label7 = new Label();
            dataGridPrendasPorCate = new DataGridView();
            cantidadPrendasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreCategoriaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreSubCategoriaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadPrendasPorCategoriaBindingSource = new BindingSource(components);
            label8 = new Label();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            dataGridVentasPorCate = new DataGridView();
            cantidadPrendasDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nombreCategoriaDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nombreSubCategoriaDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cantidadVentasPorCategoriaBindingSource = new BindingSource(components);
            groupBoxBotones = new GroupBox();
            btnSalir = new Button();
            btnCrearPdf = new Button();
            groupBox1 = new GroupBox();
            lblHasta = new Label();
            lblDesde = new Label();
            label4 = new Label();
            lblUsuario = new Label();
            lblFecha = new Label();
            lblPrendasPorCat = new Label();
            lblVentasPorCat = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridPrendasPorCate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cantidadPrendasPorCategoriaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridVentasPorCate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cantidadVentasPorCategoriaBindingSource).BeginInit();
            groupBoxBotones.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(44, 31);
            label1.Name = "label1";
            label1.Size = new Size(263, 20);
            label1.TabIndex = 20;
            label1.Text = "REPORTE DE VENTAS POR CATEGORÍA";
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Right;
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(707, 153);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(704, 370);
            formsPlot1.TabIndex = 24;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(313, 159);
            label7.Name = "label7";
            label7.Size = new Size(196, 20);
            label7.TabIndex = 23;
            label7.Text = "PRENDAS POR CATEGORÍAS";
            // 
            // dataGridPrendasPorCate
            // 
            dataGridPrendasPorCate.AllowUserToAddRows = false;
            dataGridPrendasPorCate.AllowUserToDeleteRows = false;
            dataGridPrendasPorCate.Anchor = AnchorStyles.Right;
            dataGridPrendasPorCate.AutoGenerateColumns = false;
            dataGridPrendasPorCate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPrendasPorCate.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridPrendasPorCate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPrendasPorCate.Columns.AddRange(new DataGridViewColumn[] { cantidadPrendasDataGridViewTextBoxColumn, nombreCategoriaDataGridViewTextBoxColumn, nombreSubCategoriaDataGridViewTextBoxColumn });
            dataGridPrendasPorCate.DataSource = cantidadPrendasPorCategoriaBindingSource;
            dataGridPrendasPorCate.Location = new Point(276, 216);
            dataGridPrendasPorCate.Name = "dataGridPrendasPorCate";
            dataGridPrendasPorCate.ReadOnly = true;
            dataGridPrendasPorCate.RowHeadersWidth = 51;
            dataGridPrendasPorCate.Size = new Size(404, 277);
            dataGridPrendasPorCate.TabIndex = 22;
            // 
            // cantidadPrendasDataGridViewTextBoxColumn
            // 
            cantidadPrendasDataGridViewTextBoxColumn.DataPropertyName = "CantidadPrendas";
            cantidadPrendasDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadPrendasDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadPrendasDataGridViewTextBoxColumn.Name = "cantidadPrendasDataGridViewTextBoxColumn";
            cantidadPrendasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreCategoriaDataGridViewTextBoxColumn
            // 
            nombreCategoriaDataGridViewTextBoxColumn.DataPropertyName = "NombreCategoria";
            nombreCategoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            nombreCategoriaDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreCategoriaDataGridViewTextBoxColumn.Name = "nombreCategoriaDataGridViewTextBoxColumn";
            nombreCategoriaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreSubCategoriaDataGridViewTextBoxColumn
            // 
            nombreSubCategoriaDataGridViewTextBoxColumn.DataPropertyName = "NombreSubCategoria";
            nombreSubCategoriaDataGridViewTextBoxColumn.HeaderText = "SubCategoria";
            nombreSubCategoriaDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreSubCategoriaDataGridViewTextBoxColumn.Name = "nombreSubCategoriaDataGridViewTextBoxColumn";
            nombreSubCategoriaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadPrendasPorCategoriaBindingSource
            // 
            cantidadPrendasPorCategoriaBindingSource.DataSource = typeof(RingoEntidades.CantidadPrendasPorCategoria);
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(313, 533);
            label8.Name = "label8";
            label8.Size = new Size(184, 20);
            label8.TabIndex = 25;
            label8.Text = "VENTAS POR CATEGORÍAS";
            // 
            // formsPlot2
            // 
            formsPlot2.Anchor = AnchorStyles.Right;
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Location = new Point(707, 527);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(704, 371);
            formsPlot2.TabIndex = 27;
            // 
            // dataGridVentasPorCate
            // 
            dataGridVentasPorCate.AllowUserToAddRows = false;
            dataGridVentasPorCate.AllowUserToDeleteRows = false;
            dataGridVentasPorCate.Anchor = AnchorStyles.Right;
            dataGridVentasPorCate.AutoGenerateColumns = false;
            dataGridVentasPorCate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridVentasPorCate.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridVentasPorCate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVentasPorCate.Columns.AddRange(new DataGridViewColumn[] { cantidadPrendasDataGridViewTextBoxColumn1, nombreCategoriaDataGridViewTextBoxColumn1, nombreSubCategoriaDataGridViewTextBoxColumn1 });
            dataGridVentasPorCate.DataSource = cantidadVentasPorCategoriaBindingSource;
            dataGridVentasPorCate.Location = new Point(276, 583);
            dataGridVentasPorCate.Name = "dataGridVentasPorCate";
            dataGridVentasPorCate.ReadOnly = true;
            dataGridVentasPorCate.RowHeadersWidth = 51;
            dataGridVentasPorCate.Size = new Size(404, 263);
            dataGridVentasPorCate.TabIndex = 26;
            // 
            // cantidadPrendasDataGridViewTextBoxColumn1
            // 
            cantidadPrendasDataGridViewTextBoxColumn1.DataPropertyName = "CantidadPrendas";
            cantidadPrendasDataGridViewTextBoxColumn1.HeaderText = "Cantidad";
            cantidadPrendasDataGridViewTextBoxColumn1.MinimumWidth = 6;
            cantidadPrendasDataGridViewTextBoxColumn1.Name = "cantidadPrendasDataGridViewTextBoxColumn1";
            cantidadPrendasDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nombreCategoriaDataGridViewTextBoxColumn1
            // 
            nombreCategoriaDataGridViewTextBoxColumn1.DataPropertyName = "NombreCategoria";
            nombreCategoriaDataGridViewTextBoxColumn1.HeaderText = "Categoría";
            nombreCategoriaDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nombreCategoriaDataGridViewTextBoxColumn1.Name = "nombreCategoriaDataGridViewTextBoxColumn1";
            nombreCategoriaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nombreSubCategoriaDataGridViewTextBoxColumn1
            // 
            nombreSubCategoriaDataGridViewTextBoxColumn1.DataPropertyName = "NombreSubCategoria";
            nombreSubCategoriaDataGridViewTextBoxColumn1.HeaderText = "SubCategoría";
            nombreSubCategoriaDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nombreSubCategoriaDataGridViewTextBoxColumn1.Name = "nombreSubCategoriaDataGridViewTextBoxColumn1";
            nombreSubCategoriaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cantidadVentasPorCategoriaBindingSource
            // 
            cantidadVentasPorCategoriaBindingSource.DataSource = typeof(RingoEntidades.CantidadVentasPorCategoria);
            // 
            // groupBoxBotones
            // 
            groupBoxBotones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxBotones.Controls.Add(btnSalir);
            groupBoxBotones.Controls.Add(btnCrearPdf);
            groupBoxBotones.Location = new Point(3, 906);
            groupBoxBotones.Name = "groupBoxBotones";
            groupBoxBotones.Size = new Size(1487, 59);
            groupBoxBotones.TabIndex = 28;
            groupBoxBotones.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(1136, 11);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(226, 29);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCrearPdf
            // 
            btnCrearPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCrearPdf.Location = new Point(127, 11);
            btnCrearPdf.Name = "btnCrearPdf";
            btnCrearPdf.Size = new Size(226, 29);
            btnCrearPdf.TabIndex = 2;
            btnCrearPdf.Text = "GUARDAR EN PDF";
            btnCrearPdf.UseVisualStyleBackColor = true;
            btnCrearPdf.Click += btnCrearPdf_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblHasta);
            groupBox1.Controls.Add(lblDesde);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblUsuario);
            groupBox1.Location = new Point(3, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1487, 65);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            // 
            // lblHasta
            // 
            lblHasta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(1081, 23);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(58, 20);
            lblHasta.TabIndex = 12;
            lblHasta.Text = "HASTA:";
            // 
            // lblDesde
            // 
            lblDesde.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(719, 23);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(58, 20);
            lblDesde.TabIndex = 11;
            lblDesde.Text = "DESDE:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(588, 23);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 10;
            label4.Text = "PERÍODO:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(41, 23);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(123, 20);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "REALIZADO POR:";
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Location = new Point(1073, 31);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(57, 20);
            lblFecha.TabIndex = 9;
            lblFecha.Text = "FECHA:";
            // 
            // lblPrendasPorCat
            // 
            lblPrendasPorCat.AutoSize = true;
            lblPrendasPorCat.BackColor = Color.Transparent;
            lblPrendasPorCat.Location = new Point(12, 268);
            lblPrendasPorCat.Name = "lblPrendasPorCat";
            lblPrendasPorCat.Size = new Size(50, 20);
            lblPrendasPorCat.TabIndex = 30;
            lblPrendasPorCat.Text = "TOTAL";
            // 
            // lblVentasPorCat
            // 
            lblVentasPorCat.AutoSize = true;
            lblVentasPorCat.BackColor = Color.Transparent;
            lblVentasPorCat.Location = new Point(12, 636);
            lblVentasPorCat.Name = "lblVentasPorCat";
            lblVentasPorCat.Size = new Size(50, 20);
            lblVentasPorCat.TabIndex = 31;
            lblVentasPorCat.Text = "TOTAL";
            // 
            // FrmReporteDeVentasPorCategoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1493, 966);
            Controls.Add(lblVentasPorCat);
            Controls.Add(lblPrendasPorCat);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxBotones);
            Controls.Add(formsPlot2);
            Controls.Add(dataGridVentasPorCate);
            Controls.Add(lblFecha);
            Controls.Add(label8);
            Controls.Add(formsPlot1);
            Controls.Add(label7);
            Controls.Add(dataGridPrendasPorCate);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReporteDeVentasPorCategoria";
            Text = "FrmReporteDeVentasPorCategoria";
            Load += FrmReporteDeVentasPorCategoria_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridPrendasPorCate).EndInit();
            ((System.ComponentModel.ISupportInitialize)cantidadPrendasPorCategoriaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridVentasPorCate).EndInit();
            ((System.ComponentModel.ISupportInitialize)cantidadVentasPorCategoriaBindingSource).EndInit();
            groupBoxBotones.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Label label7;
        private DataGridView dataGridPrendasPorCate;
        private Label label8;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private DataGridView dataGridVentasPorCate;
        private GroupBox groupBoxBotones;
        private Button btnSalir;
        private Button btnCrearPdf;
        private GroupBox groupBox1;
        private Label lblHasta;
        private Label lblDesde;
        private Label label4;
        private Label lblUsuario;
        private Label lblFecha;
        private DataGridViewTextBoxColumn cantidadPrendasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreCategoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreSubCategoriaDataGridViewTextBoxColumn;
        private BindingSource cantidadPrendasPorCategoriaBindingSource;
        private DataGridViewTextBoxColumn cantidadPrendasDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nombreCategoriaDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nombreSubCategoriaDataGridViewTextBoxColumn1;
        private BindingSource cantidadVentasPorCategoriaBindingSource;
        private Label lblPrendasPorCat;
        private Label lblVentasPorCat;
    }
}