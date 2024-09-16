namespace SistemaWebAppi.Repository
{
    public class Personas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }

        public string GuardarPersonas()
        {
            return "";
        }

        public List<Personas> ListarPersonas()
        {
            List<Personas> lista = new List<Personas>();
            return lista;
        }
    }
}
