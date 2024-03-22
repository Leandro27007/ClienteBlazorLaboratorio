using LaboratorioBlazorUI.Modelos;
using LaboratorioBlazorUI.Modelos.Request;

namespace LaboratorioBlazorUI.Servicios
{
    public interface ITurnoServices
    {
        Task<List<Turno>> GetTurnos();
        Task<string> GenerarTurno(GenerarTurnoRequest turno);
        Task<string> CancelarTurno(string idTurno);
        Task<string> AtenderTurno(string turnoId);
    }
}
