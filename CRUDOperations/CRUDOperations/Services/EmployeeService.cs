using CRUDOperations.Interfaces;
using CRUDOperations.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;


namespace CRUDOperations.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly string _connectionString;

        public EmployeeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("GetEmployees", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                employees.Add(new Employee
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Number = reader.GetString(reader.GetOrdinal("Number")),
                                    Department = reader.GetString(reader.GetOrdinal("Department")),
                                    Salary = reader.GetDecimal(reader.GetOrdinal("Salary"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return employees;
        }

        public async Task<string> InsertEmployeeAsync(Employee emp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("InsertEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", emp.Name);
                        cmd.Parameters.AddWithValue("@Email", emp.Email);
                        cmd.Parameters.AddWithValue("@Number", emp.Number);
                        cmd.Parameters.AddWithValue("@Department", emp.Department);
                        cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                        var outputParan = new SqlParameter(
                            "@ReturnValue",
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

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            Employee employee = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("GetEmployeeById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                employee = new Employee
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Number = reader.GetString(reader.GetOrdinal("Number")),
                                    Department = reader.GetString(reader.GetOrdinal("Department")),
                                    Salary = reader.GetDecimal(reader.GetOrdinal("Salary"))
                                };
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
             
                Console.WriteLine($"Error: {ex.Message}");
            }

            return employee;

        }


        public async Task<string> DeleteEmployeByIdAsync(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("DeleteEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", id);

                        var outputParan = new SqlParameter(
                            "@ReturnValue",
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
                return $"error: {ex.Message}";  
            }
            }

        public async Task<string> UpdateEmployeeById(Employee emp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("UpdateEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id",emp.Id);
                        cmd.Parameters.AddWithValue("@Name", emp.Name);
                        cmd.Parameters.AddWithValue("@Email", emp.Email);
                        cmd.Parameters.AddWithValue("@Number", emp.Number);
                        cmd.Parameters.AddWithValue("@Department", emp.Department);
                        cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                        var outputParan = new SqlParameter(
                             "@ReturnValue",
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