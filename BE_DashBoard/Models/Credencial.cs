namespace BE_DashBoard.Models
{
    public class Credencial
    {
        public string idusuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string rol { get; set; }

        public static List<Credencial> DB()
        {
            var list = new List<Credencial>();
            {
                new Credencial
                {
                    idusuario = "1",
                    usuario = "pedro",
                    password = "123.",
                    rol = "empleado"

                };


                new Credencial
                {
                    idusuario = "2",
                    usuario = "ramon",
                    password = "123.",
                    rol = "administrador"

                };
            }
            return list;
        }
    }
}
