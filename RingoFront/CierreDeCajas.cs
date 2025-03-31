using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.Logging;
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
    public class CierreDeCajas
    {

        public bool imprimirCierreCajas(List<CajasConsulta> cajasConsultaList, decimal montoReal, decimal montoDeclarado)
        {
            bool exito = false;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.Title = "Guardar Cierre de Cajas";
                saveFileDialog.FileName = $"CierreCajas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string nombreArchivo = saveFileDialog.FileName;

                    try
                    {
                        string colorDiferencia = "#C0392B";
                        Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Size(PageSizes.A4);
                                page.Margin(2, Unit.Centimetre);
                                page.DefaultTextStyle(x => x.FontSize(12));

                                // Convertir la imagen desde los recursos a byte[]
                                Bitmap logoBitmap = Resources.logo_Ringo;
                                byte[] logoBytes = ImageToByteArray(logoBitmap);

                                // Encabezado
                                page.Header().Row(row =>
                                {
                                    row.RelativeItem(2).Column(column =>
                                    {
                                        column.Item().Text("Formulario de Cierre de Cajas").Bold().FontSize(18);
                                        column.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy}");
                                    });
                                    row.ConstantItem(100).Height(100).Image(logoBytes, ImageScaling.FitArea);
                                });

                                page.Content().Column(column =>
                                {
                                    column.Spacing(20);

                                    // Información del Resumen
                                    column.Item().PaddingVertical(1, Unit.Centimetre).Column(innerColumn =>
                                    {
                                        innerColumn.Spacing(5);
                                        innerColumn.Item().Text($"Monto Real: $ {montoReal:N2}");
                                        innerColumn.Item().Text($"Monto Declarado: $ {montoDeclarado:N2}");
                                        innerColumn.Item().Text(diferenciaTexto(montoReal, montoDeclarado, ref colorDiferencia)).Bold().FontSize(14).FontColor(QuestPDF.Infrastructure.Color.FromHex(colorDiferencia));
                                    });

                                    // Detalles de las Cajas
                                    if (cajasConsultaList != null)
                                    {
                                        column.Item().PaddingVertical(1, Unit.Centimetre).Table(table =>
                                        {
                                            table.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn();
                                                columns.RelativeColumn(2);
                                                columns.RelativeColumn(2);
                                                columns.RelativeColumn(2);
                                                columns.RelativeColumn(3);
                                                columns.RelativeColumn(2);
                                            });

                                            table.Header(header =>
                                            {
                                                header.Cell().Element(CellStyle).Text("Hora");
                                                header.Cell().Element(CellStyle).Text("Vendedor");
                                                header.Cell().Element(CellStyle).Text("Método de Pago");
                                                header.Cell().Element(CellStyle).Text("Tarjeta");
                                                header.Cell().Element(CellStyle).Text("Banco");
                                                header.Cell().Element(CellStyle).Text("Monto");

                                                IContainer CellStyle(IContainer container)
                                                {
                                                    return container.DefaultTextStyle(x => x.SemiBold())
                                                        .Border(1).BorderColor(Colors.Black) // Borde externo e interno
                                                        .Padding(5);
                                                }
                                            });

                                            foreach (CajasConsulta item in cajasConsultaList)
                                            {
                                                table.Cell().Element(CellStyle).Text(item.Hora);
                                                table.Cell().Element(CellStyle).Text(item.Vendedor);
                                                table.Cell().Element(CellStyle).Text(item.MedioDePago);
                                                table.Cell().Element(CellStyle).Text(item.Tarjeta ?? "-");
                                                table.Cell().Element(CellStyle).Text(item.Banco ?? "-");
                                                table.Cell().Element(CellStyle).Text($"$ {item.TotalFactura:N2}");

                                                IContainer CellStyle(IContainer container)
                                                {
                                                    return container.Border(1).BorderColor(Colors.Black) // Borde externo e interno
                                                        .Padding(5);
                                                }
                                            }
                                        });
                                    }
                                });

                                // Pie de Página
                                page.Footer().AlignCenter().Column(innerColumn =>
                                {
                                    // Declaración
                                    innerColumn.Item().PaddingVertical(1, Unit.Centimetre).AlignCenter().Text("Declaro que los datos en el presente formulario son verídicos y tomo responsabilidad por las diferencias que puedan generar los errores humanos que pueda haber ocasionado").Bold();
                                    // Firma
                                    innerColumn.Item().PaddingVertical(1, Unit.Centimetre).AlignCenter().Column(firmaColumn =>
                                    {
                                        firmaColumn.Item().Text("Firma: _______________________________");
                                        firmaColumn.Item().Text("Aclaración: _________________________");
                                    });

                                    innerColumn.Item().Text(text =>
                                    {
                                        text.Span("Página ");
                                        text.CurrentPageNumber();
                                    });
                                });
                            });
                        }).GeneratePdf(nombreArchivo);

                        exito = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Problemas para crear Pdf: " + ex.Message);
                        exito = false;
                    }
                }
            }

            return exito;
        }

        private byte[] ImageToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private string diferenciaTexto(decimal real, decimal declarado, ref string color)
        {
            decimal dif = 0;
            string diferencia = "";
            try
            {
                dif = declarado - real;
                if (dif > 0)
                {
                    color = "#0066FF"; // Cyan suave
                    diferencia = $"Sobrante de cajas de ${dif:N2}";
                }
                else if (dif < 0)
                {
                    dif = Math.Abs(dif);
                    color = "#C0392B"; // Rojo apagado
                    diferencia = $"Faltante de cajas de ${dif:N2}";
                }
                else
                {
                    color = "#20AE78"; // Verde suave
                    diferencia = "Sin diferencia de cajas";
                }
            }
            catch (Exception ex)
            {
                color = "#C0392B";
                return "Error al calcular: " + ex.Message;
            }
            return diferencia;
        }

    }
}
