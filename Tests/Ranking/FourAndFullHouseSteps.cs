using System;
using System.Collections.Generic;
using FluentAssertions;
using ProbSqlite;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class FourAndFullHouseSteps
    {
        private readonly Hand _hand = new Hand();
        private readonly Hand _hand2 = new Hand();

        [Given(@"the first poker player has the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheFirstPokerPlayerHasTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Given(@"the second poker player has the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheSecondPokerPlayerHasTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand2.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
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
            var range = new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), new Card(suit3, kind3), };
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
            var range = new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), };
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


        private readonly Hand _pavel = new Hand();
        private readonly Hand _simon = new Hand();

        [Given(@"the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" are for ""(.*)""")]
        public void GivenTheOfAndTheOfAndTheOfAndTheOfAndTheOfAreFor(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            if (!Enum.TryParse(p5, true, out Suit suit3)) return;
            if (!Enum.TryParse(p4, true, out Kind kind3)) return;
            if (!Enum.TryParse(p7, true, out Suit suit4)) return;
            if (!Enum.TryParse(p6, true, out Kind kind4)) return;
            if (!Enum.TryParse(p3, true, out Suit suit5)) return;
            if (!Enum.TryParse(p8, true, out Kind kind5)) return;
            var cards = new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), new Card(suit3, kind3), new Card(suit4, kind4), new Card(suit5, kind5), };
            if (p10 == "Pavel")
                _pavel.AddCards(cards);
            if (p10 == "Simon")
                _simon.AddCards(cards);

        }

        [Then(@"Simon wins")]
        public void ThenSimonWins()
        {
            _simon.CompareTo(_pavel).Should().Be(1);
        }


    }
}
