using System;

namespace Mnist
{
    public static class TensorExtensions
    {
        public static Tensor Normalize(this Tensor t, float max, float min = 0)
        {
            if (max <= min) throw new InvalidOperationException();

            var result = new Tensor(t.M, t.N);

            for (var n = 0; n < t.N; n++)
            {
                for (var m = 0; m < t.M; m++)
                {
                    var val = t[n, m];

                    if (val > max) throw new InvalidOperationException();
                    if (val < min) throw new InvalidOperationException();

                    var r = (val - min) / max;

                    result[n, m] = r;
                }
            }

            return result;
        }

        public static Tensor DotProduct(this Tensor a, Tensor b)
        {
            if (a.M != b.N) throw new InvalidOperationException();
                
            var result = new Tensor(a.M, b.N);

            for (var a_m = 0; a_m < a.M; a_m++)
            {
                for (var b_n = 0; b_n < b.N; b_n++)
                {
                    var accum = 0f;

                    for (var a_n = 0; a_n < b.M; a_n++)
                    {
                        accum += a[a_m, a_n] * b[a_n, b_n];
                    }

                    result[a_m, b_n] = accum;
                }   
            }

            return result;
        }

        public static Tensor HadamardProduct(this Tensor a, Tensor b)
        {
            if (!(a.M == b.M && a.N == b.N)) throw new InvalidOperationException();

            var result = new Tensor(a.M, a.N);

            for (var m = 0; m < a.M; m++)
            {
                for (var n = 0; n < a.N; n++)
                {
                    result[m, n] = a[m, n] * b[m, n];
                }
            }

            return result;
        }

        public static Tensor Add(this Tensor a, Tensor b)
        {
            throw new NotImplementedException();
        }

        public static Tensor Softmax(this Tensor t)
        {
            // t is (number_of_inputs * number_of_classes)
            // t[m] = one row of input
            // t[m, n] = evidence of input row r being in class n

            var result = new Tensor(t.M, t.N);

            for (var m = 0; m < t.M; m++)
            {
                // For each input...
                var sum_of_exponents = 0f;

                for (var n = 0; n < t.N; n++)
                {
                    // For each class
                    var x_i = t[m, n];
                    sum_of_exponents += (float) Math.Exp(x_i);
                }

                for (var n = 0; n < t.N; n++)
                {
                    var x_i = t[m, n];
                    var exp_x_i = (float) Math.Exp(x_i);
                    var softmax_xi = exp_x_i / sum_of_exponents;

                    result[m, n] = softmax_xi;
                }
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="a">Predicted values.</param>
        /// <param name="b">Actual values.</param>
        /// <returns></returns>
        public static Tensor CrossEntropy(this Tensor a, Tensor b)
        {
            if (a.M != b.M || a.N != b.N) throw new InvalidOperationException();

            var result = new Tensor(a.M, 1);

            for (var m = 0; m < a.M; m++)
            {
                var resultRow = 0.0f;

                for (var n = 0; n < a.N; n++)
                {
                    resultRow += b[m, n] * (float) Math.Log(a[m, n]);
                }

                result[m, 0] = -1f * resultRow;
            }

            return result;
        }

        public static Tensor ReduceMean(this Tensor t)
        {
            var result = new Tensor(t.M, 1);

            for (var m = 0; m < t.M; m++)
            {
                for (var n = 0; n < t.N; n++)
                {
                    
                }
            }

            throw new NotImplementedException();
        }
    }
}