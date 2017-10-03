using System;
using System.Collections.Generic;
using System.Linq;

namespace Mnist
{
    public class ImageReader : IdxReader
    {
        public ImageReader(string relativePath) : base(relativePath)
        {
            RowSize = ReadInt();
            ColumnSize = ReadInt();
        }

        public int RowSize { get; }
        public int ColumnSize { get; }

        public IEnumerable<int[]> ToEnumerable()
        {
            for (var count = 0; count < ItemCount; count++)
            {
                var buffer = new int[RowSize * ColumnSize];

                for (var i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = ReadBytes(1)[0];
                }

                yield return buffer;
            }
        }

        public float[,] GetTensor()
        {
            var itemSize = RowSize * ColumnSize;
            var buffer = new float[ItemCount, itemSize];

            for (var count = 0; count < ItemCount; count++)
            {
                var floats = ReadBytesAsFloats(itemSize);

                for (var i = 0; i < itemSize; i++)
                {
                    buffer[count, i] = floats[i];
                }
            }

            return buffer;
        }
    }
}