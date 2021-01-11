Feature: FirstTest

Scenario: Compare two cards
	Given there are two instances of card "King" of "Diamonds"
	When the two cards are compared
	Then the result should be true

Scenario: Hand output
	Given there is a hand with two cards the "Four" of "Diamonds" and the "Six" of "Clubs"
	Then output should be "Four of Diamonds ; Six of Clubs ; "

Scenario: Dealer
	Then "28"th card is the "King" of "Hearts"

Scenario: Shuffle
	Then Deck of "52" cards is shuffled