namespace Pokedex.Utils
{
    public static class Utils
    {
        public static string FirstCharToUpper(this string input)
        {
            return string.Concat(input.First().ToString().ToUpper(), input.AsSpan(1));
        }
    }
}
