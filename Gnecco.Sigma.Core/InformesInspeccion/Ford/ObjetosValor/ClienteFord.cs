namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.ObjetosValor
{
    public class ClienteFord
    {
        public string Nombre { get; private set; }
        public string CorreoElectronico { get; private set; }

        private ClienteFord()
        {

        }
        public ClienteFord(string nombre, string correoElectronico)
        {
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
        }
    }
}