namespace BE_DashBoard.Models
{
    public class Contribuyentes
    {
        public string rnc { get; set; }
        public string razonSocial { get; set; }
        public List<tipo_certificacion> tipo_certificacion { get; set; }
    }
    public class tipo_certificacion
    {
        public string tipo { get; set; }
        public string estado { get; set; }
        public string inicio_postulacion { get; set; }
        public string finalizacion_postulacion { get; set; }
    }
}
