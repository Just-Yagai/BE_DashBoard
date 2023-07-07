namespace BE_DashBoard.Models
{
    public class Secuencias
    {
        public string rnc { get; set; }
        public string e_CF { get; set; }
        public string secuenciaDesde { get; set; }
        public string secuenciaHasta { get; set; }
        public string nroAutorizacion { get; set; }
        public string estado { get; set; }
        public string realizadoEmision { get; set; }
        public string fechaRegistro2 { get; set; }
        public string fechaDesde { get; set; }
        public string fechaHasta { get; set; }
        public int AmbienteID { get; set; }
        public int CanalID { get; set; }
        public int TipoECF { get; set; }
    }
}
