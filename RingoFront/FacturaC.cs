using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RingoEntidades;
using RingoFront.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoFront
{
    public class FacturaC
    {
        public void GenerarFacturaC(Personas cliente, string direccionCliente, List<DetallesVentas> detalles, decimal total, string nomArchivo, bool envio)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.Title = "Guardar Factura C";
                saveFileDialog.FileName = nomArchivo;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string nombreArchivo = saveFileDialog.FileName;

                    Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            // Convertir la imagen desde los recursos a byte[]
                            Bitmap logoBitmap = Resources.logo_Ringo;
                            // Ajusta esto para obtener tu imagen de los recursos
                            byte[] logoBytes = ImageToByteArray(logoBitmap);
                            page.Size(PageSizes.A4);
                            page.Margin(2, Unit.Centimetre);
                            page.DefaultTextStyle(x => x.FontSize(12));

                            // Encabezado
                            page.Header().Row(row =>
                            {
                                row.RelativeItem(2).Column(column =>
                                {
                                    column.Item().Text("Ringo Indumentaria").Bold().FontSize(18);
                                    column.Item().Text("Dirección: Majul 346");
                                    column.Item().Text("CUIT: 20-34660451-5");
                                    column.Item().Text("Condición ante el IVA: Monotributo");
                                });
                                row.RelativeItem().Column(logo =>
                                {
                                    logo.Item().Image(logoBytes);
                                });
                            });

                            /*
                            page.Header().Column(column =>
                            {
                                column.Item().Text("Ringo Indumentaria").Bold().FontSize(18);
                                column.Item().Text("Dirección: Majul 346");
                                column.Item().Text("CUIT: 20-34660451-5");
                                column.Item().Text("Condición ante el IVA: Monotributo");
                            });
                            */
                            // Contenido de la Página
                            page.Content().Column(column =>
                            {
                                column.Spacing(20);

                                // Información del Cliente
                                column.Item().PaddingVertical(1, Unit.Centimetre).Column(innerColumn =>
                                {
                                    innerColumn.Spacing(5);
                                    innerColumn.Item().Text($"Cliente: {cliente.Nombre} {cliente.Apellidos}").Bold();
                                    innerColumn.Item().Text($"Dirección: {direccionCliente}");
                                    innerColumn.Item().Text($"CUIT/DNI: {cliente.Dni}");
                                    innerColumn.Item().Text("Condición ante el IVA: Consumidor final");
                                });

                                // Detalles de la Factura
                                column.Item().PaddingVertical(1, Unit.Centimetre).Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Element(CellStyle).Text("Descripción");
                                        header.Cell().Element(CellStyle).Text("Cantidad");
                                        header.Cell().Element(CellStyle).Text("Precio Unitario");
                                        header.Cell().Element(CellStyle).Text("Subtotal");

                                        IContainer CellStyle(IContainer container)
                                        {
                                            return container.DefaultTextStyle(x => x.SemiBold()).BorderBottom(1).BorderColor(Colors.Black).Padding(5);
                                        }
                                    });

                                    foreach (DetallesVentas item in detalles)
                                    {
                                        table.Cell().Element(CellStyle).Text(item.DescripcionProducto);
                                        table.Cell().Element(CellStyle).Text(item.Cantidad.ToString());
                                        table.Cell().Element(CellStyle).Text($"$ {item.PrecioUnitario:N2}");
                                        table.Cell().Element(CellStyle).Text($"$ {item.SubTotal:N2}");

                                        IContainer CellStyle(IContainer container)
                                        {
                                            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5);
                                        }
                                    }
                                });

                                // Totales
                                column.Item().PaddingVertical(1, Unit.Centimetre).AlignRight().Text($"Total: $ {total:N2}").Bold();
                            });

                            // Pie de Página
                            page.Footer().AlignCenter().Column(column =>
                            {
                                column.Spacing(5);
                                column.Item().Text(text =>
                                {
                                    text.Span("Página ");
                                    text.CurrentPageNumber();
                                });

                                if (envio)
                                {
                                    column.Item().Text("Venta con envío a domicilio").Bold().FontSize(14);
                                    column.Item().Text("Recibí conforme el contenido declarado en esta factura");
                                    column.Item().Text("Firma: .........................................");
                                }
                            });
                        });
                    }).GeneratePdf(nombreArchivo);
                }
            }
        }


        private byte[] ImageToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

    }
}
