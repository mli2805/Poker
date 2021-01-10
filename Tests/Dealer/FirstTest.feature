Feature: FirstTest

Scenario: Compare two cards
	Given there are two instances of card "King" of "Diamonds"
	When the two cards are compared
	Then the result should be true

Scenario: Hand output
	Given there is a hand with two cards the "Four" of "Diamonds" and the "Six" of "Clubs"
	Then output should be "Four of Diamonds ; Six of Clubs ; "

Scenario: Dealer
	Then "28"th card is the "Queen" of "Hearts"

	Scenario: New deck of cards
	Given from new deck are dealt the "6"th and the "28"th and the "48"th cards
	Then the "Eight" of "Diamonds" and the "Queen" of "Hearts" and the "Five" of "Spades" are absent from the deck