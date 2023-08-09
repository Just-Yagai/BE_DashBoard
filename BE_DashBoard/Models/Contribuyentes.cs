namespace BE_DashBoard.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Contribuyente
    {
        public string rnc { get; set; }
        public string razonSocial { get; set; }
        public List<TipoCertificacion> tipo_certificacion { get; set; }
    }
    public class TipoCertificacion
    {
        public string tipo { get; set; }
        public string estado { get; set; }
        public string inicio_postulacion { get; set; }
        public string finalizacion_postulacion { get; set; }
    }
}
