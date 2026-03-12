<%@ Page Title="Calificar Servicio" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="CalificarServicio.aspx.cs" Inherits="SmartUrbanMedellin.Web.Paginas.CalificarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="animate-up" style="margin-bottom: 1.5rem; display: flex; align-items: center; gap: 0.5rem; font-size: 0.875rem;">
        <a href="/Paginas/Solicitudes" style="color: #1B3FE4; text-decoration: none;">← Solicitudes</a>
        <span style="color: #cbd5e1;">/</span>
        <span style="color: #64748b;">Calificar Servicio</span>
    </div>

    <div style="max-width: 28rem; margin: 0 auto;" class="animate-up">
        <div class="card" style="padding: 2rem;">
            <!-- Header -->
            <div style="text-align: center; margin-bottom: 2rem;">
                <div style="width: 4rem; height: 4rem; border-radius: 1rem; background: rgba(245,196,0,0.1); display: flex; align-items: center; justify-content: center; font-size: 2.25rem; margin: 0 auto 0.75rem auto;">⭐</div>
                <h2 style="font-family: 'Outfit', sans-serif; font-weight: 900; font-size: 1.5rem; color: #0F1523; margin-bottom: 0.25rem;">Calificar Servicio</h2>
                <p style="color: #64748b; font-size: 0.875rem;">Tu opinión ayuda a otros ciudadanos a elegir mejor</p>
            </div>

            <asp:Panel ID="pnlForm" runat="server" DefaultButton="btnEnviar">
                <asp:HiddenField ID="hdnIdSolicitud" runat="server" />

                <!-- Star rating -->
                <div style="margin-bottom: 1.5rem;">
                    <label class="field-label" style="text-align: center; display: block; margin-bottom: 1rem;">¿Cómo calificarías el servicio?</label>
                    <div class="star-group" style="justify-content: center;">
                        <asp:RadioButtonList ID="rblPuntuacion" runat="server" RepeatDirection="Horizontal" style="display: flex; flex-direction: row-reverse; gap: 0.25rem; justify-content: center;">
                            <asp:ListItem Value="5"><span style="font-size: 1.5rem;">⭐</span></asp:ListItem>
                            <asp:ListItem Value="4"><span style="font-size: 1.5rem;">⭐</span></asp:ListItem>
                            <asp:ListItem Value="3"><span style="font-size: 1.5rem;">⭐</span></asp:ListItem>
                            <asp:ListItem Value="2"><span style="font-size: 1.5rem;">⭐</span></asp:ListItem>
                            <asp:ListItem Value="1"><span style="font-size: 1.5rem;">⭐</span></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div style="display: flex; justify-content: space-between; font-size: 0.75rem; color: #cbd5e1; margin-top: 0.5rem; padding: 0 0.25rem;">
                        <span>Muy malo</span>
                        <span>Excelente</span>
                    </div>
                </div>

                <!-- Comment -->
                <div style="margin-bottom: 1.5rem;">
                    <label class="field-label">Comentario</label>
                    <asp:TextBox ID="txtComentario" runat="server" CssClass="input" TextMode="MultiLine" Rows="4" placeholder="Describe tu experiencia con este servicio..." style="resize: none;"></asp:TextBox>
                </div>

                <asp:Button ID="btnEnviar" runat="server" Text="⭐ Enviar Calificación" CssClass="btn-oro" style="width: 100%; font-size: 1rem; padding: 0.875rem; font-family: 'Outfit', sans-serif; font-weight: 900;" OnClick="btnEnviar_Click" />
                <a href="/Paginas/Solicitudes" style="display: block; text-align: center; color: #64748b; font-size: 0.875rem; margin-top: 0.25rem; text-decoration: none;">Cancelar</a>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
