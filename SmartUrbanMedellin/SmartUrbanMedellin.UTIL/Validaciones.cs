using System.Text.RegularExpressions;

namespace SmartUrbanMedellin.UTIL
{
    public static class Validaciones
    {
        public static bool EsCorreoValido(string correo) =>
            Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public static bool EsTelefonoValido(string tel) =>
            Regex.IsMatch(tel, @"^\d{7,10}$");

        public static bool EsCampoVacio(string valor) =>
            string.IsNullOrWhiteSpace(valor);
    }
}