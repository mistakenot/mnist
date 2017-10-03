using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mnist.Test
{
    [TestClass]
    public class LabelReaderTests
    {
        [TestMethod]
        public void LabelReader_CanReadLabel_Ok()
        {
            using (var reader = new LabelReader("t10k-labels-idx1-ubyte/t10k-labels.idx1-ubyte"))
            {
                var vals = reader.ToEnumerable().Take(3).ToArray();

                Assert.AreEqual(7, vals[0]);
                Assert.AreEqual(2, vals[1]);
                Assert.AreEqual(1, vals[2]);
            }
        }

        [TestMethod]
        public void LabelReader_CanGetTensor_Ok()
        {
            using (var reader = new LabelReader("t10k-labels-idx1-ubyte/t10k-labels.idx1-ubyte"))
            {
                var vals = reader.GetTensor();
                
                Assert.AreEqual(10000*10, vals.Length);
            }
        }
    }
}
