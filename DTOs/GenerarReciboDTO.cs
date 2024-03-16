namespace DTOs
{
    public class GenerarReciboDTO
    {
        public string IdCajero { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Cedula { get; set; } = "0";
        public List<PruebaReciboDTO> Pruebas { get; set; }
    }
}
