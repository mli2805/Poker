Feature: ListsComparison

Scenario: Two hands with HighCard combinations
	Given there are a hand with the "Four" of "Diamonds" and the "Six" of "Clubs"
	And another hand with the "Three" of "Hearts" and the "Six" of "Spades"
	When dealer opens the "Jack" of "Spades" and the "Queen" of "Clubs" and the "Ace" of "Hearts"
	Then the first hand beats the second
	When one more card is opened the "Ten" of "Hearts"
	Then it is a draw