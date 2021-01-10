Feature: StraightAndFlush

Background:
	Given hand contains the "Three" of "Clubs" and the "Four" of "Clubs"

Scenario: Identify StraightFlush
	And then handsome dealer opens the "Five" of "Clubs" and the "Six" of "Clubs" and the "Seven" of "Clubs"
	And then dealer opens the "Eight" of "Spades" and the "Nine" of "Clubs"
	Then combination should be StraightFlush

Scenario: Identify StraightFlush 2
	And then handsome dealer opens the "Five" of "Clubs" and the "Six" of "Hearts" and the "Seven" of "Clubs"
	And then dealer opens the "Two" of "Clubs" and the "Ace" of "Clubs"
	Then combination should be StraightFlush

Scenario: Identify RoyalFlush
	And then handsome dealer opens the "Queen" of "Clubs" and the "King" of "Clubs" and the "Jack" of "Clubs"
	And then dealer opens the "Ten" of "Clubs" and the "Ace" of "Clubs"
	Then combination should be "RoyalFlush"

Scenario: Comparison of two StraightFlushes
	Given handA contains the "Six" of "Clubs" and the "Eight" of "Clubs"
	Given handB contains the "Six" of "Hearts" and the "King" of "Clubs"
	And then handsome dealer opens the "Five" of "Clubs" and the "Three" of "Hearts" and the "Four" of "Clubs"
	And then dealer opens the "Two" of "Clubs" and the "Ace" of "Clubs"
	Then handA beats handB
	