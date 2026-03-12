using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.DAL
{
    public class ServicioDAL
    {
        public List<Servicio> ObtenerTodos()
        {
            var lista = new List<Servicio>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("SELECT * FROM Servicios", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(Mapear(dr));
            return lista;
        }

        public Servicio? ObtenerPorId(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("SELECT * FROM Servicios WHERE IdServicios=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using var dr = cmd.ExecuteReader();
            return dr.Read() ? Mapear(dr) : null;
        }

        public void Insertar(Servicio s)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Servicios(NombreServicio,Descripcion) VALUES(@no,@de)", con);
            cmd.Parameters.AddWithValue("@no", s.NombreServicio);
            cmd.Parameters.AddWithValue("@de", s.Descripcion);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Servicio s)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "UPDATE Servicios SET NombreServicio=@no,Descripcion=@de WHERE IdServicios=@id", con);
            cmd.Parameters.AddWithValue("@no", s.NombreServicio);
            cmd.Parameters.AddWithValue("@de", s.Descripcion);
            cmd.Parameters.AddWithValue("@id", s.IdServicios);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("DELETE FROM Servicios WHERE IdServicios=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private Servicio Mapear(SqlDataReader dr) => new()
        {
            IdServicios = (int)dr["IdServicios"],
            NombreServicio = dr["NombreServicio"]?.ToString() ?? string.Empty,
            Descripcion = dr["Descripcion"]?.ToString() ?? string.Empty,
        };
    }
}