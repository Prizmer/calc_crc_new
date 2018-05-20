using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crcCalc.Algorithms
{
    class crc16ModBus : IAlgorithms
    {
        private byte[] CRC16(byte[] Arr, int length)
        {
            byte[] CRC = new byte[2];
            UInt16 B = 0xFFFF;
            int j = 0;
            int i;
            byte b;
            bool f;

            unchecked
            {
                do
                {
                    i = 0;
                    b = Arr[j];
                    B = (UInt16)(B ^ (UInt16)b);
                    do
                    {
                        f = (((B) & (1)) == 1);
                        B = (UInt16)(B / 2);
                        if (f)
                        {
                            B = (UInt16)(B ^ (0xA001));
                        }
                        i++;
                    } while (i < 8);
                    j++;
                } while (j < length);
                CRC[0] = (byte)(B);
                CRC[1] = (byte)(B >> 8);
            }
            return CRC;
        }

        public bool GetCRCBytes(byte[] inputBytes, ref byte[] crcBytes)
        {
            crcBytes = this.CRC16(inputBytes, inputBytes.Length);
            return true;
        }
    }
}
