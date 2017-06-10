using System;

namespace Mica.Infrastructure.Extensions
{
    public static class NumericCompareExtensions
    {
        public static int NoLessThan(this int origin, int target = 0)
        {
            return Pick(origin, target, true);
        }

        public static double NoLessThan(this double origin, double target = 0.0)
        {
            return Pick(origin, target, true);
        }

        public static int NoGreaterThan(this int origin, int target = 0)
        {
            return Pick(origin, target, false);
        }

        public static double NoGreaterThan(this double origin, double target = 0.0)
        {
            return Pick(origin, target, false);
        }

        private static T Pick<T>(T a, T b, bool pickMaximum) where T : IComparable
        {
            return pickMaximum ? (a.CompareTo(b) > 0 ? a : b) : (a.CompareTo(b) < 0 ? a : b);
        }
    }
}
