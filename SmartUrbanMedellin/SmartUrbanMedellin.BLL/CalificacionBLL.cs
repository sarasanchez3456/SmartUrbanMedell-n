using SmartUrbanMedellin.DAL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.BLL
{
    public class CalificacionBLL
    {
        private readonly CalificacionDAL _dal = new();
        public List<Calificacion> ObtenerTodos() => _dal.ObtenerTodos();
        public void Insertar(Calificacion c) => _dal.Insertar(c);
    }
}