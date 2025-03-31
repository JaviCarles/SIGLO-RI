using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using RingoNegocio;
using System.Runtime.CompilerServices;
using System.Drawing.Imaging;
using iText.Layout;
using iText.Signatures;

namespace RingoFront
{

    public static class DiseñoUI
    {
        public enum TemaAplicacion
        {
            Menta,
            Ringo,
            Toro,
        }

        public static Image imagenFondo;// = Properties.Resources.aesthetic_clouds1;
        public static Image imagenFondoPanelUsuario = Properties.Resources.marron_Fondo;
        public static Color colorForm;// = Color.FromArgb(255, 200, 240);
        public static Color colorBoton;// = Color.FromArgb(215, 144, 193);
        public static Color colorFontBoton;
        public static Color colorLabel;//= colorBoton;
        public static Color colorGroupBox;// = Color.Transparent; //Color.FromArgb(232, 218, 239);
        public static Color colorTextoGroupBox;// = colorBoton;
        public static Color colorMenuLateral;// = Color.FromArgb(250, 219, 216);
        public static Font  fontGeneral;// = new Font("Century Gothic", 11f, FontStyle.Bold);
        public static Font  fontBoton;// = new Font("Century Gothic", 9f, FontStyle.Bold);
        public static Color colorCheckBox; 

        // este método toma el valor de string que quedó guardado de la ultima sesión 
        public static void temaSeleccionado ( string temaGuardado )
        {
            TemaAplicacion temaEnum;

            try
            {
                temaEnum = (TemaAplicacion)Enum.Parse(typeof(TemaAplicacion),temaGuardado, true);
                // El tercer argumento (true) indica que la conversión no distingue entre mayúsculas y minúsculas

                // Ahora puedes aplicar el tema a tus controles según la selección
                switch (temaEnum)
                {
                    case TemaAplicacion.Toro:
                        
                        imagenFondo = Properties.Resources.beige_claro;
                        imagenFondoPanelUsuario = Properties.Resources.beige_claro;
                        colorForm = Color.FromArgb(218, 165, 32);
                        colorMenuLateral = Color.FromArgb(236, 222, 196);
                        colorBoton = Color.FromArgb(195, 170, 95/*215, 185, 106*/);
                        colorFontBoton = Color.White;
                        colorLabel = Color.FromArgb(176, 137, 74);// colorMenuLateral;
                        colorGroupBox = Color.Transparent; //Color.FromArgb(232, 218, 239);
                        colorTextoGroupBox = colorLabel; //Color.FromArgb(223, 200, 163);// colorMenuLateral;
                        colorCheckBox = colorLabel;
                        fontGeneral = new Font("BookBookman Old Style", 11f, FontStyle.Bold);
                        fontBoton = new Font("BookBookman Old Style", 9f, FontStyle.Bold);

                        break;
                    case TemaAplicacion.Menta:
                       
                        imagenFondo = Properties.Resources.verde_claro;
                        imagenFondoPanelUsuario = Properties.Resources.verde_claro;
                        colorForm = Color.FromArgb(109, 165, 108);
                        colorMenuLateral = Color.FromArgb(228, 245, 208);
                        colorBoton = Color.FromArgb(160,220,160/*145, 215, 144*/);
                        colorFontBoton = Color.White;
                        colorLabel = Color.FromArgb(64, 108, 63);
                        colorGroupBox = Color.Transparent; //Color.FromArgb(232, 218, 239);
                        colorTextoGroupBox = Color.FromArgb(64, 108, 63);
                        colorTextoGroupBox = colorLabel;
                        colorCheckBox = colorLabel;
                        //colorMenuLateral = Color.FromArgb(145, 215, 144);

                        fontGeneral = new Font("BookBookman Old Style", 11f, FontStyle.Bold);
                        fontBoton = new Font("BookBookman Old Style"/*"High Tower Text"*/, 9f, FontStyle.Bold);
                        break;
                    case TemaAplicacion.Ringo:
                        // Aplica el tema ringo
                        imagenFondo = Properties.Resources.rosa_claro;
                        imagenFondoPanelUsuario = Properties.Resources.rosa_claro;
                        colorForm = Color.FromArgb(255, 200, 240);
                        colorBoton = Color.FromArgb(/*180, 110, 140*/218, 157, 210);
                        colorFontBoton = Color.White;
                        colorLabel =  Color.FromArgb(/*205, 134, 183*/185,104,153);
                        colorGroupBox = Color.Transparent; //Color.FromArgb(232, 218, 239);
                        colorTextoGroupBox = colorLabel;
                        colorCheckBox = colorLabel;
                        colorMenuLateral = Color.FromArgb(249, 234, 249);
                        fontGeneral = new Font("BookBookman Old Style" /* "High Tower Text"*/, 11f, FontStyle.Bold);
                        fontBoton = new Font("BookBookman Old Style", 9f, FontStyle.Bold);
                        break;
                        // Agrega más casos según los temas
                }

            }

            catch (ArgumentException)
            {
                MessageBox.Show("No existe ningun tema guardado");
            }
           
        }


