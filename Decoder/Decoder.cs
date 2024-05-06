using System.Collections;

namespace Lab1;

public class Decoder
{
    // Основной метод для декодирования гамма-кодирования Элиаса
    public List<int> EliasGammaDecode(BitArray bitArray)
    {
        List<int> decodedNumbers = new List<int>();
        int currentIndex = 0;

        while (currentIndex < bitArray.Count)
        {
            // Получаем количество начальных нулей
            int zeroCount = CountLeadingZeros(bitArray, ref currentIndex);

            // Длина числа
            int bitLength = zeroCount + 1;

            // Извлекаем само число
            int number = ExtractNumber(bitArray, bitLength, ref currentIndex);

            decodedNumbers.Add(number);
        }

        return decodedNumbers;
    }
    
    // Метод для подсчета начальных нулей
    private int CountLeadingZeros(BitArray bitArray, ref int currentIndex)
    {
        int zeroCount = 0;
        while (currentIndex < bitArray.Count && !bitArray[currentIndex])
        {
            zeroCount++;
            currentIndex++;
        }
        return zeroCount;
    }

    // Метод для извлечения числа из BitArray, основываясь на длине
    private int ExtractNumber(BitArray bitArray, int bitLength, ref int currentIndex)
    {
        int number = 0;
        for (int i = 0; i < bitLength; i++)
        {
            if (currentIndex < bitArray.Count && bitArray[currentIndex])
            {
                number |= (1 << (bitLength - i - 1)); // Устанавливаем соответствующий бит
            }
            currentIndex++;
        }
        return number;
    }
    
    
    public List<byte> Decode(List<int> numericSequence, List<byte> alphabet)
    {
        List<byte> result = new List<byte>();
        foreach (var item in numericSequence)
        {
            var letter = GetCharAnalog(item, alphabet);
            alphabet.Add(letter);
            result.Add(letter);
        }
        return result;
    }

    private byte GetCharAnalog(int item, List<byte> alphabet)
    {
        if(item!= 0)
            return ReverseAndRemoveDuplicates(alphabet)[item-1];
        return alphabet.Last();
    }
    
    private List<byte> ReverseAndRemoveDuplicates(List<byte> originalList)
    {
        HashSet<byte> uniqueElements = new HashSet<byte>();
        List<byte> resultList = new List<byte>();
        
        for (int i = originalList.Count - 1; i >= 0; i--)
        {
            byte element = originalList[i];
            
            if (uniqueElements.Add(element))
            {
                resultList.Add(element);
            }
        }

        return resultList;
    }
}