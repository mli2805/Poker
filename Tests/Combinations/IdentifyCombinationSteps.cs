using FluentAssertions;
using Probabilities;
using TechTalk.SpecFlow;
using Enum = System.Enum;

namespace Tests
{
    [Binding]
    class IdentifyCombinationSteps
    {
        private Hand _hand;

        [Given(@"there is a hand with the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenThereIsAHandWithTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand = new Hand();
            _hand.AddCards(new []{new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Then(@"the combination should be the ""(.*)"" and mayor card the ""(.*)"" of ""(.*)""")]
        public void ThenTheCombinationShouldBeTheAndMayorCardTheOf(string p0, string p1, string p2)
        {
            if (!Enum.TryParse(p0, true, out CombinationName combinationName)) return;
            if (!Enum.TryParse(p2, true, out Suit suit)) return;
            if (!Enum.TryParse(p1, true, out Kind kind)) return;

            _hand.Combination.Rank.Should().Be(combinationName);
            _hand.Combination.Cards[0].Equals(new Card(suit, kind)).Should().BeTrue();
        }

    }
}
