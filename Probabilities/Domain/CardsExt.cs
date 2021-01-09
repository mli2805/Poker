using System;
using System.Collections.Generic;
using System.Linq;

namespace Probabilities
{
    public static class CardsExt
    {
        public static List<Card> SortCards(this List<Card> cards)
        {
            var result = new List<Card>();
            var kinds = (Kind[])Enum.GetValues(typeof(Kind));
            for (int i = kinds.Length -1 ; i >= 0; i--)
            {
                var kind = kinds[i];
                var allOfAKind = cards.Where(c => c.Kind == kind);
                result.AddRange(allOfAKind);
            }
            return result;
        }
    }
}
