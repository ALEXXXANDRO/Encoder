using System.Collections;

namespace Lab1;

public class Encoder
{
    public BitArray EncodeArray(List<int> numbers)
    {
        int totalLength = numbers.Select(EliasGammaEncodedLength).Sum();
        BitArray bitArray = new BitArray(totalLength);

        int currentIndex = 0;

        foreach (int number in numbers)
        {
            int bitLength = EliasGammaEncodedLength(number);

            // Добавляем префикс из нулей
            for (int i = 0; i < bitLength - 1; i++)
            {
                bitArray[currentIndex + i] = false;
            }

            // Добавляем двоичное представление числа
            int num = number;
            for (int i = 0; i < bitLength; i++)
            {
                int bitPos = bitLength - 1 - i;
                bitArray[currentIndex + bitPos] = (num & (1 << i)) != 0;
            }

            currentIndex += bitLength;
        }

        return bitArray;
    }
    
    public List<int> ConvertToNumericSequence(List<byte> alphabet, byte[] inputString)
    {
        List<int> result = new List<int>();
        foreach (var letter in inputString)
        {
            var numeric = GetNumericAnalog(letter, alphabet);
            alphabet.Add(letter);
            result.Add(numeric);
        }

        return result;
    }
    private int GetNumericAnalog(byte letter, List<byte> encodedSubstring)
    {
        var lastIndex = encodedSubstring.LastIndexOf(letter);
        return CountUniqueBytesFrom(encodedSubstring, lastIndex);
    }
    
    public  int CountUniqueBytesFrom(List<byte> array, int startIndex)
    {
        if (startIndex < 0 || startIndex >= array.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index must be within the array bounds.");
        }

        var uniqueBytes = new HashSet<byte>();

        // Итерируем по массиву начиная с заданного индекса
        for (int i = startIndex; i < array.Count; i++)
        {
            uniqueBytes.Add(array[i]);
        }

        // Возвращаем количество уникальных элементов
        return uniqueBytes.Count;
    }
    private int EliasGammaEncodedLength(int number)
    {
        int bitLength = (int)Math.Floor(Math.Log2(number)) + 1;
        return (bitLength - 1) + bitLength; // префиксные нули + двоичное число
    }
    
}