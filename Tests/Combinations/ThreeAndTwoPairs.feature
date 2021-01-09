Feature: ThreeOfAKind

Background: Identification of Three of a Kind and Two Pairs
	Given the first player has the "Three" of "Clubs" and the "Five" of "Clubs"
	And the second player has the "Four" of "Clubs" and the "Four" of "Diamonds"
	And the third player has the "Jack" of "Hearts" and the "Jack" of "Spades"
	When next were opened the "Four" of "Spades" and the "Three" of "Hearts" and the "Five" of "Hearts"

Scenario: Comparison of ThreeOfAKind and TwoPairs and Pair combinations
	Then the first player beats the third and the second beats the first

Scenario: Comparison of two ThreeOfAKind combination
	When next card is the "Jack" of "Clubs"
	Then third hand wins then all

Scenario: Comparison of two TwoPairs combinations
	When next card is the "Two" of "Clubs"
	When next card is the "Two" of "Hearts"
	Then The third hand beats only the first
