using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public enum CardValue
    {
        g6, g7, g8, g9, g10, J, D, K, A
    }

    public enum CardType
    {
        Пики, Буби, Черви, Крести
    }

    public class Card
    {
        public CardType Suit { get; set; }
        public CardValue Value { get; set; }

        public Card(CardType type, CardValue value)
        {
            Suit = type;
            Value = value;
        }
    }
}
