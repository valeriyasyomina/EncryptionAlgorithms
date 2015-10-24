using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input file name for encryption: ");
                string fileNameSourse = Console.ReadLine(); 
  
                Console.WriteLine("Input encrypted filename: ");
                string fileNameEncrypt = Console.ReadLine();   
           
                RSA rsa = new RSA(); 
                rsa.GenerateKeys();

                rsa.Encrypt(fileNameSourse, fileNameEncrypt, rsa.PUBLIC_KEY_FILE_NAME);
                Console.WriteLine("File encrypted!");

                Console.WriteLine("Input file name for decryption: ");
                string fileNameDecrypt = Console.ReadLine();
                rsa.Decrypt(fileNameEncrypt, fileNameDecrypt, rsa.PRIVATE_KEY_FILE_NAME);

                Console.WriteLine("File decrypted!");
                Console.ReadLine();
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
