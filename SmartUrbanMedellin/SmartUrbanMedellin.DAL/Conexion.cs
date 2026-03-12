using System.Data.SqlClient;
using System.Configuration;

namespace SmartUrbanMedellin.DAL
{
    public class Conexion
    {
        private static readonly string Cadena = 
            ConfigurationManager.ConnectionStrings["SmartUrbanDB"]?.ConnectionString
            ?? "Data Source=.;Initial Catalog=SmartUrbanMedellin;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection ObtenerConexion() => new SqlConnection(Cadena);
    }
}
