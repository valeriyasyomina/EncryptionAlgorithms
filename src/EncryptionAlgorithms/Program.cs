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
                Console.WriteLine("Enter algorithm name: 'RSA' or 'AES'");
                string algorithm = Console.ReadLine();
                if (algorithm == "RSA")
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
                }
                else if (algorithm == "AES")
                {
                    Console.WriteLine("Input file name for encryption: ");
                    string fileNameSourse = Console.ReadLine();

                    Console.WriteLine("Input encrypted filename: ");
                    string fileNameEncrypt = Console.ReadLine();

                    AES128 aes128 = new AES128();
                    aes128.GenerateRaundKeys();
                    aes128.EncipherFile(fileNameSourse, fileNameEncrypt);

                    Console.WriteLine("File encrypted!");
                    Console.WriteLine("Input file name for decryption: ");

                    string fileNameDecrypt = Console.ReadLine();
                    aes128.DecipherFile(fileNameEncrypt, fileNameDecrypt);                 

                    Console.WriteLine("File decrypted!");                  
                }
                else
                {
                    Console.WriteLine("Unknown algorithm");
                }
                Console.ReadLine();                  
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadLine();
            }
        }
    }
}
