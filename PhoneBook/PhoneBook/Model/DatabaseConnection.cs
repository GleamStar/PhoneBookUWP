namespace PhoneBook.Model
{

    public sealed  class DatabaseConnection
    {
        private static UserContext _instance;

        public static UserContext Instance => _instance ?? (_instance = new UserContext());
    }

}
