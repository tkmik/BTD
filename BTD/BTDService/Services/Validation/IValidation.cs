using System.Threading.Tasks;

namespace BTDService.Services.Validation
{
    public interface IValidation
    {
        Task<ValidationType> ValidationUserByPasswordAsync(string login, string password);
    }
}
