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
                if (SizePagina > 0)
                {
                    return (int)Math.Ceiling((double)TotalElementos / SizePagina);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
