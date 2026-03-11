using Microsoft.Data.SqlClient;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.DAL
{
    public class UsuarioDAL
    {
        public List<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("SELECT * FROM Usuarios", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(Mapear(dr));
            return lista;
        }

        public Usuario? ObtenerPorId(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("SELECT * FROM Usuarios WHERE IdUsuario=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using var dr = cmd.ExecuteReader();
            return dr.Read() ? Mapear(dr) : null;
        }

        public void Insertar(Usuario u)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Usuarios(Nombre,Telefono,Email,TipoUsuario) VALUES(@no,@te,@em,@ti)", con);
            cmd.Parameters.AddWithValue("@no", u.Nombre);
            cmd.Parameters.AddWithValue("@te", u.Telefono);
            cmd.Parameters.AddWithValue("@em", u.Email);
            cmd.Parameters.AddWithValue("@ti", u.TipoUsuario);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Usuario u)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "UPDATE Usuarios SET Nombre=@no,Telefono=@te,Email=@em,TipoUsuario=@ti WHERE IdUsuario=@id", con);
            cmd.Parameters.AddWithValue("@no", u.Nombre);
            cmd.Parameters.AddWithValue("@te", u.Telefono);
            cmd.Parameters.AddWithValue("@em", u.Email);
            cmd.Parameters.AddWithValue("@ti", u.TipoUsuario);
            cmd.Parameters.AddWithValue("@id", u.IdUsuario);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("DELETE FROM Usuarios WHERE IdUsuario=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private Usuario Mapear(SqlDataReader dr) => new()
        {
            IdUsuario = (int)dr["IdUsuario"],
            Nombre = dr["Nombre"]?.ToString() ?? string.Empty,
            Telefono = dr["Telefono"]?.ToString() ?? string.Empty,
            Email = dr["Email"]?.ToString() ?? string.Empty,
            TipoUsuario = dr["TipoUsuario"]?.ToString() ?? string.Empty,
        };
    }
}