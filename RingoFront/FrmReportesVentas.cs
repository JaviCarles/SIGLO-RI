using RingoEntidades;
using RingoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OpenTK.Graphics.OpenGL.GL;

namespace RingoFront
{
    public partial class FrmReportesVentas : Form
    {
        public FrmReportesVentas()
        {
            InitializeComponent();
        }

        int mesAnt, mesPost, añoAnt, añoPost;

        private void FrmReportesVentas_Load(object sender, EventArgs e)
        {
            dateTimePickerDesde.Value = DateTime.Now.AddMonths(-12);
            dateTimePickerHasta.Value = DateTime.Now.AddDays(+1);
            comboBoxTipoDeReporte.SelectedIndex = 0;
            comboBoxCantidad.SelectedIndex = 0;
            LlenarComboBoxAños();
            LlenarCombosAñosYMEsParaRepFinanzas();
            DiseñoUI.diseñoFront(this);
        }
        private void LlenarComboBoxAños()// carga los combos de años para el reporte comparativo anual de cantidad de ventas
        {
            try
            {
                int añoActual = DateTime.Now.Year;
                for (int i = 0; i <= 10; i++)
                {
                    comboAño1.Items.Add(añoActual - i);
                    comboAño2.Items.Add(añoActual - i);
                }
                comboAño1.SelectedIndex = 0;
                comboAño2.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puedo cargar el listado de años");
            }
        }

