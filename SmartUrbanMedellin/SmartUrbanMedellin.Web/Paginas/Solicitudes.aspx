<%@ Page Title="Solicitudes" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="SmartUrbanMedellin.Web.Paginas.Solicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header animate-up">
        <div>
            <h2 class="page-title">📋 Solicitudes</h2>
            <p class="text-slate-400 text-sm" style="margin-top: 0.125rem;">Historial y estado de tus solicitudes de servicio</p>
        </div>
        <a href="/Paginas/SolicitarServicio" class="btn-verde">+ Nueva Solicitud</a>
    </div>

    <!-- Leyenda + mapa -->
    <div class="card" style="overflow: hidden; margin-bottom: 1.5rem;">
        <div class="card-header azul" style="display: flex; gap: 1.5rem; align-items: center; flex-wrap: wrap;">
            <span>🗺️ Solicitudes Activas en el Mapa</span>
            <div style="margin-left: auto; display: flex; gap: 1rem; font-size: 0.75rem; font-weight: 500;">
                <span style="display: flex; align-items: center; gap: 0.375rem;">
                    <span style="width: 0.625rem; height: 0.625rem; border-radius: 50%; background: #F5C400; display: inline-block;"></span>Pendiente
                </span>
                <span style="display: flex; align-items: center; gap: 0.375rem;">
                    <span style="width: 0.625rem; height: 0.625rem; border-radius: 50%; background: #00C47A; display: inline-block;"></span>Activo
                </span>
                <span style="display: flex; align-items: center; gap: 0.375rem;">
                    <span style="width: 0.625rem; height: 0.625rem; border-radius: 50%; background: #ef4444; display: inline-block;"></span>Cancelado
                </span>
            </div>
        </div>
        <div class="mapa-box" id="mapa-solicitudes"></div>
    </div>

    <!-- Table -->
    <div class="card" style="overflow: hidden;">
        <div class="card-header grafito">Listado de Solicitudes</div>
        <div style="overflow-x: auto;">
            <table class="data-table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Servicio</th>
                        <th>Fecha</th>
                        <th>Estado</th>
                        <th style="text-align: center;">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptSolicitudes" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="font-family: monospace; color: #64748b; font-size: 0.75rem;">#<%# Eval("IdSolicitud") %></td>
                                <td style="font-weight: 600; color: #0F1523;">Servicio <%# Eval("IdServicio") %></td>
                                <td style="color: #64748b;"><%# Eval("FechaSolicitud", "{0:dd/MM/yyyy}") %></td>
                                <td>
                                    <span class='<%# GetBadgeClass(Eval("Estado").ToString()) %>'><%# Eval("Estado") %></span>
                                </td>
                                <td style="text-align: center;">
                                    <a href='/Paginas/CalificarServicio.aspx?id=<%# Eval("IdSolicitud") %>' class="badge badge-amarillo">⭐ Calificar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="trSinSolicitudes" runat="server" visible="false">
                        <td colspan="5" style="text-align: center; color: #cbd5e1; padding: 3rem 1rem;">
                            <span style="font-size: 1.875rem; display: block; margin-bottom: 0.5rem;">📋</span>
                            No hay solicitudes aún
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var solGeo = [];
        
        document.addEventListener('DOMContentLoaded', function() {
            var m = crearMapa('mapa-solicitudes', 6.2442, -75.5812, 12);
            if (!m) return;
            
            m.on('load', function() {
                var colores = { 'Pendiente': '#F5C400', 'Activo': '#00C47A', 'Cancelado': '#ef4444' };
                for (var i = 0; i < solGeo.length; i++) {
                    var s = solGeo[i];
                    if (s.lat && s.lng) {
                        agregarPin(m, s.lng, s.lat, '#' + s.id + ' — ' + s.estado, colores[s.estado] || '#1B3FE4');
                    }
                }
            });
        });
    </script>
</asp:Content>
