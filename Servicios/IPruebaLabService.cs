using DTOs;
using LaboratorioBlazorUI.Modelos;

namespace LaboratorioBlazorUI.Servicios
{
    public interface IPruebaLabService
    {
        Task<IEnumerable<PruebaLab>> ObtenerPruebas();
        Task<PruebaLab> CrearPruebaLab(CreacionPruebaLabDTO creacionPruebaLabDTO);
        Task<bool> EditarPruebaLab(EdicionPruebaLabDTO edicionPruebaLabDTO);
        Task<bool> eliminarPruebaLab(string idPruebalab);
    }
}
