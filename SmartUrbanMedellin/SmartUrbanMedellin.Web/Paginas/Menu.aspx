<%@ Page Title="Menú Principal" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="SmartUrbanMedellin.Web.Paginas.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header animate-up">
        <h2 class="page-title">Menú Principal</h2>
        <p class="text-slate-400 text-sm" style="display: none;" id="subtitle" runat="server">¿Qué necesitas hoy?</p>
    </div>

    <div class="menu-grid">
        <a href="/Paginas/Proveedores" class="menu-card">
            <span class="menu-emoji">🏪</span>
            <h3 class="menu-title">Proveedores</h3>
            <p class="menu-desc">Ver y gestionar proveedores</p>
            <span class="menu-link">Ir →</span>
        </a>
        
        <a href="/Paginas/Servicios" class="menu-card">
            <span class="menu-emoji">🛠️</span>
            <h3 class="menu-title">Servicios</h3>
            <p class="menu-desc">Catálogo de servicios disponibles</p>
            <span class="menu-link">Ir →</span>
        </a>
        
        <a href="/Paginas/Solicitudes" class="menu-card">
            <span class="menu-emoji">📋</span>
            <h3 class="menu-title">Solicitudes</h3>
            <p class="menu-desc">Gestionar solicitudes de servicio</p>
            <span class="menu-link">Ir →</span>
        </a>
        
        <a href="/Paginas/RegistrarProveedor" class="menu-card">
            <span class="menu-emoji">➕</span>
            <h3 class="menu-title">Registrar Proveedor</h3>
            <p class="menu-desc">Agregar nuevo proveedor con ubicación</p>
            <span class="menu-link">Ir →</span>
        </a>
        
        <a href="/Paginas/SolicitarServicio" class="menu-card">
            <span class="menu-emoji">📤</span>
            <h3 class="menu-title">Solicitar Servicio</h3>
            <p class="menu-desc">Crear nueva solicitud con ubicación</p>
            <span class="menu-link">Ir →</span>
        </a>
        
        <a href="/Paginas/CalificarServicio" class="menu-card">
            <span class="menu-emoji">⭐</span>
            <h3 class="menu-title">Calificar Servicio</h3>
            <p class="menu-desc">Evaluar la calidad del servicio recibido</p>
            <span class="menu-link">Ir →</span>
        </a>
    </div>

    <style>
        .menu-grid {
            display: grid;
            grid-template-columns: 1fr;
            gap: 1.25rem;
        }
        @media (min-width: 640px) {
            .menu-grid { grid-template-columns: repeat(2, 1fr); }
        }
        @media (min-width: 1024px) {
            .menu-grid { grid-template-columns: repeat(3, 1fr); }
        }
        
        .menu-card {
            background: #fff;
            border-radius: 1.25rem;
            padding: 1.75rem;
            display: flex;
            flex-direction: column;
            align-items: center;
            text-align: center;
            text-decoration: none;
            box-shadow: 0 4px 24px rgba(15,21,35,.07);
            transition: box-shadow 0.22s, transform 0.22s;
        }
        .menu-card:hover {
            box-shadow: 0 8px 40px rgba(15,21,35,.13);
            transform: translateY(-2px);
        }
        .menu-card:hover .menu-title { color: #1B3FE4; }
        .menu-card:hover .menu-link { opacity: 1; }
        
        .menu-emoji {
            font-size: 3rem;
            margin-bottom: 1rem;
            transition: transform 0.2s;
        }
        .menu-card:hover .menu-emoji { transform: scale(1.1); }
        
        .menu-title {
            font-family: 'Outfit', sans-serif;
            font-weight: 700;
            font-size: 1.125rem;
            color: #0F1523;
            margin-bottom: 0.375rem;
            transition: color 0.2s;
        }
        
        .menu-desc {
            color: #64748b;
            font-size: 0.875rem;
            line-height: 1.5;
        }
        
        .menu-link {
            margin-top: 1.25rem;
            color: #1B3FE4;
            font-size: 0.75rem;
            font-weight: 600;
            text-transform: uppercase;
            letter-spacing: 0.1em;
            opacity: 0;
            transition: opacity 0.2s;
        }
        
        .text-slate-400 {
            color: #64748b;
        }
    </style>
</asp:Content>
