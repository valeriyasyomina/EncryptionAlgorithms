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
                int[] bytes = new int[7];
                bytes[0] = 101;
                bytes[1] = 67;
                bytes[2] = 201;
                bytes[3] = 0;
                bytes[4] = 57;
                bytes[5] = 0;
                bytes[6] = 10;
              //  Console.WriteLine("Input filename: ");
               // string fileName = Console.ReadLine();

               /* using (FileStream file = new FileStream(@"C:\Users\valeriya\Desktop\view.txt", FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                }*/

                RSA rsa = new RSA(3, 11);
            //    int[] bytesAsInts = Array.ConvertAll(bytes, c => (int)c);
                int[] messsage = rsa.EncryptMessage(bytes);

                int[] dec = rsa.DecryptMessage(messsage);

                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
