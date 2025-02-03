
using JoinsSqlWebApi.Models;

namespace JoinsSqlWebApi.Inteface
{
    public interface IProduct
    {
       Task<List<Products>> GetProductsAsync();

    }
}
