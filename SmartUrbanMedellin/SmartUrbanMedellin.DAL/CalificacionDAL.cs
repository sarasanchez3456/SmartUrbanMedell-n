using Microsoft.Data.SqlClient;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.DAL
{
    public class CalificacionDAL
    {
        public List<Calificacion> ObtenerTodos()
        {
            var lista = new List<Calificacion>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("SELECT * FROM Calificaciones", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(Mapear(dr));
            return lista;
        }

        public void Insertar(Calificacion c)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Calificaciones(IdSolicitud,Puntuacion,Comentario) VALUES(@is,@pu,@co)", con);
            cmd.Parameters.AddWithValue("@is", c.IdSolicitud);
            cmd.Parameters.AddWithValue("@pu", c.Puntuacion);
            cmd.Parameters.AddWithValue("@co", c.Comentario);
            cmd.ExecuteNonQuery();
        }

        private Calificacion Mapear(SqlDataReader dr) => new()
        {
            IdCalificacion = (int)dr["IdCalificacion"],
            IdSolicitud = (int)dr["IdSolicitud"],
            Puntuacion = (int)dr["Puntuacion"],
            Comentario = dr["Comentario"]?.ToString() ?? string.Empty,
        };
    }
}