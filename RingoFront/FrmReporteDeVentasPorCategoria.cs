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
using Color = System.Drawing.Color;


namespace RingoFront
{
    public partial class FrmReporteDeVentasPorCategoria : Form
    {
        public FrmReporteDeVentasPorCategoria()
        {
            InitializeComponent();
        }

        public int cantidad;//objetos que devuelve la consulta de DB
        public DateTime fechaDesde, fechaHasta;
        public List<CantidadVentasPorCategoria> listaVentasPorCategoria;
        public List<CantidadPrendasPorCategoria> listaPrendasPorCategoria;
        string imagePath1 = " ";//esta variable es definifda en el metodo cargarGrafico1
        string imagePath2 = " ";// esta es definida en cargarGrafico2
        List<PieSlice> slices2 = new List<PieSlice>();
        List<PieSlice> slices1 = new List<PieSlice>();
        int cantidadTotalVent;// de prendas vendidas por categoria
        int cantidadTotalPrend;// de prendas por categoria
        private void FrmReporteDeVentasPorCategoria_Load(object sender, EventArgs e)
        {
            
            lblDesde.Text = "Desde: " + fechaDesde.ToString("dd 'de' MMMM 'de' yyyy");
            lblHasta.Text = "Hasta: " + fechaHasta.ToString("dd 'de' MMMM 'de' yyyy");
            lblUsuario.Text = "NOMBRE: Verónica Mendoza";
            lblFecha.Text = " FECHA: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'");
            listaVentasPorCategoria = ReportesNegocio.GetVentasPorCategoria(cantidad, fechaDesde, fechaHasta);
            listaPrendasPorCategoria = ReportesNegocio.GetPrendasPorCategorias(cantidad, fechaDesde, fechaHasta);
            cargarTotales(); // carga las variables cantidadTotalVent y cantidadTotalPrend.
            lblVentasPorCat.Text ="TOTAL VENTAS: " + cantidadTotalVent.ToString();
            lblPrendasPorCat.Text ="TOTAL PRENDAS: " + cantidadTotalPrend.ToString();   
            cargarGrillaPrendasPorCategoria();
            cargarGrillaVentasPorCategoria();
            this.Dock = DockStyle.Fill;
            cargarGrafico1();
            cargarGrafico2();
            pintarGraficosIguales();//pintamos los graficos con los colores correspondientes a las categorías
            agregarleCantidadALegendas();// con este método le agregamos la cantidad a la leyenda de la lista en el gráfico
            DiseñoUI.diseñoFront(this);
        }

