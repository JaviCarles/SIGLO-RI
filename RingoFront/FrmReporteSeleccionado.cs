using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using ScottPlot;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Helpers;
using RingoNegocio;
using RingoEntidades;
using System.Drawing;
using QuestColors = QuestPDF.Helpers.Colors;
using ScottColors = ScottPlot.Colors;


namespace RingoFront
{
    public partial class FrmReporteSeleccionado : Form
    {
        string imagePath = " "; //nombre de la imagen que se usará para pdf
        public EnumModoForm modo;
        public int cantidad; // cantidad de valores que devolverá la consulta
        int cantidadTotal; //refleja la cantidad total de las compras del grupo de clientes
        public bool ordenAscendente; // orden del listado 
        public DateTime fechaDesde, fechaHasta; // periodo de compras
        
       
        List<ClienteParaReporte> listaClientes;
        public FrmReporteSeleccionado()
        {
            InitializeComponent();
        }


        private void FrmReporteSeleccionado_Load(object sender, EventArgs e)
        {
            listaClientes = ReportesNegocio.GetReporte(ordenAscendente, fechaDesde, fechaHasta, cantidad);

            lblFecha.Text = " FECHA: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'");
            if (modo == EnumModoForm.ReporteUno)
            {
                reporteUno(cantidad, fechaDesde, fechaHasta);
            }
            
           
            dataGridComprasPorClientes.DataSource = listaClientes;
            dataGridComprasPorClientes.Refresh(); 
            
            DiseñoUI.diseñoFront(this);
        }

        public void crearPdf(string nombreImagen)
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

                            page.Header().Text("Reporte de cantidad de ventas por cliente")
                                .SemiBold().FontSize(12).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                            page.Content().PaddingVertical(1, Unit.Centimetre).Column(x =>
                            {
                                x.Spacing(8);
                                x.Item().Text("Creado por: Verónica Mendoza" + "    Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy HH:mm:ss 'hs'")
                                    + "\nPeríodo: " + fechaDesde + " hasta " + fechaHasta).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                /* for (int i = 0; i < listaClientes.Count; i++)
                                 {
                                     x.Item().Text("Nombre: " + listaClientes[i].Nombre + " " + listaClientes[i].Apellido + "    Cantidad de compras: " + listaClientes[i].CantidadCompras + "    Dni: " + listaClientes[i].Dni);
                                 }*/
                                // Añadir un contenedor con borde inferior alrededor de cada ítem
                                x.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Medium).Padding(5).Column(col =>
                                {
                                    for (int i = 0; i < listaClientes.Count; i++)
                                    {
                                        cantidadTotal += listaClientes[i].CantidadCompras;
                                        col.Item().BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                        .PaddingBottom(5).Row(row => {
                                            row.RelativeItem().Text($"Nombre: {listaClientes[i].Nombre} {listaClientes[i].Apellido}").FontSize(10);
                                            row.RelativeItem().Text($"DNI: {listaClientes[i].Dni}").FontSize(10);
                                            row.RelativeItem().Text($"Cantidad de compras: {listaClientes[i].CantidadCompras}").FontSize(10);
                                        });
                                    }
                                    col.Item().Text("CANTIDAD TOTAL DE COMPRAS: " + cantidadTotal).FontSize(11).FontColor(QuestPDF.Helpers.Colors.Green.Medium);
                                });
                                x.Item().Image(nombreImagen);
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

        public void reporteUno(int cantidad,DateTime desde, DateTime hasta) //Reporte "Clientes por cantidad de compras"
        {
            lblNombre.Text = "NOMBRE: Verónica Mendoza";
            lblTituloReporte.Text = "REPORTE DE VENTAS POR CLIENTE";
            labelDesde.Text ="Desde: " + desde.ToString("dd/MM/yyyy");
            labelHasta.Text = "Hasta: " + hasta.ToString("dd/MM/yyyy");
            
            try
            {
                // Crear un gráfico de barras

                double[] values = new double[listaClientes.Count];
                for (int i = 0; i < listaClientes.Count; i++)
                {
                    values[i] = listaClientes[i].CantidadCompras;
                }
                formsPlot1.Plot.Add.Bars(values);
                formsPlot1.Plot.Axes.Margins(bottom: 0);

                // Crear una etiqueta para cada barra
                Tick[] ticks = new Tick[listaClientes.Count];
                {
                    for (int i = 0; i < listaClientes.Count; i++) 
                        {
                            ticks[i] = new Tick(i, listaClientes[i].Nombre +" "+listaClientes[i].Apellido); 
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



                formsPlot1.Refresh();

                // Guardar el gráfico como imagen
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss"); 
                imagePath = $"Reporte_{timestamp}.png";
                
                formsPlot1.Plot.SavePng(imagePath, 900, 700);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrearPdf_Click(object sender, EventArgs e)
        {
            crearPdf(imagePath);
        }
    }
}
