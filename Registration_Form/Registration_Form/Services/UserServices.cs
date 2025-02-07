using System.Data;
using Microsoft.Data.SqlClient;
using Registration_Form.Interface;
using Registration_Form.Models;

namespace Registration_Form.Services
{
    public class UserServices : IUsers
    {
        private readonly string _connectionString;

        public UserServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = new List<User>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (var cmd = new SqlCommand("sp_GetAllUsers", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                users.Add(new User
                                {
                                    UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                    FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                                    LastName = reader.GetString(reader.GetOrdinal("last_name")),
                                    Email = reader.GetString(reader.GetOrdinal("email")),
                                    PhoneNumber = reader.GetString(reader.GetOrdinal("phone_number")),
                                    StreetAddress = reader.GetString(reader.GetOrdinal("street_address")),
                                    StateName = reader.GetString(reader.GetOrdinal("state_name")),
                                    CountryName = reader.GetString(reader.GetOrdinal("country_name")),
                                    AreaCode = reader.GetString(reader.GetOrdinal("area_code"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
            }

            return users;
        }

        public async Task<string> InsertUserAsync(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_InsertUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                        cmd.Parameters.AddWithValue("@StreetAddress", user.StreetAddress);
                        cmd.Parameters.AddWithValue("@StateName", user.StateName);
                        cmd.Parameters.AddWithValue("@CountryName", user.CountryName);
                        cmd.Parameters.AddWithValue("@AreaCode", user.AreaCode);

                        var outputParan = new SqlParameter(
                            "@ReturnMessage",
                            SqlDbType.NVarChar,
                            100)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(outputParan);

                        await cmd.ExecuteNonQueryAsync();

                        string returnValue = outputParan.Value.ToString();

                        return returnValue;
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GetUserById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", id);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new User
                                {
                                    UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                    FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                                    LastName = reader.GetString(reader.GetOrdinal("last_name")),
                                    Email = reader.GetString(reader.GetOrdinal("email")),
                                    PhoneNumber = reader.GetString(reader.GetOrdinal("phone_number")),
                                    StreetAddress = reader.GetString(reader.GetOrdinal("street_address")),
                                    StateName = reader.GetString(reader.GetOrdinal("state_name")),
                                    CountryName = reader.GetString(reader.GetOrdinal("country_name")),
                                    AreaCode = reader.GetString(reader.GetOrdinal("area_code"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user: {ex.Message}");
            }

            return null;
        }

        public async Task<string> DeleteByIdAsync(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteUserById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", id);

                        var outputParan = new SqlParameter(
                            "@ReturnMessage",
                            SqlDbType.NVarChar,
                            100)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(outputParan);

                        await cmd.ExecuteNonQueryAsync();

                        string returnValue = outputParan.Value.ToString();

                        return returnValue;
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> UpdateUserById(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", user.UserId);
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                        cmd.Parameters.AddWithValue("@StreetAddress", user.StreetAddress);
                        cmd.Parameters.AddWithValue("@StateName", user.StateName);
                        cmd.Parameters.AddWithValue("@CountryName", user.CountryName);
                        cmd.Parameters.AddWithValue("@AreaCode", user.AreaCode);
                        var outputParan = new SqlParameter(
                            "@ReturnMessage",
                            SqlDbType.NVarChar,
                            100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParan);
                        await cmd.ExecuteNonQueryAsync();
                        string returnValue = outputParan.Value.ToString();
                        return returnValue;
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }

        }
    }
}
