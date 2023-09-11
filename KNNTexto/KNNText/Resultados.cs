namespace KNNText
{
    class Resultados
    {
        public String label { get; set; }
        public double result { get; set; }

        public Resultados(string label, double result)
        {
            this.label = label;
            this.result = result;
        }
    }
}
