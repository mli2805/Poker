﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using ProbSqlite;
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

     
        [Then(@"card with id ""(.*)"" is the ""(.*)"" of ""(.*)""")]
        public void ThenCardWithIdIsTheOf(int p0, string p1, string p2)
        {
            if (!Enum.TryParse(p2, true, out Suit suit)) return;
            if (!Enum.TryParse(p1, true, out Kind kind)) return;
            var card = p0.ToCard();
            var expectation = new Card(suit, kind);
            card.Should().BeEquivalentTo(expectation);
        }


        [Then(@"Deck of ""(.*)"" cards is shuffled")]
        public void ThenDeckOfCardsIsShuffled(int p0)
        {
            var deck = Deck.Shuffle();
            deck.Count.Should().Be(p0);
        }

    }
}
