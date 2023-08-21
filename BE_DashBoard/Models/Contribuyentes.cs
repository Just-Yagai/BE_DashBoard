using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BE_DashBoard.Models
{

    public class Contribuyente
    {
        public int Id { get; set; }
        public string RNC { get; set; }
        public string RazonSocial { get; set; }
        
        [NotMapped]
        public ICollection<TipoCertificacion> TiposCertificacion { get; set; }
    }
    public class TipoCertificacion
    {
        public int Id { get; set; }
        public string ContribuyenteId { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string InicioPostulacion { get; set; }
        public string FinalizacionPostulacion { get; set; }
        [JsonIgnore]
        public Contribuyente Contribuyente { get; set; }
    }
}
