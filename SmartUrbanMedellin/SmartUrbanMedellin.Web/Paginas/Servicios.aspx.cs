using System;
using System.Collections.Generic;
using System.Web.UI;
using SmartUrbanMedellin.BLL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class Servicios : Page
    {
        public List<ServicioVM> Servicios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarServicios();
            }
        }

        private void CargarServicios()
        {
            try
            {
                var bll = new ServicioBLL();
                var servicios = bll.ObtenerTodos();
                
                if (servicios == null)
                {
                    servicios = new List<Servicio>();
                }
                
                // Convertir a ServicioVM con emojis y colores
                Servicios = new List<ServicioVM>();
                foreach (var s in servicios)
                {
                    Servicios.Add(new ServicioVM
                    {
                        IdServicio = s.IdServicio,
                        Nombre = s.Nombre,
                        Descripcion = s.Descripcion,
                        Categoria = s.Categoria,
                        Emoji = GetEmoji(s.Nombre),
                        ColorBg = GetColorBg(s.Nombre)
                    });
                }
                
                rptServicios.DataSource = Servicios;
                rptServicios.DataBind();
            }
            catch
            {
                // Datos de ejemplo en caso de error
                Servicios = new List<ServicioVM>
                {
                    new ServicioVM { IdServicio = 1, Nombre = "Electricidad", Descripcion = "Instalaciones eléctricas residenciales y comerciales.", Categoria = "Hogar", Emoji = "⚡", ColorBg = "bg-yellow-500" },
                    new ServicioVM { IdServicio = 2, Nombre = "Plomería", Descripcion = "Reparación de tuberías, sanitarios y filtraciones.", Categoria = "Hogar", Emoji = "🔧", ColorBg = "bg-blue-600" },
                    new ServicioVM { IdServicio = 3, Nombre = "Carpintería", Descripcion = "Muebles a la medida, reparaciones y acabados.", Categoria = "Construcción", Emoji = "🪚", ColorBg = "bg-amber-700" },
                    new ServicioVM { IdServicio = 4, Nombre = "Pintura", Descripcion = "Pintura interior y exterior, acabados decorativos.", Categoria = "Construcción", Emoji = "🎨", ColorBg = "bg-red-500" },
                    new ServicioVM { IdServicio = 5, Nombre = "Jardinería", Descripcion = "Mantenimiento de zonas verdes y jardines.", Categoria = "Exterior", Emoji = "🌿", ColorBg = "bg-green-600" },
                    new ServicioVM { IdServicio = 6, Nombre = "Limpieza", Descripcion = "Limpieza profunda de hogares y oficinas.", Categoria = "Hogar", Emoji = "🧹", ColorBg = "bg-violet-600" }
                };
                
                rptServicios.DataSource = Servicios;
                rptServicios.DataBind();
            }
        }

        private string GetEmoji(string nombre)
        {
            switch (nombre.ToLower())
            {
                case "electricidad": return "⚡";
                case "plomería": return "🔧";
                case "carpintería": return "🪚";
                case "pintura": return "🎨";
                case "jardinería": return "🌿";
                case "limpieza": return "🧹";
                default: return "🛠️";
            }
        }

        private string GetColorBg(string nombre)
        {
            switch (nombre.ToLower())
            {
                case "electricidad": return "bg-yellow";
                case "plomería": return "bg-blue";
                case "carpintería": return "bg-amber";
                case "pintura": return "bg-red";
                case "jardinería": return "bg-green";
                case "limpieza": return "bg-violet";
                default: return "bg-blue";
            }
        }

        public string GetColorClass(string colorBg)
        {
            switch (colorBg)
            {
                case "bg-yellow-500": return "servicio-yellow";
                case "bg-blue-600": return "servicio-blue";
                case "bg-amber-700": return "servicio-amber";
                case "bg-red-500": return "servicio-red";
                case "bg-green-600": return "servicio-green";
                case "bg-violet-600": return "servicio-violet";
                default: return "servicio-blue";
            }
        }
    }
}
