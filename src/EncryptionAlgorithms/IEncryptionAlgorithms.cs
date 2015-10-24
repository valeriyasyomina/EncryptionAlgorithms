using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    interface IEncryptionAlgorithms
    {
        int[] EncryptMessage(int[] message);
        int[] DecryptMessage(int[] message);
    }
}
