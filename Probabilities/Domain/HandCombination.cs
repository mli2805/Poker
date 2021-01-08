using System;
using System.Linq;

namespace Probabilities
{
    public partial class Hand
    {
        public Combination IdentifyCombination()
        {
            var isFlush = _suits.Any(i => _suits[i] >= 5);

            var line = GetLine();
            var isStraight = line.LenghtOfLine == 5;



            if (MaybeThreeOfAKind(out Combination combinationThree))
                return combinationThree;

            if (MaybeOneOrTwoPairs(out Combination combination))
                return combination;
            
            return new HighCard(_cards.SortCards().ToArray());
        }

        private bool MaybeThreeOfAKind(out Combination combination)
        {
            var indexOf3 = Array.LastIndexOf(_kinds, 3);
            if (indexOf3 != -1)
            {
                var cardOfPair = _cards.Where(c => c.Kind == (Kind)indexOf3).ToList();
                cardOfPair.AddRange(_cards.Where(c => c.Kind != (Kind)indexOf3).ToList().SortCards().Take(2));
                combination = new ThreeOfAKind(cardOfPair.ToArray());
                return true;
            }

            combination = null;
            return false;
        }

        private bool MaybeOneOrTwoPairs(out Combination combination)
        {
            var index = Array.LastIndexOf(_kinds, 2);
            if (index != -1)
            {
                var cardOfPair = _cards.Where(c => c.Kind == (Kind)index).ToList();
                var secondIndex = Array.LastIndexOf(_kinds, 2, index - 1);
                if (secondIndex > 1)
                {
                    cardOfPair.AddRange(_cards.Where(c=>c.Kind == (Kind)secondIndex));
                    cardOfPair.AddRange(_cards
                        .Where(c => c.Kind != (Kind)index && c.Kind != (Kind)secondIndex)
                        .ToList().SortCards().Take(1));
                    combination = new TwoPairs(cardOfPair.ToArray());
                    return true;
                }
                cardOfPair.AddRange(_cards.Where(c => c.Kind != (Kind)index).ToList().SortCards().Take(3));
                combination = new OnePair(cardOfPair.ToArray());
                return true;
            }

            combination = null;
            return false;
        }

        private Line GetLine()
        {
            var maxLineLenght = 0;
            var minorCardOfMaxLine = Kind.Ace;
            var lineLenght = 0;
            for (int i = (int)Kind.Ace; i >= (int)Kind.BadAce; i--)
            {
                if (_kinds[i] == 0)
                {
                    if (lineLenght > maxLineLenght)
                    {
                        maxLineLenght = lineLenght;
                        minorCardOfMaxLine = (Kind)(i + 1);
                    }
                    lineLenght = 0;
                }
                else
                    lineLenght++;

                if (lineLenght == 5)
                    return new Line((Kind)(i + 1), 5);
            }
            return new Line(minorCardOfMaxLine, maxLineLenght);
        }
    }

}
