using System.Collections.Generic;
namespace BE_DashBoard.Models

{
    public class PageResult<T>
    {
       public IEnumerable<T> Result { get; set; }
       public Paginacion Paginacion { get; set; }
    }
}
