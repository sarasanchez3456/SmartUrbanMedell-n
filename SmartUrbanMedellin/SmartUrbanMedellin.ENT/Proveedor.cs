namespace SmartUrbanMedellin.ENT
{
    public class Proveedor
    {
        // Para la BD
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = string.Empty;
        
        // Alias para las vistas
        public string RazonSocial { get => Nombre; set => Nombre = value; }
        public string Contacto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
    }
}