using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{
    public static class BufferExtensions
    {

        public static QueueBuffer[] CopyQueueBuffersToArray(this Dictionary<Guid, IQueueBuffer> queueBuffers)
        {
            QueueBuffer[] buffers = null;

            var queueCount = queueBuffers.Count;
            buffers = new QueueBuffer[queueCount];
            int index = 0;
            foreach (IQueueBuffer queueBuffer in queueBuffers.Values)
            {
                buffers[index++] = new QueueBuffer() { CurrentPriority = queueBuffer.Priority, HardBuffer = queueBuffer.Buffer() };
            }

            return buffers;
        }

        public static byte[] MergeQueueBuffers(this IQueueBuffer[] buffers, int busLength)
        {
            byte[] finalBuffer = new byte[busLength];
            byte?[] newBuffer = new byte?[busLength];
            IOrderedEnumerable<IQueueBuffer> orderedBuffers = buffers.OrderBy(queueBuffer => queueBuffer.Priority);
            foreach (var queueBuffer in orderedBuffers)
            {
                byte?[] queueBufferBuffer = queueBuffer.Buffer();
                for (int channel = 0; channel < busLength; channel++)
                {
                    byte? value = queueBufferBuffer[channel];
                    if (value != null)
                        newBuffer[channel] = value;
                }
            }
            for (int i = 0; i < busLength; i++)
            {
                if (newBuffer[i] == null)
                    finalBuffer[i] = 0;
                else
                    finalBuffer[i] = (byte)newBuffer[i];
            }

            return finalBuffer;

        }


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
