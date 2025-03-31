namespace RingoFront
{
    partial class FrmLoginUsuario
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoginUsuario));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnIngresar = new Button();
            txtContrasenia = new TextBox();
            txtUsuario = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Logo_Ringo_11;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnIngresar);
            panel1.Controls.Add(txtContrasenia);
            panel1.Controls.Add(txtUsuario);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1416, 786);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.icono_contraseña;
            pictureBox2.Location = new Point(489, 164);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 40);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.icono_usuario1;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(489, 86);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 40);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label1.Location = new Point(489, 9);
            label1.Name = "label1";
            label1.Size = new Size(314, 23);
            label1.TabIndex = 9;
            label1.Text = "Ingrese Usuario y Contraseña...";
            // 
            // btnIngresar
            // 
            btnIngresar.Anchor = AnchorStyles.None;
            btnIngresar.BackColor = Color.MistyRose;
            btnIngresar.FlatAppearance.BorderColor = Color.Plum;
            btnIngresar.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            btnIngresar.ForeColor = SystemColors.ActiveCaptionText;
            btnIngresar.Location = new Point(551, 249);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(262, 50);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Anchor = AnchorStyles.None;
            txtContrasenia.Font = new Font("Century Gothic", 12F);
            txtContrasenia.Location = new Point(551, 170);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PasswordChar = '*';
            txtContrasenia.PlaceholderText = " Contraseña...";
            txtContrasenia.Size = new Size(262, 32);
            txtContrasenia.TabIndex = 7;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.None;
            txtUsuario.Font = new Font("Century Gothic", 12F);
            txtUsuario.Location = new Point(551, 92);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = " Usuario...";
            txtUsuario.Size = new Size(262, 32);
            txtUsuario.TabIndex = 6;
            // 
            // FrmLoginUsuario
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Thistle;
            BackgroundImage = Properties.Resources.Logo_Ringo_11;
            ClientSize = new Size(1416, 786);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Font = new Font("Century Gothic", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLoginUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " LOGIN";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnIngresar;
        private TextBox txtContrasenia;
        internal TextBox txtUsuario;
    }
}