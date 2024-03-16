using DTOs;

namespace LaboratorioBlazorUI.Servicios
{
    public interface IReporteService
    {
        Task<ReporteDTO> ObtenerReporte(string FechaInicio, string FechaFinal); 
    }
}
