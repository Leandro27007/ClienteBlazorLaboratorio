using DTOs;

namespace LaboratorioBlazorUI.Servicios
{
    public interface IMedicoService
    {
        Task<List<PacienteDTO>> ObtenerPacientesPendientes();
        Task<PacienteDTO> BuscarPaciente(string idRecibo);
        Task<bool> CambiarEstadoRecibo(string idRecibo, string estado);
        Task<List<string>> ObtenerEstadosRecibo();
    }
}
