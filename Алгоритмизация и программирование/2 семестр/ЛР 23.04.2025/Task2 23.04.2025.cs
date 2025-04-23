//Любой класс работы с файлом. В файле находится набор строк (несколько строк).
//Необходимо поместить в выходной файл только те строки,
//в которых присутствует хотя бы одно нечетное число (набор цифр, ограниченных другими символами).
//Для вывода необходимо создавать файл с заданным именем.


using System;
using System.ComponentModel.Design;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2
{
    public class FileProcessor
    {
        public void ProcessFile(string inputFilePath, string outputFilePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(inputFilePath);
                var filteredLines = lines.Where(line => ContainsOddNumber(line));
                File.WriteAllLines(outputFilePath, filteredLines);
                Console.WriteLine($"Файл успешно обработан");
            }
            catch (Exception err)
            {
                Console.WriteLine($"Ошибка при обработке файла: {err.Message}");
            }
        }
        public bool ContainsOddNumber(string line)
        {
            string number = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    number += line[i];
                }
                else
                {
                    if (!string.IsNullOrEmpty(number) && int.TryParse(number, out int num) && num % 2 != 0) return true;
                    number = "";
                }
            }

            return !string.IsNullOrEmpty(number) && int.TryParse(number, out int last_num) && last_num % 2 != 0;
        }
    }
    class Programm
    {
        static void Main()
        {
            var processor = new FileProcessor();
            processor.ProcessFile("input.txt", "output.txt");
        }
    }
}
