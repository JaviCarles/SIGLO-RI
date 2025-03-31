using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
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
//using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using Color = System.Drawing.Color;
using ScottColors = ScottPlot.Colors;
namespace RingoFront
{
    public partial class FrmReporteVentasProveedores : Form
    {
        public FrmReporteVentasProveedores()
        {
            InitializeComponent();
        }

        public int cantidad;
        public DateTime fechaDesde, fechaHasta;
        public List<PrendasVendidasPorProveedor> cantidadVentasPorProveedor;
        public List<CantPrendasPorProveedor> cantPrendasPorProveedor;
        string imagePath1 = " ";//esta variable es definifda en el metodo cargarGrafico1
        string imagePath2 = " ";// esta es definida en cargarGrafico2
        List<PieSlice> slices2 = new List<PieSlice>();
        List<PieSlice> slices1 = new List<PieSlice>();
        int totalPrendas, totalPrendasVendidas;

        private void FrmReporteVentasProveedores_Load(object sender, EventArgs e)
        {
            lblDesde.Text ="Desde: " + fechaDesde.ToString("dd 'de' MMMM 'de' yyyy");
            lblHasta.Text ="Hasta: " + fechaHasta.ToString("dd 'de' MMMM 'de' yyyy");
            lblUsuario.Text = "NOMBRE: Verónica Mendoza";
            lblFecha.Text = " FECHA: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'");
            cantidadVentasPorProveedor = ReportesNegocio.GetPrendasVendidasPorProveedor(cantidad, fechaDesde, fechaHasta);
            cantPrendasPorProveedor = ReportesNegocio.GetCantidadPrendasPorProveedor(cantidad);
            cargarTotales();
            lblTotalPrendas.Text ="TOTAL PRENDAS: " + totalPrendas.ToString();
            lblTotalVentas.Text ="TOTAL VENDIDAS: " + totalPrendasVendidas.ToString();  
            cargarGrillaVentasPorProveedor();
            cargarGrillaCantidadPrendas();
            this.Dock = DockStyle.Fill;
            
            cargarGrafico1();
            cargarGrafico2();
            pintarGraficosIguales();//pintamos los graficos con los colores correspondientes a los proveedores
            DiseñoUI.diseñoFront(this);
        }

