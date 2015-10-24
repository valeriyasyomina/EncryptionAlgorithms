using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public class RSA 
    {
        public string PUBLIC_KEY_FILE_NAME = "./public_key.txt";

        public string PRIVATE_KEY_FILE_NAME = "./private_key.txt";
       
        private Random random;

        private Int64[] simpleList;     
        public void GenerateKeys()
        {
            random = new Random((int)DateTime.Now.Ticks % Int32.MaxValue);
            simpleList = GenerateSimpleNumbersList(1000);

            Int64 P = GenerateRandomNumberInt16();
            Int64 Q = P;
            while (P == Q)
            {
                Q = GenerateRandomNumberInt16();
            }
            Int64 N = P * Q;
            Int64 M = (P - 1) * (Q - 1);
            Int64 E = 0;
            do
            {
                E = GenerateRandomNumberInt32();
            }
            while (EuclidsAlgorithm(E, M) != 1);
            Int64 D = ExtendedEuclid(E, M);

            RSAKey publicKey = new RSAKey();
            publicKey.data = E;
            publicKey.N = N;

            RSAKey privateKey = new RSAKey();
            privateKey.data = D;
            privateKey.N = N;

            KeyFileWriter.WriteKey(publicKey, PUBLIC_KEY_FILE_NAME);
            KeyFileWriter.WriteKey(privateKey, PRIVATE_KEY_FILE_NAME);
        }
        private Int64[] GenerateSimpleNumbersList(int arraySize)
        {
            Int64[] simpleList = new Int64[arraySize];
            Int64 i = 0;
            Int64 number = 2;
            bool isSimpleNumber = true;

            while (i < arraySize) 
            {
                isSimpleNumber = true;
                for (Int64 j = 2; j < number / 2 + 1; j++)
                {
                    if (number % j == 0)
                    {
                        isSimpleNumber = false;
                        break;
                    }
                }
                if (isSimpleNumber)
                {
                    simpleList[i] = number;
                    i++;
                }
                number++;
            }
            return simpleList;
        }
        private Int16 GenerateRandomNumberInt16()
        {
            Int16 number = 0;
            do
            {
                number = (Int16) random.Next(1, Int16.MaxValue);
            }
            while (!IsSimpleNumber(number));
            return number;
        }
        private Int32 GenerateRandomNumberInt32()
        {
            Int32 number = 0;
            do
            {
                number = (Int32)random.Next(1, Int32.MaxValue);
            }
            while (!IsSimpleNumber(number));
            return number;
        }

        private bool IsSimpleNumber(Int64 number)
        {
            for (int i = 0; i < simpleList.Length; i++)
            {
                if (number % simpleList[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private Int64 GCD(Int64 a, Int64 b, out Int64 x, out Int64 y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }
            Int64 x1, y1;
            Int64 d = GCD(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }

        private Int64 ExtendedEuclid(Int64 a, Int64 n)
        {
            Int64 x, y;
            Int64 g = GCD(a, n, out x, out y);
            if (g != 1)
                throw new ArgumentException();

            return (x % n + n) % n;
        }

        public void Encrypt(string sousreFileName, string destFileName, string keyFilename)
        {
            RSAKey publicKey = KeyFileReader.ReadKey(keyFilename);
            FileStream sourseFileStream = new FileStream(sousreFileName, FileMode.Open);
            FileStream destFileStream = new FileStream(destFileName, FileMode.Create);

            using (BinaryWriter binaryWriter = new BinaryWriter(destFileStream))
            {
                using (BinaryReader binaryReader = new BinaryReader(sourseFileStream))
                {
                    while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                    {
                        Console.WriteLine("Byte encrypted");
                        binaryWriter.Write(PowModFast(Convert.ToInt64(binaryReader.ReadByte()), publicKey.data, publicKey.N));
                    }
                }
            }
            sourseFileStream.Close();
            destFileStream.Close();
        }

        public void Decrypt(string sousreFileName, string destFileName, string keyFilename)
        {
            RSAKey privateKey = KeyFileReader.ReadKey(keyFilename);
            FileStream sourseFileStream = new FileStream(sousreFileName, FileMode.Open);
            FileStream destFileStream = new FileStream(destFileName, FileMode.Create);

            using (BinaryWriter binaryWriter = new BinaryWriter(destFileStream))
            {
                using (BinaryReader binaryReader = new BinaryReader(sourseFileStream))
                {
                    while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                    {
                        Console.WriteLine("Byte decrypted");                 
                        binaryWriter.Write(Convert.ToByte(PowModFast(binaryReader.ReadInt64(), privateKey.data, privateKey.N)));
                    }
                }
            }
            sourseFileStream.Close();
            destFileStream.Close();
        }


  
        /// <summary>
        /// Находит наибольший общий делитель двух целых чисел по алгоритму Евклида
        /// </summary>
        /// <returns>НОД</returns>
        private Int64 EuclidsAlgorithm(Int64 firstNumber, Int64 secondNumber)
        {
            Int64 tmpFirstNumber = firstNumber;
            Int64 tmpSecondNumber = secondNumber;
            while (tmpFirstNumber != 0 && tmpSecondNumber != 0)
            {
                if (tmpFirstNumber > tmpSecondNumber)
                {
                    tmpFirstNumber = tmpFirstNumber % tmpSecondNumber;
                }
                else
                {
                    tmpSecondNumber = tmpSecondNumber % tmpFirstNumber;
                }
            }
            return tmpFirstNumber + tmpSecondNumber;
        }

        /// <summary>
        /// Алгоритм быстроего возведения числа в степень по модулю
        /// </summary>
        /// <param name="symbol">возводимое число</param>
        /// <param name="key">степень</param>
        /// <param name="n">число, по которому берется модуль</param>
        /// <returns>Число, возведенное в степень по модулю</returns>
        private Int64 PowModFast(Int64 symbol, Int64 key, Int64 n)
        {
            Int64 r = 1;
            Int64 keyCount = 0;
            while (keyCount < key)
            {
                keyCount++;               
                r = (r * symbol) % n;                
            }
            return r;
        }
    }
}
