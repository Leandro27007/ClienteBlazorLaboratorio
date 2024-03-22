using DTOs;
using LaboratorioBlazorUI.DTOs;
using Newtonsoft.Json;

namespace LaboratorioBlazorUI.Servicios
{
    public interface IPacienteService
    {
       Task<PacienteObtencionDTO> BuscarPaciente(string documento);
    }
}
