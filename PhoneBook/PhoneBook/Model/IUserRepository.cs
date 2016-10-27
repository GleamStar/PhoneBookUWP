using System.Threading.Tasks;

namespace PhoneBook.Model
{
    interface IUserRepository
    {
        System.Collections.ObjectModel.ObservableCollection<User> Users { get; }

        Task<bool> AddUser(User user);

    }
}
