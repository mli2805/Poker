using System.Collections.Generic;
using FluentAssertions;
using Logic;
using TechTalk.SpecFlow;
using Enum = System.Enum;

namespace Tests
{
    [Binding]
    class PairAndHighCardSteps
    {
        private readonly Hand _hand = new Hand();
        private readonly Hand _hand2 = new Hand();
        private readonly Hand _hand3 = new Hand();

        [Given(@"there is a hand with the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenThereIsAHandWithTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand.AddCards(new List<Card>{new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Then(@"the combination should be the ""(.*)"" and mayor card the ""(.*)"" of ""(.*)""")]
        public void ThenTheCombinationShouldBeTheAndMayorCardTheOf(string p0, string p1, string p2)
        {
            if (!Enum.TryParse(p0, true, out Rank combinationName)) return;
            if (!Enum.TryParse(p2, true, out Suit suit)) return;
            if (!Enum.TryParse(p1, true, out Kind kind)) return;

            _hand.Combination.Rank.Should().Be(combinationName);
            _hand.Combination.Cards[0].Equals(new Card(suit, kind)).Should().BeTrue();
        }

        [Given(@"there is another hand with the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenThereIsAnotherHandWithTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand2.AddCards(new List<Card>{new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Given(@"there is third hand with the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenThereIsThirdHandWithTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand3.AddCards(new List<Card>{new Card(suit1, kind1), new Card(suit2, kind2), });
        }


        [When(@"the dealer opens the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void WhenTheDealerOpensTheOfAndTheOfAndTheOf(string p0, string p1, string p2, string p3, string p4, string p5)
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

        [Then(@"the second beats the first")]
        public void ThenTheSecondBeatsTheFirst()
        {
            _hand2.CompareTo(_hand).Should().Be(1);
        }

        [Then(@"the third beats both of them")]
        public void ThenTheThirdBeatsBothOfThem()
        {
            _hand3.CompareTo(_hand).Should().Be(1);
            _hand3.CompareTo(_hand2).Should().Be(1);
        }

        [Then(@"the first hand beats the second")]
        public void ThenTheFirstHandBeatsTheSecond()
        {
            _hand.CompareTo(_hand2).Should().Be(1);
        }
       
        [When(@"one more card is opened the ""(.*)"" of ""(.*)""")]
        public void WhenOneMoreCardIsOpenedTheOf(string p0, string p1)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            var range = new List<Card> { new Card(suit1, kind1), };
            _hand.AddCards(range);
            _hand2.AddCards(range);
        }
     
        [Then(@"it is a draw")]
        public void ThenItIsADraw()
        {
            _hand.CompareTo(_hand2).Should().Be(0);
        }

    }
}
