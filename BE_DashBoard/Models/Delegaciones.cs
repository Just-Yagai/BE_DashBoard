namespace BE_DashBoard.Models
{
    public class Delegaciones
    {


        public string rnc { get; set; }
        public bool? firmanteAutorizado { get; set; }  
        public bool? solicitanteAutorizado { get; set; }
        public bool? aprobadorComercial { get; set; }
        public bool? administrador { get; set; }
        public string estado { get; set; }
        public string identificacion { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaActualizacion { get; set;}
        public int AmbienteID { get; set; }
        public int CanalID { get; set; }

 
    }
}
