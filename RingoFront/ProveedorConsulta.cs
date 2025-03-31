using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoFront
{
    public class ProveedorConsulta
    {
        public int idProveedor {  get; set; }
        public int idEmpresa { get; set; }
        public string? cuit { get; set; }
        public string? razonSocial { get; set; }
        public string? condicionFiscal { get; set; }
        public string? estado { get; set; }
        public int? idDomicilio { get; set; }
        public string? direccion {  get; set; }
        public string? localidadProvincia { get; set; }
        public string? detalles { get; set; }

        public Proveedores? Proveedor { get; set; }
        public Domicilios? Domicilio { get; set; }

        public ProveedorConsulta(Proveedores? proveedor, Domicilios? domicilio)
        {
            Proveedor = proveedor;
            if (Proveedor == null || Proveedor.Empresas == null)
            {
                idProveedor = 0; idEmpresa = 0;
                razonSocial = "Error al traer proveedor";
                return;
            }

            idProveedor = (int)proveedor.IdProveedor;
            idEmpresa = Proveedor.IdEmpresa;
            cuit = Proveedor.Empresas.Cuit;
            razonSocial = Proveedor.Empresas.RazonSocial;
            condicionFiscal = Proveedor.Empresas.DetalleFiscal;
            estado = Proveedor.Estado;
            detalles = Proveedor.DetalleProveedor;

            Domicilio = domicilio;
            if (domicilio == null)
            {
                idDomicilio = 0;
                return;
            }

            string calle = domicilio.Calle ?? "";
            string nro = domicilio.Altura ?? "";
            string piso = domicilio.Piso ?? "";
            string depto = domicilio.Departamento ?? "";
            string barrio = "";
            Barrios? barrioDom = domicilio.Barrios;
            if (barrioDom != null)
            {
                barrio = "barrio "+barrioDom.NombreBarrio;
            }
            direccion = calle+nro+piso+depto+barrio;

            if (domicilio.Ciudades == null || domicilio.Ciudades.Provincias == null)
            {
                return;
            }

            localidadProvincia = $"{domicilio.Ciudades.NombreCiudad} - {domicilio.Ciudades.NombreProvincia}";
        }


    }
}