        private void LlenarCombosAñosYMEsParaRepFinanzas() // carga los combos de mes y año para el reporte comparativo de ingresos y egresos
        {
            try
            {
                int añoActual = DateTime.Now.Year;
                for (int i = 0; i <= 10; i++)
                {
                    comboBoxAñoAnterior.Items.Add(añoActual - i);
                    comboBoxAñoPosterior.Items.Add(añoActual - i);
                }

                comboBoxAñoAnterior.SelectedIndex = 0;
                comboBoxAñoPosterior.SelectedIndex = 0;
                comboBoxMesAnterior.SelectedIndex = 0;
                comboBoxMesPosterior.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los comboBox");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Form padre = Application.OpenForms["FrmPrincipal"] as Form;
            FrmReporteSeleccionado myForm = Application.OpenForms["FrmReportesSeleccionado"] as FrmReporteSeleccionado;


            if (myForm != null) // El formulario no está abierto
            {
                myForm.Close();
            }

            if (comboBoxTipoDeReporte.SelectedIndex == 0)
            {

                FrmReporteSeleccionado frmReportes = new FrmReporteSeleccionado();

                frmReportes.MdiParent = padre;
                frmReportes.Dock = DockStyle.Fill;
                frmReportes.cantidad = int.Parse(comboBoxCantidad.SelectedItem.ToString());
                frmReportes.fechaDesde = dateTimePickerDesde.Value;
                frmReportes.fechaHasta = dateTimePickerHasta.Value;

                if (radioButtonMayorAMenor.Checked)
                {
                    frmReportes.ordenAscendente = true;
                }
                else
                {
                    frmReportes.ordenAscendente = false;
                }

                if (comboBoxTipoDeReporte.SelectedIndex == 0)
                {
                    frmReportes.modo = EnumModoForm.ReporteUno;
                }

                frmReportes.Show();
            }
            else if (comboBoxTipoDeReporte.SelectedIndex == 1)
            {

                FrmReporteComparativo form = Application.OpenForms["FrmReporteComparativo"] as FrmReporteComparativo;

                if (form != null) // El formulario no está abierto
                {
                    form.Close();
                }

                FrmReporteComparativo frmReporte = new FrmReporteComparativo();

                frmReporte.MdiParent = padre;
                frmReporte.Dock = DockStyle.Fill;
                frmReporte.año1 = (int)comboAño1.SelectedItem;
                frmReporte.año2 = (int)comboAño2.SelectedItem;
                frmReporte.Show();
            }
            else if (comboBoxTipoDeReporte.SelectedIndex == 2)
            {
                FrmReporteVentasProveedores form = Application.OpenForms["FrmReporteVentasProveedores"] as FrmReporteVentasProveedores;

                if (form != null)
                {
                    form.Close();
                }

                FrmReporteVentasProveedores frmReporte = new FrmReporteVentasProveedores();
                frmReporte.MdiParent = padre;
                frmReporte.Dock = DockStyle.Fill;
                frmReporte.cantidad = int.Parse(comboBoxCantidad.SelectedItem.ToString());
                frmReporte.fechaDesde = dateTimePickerDesde.Value;
                frmReporte.fechaHasta = dateTimePickerHasta.Value;
                frmReporte.Show();
            }
            else if (comboBoxTipoDeReporte.SelectedIndex == 3)
            {
                FrmReporteDeVentasPorCategoria form = Application.OpenForms["FrmReporteDeVentasPorCategoria"] as FrmReporteDeVentasPorCategoria;

                if (form != null)
                {
                    form.Close();
                }

                FrmReporteDeVentasPorCategoria frmReporte = new FrmReporteDeVentasPorCategoria();

                frmReporte.MdiParent = padre;
                frmReporte.Dock = DockStyle.Fill;
                frmReporte.cantidad = int.Parse(comboBoxCantidad.SelectedItem.ToString());
                frmReporte.fechaDesde = dateTimePickerDesde.Value;
                frmReporte.fechaHasta = dateTimePickerHasta.Value;
                frmReporte.Show();
            }
            else if (comboBoxTipoDeReporte.SelectedIndex == 4)
            {
                try
                {
                    FrmReporteMovimientosFinanzas form = Application.OpenForms["FrmReporteMovimientosFinanzas"] as FrmReporteMovimientosFinanzas;

                    if (form != null)
                    {
                        form.Close();
                    }
                    int mesUno = Convert.ToInt32(comboBoxMesAnterior.SelectedItem);
                    int añoUno = (int)comboBoxAñoAnterior.SelectedItem;
                    int mesDos = Convert.ToInt32(comboBoxMesPosterior.SelectedItem);
                    int añoDos = (int)comboBoxAñoPosterior.SelectedItem;
                    List<MovimientoFinanzasDiario> listaMovimientoFinanzas = ReportesNegocio.GetMovimientoFinanzaDiario(mesUno, añoUno);
                    List<MovimientoFinanzasDiario> listaMovimientoFinanzas2 = ReportesNegocio.GetMovimientoFinanzaDiario(mesDos, añoDos);
                    //validación de listas, si algún més no posee ventas, no se abre el formulario.
                    if (listaMovimientoFinanzas.Count == 0)
                    {
                        MessageBox.Show("El mes anterior seleccionado no posee margen de ventas, seleccione un mes con ventas.");
                        return;
                    }
                    else if (listaMovimientoFinanzas2.Count == 0)
                    {
                        MessageBox.Show("El mes posterior seleccionado no posee margen de ventas, seleccione un mes con ventas.");
                        return;
                    }

                    FrmReporteMovimientosFinanzas frmReporte = new FrmReporteMovimientosFinanzas();
                    frmReporte.listaMovimientoFinanzas = listaMovimientoFinanzas;
                    frmReporte.listaMovimientoFinanzas2 = listaMovimientoFinanzas2;
                    frmReporte.MdiParent = padre;
                    frmReporte.Dock = DockStyle.Fill;
                    frmReporte.mes1 = Convert.ToInt32(comboBoxMesAnterior.SelectedItem);
                    frmReporte.mes2 = Convert.ToInt32(comboBoxMesPosterior.SelectedItem);
                    frmReporte.año1 = (int)comboBoxAñoAnterior.SelectedItem;
                    frmReporte.año2 = (int)comboBoxAñoPosterior.SelectedItem;
                    frmReporte.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar abrir FrmReporteMovimientosFinanzas");
                }
            }
        }

        private void comboBoxTipoDeReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoDeReporte.SelectedIndex == 0)
            {
                // comboAño1.Enabled = false;
                //comboAño2.Enabled = false;
                //dateTimePickerDesde.Enabled = true;
                //dateTimePickerHasta.Enabled = true;
                groupBoxDesdeHasta.Enabled = true;
                groupBoxOrden.Enabled = true;
                //comboBoxCantidad.Enabled = true;
                groupBoxCantidad.Enabled = true;
                groupBoxAñosComparar.Enabled = false;
                groupBoxAñosYMeses.Enabled = false;
            }
            else if (comboBoxTipoDeReporte.SelectedIndex == 1)
            {
                // comboAño1.Enabled = true;
                //comboAño2.Enabled = true;
                groupBoxAñosComparar.Enabled = true;
                //dateTimePickerDesde.Enabled = false;
                //dateTimePickerHasta.Enabled = false;
                groupBoxDesdeHasta.Enabled = false;
                groupBoxOrden.Enabled = false;
                //comboBoxCantidad.Enabled = false;
                groupBoxCantidad.Enabled = false;
                groupBoxAñosYMeses.Enabled = false;
            }
            else if (comboBoxTipoDeReporte.SelectedIndex == 2)
            {
                //comboAño1.Enabled = false;
                //comboAño2.Enabled = false;
                groupBoxAñosComparar.Enabled = false;
                //dateTimePickerDesde.Enabled = true;
                //dateTimePickerHasta.Enabled = true;
                groupBoxDesdeHasta.Enabled = true;
                groupBoxOrden.Enabled = false;
                //comboBoxCantidad.Enabled = true;
                groupBoxCantidad.Enabled = true;
                groupBoxAñosYMeses.Enabled = false;
            }
            else if (comboBoxTipoDeReporte.SelectedIndex == 3)
            {
                //comboAño1.Enabled = false;
                //comboAño2.Enabled = false;
                groupBoxAñosComparar.Enabled = false;
                //dateTimePickerDesde.Enabled = true;
                //dateTimePickerHasta.Enabled = true;
                groupBoxDesdeHasta.Enabled = true;
                groupBoxOrden.Enabled = false;
                //comboBoxCantidad.Enabled = true;
                groupBoxCantidad.Enabled = true;
                groupBoxAñosYMeses.Enabled = false;
            }
            else if (comboBoxTipoDeReporte.SelectedIndex == 4)
            {
                //comboAño1.Enabled = false;
                //comboAño2.Enabled = false;
                groupBoxAñosComparar.Enabled = false;
                //dateTimePickerDesde.Enabled = false;
                //dateTimePickerHasta.Enabled = false;
                groupBoxDesdeHasta.Enabled = false;
                groupBoxOrden.Enabled = false;
                //comboBoxCantidad.Enabled = false;
                groupBoxCantidad.Enabled = false;
                groupBoxAñosYMeses.Enabled = true;
            }
        }

