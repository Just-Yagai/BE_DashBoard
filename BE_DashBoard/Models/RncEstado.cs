namespace BE_DashBoard.Models
{
    public class RncEstado
    {
        public string rnc { set; get; }
        public string estado { set; get; }
        public bool? autorizadoAFacturar { set; get; }
        public bool? autorizadoSolicitarSecuencia { set; get; } 
        public bool? esGrandeContribuyente { set; get; }
        public int AmbienteID { set; get; }
        public int CanalID { set; get; }

    }
}
