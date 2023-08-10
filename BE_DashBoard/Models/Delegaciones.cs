namespace BE_DashBoard.Models
{
    public class Delegacion
    {

        public int Id { get; set; }
        public string Rnc { get; set; }
        public string FirmanteAutorizado { get; set; }  
        public string SolicitanteAutorizado { get; set; }
        public string AprobadorComercial { get; set; }
        public string Administrador { get; set; }
        public string Estado { get; set; }
        public string Identificacion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set;}
        public int AmbienteID { get; set; }
        public int CanalID { get; set; }

 
    }
}