        public static void diseñoFront(Form actualForm)
        {
            actualForm.BackColor = colorForm;
            actualForm.BackgroundImage = imagenFondo;
            actualForm.BackgroundImageLayout = ImageLayout.Stretch;
            
          
            //actualForm.Dock = DockStyle.Fill;
           
            foreach (Control control in actualForm.Controls)
            {
                if (control is FlowLayoutPanel panelLayout)
                {
                    if (panelLayout.Name == "panelMenuLateral")
                    {
                        panelLayout.BackColor = colorMenuLateral;
                        //panelLayout.BackgroundImage = imagenFondo;
                        foreach (Control control1 in panelLayout.Controls)
                        {
                            if (control1 is Button button1)
                            {
                                button1.Size = new Size(350, 50);
                                button1.Text = button1.Text.ToUpper();
                                button1.Font = fontGeneral;//new Font("Century Gothic", 13f, FontStyle.Bold);
                                button1.BackColor = colorBoton; //Color.FromArgb(243, 91, 213);
                                button1.ForeColor = Color.Black;//colorMenuLateral; //Color.FromArgb(232, 218, 239);
                                
                            }
                            else if (control1 is Panel panel) 
                            {
                                if (control1.Name == "panelBienvenida")
                                {
                                    control1.BackgroundImage = imagenFondoPanelUsuario;
                                    FrmPrincipal principal = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;
                                    principal.labelUsuario.Text = "VERONICA MENDOZA";
                                    principal.labelUsuario.ForeColor = Color.Black;// colorMenuLateral;
                                    //principal.labelUsuario.BackColor = Color.FromArgb(120, colorBoton);
                                    principal.labelUsuario.Font = new Font(fontGeneral.OriginalFontName,14f, FontStyle.Bold);
                                }
                                else
                                {
                                    control1.BackColor = Color.Transparent;
                                }

                                foreach (Control control2 in panel.Controls)
                                {
                                    if(control2 is Button button2) 
                                    {
                                        button2.Size = new Size(350, 43);
                                        button2.Text = button2.Text.ToUpper();
                                        button2.Font = fontGeneral;
                                        button2.BackColor = Color.FromArgb(Math.Max(colorBoton.R + 27, 0),
                                                                           Math.Max(colorBoton.G + 27, 0),
                                                                           Math.Max(colorBoton.B + 27, 0));
                                        button2.ForeColor = Color.Black; 
                                    }
                                }


                            }
                        }
                    }

                    else
                    {
                        foreach (Control control1 in panelLayout.Controls)
                        {
                            panelLayout.BackColor = Color.Transparent;

                            if (control1 is GroupBox groupBox1)
                            {
                                groupBox1.BackColor = colorGroupBox;
                                groupBox1.ForeColor = colorTextoGroupBox;
                                groupBox1.Text = groupBox1.Text.ToUpper();
                                groupBox1.Font = fontGeneral;  
                                foreach (Control control2 in groupBox1.Controls)
                                {
                                    if (control2 is Label label1)
                                    {

                                        label1.Text = label1.Text.ToUpper();
                                        label1.Font = fontGeneral; 
                                        control2.Font = label1.Font;
                                        label1.ForeColor = colorLabel;
                                        //label1.BackColor = Color.FromArgb(120,colorForm);
                                    }
                                    else if (control2 is Button button1)
                                    {
                                        button1.Size = new Size(button1.Size.Width, 42);
                                        button1.Text = button1.Text.ToUpper();
                                        button1.Font = fontBoton; 
                                        button1.BackColor = colorBoton;
                                        button1.ForeColor = colorFontBoton;
                                    }
                                    else if (control is CheckBox checkBox)
                                    {
                                        checkBox.ForeColor = colorLabel;
                                        checkBox.Font = fontGeneral;
                                        checkBox.Text = checkBox.Text.ToUpper();

                                    }
                                    else if (control2 is TextBox textBox1)
                                    {

                                    }
                                }
                            }
                            else if (control1 is Label label2)
                            {
                                label2.ForeColor = colorLabel;
                                label2.Text = label2.Text.ToUpper();
                                label2.Font = fontGeneral; //new Font("Century Gothic", 11f, FontStyle.Bold);
                                control.Font = label2.Font;
                            }
                            else if (control1 is Button button2)
                            {
                                button2.Size = new Size(button2.Size.Width, 42);
                                button2.Text = button2.Text.ToUpper();
                                button2.Font = fontBoton; //new Font("Century Gothic", 9f, FontStyle.Bold);
                                button2.BackColor = colorBoton; // Color.FromArgb(165, 105, 189);
                                button2.ForeColor = colorFontBoton;
                            }
                            else if (control is CheckBox checkBox)
                            {
                                checkBox.ForeColor = colorLabel;
                                checkBox.Font = fontGeneral;
                                checkBox.Text = checkBox.Text.ToUpper();

                            }
                            else if (control1 is TextBox textBox)
                            {

                            }
                        }
                    }

                }

                else if (control is Panel panel)
                {
                   
                    foreach (Control control1 in panel.Controls)
                    {
                        if (control1 is GroupBox groupBox1)
                        {
                            groupBox1.BackColor = colorGroupBox;
                            groupBox1.ForeColor = colorTextoGroupBox;
                            groupBox1.Text = groupBox1.Text.ToUpper();
                            groupBox1.Font = fontGeneral;  //new Font("Century Gothic", 11f, FontStyle.Bold);
                            foreach (Control control2 in groupBox1.Controls)
                            {
                                if (control2 is Label label1)
                                {
                                    
                                    label1.Text = label1.Text.ToUpper();
                                    label1.Font = fontGeneral; //new Font("Century Gothic", 11f, FontStyle.Bold);
                                    control2.Font = label1.Font;
                                    label1.ForeColor = colorLabel;
                                }
                                else if (control2 is Button button1)
                                {
                                    button1.Size = new Size(button1.Size.Width, 42);
                                    button1.Text = button1.Text.ToUpper();
                                    button1.Font = fontBoton; //new Font("Century Gothic", 9f, FontStyle.Bold);
                                    button1.BackColor = colorBoton;
                                    button1.ForeColor = colorFontBoton;
                                }
                                else if (control is CheckBox checkBox)
                                {
                                    checkBox.ForeColor = colorLabel;
                                    checkBox.Font = fontGeneral;
                                    checkBox.Text = checkBox.Text.ToUpper();

                                }
                                else if (control2 is TextBox textBox1)
                                {

                                }
                            }
                        }
                        else if (control1 is Label label2)
                        {
                            label2.ForeColor = colorLabel;
                            label2.Text = label2.Text.ToUpper();
                            label2.Font = fontGeneral; //new Font("Century Gothic", 11f, FontStyle.Bold);
                            control.Font = label2.Font;
                        }
                        else if (control1 is Button button2)
                        {
                            button2.Size = new Size(button2.Size.Width, 42);
                            button2.Text = button2.Text.ToUpper();
                            button2.Font = fontBoton; //new Font("Century Gothic", 9f, FontStyle.Bold);
                            button2.BackColor = colorBoton; 
                            button2.ForeColor = colorFontBoton;
                        }
                        else if (control is CheckBox checkBox)
                        {
                            checkBox.ForeColor = colorLabel;
                            checkBox.Font = fontGeneral;
                            checkBox.Text = checkBox.Text.ToUpper();

                        }
                        else if (control1 is ComboBox combo)
                        {
                            combo.Font = fontGeneral;
                        }
                    }
                
                }

                else if (control is GroupBox groupBox2)
                {
                    groupBox2.BackColor = colorGroupBox;
                    groupBox2.Text = groupBox2.Text.ToUpper();
                    groupBox2.Font = fontGeneral; //new Font("Century Gothic", 11f, FontStyle.Bold);
                    groupBox2.ForeColor = colorTextoGroupBox;
                    foreach (Control control2 in groupBox2.Controls)
                    {

                        if (control2 is Label label3)
                        {
                            label3.Text = label3.Text.ToUpper();
                            label3.Font = fontGeneral; //new Font("Century Gothic", 11f, FontStyle.Bold);
                            control2.Font = label3.Font;
                        }
                        else if (control2 is Button button3)
                        {
                            button3.Size = new Size(button3.Size.Width, 42);
                            button3.Text = button3.Text.ToUpper();
                            button3.Font = fontBoton; //new Font("Century Gothic", 9f, FontStyle.Bold);
                            button3.BackColor = colorBoton;
                            button3.ForeColor = colorFontBoton;
                        }
                        else if (control is CheckBox checkBox)
                        {
                            checkBox.ForeColor = colorLabel;
                            checkBox.Font = fontGeneral;
                            checkBox.Text = checkBox.Text.ToUpper();

                        }
                        else if (control2 is GroupBox groupBox3)
                        {
                            foreach (Control control3 in groupBox3.Controls)
                            { 
                                if (control3 is GroupBox groupBox4)
                                {
                                    groupBox4.BackColor = colorGroupBox;
                                    groupBox4.Text = groupBox4.Text.ToUpper();
                                    groupBox4.Font = fontGeneral;
                                    groupBox4.ForeColor = colorTextoGroupBox;
                                }
                            }
                        }
                    }
                }

                if ( control is Label label ) 
                {
                    label.ForeColor = colorLabel;
                    label.Text = label.Text.ToUpper();
                    label.Font = fontGeneral; //new Font("Century Gothic", 11f, FontStyle.Bold); 
                    control.Font = label.Font;
                }
                else if ( control is Button button ) 
                {
                    button.Size = new Size(button.Size.Width, 42);
                    button.Text = button.Text.ToUpper();
                    button.Font = fontBoton; //new Font("Century Gothic", 9f, FontStyle.Bold);
                    button.BackColor = colorBoton; 
                    button.ForeColor = colorFontBoton;
                }
                else if( control is CheckBox checkBox)
                {
                    checkBox.ForeColor = colorLabel;
                    checkBox.Font = fontGeneral;
                    checkBox.Text = checkBox.Text.ToUpper();

                }

                else if ( control is TextBox textBox ) 
                {
                
                }
            }

        
           

           
        }

        public static void fondoForm( Form actualForm)
        {
          
        }
        
    }
}
