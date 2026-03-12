using System.Collections.Generic;
using SmartUrbanMedellin.DAL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.BLL
{
    public class ServicioBLL
    {
        private readonly ServicioDAL _dal = new();
        public List<Servicio> ObtenerTodos() => _dal.ObtenerTodos();
        public Servicio? ObtenerPorId(int id) => _dal.ObtenerPorId(id);
        public void Insertar(Servicio s) => _dal.Insertar(s);
        public void Actualizar(Servicio s) => _dal.Actualizar(s);
        public void Eliminar(int id) => _dal.Eliminar(id);
    }
}