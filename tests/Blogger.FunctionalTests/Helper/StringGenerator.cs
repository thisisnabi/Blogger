namespace Blogger.FunctionalTests.Helper;

public static class StringGenerator
{
    private readonly static Random _random = new();

    public static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        var stringBuilder = new System.Text.StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            int index = _random.Next(chars.Length);

            stringBuilder.Append(chars[index]);
        }

        return stringBuilder.ToString();
    }
}
