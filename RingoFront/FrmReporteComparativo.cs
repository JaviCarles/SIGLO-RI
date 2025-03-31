using iText.IO.Image;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RingoEntidades;
using RingoNegocio;
using ScottPlot;
using ScottPlot.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RingoFront
{

    public partial class FrmReporteComparativo : Form
    {
        string imagePath1 = " ", imagePath2 = " ";
        public int año1, año2;
        public static List<MesParaReporte>? listaMeses1;
        public static List<MesParaReporte>? listaMeses2;
        double yMax1, yMax2;
        int cant1, cant2;//cantidad total de ventas
        double valorMaximoAlturaBarra;

        

        public FrmReporteComparativo()
        {
            InitializeComponent();
        }

        private void FrmReporteComparativo_Load(object sender, EventArgs e)
        {
            listaMeses1 = ReportesNegocio.Get12Meses(año1);
            listaMeses2 = ReportesNegocio.Get12Meses(año2);
            this.Dock = DockStyle.Fill;
            CargarGrilla1();
            CargarGrilla2();
            valorMaximoAlturaBarra = CalcularYMax();
            CargarGrafico1(año1);
            CargarGrafico2(año2);
            lblFecha.Text = " FECHA: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'");
            lblAño1.Text = "AÑO " + año1 + "\n\nTOTAL VENTAS: " + cant1;
            lblAño2.Text = "AÑO " + año2 + "\n\nTOTAL VENTAS: " + cant2;
            DiseñoUI.diseñoFront(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarGrilla1()
        {

            dataGridViewAño1.DataSource = listaMeses1;
        }
        public void CargarGrilla2()
        {

            dataGridViewAño2.DataSource = listaMeses2;
        }

        /* A continuación método para calcular el valor maximo del eje "Y".
        El valor máximo será el cliente con mayores compras y la barra más alta representará ese valor, por ende necesitamos
        que la escala de ambos gráficos sea igual al que posee el máximo valor para que visiblemente sean comparables las barras.
        */
        
        public double CalcularYMax() // compara el valor máximo de cada uno y al mayor lo retorna, además carga con datos las variables
        {                            // cant1 y cant2.
            double yMaxUno = 0;
            double yMaxDos = 0;
            try
            {
                double[] values1 = new double[listaMeses1.Count];
                for (int i = 0; i < listaMeses1.Count; i++)
                {
                    values1[i] = listaMeses1[i].CantidadVentas;
                    cant1 += listaMeses1[i].CantidadVentas;
                }


                foreach (var value in values1)
                {
                    if (value > yMaxUno)
                    {
                        yMaxUno = value;
                    }
                }
                yMax1 = yMaxUno;

                double[] values2 = new double[listaMeses2.Count];
                for (int i = 0; i < listaMeses2.Count; i++)
                {
                    values2[i] = listaMeses2[i].CantidadVentas;
                    cant2 += listaMeses2[i].CantidadVentas;
                }

                foreach (var value in values2)
                {
                    if (value > yMaxDos)
                    {
                        yMaxDos = value;
                    }
                }
                yMax2 = yMaxDos;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problemas en el método CalcularYMax que define la altura de las barras");
            }
            double yMax = Math.Max(yMax1, yMax2);
            return yMax;

        }

        /*public double valorMaximoDeAmbosGraf()
        {
            double yMax = Math.Max(yMax1, yMax2);
            return yMax;
        }*/

        public void CargarGrafico1(int año)
        {
            try
            {
                // Crear un gráfico de barras

                double[] values = new double[listaMeses1.Count];
                for (int i = 0; i < listaMeses1.Count; i++)
                {
                    values[i] = listaMeses1[i].CantidadVentas;
                }
                formsPlot1.Plot.Add.Bars(values);
                formsPlot1.Plot.Axes.Margins(bottom: 0);

                // Crear una etiqueta para cada barra
                Tick[] ticks = new Tick[listaMeses1.Count];
                {
                    for (int i = 0; i < listaMeses1.Count; i++)
                    {
                        ticks[i] = new Tick(i, listaMeses1[i].Nombre);
                    }

                };

                formsPlot1.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
                formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
                formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleLeft;

                // Determinar el ancho de la etiqueta más grande
                float largestLabelWidth = 0;
                using SKPaint paint = new();
                foreach (Tick tick in ticks)
                {
                    PixelSize size = formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label, paint).Size;
                    largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                }

                // Asegurarse de que los paneles de los ejes no sean más pequeños que la etiqueta más grande
                formsPlot1.Plot.Axes.Bottom.MinimumSize = largestLabelWidth;
                formsPlot1.Plot.Axes.Right.MinimumSize = largestLabelWidth;



                double yMax = valorMaximoAlturaBarra;
                formsPlot1.Plot.Axes.SetLimitsY(0, yMax + 1);


                formsPlot1.Refresh();

                // Guardar el gráfico como imagen
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                imagePath1 = $"Reporte_{timestamp}.png";

                formsPlot1.Plot.SavePng(imagePath1, 900, 700);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarGrafico2(int año)
        {
            try
            {
                // Crear un gráfico de barras

                double[] values = new double[listaMeses2.Count];
                for (int i = 0; i < listaMeses2.Count; i++)
                {
                    values[i] = listaMeses2[i].CantidadVentas;
                }
                formsPlot2.Plot.Add.Bars(values);
                formsPlot2.Plot.Axes.Margins(bottom: 0);

                // Crear una etiqueta para cada barra
                Tick[] ticks = new Tick[listaMeses2.Count];
                {
                    for (int i = 0; i < listaMeses2.Count; i++)
                    {
                        ticks[i] = new Tick(i, listaMeses2[i].Nombre);
                    }

                };

                formsPlot2.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
                formsPlot2.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
                formsPlot2.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleLeft;

                // Determinar el ancho de la etiqueta más grande
                float largestLabelWidth = 0;
                using SKPaint paint = new();
                foreach (Tick tick in ticks)
                {
                    PixelSize size = formsPlot2.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label, paint).Size;
                    largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                }

                // Asegurarse de que los paneles de los ejes no sean más pequeños que la etiqueta más grande
                formsPlot2.Plot.Axes.Bottom.MinimumSize = largestLabelWidth;
                formsPlot2.Plot.Axes.Right.MinimumSize = largestLabelWidth;

                double yMax = valorMaximoAlturaBarra;

                formsPlot2.Plot.Axes.SetLimitsY(0, yMax + 1);

                formsPlot2.Refresh();

                //Guardar el gráfico como imagen
                string timestamp2 = DateTime.Now.AddSeconds(+1).ToString("yyyyMMdd_HHmmss");
                imagePath2 = $"Reporte_{timestamp2}.png";

                formsPlot2.Plot.SavePng(imagePath2, 900, 700);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void crearPdf(string nombreImagen1 , string nombreImagen2)
        {
            string fileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.Title = "Guardar Reporte";
                saveFileDialog.FileName = fileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string nombreArchivo = saveFileDialog.FileName;
                    Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(2, Unit.Centimetre);
                            //  page.Background(Colors.White);
                            page.DefaultTextStyle(x => x.FontSize(10));

                            page.Header().Text("REPORTE DE VENTAS ANUAL COMPARATIVO")
                                .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                            page.Content().PaddingVertical(1, Unit.Centimetre).Column(x =>
                            {
                                x.Spacing(8);
                                x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                    + "\nPeríodo a comparar: Año " + año1).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                
                                x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col =>
                                {
                                    for (int i = 0; i < listaMeses1.Count; i++)
                                    {
                                        col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                        .PaddingBottom(5).Row(row =>
                                        {
                                            row.RelativeItem().Text($" {listaMeses1[i].Nombre} ").FontSize(10);
                                            row.RelativeItem().Text($"Cantidad de ventas: {listaMeses1[i].CantidadVentas}").FontSize(10);
                                            
                                        });
                                    }
                                    col.Item().Text($"CANTIDAD TOTAL DE VENTAS EN EL AÑO {año1}: {cant1} "  ).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                });
                                x.Item().Image(nombreImagen1);
                            });

                            page.Footer().AlignCenter().Text(x =>
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

                            page.Header().Text("REPORTE DE VENTAS ANUAL COMPARATIVO")
                                .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                            page.Content().PaddingVertical(1, Unit.Centimetre).Column(x =>
                            {
                                x.Spacing(8);
                                x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                    + "\nPeríodo a comparar: Año " +  año2).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                                x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col =>
                                {
                                    for (int i = 0; i < listaMeses2.Count; i++)
                                    {
                                        col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                        .PaddingBottom(5).Row(row =>
                                        {
                                            row.RelativeItem().Text($" {listaMeses2[i].Nombre} ").FontSize(10);
                                            row.RelativeItem().Text($"Cantidad de ventas: {listaMeses2[i].CantidadVentas}").FontSize(10);

                                        });
                                    }
                                    col.Item().Text($"CANTIDAD TOTAL DE VENTAS EN EL AÑO {año2}: {cant2} ").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                });
                                x.Item().Image(nombreImagen2);
                            });

                            page.Footer().AlignCenter().Text(x =>
                            {
                                x.Span("Page ");
                                x.CurrentPageNumber();
                            });
                        });

                    }).GeneratePdf(nombreArchivo);
                }
            }

        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            crearPdf(imagePath1, imagePath2);
        }
    }
}
