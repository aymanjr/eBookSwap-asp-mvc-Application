using ebookSwapApllication.Models;

namespace ebookSwapApllication.Data.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> Getall();
        User GetById(int id);
        void Add(User user);
        User Update(int id, User newUser);
        void  Delete(int id);
    }
}
