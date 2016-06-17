using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{
    public static class Extensions
    {



        public static bool CompareBuffers(this byte[] oldBuffer, byte[] newBuffer)
        {

            for (int channel = 0; channel < oldBuffer.Length; channel++)
            {
                if (oldBuffer[channel] != newBuffer[channel])
                {
                    return true;

                }
            }
            return false;
        }
        public static bool CompareBuffers(this byte?[] oldBuffer, byte?[] newBuffer)
        {

            for (int channel = 0; channel < oldBuffer.Length; channel++)
            {
                if (oldBuffer[channel] != newBuffer[channel])
                {
                    return true;

                }
            }
            return false;
        }







        public static int[] Replace(this int[] initialArray, int intOld, int intNew)
        {
            int[] toReturn = new int[initialArray.Length];
            initialArray.CopyTo(toReturn, 0);
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (toReturn[i] == intOld)
                {
                    toReturn[i] = intNew;
                }
            }
            return toReturn;
        }

        public static String ToFlatString(this int[] initialArray)
        {
            String toReturn = "";
            for (int i = 0; i < initialArray.Length; i++)
            {
                toReturn = toReturn + initialArray[i].ToString();
            }
            return toReturn;
        }
    }
}
