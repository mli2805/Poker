using System.Linq;
using FluentAssertions;
using Probabilities;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class CombinationCountSteps
    {
        private int availableCardsCount;
        private int placeCount;

        [Given(@"there are ""(.*)"" cards in the deck")]
        public void GivenThereAreCardsInTheDeck(int p0)
        {
            availableCardsCount = p0;
        }

        [Given(@"every player gets ""(.*)"" cards")]
        public void GivenEveryPlayerGetsCards(int p0)
        {
            placeCount = p0;
        }

        [Then(@"there are ""(.*)"" variants")]
        public void ThenThereAreVariants(int p0)
        {
            var variants = Calc.GetCards(placeCount, availableCardsCount).ToList();
            variants.Count.Should().Be(p0);
        }

    }
}
