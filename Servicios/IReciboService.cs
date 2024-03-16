using DTOs;
using LaboratorioBlazorUI.Modelos.Request;
using LaboratorioBlazorUI.Modelos.Response;

namespace LaboratorioBlazorUI.Servicios
{
    public interface IReciboService
    {
        Task<ReciboResponse> GenerarRecibo(ReciboRequest recibo);
        Task<List<ReciboDTO>> ListarRecibos();
        Task<bool> Reembolsar(ReembolsoRequest reembolsoRequest);

    }
}
