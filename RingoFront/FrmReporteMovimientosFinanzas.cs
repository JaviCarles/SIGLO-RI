using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RingoDatos;
using RingoEntidades;
using RingoNegocio;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using Colors = ScottPlot.Colors;

namespace RingoFront
{
    public partial class FrmReporteMovimientosFinanzas : Form
    {
        public int mes1, mes2, año1, año2;
        public List<MovimientoFinanzasDiario> listaMovimientoFinanzas = new List<MovimientoFinanzasDiario>();
        public List<MovimientoFinanzasDiario> listaMovimientoFinanzas2 = new List<MovimientoFinanzasDiario>();
        public decimal MargenTotalMesAnt = 0;// esta variable se carga en el método cargarGrafico
        public decimal MargenTotalMesPost = 0;// esta variable se carga en el método cargarGrafico
        string imagePath;
        public FrmReporteMovimientosFinanzas()
        {
            InitializeComponent();
        }

        private void FrmReporteMovimientosFinanzas_Load(object sender, EventArgs e)
        {
            cargarGrafico();
            lblFecha.Text = " FECHA: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'");
            lblUsuario.Text = "Realizado por: Verónica Mendoza";
            lblPeriodo1.Text = "Mes " + mes1 + ", Año " + año1;
            lblPeriodo2.Text = "Mes " + mes2 + ", Año " + año2;
            lblMesAnt.Text = "Mes " + mes1 + "\nAño " + año1 + "\nMargen $ " + MargenTotalMesAnt;
            lblMesPost.Text = "Mes " + mes2 + "\nAño " + año2 + "\nMargen $ " + MargenTotalMesPost;
            DiseñoUI.diseñoFront(this);
            cargarGrillas();
        }
        public void cargarGrafico()
        {
            int count = listaMovimientoFinanzas.Count;
            double[] xs1 = new double[count];
            double[] margenMesAnt = new double[count];


            for (int i = 0; i < count; i++)
            {
                xs1[i] = listaMovimientoFinanzas[i].Fecha.Day; // Usar el día del mes
                margenMesAnt[i] = (double)listaMovimientoFinanzas[i].TotalMargen; // se guardará el margen de cada día
                MargenTotalMesAnt += listaMovimientoFinanzas[i].TotalMargen;
            }

            count = listaMovimientoFinanzas2.Count;
            double[] xs2 = new double[count];
            double[] margenMesPost = new double[count];
            for (int i = 0; i < count; i++)
            {
                xs2[i] = listaMovimientoFinanzas2[i].Fecha.Day; // Usar el día del mes 
                margenMesPost[i] = (double)listaMovimientoFinanzas2[i].TotalMargen;
                MargenTotalMesPost += listaMovimientoFinanzas2[i].TotalMargen;
            }

            double[] xs;
            if (xs1.Length >= xs2.Length) // defino cual es el máximo para usarlo en el gráfico
                xs = xs1;
            else
                xs = xs2;

            var scatterMargenAnt = formsPlot1.Plot.Add.Scatter(xs, margenMesAnt);
            scatterMargenAnt.Label = "Año: " + año1 + " Mes: " + mes1;
            scatterMargenAnt.Color = Colors.MediumVioletRed;

            var scatterMargenPost = formsPlot1.Plot.Add.Scatter(xs, margenMesPost);
            scatterMargenPost.Label = "Año: " + año2 + " Mes: " + mes2;
            scatterMargenPost.Color = Colors.Blue;

            //var fill = formsPlot1.Plot.Add.FillY(scatterIngresos, scatterEgresos);
            //fill.FillColor = Colors.White.WithAlpha(.1);
            //fill.LineWidth = 0;
            //formsPlot1.Plot.MoveToBack(fill);

            var legend = formsPlot1.Plot.Add.Legend();

            legend.Location = ScottPlot.Alignment.UpperRight; // Cambiar a la esquina superior derecha 
            legend.Orientation = ScottPlot.Orientation.Horizontal; // layenda de forma horizontal

            formsPlot1.Plot.XLabel("Día");//nombre de lo que representa el eje X
            formsPlot1.Plot.YLabel("Margen en $");//nombre de lo que representa el eje Y
            formsPlot1.Plot.Legend.IsVisible = false; // Desactivar leyenda que aparece abajo a la derecha

            double yMin = 0;
            double yMax = Math.Max(margenMesAnt.Max(), margenMesPost.Max()) * 1.1; // Aumentar el límite superior un 10%
            formsPlot1.Plot.Axes.SetLimitsY(yMin, yMax);
            formsPlot1.Plot.Axes.Margins(top: 0.2); //aumentar el limite inferior

            formsPlot1.Refresh();
        }

