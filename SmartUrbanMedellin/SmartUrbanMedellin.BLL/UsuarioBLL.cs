using SmartUrbanMedellin.DAL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _dal = new();
        public List<Usuario> ObtenerTodos() => _dal.ObtenerTodos();
        public Usuario? ObtenerPorId(int id) => _dal.ObtenerPorId(id);
        public void Insertar(Usuario u) => _dal.Insertar(u);
        public void Actualizar(Usuario u) => _dal.Actualizar(u);
        public void Eliminar(int id) => _dal.Eliminar(id);
    }
}