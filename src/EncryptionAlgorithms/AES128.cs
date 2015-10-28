using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public class AES128
    {
        private const int Nr = 10;
        private const int Nk = 4;
        private const int Nb = 4;   // Блок информации = 4 слова, одно слово = 32 бита (32 * 4 = 128 бит)
        private const int keySize = 16;  // размер секретного ключа = 16 байт (16 * 8 = 128 бит)
        private byte[] secretKey;
        private byte[] raundKeys;

        public AES128() 
        {
            secretKey = new byte[keySize];
            raundKeys = new byte[(Nr + 1) * Nb];
        }
        public void GenerateRaundKeys()
        {
            GenerateSecretKey();
            for (int i = 0; i <= Nr; i++)
            {

            }
        }
        private void GenerateSecretKey()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            random.NextBytes(secretKey);
        }
    }
}
