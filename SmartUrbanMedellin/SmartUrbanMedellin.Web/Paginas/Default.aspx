<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartUrbanMedellin.Web.Paginas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero -->
    <section class="hero-section">
        <div class="hero-content">
            <span class="hero-badge">
                <span class="badge-dot"></span>
                Servicios activos en Medellín
            </span>
            <h1 class="hero-title">
                Tu ciudad, tus<br>
                <span class="text-verde">servicios.</span>
            </h1>
            <p class="hero-subtitle">
                Conectamos ciudadanos con plomeros, electricistas, carpinteros y más — rápido, seguro y cerca de ti.
            </p>
            <div class="hero-buttons">
                <a href="/Paginas/Servicios" class="btn-verde">
                    <span>Ver Servicios</span>
                    <span>→</span>
                </a>
                <a href="/Paginas/RegistrarProveedor" class="btn-secondary">
                    Ofrecer un servicio
                </a>
            </div>
        </div>
    </section>

    <!-- Stats -->
    <div class="stats-grid">
        <a href="/Paginas/Proveedores" class="stat-card">
            <span class="stat-emoji">🏪</span>
            <span class="stat-value" runat="server" id="lblProveedores">0</span>
            <span class="stat-label">Proveedores</span>
        </a>
        <a href="/Paginas/Servicios" class="stat-card">
            <span class="stat-emoji">🛠️</span>
            <span class="stat-value" runat="server" id="lblServicios">0</span>
            <span class="stat-label">Servicios</span>
        </a>
        <a href="/Paginas/Solicitudes" class="stat-card">
            <span class="stat-emoji">📋</span>
            <span class="stat-value" runat="server" id="lblSolicitudes">0</span>
            <span class="stat-label">Solicitudes</span>
        </a>
        <a href="/Paginas/CalificarServicio" class="stat-card">
            <span class="stat-emoji">⭐</span>
            <span class="stat-value" runat="server" id="lblCalificaciones">0</span>
            <span class="stat-label">Calificaciones</span>
        </a>
    </div>

    <!-- Map -->
    <div class="card">
        <div class="card-header azul">
            🗺️ <span>Servicios disponibles en Medellín</span>
        </div>
        <div class="card-body">
            <div id="mapa-inicio" class="mapa-box"></div>
        </div>
    </div>

    <script>
        document.addEventListener('DOMContentLoaded', function() {
            var mapContainer = document.getElementById('mapa-inicio');
            if (mapContainer && typeof maptilersdk !== 'undefined') {
                var map = new maptilersdk.Map({
                    container: 'mapa-inicio',
                    style: maptilersdk.MapStyle.STREETS,
                    center: [-75.5812, 6.2442],
                    zoom: 12
                });
                
                map.on('load', function() {
                    addMarker(-75.5681, 6.2530, '⚡ El Poblado — Electricidad', '#1B3FE4');
                    addMarker(-75.5900, 6.2700, '🔧 Laureles — Plomería', '#00C47A');
                    addMarker(-75.5750, 6.2100, '🏠 Envigado — Limpieza', '#7c3aed');
                    addMarker(-75.5812, 6.2442, '🪚 Centro — Carpintería', '#F5C400');
                    addMarker(-75.6050, 6.2600, '🎨 Belén — Pintura', '#ef4444');
                });
            }
        });

        function addMarker(lng, lat, title, color) {
            if (typeof marker !== 'undefined') {
                var el = document.createElement('div');
                el.className = 'custom-marker';
                el.style.backgroundColor = color;
                el.style.width = '30px';
                el.style.height = '30px';
                el.style.borderRadius = '50%';
                el.style.cursor = 'pointer';
                
                new maptilersdk.Marker(el)
                    .setLngLat([lng, lat])
                    .setPopup(new maptilersdk.Popup({ offset: 25 }).setHTML(
                        '<div class="marker-popup">' + title + '</div>'
                    ))
                    .addTo(map);
            }
        }
    </script>
</asp:Content>
