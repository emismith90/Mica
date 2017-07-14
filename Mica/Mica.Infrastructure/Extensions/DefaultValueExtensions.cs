namespace Mica.Infrastructure.Extensions
{
    public static class DefaultValueExtensions
    {
        public static string Default(this string current, string defaultValue = "")
        {
            return Or(current, defaultValue);
        }

        public static int Default(this int? current, int defaultValue = 0)
        {
            return Or(current, defaultValue);
        }

        public static double Default(this double? current, double defaultValue = 0.0)
        {
            return Or(current, defaultValue);
        }
        public static decimal Default(this decimal? current, decimal defaultValue = (decimal)0.0)
        {
            return Or(current, defaultValue);
        }

        public static bool Default(this bool? current, bool defaultValue = false)
        {
            return Or(current, defaultValue);
        }

        public static string Or(string src, string target)
        {
            return !string.IsNullOrEmpty(src)
                ? src
                : target;
        }

        public static int Or(int? src, int target)
        {
            return !src.HasValue
                ? src.Value
                : target;
        }

        public static double Or(double? src, double target)
        {
            return !src.HasValue
                ? src.Value
                : target;
        }

        public static decimal Or(decimal? src, decimal target)
        {
            return !src.HasValue
                ? src.Value
                : target;
        }

        public static bool Or(bool? src, bool target)
        {
            return !src.HasValue
                ? src.Value
                : target;
        }

    }
}
