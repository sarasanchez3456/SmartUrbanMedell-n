using System;

namespace SmartUrbanMedellin.ENT
{
    public class Solicitud
    {
        // Para la BD
        public int IdSolicitud { get; set; }
        public int IdUsuario { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        
        // Alias para las vistas
        public int IdServicio { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string NombreProveedor { get; set; } = string.Empty;
    }
}