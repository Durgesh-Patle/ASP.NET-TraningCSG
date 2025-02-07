using Registration_Form.Models;

namespace Registration_Form.Interface
{
    public interface IUsers
    {
        Task<string> InsertUserAsync(User user);

        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<string> DeleteByIdAsync(int id);

        Task<string> UpdateUserById(User user);
    }
}
