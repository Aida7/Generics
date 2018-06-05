using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Player
    {
        public string Name { get; set; }

        public Stack<Card> holdCards;

        public void PrintCards()
        {
            foreach (var card in holdCards)
                Program.ShowCard(card);
        }

        public Player()
        {
            holdCards = new Stack<Card>();
        }
    }
}
