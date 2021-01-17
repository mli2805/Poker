using System.Collections.Generic;

namespace Logic
{
    public static class CombinationsEnumerator
    {
        public static IEnumerable<int[]> GetCombinationsOf(this int availableCardsCount, int placeCount)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 1; i < placeCount; i++)
                dict.Add(i, i);
            dict.Add(placeCount, placeCount - 1); // will be incremented on first step

            while (true)
            {
                var next = GetNext(dict, placeCount, availableCardsCount);
                if (next == null) break;
                yield return next;
            }
        }

        private static int[] GetNext(Dictionary<int, int> dict, int placeCount, int availableCount)
        {
            var place = placeCount;
            dict[place]++;
            var limitForPlace = availableCount;
            while (dict[place] > limitForPlace && place > 1)
            {
                place--;
                limitForPlace--;
                dict[place]++;
                for (int j = place+1; j <= placeCount; j++)
                    dict[j] = dict[j - 1] + 1;
            }
            return dict[place] > limitForPlace ? null : Convert(dict, placeCount);
        }

        private static int[] Convert(Dictionary<int, int> dict, int placeCount)
        {
            var result = new int[placeCount];
            for (int j = 0; j < placeCount; j++)
                result[j] = dict[j + 1];
            return result;
        }

        /// <summary>
        /// converts number to Card
        /// </summary>
        /// <param name="number">from range 1..52</param>
        /// <returns></returns>
        public static Card ToCard(this int number)
        {
            number--;
            return new Card((Suit)(number / 13), (Kind)(number % 13));
        }
    }


}
