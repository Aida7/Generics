using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Staticstic
    {
        private Dictionary<string, int> TextStat = new Dictionary<string, int>();

        private string[] words;
        public void Add(string poem)
        {
            string[] buffer = poem.Split(new char[] { ' ', ',', '.', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            words = new string[buffer.Length];

            buffer.CopyTo(words, 0);

            for (int i = 0; i < words.Length; i++)
            {
                int wordCount = 0;
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[i].ToLower().Equals(words[j].ToLower())) wordCount++;
                }

                if (!TextStat.ContainsKey(words[i])) TextStat.Add(words[i], wordCount);
            }

        }

        public void Print()
        {
            Console.WriteLine("\t\tСлово:\t\tКол-во:");

            int index = 0, uniqueWords = 0;
            foreach (KeyValuePair<string, int> word in TextStat)
            {
                Console.WriteLine("{0, 2}.\t{1, 8}\t{2, 9}", ++index, word.Key, word.Value);

                if (word.Value == 1) uniqueWords++;
            }

            Console.WriteLine("\nВсего слов: {0}, из них {1} уникальных", TextStat.Count, uniqueWords);

            Console.ReadLine();
        }
    }
}
