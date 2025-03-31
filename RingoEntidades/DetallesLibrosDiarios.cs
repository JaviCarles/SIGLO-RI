using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesLibrosDiarios
    {
        [Key]
        public int? IdDetalleLibroDiario { get; set; }

        [ForeignKey("LibrosDiarios")]
        public int IdLibroDiario { get; set; }

        [ForeignKey("MediosPagos")]
        public int? IdMedioPago { get; set; }

        [ForeignKey("Ventas")]
        public int? IdVenta { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd 'de' MMMM 'de' yyyy HH:mm 'hs'}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Ingreso { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Egreso { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Margen { get; set; }

        public LibrosDiarios? LibrosDiarios { get; set; }

        public MediosPagos? MediosPagos { get; set; }

        public Ventas? Ventas { get; set; }

        [NotMapped]
        public string? MedioPago
        {
            get
            {
                if (MediosPagos != null)
                {
                    return MediosPagos.FormaPago;
                }
                return "No declara";
            } set
            {
                _medioPago = value;
            }
        }
        private string? _medioPago;

    }
}
