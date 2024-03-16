using DTOs;

namespace LaboratorioBlazorUI.Servicios
{
    public interface IUsuarioServices
    {
        Task<List<UsuarioDTO>> ObtenerUsuarios();
        Task<UsuarioDTO> BuscarUsuario(string Cedula);
        Task<UsuarioDTO> CrearUsuario(UsuarioCreacionDTO usuarioCreacion);
        Task<bool> Eliminar(string Cedula);
        Task<bool> Editar(UsuarioEdicionDTO usuarioCreacion);
    }
}
