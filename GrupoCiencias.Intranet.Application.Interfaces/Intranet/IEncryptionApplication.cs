using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Intranet
{
    public interface IEncryptionApplication
    {
        Task<string> EncryptString(string _cadenaAencriptar);
        Task<string> DescryptString(string _cadenaAencriptar);
    }
}
