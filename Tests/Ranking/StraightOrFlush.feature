Feature: StraightOrFlush

Scenario: Identify and compare flushes
	Given player "Mary" has the "Ace" of "Clubs" and the "Two" of "Clubs"
	And player "Paul" has the "Eight" of "Clubs" and the "Jack" of "Clubs"
	When dealer opens the "Three" of "Clubs" and the "Four" of "Clubs" and the "Six" of "Clubs"
	Then "Mary" wins "Paul"

Scenario: Compare Flush and StraightFlush
	Given player "Jackie" has the "Three" of "Clubs" and the "Two" of "Clubs"
	And player "Anna" has the "King" of "Clubs" and the "Jack" of "Clubs"
	When dealer opens the "Five" of "Clubs" and the "Four" of "Clubs" and the "Ace" of "Clubs"
	Then "Jackie" wins "Anna"

Scenario: Identify and compare Straight
	Given player "Petr" has the "Three" of "Clubs" and the "Two" of "Spades"
	And player "Joe" has the "Five" of "Clubs" and the "Five" of "Diamonds"
	When dealer opens the "Five" of "Hearts" and the "Four" of "Clubs" and the "Six" of "Spades"
	Then "Petr" wins "Joe"