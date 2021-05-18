using BTDCore;
using BTDService.Services.Crypto;
using BTDService.Services.Users;
using System.Media;
using System.Threading.Tasks;
using System.Windows;

namespace BTDService.Services.Validation
{
    public class ValidationUser : IValidation
    {
        private readonly IUserService _userService;
        public ValidationUser()
        {
            _userService = new UserService();
        }

        public async Task<ValidationType> ValidationUserByPassword(string login, string password)
        {
            var user = await _userService.GetUserByLoginAsync(login);
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
