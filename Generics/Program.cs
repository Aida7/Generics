using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.NewGame();
        }

        public static void Print(Dictionary<string, int> text)
        {
            Console.WriteLine("\t\tСлово:\t\tКол-во:");

            int index = 0, uniqueWords = 0;
            foreach (KeyValuePair<string, int> word in text)
            {
                Console.WriteLine("{0, 2}.\t{1, 8}\t{2, 9}", ++index, word.Key, word.Value);

                if (word.Value == 1) uniqueWords++;
            }

            Console.WriteLine("\nВсего слов: {0}, из них {1} уникальных", text.Count, uniqueWords);

            Console.ReadLine();
        }

        public static void ShowCard(Card card)
        {
            Console.WriteLine($"{card.Value} {card.Suit}");
        }
    }
}
