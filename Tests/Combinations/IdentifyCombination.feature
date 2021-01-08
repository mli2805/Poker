Feature: IdentifyCombination

Scenario: Combination identification
	Given there is a hand with the "Five" of "Clubs" and the "Six" of "Clubs"
	Then the combination should be the "HighCard" and mayor card the "Six" of "Clubs"