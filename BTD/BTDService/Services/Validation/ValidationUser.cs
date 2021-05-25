using BTDService.Services.db.Users;

namespace BTDService.Services.Validation
{
    public class ValidationUser : IValidation
    {
        private readonly IUserService _userService;
        public ValidationUser()
        {
            _userService = new UserService();
        }

        public ValidationType ValidationUserByPassword(string login, string password)
        {
            var user = _userService.GetUserByLogin(login);
            if (user is not null)
            {
                if (user.Password == password)
                {
                    return ValidationType.Login;
                }
                else
                {
                    return ValidationType.PasswordError;
                }
            }
            else
            {
                return ValidationType.LoginError;
            }
        }
    }
}
