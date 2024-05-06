using System.Collections;

namespace Lab1;

public static class Tools
{
    public static byte[] BitArrayToByteArray(BitArray bits)
    {
        int numBytes = (bits.Length + 7) / 8;
        byte[] bytes = new byte[numBytes];
        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i])
            {
                bytes[i / 8] |= (byte)(1 << (i % 8));
            }
        }

        return bytes;
    }

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