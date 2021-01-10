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

        [Then(@"factorial of ""(.*)"" is ""(.*)""")]
        public void ThenFactorialOfIs(int p0, int p1)
        {
            p0.Factorial().Should().Be(p1);
        }

        [Then(@"combination count of ""(.*)"" from ""(.*)"" is ""(.*)""")]
        public void ThenCombinationCountOfFromIs(int p0, int p1, int p2)
        {
            p1.CombinationCount(p0).Should().Be(p2);
        }


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

        [Then(@"variants count should match with evaluated by formula")]
        public void ThenVariantsCountShouldMatchWithEvaluatedByFormula()
        {
            var variants = Calc.GetCards(placeCount, availableCardsCount).ToList();
            variants.Count.Should().Be(availableCardsCount.CombinationCount(placeCount));
        }


    }
}
