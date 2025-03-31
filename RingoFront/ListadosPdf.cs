using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iText.IO.Image;
using iText.Kernel.Geom;

namespace RingoFront
{
    public class ListadosPdf
    {
        public static void ExportEstadosPrendasToPdf(List<EstadosPrendas> estadosPrendasList, string filtro)
        {
            List<EstadosPrendas> listado = estadosPrendasList.OrderBy(e => e.DescripcionPrenda).ToList();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar archivo PDF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        PdfWriter writer = new PdfWriter(fs);
                        PdfDocument pdf = new PdfDocument(writer);
                        Document document = new Document(pdf, PageSize.A4.Rotate());

                        // Agregar logo desde recursos
                        System.Drawing.Image logoImage = Properties.Resources.Logo_Ringo_1;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            logoImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(ms.ToArray()));
                            logo.SetWidth(50).SetHeight(50);
                            document.Add(logo);
                        }

                        // Agregar título
                        Paragraph titulo = new Paragraph("Listado de Prendas")
                                            .SetTextAlignment(TextAlignment.RIGHT)
                                            .SetFontSize(24);
                        document.Add(titulo);

                        // Encabezado de filtro y fecha
                        Paragraph header = new Paragraph($"Filtro utilizado: {filtro}\nFecha de listado: {DateTime.Now:dd-MM-yy HH:mm}\n\n");
                        document.Add(header);

                        // Tabla
                        Table table = new Table(11); // 11 columnas
                        table.SetWidth(UnitValue.CreatePercentValue(90));

                        // Encabezados
                        table.AddCell("Código Prenda");
                        table.AddCell("Código Detalle");
                        table.AddCell("Descripción");
                        table.AddCell("Precio Venta");
                        table.AddCell("Nro Talle");
                        table.AddCell("Descripción Talle");
                        table.AddCell("Color");
                        table.AddCell("Costo Prenda");
                        table.AddCell("Estado");
                        table.AddCell("Cantidad");
                        table.AddCell("Observaciones");

                        // Datos
                        foreach (var estadoPrenda in listado)
                        {
                            table.AddCell(estadoPrenda.Prendas?.CodigoPrenda ?? string.Empty);
                            table.AddCell(estadoPrenda.CodigoDetalle ?? string.Empty);
                            table.AddCell(estadoPrenda.Prendas?.DescripcionPrenda ?? string.Empty);
                            table.AddCell(estadoPrenda.PrecioVenta.ToString());
                            table.AddCell(estadoPrenda.NroTalle ?? string.Empty);
                            table.AddCell(estadoPrenda.DescripcionTalle ?? string.Empty);
                            table.AddCell(estadoPrenda.Color ?? string.Empty);
                            table.AddCell(estadoPrenda.Costo.ToString());
                            table.AddCell(estadoPrenda.EstadoActual ?? string.Empty);
                            table.AddCell(estadoPrenda.CantidadEstado.ToString());
                            table.AddCell(estadoPrenda.Observaciones ?? string.Empty);
                        }

                        document.Add(table);
                        document.Close();
                    }
                    MessageBox.Show("Archivo PDF creado en la ubicación seleccionada!");
                }
            }
        }
    }
}


