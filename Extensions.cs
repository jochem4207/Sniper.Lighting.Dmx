using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{
    public static class Extensions
    {










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
