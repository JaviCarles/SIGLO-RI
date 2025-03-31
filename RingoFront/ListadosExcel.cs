using OfficeOpenXml;
using RingoEntidades;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoFront
{
    public class ListadosExcel
    {

        //Listado de personas en excel
        public static void ExportPersonasToExcel(List<Personas> personas, string filtroNombre, string filtroDni, string filtroCiudad)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Guardar archivo Excel";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Crear hoja de filtros
                        ExcelWorksheet filtrosWorksheet = excelPackage.Workbook.Worksheets.Add("Filtros");
                        filtrosWorksheet.Cells[1, 1].Value = "Filtros utilizados";
                        filtrosWorksheet.Cells[2, 1].Value = "DNI:";
                        filtrosWorksheet.Cells[2, 2].Value = filtroDni; // Ejemplo de filtro
                        filtrosWorksheet.Cells[2, 3].Value = "Nombres:";
                        filtrosWorksheet.Cells[2, 4].Value = filtroNombre; // Ejemplo de filtro
                        filtrosWorksheet.Cells[2, 5].Value = "Ciudad:";
                        filtrosWorksheet.Cells[2, 6].Value = filtroCiudad; // Ejemplo de filtro
                        filtrosWorksheet.Cells[3, 1].Value = "Fecha de listado:";
                        filtrosWorksheet.Cells[3, 2].Value = DateTime.Now.ToString("dd-MM-yy HH:mm");
                        filtrosWorksheet.Cells[4, 1].Value = "Listado en página siguiente";

                        // Crear hoja de listado
                        ExcelWorksheet listadoWorksheet = excelPackage.Workbook.Worksheets.Add("Listado");

                        // Agregar encabezados
                        listadoWorksheet.Cells[1, 1].Value = "DNI";
                        listadoWorksheet.Cells[1, 2].Value = "Nombre";
                        listadoWorksheet.Cells[1, 3].Value = "Apellidos";
                        listadoWorksheet.Cells[1, 4].Value = "Cuil";
                        listadoWorksheet.Cells[1, 5].Value = "FechaNacimiento";
                        listadoWorksheet.Cells[1, 6].Value = "Observaciones";
                        listadoWorksheet.Cells[1, 7].Value = "CondicionFiscal";
                        listadoWorksheet.Cells[1, 8].Value = "EstadoPersona";

                        // Agregar datos
                        int row = 2;
                        foreach (var persona in personas)
                        {
                            listadoWorksheet.Cells[row, 1].Value = persona.Dni;
                            listadoWorksheet.Cells[row, 2].Value = persona.Nombre;
                            listadoWorksheet.Cells[row, 3].Value = persona.Apellidos;
                            listadoWorksheet.Cells[row, 4].Value = persona.Cuil;
                            listadoWorksheet.Cells[row, 5].Value = persona.FechaNacimiento.HasValue ? persona.FechaNacimiento.Value.ToString("dd/MM/yyyy") : string.Empty;
                            listadoWorksheet.Cells[row, 6].Value = persona.Observaciones;
                            listadoWorksheet.Cells[row, 7].Value = persona.DetalleFiscal;
                            listadoWorksheet.Cells[row, 8].Value = persona.EstadoPersona;

                            row++;
                        }

                        // Guardar archivo
                        FileInfo fi = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(fi);
                    }

                    MessageBox.Show("Archivo de Excel creado en la ubicación seleccionada!");
                }
            }
        }

        public static void ExportEstadosPrendasToExcel(List<EstadosPrendas> estadosPrendasList, string filtro)
        {
            List<EstadosPrendas> listado = estadosPrendasList.OrderBy(e => e.DescripcionPrenda).ToList();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Guardar archivo Excel";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Configurar la licencia
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Crear hoja de filtros
                        ExcelWorksheet filtrosWorksheet = excelPackage.Workbook.Worksheets.Add("Filtros");
                        filtrosWorksheet.Cells[1, 1].Value = "Filtro utilizado: ";
                        filtrosWorksheet.Cells[1, 2].Value = filtro;
                        filtrosWorksheet.Cells[2, 1].Value = "Fecha de listado: ";
                        filtrosWorksheet.Cells[2, 2].Value = DateTime.Now.ToString("dd-MM-yy HH:mm");
                        filtrosWorksheet.Cells[4, 1].Value = "Listado en página siguiente";

                        // Crear hoja de listado
                        ExcelWorksheet listadoWorksheet = excelPackage.Workbook.Worksheets.Add("Listado");

                        // Agregar encabezados
                        listadoWorksheet.Cells[1, 1].Value = "Código Prenda";
                        listadoWorksheet.Cells[1, 2].Value = "Código Detalle";
                        listadoWorksheet.Cells[1, 3].Value = "Descripción";
                        listadoWorksheet.Cells[1, 4].Value = "Precio Venta";
                        listadoWorksheet.Cells[1, 5].Value = "Nro Talle";
                        listadoWorksheet.Cells[1, 6].Value = "Descripción Talle";
                        listadoWorksheet.Cells[1, 7].Value = "Color";
                        listadoWorksheet.Cells[1, 8].Value = "Costo Prenda";
                        listadoWorksheet.Cells[1, 9].Value = "Estado";
                        listadoWorksheet.Cells[1, 10].Value = "Cantidad";
                        listadoWorksheet.Cells[1, 11].Value = "Observaciones";

                        // Agregar datos
                        int row = 2;
                        foreach (var estadoPrenda in listado)
                        {
                            listadoWorksheet.Cells[row, 1].Value  = estadoPrenda.Prendas?.CodigoPrenda;
                            listadoWorksheet.Cells[row, 2].Value  = estadoPrenda.CodigoDetalle;
                            listadoWorksheet.Cells[row, 3].Value  = estadoPrenda.Prendas?.DescripcionPrenda;
                            listadoWorksheet.Cells[row, 4].Value  = estadoPrenda.PrecioVenta;
                            listadoWorksheet.Cells[row, 5].Value  = estadoPrenda.NroTalle;
                            listadoWorksheet.Cells[row, 6].Value  = estadoPrenda.DescripcionTalle;
                            listadoWorksheet.Cells[row, 7].Value  = estadoPrenda.Color;
                            listadoWorksheet.Cells[row, 8].Value  = estadoPrenda.Costo;
                            listadoWorksheet.Cells[row, 9].Value  = estadoPrenda.EstadoActual;
                            listadoWorksheet.Cells[row, 10].Value = estadoPrenda.CantidadEstado;
                            listadoWorksheet.Cells[row, 11].Value = estadoPrenda.Observaciones;

                            row++;
                        }

                        // Guardar archivo
                        FileInfo fi = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(fi);
                    }

                    MessageBox.Show("Archivo de Excel creado en la ubicación seleccionada!");
                }
            }
        }

    }
}
