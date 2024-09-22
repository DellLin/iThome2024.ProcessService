using System.Text;

public class Base64Converter
{
    public static string Base64ToUtf8(string base64String)
    {
        byte[] bytes = Convert.FromBase64String(base64String);
        string utf8String = Encoding.UTF8.GetString(bytes);
        return utf8String;
    }
}