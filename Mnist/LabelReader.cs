using System.Collections.Generic;

namespace Mnist
{
    public class LabelReader : IdxReader
    {
        public LabelReader(string relativePath) : base(relativePath)
        {
        }

        public IEnumerable<int> ToEnumerable()
        {
            for (var i = 0; i < ItemCount; i++)
            {
                var b = ReadBytes(1);
                yield return b[0];
            }

            Dispose();
        }

        public float[,] GetTensor()
        {
            const int itemSize = 1;
            const int rowSize = 10;
            var buffer = new float[ItemCount, rowSize];

            for (var count = 0; count < ItemCount; count++)
            {
                var floats = ReadBytesAsFloats(itemSize);
                var value = floats[0];
                var index = (int) value;
                buffer[count, index] = 1.0f;
            }

            return buffer;
        }
    }
}