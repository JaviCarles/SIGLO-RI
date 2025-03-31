namespace RingoFront
{
    partial class FrmReportesVentas
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
            groupBox1 = new GroupBox();
            labelTitulo = new Label();
            btnSalir = new Button();
            groupBoxReporte = new GroupBox();
            groupBoxCantidad = new GroupBox();
            comboBoxCantidad = new ComboBox();
            lblCantidad = new Label();
            groupBoxDesdeHasta = new GroupBox();
            dateTimePickerHasta = new DateTimePicker();
            lblHasta = new Label();
            lblDesde = new Label();
            dateTimePickerDesde = new DateTimePicker();
            groupBoxAñosYMeses = new GroupBox();
            groupBoxPosterior = new GroupBox();
            comboBoxAñoPosterior = new ComboBox();
            comboBoxMesPosterior = new ComboBox();
            groupBoxAnterior = new GroupBox();
            comboBoxAñoAnterior = new ComboBox();
            comboBoxMesAnterior = new ComboBox();
            groupBoxAñosComparar = new GroupBox();
            comboAño2 = new ComboBox();
            comboAño1 = new ComboBox();
            label1 = new Label();
            labelSeleccionarNombre = new Label();
            comboBoxTipoDeReporte = new ComboBox();
            groupBoxOrden = new GroupBox();
            radioButtonMenorAMayor = new RadioButton();
            radioButtonMayorAMenor = new RadioButton();
            btnVer = new Button();
            groupBox1.SuspendLayout();
            groupBoxReporte.SuspendLayout();
            groupBoxCantidad.SuspendLayout();
            groupBoxDesdeHasta.SuspendLayout();
            groupBoxAñosYMeses.SuspendLayout();
            groupBoxPosterior.SuspendLayout();
            groupBoxAnterior.SuspendLayout();
            groupBoxAñosComparar.SuspendLayout();
            groupBoxOrden.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelTitulo);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1347, 111);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Location = new Point(113, 54);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(157, 20);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "REPORTES DE VENTAS";
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSalir.Location = new Point(634, 812);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 29);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // groupBoxReporte
            // 
            groupBoxReporte.Controls.Add(groupBoxCantidad);
            groupBoxReporte.Controls.Add(groupBoxDesdeHasta);
            groupBoxReporte.Controls.Add(groupBoxAñosYMeses);
            groupBoxReporte.Controls.Add(groupBoxAñosComparar);
            groupBoxReporte.Controls.Add(labelSeleccionarNombre);
            groupBoxReporte.Controls.Add(comboBoxTipoDeReporte);
            groupBoxReporte.Controls.Add(groupBoxOrden);
            groupBoxReporte.Controls.Add(btnVer);
            groupBoxReporte.Dock = DockStyle.Top;
            groupBoxReporte.Location = new Point(0, 111);
            groupBoxReporte.Name = "groupBoxReporte";
            groupBoxReporte.Size = new Size(1347, 673);
            groupBoxReporte.TabIndex = 8;
            groupBoxReporte.TabStop = false;
            // 
            // groupBoxCantidad
            // 
            groupBoxCantidad.Controls.Add(comboBoxCantidad);
            groupBoxCantidad.Controls.Add(lblCantidad);
            groupBoxCantidad.Location = new Point(1057, 174);
            groupBoxCantidad.Name = "groupBoxCantidad";
            groupBoxCantidad.Size = new Size(229, 84);
            groupBoxCantidad.TabIndex = 24;
            groupBoxCantidad.TabStop = false;
            // 
            // comboBoxCantidad
            // 
            comboBoxCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxCantidad.DisplayMember = "0";
            comboBoxCantidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCantidad.FormattingEnabled = true;
            comboBoxCantidad.Items.AddRange(new object[] { "10", "30", "50", "100" });
            comboBoxCantidad.Location = new Point(17, 38);
            comboBoxCantidad.Name = "comboBoxCantidad";
            comboBoxCantidad.Size = new Size(151, 28);
            comboBoxCantidad.TabIndex = 6;
            // 
            // lblCantidad
            // 
            lblCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(17, 11);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(83, 20);
            lblCantidad.TabIndex = 7;
            lblCantidad.Text = "CANTIDAD";
            // 
            // groupBoxDesdeHasta
            // 
            groupBoxDesdeHasta.Controls.Add(dateTimePickerHasta);
            groupBoxDesdeHasta.Controls.Add(lblHasta);
            groupBoxDesdeHasta.Controls.Add(lblDesde);
            groupBoxDesdeHasta.Controls.Add(dateTimePickerDesde);
            groupBoxDesdeHasta.Location = new Point(104, 160);
            groupBoxDesdeHasta.Name = "groupBoxDesdeHasta";
            groupBoxDesdeHasta.Size = new Size(863, 99);
            groupBoxDesdeHasta.TabIndex = 23;
            groupBoxDesdeHasta.TabStop = false;
            // 
            // dateTimePickerHasta
            // 
            dateTimePickerHasta.Anchor = AnchorStyles.Top;
            dateTimePickerHasta.Location = new Point(496, 50);
            dateTimePickerHasta.Name = "dateTimePickerHasta";
            dateTimePickerHasta.Size = new Size(357, 27);
            dateTimePickerHasta.TabIndex = 4;
            dateTimePickerHasta.ValueChanged += dateTimePickerHasta_ValueChanged;
            // 
            // lblHasta
            // 
            lblHasta.Anchor = AnchorStyles.Top;
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(496, 27);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(55, 20);
            lblHasta.TabIndex = 5;
            lblHasta.Text = "HASTA";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(14, 26);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(55, 20);
            lblDesde.TabIndex = 3;
            lblDesde.Text = "DESDE";
            // 
            // dateTimePickerDesde
            // 
            dateTimePickerDesde.Location = new Point(9, 51);
            dateTimePickerDesde.Name = "dateTimePickerDesde";
            dateTimePickerDesde.Size = new Size(357, 27);
            dateTimePickerDesde.TabIndex = 2;
            dateTimePickerDesde.ValueChanged += dateTimePickerDesde_ValueChanged;
            // 
            // groupBoxAñosYMeses
            // 
            groupBoxAñosYMeses.Controls.Add(groupBoxPosterior);
            groupBoxAñosYMeses.Controls.Add(groupBoxAnterior);
            groupBoxAñosYMeses.Location = new Point(69, 450);
            groupBoxAñosYMeses.Name = "groupBoxAñosYMeses";
            groupBoxAñosYMeses.Size = new Size(1060, 152);
            groupBoxAñosYMeses.TabIndex = 22;
            groupBoxAñosYMeses.TabStop = false;
            // 
            // groupBoxPosterior
            // 
            groupBoxPosterior.Controls.Add(comboBoxAñoPosterior);
            groupBoxPosterior.Controls.Add(comboBoxMesPosterior);
            groupBoxPosterior.ForeColor = Color.SeaGreen;
            groupBoxPosterior.Location = new Point(506, 26);
            groupBoxPosterior.Name = "groupBoxPosterior";
            groupBoxPosterior.Size = new Size(478, 103);
            groupBoxPosterior.TabIndex = 23;
            groupBoxPosterior.TabStop = false;
            groupBoxPosterior.Text = "    SELECCIONE MES Y AÑO POSTERIOR";
            // 
            // comboBoxAñoPosterior
            // 
            comboBoxAñoPosterior.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAñoPosterior.FormattingEnabled = true;
            comboBoxAñoPosterior.Location = new Point(257, 52);
            comboBoxAñoPosterior.Name = "comboBoxAñoPosterior";
            comboBoxAñoPosterior.Size = new Size(125, 28);
            comboBoxAñoPosterior.TabIndex = 1;
            comboBoxAñoPosterior.SelectedIndexChanged += comboBoxAñoPosterior_SelectedIndexChanged;
            // 
            // comboBoxMesPosterior
            // 
            comboBoxMesPosterior.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMesPosterior.FormattingEnabled = true;
            comboBoxMesPosterior.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            comboBoxMesPosterior.Location = new Point(25, 52);
            comboBoxMesPosterior.Name = "comboBoxMesPosterior";
            comboBoxMesPosterior.Size = new Size(125, 28);
            comboBoxMesPosterior.TabIndex = 0;
            comboBoxMesPosterior.SelectedIndexChanged += comboBoxMesPosterior_SelectedIndexChanged;
            // 
            // groupBoxAnterior
            // 
            groupBoxAnterior.Controls.Add(comboBoxAñoAnterior);
            groupBoxAnterior.Controls.Add(comboBoxMesAnterior);
            groupBoxAnterior.ForeColor = Color.SeaGreen;
            groupBoxAnterior.Location = new Point(23, 26);
            groupBoxAnterior.Name = "groupBoxAnterior";
            groupBoxAnterior.Size = new Size(457, 103);
            groupBoxAnterior.TabIndex = 22;
            groupBoxAnterior.TabStop = false;
            groupBoxAnterior.Text = "    SELECCIONE MES Y AÑO ANTERIOR";
            // 
            // comboBoxAñoAnterior
            // 
            comboBoxAñoAnterior.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAñoAnterior.FormattingEnabled = true;
            comboBoxAñoAnterior.Location = new Point(253, 52);
            comboBoxAñoAnterior.Name = "comboBoxAñoAnterior";
            comboBoxAñoAnterior.Size = new Size(125, 28);
            comboBoxAñoAnterior.TabIndex = 1;
            comboBoxAñoAnterior.SelectedIndexChanged += comboBoxAñoAnterior_SelectedIndexChanged;
            // 
            // comboBoxMesAnterior
            // 
            comboBoxMesAnterior.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMesAnterior.FormattingEnabled = true;
            comboBoxMesAnterior.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            comboBoxMesAnterior.Location = new Point(21, 52);
            comboBoxMesAnterior.Name = "comboBoxMesAnterior";
            comboBoxMesAnterior.Size = new Size(124, 28);
            comboBoxMesAnterior.TabIndex = 0;
            comboBoxMesAnterior.SelectedIndexChanged += comboBoxMesAnterior_SelectedIndexChanged;
            // 
            // groupBoxAñosComparar
            // 
            groupBoxAñosComparar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxAñosComparar.Controls.Add(comboAño2);
            groupBoxAñosComparar.Controls.Add(comboAño1);
            groupBoxAñosComparar.Controls.Add(label1);
            groupBoxAñosComparar.Location = new Point(783, 29);
            groupBoxAñosComparar.Name = "groupBoxAñosComparar";
            groupBoxAñosComparar.Size = new Size(552, 125);
            groupBoxAñosComparar.TabIndex = 19;
            groupBoxAñosComparar.TabStop = false;
            // 
            // comboAño2
            // 
            comboAño2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboAño2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboAño2.FormattingEnabled = true;
            comboAño2.Location = new Point(291, 55);
            comboAño2.Name = "comboAño2";
            comboAño2.Size = new Size(151, 28);
            comboAño2.TabIndex = 18;
            comboAño2.SelectedIndexChanged += comboAño2_SelectedIndexChanged;
            // 
            // comboAño1
            // 
            comboAño1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboAño1.FormattingEnabled = true;
            comboAño1.Location = new Point(80, 55);
            comboAño1.Name = "comboAño1";
            comboAño1.Size = new Size(147, 28);
            comboAño1.TabIndex = 16;
            comboAño1.SelectedIndexChanged += comboAño1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(178, 23);
            label1.Name = "label1";
            label1.Size = new Size(329, 20);
            label1.TabIndex = 17;
            label1.Text = "SELECCIONE LOS AÑOS QUE DESEA COMPARAR";
            // 
            // labelSeleccionarNombre
            // 
            labelSeleccionarNombre.AutoSize = true;
            labelSeleccionarNombre.Location = new Point(113, 51);
            labelSeleccionarNombre.Name = "labelSeleccionarNombre";
            labelSeleccionarNombre.Size = new Size(201, 20);
            labelSeleccionarNombre.TabIndex = 15;
            labelSeleccionarNombre.Text = "Seleccione el tipo de reporte";
            // 
            // comboBoxTipoDeReporte
            // 
            comboBoxTipoDeReporte.BackColor = SystemColors.Window;
            comboBoxTipoDeReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoDeReporte.FormattingEnabled = true;
            comboBoxTipoDeReporte.Items.AddRange(new object[] { "REPORTE DE VENTAS POR CLIENTE", "REPORTE DE VENTAS ANUAL COMPARATIVO", "REPORTE DE VENTAS POR PROVEEDOR", "REPORTE DE VENTAS POR CATEGORÍA", "REPORTE COMPARATIVO DE EGRESOS E INGRESOS BRUTOS" });
            comboBoxTipoDeReporte.Location = new Point(113, 83);
            comboBoxTipoDeReporte.Name = "comboBoxTipoDeReporte";
            comboBoxTipoDeReporte.Size = new Size(664, 28);
            comboBoxTipoDeReporte.TabIndex = 14;
            comboBoxTipoDeReporte.SelectedIndexChanged += comboBoxTipoDeReporte_SelectedIndexChanged;
            // 
            // groupBoxOrden
            // 
            groupBoxOrden.Controls.Add(radioButtonMenorAMayor);
            groupBoxOrden.Controls.Add(radioButtonMayorAMenor);
            groupBoxOrden.Location = new Point(92, 334);
            groupBoxOrden.Name = "groupBoxOrden";
            groupBoxOrden.Size = new Size(875, 69);
            groupBoxOrden.TabIndex = 13;
            groupBoxOrden.TabStop = false;
            // 
            // radioButtonMenorAMayor
            // 
            radioButtonMenorAMayor.Anchor = AnchorStyles.Top;
            radioButtonMenorAMayor.AutoSize = true;
            radioButtonMenorAMayor.Location = new Point(508, 30);
            radioButtonMenorAMayor.Name = "radioButtonMenorAMayor";
            radioButtonMenorAMayor.Size = new Size(245, 24);
            radioButtonMenorAMayor.TabIndex = 12;
            radioButtonMenorAMayor.Text = "ORDENAR DE MENOR A MAYOR";
            radioButtonMenorAMayor.UseVisualStyleBackColor = true;
            // 
            // radioButtonMayorAMenor
            // 
            radioButtonMayorAMenor.AutoSize = true;
            radioButtonMayorAMenor.Checked = true;
            radioButtonMayorAMenor.Location = new Point(21, 30);
            radioButtonMayorAMenor.Name = "radioButtonMayorAMenor";
            radioButtonMayorAMenor.Size = new Size(245, 24);
            radioButtonMayorAMenor.TabIndex = 11;
            radioButtonMayorAMenor.TabStop = true;
            radioButtonMayorAMenor.Text = "ORDENAR DE MAYOR A MENOR";
            radioButtonMayorAMenor.UseVisualStyleBackColor = true;
            // 
            // btnVer
            // 
            btnVer.Location = new Point(1057, 359);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(229, 29);
            btnVer.TabIndex = 10;
            btnVer.Text = "VER REPORTE";
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += btnVer_Click;
            // 
            // FrmReportesVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1347, 886);
            Controls.Add(btnSalir);
            Controls.Add(groupBoxReporte);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReportesVentas";
            Text = "FrmReportesVentas";
            Load += FrmReportesVentas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxReporte.ResumeLayout(false);
            groupBoxReporte.PerformLayout();
            groupBoxCantidad.ResumeLayout(false);
            groupBoxCantidad.PerformLayout();
            groupBoxDesdeHasta.ResumeLayout(false);
            groupBoxDesdeHasta.PerformLayout();
            groupBoxAñosYMeses.ResumeLayout(false);
            groupBoxPosterior.ResumeLayout(false);
            groupBoxAnterior.ResumeLayout(false);
            groupBoxAñosComparar.ResumeLayout(false);
            groupBoxAñosComparar.PerformLayout();
            groupBoxOrden.ResumeLayout(false);
            groupBoxOrden.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelTitulo;
        private Label labelReporteSeleccionado;
        private Button btnSalir;
        private GroupBox groupBoxReporte;
        private GroupBox groupBoxAñosYMeses;
        private GroupBox groupBoxPosterior;
        private ComboBox comboBoxAñoPosterior;
        private ComboBox comboBoxMesPosterior;
        private GroupBox groupBoxAnterior;
        private ComboBox comboBoxAñoAnterior;
        private ComboBox comboBoxMesAnterior;
        private GroupBox groupBoxAñosComparar;
        private ComboBox comboAño2;
        private ComboBox comboAño1;
        private Label label1;
        private Label labelSeleccionarNombre;
        private ComboBox comboBoxTipoDeReporte;
        private GroupBox groupBoxOrden;
        private RadioButton radioButtonMenorAMayor;
        private RadioButton radioButtonMayorAMenor;
        private Button btnVer;
        private DateTimePicker dateTimePickerDesde;
        private Label lblCantidad;
        private Label lblDesde;
        private ComboBox comboBoxCantidad;
        private DateTimePicker dateTimePickerHasta;
        private Label lblHasta;
        private GroupBox groupBoxDesdeHasta;
        private GroupBox groupBoxCantidad;
    }
}