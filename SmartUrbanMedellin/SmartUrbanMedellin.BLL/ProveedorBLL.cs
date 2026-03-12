using System.Collections.Generic;
using SmartUrbanMedellin.DAL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.BLL
{
    public class ProveedorBLL
    {
        private readonly ProveedorDAL _dal = new();
        public List<Proveedor> ObtenerTodos() => _dal.ObtenerTodos();
        public Proveedor? ObtenerPorId(int id) => _dal.ObtenerPorId(id);
        public void Insertar(Proveedor p) => _dal.Insertar(p);
        public void Actualizar(Proveedor p) => _dal.Actualizar(p);
        public void Eliminar(int id) => _dal.Eliminar(id);
    }
}