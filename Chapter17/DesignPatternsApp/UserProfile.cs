namespace DesignPatternsApp
{
    // Builder Pattern example
    public class UserProfile
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
    }

    public interface IUserProfileBuilder
    {
        IUserProfileBuilder SetFirstName(string firstName);
        IUserProfileBuilder SetLastName(string lastName);
        IUserProfileBuilder SetAge(int age);
        IUserProfileBuilder SetEmail(string email);
        IUserProfileBuilder SetAddress(string address);
        UserProfile Build();
    }

    public class UserProfileBuilder : IUserProfileBuilder
    {
        private UserProfile _userProfile = new();

        public UserProfile Build()
        {
            return _userProfile;
        }

        public IUserProfileBuilder SetAddress(string address)
        {
            _userProfile.Address = address;
            return this;
        }

        public IUserProfileBuilder SetAge(int age)
        {
            _userProfile.Age = age;
            return this;
        }

        public IUserProfileBuilder SetEmail(string email)
        {
            _userProfile.Email = email;
            return this;
        }

        public IUserProfileBuilder SetFirstName(string firstName)
        {
            _userProfile.FirstName = firstName;
            return this;
        }

        public IUserProfileBuilder SetLastName(string lastName)
        {
            _userProfile.LastName = lastName;
            return this;
        }
    }
}
