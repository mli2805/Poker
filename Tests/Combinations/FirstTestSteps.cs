using System;
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

    }
}