        public void cargarGrillas()
        {
            try
            {
                dataGridMesAnt.DataSource = listaMovimientoFinanzas;
                dataGridMesPost.DataSource = listaMovimientoFinanzas2;
            }
            catch
            {
                MessageBox.Show("Error al cargar grillas");
            }
        }

        #region Pdf sin la opción de guardar el documento

        /*public void crearPdf()
         {
             try
             {
                 // Guardar el gráfico 1 como imagen para luego implementarlo en el pdf
                 string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                 imagePath = $"Reporte_{timestamp}.png";
                 formsPlot1.Plot.SavePng(imagePath, 650, 450);

                 var fileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                 Document.Create(container =>
                 {
                     container.Page(page =>
                     {
                         page.Size(PageSizes.A4);
                         page.Margin(2, Unit.Centimetre);
                         //  page.Background(Colors.White);
                         page.DefaultTextStyle(x => x.FontSize(10));

                         page.Header()
                             .Text("REPORTE COMPARATIVO DE EGRESOS E INGRESOS BRUTOS")
                             .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                         page.Content()
                             .PaddingVertical(1, Unit.Centimetre)
                             .Column(x =>
                             {
                                 x.Spacing(8);
                                 x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                     + "\nMovimiento financiero diario del mes " + mes1 + " del año " + año1).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                 for (int i = 0; i < listaMovimientoFinanzas.Count; i++)
                                 {
                                     x.Item().Text("Fecha: " + listaMovimientoFinanzas[i].Fecha + "   Ingreso: $" + listaMovimientoFinanzas[i].TotalIngreso +
                                         "   Egreso: $" + listaMovimientoFinanzas[i].TotalEgreso + "   Margen: $" + listaMovimientoFinanzas[i].TotalMargen);
                                 }
                                 x.Item().Text("MARGEN MENSUAL: $"+MargenTotalMesAnt).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                             });

                         page.Footer()
                             .AlignCenter()
                             .Text(x =>
                             {
                                 x.Span("Page ");
                                 x.CurrentPageNumber();
                             });
                     });

                     container.Page(page =>
                     {
                         page.Size(PageSizes.A4);
                         page.Margin(2, Unit.Centimetre);
                         //  page.Background(Colors.White);
                         page.DefaultTextStyle(x => x.FontSize(10));

                         page.Header()
                             .Text("REPORTE COMPARATIVO DE EGRESOS E INGRESOS BRUTOS")
                             .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                         page.Content()
                             .PaddingVertical(1, Unit.Centimetre)
                             .Column(x =>
                             {
                                 x.Spacing(8);
                                 x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                     + "\nMovimiento financiero diario del mes " + mes2 + " del año " + año2).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                 for (int i = 0; i < listaMovimientoFinanzas2.Count; i++)
                                 {
                                     x.Item().Text("Fecha: " + listaMovimientoFinanzas2[i].Fecha + "   Ingreso: $" + listaMovimientoFinanzas2[i].TotalIngreso +
                                         "   Egreso: $" + listaMovimientoFinanzas2[i].TotalEgreso + "   Margen: $" + listaMovimientoFinanzas2[i].TotalMargen);
                                 }
                                 x.Item().Text("MARGEN MENSUAL: $" + MargenTotalMesPost).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                             });

                         page.Footer()
                             .AlignCenter()
                             .Text(x =>
                             {
                                 x.Span("Page ");
                                 x.CurrentPageNumber();
                             });
                     });

                     container.Page(page =>
                     {
                         page.Size(PageSizes.A4);
                         page.Margin(2, Unit.Centimetre);
                         //  page.Background(Colors.White);
                         page.DefaultTextStyle(x => x.FontSize(10));

                         page.Header()
                             .Text("REPORTE COMPARATIVO DE EGRESOS E INGRESOS BRUTOS")
                             .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                         page.Content()
                             .PaddingVertical(1, Unit.Centimetre)
                             .Column(x =>
                             {
                                 x.Spacing(8);
                                 x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                     + "\nMARGEN MENSUAL DEL MES " + mes1 + " del año " + año1 + " = $" + MargenTotalMesAnt +
                                      "\nMARGEN MENSUAL DEL MES " + mes2 + " del año " + año2 + " = $" + MargenTotalMesAnt)
                                 .FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                                 x.Item().Image(imagePath);

                             });

                         page.Footer()
                             .AlignCenter()
                             .Text(x =>
                             {
                                 x.Span("Page ");
                                 x.CurrentPageNumber();
                             });
                     });
                 }).GeneratePdf(fileName);
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Problemas para crear Pdf");
             }
         }*/
        #endregion
        
