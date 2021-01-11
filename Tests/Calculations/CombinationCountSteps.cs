using System;
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

        [Then(@"variants count should match with evaluated by formula")]
        public void ThenVariantsCountShouldMatchWithEvaluatedByFormula()
        {
            var variants = availableCardsCount.GetCombinationsOf(placeCount).ToList();
            variants.Count.Should().Be(availableCardsCount.CombinationCount(placeCount));
        }

        [Then(@"There should be ""(.*)"" pairs")]
        public void ThenThereShouldBePairs(int p0)
        {
            var pairs = EquipotentPairs.Get();
            pairs.Count.Should().Be(p0);
        }

        private PairOfCards _first;
        private PairOfCards _second;

        [Given(@"the first pair is the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheFirstPairIsTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _first = new PairOfCards(new Card(suit1, kind1), new Card(suit2, kind2));
        }

        [Given(@"the second pair is the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheSecondPairIsTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _second = new PairOfCards(new Card(suit1, kind1), new Card(suit2, kind2));
        }

        [Then(@"the first pair balance win minus lose will be (.*)")]
        public void ThenTheFirstPairBalanceWinMinusLoseWillBe(int p0)
        {
            _first.Compare(_second).Should().Be(p0);
        }

    }
}
