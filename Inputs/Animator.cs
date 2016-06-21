using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{
    public class Animator : IQueueBuffer
    {
        public Animator()
        {
            BufferSize = 512;
            RepeatTimes = 0;
            Priority = 1;
            RepeatForever = false;
        }
        public int BufferSize { get; set; }
        public int RepeatTimes { get; set; }

        private bool _repeatForeverValue;
        public bool RepeatForever {
            get {
                return _repeatForeverValue;
            }
            set
            {
                _repeatForeverValue = value;
                if (!value) RepeatTimes = 0;
                if (value && RepeatTimes == 0) RepeatTimes = 1;
            }
            }
        public List<byte?[]> Frames { get; set; }
        public int Priority { get; set; }
        public bool Pause { get; set; }
        private int currentFrame = 0;

        public byte?[] Buffer()
        {
            if (Frames == null ||
                Frames.Count == 0 ||
                Pause) return BufferExtensions.EmptyNullableBuffer(this.BufferSize);

            if (currentFrame < Frames.Count) return Frames[currentFrame++];

            //Else if currentFrame has surpassed frameCount...
            if (RepeatTimes > 0)
            {
                RepeatTimes-=(RepeatForever? 0:1); //If we are repeating forever, don't decrement RepeatTimes.
                currentFrame = 0;
                return Frames[currentFrame];
            }
            Pause = true;
            return BufferExtensions.EmptyNullableBuffer(this.BufferSize);
        }
    }
}
