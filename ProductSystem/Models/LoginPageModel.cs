namespace ProductSystem.Models
{
    public class LoginPageModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public LoginPageModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
            ErrorMessage = string.Empty;
        }
    }
}
