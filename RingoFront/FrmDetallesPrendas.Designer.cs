namespace RingoFront
{
    partial class FrmDetallesPrendas
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
            txtCodigoDetalle = new TextBox();
            groupBoxDetalle = new GroupBox();
            txtCodigoPrenda = new TextBox();
            lblCodPrenda = new Label();
            cmbEstado = new ComboBox();
            bindingSourceEstados = new BindingSource(components);
            label8 = new Label();
            txtVenta = new TextBox();
            label6 = new Label();
            txtCosto = new TextBox();
            label5 = new Label();
            label4 = new Label();
            comboBoxTalle = new ComboBox();
            bindingSourceTalles = new BindingSource(components);
            comboBoxColor = new ComboBox();
            label3 = new Label();
            numUpDownDetallePrenda = new NumericUpDown();
            label2 = new Label();
            categoriasPrendasBindingSource = new BindingSource(components);
            telasBindingSource = new BindingSource(components);
            btnAgregarDetalleNuevo = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            btnQuitarDetalle = new Button();
            panel1 = new FlowLayoutPanel();
            lblRegistrarDetalles = new Label();
            groupBox2 = new GroupBox();
            groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceEstados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUpDownDetallePrenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriasPrendasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)telasBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(34, 34);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 0;
            label1.Text = "CÓDIGO";
            // 
            // txtCodigoDetalle
            // 
            txtCodigoDetalle.Enabled = false;
            txtCodigoDetalle.Font = new Font("Segoe UI", 11F);
            txtCodigoDetalle.Location = new Point(160, 32);
            txtCodigoDetalle.Name = "txtCodigoDetalle";
            txtCodigoDetalle.ReadOnly = true;
            txtCodigoDetalle.Size = new Size(133, 32);
            txtCodigoDetalle.TabIndex = 1;
            txtCodigoDetalle.KeyPress += NumericTextBox_KeyPress;
            // 
            // groupBoxDetalle
            // 
            groupBoxDetalle.BackColor = Color.Transparent;
            groupBoxDetalle.BackgroundImageLayout = ImageLayout.None;
            groupBoxDetalle.Controls.Add(txtCodigoPrenda);
            groupBoxDetalle.Controls.Add(lblCodPrenda);
            groupBoxDetalle.Controls.Add(cmbEstado);
            groupBoxDetalle.Controls.Add(label8);
            groupBoxDetalle.Controls.Add(txtVenta);
            groupBoxDetalle.Controls.Add(label6);
            groupBoxDetalle.Controls.Add(txtCosto);
            groupBoxDetalle.Controls.Add(label5);
            groupBoxDetalle.Controls.Add(label4);
            groupBoxDetalle.Controls.Add(comboBoxTalle);
            groupBoxDetalle.Controls.Add(comboBoxColor);
            groupBoxDetalle.Controls.Add(label3);
            groupBoxDetalle.Controls.Add(numUpDownDetallePrenda);
            groupBoxDetalle.Controls.Add(label2);
            groupBoxDetalle.Controls.Add(txtCodigoDetalle);
            groupBoxDetalle.Controls.Add(label1);
            groupBoxDetalle.Dock = DockStyle.Top;
            groupBoxDetalle.Location = new Point(33, 33);
            groupBoxDetalle.Name = "groupBoxDetalle";
            groupBoxDetalle.Size = new Size(1284, 127);
            groupBoxDetalle.TabIndex = 2;
            groupBoxDetalle.TabStop = false;
            groupBoxDetalle.Text = "Detalle de prenda 1";
            // 
            // txtCodigoPrenda
            // 
            txtCodigoPrenda.Enabled = false;
            txtCodigoPrenda.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtCodigoPrenda.Location = new Point(1097, 78);
            txtCodigoPrenda.Name = "txtCodigoPrenda";
            txtCodigoPrenda.Size = new Size(151, 32);
            txtCodigoPrenda.TabIndex = 15;
            txtCodigoPrenda.Visible = false;
            // 
            // lblCodPrenda
            // 
            lblCodPrenda.AutoSize = true;
            lblCodPrenda.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCodPrenda.Location = new Point(934, 81);
            lblCodPrenda.Name = "lblCodPrenda";
            lblCodPrenda.Size = new Size(137, 25);
            lblCodPrenda.TabIndex = 14;
            lblCodPrenda.Text = "COD. PRENDA";
            lblCodPrenda.Visible = false;
            // 
            // cmbEstado
            // 
            cmbEstado.DataSource = bindingSourceEstados;
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(1097, 26);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(151, 33);
            cmbEstado.TabIndex = 13;
            cmbEstado.ValueMember = "IdEstado";
            // 
            // bindingSourceEstados
            // 
            bindingSourceEstados.DataSource = typeof(RingoEntidades.Estados);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label8.Location = new Point(991, 31);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 12;
            label8.Text = "ESTADO";
            // 
            // txtVenta
            // 
            txtVenta.Font = new Font("Segoe UI", 11F);
            txtVenta.Location = new Point(778, 78);
            txtVenta.Name = "txtVenta";
            txtVenta.Size = new Size(133, 32);
            txtVenta.TabIndex = 11;
            txtVenta.KeyPress += NumericTextBox_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(663, 82);
            label6.Name = "label6";
            label6.Size = new Size(94, 25);
            label6.TabIndex = 10;
            label6.Text = "VENTA  $";
            // 
            // txtCosto
            // 
            txtCosto.Font = new Font("Segoe UI", 11F);
            txtCosto.Location = new Point(465, 78);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(132, 32);
            txtCosto.TabIndex = 9;
            txtCosto.KeyPress += NumericTextBox_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.Location = new Point(345, 79);
            label5.Name = "label5";
            label5.Size = new Size(94, 25);
            label5.TabIndex = 8;
            label5.Text = "COSTO  $";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(664, 34);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 7;
            label4.Text = "TALLE";
            // 
            // comboBoxTalle
            // 
            comboBoxTalle.DataSource = bindingSourceTalles;
            comboBoxTalle.DisplayMember = "DescripcionTalle";
            comboBoxTalle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTalle.Font = new Font("Segoe UI", 11F);
            comboBoxTalle.FormattingEnabled = true;
            comboBoxTalle.Location = new Point(778, 28);
            comboBoxTalle.Name = "comboBoxTalle";
            comboBoxTalle.Size = new Size(134, 33);
            comboBoxTalle.TabIndex = 6;
            comboBoxTalle.ValueMember = "IdTalle";
            // 
            // bindingSourceTalles
            // 
            bindingSourceTalles.DataSource = typeof(RingoEntidades.Talles);
            // 
            // comboBoxColor
            // 
            comboBoxColor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColor.Font = new Font("Segoe UI", 11F);
            comboBoxColor.FormattingEnabled = true;
            comboBoxColor.Items.AddRange(new object[] { "Amarillo", "Azul Claro", "Azul Oscuro", "Beige", "Blanco", "Bordó", "Café", "Celeste", "Gris plata", "Gris plomo", "Marrón", "Negro", "Oliva", "Salmón", "Varios", "Verde", "Verde Claro", "Violeta" });
            comboBoxColor.Location = new Point(465, 29);
            comboBoxColor.Name = "comboBoxColor";
            comboBoxColor.Size = new Size(132, 33);
            comboBoxColor.Sorted = true;
            comboBoxColor.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(346, 33);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 4;
            label3.Text = "COLOR";
            // 
            // numUpDownDetallePrenda
            // 
            numUpDownDetallePrenda.Font = new Font("Segoe UI", 11F);
            numUpDownDetallePrenda.Location = new Point(160, 78);
            numUpDownDetallePrenda.Name = "numUpDownDetallePrenda";
            numUpDownDetallePrenda.Size = new Size(133, 32);
            numUpDownDetallePrenda.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(33, 77);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 2;
            label2.Text = "CANTIDAD";
            // 
            // categoriasPrendasBindingSource
            // 
            categoriasPrendasBindingSource.DataSource = typeof(RingoEntidades.CategoriasPrendas);
            // 
            // telasBindingSource
            // 
            telasBindingSource.DataSource = typeof(RingoEntidades.Telas);
            // 
            // btnAgregarDetalleNuevo
            // 
            btnAgregarDetalleNuevo.BackColor = SystemColors.ActiveCaption;
            btnAgregarDetalleNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregarDetalleNuevo.Location = new Point(64, 20);
            btnAgregarDetalleNuevo.Name = "btnAgregarDetalleNuevo";
            btnAgregarDetalleNuevo.Size = new Size(60, 36);
            btnAgregarDetalleNuevo.TabIndex = 3;
            btnAgregarDetalleNuevo.Text = "+";
            btnAgregarDetalleNuevo.UseVisualStyleBackColor = false;
            btnAgregarDetalleNuevo.Click += btnAgregarDetalleNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.Location = new Point(376, 20);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 43);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Añadir";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancelar.Location = new Point(1035, 20);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 43);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnQuitarDetalle);
            groupBox1.Controls.Add(btnAgregarDetalleNuevo);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(0, 763);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1329, 140);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // btnQuitarDetalle
            // 
            btnQuitarDetalle.BackColor = SystemColors.ActiveCaption;
            btnQuitarDetalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQuitarDetalle.Location = new Point(160, 20);
            btnQuitarDetalle.Name = "btnQuitarDetalle";
            btnQuitarDetalle.Size = new Size(60, 36);
            btnQuitarDetalle.TabIndex = 5;
            btnQuitarDetalle.Text = "-";
            btnQuitarDetalle.UseVisualStyleBackColor = false;
            btnQuitarDetalle.Click += btnQuitarDetalle_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(groupBoxDetalle);
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(30);
            panel1.Size = new Size(1389, 639);
            panel1.TabIndex = 6;
            // 
            // lblRegistrarDetalles
            // 
            lblRegistrarDetalles.AutoSize = true;
            lblRegistrarDetalles.BackColor = Color.Transparent;
            lblRegistrarDetalles.Location = new Point(33, 43);
            lblRegistrarDetalles.Name = "lblRegistrarDetalles";
            lblRegistrarDetalles.Size = new Size(165, 20);
            lblRegistrarDetalles.TabIndex = 7;
            lblRegistrarDetalles.Text = "REGISTRAR DETALLES";
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(lblRegistrarDetalles);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1329, 86);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            // 
            // FrmDetallesPrendas
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 903);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FrmDetallesPrendas";
            Text = "Registrar Detalles";
            Load += FrmDetallesPrendas_Load;
            groupBoxDetalle.ResumeLayout(false);
            groupBoxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceEstados).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUpDownDetallePrenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoriasPrendasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)telasBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label label1;
        internal TextBox txtCodigoDetalle;
        internal GroupBox groupBoxDetalle;
        internal NumericUpDown numUpDownDetallePrenda;
        internal Label label2;
        internal Label label3;
        internal ComboBox comboBoxColor;
        internal ComboBox comboBoxTalle;
        internal Label label4;
        internal TextBox txtVenta;
        internal Label label6;
        internal TextBox txtCosto;
        internal Label label5;
        internal Button btnAgregarDetalleNuevo;
        internal Button btnGuardar;
        internal Button btnCancelar;
        internal BindingSource bindingSourceTalles;
        internal BindingSource telasBindingSource;
        internal BindingSource categoriasPrendasBindingSource;
        private GroupBox groupBox1;
        private FlowLayoutPanel panel1;
        internal Button btnQuitarDetalle;
        internal Label lblRegistrarDetalles;
        private BindingSource bindingSourceEstados;
        internal ComboBox cmbEstado;
        private Label label8;
        private GroupBox groupBox2;
        internal TextBox txtCodigoPrenda;
        internal Label lblCodPrenda;
    }
}