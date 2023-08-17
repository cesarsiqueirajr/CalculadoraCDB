namespace CalculadoraCDB.Modelos {
    public class CalculoCdbInput {
        public decimal ValorInicial { get; set; }
        public int PrazoEmMeses { get; set; }
    }

    public class CalculoCdbOutput {
        public decimal ResultadoBruto { get; set; }
        public decimal ResultadoLiquido { get; set; }
    }
}
