using System;
using System.Runtime.CompilerServices;

namespace Mnist
{
    public static class FloatExtensions
    {
        public static bool ApproxEquals(this float y, float x, int decimalPlaces = 3)
        {
            var y_ = Math.Round(y * decimalPlaces);
            var x_ = Math.Round(x * decimalPlaces);

            return y_ == x_;
        }
    }
}