namespace SolidPrinciplesApp
{
    // Single Responsibility Principle
    // A class should have only one reason to change. A class should have only one job or responsibility.
    public class UserProfile
    {
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
    }

    public class UserProfileManager
    {
        public void SaveUserProfile(UserProfile user)
        {
            // Save user profile to db
            WriteLine($"{user.UserName} has been saved to the database!");
        }
    }
}
