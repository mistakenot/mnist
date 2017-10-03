using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mnist.Test
{
    [TestClass]
    public class ImageReaderTests
    {
        [TestMethod]
        public void ImageReader_CanReadImage_Ok()
        {
            using (var reader = new ImageReader("train-images-idx3-ubyte/train-images.idx3-ubyte"))
            {
                var image = reader.ToEnumerable().First();
                Assert.IsTrue(image.All(b => b > -1 && b < 256));
            }
        }

        [TestMethod]
        public void ImageReader_CanGetTensor_Ok()
        {
            using (var reader = new ImageReader("train-images-idx3-ubyte/train-images.idx3-ubyte"))
            {
                var image = reader.GetTensor();

                Assert.AreEqual(2, image.Rank);
                Assert.AreEqual(784*60000, image.Length);
            }
        }
    }
}