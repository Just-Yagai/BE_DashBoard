namespace BE_DashBoard.Models
{
    public class Marcas
    {
        public int Id { get; set; }
        public string Rnc { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string FechaInicioOperacion { get; set; }
        public int AmbienteID { get; set; }
        public int CanalID { get; set; }
    }
}
