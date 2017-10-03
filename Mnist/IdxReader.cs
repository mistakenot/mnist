using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Mnist
{
    public class IdxReader : IDisposable
    {
        public const string DefaultRoot = "../../../Data/";

        private readonly BinaryReader _reader;

        public IdxReader(string relativePath)
        {
            var path = Path.Combine(DefaultRoot, relativePath);
            var fileStream = File.Open(path, FileMode.Open);
            var reader = new BinaryReader(fileStream, Encoding.BigEndianUnicode);

            _reader = reader;

            MagicNumber = ReadInt();
            ItemCount = ReadInt();
        }

        public int MagicNumber { get; }
        public int ItemCount { get; }

        public void Dispose()
        {
            _reader.Dispose();
        }

        protected int ReadInt()
        {
            var bigEndianBytes = _reader.ReadBytes(4);
            var reversed = bigEndianBytes.Reverse().ToArray();
            return BitConverter.ToInt32(reversed, 0);
        }

        public byte[] ReadBytes(int count)
        {
            return _reader.ReadBytes(count);
        }

        public float[] ReadBytesAsFloats(int count)
        {
            var bytes = ReadBytes(count);
            var floats = bytes.Select(b => (int) b).Select(i => (float) i);
            return floats.ToArray();
        }
    }
}