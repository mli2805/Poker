using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using ProbSqlite;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class StraightOrFlushSteps
    {
        private List<Player> _players = new List<Player>();

        [Given(@"player ""(.*)"" has the ""(.*)"" of ""(.*)"" and the ""(.*)"" of ""(.*)""")]
        public void GivenPlayerHasTheOfAndTheOf(string p0, string p1, string p2, string p3, string p4)
        {
            if (!Enum.TryParse(p2, true, out Suit suit1)) return;
            if (!Enum.TryParse(p1, true, out Kind kind1)) return;
            if (!Enum.TryParse(p4, true, out Suit suit2)) return;
            if (!Enum.TryParse(p3, true, out Kind kind2)) return;
            var hand = new Hand();
            hand.AddCards(new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), });
            _players.Add(new Player(p0, hand));
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
            var range = new List<Card> { new Card(suit1, kind1), new Card(suit2, kind2), new Card(suit3, kind3), };
            foreach (var player in _players)
            {
                player.Hand.AddCards(range);
            }
        }

        [Then(@"""(.*)"" wins ""(.*)""")]
        public void ThenWins(string p0, string p1)
        {
            var player0 = _players.First(p => p.Name == p0);
            var player1 = _players.First(p => p.Name == p1);
            player0.CompareTo(player1).Should().Be(1);
        }



    }
}
