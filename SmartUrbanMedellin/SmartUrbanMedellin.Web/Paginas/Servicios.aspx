<%@ Page Title="Servicios" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="SmartUrbanMedellin.Web.Paginas.Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header animate-up">
        <div>
            <h2 class="page-title">🛠️ Servicios Disponibles</h2>
            <p class="text-slate-400 text-sm" style="margin-top: 0.125rem;">Encuentra el servicio que necesitas en tu zona</p>
        </div>
    </div>

    <!-- Búsqueda -->
    <div class="card" style="padding: 1rem; margin-bottom: 1.5rem;">
        <p style="font-size: 0.75rem; font-weight: 600; color: #64748b; text-transform: uppercase; letter-spacing: 0.1em; margin-bottom: 0.75rem;">Buscar por zona</p>
        <div style="display: flex; gap: 0.75rem; flex-wrap: wrap;">
            <input id="zonaInput" type="text" placeholder="Ej: El Poblado, Laureles, Bello, Itagüí..." class="input" style="flex: 1; min-width: 12rem;" />
            <button onclick="buscarZona()" class="btn-primary">Ver en Mapa →</button>
        </div>
    </div>

    <!-- Map -->
    <div class="card" style="overflow: hidden; margin-bottom: 2rem;">
        <div class="card-header azul">🗺️ Servicios por Zona — Medellín y Área Metropolitana</div>
        <div class="mapa-box" id="mapa-servicios"></div>
    </div>

    <!-- Cards -->
    <div style="display: grid; grid-template-columns: repeat(1, 1fr); gap: 1rem;" class="sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
        <asp:Repeater ID="rptServicios" runat="server">
            <ItemTemplate>
                <div class="card" style="overflow: hidden;">
                    <div style="padding: 1rem 1.25rem; display: flex; align-items: center; gap: 0.75rem;" class='<%# GetColorClass(Eval("ColorBg").ToString()) %>'>
                        <span style="font-size: 1.875rem;"><%# Eval("Emoji") %></span>
                        <div>
                            <h3 style="font-family: 'Outfit', sans-serif; font-weight: 700; font-size: 1rem; color: white; line-height: 1.2; margin: 0;"><%# Eval("Nombre") %></h3>
                            <span style="font-size: 0.75rem; color: rgba(255,255,255,0.7);"><%# Eval("Categoria") %></span>
                        </div>
                    </div>
                    <div style="padding: 1rem;">
                        <p style="color: #64748b; font-size: 0.875rem; margin-bottom: 1rem; line-height: 1.5;"><%# Eval("Descripcion") %></p>
                        <a href='/Paginas/SolicitarServicio.aspx?idServicio=<%# Eval("IdServicio") %>' class="btn-primary" style="display: block; text-align: center; text-decoration: none; font-size: 0.875rem;">Solicitar →</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <script type="text/javascript">
        var mapaS;
        
        document.addEventListener('DOMContentLoaded', function() {
            mapaS = crearMapa('mapa-servicios', 6.2442, -75.5812, 11);
            if (!mapaS) return;
            
            mapaS.on('load', function() {
                agregarPin(mapaS, -75.5681, 6.2090, '⚡ Electricidad — El Poblado', '#1B3FE4');
                agregarPin(mapaS, -75.5950, 6.2442, '🔧 Plomería — Laureles', '#00C47A');
                agregarPin(mapaS, -75.5500, 6.2650, '🌿 Jardinería — Poblado', '#16a34a');
                agregarPin(mapaS, -75.6050, 6.2220, '🪚 Carpintería — Belén', '#F5C400');
                agregarPin(mapaS, -75.5812, 6.3100, '🎨 Pintura — Bello', '#ef4444');
                agregarPin(mapaS, -75.5900, 6.1750, '🧹 Limpieza — Envigado', '#7c3aed');
            });
        });

        function buscarZona() {
            var texto = document.getElementById('zonaInput').value.trim();
            if (!mapaS || !texto) return;
            var url = 'https://api.maptiler.com/geocoding/' + encodeURIComponent(texto + ', Medellín, Colombia') + '.json?key=' + MAPTILER_KEY + '&limit=1';
            fetch(url).then(function(r) { return r.json(); }).then(function(data) {
                if (data.features && data.features.length > 0) {
                    var coord = data.features[0].center;
                    mapaS.flyTo({ center: coord, zoom: 14, duration: 1000 });
                    agregarPin(mapaS, coord[0], coord[1], '🔍 ' + texto, '#1B3FE4');
                }
            });
        }
    </script>
</asp:Content>
