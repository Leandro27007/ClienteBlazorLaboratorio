namespace LaboratorioBlazorUI.Modelos.Request
{
    public class GenerarTurnoRequest
    {

        public List<PruebalabTurnoRequest> pruebasLab { get; set; }

        public class PruebalabTurnoRequest
        {
            public int idPruebaLab { get; set; }
            public string nombrePrueba { get; set; } = "";
        }

    }
}
