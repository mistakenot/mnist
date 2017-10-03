using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mnist.Test
{
    [TestClass]
    public class TensorExtensionsTests
    {
        [TestMethod]
        public void TensorExtensions_NormalizeWorks_Ok()
        {
            var tensor = new Tensor(2, 2)
            {
                [0, 1] = 5,
                [1, 0] = 7,
                [1, 1] = 2
            };
            
            var result = tensor.Normalize(10);
            
            Assert.IsTrue(result[0, 1].ApproxEquals(0.5f));
            Assert.IsTrue(result[1, 0].ApproxEquals(0.7f));
            Assert.IsTrue(result[1, 1].ApproxEquals(0.2f));
        }

        [TestMethod]
        public void TensorExtensions_DotProduct_Ok()
        {
            var t1 = new Tensor(2, 3)
            {
                [0, 0] = 1f, [0, 1] = 2f, [0, 2] = 3,
                [1, 0] = 4f, [1, 1] = 5f, [1, 2] = 6
            };

            var t2 = new Tensor(3, 2)
            {
                [0, 0] = 7f,  [0, 1] = 8f,
                [1, 0] = 9f,  [1, 1] = 10f,
                [2, 0] = 11f, [2, 1] = 12f
            };

            var result = t1.DotProduct(t2);

            Assert.AreEqual(t1.M, result.M);
            Assert.AreEqual(t2.N, result.N);
            Assert.AreEqual(58, result[0, 0]);
            Assert.AreEqual(64, result[0, 1]);
            Assert.AreEqual(139, result[1, 0]);
            Assert.AreEqual(154, result[1, 1]);
        }

        [TestMethod]
        public void TensorExtensions_Add_Ok()
        {
            var t1 = new Tensor(2, 3)
            {
                [0, 0] = 1, [0, 1] = 2, [0, 2] = 3,
                [1, 0] = 4, [1, 1] = 5, [1, 2] = 6
            };

            var t2 = new Tensor(1, 3)
            {
                [0, 0] = 1, [0, 1] = 2, [0, 2] = 3
            };

            var result = t1.Add(t2);

            Assert.AreEqual(t1.M, result.M);
            Assert.AreEqual(t2.N, result.N);
            Assert.AreEqual(2, result[0, 0]);
            Assert.AreEqual(4, result[0, 1]);
            Assert.AreEqual(9, result[0, 2]);
            Assert.AreEqual(5, result[1, 0]);
            Assert.AreEqual(7, result[1, 1]);
            Assert.AreEqual(9, result[1, 2]);
        }

        [TestMethod]
        public void TensorExtensions_HadmardMultiply_OK()
        {
            var t1 = new Tensor(2, 2)
            {
                [0, 0] = 1, [0, 1] = 2,
                [1, 0] = 2, [1, 1] = 4
            };

            var t2 = new Tensor(2, 2)
            {
                [0, 0] = 4, [0, 1] = -6,
                [1, 0] = -2, [1, 1] = 3
            };

            var result = t1.HadamardProduct(t2);

            Assert.AreEqual(t1.M, result.M);
            Assert.AreEqual(t1.N, result.N);
            Assert.AreEqual(4, result[0, 0]);
            Assert.AreEqual(-12, result[0, 1]);
            Assert.AreEqual(-4, result[1, 0]);
            Assert.AreEqual(12, result[1, 1]);
        }
    }
}
