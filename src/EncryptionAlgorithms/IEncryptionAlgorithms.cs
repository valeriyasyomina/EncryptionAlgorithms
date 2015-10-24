using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    interface IEncryptionAlgorithms
    {
        byte[] EncryptMessage(byte[] message);
        byte[] DecryptMessage(byte[] message);
    }
}
