Feature: CombinationCount

Scenario: Factorial
	Then factorial of "6" is "720"
Scenario: Combination count
	Then combination count of "5" from "42" is "850668"

Scenario: Initial dealing
	Given there are "52" cards in the deck
	And every player gets "2" cards
	Then variants count should match with evaluated by formula
