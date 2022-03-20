using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Intranet
{
    public class EncryptionApplication : IEncryptionApplication
    { 
        private readonly AppSetting _appSettings;
        public EncryptionApplication(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<string> EncryptString(string encryptString)
        {
            string key = UtilConstants.ContentService.KeyFormat; 
            byte[] keyArray; 
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(encryptString); 

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider(); 
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear(); 

            var tdes = new TripleDESCryptoServiceProvider()
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            }; 
             
            ICryptoTransform cTransform = tdes.CreateEncryptor(); 
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length); 
            tdes.Clear();
             
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length); 
        }

        public async Task<string> DescryptString(string descryptString)
        {
            string key = UtilConstants.ContentService.KeyFormat;
            byte[] keyArray; 
            byte[] Array_a_Descifrar = Convert.FromBase64String(descryptString); 
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key)); 
            hashmd5.Clear();

            var tdes = new TripleDESCryptoServiceProvider()
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            }; 

            ICryptoTransform cTransform = tdes.CreateDecryptor(); 
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length); 
            tdes.Clear(); 

            return UTF8Encoding.UTF8.GetString(resultArray);
        }  
    }
}
