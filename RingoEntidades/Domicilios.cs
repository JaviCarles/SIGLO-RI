using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Domicilios
    {
        [Key]
        public int? IdDomicilio { get; set; }

        [MaxLength(100)]
        public string? Calle { get; set; }

        [MaxLength(10)]
        public string? Altura { get; set; }

        [MaxLength(10)]
        public string? Piso { get; set; }

        [MaxLength(10)]
        public string? Departamento { get; set;}

        [MaxLength(200)]
        public string? ObservacionesBarrio { get; set; }

        [ForeignKey("Ciudades")]
        public int? IdCiudad { get; set; }

        [ForeignKey("Barrios")]
        public int? IdBarrio { get; set; }

        [ForeignKey("Personas")]
        public int? IdPersona { get; set; }
        
        public Ciudades? Ciudades { get; set; }
        
        public Barrios? Barrios { get; set; }
        
        public Personas? Personas { get; set; }

        [NotMapped]
        public string? DomicilioCompleto
        {
            get
            {
                return $"{NombreBarrio ?? ""}{CalleCompleta ?? ""}";
            }
        }

        [NotMapped]
        public string? CalleCompleta
        {
            get
            {
                string? result = "";
                if (!String.IsNullOrWhiteSpace(Calle))
                {
                    result = Calle.ToString()+" ";
                }
                if (!String.IsNullOrWhiteSpace(Altura))
                {
                    result += Altura.ToString();
                }
                if (!String.IsNullOrWhiteSpace(Piso))
                {
                    result += " | " + Piso.ToString() + " ";
                }
                if (!String.IsNullOrWhiteSpace(Departamento))
                {
                    result+= Departamento.ToString() + " ";
                }
                return result;
            }
        }

        [NotMapped]
        public string? NombreCiudad
        {
            get
            {
                if (Ciudades != null)
                    return Ciudades.NombreCiudad;
                else
                    return null;
            }
        }

        [NotMapped]
        public int? CodigoPostal
        {
            get
            {
                if (Ciudades != null)
                    return Ciudades.CodigoPostal;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? NombreBarrio
        {
            get
            {
                if (Barrios != null)
                    return $"Barrio: {Barrios.NombreBarrio} | ";
                else
                    return null;
            }
        }


        [NotMapped]
        public string? Nombres
        {
            get
            {
                if (Personas != null)
                    return Personas.Nombre;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Apellidos
        {
            get
            {
                if (Personas != null)
                    return Personas.Apellidos;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? DNI
        {
            get
            {
                if (Personas != null)
                    return Personas.Dni;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? EstadoPersona
        {
            get
            {
                if (Personas != null)
                    return Personas.EstadoPersona;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? CondFiscal
        {
            get
            {
                if (Personas != null)
                    return Personas.DetalleFiscal;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? CUIL
        {
            get
            {
                if (Personas != null)
                    return Personas.Cuil;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Observaciones
        {
            get
            {
                if (Personas != null)
                    return Personas.Observaciones;
                else
                    return null;
            }
        }
    }
}
