using System;
using System.Linq;
using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace PhoneBook.Model
{
    public class UserRepository : IUserRepository
    {
        readonly UserContext _context;

        public ObservableCollection<User> Users { get; }

        public UserRepository()
        {
            _context = DatabaseConnection.Instance;
            Users = new ObservableCollection<User>(_context.Users.ToList());
        }
        public async Task<bool> AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException("user is null");
            Users.Add(user);
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
