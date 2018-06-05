using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Game
    {
        private List<Player> players;

        private Stack<Card> deck;

        public void InitDeck()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 9; j++)

                    deck.Push(new Card((CardType)i, (CardValue)j));

            var sorted = deck.OrderBy(x => Guid.NewGuid()).ToList();
            deck.Clear();

            foreach (var card in sorted)
                deck.Push(card);
        }

        public void NewGame()
        {
            Console.Clear();

            players.Clear();

            int choice;
            Console.Write("Сколько игроков будет учавствовать? (минимум 2): ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 2)
            {
                if (choice < 2) Console.Write("\nТребуется как минимум 2 игрока!\n" +
                    "Введите число: ");
                else Console.Write("Введите число: ");
            }

            for (int i = 0; i < choice; i++)
            {
                players.Add(new Player());

                Console.Write("Введите имя {0} игрока: ", i+1);

                players[i].Name = Console.ReadLine();
            }

            Console.Clear();

            StartGame();
        }

        public void StartGame()
        {
            InitDeck();

            while (deck.Count != 0)
            {
                foreach (var player in players)
                {
                    if (deck.Count == 0) break;

                    player.holdCards.Push(deck.Pop());
                }
            }

            List<Card> pool = new List<Card>();

            while (true)
            {
                for(int i=players.Count-1; i>=0; i--)
                {
                    if (players[i].holdCards.Count == 0)
                        players.Remove(players[i]);
                }

                foreach (var player in players)
                    pool.Add(player.holdCards.Pop());

                int maxValuePosition = -1;
                Card maxValueCard = pool[0];

                for (int i = 0; i < pool.Count; i++)
                    if (pool[i].Value > maxValueCard.Value) maxValuePosition = i;

                if (maxValuePosition == -1)
                {
                    Console.WriteLine(players[0].Name + " выигрвает кон!\n");

                    // Переворачиваю этим самым колоду игрока
                    players[0].holdCards = new Stack<Card>(players[0].holdCards);

                    pool.Reverse();
                    foreach (var card in pool)
                        players[0].holdCards.Push(card);

                    // Обратно переворачиваю колоду после вставок новых карт
                    players[0].holdCards = new Stack<Card>(players[0].holdCards);

                    if (players[0].holdCards.Count == 36)
                    {
                        WinnerAnnounce(players[0]); break;
                    }

                    pool.Clear();
                }
                else
                {
                    Console.WriteLine(players[maxValuePosition].Name + " выигрвает кон!\n");

                    players[maxValuePosition].holdCards = new Stack<Card>(players[maxValuePosition].holdCards);

                    foreach (var card in pool)
                        players[maxValuePosition].holdCards.Push(card);

                    players[maxValuePosition].holdCards = new Stack<Card>(players[maxValuePosition].holdCards);

                    if (players[maxValuePosition].holdCards.Count == 36)
                    {
                        WinnerAnnounce(players[maxValuePosition]); break;
                    }

                    pool.Clear();
                }

            }

            string choice;
            Console.WriteLine("\nНе желаете сыграть еще раз? (1-Да) (0-нет)");

            choice = Console.ReadLine();
            if (choice.Equals("1"))
               NewGame();

            else
                Console.WriteLine("Выход с игры...");
        }

        private void WinnerAnnounce(Player player)
        {
            Console.WriteLine($"{player.Name} собрал все карты и является победителем этой игры!!!");

            player.PrintCards();
        }

        public Game()
        {
            players = new List<Player>();

            deck = new Stack<Card>();
        }
    }
}
