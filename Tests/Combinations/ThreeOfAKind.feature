Feature: ThreeOfAKind

Scenario: Identification of Three of a Kind and Two Pairs
	Given the first player has the "Three" of "Clubs" and the "Five" of "Clubs"
	And the second player has the "Four" of "Clubs" and the "Four" of "Diamonds"
	And the third player has the "Jack" of "Hearts" and the "Jack" of "Spades"
	When next were opened the "Four" of "Spades" and the "Three" of "Hearts" and the "Five" of "Hearts"
	Then the first player beats the third and the second beats the first