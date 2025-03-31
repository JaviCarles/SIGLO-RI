namespace RingoFront
{
    partial class dialogFondoCaja
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
            numMonto = new NumericUpDown();
            lblMonto = new Label();
            label1 = new Label();
            label2 = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            label3 = new Label();
            label4 = new Label();
            txtFondo = new TextBox();
            comboBoxOperacion = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
            SuspendLayout();
            // 
            // numMonto
            // 
            numMonto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numMonto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            numMonto.Location = new Point(309, 267);
            numMonto.Margin = new Padding(3, 4, 3, 4);
            numMonto.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numMonto.Name = "numMonto";
            numMonto.Size = new Size(187, 34);
            numMonto.TabIndex = 17;
            numMonto.ValueChanged += numMonto_ValueChanged;
            // 
            // lblMonto
            // 
            lblMonto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMonto.AutoSize = true;
            lblMonto.BackColor = Color.Transparent;
            lblMonto.Font = new Font("Segoe UI", 11F);
            lblMonto.Location = new Point(360, 226);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(80, 25);
            lblMonto.TabIndex = 16;
            lblMonto.Text = "MONTO";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(211, 15);
            label1.Name = "label1";
            label1.Size = new Size(384, 25);
            label1.TabIndex = 18;
            label1.Text = "DEBE DECLARAR EL FONDO INICIAL DEL DIA";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(177, 55);
            label2.Name = "label2";
            label2.Size = new Size(474, 25);
            label2.TabIndex = 19;
            label2.Text = "¿CUANTO DINERO AGREGARÁ A LA CAJA EN EFCTIVO?";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnConfirmar.Location = new Point(75, 403);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(201, 29);
            btnConfirmar.TabIndex = 20;
            btnConfirmar.Text = "CONFIRMAR";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancelar.Location = new Point(555, 403);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(204, 29);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(127, 105);
            label3.Name = "label3";
            label3.Size = new Size(149, 25);
            label3.TabIndex = 22;
            label3.Text = "FONDO ACTUAL";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(555, 105);
            label4.Name = "label4";
            label4.Size = new Size(115, 25);
            label4.TabIndex = 23;
            label4.Text = "OPERACIÓN";
            // 
            // txtFondo
            // 
            txtFondo.Enabled = false;
            txtFondo.Font = new Font("Segoe UI", 11F);
            txtFondo.Location = new Point(127, 140);
            txtFondo.Name = "txtFondo";
            txtFondo.Size = new Size(145, 32);
            txtFondo.TabIndex = 24;
            // 
            // comboBoxOperacion
            // 
            comboBoxOperacion.Anchor = AnchorStyles.Top;
            comboBoxOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperacion.Font = new Font("Segoe UI", 11F);
            comboBoxOperacion.FormattingEnabled = true;
            comboBoxOperacion.Items.AddRange(new object[] { "Ingreso", "Retiro" });
            comboBoxOperacion.Location = new Point(555, 139);
            comboBoxOperacion.Name = "comboBoxOperacion";
            comboBoxOperacion.Size = new Size(147, 33);
            comboBoxOperacion.TabIndex = 25;
            comboBoxOperacion.TextChanged += comboBoxOperacion_TextChanged;
            // 
            // dialogFondoCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 468);
            Controls.Add(comboBoxOperacion);
            Controls.Add(txtFondo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numMonto);
            Controls.Add(lblMonto);
            Margin = new Padding(3, 4, 3, 4);
            Name = "dialogFondoCaja";
            Text = "Fondo de Cajas";
            Load += dialogFondoCaja_Load;
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numMonto;
        private Label lblMonto;
        private Label label1;
        private Label label2;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label label3;
        private Label label4;
        private TextBox txtFondo;
        private ComboBox comboBoxOperacion;
    }
}