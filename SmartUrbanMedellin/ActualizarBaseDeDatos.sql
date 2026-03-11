-- Script para actualizar la base de datos SmartUrban
-- Ejecuta este script en SQL Server Management Studio

USE SmartUrbanMedellin;

-- Agregar columna Categoria a Servicios (para las vistas)
ALTER TABLE Servicios ADD Categoria VARCHAR(50);

-- Agregar columnas a Proveedores (para las vistas)
ALTER TABLE Proveedores ADD Contacto VARCHAR(100);
ALTER TABLE Proveedores ADD Correo VARCHAR(100);

-- Agregar columnas a Solicitudes (para las vistas)
ALTER TABLE Solicitudes ADD IdServicio INT;
ALTER TABLE Solicitudes ADD Estado VARCHAR(50);

-- Agregar foreign key para IdServicio en Solicitudes
ALTER TABLE Solicitudes 
ADD CONSTRAINT FK_Solicitud_Servicio 
FOREIGN KEY (IdServicio) REFERENCES Servicios(IdServicios);
