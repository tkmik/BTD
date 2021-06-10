using BTDService.Services.db.Users;
using System.Threading.Tasks;

namespace BTDService.Services.Validation
{
    public class ValidationUser : IValidation
    {
        private readonly IUserService _userService;
        public ValidationUser()
        {
            _userService = new UserService();
        }

        public async Task<ValidationType> ValidationUserByPasswordAsync(string login, string password)
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
