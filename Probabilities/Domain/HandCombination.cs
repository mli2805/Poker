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

           


            return new HighCard(CardsExt.SortCards(_cards).ToArray());
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
