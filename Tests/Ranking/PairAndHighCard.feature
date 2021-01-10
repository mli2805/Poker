Feature: PairAndHighCard

Scenario: Identify and compare hands with PairOfAKind
	Given there is a hand with the "Five" of "Clubs" and the "Six" of "Clubs"
	Then the combination should be the "HighCard" and mayor card the "Six" of "Clubs"

	Given there is another hand with the "Two" of "Hearts" and the "Two" of "Spades"
	And there is third hand with the "Queen" of "Spades" and the "Six" of "Diamonds"	
	When the dealer opens the "Jack" of "Spades" and the "Queen" of "Clubs" and the "Ace" of "Hearts"
	Then the second beats the first
	And the third beats both of them

Scenario: Compare two hands with HighCard combinations
	Given there is a hand with the "Four" of "Diamonds" and the "Six" of "Clubs"
	And there is another hand with the "Three" of "Hearts" and the "Six" of "Spades"
	When the dealer opens the "Jack" of "Spades" and the "Queen" of "Clubs" and the "Ace" of "Hearts"
	Then the first hand beats the second
	When one more card is opened the "Ten" of "Hearts"
	Then it is a draw