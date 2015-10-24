using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public class RSA : IEncryptionAlgorithms
    {
        public int P { get; protected set; }
        public int Q { get; protected set; }
        public int N { get; protected set; }
        public int M { get; protected set; }
        public int E { get; protected set; }

        protected int D;

        public RSA(int minSimpleNumber, int maxSimpleNumber)
        {           
            //поиск простых чисел по алгоритму, надо реализовать
            P = minSimpleNumber;
            Q = maxSimpleNumber;

            N = P * Q;
            M = (P - 1) * (Q - 1);

           // E = GetRelativelySimpleNumber(M);
            E = 7;
            D = 3;
           
        }
        public int[] EncryptMessage(int[] message)
        { 
            if (message.Length == 0)
            {
                throw new Exception("Error! Empty message!");
            }
            int[] encryptedMessage = new int[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                encryptedMessage[i] = PowFast(message[i], E, N);
            }
            return encryptedMessage;
        }
        public int[] DecryptMessage(int[] message)
        {
            if (message.Length == 0)
            {
                throw new Exception("Error! Empty message!");
            }
            int[] decryptedMessage = new int[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                decryptedMessage[i] = PowFast(message[i], D, N);
            }
            return decryptedMessage;
        }

        private void ExtendedEuclidsAlgorithm()
        {

        }
        /// <summary>
        /// Находит взаимно простое число с number, меньшее number
        /// </summary>
        /// <param name="number">Число, для которого изщется взаимно простое</param>
        /// <returns></returns>
        private int GetRelativelySimpleNumber(int number)
        {
            for (int searchNumber = number - 1; searchNumber > 1; --searchNumber)
            {
                if (EuclidsAlgorithm(searchNumber, number) == 1)
                {
                    return searchNumber;
                }
            }
            return number;
        }

        /// <summary>
        /// Находит наибольший общий делитель двух целых чисел по алгоритму Евклида
        /// </summary>
        /// <returns>НОД</returns>
        private int EuclidsAlgorithm(int firstNumber, int secondNumber)
        {
            int tmpFirstNumber = firstNumber;
            int tmpSecondNumber = secondNumber;
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
        private int PowFast(int symbol, int key, int n)
        {
            int r = 1;
            int keyCount = 0;
            while (keyCount < key)
            {
                keyCount++;               
                r = (r * symbol) % n;                
            }
            return r;
        }
    }
}
