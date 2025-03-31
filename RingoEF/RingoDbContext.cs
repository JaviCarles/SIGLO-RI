using Microsoft.EntityFrameworkCore;
using RingoEntidades;
using System.Configuration;

namespace RingoEF
{
    public class RingoDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteParaReporte>().HasNoKey();
            modelBuilder.Entity<MesParaReporte>().HasNoKey();
            modelBuilder.Entity<PrendasVendidasPorProveedor>().HasNoKey();
            modelBuilder.Entity<CantPrendasPorProveedor>().HasNoKey();
            modelBuilder.Entity<CantidadVentasPorCategoria>().HasNoKey();
            modelBuilder.Entity<CantidadPrendasPorCategoria>().HasNoKey();
            modelBuilder.Entity<MovimientoFinanzasDiario>().HasNoKey();
        }
        /*En esta clase RingoDBContext lo que digo es que tenemos todas estas en mi contexto(usuario,cliente,etc.)
          estas clases se crearán como tablas de la Db.*/
            // public DbSet<Usuarios1> usuarios { get; set; }   // DbSet es otra clase de Entity Framework
       
        public DbSet<MovimientoFinanzasDiario> MovimientoFinanzasDiario { get; set; }
        public DbSet<CantidadPrendasPorCategoria> CantidadPrendasPorCategoria { get; set; }
        public DbSet<CantidadVentasPorCategoria> CantidadVentasPorCategorias {  get; set; }
        public DbSet<CantPrendasPorProveedor> CantPrendasPorProveedors { get; set; }
        public DbSet<PrendasVendidasPorProveedor> PrendasVendidasPorProveedors { get; set; }
        public DbSet<MesParaReporte> MesParaReportes { get; set; }
        public DbSet<Provincias> Provincias { get; set; }  // DbSet es otra clase de Entity Framework
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Barrios> Barrios { get; set; }
        public DbSet<RedesSociales> RedesSociales { get; set; }
        public DbSet<UsersRedesSociales> UsersRedesSociales { get; set; }
        public DbSet<CondicionesFiscales> CondicionesFiscales { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Credenciales> Credenciales { get; set; }
        public DbSet<UsuariosCredenciales> UsuariosCredenciales { get; set; }
        public DbSet<Domicilios> Domicilios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Puestos> Puestos { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<EstadosHistorias> EstadosHistorias { get; set; }
        public DbSet<Telas> Telas { get; set; }
        public DbSet<Talles> Talles { get; set; }
        public DbSet<CategoriasPrendas> CategoriasPrendas { get; set; }
        public DbSet<SubCategoriasPrendas> SubCategoriasPrendas { get; set; }
        public DbSet<Prendas> Prendas { get; set; }
        public DbSet<DetallesPrendas> DetallesPrendas { get; set; }
        public DbSet<CategoriaSubCategoria> CategoriaSubCategoria {  get; set; }
        public DbSet<PedidosProveedores> PedidosProveedores { get; set; }
        public DbSet<LibrosDiarios> LibrosDiarios { get; set; }
        public DbSet<DetallesLibrosDiarios> DetallesLibrosDiarios { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<DetallesCompras> DetallesCompras { get; set; }
        public DbSet<EntidadesTarjetas> EntidadesTarjetas { get; set; }
        public DbSet<Tarjetas> Tarjetas { get; set; }
        public DbSet<TarjetasEntidades> TarjetasEntidades { get; set; }
        public DbSet<MediosPagos> MediosPagos { get; set; }
        public DbSet<TiposFacturas> TiposFacturas { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<DetallesFacturas> DetallesFacturas { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<DetallesInventarios> DetallesInventarios { get; set; }
        public DbSet<PedidosClientes> PedidosClientes { get; set; }
        public DbSet<DetallesPedidosClientes> DetallesPedidosClientes { get; set; }
        public DbSet<DetallesPedidosProveedores> DetallesPedidosProveedores { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<DetallesVentas> DetallesVentas { get; set; }
        public DbSet<DevolucionesClientes> DevolucionesClientes { get; set; }
        public DbSet<DetallesDevoluciones> DetallesDevoluciones { get; set; }
        public DbSet<DevolucionesProveedores> DevolucionesProveedores { get; set; }
        public DbSet<DetallesDevolucionesProveedores> DetallesDevolucionesProveedores { get; set; }
        public DbSet<EstadosNC> EstadosNC { get; set; }
        public DbSet<EstadosPrendas> EstadosPrendas { get; set; }
        public DbSet<FondosCajas> FondosCajas { get; set; }
        public DbSet<Reportes> Reportes { get; set; }
        public DbSet<DetallesReportes> DetallesReportes { get; set; }
        public DbSet<ClienteParaReporte> ClienteParaReporte { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            optionsBuilder.UseSqlServer(connString);
        }
    }
}