namespace Lab1;

public static class Tools
{
    public static List<byte> GetAlphabet()
    {
        List<byte> byteList = new List<byte>(256);

        for (int i = 0; i < 256; i++)
        {
            byteList.Add((byte) (255 - i));
        }

        return byteList;
    }
}