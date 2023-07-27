namespace BE_DashBoard.Models
{
    public class RncEstado
    {
        public string rnc { set; get; }
        public string estado { set; get; }
        public string autorizadoAFacturar { set; get; }
        public string autorizadoSolicitarSecuencia { set; get; } 
        public string esGrandeContribuyente { set; get; }
        public string identificacion { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaActualizacion { get; set; }
        public int AmbienteID { set; get; }
        public int CanalID { set; get; }

    }
}
