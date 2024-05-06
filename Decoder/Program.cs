using System.Collections;
using System.Text;
using Lab1;
using Decoder = Lab1.Decoder;

Console.WriteLine("Enter the file name to decompress");
string filePath = Console.ReadLine();

if (!File.Exists(filePath))
{
    Console.WriteLine($"File does not exist");
    return;
}
Console.WriteLine("Enter the result file name");
string resultName = Console.ReadLine();


var content = File.ReadAllBytes(filePath);
var alphabet = Tools.GetAlphabet();

var decoder = new Decoder();
var numericSequence = decoder.EliasGammaDecode(new BitArray(content));
var result = decoder.Decode(numericSequence,alphabet);
result.RemoveAt(result.Count - 1);
string outputFilePath = $" decoder zipfile {resultName}"; 
File.WriteAllBytes(outputFilePath, result.ToArray());