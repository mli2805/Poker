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

Scenario: Comparison of two FourOfAKind combinations
	Given the first poker player has the "Nine" of "Clubs" and the "Two" of "Spades"
	And the second poker player has the "Six" of "Clubs" and the "Six" of "Spades"
	When pretty dealer opens the "Nine" of "Diamonds" and the "Ace" of "Hearts" and the "Nine" of "Clubs"
	And plus to them the "Nine" of "Hearts" and the "Five" of "Hearts"

Scenario: Comparison of two FullHouse combinations
	Given the "Queen" of "Clubs" and the "Queen" of "Spades" and the "Queen" of "Hearts" and the "Two" of "Spades" and the "Two" of "Clubs" are for "Simon"
	Given the "Jack" of "Clubs" and the "Jack" of "Spades" and the "Jack" of "Hearts" and the "Ace" of "Spades" and the "Ace" of "Clubs" are for "Pavel"
	Then Simon wins