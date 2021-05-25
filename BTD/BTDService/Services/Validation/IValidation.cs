namespace BTDService.Services.Validation
{
    public interface IValidation
    {
        ValidationType ValidationUserByPassword(string login, string password);
    }
}
