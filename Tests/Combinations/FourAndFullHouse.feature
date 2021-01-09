Feature: FourAndFullHouse

Scenario: Identify Four of a kind
	Given the first poker player has the "Three" of "Clubs" and the "Four" of "Spades"
	And the second poker player has the "King" of "Clubs" and the "King" of "Spades"
	When pretty dealer opens the "King" of "Diamonds" and the "Ten" of "Spades" and the "Ten" of "Clubs"
	And plus to them the "Ten" of "Diamonds" and the "Ten" of "Hearts"
	Then the result is draw

Scenario: Identify FullHouse
	Given the first poker player has the "Three" of "Clubs" and the "Nine" of "Spades"
	And the second poker player has the "Ace" of "Clubs" and the "Ace" of "Spades"
	When pretty dealer opens the "Nine" of "Diamonds" and the "Ace" of "Hearts" and the "Nine" of "Clubs"
	And plus to them the "Nine" of "Hearts" and the "Five" of "Hearts"
	Then the first player with the "FourOfAKind" beats the second player with the "FullHouse"