using System;
using System.Collections.Generic;
using FluentAssertions;
using Probabilities;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class ThreeAndTwoPairsSteps
    {
        private readonly Hand _hand = new Hand();
        private readonly Hand _hand2 = new Hand();
        private readonly Hand _hand3 = new Hand();

        [Given(@"the first player has the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheFirstPlayerHasTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Given(@"the second player has the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheSecondPlayerHasTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand2.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Given(@"the third player has the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenTheThirdPlayerHasTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand3.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [When(@"next were opened the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void WhenNextWereOpenedTheOfAndTheOfAndTheOf(string p0, string p1, string p2, string p3, string p4, string p5)
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
            _hand3.AddCards(range);
        }

        [Then(@"the first player beats the third and the second beats the first")]
        public void ThenTheFirstPlayerBeatsTheThirdAndTheSecondBeatsTheFirst()
        {
            _hand3.CompareTo(_hand).Should().Be(-1);
            _hand2.CompareTo(_hand).Should().Be(1);
        }

        [When(@"next card is the ""(.*)"" of ""(.*)""")]
        public void WhenNextCardIsTheOf(string p0, string p1)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            var range = new List<Card> { new Card(suit1, kind1), };
            _hand.AddCards(range);
            _hand2.AddCards(range);
            _hand3.AddCards(range);
        }

        [Then(@"third hand wins then all")]
        public void ThenThirdHandWinsThenAll()
        {
            _hand3.CompareTo(_hand).Should().Be(1);
            _hand3.CompareTo(_hand2).Should().Be(1);
        }

        [Then(@"The third hand beats only the first")]
        public void ThenTheThirdHandBeatsOnlyTheFirst()
        {
            _hand3.CompareTo(_hand).Should().Be(1);
        }

    }
}
