Feature: FirstTest

Scenario: Compare two cards
	Given there are two instances of card "King" of "Diamonds"
	When the two cards are compared
	Then the result should be true
