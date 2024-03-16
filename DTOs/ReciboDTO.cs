namespace DTOs
{
    public class ReciboDTO
    {
        public int idRecibo { get; set; }
        public string nombreCliente { get; set; }
        public string? nombreCajero { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public List<PruebaReciboDTO>? pruebas { get; set; } = new();
        public decimal? total { get; set; }

    }
}