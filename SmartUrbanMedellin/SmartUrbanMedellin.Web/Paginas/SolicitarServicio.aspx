<%@ Page Title="Solicitar Servicio" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="SolicitarServicio.aspx.cs" Inherits="SmartUrbanMedellin.Web.Paginas.SolicitarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="animate-up" style="margin-bottom: 1.5rem; display: flex; align-items: center; gap: 0.5rem; font-size: 0.875rem;">
        <a href="/Paginas/Solicitudes" style="color: #1B3FE4; text-decoration: none;">← Solicitudes</a>
        <span style="color: #cbd5e1;">/</span>
        <span style="color: #64748b;">Solicitar Servicio</span>
    </div>

    <h2 class="page-title animate-up" style="margin-bottom: 1.5rem;">📤 Solicitar Servicio</h2>

    <div style="display: grid; grid-template-columns: 1fr; gap: 1.5rem;" class="lg:grid-cols-5">
        <!-- Form -->
        <div class="lg:col-span-2">
            <div class="card" style="padding: 1.5rem;">
                <h3 style="font-family: 'Outfit', sans-serif; font-weight: 700; color: #0F1523; font-size: 1rem; margin-bottom: 1.25rem; padding-bottom: 0.75rem; border-bottom: 1px solid #f1f5f9;">
                    Datos de la Solicitud
                </h3>
                <asp:Panel ID="pnlForm" runat="server" DefaultButton="btnEnviar">
                    <div class="form-group">
                        <label class="field-label">Servicio *</label>
                        <asp:DropDownList ID="ddlServicio" runat="server" CssClass="input" required>
                            <asp:ListItem value="">— Seleccionar servicio —</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="field-label">Fecha *</label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="input" TextMode="Date" required></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="field-label">Estado</label>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="input">
                            <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                            <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                            <asp:ListItem Text="Cancelado" Value="Cancelado"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="padding-top: 0.75rem; border-top: 1px solid #f1f5f9;">
                        <label class="field-label">
                            Ubicación del Servicio *
                            <span style="font-weight: normal; color: #64748b; margin-left: 0.25rem; text-transform: none;">(clic en el mapa)</span>
                        </label>
                        <asp:HiddenField ID="hdnLat" runat="server" />
                        <asp:HiddenField ID="hdnLng" runat="server" />
                        <div id="coordsDisplay" class="coords-box">Sin ubicación seleccionada</div>
                    </div>
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar Solicitud →" CssClass="btn-verde" style="width: 100%; margin-top: 0.5rem;" OnClick="btnEnviar_Click" />
                    <a href="/Paginas/Solicitudes" style="display: block; text-align: center; color: #64748b; font-size: 0.875rem; margin-top: 0.25rem; text-decoration: none;">Cancelar</a>
                </asp:Panel>
            </div>
        </div>

        <!-- Map -->
        <div class="lg:col-span-3">
            <div class="card" style="overflow: hidden;">
                <div class="card-header verde">🗺️ Indica dónde necesitas el servicio</div>
                <div class="mapa-box mapa-tall" id="mapa-solicitar"></div>
            </div>
            <p style="font-size: 0.75rem; color: #64748b; margin-top: 0.5rem; padding-left: 0.25rem;">
                💡 Haz clic en el mapa para marcar exactamente dónde necesitas el servicio.
            </p>
        </div>
    </div>

    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function() {
            var m = crearMapa('mapa-solicitar', 6.2442, -75.5812, 13);
            if (!m) return;
            m.on('load', function() {
                activarSeleccion(m, '<%= hdnLat.ClientID %>', '<%= hdnLng.ClientID %>', 'coordsDisplay');
            });
        });
    </script>
</asp:Content>
