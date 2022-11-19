using ebookSwapApllication.Models;
using Microsoft.EntityFrameworkCore;

namespace ebookSwapApllication.Data.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> Getall()
        {
            var result = await  _context.Users.ToListAsync(); 
            return result;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(int id, User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
