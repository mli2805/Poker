using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Probabilities;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class FirstTestSteps
    {

        private Card _card1;
        private Card _card2;
        private bool _comparisonResult;

        [Given(@"there are two instances of card ""(.*)"" of ""(.*)""")]
        public void GivenThereAreTwoInstancesOfCardOf(string p0, string p1)
        {
            if (!Enum.TryParse(p1, true, out Suit suit)) return;
            if (!Enum.TryParse(p0, true, out Kind kind)) return;
            _card1 = new Card(suit, kind);
            _card2 = new Card(suit, kind);
        }

        [When(@"the two cards are compared")]
        public void WhenTheTwoCardsAreCompared()
        {
            _comparisonResult = _card1.Equals(_card2);
        }

        [Then(@"the result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            _comparisonResult.Should().BeTrue();
        }

        private readonly Hand _hand = new Hand();

        [Given(@"there is a hand with two cards the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenThereIsAHandWithTwoCardsTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Then(@"output should be ""(.*)""")]
        public void ThenOutputShouldBe(string p0)
        {
            _hand.ToString().Should().Be(p0);
        }

        [Then(@"""(.*)""th card is the ""(.*)"" of ""(.*)""")]
        public void ThenThCardIsTheOf(int p0, string p1, string p2)
        {
            if (!Enum.TryParse(p2, true, out Suit suit)) return;
            if (!Enum.TryParse(p1, true, out Kind kind)) return;
            Deck.Convert(p0).Equals(new Card(suit, kind)).Should().Be(true);
        }

        private readonly Deck _deck = new Deck();

        [Given(@"from new deck are dealt the ""(.*)""th and the ""(.*)""th and the ""(.*)""th cards")]
        public void GivenFromNewDeckAreDealtTheThAndTheThAndTheThCards(int p0, int p1, int p2)
        {
            var set = new[] { p0, p1, p2 };
            _deck.DealCardsByNumbers(set);
        }

        [Then(@"the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" are absent from the deck")]
        public void ThenTheOfAndTheOfAndTheOfAreAbsentFromTheDeck(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            if (!Enum.TryParse(p5, true, out Suit suit3)) return;
            if (!Enum.TryParse(p4, true, out Kind kind3)) return;
            _deck.Cards.FirstOrDefault(c => c.Suit == suit1 && c.Kind == kind1).Should().BeNull();
            _deck.Cards.FirstOrDefault(c => c.Suit == suit2 && c.Kind == kind2).Should().BeNull();
            _deck.Cards.FirstOrDefault(c => c.Suit == suit3 && c.Kind == kind3).Should().BeNull();
        }

    }
}