        public void cargarTotales()// carga las variables cantidadTotalVent y cantidadTotalPrend.
        {
            try
            {
                for (int i = 0; i < listaVentasPorCategoria.Count; i++)
                {
                    cantidadTotalVent += listaVentasPorCategoria[i].CantidadPrendas;
                }

                for (int i = 0; i < listaPrendasPorCategoria.Count; i++)
                {
                    cantidadTotalPrend += listaPrendasPorCategoria[i].CantidadPrendas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método cargarTotales() de la clase FrmReporteDeVentasPorCategoria");
            }
        }

        public void cargarGrillaPrendasPorCategoria()
        {
            dataGridPrendasPorCate.DataSource = listaPrendasPorCategoria;
            dataGridVentasPorCate.Refresh();
        }

        public void cargarGrillaVentasPorCategoria()
        {
            dataGridVentasPorCate.DataSource = listaVentasPorCategoria;
            dataGridVentasPorCate.Refresh();
        }

        public void cargarGrafico1()
        {
            try
            {

                double umbral = 70;  // Ajusta este valor según el umbral que consideres para "Otros"
                double totalPequeños = 0;
                List<string> leyendasPequeñas = new List<string>();

                foreach (var dato in listaPrendasPorCategoria)
                {
                    if (dato.CantidadPrendas < umbral)
                    {
                        totalPequeños += dato.CantidadPrendas;
                        leyendasPequeñas.Add(dato.NombreCategoria + " " + dato.NombreSubCategoria);
                    }
                    else
                    {
                        slices1.Add(new PieSlice
                        {
                            Value = dato.CantidadPrendas,
                            Label = dato.CantidadPrendas.ToString(),
                            LegendText = dato.NombreCategoria + " " + dato.NombreSubCategoria,
                            
                        });
                    }
                }

                // Agregar la categoría "Otros" si hay segmentos pequeños
                if (totalPequeños > 0)
                {
                    slices1.Add(new PieSlice
                    {
                        Value = totalPequeños,
                        Label = totalPequeños.ToString(),
                        LegendText = "Otros"
                    });
                }

                var pie = formsPlot1.Plot.Add.Pie(slices1.ToArray());
                pie.ExplodeFraction = .1;
                pie.SliceLabelDistance = 1.1;


                formsPlot1.Plot.ShowLegend();
                formsPlot1.Plot.Axes.Frameless();
                formsPlot1.Plot.HideGrid();

                formsPlot1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void cargarGrafico2()
        {
            try
            {
                
                double umbral = 5;  // Ajusta este valor según el umbral que consideres para "Otros"
                double totalPequeños = 0;
                List<string> leyendasPequeñas = new List<string>();

                foreach (var dato in listaVentasPorCategoria)
                {
                    
                    if (dato.CantidadPrendas < umbral)
                    {
                        totalPequeños += dato.CantidadPrendas;
                        leyendasPequeñas.Add(dato.NombreCategoria + " " + dato.NombreSubCategoria);
                    }
                    else
                    {
                        slices2.Add(new PieSlice
                        {
                            Value = dato.CantidadPrendas,
                            Label = dato.CantidadPrendas.ToString(),
                            LegendText = dato.NombreCategoria + " " + dato.NombreSubCategoria
                        });
                    }
                }

                // Agregar la categoría "Otros" si hay segmentos pequeños
                if (totalPequeños > 0)
                {
                    slices2.Add(new PieSlice
                    {
                        Value = totalPequeños,
                        Label = totalPequeños.ToString(),
                        LegendText = "Otros"
                    });
                }

                var pie = formsPlot2.Plot.Add.Pie(slices2.ToArray());
                pie.ExplodeFraction = .1;
                pie.SliceLabelDistance = 1.1;


                formsPlot2.Plot.ShowLegend();
                formsPlot2.Plot.Axes.Frameless();
                formsPlot2.Plot.HideGrid();

                formsPlot2.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void pintarGraficosIguales()//pintamos los graficos con los colores correspondientes a las categorías
        {
            
            ScottPlot.Color[] color = new ScottPlot.Color[30];
            
            color[0] = ScottPlot.Color.FromColor(Color.FromArgb(255, 50, 180, 255));
            color[1] = ScottPlot.Color.FromColor(Color.FromArgb(255, 154, 205, 50));
            color[2] = ScottPlot.Color.FromColor(Color.FromArgb(255, 178, 34, 34));
            color[3] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 90, 150));
            color[4] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 140, 0));
            color[5] = ScottPlot.Color.FromColor(Color.FromArgb(255, 70, 130, 180));
            color[6] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 215, 0));
            color[7] = ScottPlot.Color.FromColor(Color.FromArgb(255, 60, 179, 113));
            color[8] = ScottPlot.Color.FromColor(Color.FromArgb(255, 147, 112, 219));
            color[9] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 69, 0));
            color[10] = ScottPlot.Color.FromColor(Color.FromArgb(255, 218, 145, 150));
            color[11] = ScottPlot.Color.FromColor(Color.FromArgb(255, 70, 130, 150));
            color[12] = ScottPlot.Color.FromColor(Color.FromArgb(255, 219, 112, 200));
            color[13] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 165, 0));
            color[14] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 105, 230));
            color[15] = ScottPlot.Color.FromColor(Color.FromArgb(255, 34, 139, 34));
            color[16] = ScottPlot.Color.FromColor(Color.FromArgb(255, 0, 100, 0));
            color[17] = ScottPlot.Color.FromColor(Color.FromArgb(255, 75, 0, 130));
            color[18] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 0, 0));
            color[19] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 255, 0));
            color[20] = ScottPlot.Color.FromColor(Color.FromArgb(255, 0, 0, 255));
            color[21] = ScottPlot.Color.FromColor(Color.FromArgb(255, 199, 21, 133));
            color[22] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 127, 80));
            color[23] = ScottPlot.Color.FromColor(Color.FromArgb(255, 0, 128, 128));
            color[24] = ScottPlot.Color.FromColor(Color.FromArgb(255, 124, 252, 0));
            color[25] = ScottPlot.Color.FromColor(Color.FromArgb(255, 0, 250, 154));
            color[26] = ScottPlot.Color.FromColor(Color.FromArgb(255, 186, 85, 211));
            color[27] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 0, 255));
            color[28] = ScottPlot.Color.FromColor(Color.FromArgb(255, 210, 105, 30));
            color[29] = ScottPlot.Color.FromColor(Color.FromArgb(255, 176, 224, 230));



            //asimilamos que cantPrendasPorProveedor va a ser siempre la lista que más cantidad de objetos va a devolver.

            if (slices1.Count > slices2.Count)
            {
                int cant = 1;
                for (int i = 0; i < slices1.Count; i++)
                {
                    for (int j = 0; j < slices2.Count; j++)
                    {
                        if (slices1[i].LegendText == slices2[j].LegendText)
                        {
                            slices1[i].FillColor = color[i];
                            slices2[j].FillColor = color[i];
                        }
                    }
                    if (slices1[i].FillColor.A == 0 && slices1[i].FillColor.R == 0 && slices1[i].FillColor.G == 0 && slices1[i].FillColor.B == 0)
                    {
                        slices1[i].FillColor = color[i];
                    }
                }

                for (int i = 0; i < slices2.Count; i++)
                {
                    if (slices2[i].FillColor.A == 0 && slices2[i].FillColor.R == 0 && slices2[i].FillColor.G == 0 && slices2[i].FillColor.B == 0)
                    {
                        slices2[i].FillColor = color[color.Length - cant];
                        cant++;
                    }
                }
            }
            else
            {
                int cant = 1;
                for (int i = 0; i < slices2.Count; i++)
                {
                    for (int j = 0; j < slices1.Count; j++)
                    {
                        if (slices2[i].LegendText == slices1[j].LegendText)
                        {
                            slices2[i].FillColor = color[i];
                            slices1[j].FillColor = color[i];
                        }
                    }
                    if (slices2[i].FillColor.A == 0 && slices2[i].FillColor.R == 0 && slices2[i].FillColor.G == 0 && slices2[i].FillColor.B == 0)
                    {
                        slices2[i].FillColor = color[i];
                    }
                }

                for (int i = 0; i < slices1.Count; i++)
                {
                    if (slices1[i].FillColor.A == 0 && slices1[i].FillColor.R == 0 && slices1[i].FillColor.G == 0 && slices1[i].FillColor.B == 0)
                    {
                        slices1[i].FillColor = color[color.Length - cant];
                        cant++;
                    }
                }

            }
        }
        public void agregarleCantidadALegendas()// con este método le agregamos la cantidad a la leyenda de la lista en el gráfico
        {
            for (int i = 0; i < slices1.Count; i++)
            {
                slices1[i].LegendText = slices1[i].Value.ToString() +" "+ slices1[i].LegendText;
            }

            for (int i = 0; i < slices2.Count; i++)
            {
                slices2[i].LegendText = slices2[i].Value.ToString() + " " + slices2[i].LegendText;
            }
        }
        public void crearPdf()
        {
            try
            {
                // Guardar el gráfico 1 como imagen para luego implementarlo en el pdf
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                imagePath1 = $"Reporte_{timestamp}.png";
                formsPlot1.Plot.SavePng(imagePath1, 650, 450);

                // Guardar el gráfico 2 como imagen
                string timestamp2 = DateTime.Now.AddSeconds(+1).ToString("yyyyMMdd_HHmmss");
                imagePath2 = $"Reporte_{timestamp2}.png";
                formsPlot2.Plot.SavePng(imagePath2, 650, 450);

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

                                page.Header()
                                    .Text("Reporte de ventas por Categoría")
                                    .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                                page.Content()
                                    .PaddingVertical(1, Unit.Centimetre)
                                    .Column(x =>
                                    {
                                        x.Spacing(8);
                                        x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                            + "\nPeríodo: " + fechaDesde + " hasta " + fechaHasta + "\n\n Cantidad de ventas por Categoría").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                        /* for (int i = 0; i < listaVentasPorCategoria.Count; i++)
                                         {
                                             x.Item().Text("Categoría: " + listaVentasPorCategoria[i].NombreCategoria + "    Cantidad de prendas vendidas: " + listaVentasPorCategoria[i].CantidadPrendas);
                                         }
                                         x.Item().Image(imagePath2);*/
                                        x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col =>
                                        {
                                            for (int i = 0; i < listaVentasPorCategoria.Count; i++)
                                            {
                                                col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                                .PaddingBottom(5).Row(row => {
                                                    row.RelativeItem().Text($"Categoría: {listaVentasPorCategoria[i].NombreCategoria}").FontSize(10);
                                                    row.RelativeItem().Text($"Subcategoria: {listaVentasPorCategoria[i].NombreSubCategoria}").FontSize(10);
                                                    row.RelativeItem().Text($"Cantidad de prendas vendidas: {listaVentasPorCategoria[i].CantidadPrendas}").FontSize(10);
                                                });
                                            }
                                            col.Item().Text("CANTIDAD TOTAL DE PRENDAS VENDIDAS POR CATEGORÍA: " + cantidadTotalVent).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                        });
                                        x.Item().Image(imagePath2);
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
                                    .Text("Reporte de ventas por Categoría")
                                    .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                                page.Content()
                                   .PaddingVertical(1, Unit.Centimetre)
                                   .Column(x =>
                                   {
                                       x.Spacing(8);

                                       x.Item().Text("Cantidad de prendas por categoría").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                                       x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col =>
                                       {
                                           for (int i = 0; i < listaPrendasPorCategoria.Count; i++)
                                           {
                                               col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                               .PaddingBottom(5).Row(row => {
                                                   row.RelativeItem().Text($"Categoría: {listaPrendasPorCategoria[i].NombreCategoria}").FontSize(10);
                                                   row.RelativeItem().Text($"Subcategoria: {listaPrendasPorCategoria[i].NombreSubCategoria}").FontSize(10);
                                                   row.RelativeItem().Text($"Cantidad de prendas: {listaPrendasPorCategoria[i].CantidadPrendas}").FontSize(10);
                                               });
                                           }
                                           col.Item().Text("CANTIDAD TOTAL DE PRENDAS: " + cantidadTotalPrend).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                       });
                                       x.Item().Image(imagePath1);
                                   });

                                page.Footer()
                                    .AlignCenter()
                                    .Text(x =>
                                    {
                                        x.Span("Page ");
                                        x.CurrentPageNumber();
                                    });

                            });

                        }).GeneratePdf(nombreArchivo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas para crear Pdf");
            }
        }
        #region primer PDF
        /*
         public void crearPdf()
        {
            try
            {
                // Guardar el gráfico 1 como imagen para luego implementarlo en el pdf
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                imagePath1 = $"Reporte_{timestamp}.png";
                formsPlot1.Plot.SavePng(imagePath1, 650, 450);

                    // Guardar el gráfico 2 como imagen
                    string timestamp2 = DateTime.Now.AddSeconds(+1).ToString("yyyyMMdd_HHmmss");
                    imagePath2 = $"Reporte_{timestamp2}.png";

                    formsPlot2.Plot.SavePng(imagePath2, 650, 450);

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
                                .Text("Reporte de ventas por Categoría")
                                .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                            page.Content()
                                .PaddingVertical(1, Unit.Centimetre)
                                .Column(x =>
                                {
                                    x.Spacing(8);
                                    x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                        + "\nPeríodo: " + fechaDesde + " hasta " + fechaHasta + "\n\n Cantidad de ventas por Categoría").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                    for (int i = 0; i < listaVentasPorCategoria.Count; i++)
                                    {
                                        x.Item().Text("Categoría: " + listaVentasPorCategoria[i].NombreCategoria + "    Cantidad de prendas vendidas: " + listaVentasPorCategoria[i].CantidadPrendas);
                                    }
                                    x.Item().Image(imagePath2);

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
                                .Text("Reporte de ventas por Categoría")
                                .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                            page.Content()
                               .PaddingVertical(1, Unit.Centimetre)
                               .Column(x =>
                               {
                                   x.Spacing(8);

                                   x.Item().Text("Cantidad de prendas por categoría").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                                   for (int i = 0; i < listaPrendasPorCategoria.Count; i++)
                                   {
                                       x.Item().Text("Categoría: " + listaPrendasPorCategoria[i].NombreCategoria + "    Cantidad de prendas : " + listaPrendasPorCategoria[i].CantidadPrendas);
                                   }
                                   x.Item().Image(imagePath1);
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
        }
         */
        #endregion


        private void btnCrearPdf_Click(object sender, EventArgs e)
        {
            crearPdf();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
