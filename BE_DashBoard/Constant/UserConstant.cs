using PB_Dashboard.Models;

namespace PB_Dashboard.Constant
{
    public class UserConstant
    {
        public static List<UsersModel> Users = new List<UsersModel>()
        {
            new UsersModel()
            {
                Username = "pedro",
                Password = "123",
                Rol = "Administrador"
            },
            new UsersModel()
            {
                Username = "juan",
                Password = "123",
                Rol = "Empleado"
            }
        };
    }
}
