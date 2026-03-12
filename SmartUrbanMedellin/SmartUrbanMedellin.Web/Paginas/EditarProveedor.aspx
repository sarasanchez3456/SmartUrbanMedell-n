<%@ Page Title="Editar Proveedor" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="EditarProveedor.aspx.cs" Inherits="SmartUrbanMedellin.Web.Paginas.EditarProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="animate-up" style="margin-bottom: 1.5rem; display: flex; align-items: center; gap: 0.5rem; font-size: 0.875rem;">
        <a href="/Paginas/Proveedores" style="color: #1B3FE4; text-decoration: none;">← Proveedores</a>
        <span style="color: #cbd5e1;">/</span>
        <span style="color: #64748b;">Editar Proveedor</span>
    </div>

    <h2 class="page-title animate-up" style="margin-bottom: 1.5rem;">Editar Proveedor</h2>

    <div style="display: grid; grid-template-columns: 1fr; gap: 1.5rem;" class="lg:grid-cols-5">
        <!-- Form -->
        <div class="lg:col-span-2">
            <div class="card" style="padding: 1.5rem;">
                <h3 style="font-family: 'Outfit', sans-serif; font-weight: 700; color: #0F1523; font-size: 1rem; margin-bottom: 1.25rem; padding-bottom: 0.75rem; border-bottom: 1px solid #f1f5f9;">
                    Actualizar Datos
                </h3>
                <asp:HiddenField ID="hdnIdProveedor" runat="server" />
                <div class="form-group">
                    <label class="field-label">Razón Social</label>
                    <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="input"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="field-label">Contacto</label>
                    <asp:TextBox ID="txtContacto" runat="server" CssClass="input"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="field-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="input"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="field-label">Correo</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="input" TextMode="Email"></asp:TextBox>
                </div>
                <div style="padding-top: 0.75rem; border-top: 1px solid #f1f5f9;">
                    <label class="field-label">
                        Actualizar Ubicación
                        <span style="font-weight: normal; color: #64748b; margin-left: 0.25rem; text-transform: none;">(clic en el mapa)</span>
                    </label>
                    <asp:HiddenField ID="hdnLat" runat="server" />
                    <asp:HiddenField ID="hdnLng" runat="server" />
                    <div id="coordsDisplay" class="coords-box">Lat: 0 · Lng: 0</div>
                </div>
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Proveedor →" CssClass="btn-oro" style="width: 100%; margin-top: 0.5rem;" OnClick="btnActualizar_Click" />
                <a href="/Paginas/Proveedores" style="display: block; text-align: center; color: #64748b; font-size: 0.875rem; margin-top: 0.25rem; text-decoration: none;">Cancelar</a>
            </div>
        </div>

        <!-- Map -->
        <div class="lg:col-span-3">
            <div class="card" style="overflow: hidden;">
                <div class="card-header oro">🗺️ Ubicación Actual — Clic para mover</div>
                <div class="mapa-box mapa-tall" id="mapa-editar"></div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var lat = 6.2442;
        var lng = -75.5812;
        
        document.addEventListener('DOMContentLoaded', function() {
            var m = crearMapa('mapa-editar', lat, lng, 15);
            if (!m) return;
            m.on('load', function() {
                agregarPin(m, lng, lat, '📍 Ubicación actual', '#F5C400');
                activarSeleccion(m, '<%= hdnLat.ClientID %>', '<%= hdnLng.ClientID %>', 'coordsDisplay');
            });
        });
    </script>
</asp:Content>
