using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mnist.Test
{
    [TestClass]
    public class IdxReaderTests
    {
        [TestMethod]
        public void IdxReader_ShouldReadMagicNumber_Ok()
        {
            using (var reader = new IdxReader("train-images-idx3-ubyte/train-images.idx3-ubyte"))
            {
                Assert.AreEqual(2051, reader.MagicNumber);
            }
        }

        [TestMethod]
        public void IdxReader_ShouldReadItemCount_Ok()
        {
            using (var reader = new IdxReader("train-images-idx3-ubyte/train-images.idx3-ubyte"))
            {
                Assert.AreEqual(60000, reader.ItemCount);
            }
        }
    }
}