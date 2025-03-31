namespace RingoFront
{
    partial class frmAnomalia
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
            label9 = new Label();
            txtCodigo = new TextBox();
            label1 = new Label();
            numCantidad = new NumericUpDown();
            label2 = new Label();
            cmbEstado = new ComboBox();
            bindingEstados = new BindingSource(components);
            label8 = new Label();
            lblCodPrenda = new Label();
            txtFalla = new TextBox();
            label3 = new Label();
            txtDescripcion = new TextBox();
            groupBox1 = new GroupBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingEstados).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label9.Location = new Point(44, 52);
            label9.Name = "label9";
            label9.Size = new Size(223, 23);
            label9.TabIndex = 21;
            label9.Text = "ANOMALIAS PRENDAS";
            // 
            // txtCodigo
            // 
            txtCodigo.Enabled = false;
            txtCodigo.Font = new Font("Segoe UI", 11F);
            txtCodigo.Location = new Point(219, 146);
            txtCodigo.Margin = new Padding(3, 4, 3, 4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(159, 32);
            txtCodigo.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(46, 150);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 23;
            label1.Text = "COD. PRENDA";
            // 
            // numCantidad
            // 
            numCantidad.Font = new Font("Segoe UI", 11F);
            numCantidad.Location = new Point(218, 330);
            numCantidad.Margin = new Padding(3, 4, 3, 4);
            numCantidad.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(160, 32);
            numCantidad.TabIndex = 25;
            numCantidad.ValueChanged += numCantidad_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(73, 332);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 24;
            label2.Text = "CANTIDAD";
            // 
            // cmbEstado
            // 
            cmbEstado.DataSource = bindingEstados;
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(219, 240);
            cmbEstado.Margin = new Padding(3, 4, 3, 4);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(159, 33);
            cmbEstado.TabIndex = 27;
            cmbEstado.ValueMember = "IdEstado";
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
            // 
            // bindingEstados
            // 
            bindingEstados.DataSource = typeof(RingoEntidades.Estados);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label8.Location = new Point(99, 243);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 26;
            label8.Text = "ESTADO";
            // 
            // lblCodPrenda
            // 
            lblCodPrenda.AutoSize = true;
            lblCodPrenda.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCodPrenda.Location = new Point(640, 237);
            lblCodPrenda.Name = "lblCodPrenda";
            lblCodPrenda.Size = new Size(67, 25);
            lblCodPrenda.TabIndex = 28;
            lblCodPrenda.Text = "FALLA";
            // 
            // txtFalla
            // 
            txtFalla.Font = new Font("Segoe UI", 12F);
            txtFalla.Location = new Point(740, 237);
            txtFalla.Margin = new Padding(5, 4, 5, 4);
            txtFalla.Multiline = true;
            txtFalla.Name = "txtFalla";
            txtFalla.Size = new Size(350, 103);
            txtFalla.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(575, 146);
            label3.Name = "label3";
            label3.Size = new Size(136, 25);
            label3.TabIndex = 31;
            label3.Text = "DESCRIPCION";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Enabled = false;
            txtDescripcion.Font = new Font("Segoe UI", 11F);
            txtDescripcion.Location = new Point(740, 143);
            txtDescripcion.Margin = new Padding(3, 4, 3, 4);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(350, 32);
            txtDescripcion.TabIndex = 30;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(0, 667);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1371, 127);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancelar.Location = new Point(941, 55);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(149, 45);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.Location = new Point(245, 55);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(149, 45);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "CONFIRMAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // frmAnomalia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 794);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(txtDescripcion);
            Controls.Add(txtFalla);
            Controls.Add(lblCodPrenda);
            Controls.Add(cmbEstado);
            Controls.Add(label8);
            Controls.Add(numCantidad);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCodigo);
            Controls.Add(label9);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmAnomalia";
            Text = "frmAnomalia";
            Load += frmAnomalia_Load;
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingEstados).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        internal TextBox txtCodigo;
        internal Label label1;
        internal NumericUpDown numCantidad;
        internal Label label2;
        internal ComboBox cmbEstado;
        private Label label8;
        internal Label lblCodPrenda;
        private TextBox txtFalla;
        internal Label label3;
        internal TextBox txtDescripcion;
        private GroupBox groupBox1;
        internal Button btnCancelar;
        internal Button btnGuardar;
        private BindingSource bindingEstados;
    }
}