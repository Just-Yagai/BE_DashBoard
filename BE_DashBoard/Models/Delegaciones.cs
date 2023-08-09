namespace BE_DashBoard.Models
{
    public class Delegacion
    {


        public string rnc { get; set; }
        public string firmanteAutorizado { get; set; }  
        public string solicitanteAutorizado { get; set; }
        public string aprobadorComercial { get; set; }
        public string administrador { get; set; }
        public string estado { get; set; }
        public string identificacion { get; set; }
        public string fechaRegistro { get; set; }
        public string FechaActualizacion { get; set;}
        public int AmbienteID { get; set; }
        public int CanalID { get; set; }

 
    }
}
