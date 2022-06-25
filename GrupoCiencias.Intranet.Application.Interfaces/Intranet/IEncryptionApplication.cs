using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Intranet
{
    public interface IEncryptionApplication
    {
        Task<string> EncryptStringAsync(string _cadenaAencriptar);
        Task<string> DescryptStringAsync(string _cadenaAencriptar);
        string DescryptString(string _cadenaDesencriptar);
    }
}
