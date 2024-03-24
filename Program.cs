using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "cuvinte.txt"; //Lab4-Afisare_cuvinte\bin\Debug
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Fișierul de intrare nu există.");
                return;
            }

            string[][] wordsByLetter = new string[26][];

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (word.Length > 0 && char.IsLetter(word[0]))
                        {
                            int index = char.ToLower(word[0]) - 'a';
                            if (wordsByLetter[index] == null)
                            {
                                wordsByLetter[index] = new string[] { word };
                            }
                            else
                            {
                                Array.Resize(ref wordsByLetter[index], wordsByLetter[index].Length + 1);
                                wordsByLetter[index][wordsByLetter[index].Length - 1] = word;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < 26; i++)
            {
                char currentLetter = (char)('a' + i);
                Console.WriteLine($"Cuvintele care încep cu '{currentLetter}' sau '{char.ToUpper(currentLetter)}':");
                if (wordsByLetter[i] != null)
                {
                    foreach (string word in wordsByLetter[i])
                    {
                        Console.WriteLine(word);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Sfarsit");
            Console.ReadKey();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare: {ex.Message}");
        }
    }
}
