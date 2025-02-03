using System.Data;
using System.Data.SqlClient;
using JoinsSqlWebApi.Inteface;
using JoinsSqlWebApi.Models;

namespace JoinsSqlWebApi.Services
{
    public class ProductsService : IProduct
    {
        private readonly string _connectionString;

        public ProductsService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            var products = new List<Products>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_GetAllProducts", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var product = new Products
                                {
                                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    Categories = new CategoryClass
                                    {
                                        CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                        CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                                    }
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return products;
        }
    }
}