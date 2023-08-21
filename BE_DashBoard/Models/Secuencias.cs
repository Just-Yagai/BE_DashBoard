namespace BE_DashBoard.Models
{
    public class Secuencias
    {
        public int Id { get; set; }
        public string Rnc { get; set; }
        public string e_cf { get; set; }
        public string SecuenciaDesde { get; set; }
        public string SecuenciaHasta { get; set; }
        public string NroAutorizacion { get; set; }
        public string Estado { get; set; }
        public string RealizadoEmision { get; set; }
        public string FechaRegistro2 { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int AmbienteID { get; set; }
        public int CanalID { get; set; }
        public int TipoECF { get; set; }
    }
}