        private void comboAño1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTipoDeReporte.SelectedIndex == 1)
                {
                    int num1 = int.Parse(comboAño1.SelectedItem.ToString());
                    int num2 = int.Parse(comboAño2.SelectedItem.ToString());

                    if (num1 <= num2)
                    {
                        MessageBox.Show("No se puede seleccionar un año menor o igual al que se va a comparar.");
                        comboAño1.SelectedIndex = comboAño2.SelectedIndex - 1;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en el comboBox comboAño1");
            }
        }

        private void comboAño2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTipoDeReporte.SelectedIndex == 1)
                {
                    int num1 = int.Parse(comboAño1.SelectedItem.ToString());
                    int num2 = int.Parse(comboAño2.SelectedItem.ToString());

                    if (num1 <= num2)
                    {
                        MessageBox.Show("No se puede seleccionar un año mayor o igual al que se va a comparar.");
                        comboAño2.SelectedIndex = comboAño1.SelectedIndex + 1;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en el comboBox comboAño2");
            }
        }

        public void cargarMesYAño() //actualiza las variables mesAnt, mesPost, añoAnt, añoPost.
        {
            try
            {
                mesAnt = int.Parse(comboBoxMesAnterior.SelectedItem.ToString());
                mesPost = int.Parse(comboBoxMesPosterior.SelectedItem.ToString());
                añoAnt = int.Parse(comboBoxAñoAnterior.SelectedItem.ToString());
                añoPost = int.Parse(comboBoxAñoPosterior.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en el método cargarMesYAño.");
            }
        }

        public void validarMesYAño()
        {
            if (comboBoxTipoDeReporte.SelectedIndex == 4)
            {
                cargarMesYAño();

                if (añoAnt == añoPost & mesAnt >= mesPost)
                {
                    MessageBox.Show("Si compara meses del mismo año, el mes anterior debe ser inferior al mes porterior");
                    if (comboBoxMesPosterior.SelectedIndex == 0)
                    {
                        comboBoxMesPosterior.SelectedIndex = 1;
                        comboBoxMesAnterior.SelectedIndex = 0;
                    }
                    else
                        comboBoxMesAnterior.SelectedIndex = comboBoxMesPosterior.SelectedIndex - 1;
                }
                if (añoAnt > añoPost)
                {
                    MessageBox.Show("El año anterior no puede ser mayor al posterior");
                    if (comboBoxAñoPosterior.SelectedIndex == 10)
                    {
                        comboBoxAñoPosterior.SelectedIndex = 9;
                        comboBoxAñoAnterior.SelectedIndex = 10;
                    }
                    else
                        comboBoxAñoAnterior.SelectedIndex = comboBoxAñoPosterior.SelectedIndex + 1;
                }

            }
        }
        private void comboBoxAñoAnterior_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validarMesYAño();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en el comboBoxAñoAnterior");
            }
        }

        private void comboBoxMesAnterior_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validarMesYAño();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en el comboBoxMesAnterior");
            }
        }

        private void comboBoxMesPosterior_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validarMesYAño();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en el comboBoxMesPosterior");
            }
        }

        private void comboBoxAñoPosterior_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validarMesYAño();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en el comboBoxAñoPosterior");
            }
        }

        private void dateTimePickerDesde_ValueChanged(object sender, EventArgs e)
        {   // Verifica que la fecha "Desde" no sea mayor o igual que la fecha "Hasta"
            try
            {
                if (dateTimePickerDesde.Value.Date >= dateTimePickerHasta.Value.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser igual o superior a la fecha 'Hasta'.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Restaura la fecha anterior o ajusta según sea necesario
                    dateTimePickerDesde.Value = dateTimePickerHasta.Value.AddDays(-1);
                }

                // Verifica que la fecha "Desde" no sea superior a la fecha actual
                if (dateTimePickerDesde.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser superior a la fecha actual.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Ajusta la fecha al día antes de "desde"
                    dateTimePickerDesde.Value = dateTimePickerHasta.Value.AddDays(-1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al validar las fechas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            { // Verifica que la fecha "Hasta" no sea menor o igual que la fecha "Desde"
                if (dateTimePickerHasta.Value.Date <= dateTimePickerDesde.Value.Date) 
                { 
                    MessageBox.Show("La fecha 'Hasta' no puede ser igual o inferior a la fecha 'Desde'.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    
                    // Restaura la fecha anterior o ajusta según sea necesario
                    dateTimePickerHasta.Value = dateTimePickerDesde.Value.AddDays(1); 
                } 
                
                // Verifica que la fecha "Hasta" no sea superior a la fecha actual
                if (dateTimePickerHasta.Value.Date > DateTime.Now.Date.AddDays(1)) 
                { 
                    MessageBox.Show("La fecha 'Hasta' no puede superar más de un día a la actual.", 
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    
                    // Ajusta la fecha al día actual
                    dateTimePickerHasta.Value = DateTime.Now.Date.AddDays(1); 
                } 
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show("Ocurrió un error al validar las fechas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
