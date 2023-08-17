namespace BE_DashBoard.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Contribuyente
    {
        public int Id { get; set; }
        public string RNC { get; set; }
        public string RazonSocial { get; set; }

        public ICollection<TipoCertificacion> TiposCertificacion { get; set; }
    }
    public class TipoCertificacion
    {
        public int Id { get; set; }
        public int ContribuyenteId { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string InicioPostulacion { get; set; }
        public string FinalizacionPostulacion { get; set; }

        public Contribuyente Contribuyente { get; set; }
    }
}
