using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public class KeyFileWriter
    {
        public static void WriteKey(RSAKey key, string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {              
                streamWriter.Write("{0} {1}", key.data, key.N);                
            }
        }
    }
}
