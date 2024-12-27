using System;
/* Строка
1) необходимо определить символ, который чаще всего встречается в комбинации a*b, где * - 1 символ
латинские символы регистр не имеет значения
2) на вход подаётся строка, латинские буквы только строчные, необходимо определить максимальную длину
подпоследовательности, состоящей из троек элементов abc, при этом в конце может стоять только часть этой тройки
*/
class Lab2511
{
    static void Main()
    {
        /*
        string a = Console.ReadLine().ToLower();
        int max = a.Split("aab").Length;
        char maxCh = 'a';
        for (int i = 1; i < 26; i++)
        {
            int count = a.Split($"a{(char)('a' + i)}b").Length;
            if (max < count)
            {
                max = count;
                maxCh = (char)('a' + i);
            }
        }
        Console.WriteLine(maxCh);
        */
        
        string a = Console.ReadLine();
        int count = 0, max = 0;
        for (int i = 0; i < a.Length; i++)
        {
            string abc = "abc";
            if (a[i] == abc[count % 3]) count++;
            else
            {
                max = Math.Max(count, max);
                count = 0;
            }
        }
        Console.WriteLine(Math.Max(count, max));
        
    }
}