namespace SmartUrbanMedellin.ENT
{
    public class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int IdSolicitud { get; set; }
        public int Puntuacion { get; set; }
        public string Comentario { get; set; } = string.Empty;
    }
}