using System;
using FluentAssertions;
using Probabilities;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class ListsComparisonSteps
    {
        private Hand _hand1 = new Hand();
        private Hand _hand2 = new Hand();

        [Given(@"there are a hand with the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenThereAreAHandWithTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand1.AddCards(new[] { new Card(suit1, kind1), new Card(suit2, kind2), });
        }
       
        [Given(@"another hand with the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenAnotherHandWithTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand2.AddCards(new[] { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [When(@"dealer opens the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void WhenDealerOpensTheOfAndTheOfAndTheOf(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            if (!Enum.TryParse(p5, true, out Suit suit3)) return;
            if (!Enum.TryParse(p4, true, out Kind kind3)) return;
            var range = new[] { new Card(suit1, kind1), new Card(suit2, kind2), new Card(suit3, kind3), };
            _hand1.AddCards(range);
            _hand2.AddCards(range);
        }

        [Then(@"the first hand beats the second")]
        public void ThenTheFirstHandBeatsTheSecond()
        {
            _hand1.CompareTo(_hand2).Should().Be(1);
        }
       
        [When(@"one more card is opened the ""(.*)"" of ""(.*)""")]
        public void WhenOneMoreCardIsOpenedTheOf(string p0, string p1)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            var range = new[] { new Card(suit1, kind1), };
            _hand1.AddCards(range);
            _hand2.AddCards(range);
        }
     
        [Then(@"it is a draw")]
        public void ThenItIsADraw()
        {
            _hand1.CompareTo(_hand2).Should().Be(0);
        }

    }
}
