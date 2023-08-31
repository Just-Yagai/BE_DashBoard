namespace BE_DashBoard.Models
{
    public class Paginacion
    {
     public int NumeroPagina { get; set;}
     public int SizePagina { get; set;} 
     public int TotalElementos {get; set;}
     public int TotalPaginas {
            get 
            {
                return TotalElementos / SizePagina;
            } 
        }
    }
}
