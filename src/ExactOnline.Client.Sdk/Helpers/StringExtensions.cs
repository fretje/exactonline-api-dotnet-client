namespace ExactOnline.Client.Sdk.Helpers
{
    public static class StringExtensions
    {
        public static int? ToNullableInt(this string s) => int.TryParse(s, out var i) ? i : (int?)null;

        public static long? ToNullableLong(this string s) => long.TryParse(s, out var i) ? i : (long?)null;
    }
}
