namespace LaboratorioBlazorUI.DTOs
{
    public class RespuestaDTO<T>
    {

        public string MensajeError { get; set; }
        public T Contenido { get; set; }

    }
}
