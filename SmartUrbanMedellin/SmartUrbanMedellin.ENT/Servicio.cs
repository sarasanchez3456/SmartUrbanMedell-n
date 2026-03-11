namespace SmartUrbanMedellin.ENT
{
    public class Servicio
    {
        // Para la BD
        public int IdServicios { get; set; }
        public string NombreServicio { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        
        // Alias para las vistas
        public int IdServicio { get => IdServicios; set => IdServicios = value; }
        public string Nombre { get => NombreServicio; set => NombreServicio = value; }
        public string Categoria { get; set; } = string.Empty;
    }
}