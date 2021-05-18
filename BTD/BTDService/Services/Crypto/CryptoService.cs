using System.Security.Cryptography;
using System.Text;

namespace BTDService.Services.Crypto
{
    public class CryptoService : ICrypto
    {

        public string Encrypt(string password)
        {
            byte[] tmpSource = Encoding.UTF8.GetBytes(password);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return Encoding.UTF8.GetString(tmpHash);
        }
    }
}
