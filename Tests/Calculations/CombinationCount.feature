Feature: CombinationCount

Scenario: Initial dealing
	Given there are "52" cards in the deck
	And every player gets "2" cards
	Then there are "1326" variants

Scenario: Open 5 cards
	Given there are "5" cards in the deck
	And every player gets "3" cards
	Then there are "10" variants