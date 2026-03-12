using System;
using System.Web.UI;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class Menu : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Mostrar el subtítulo en desktop
            subtitle.Style["display"] = "block";
        }
    }
}
