using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    //Span represents a contiguous region of arbitrary memory
    public static class SpanReadonlySpan
    {
        public static void Test()
        {
            var str = "08 09 2017";
            var year = GetYear(str);
            var yearAsText = GetYearText(str);

        }

        private static int GetYear(ReadOnlySpan<char> str)
        {
            return int.Parse(str[6..]); // without allocations
        }

        private static string GetYearText(ReadOnlySpan<char> str)
        {
            return str[6..].ToString(); // there is allocation.It doesn't make sense to return string
        }

        private static Guid ToGuidFromString(ReadOnlySpan<char> id)
        {
            Span<char> base64Characters = stackalloc char[24];
            for (int i = 0; i < 22; i++)
            {
                base64Characters[i] = id[i] switch
                {
                    '-' => '/',
                    _ => id[i]
                };
            }

            Span<byte> bytes = stackalloc byte[16];

            Convert.TryFromBase64Chars(base64Characters, bytes, out _);

            return new Guid(bytes);
        }

    }
}
