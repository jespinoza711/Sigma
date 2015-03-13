namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.ObjetosValor
{
    public class InformacionVehiculoFord
    {
        private InformacionVehiculoFord()
        {

        }
        public InformacionVehiculoFord(string marca, string modelo, int anio, string millaje, string vin, string placa)
        {
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Millaje = millaje;
            Vin = vin;
            Placa = placa;
        }

        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Anio { get; private set; }
        public string Millaje { get; private set; }
        public string Vin { get; private set; }
        public string Placa { get; private set; }
    }
}