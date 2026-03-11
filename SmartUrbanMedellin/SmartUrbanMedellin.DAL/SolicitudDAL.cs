using Microsoft.Data.SqlClient;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.DAL
{
    public class SolicitudDAL
    {
        public List<Solicitud> ObtenerTodos()
        {
            var lista = new List<Solicitud>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(@"
                SELECT s.*, u.Nombre AS NombreUsuario, p.Nombre AS NombreProveedor
                FROM Solicitudes s
                LEFT JOIN Usuarios    u ON s.IdUsuario   = u.IdUsuario
                LEFT JOIN Proveedores p ON s.IdProveedor = p.IdProveedor", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(Mapear(dr));
            return lista;
        }

        public Solicitud? ObtenerPorId(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(@"
                SELECT s.*, u.Nombre AS NombreUsuario, p.Nombre AS NombreProveedor
                FROM Solicitudes s
                LEFT JOIN Usuarios    u ON s.IdUsuario   = u.IdUsuario
                LEFT JOIN Proveedores p ON s.IdProveedor = p.IdProveedor
                WHERE s.IdSolicitud=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using var dr = cmd.ExecuteReader();
            return dr.Read() ? Mapear(dr) : null;
        }

        public void Insertar(Solicitud s)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(@"
                INSERT INTO Solicitudes(IdUsuario,IdProveedor,IdServicio,FechaSolicitud,Descripcion,Estado)
                VALUES(@iu,@ip,@is,@fe,@de,@es)", con);
            cmd.Parameters.AddWithValue("@iu", s.IdUsuario);
            cmd.Parameters.AddWithValue("@ip", s.IdProveedor);
            cmd.Parameters.AddWithValue("@is", s.IdServicio > 0 ? s.IdServicio : DBNull.Value);
            cmd.Parameters.AddWithValue("@fe", s.FechaSolicitud);
            cmd.Parameters.AddWithValue("@de", s.Descripcion);
            cmd.Parameters.AddWithValue("@es", s.Estado ?? string.Empty);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Solicitud s)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(@"
                UPDATE Solicitudes
                SET IdUsuario=@iu,IdProveedor=@ip,IdServicio=@is,FechaSolicitud=@fe,Descripcion=@de,Estado=@es
                WHERE IdSolicitud=@id", con);
            cmd.Parameters.AddWithValue("@iu", s.IdUsuario);
            cmd.Parameters.AddWithValue("@ip", s.IdProveedor);
            cmd.Parameters.AddWithValue("@is", s.IdServicio > 0 ? s.IdServicio : DBNull.Value);
            cmd.Parameters.AddWithValue("@fe", s.FechaSolicitud);
            cmd.Parameters.AddWithValue("@de", s.Descripcion);
            cmd.Parameters.AddWithValue("@es", s.Estado ?? string.Empty);
            cmd.Parameters.AddWithValue("@id", s.IdSolicitud);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("DELETE FROM Solicitudes WHERE IdSolicitud=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private Solicitud Mapear(SqlDataReader dr) => new()
        {
            IdSolicitud = (int)dr["IdSolicitud"],
            IdUsuario = dr["IdUsuario"] != DBNull.Value ? (int)dr["IdUsuario"] : 0,
            IdProveedor = dr["IdProveedor"] != DBNull.Value ? (int)dr["IdProveedor"] : 0,
            IdServicio = dr["IdServicio"] != DBNull.Value ? (int)dr["IdServicio"] : 0,
            FechaSolicitud = dr["FechaSolicitud"] != DBNull.Value
                                ? Convert.ToDateTime(dr["FechaSolicitud"]) : DateTime.Now,
            Descripcion = dr["Descripcion"]?.ToString() ?? string.Empty,
            Estado = dr["Estado"]?.ToString() ?? string.Empty,
            NombreUsuario = dr["NombreUsuario"]?.ToString() ?? string.Empty,
            NombreProveedor = dr["NombreProveedor"]?.ToString() ?? string.Empty,
        };
    }
}