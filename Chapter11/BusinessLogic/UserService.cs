namespace BusinessLogic
{
    public class UserService
    {
        private readonly IEmailSender _emailSender;

        public UserService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public bool CreateUser(string email, string password)
        {
            bool successfulUserCreation = true;

            bool successfulEmailSend = _emailSender.SendEmail(
                to: email,
                subject: "Welcome!",
                body: "Your account is created."
            );

            return successfulEmailSend && successfulUserCreation;
        }
    }
}
