using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crcCalc.Algorithms
{
    interface IAlgorithms
    {
        bool GetCRCBytes(byte[] inputBytes, ref byte[] crcBytes);
    }
}