        public void crearPdf()
        {
            try
            {
                // Guardar el gráfico 1 como imagen para luego implementarlo en el pdf
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string imagePath = $"Reporte_{timestamp}.png";
                formsPlot1.Plot.SavePng(imagePath, 650, 450);

                // Configurar el SaveFileDialog para guardar el PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(2, Unit.Centimetre);
                            //  page.Background(Colors.White);
                            page.DefaultTextStyle(x => x.FontSize(10));

                            page.Header()
                                .Text("REPORTE COMPARATIVO DE EGRESOS E INGRESOS BRUTOS")
                                .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                            page.Content()
                                .PaddingVertical(1, Unit.Centimetre)
                                .Column(x =>
                                {
                                    x.Spacing(8);
                                    x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                        + "\nMovimiento financiero diario del mes " + mes1 + " del año " + año1).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                    
                                    // Añadir un contenedor con borde inferior alrededor de cada ítem
                                    x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col => 
                                    { 
                                        for (int i = 0; i < listaMovimientoFinanzas.Count; i++) 
                                        { 
                                            col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                            .PaddingBottom(5).Row(row => { row.ConstantItem(80).Text(listaMovimientoFinanzas[i].Fecha.ToString("dd/MM/yyyy")).FontSize(10); 
                                                row.RelativeItem().Text($"Ingreso: ${listaMovimientoFinanzas[i].TotalIngreso}").FontSize(10); 
                                                row.RelativeItem().Text($"Egreso: ${listaMovimientoFinanzas[i].TotalEgreso}").FontSize(10); 
                                                row.RelativeItem().Text($"Margen: ${listaMovimientoFinanzas[i].TotalMargen}").FontSize(10); 
                                            }); 
                                        } 
                                        col.Item().Text("MARGEN MENSUAL: $" + MargenTotalMesAnt).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium); 
                                    });

                                });

                            page.Footer()
                                .AlignCenter()
                                .Text(x =>
                                {
                                    x.Span("Page ");
                                    x.CurrentPageNumber();
                                });
                        });

                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(2, Unit.Centimetre);
                            //  page.Background(Colors.White);
                            page.DefaultTextStyle(x => x.FontSize(10));

                            page.Header()
                                .Text("REPORTE COMPARATIVO DE EGRESOS E INGRESOS BRUTOS")
                                .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                            page.Content()
                                .PaddingVertical(1, Unit.Centimetre)
                                .Column(x =>
                                {
                                    x.Spacing(8);
                                    x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                        + "\nMovimiento financiero diario del mes " + mes2 + " del año " + año2).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                                    // Añadir un contenedor con borde inferior alrededor de cada ítem
                                    x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col =>
                                    {
                                        for (int i = 0; i < listaMovimientoFinanzas2.Count; i++)
                                        {
                                            col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                            .PaddingBottom(5).Row(row => {
                                                row.ConstantItem(80).Text(listaMovimientoFinanzas2[i].Fecha.ToString("dd/MM/yyyy")).FontSize(10);
                                                row.RelativeItem().Text($"Ingreso: ${listaMovimientoFinanzas2[i].TotalIngreso}").FontSize(10);
                                                row.RelativeItem().Text($"Egreso: ${listaMovimientoFinanzas2[i].TotalEgreso}").FontSize(10);
                                                row.RelativeItem().Text($"Margen: ${listaMovimientoFinanzas2[i].TotalMargen}").FontSize(10);
                                            });
                                        }
                                        col.Item().Text("MARGEN MENSUAL: $" + MargenTotalMesPost).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                    });
                                    
                                });

                            page.Footer()
                                .AlignCenter()
                                .Text(x =>
                                {
                                    x.Span("Page ");
                                    x.CurrentPageNumber();
                                });
                        });

                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(2, Unit.Centimetre);
                            //  page.Background(Colors.White);
                            page.DefaultTextStyle(x => x.FontSize(10));

                            page.Header()
                                .Text("REPORTE COMPARATIVO DE EGRESOS E INGRESOS BRUTOS")
                                .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                            page.Content()
                                .PaddingVertical(1, Unit.Centimetre)
                                .Column(x =>
                                {
                                    x.Spacing(8);
                                    x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                        + "\nMARGEN MENSUAL DEL MES " + mes1 + " del año " + año1 + " = $" + MargenTotalMesAnt +
                                         "\nMARGEN MENSUAL DEL MES " + mes2 + " del año " + año2 + " = $" + MargenTotalMesPost)
                                    .FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                                    x.Item().Image(imagePath);

                                });

                            page.Footer()
                                .AlignCenter()
                                .Text(x =>
                                {
                                    x.Span("Page ");
                                    x.CurrentPageNumber();
                                });
                        });
                    }).GeneratePdf(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas para crear Pdf");
            }
        }

        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            crearPdf();
        }
    }
}