        public void cargarTotales()// carga las variables totalPrendas y totalPrendasVendidas.
        {
            try
            {
                for (int i = 0; i < cantPrendasPorProveedor.Count; i++)
                {
                    totalPrendas += cantPrendasPorProveedor[i].CantidadPrendas;
                }

                for (int i = 0; i < cantidadVentasPorProveedor.Count; i++)
                {
                     totalPrendasVendidas += cantidadVentasPorProveedor[i].CantidadPrendasVendidas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método cargarTotales() de la clase FrmReporteDeVentasPorCategoria");
            }
        }

        public void cargarGrillaVentasPorProveedor()
        {
            dataGridVentasPorProve.DataSource = cantidadVentasPorProveedor;
            dataGridVentasPorProve.Refresh();
        }

        public void cargarGrillaCantidadPrendas()
        {
            dataGridPrendasPorProve.DataSource = cantPrendasPorProveedor;
            dataGridPrendasPorProve.Refresh();
        }

        public void cargarGrafico1()
        {

            try
            {


                foreach (var dato in cantPrendasPorProveedor)
                {

                    slices1.Add(new PieSlice
                    {
                        Value = dato.CantidadPrendas,
                        //FillColor = ScottColors.RandomHue(50)[19],
                        Label = dato.CantidadPrendas.ToString(), // La etiqueta será el nombre del proveedor
                        LegendText =/* dato.CantidadPrendas + " " +*/ dato.NombreProveedor // El texto de la leyenda será el nombre del proveedor
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
                

                foreach (var dato in cantidadVentasPorProveedor)
                {

                    slices2.Add(new PieSlice
                    {
                       
                        Value = dato.CantidadPrendasVendidas,
                        //FillColor = ScottColors.RandomHue(50)[32],
                        Label = dato.CantidadPrendasVendidas.ToString(), // La etiqueta será el nombre del proveedor
                        LegendText = /*dato.CantidadPrendasVendidas + " " +*/ dato.NombreProveedor   // El texto de la leyenda será el nombre del proveedor
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

        public void pintarGraficosIguales()
        {
            //var colores = ScottColors.RandomHue(cantPrendasPorProveedor.Count);

            ScottPlot.Color[] color = new ScottPlot.Color[30];
            color[0] = ScottPlot.Color.FromColor(Color.FromArgb(255, 30, 144, 255)); 
            color[1] = ScottPlot.Color.FromColor(Color.FromArgb(255, 154, 205, 50)); 
            color[2] = ScottPlot.Color.FromColor(Color.FromArgb(255,178,34,34)); 
            color[3] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 90, 150)); 
            color[4] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 140, 0)); 
            color[5] = ScottPlot.Color.FromColor(Color.FromArgb(255, 173, 216, 230)); 
            color[6] = ScottPlot.Color.FromColor(Color.FromArgb(255,255,215,0)); 
            color[7] = ScottPlot.Color.FromColor(Color.FromArgb(255, 60, 179, 113)); 
            color[8] = ScottPlot.Color.FromColor(Color.FromArgb(255, 147, 112, 219)); 
            color[9] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 69, 0)); 
            color[10] = ScottPlot.Color.FromColor(Color.FromArgb(255, 218, 145, 214)); 
            color[11] = ScottPlot.Color.FromColor(Color.FromArgb(255, 70, 130, 120)); 
            color[12] = ScottPlot.Color.FromColor(Color.FromArgb(255, 219, 112, 147)); 
            color[13] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 165, 0)); 
            color[14] = ScottPlot.Color.FromColor(Color.FromArgb(255, 175, 238, 238)); 
            color[15] = ScottPlot.Color.FromColor(Color.FromArgb(255, 221, 160, 221)); 
            color[16] = ScottPlot.Color.FromColor(Color.FromArgb(255, 0, 100, 0)); color[17] = ScottPlot.Color.FromColor(Color.FromArgb(255, 75, 0, 130)); color[18] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 0, 0)); color[19] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 255, 0)); color[20] = ScottPlot.Color.FromColor(Color.FromArgb(255, 0, 0, 255)); color[21] = ScottPlot.Color.FromColor(Color.FromArgb(255, 199, 21, 133)); color[22] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 127, 80)); color[23] = ScottPlot.Color.FromColor(Color.FromArgb(255, 135, 206, 235)); color[24] = ScottPlot.Color.FromColor(Color.FromArgb(255, 221, 160, 221)); color[25] = ScottPlot.Color.FromColor(Color.FromArgb(255, 0, 250, 154)); color[26] = ScottPlot.Color.FromColor(Color.FromArgb(255, 186, 85, 211)); color[27] = ScottPlot.Color.FromColor(Color.FromArgb(255, 255, 0, 255)); color[28] = ScottPlot.Color.FromColor(Color.FromArgb(255, 210, 105, 30)); color[29] = ScottPlot.Color.FromColor(Color.FromArgb(255, 135, 206, 250));
            //asimilamos que cantPrendasPorProveedor va a ser siempre la lista que más cantidad de objetos va a devolver.

            for (int i = 0; i < cantPrendasPorProveedor.Count; i++)
                {
                    
                    for(int x = 0; x < cantidadVentasPorProveedor.Count; x++)
                    {
                    slices1[i].FillColor = color[i];
                    if (slices1[i].LegendText == slices2[x].LegendText)
                            {
                                slices2[x].FillColor = color[i];
                            }
                    }

                    if ( i >= cantidadVentasPorProveedor.Count - 1)
                    {
                         slices1[i].FillColor = color[i];// colores[i];
                    }
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
                                    .Text("Reporte de ventas por Proveedor")
                                    .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                                page.Content()
                                    .PaddingVertical(1, Unit.Centimetre)
                                    .Column(x =>
                                    {
                                        x.Spacing(8);
                                        x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                            + "\nPeríodo: " + fechaDesde + " hasta " + fechaHasta + "\n\n Cantidad de ventas por Proveedor").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                        
                                        x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col =>
                                        {
                                            for (int i = 0; i < cantidadVentasPorProveedor.Count; i++)
                                            {
                                                col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                                .PaddingBottom(5).Row(row => {
                                                    row.RelativeItem().Text($"Proveedor: {cantidadVentasPorProveedor[i].NombreProveedor}").FontSize(10);
                                                    row.RelativeItem().Text($"Prendas Vendidas: {cantidadVentasPorProveedor[i].CantidadPrendasVendidas}").FontSize(10);
                                                   
                                                });
                                            }
                                            col.Item().Text("CANTIDAD TOTAL DE PRENDAS VENDIDAS POR PROVEEDOR: " + totalPrendasVendidas).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
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
                                    .Text("Reporte de prendas por Proveedores")
                                    .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                                page.Content()
                                   .PaddingVertical(1, Unit.Centimetre)
                                   .Column(x =>
                                   {
                                       x.Spacing(8);

                                       x.Item().Text("Cantidad de prendas por Proveedor").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                                       x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col =>
                                       {
                                           for (int i = 0; i < cantPrendasPorProveedor.Count; i++)
                                           {
                                               col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                               .PaddingBottom(5).Row(row => {
                                                   row.RelativeItem().Text($"Proveedor: {cantPrendasPorProveedor[i].NombreProveedor}").FontSize(10);
                                                   row.RelativeItem().Text($"Cantidad de prendas: {cantPrendasPorProveedor[i].CantidadPrendas}").FontSize(10);
                                                   
                                               });
                                           }
                                           col.Item().Text("CANTIDAD TOTAL DE PRENDAS: " + totalPrendas).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
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
        #region Primer pdf
        /* public void crearPdf()
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
                         .Text("Reporte de ventas por proveedor")
                         .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                     page.Content()
                         .PaddingVertical(1, Unit.Centimetre)
                         .Column(x =>
                         {
                             x.Spacing(8);
                             x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                 + "\nPeríodo: " + fechaDesde + " hasta " + fechaHasta + "\n\n Cantidad de ventas por proveedor").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                             for (int i = 0; i < cantidadVentasPorProveedor.Count; i++)
                             {
                                 x.Item().Text("Proveedor: " + cantidadVentasPorProveedor[i].NombreProveedor + "    Cantidad de prendas vendidas: " + cantidadVentasPorProveedor[i].CantidadPrendasVendidas);
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
                          .Text("Reporte de ventas por proveedor")
                          .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                      page.Content()
                         .PaddingVertical(1, Unit.Centimetre)
                         .Column(x =>
                         {
                             x.Spacing(8);

                             x.Item().Text("Cantidad de prendas por proveedor").FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);

                             for (int i = 0; i < cantPrendasPorProveedor.Count; i++)
                             {
                                 x.Item().Text("Proveedor: " + cantPrendasPorProveedor[i].NombreProveedor + "    Cantidad de prendas : " + cantPrendasPorProveedor[i].CantidadPrendas);
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
        */
        #endregion
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrearPdf_Click(object sender, EventArgs e)
        {
            crearPdf();
        }
    }
}
