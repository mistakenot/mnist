using System;

namespace Mnist
{
    public class Tensor
    {
        public int N { get; }
        public int M { get; }

        private readonly float[,] _values;

        public Tensor(int m, int n, InitilizationMode initlInitilizationMode = InitilizationMode.Zeroes)
        {
            N = n;
            M = m;

            _values = new float[m, n];

            if (initlInitilizationMode == InitilizationMode.Random)
            {
                Randomise();
            }
        }

        public float this[int m, int n]
        {
            get { return _values[m, n]; }
            set { _values[m, n] = value; }
        }

        private void Randomise()
        {
            var random = new Random();

            for (var n = 0; n < N; n++)
            {
                for (var m = 0; m < M; m++)
                {
                    _values[n, m] = (float) random.NextDouble();
                }
            }
        }

        public enum InitilizationMode
        {
            Zeroes,
            Random
        }
    }
}