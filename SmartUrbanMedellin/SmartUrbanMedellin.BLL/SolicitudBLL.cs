using SmartUrbanMedellin.DAL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.BLL
{
    public class SolicitudBLL
    {
        private readonly SolicitudDAL _dal = new();
        public List<Solicitud> ObtenerTodos() => _dal.ObtenerTodos();
        public void Insertar(Solicitud s) => _dal.Insertar(s);
        public void Actualizar(Solicitud s) => _dal.Actualizar(s);
        public void Eliminar(int id) => _dal.Eliminar(id);
    }
}