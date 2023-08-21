namespace BE_DashBoard.Models
{
    public class RncEstado
    {
        public int Id { get; set; }
        public string Rnc { set; get; }
        public string Estado { set; get; }
        public string AutorizadoAFacturar { set; get; }
        public string AutorizadoSolicitarSecuencia { set; get; } 
        public string EsGrandeContribuyente { set; get; }
        public string Identificacion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set; }
        public int AmbienteID { set; get; }
        public int CanalID { set; get; }

    }
}
