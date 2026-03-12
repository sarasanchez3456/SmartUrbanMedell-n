using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.DAL
{
    public class ProveedorDAL
    {
        public List<Proveedor> ObtenerTodos()
        {
            var lista = new List<Proveedor>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(@"
                SELECT p.*, s.NombreServicio
                FROM Proveedores p
                LEFT JOIN Servicios s ON p.IdServicio = s.IdServicios", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(Mapear(dr));
            return lista;
        }

        public Proveedor? ObtenerPorId(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(@"
                SELECT p.*, s.NombreServicio
                FROM Proveedores p
                LEFT JOIN Servicios s ON p.IdServicio = s.IdServicios
                WHERE p.IdProveedor=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using var dr = cmd.ExecuteReader();
            return dr.Read() ? Mapear(dr) : null;
        }

        public void Insertar(Proveedor p)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Proveedores(Nombre,Telefono,IdServicio) VALUES(@no,@te,@is)", con);
            cmd.Parameters.AddWithValue("@no", p.Nombre);
            cmd.Parameters.AddWithValue("@te", p.Telefono);
            cmd.Parameters.AddWithValue("@is", p.IdServicio);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Proveedor p)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "UPDATE Proveedores SET Nombre=@no,Telefono=@te,IdServicio=@is WHERE IdProveedor=@id", con);
            cmd.Parameters.AddWithValue("@no", p.Nombre);
            cmd.Parameters.AddWithValue("@te", p.Telefono);
            cmd.Parameters.AddWithValue("@is", p.IdServicio);
            cmd.Parameters.AddWithValue("@id", p.IdProveedor);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("DELETE FROM Proveedores WHERE IdProveedor=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private Proveedor Mapear(SqlDataReader dr) => new()
        {
            IdProveedor = (int)dr["IdProveedor"],
            Nombre = dr["Nombre"]?.ToString() ?? string.Empty,
            Telefono = dr["Telefono"]?.ToString() ?? string.Empty,
            IdServicio = dr["IdServicio"] != DBNull.Value ? (int)dr["IdServicio"] : 0,
            NombreServicio = dr["NombreServicio"]?.ToString() ?? string.Empty,
        };
    }
}