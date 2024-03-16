using CurrieTechnologies.Razor.SweetAlert2;

namespace LaboratorioBlazorUI.AlertasSweet
{
    public class Alertas
    {

        SweetAlertService _swal;
        public Alertas(SweetAlertService swal)
        {
            _swal = swal;
        }


        public async Task<bool> Confirmar(string nombreOperacion = "", string texto = "Deseas confirmar la operacion?", string textoBotonGuardar =" Si")
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Title = $"{nombreOperacion}",
                Text = texto,
                ShowCancelButton = true,
                Icon = SweetAlertIcon.Question,
                ConfirmButtonText = textoBotonGuardar,
                CancelButtonText = "No"
            });


            if (!string.IsNullOrEmpty(result.Value))
            {
                return true;
            }
            else
            {
                return false;
            }

        }      
        public async Task<bool> CancelarOperacion(string titulo = "", string mensaje ="")
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Title = $"{titulo}",
                Text = mensaje,
                ShowCancelButton = true,
                Icon = SweetAlertIcon.Warning,
                ConfirmButtonText = "Si",
                CancelButtonText = "No"
            });


            if (!string.IsNullOrEmpty(result.Value))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task Alerta(string titulo, string mensaje, SweetAlertIcon icono)
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Title = $"{titulo}",
                Text = $"{mensaje}",
                ShowCancelButton = false,
                ShowConfirmButton = false,
                Toast = true,
                Icon = icono,
                TimerProgressBar = true,
                Timer = 5000m,
                ShowCloseButton = true
            }) ;

        }

    }
}
