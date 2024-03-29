﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using ProbSqlite;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class StraightFlushSteps
    {
        private readonly Hand _hand = new Hand();
        private readonly Hand _handA = new Hand();
        private readonly Hand _handB = new Hand();

        [Given(@"hand contains the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenHandContainsTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _hand.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

       
        [Given(@"then handsome dealer opens the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenThenHandsomeDealerOpensTheOfAndTheOfAndTheOf(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            if (!Enum.TryParse(p5, true, out Suit suit3)) return;
            if (!Enum.TryParse(p4, true, out Kind kind3)) return;
            var range = new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), new Card(suit3, kind3), };
            _hand.AddCards(range);
            _handA.AddCards(range);
            _handB.AddCards(range);
        }

        [Given(@"then dealer opens the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenThenDealerOpensTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            var range = new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), };
            _hand.AddCards(range);
        }

        [Then(@"combination should be StraightFlush")]
        public void ThenCombinationShouldBeStraightFlush()
        {
            _hand.Combination.Rank.Should().Be(Rank.StraightFlush);
        }

        [Then(@"combination should be ""(.*)""")]
        public void ThenCombinationShouldBe(string p0)
        {
            if (!Enum.TryParse(p0, true, out Rank rank)) return;
            _hand.Combination.Rank.Should().Be(rank);
        }

        [Given(@"handA contains the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenHandAContainsTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _handA.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Given(@"handB contains the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenHandBContainsTheOfAndTheOf(string p0, string p1, string p2, string p3)
        {
            if (!Enum.TryParse(p1, true, out Suit suit1)) return;
            if (!Enum.TryParse(p0, true, out Kind kind1)) return;
            if (!Enum.TryParse(p3, true, out Suit suit2)) return;
            if (!Enum.TryParse(p2, true, out Kind kind2)) return;
            _handB.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
        }

        [Then(@"handA beats handB")]
        public void ThenHandABeatsHandB()
        {
            _hand.CompareTo(_handB).Should().Be(1);
        }

    }
}
