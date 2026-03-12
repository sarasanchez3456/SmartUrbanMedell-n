<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="SmartUrbanMedellin.Web.Paginas.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header animate-up">
        <div>
            <h2 class="page-title">🏪 Proveedores</h2>
            <p class="text-slate-400 text-sm" style="margin-top: 0.125rem;">Gestiona los proveedores de servicio registrados</p>
        </div>
        <a href="/Paginas/RegistrarProveedor" class="btn-verde">+ Nuevo Proveedor</a>
    </div>

    <!-- Search bar -->
    <div class="card" style="padding: 1rem; margin-bottom: 1.5rem;">
        <div style="display: flex; gap: 0.75rem; align-items: center;">
            <span class="text-slate-400" style="font-size: 0.875rem; font-weight: 500;">🔍</span>
            <input id="busquedaBarrio" type="text" placeholder="Buscar por barrio: El Poblado, Laureles, Envigado..." class="input" style="flex: 1;" onkeyup="buscarEnMapa(this.value)" />
            <button onclick="buscarEnMapa(document.getElementById('busquedaBarrio').value)" class="btn-verde">Buscar</button>
        </div>
    </div>

    <div style="display: grid; grid-template-columns: 1fr; gap: 1.5rem;" class="lg:grid-cols-2">
        <!-- Table -->
        <div class="card" style="overflow: hidden;">
            <div class="card-header azul">Lista de Proveedores</div>
            <div style="overflow-x: auto;">
                <table class="data-table">
                    <thead>
                        <tr>
                            <th>Razón Social</th>
                            <th>Contacto</th>
                            <th>Teléfono</th>
                            <th style="text-align: center;">Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptProveedores" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="font-weight: 600; color: #0F1523;"><%# Eval("RazonSocial") %></td>
                                    <td style="color: #64748b;"><%# Eval("Contacto") %></td>
                                    <td style="color: #64748b; font-family: monospace; font-size: 0.75rem;"><%# Eval("Telefono") %></td>
                                    <td style="text-align: center;">
                                        <a href='/Paginas/EditarProveedor.aspx?id=<%# Eval("IdProveedor") %>' class="badge badge-azul" style="margin-right: 0.25rem;">✏️ Editar</a>
                                        <button onclick="confirmarEliminar('<%# Eval("RazonSocial") %>', '<%# Eval("IdProveedor") %>')" class="badge badge-rojo" style="border: 0; cursor: pointer;">🗑️</button>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trSinDatos" runat="server" visible="false">
                            <td colspan="4" style="text-align: center; color: #cbd5e1; padding: 3rem 1rem;">
                                <span style="font-size: 1.875rem; display: block; margin-bottom: 0.5rem;">🏪</span>
                                No hay proveedores registrados aún
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <!-- Map -->
        <div class="card" style="overflow: hidden;">
            <div class="card-header verde">📍 Ubicación de Proveedores</div>
            <div class="mapa-box" id="mapa-proveedores"></div>
        </div>
    </div>

    <script type="text/javascript">
        var provGeo = [];
        var mapaP;
        
        document.addEventListener('DOMContentLoaded', function() {
            cargarProveedores();
        });

        function cargarProveedores() {
            mapaP = crearMapa('mapa-proveedores', 6.2442, -75.5812, 12);
            if (!mapaP) return;
            
            mapaP.on('load', function() {
                for (var i = 0; i < provGeo.length; i++) {
                    var p = provGeo[i];
                    if (p.lat && p.lng) {
                        agregarPin(mapaP, p.lng, p.lat, p.razonSocial, '#00C47A');
                    }
                }
            });
        }

        function buscarEnMapa(texto) {
            if (!texto || !texto.trim()) return;
            var url = 'https://api.maptiler.com/geocoding/' + encodeURIComponent(texto + ', Medellín, Colombia') + '.json?key=' + MAPTILER_KEY + '&limit=1';
            fetch(url).then(function(r) { return r.json(); }).then(function(data) {
                if (data.features && data.features.length > 0) {
                    var coord = data.features[0].center;
                    var lng = coord[0];
                    var lat = coord[1];
                    if (mapaP) {
                        mapaP.flyTo({ center: [lng, lat], zoom: 14, duration: 1200 });
                        agregarPin(mapaP, lng, lat, '🔍 ' + texto, '#1B3FE4');
                    }
                }
            });
        }

        function confirmarEliminar(nombre, id) {
            if (confirm('¿Eliminar a ' + nombre + '?')) {
                eliminarProveedor(id);
            }
        }

        function eliminarProveedor(id) {
            // TODO: Llamar al endpoint para eliminar
            window.location.href = '/Paginas/Proveedores.aspx?eliminar=' + id;
        }
    </script>
</asp:Content>
