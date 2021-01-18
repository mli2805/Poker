using System;
using System.Collections.Generic;
using System.Linq;

namespace ProbSqlite
{
    public static class CardsExt
    {
        public static List<Card> SortCards(this List<Card> cards)
        {
            var result = new List<Card>();
            foreach (var kind in (Kind[])Enum.GetValues(typeof(Kind)))
            {
                var allOfAKind = cards.Where(c => c.Kind == kind);
                result.AddRange(allOfAKind);
            }
            return result;
        }
    }
}
