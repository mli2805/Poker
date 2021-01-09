using System;
using FluentAssertions;
using Probabilities;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class FourAndFullHouseSteps
    {
        private Hand _hand = new Hand();
        private Hand _hand2 = new Hand();

        [Given(@"the first poker player has the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheFirstPokerPlayerHasTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand.AddCards(new[] { new Card(suit1, kind1), new Card(suit2, kind2), });  }

        [Given(@"the second poker player has the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheSecondPokerPlayerHasTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand2.AddCards(new[] { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [When(@"pretty dealer opens the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void WhenPrettyDealerOpensTheOfAndTheOfAndTheOf(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            if (!Enum.TryParse(p5, true, out Suit suit3)) return;
            if (!Enum.TryParse(p4, true, out Kind kind3)) return;
            var range = new[] { new Card(suit1, kind1), new Card(suit2, kind2), new Card(suit3, kind3), };
            _hand.AddCards(range);
            _hand2.AddCards(range);
        }

        [When(@"plus to them the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void WhenPlusToThemTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            var range = new[] { new Card(suit1, kind1), new Card(suit2, kind2), };
            _hand.AddCards(range);
            _hand2.AddCards(range);
        }

        [Then(@"the result is draw")]
        public void ThenTheResultIsDraw()
        {
            _hand.CompareTo(_hand2).Should().Be(0);
        }

        [Then(@"the first player with the ""(.*)"" beats the second player with the ""(.*)""")]
        public void ThenTheFirstPlayerWithTheBeatsTheSecondPlayerWithThe(string p0, string p1)
        {
            if (!Enum.TryParse(p0, true, out Rank rank)) return;
            if (!Enum.TryParse(p1, true, out Rank rank2)) return;
            _hand.Combination.Rank.Should().Be(rank);
            _hand2.Combination.Rank.Should().Be(rank2);
            _hand.CompareTo(_hand2).Should().Be(1);
        }

    }
}
