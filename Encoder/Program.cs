using Lab1;

Console.WriteLine("Enter the file name to compress");
string filePath = Console.ReadLine();

if (!File.Exists(filePath))
{
    Console.WriteLine("File does not exist");
    return;
}

var content = File.ReadAllBytes(filePath);
var alphabet = Tools.GetAlphabet();

var encoder = new Encoder();
var numericSequence = encoder.ConvertToNumericSequence(alphabet, content);
var result = encoder.EncodeArray(numericSequence);
byte[] byteArray = Tools.BitArrayToByteArray(result);
string outputFilePath = $"encoder {filePath} zipfile"; 
File.WriteAllBytes(outputFilePath, byteArray);










