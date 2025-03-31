namespace RingoFront
{
    partial class FrmReporteMovimientosFinanzas
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
            label1 = new Label();
            dataGridMesAnt = new DataGridView();
            fechaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalIngresoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalEgresoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalMargenDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            movimientoFinanzasDiarioBindingSource = new BindingSource(components);
            dataGridMesPost = new DataGridView();
            fechaDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            totalIngresoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            totalEgresoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            totalMargenDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            movimientoFinanzasDiarioBindingSource1 = new BindingSource(components);
            btnPdf = new Button();
            btnSalir = new Button();
            lblPeriodo2 = new Label();
            lblPeriodo1 = new Label();
            lblMesAnt = new Label();
            lblMesPost = new Label();
            lblFecha = new Label();
            lblUsuario = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridMesAnt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movimientoFinanzasDiarioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridMesPost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movimientoFinanzasDiarioBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(513, 260);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(776, 515);
            formsPlot1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(60, 52);
            label1.Name = "label1";
            label1.Size = new Size(405, 20);
            label1.TabIndex = 1;
            label1.Text = "REPORTE COMPARATIVO DE EGRESOS E INGRESOS BRUTOS";
            // 
            // dataGridMesAnt
            // 
            dataGridMesAnt.AllowUserToAddRows = false;
            dataGridMesAnt.AllowUserToDeleteRows = false;
            dataGridMesAnt.AutoGenerateColumns = false;
            dataGridMesAnt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMesAnt.BackgroundColor = Color.White;
            dataGridMesAnt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridMesAnt.Columns.AddRange(new DataGridViewColumn[] { fechaDataGridViewTextBoxColumn, totalIngresoDataGridViewTextBoxColumn, totalEgresoDataGridViewTextBoxColumn, totalMargenDataGridViewTextBoxColumn });
            dataGridMesAnt.DataSource = movimientoFinanzasDiarioBindingSource;
            dataGridMesAnt.Location = new Point(12, 205);
            dataGridMesAnt.Name = "dataGridMesAnt";
            dataGridMesAnt.ReadOnly = true;
            dataGridMesAnt.RowHeadersWidth = 51;
            dataGridMesAnt.Size = new Size(495, 284);
            dataGridMesAnt.TabIndex = 2;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalIngresoDataGridViewTextBoxColumn
            // 
            totalIngresoDataGridViewTextBoxColumn.DataPropertyName = "TotalIngreso";
            totalIngresoDataGridViewTextBoxColumn.HeaderText = "Ingreso";
            totalIngresoDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalIngresoDataGridViewTextBoxColumn.Name = "totalIngresoDataGridViewTextBoxColumn";
            totalIngresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalEgresoDataGridViewTextBoxColumn
            // 
            totalEgresoDataGridViewTextBoxColumn.DataPropertyName = "TotalEgreso";
            totalEgresoDataGridViewTextBoxColumn.HeaderText = "Egreso";
            totalEgresoDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalEgresoDataGridViewTextBoxColumn.Name = "totalEgresoDataGridViewTextBoxColumn";
            totalEgresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalMargenDataGridViewTextBoxColumn
            // 
            totalMargenDataGridViewTextBoxColumn.DataPropertyName = "TotalMargen";
            totalMargenDataGridViewTextBoxColumn.HeaderText = "Margen";
            totalMargenDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalMargenDataGridViewTextBoxColumn.Name = "totalMargenDataGridViewTextBoxColumn";
            totalMargenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // movimientoFinanzasDiarioBindingSource
            // 
            movimientoFinanzasDiarioBindingSource.DataSource = typeof(RingoEntidades.MovimientoFinanzasDiario);
            // 
            // dataGridMesPost
            // 
            dataGridMesPost.AllowUserToAddRows = false;
            dataGridMesPost.AllowUserToDeleteRows = false;
            dataGridMesPost.AutoGenerateColumns = false;
            dataGridMesPost.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMesPost.BackgroundColor = Color.White;
            dataGridMesPost.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridMesPost.Columns.AddRange(new DataGridViewColumn[] { fechaDataGridViewTextBoxColumn1, totalIngresoDataGridViewTextBoxColumn1, totalEgresoDataGridViewTextBoxColumn1, totalMargenDataGridViewTextBoxColumn1 });
            dataGridMesPost.DataSource = movimientoFinanzasDiarioBindingSource1;
            dataGridMesPost.Location = new Point(12, 570);
            dataGridMesPost.Name = "dataGridMesPost";
            dataGridMesPost.ReadOnly = true;
            dataGridMesPost.RowHeadersWidth = 51;
            dataGridMesPost.Size = new Size(495, 284);
            dataGridMesPost.TabIndex = 3;
            // 
            // fechaDataGridViewTextBoxColumn1
            // 
            fechaDataGridViewTextBoxColumn1.DataPropertyName = "Fecha";
            fechaDataGridViewTextBoxColumn1.HeaderText = "Fecha";
            fechaDataGridViewTextBoxColumn1.MinimumWidth = 6;
            fechaDataGridViewTextBoxColumn1.Name = "fechaDataGridViewTextBoxColumn1";
            fechaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalIngresoDataGridViewTextBoxColumn1
            // 
            totalIngresoDataGridViewTextBoxColumn1.DataPropertyName = "TotalIngreso";
            totalIngresoDataGridViewTextBoxColumn1.HeaderText = "Ingreso";
            totalIngresoDataGridViewTextBoxColumn1.MinimumWidth = 6;
            totalIngresoDataGridViewTextBoxColumn1.Name = "totalIngresoDataGridViewTextBoxColumn1";
            totalIngresoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalEgresoDataGridViewTextBoxColumn1
            // 
            totalEgresoDataGridViewTextBoxColumn1.DataPropertyName = "TotalEgreso";
            totalEgresoDataGridViewTextBoxColumn1.HeaderText = "Egreso";
            totalEgresoDataGridViewTextBoxColumn1.MinimumWidth = 6;
            totalEgresoDataGridViewTextBoxColumn1.Name = "totalEgresoDataGridViewTextBoxColumn1";
            totalEgresoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalMargenDataGridViewTextBoxColumn1
            // 
            totalMargenDataGridViewTextBoxColumn1.DataPropertyName = "TotalMargen";
            totalMargenDataGridViewTextBoxColumn1.HeaderText = "Margen";
            totalMargenDataGridViewTextBoxColumn1.MinimumWidth = 6;
            totalMargenDataGridViewTextBoxColumn1.Name = "totalMargenDataGridViewTextBoxColumn1";
            totalMargenDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // movimientoFinanzasDiarioBindingSource1
            // 
            movimientoFinanzasDiarioBindingSource1.DataSource = typeof(RingoEntidades.MovimientoFinanzasDiario);
            // 
            // btnPdf
            // 
            btnPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPdf.Location = new Point(150, 912);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(180, 29);
            btnPdf.TabIndex = 4;
            btnPdf.Text = "Crear PDF";
            btnPdf.UseVisualStyleBackColor = true;
            btnPdf.Click += btnPdf_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(1225, 912);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(179, 29);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblPeriodo2
            // 
            lblPeriodo2.AutoSize = true;
            lblPeriodo2.BackColor = Color.Transparent;
            lblPeriodo2.Location = new Point(37, 525);
            lblPeriodo2.Name = "lblPeriodo2";
            lblPeriodo2.Size = new Size(60, 20);
            lblPeriodo2.TabIndex = 6;
            lblPeriodo2.Text = "Periodo";
            // 
            // lblPeriodo1
            // 
            lblPeriodo1.AutoSize = true;
            lblPeriodo1.BackColor = Color.Transparent;
            lblPeriodo1.Location = new Point(37, 166);
            lblPeriodo1.Name = "lblPeriodo1";
            lblPeriodo1.Size = new Size(60, 20);
            lblPeriodo1.TabIndex = 7;
            lblPeriodo1.Text = "Periodo";
            // 
            // lblMesAnt
            // 
            lblMesAnt.AutoSize = true;
            lblMesAnt.BackColor = Color.Transparent;
            lblMesAnt.Location = new Point(1306, 334);
            lblMesAnt.Name = "lblMesAnt";
            lblMesAnt.Size = new Size(94, 20);
            lblMesAnt.TabIndex = 8;
            lblMesAnt.Text = "Mes Anterior";
            // 
            // lblMesPost
            // 
            lblMesPost.AutoSize = true;
            lblMesPost.BackColor = Color.Transparent;
            lblMesPost.Location = new Point(1306, 659);
            lblMesPost.Name = "lblMesPost";
            lblMesPost.Size = new Size(98, 20);
            lblMesPost.TabIndex = 9;
            lblMesPost.Text = "Mes Posterior";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Location = new Point(1123, 52);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(47, 20);
            lblFecha.TabIndex = 10;
            lblFecha.Text = "Fecha";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Location = new Point(59, 101);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 20);
            lblUsuario.TabIndex = 11;
            lblUsuario.Text = "Usuario";
            // 
            // FrmReporteMovimientosFinanzas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 984);
            Controls.Add(lblUsuario);
            Controls.Add(lblFecha);
            Controls.Add(lblMesPost);
            Controls.Add(lblMesAnt);
            Controls.Add(lblPeriodo1);
            Controls.Add(lblPeriodo2);
            Controls.Add(btnSalir);
            Controls.Add(btnPdf);
            Controls.Add(dataGridMesPost);
            Controls.Add(dataGridMesAnt);
            Controls.Add(label1);
            Controls.Add(formsPlot1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReporteMovimientosFinanzas";
            Text = "FrmReporteMovimientosFinanzas";
            Load += FrmReporteMovimientosFinanzas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridMesAnt).EndInit();
            ((System.ComponentModel.ISupportInitialize)movimientoFinanzasDiarioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridMesPost).EndInit();
            ((System.ComponentModel.ISupportInitialize)movimientoFinanzasDiarioBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Label label1;
        private DataGridView dataGridMesAnt;
        private DataGridView dataGridMesPost;
        private Button btnPdf;
        private Button btnSalir;
        private Label lblPeriodo2;
        private Label lblPeriodo1;
        private Label lblMesAnt;
        private Label lblMesPost;
        private BindingSource movimientoFinanzasDiarioBindingSource;
        private BindingSource movimientoFinanzasDiarioBindingSource1;
        private Label lblFecha;
        private Label lblUsuario;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalIngresoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalEgresoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalMargenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn totalIngresoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn totalEgresoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn totalMargenDataGridViewTextBoxColumn1;
    }
}