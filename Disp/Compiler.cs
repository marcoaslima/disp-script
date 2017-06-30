using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Disp
{
    public class Compiler
    {
        private byte[] GetBinaryFile(String filename)
        {
             byte[] bytes;
             using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
             {
                  bytes = new byte[file.Length];
                  file.Read(bytes, 0, (int)file.Length);
             }
             return bytes;
        }

        public String BitArrayToStr(BitArray ba)
        {
            byte[] strArr = new byte[ba.Length / 8];

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            for (int i = 0; i < ba.Length / 8; i++)
            {
                for (int index = i * 8, m = 1; index < i * 8 + 8; index++, m *= 2)
                {
                    strArr[i] += ba.Get(index) ? (byte)m : (byte)0;
                }
            }

            return encoding.GetString(strArr);
        }

        public Byte[] StringToByte(String TextLine)
        {
            return Encoding.UTF8.GetBytes(TextLine);
        }

        public Int64 StringToBit(String TextLine)
        {
            return BitConverter.ToInt64(StringToByte(TextLine), 0);
        }

        public String BitArrayToString(BitArray Array)
        {
            return BitArrayToStr(Array);
        }

    }
}
