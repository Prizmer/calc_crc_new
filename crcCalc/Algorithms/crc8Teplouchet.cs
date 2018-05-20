using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crcCalc.Algorithms
{
    class crc8Teplouchet:IAlgorithms
    {
        public bool GetCRCBytes(byte[] inputBytes, ref byte[] crcBytes)
        {
            byte byteCrcEvaluated = 0;
            foreach (byte b in inputBytes)
                byteCrcEvaluated += b;

            crcBytes = new byte[] {byteCrcEvaluated};
            return true;
        }
    }
}
