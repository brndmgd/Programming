using System;
/* Строка, состоящая из строк, между которыми от одного до нескольких пробелов
 * Для заданной строки выполнить следующие задачи:
 * 1. Удалить все лишние пробелы, оставив по одному.
 * 2. Выдать все слова-палиндромы
 * 3. Подсчитать количество строк, у которых первый и последний символ совпадает в любых начертаниях
 */
class Lab241111
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        input = string.Join(' ', words);
        Console.WriteLine(input);
        int count = 0;
        foreach (string word in words)
        {
            char[] letters = word.ToCharArray();
            Array.Reverse(letters);
            if (word == string.Join("", letters))
            {
                Console.WriteLine(word);
            }
            if (word.ToLower()[0] == word.ToLower()[word.Length - 1])
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}
