using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public class KeyFileReader
    {
        public static RSAKey ReadKey(string fileName)
        {
            RSAKey key = new RSAKey();
            FileStream fileStream = new FileStream(fileName, FileMode.Open);

            string fileContents;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContents = reader.ReadToEnd();
            }
            fileStream.Close();
          
            Int64[] dataArray = fileContents.Split().Select(x => Int64.Parse(x)).ToArray();
            if (dataArray.Length != 2)
            {
                throw new Exception("Error reading key from file!");
            }
            key.data = dataArray[0];
            key.N = dataArray[1];
            return key;
        }
    }
}
