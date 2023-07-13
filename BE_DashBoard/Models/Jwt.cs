using System.Security.Claims;

namespace BE_DashBoard.Models
{
    public class Jwt
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Subject { get; set; }

        public static dynamic ValidarToken(ClaimsIdentity identity)
        {
            try
            {
                if(identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "comporbado si el token  es valido",
                        result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

                Credencial _id = Credencial.DB().FirstOrDefault(x => x.idusuario == id);

                return new
                {
                    success = true,
                    message = "exito",
                    result = _id
                };
            }
            catch (Exception ex) 
            { 
            
                return new
                {
                    success = false,
                    message = "Catch: "+ex.Message,
                    result = ""
                };
            }
        }

    }
}
