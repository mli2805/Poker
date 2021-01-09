﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Probabilities
{
    public partial class Hand
    {
        public Combination IdentifyCombination()
        {
            var flush = MaybeFlush();
            if (flush != null && flush.Rank >= Rank.StraightFlush)
                return flush;

            if (MaybeFourOfAKind(out Combination fourOfAKind))
                return fourOfAKind;

            if (MaybeFullHouse(out Combination fullHouse))
                return fullHouse;

            if (flush != null && flush.Rank == Rank.Flush)
                return flush;

            if (MaybeStraight(out Combination straight))
                return straight;

            if (MaybeThreeOfAKind(out Combination threeOfAKind))
                return threeOfAKind;

            if (MaybeOneOrTwoPairs(out Combination combination))
                return combination;

            return new Combination(Rank.HighCard, _cards.SortCards().ToArray());
        }

        private Combination MaybeFlush()
        {
            if (GetFlushVariants(out List<List<Card>> variants))
            {
                foreach (var variant in variants)
                {
                    if (IsFiveCardsAreStraight(variant.ToArray()))
                    {
                        var rank = variant.First().Kind == Kind.Ace ? Rank.RoyalFlush : Rank.StraightFlush;
                        return new Combination(rank, variant.ToArray());
                    }
                }
                return new Combination(Rank.Flush, variants.First().ToArray());
            }

            return null;
        }

        private bool GetFlushVariants(out List<List<Card>> variants)
        {
            variants = new List<List<Card>>();
            for (int i = 0; i < 4; i++)
            {
                if (_suits[i] >= 5)
                {
                    var sortedCardsOfSuit = _cards.Where(c => c.Suit == (Suit)i).ToList().SortCards();
                    if (sortedCardsOfSuit.First().Kind == Kind.Ace)
                        sortedCardsOfSuit.Add(new Card((Suit)i, Kind.LowerAce));
                    for (int j = 0; j <= sortedCardsOfSuit.Count - 5; j++)
                    {
                        variants.Add(sortedCardsOfSuit.Skip(j).Take(5).ToList());
                    }

                    return true;
                }
            }

            return false;
        }

        private bool IsFiveCardsAreStraight(Card[] cards)
        {
            for (int i = 0; i < 4; i++)
                if (cards[i + 1].Kind - cards[i].Kind != 1)
                    return false;
            return true;
        }

        private bool MaybeFourOfAKind(out Combination combination)
        {
            var indexOf4 = Array.IndexOf(_kinds, 4);
            if (indexOf4 != -1)
            {
                var cardsOfCombination = _cards.Where(c => c.Kind == (Kind)indexOf4).ToList();
                cardsOfCombination.AddRange(_cards.Where(c => c.Kind != (Kind)indexOf4).ToList().SortCards().Take(1));
                combination = new Combination(Rank.FourOfAKind, cardsOfCombination.ToArray());
                return true;
            }

            combination = null;
            return false;
        }

        private bool MaybeFullHouse(out Combination combination)
        {
            var indexOf3 = Array.IndexOf(_kinds, 3);
            if (indexOf3 != -1)
            {
                var cardsOfCombination = _cards.Where(c => c.Kind == (Kind)indexOf3).ToList();
                _kinds[indexOf3] = 0;

                var secondIndex = Array.IndexOf(_kinds, 3);
                if (secondIndex == -1)
                    secondIndex = Array.IndexOf(_kinds, 2);

                _kinds[indexOf3] = 3;

                if (secondIndex != -1)
                {
                    cardsOfCombination.AddRange(_cards.Where(c => c.Kind == (Kind)secondIndex).Take(2));
                    combination = new Combination(Rank.FullHouse, cardsOfCombination.ToArray());
                    return true;
                }
            }

            combination = null;
            return false;
        }

        private bool MaybeStraight(out Combination combination)
        {
            combination = null;
            return false;
        }

        private bool MaybeThreeOfAKind(out Combination combination)
        {
            var indexOf3 = Array.IndexOf(_kinds, 3);
            if (indexOf3 != -1)
            {
                var cardsOfCombination = _cards.Where(c => c.Kind == (Kind)indexOf3).ToList();
                cardsOfCombination.AddRange(_cards.Where(c => c.Kind != (Kind)indexOf3).ToList().SortCards().Take(2));
                combination = new Combination(Rank.ThreeOfAKind, cardsOfCombination.ToArray());
                return true;
            }

            combination = null;
            return false;
        }

        private bool MaybeOneOrTwoPairs(out Combination combination)
        {
            var index = Array.IndexOf(_kinds, 2);
            if (index != -1)
            {
                var cardsOfCombination = _cards.Where(c => c.Kind == (Kind)index).ToList();
                var secondIndex = Array.IndexOf(_kinds, 2, index + 1);
                if (secondIndex > 1)
                {
                    cardsOfCombination.AddRange(_cards.Where(c => c.Kind == (Kind)secondIndex));
                    cardsOfCombination.AddRange(_cards
                        .Where(c => c.Kind != (Kind)index && c.Kind != (Kind)secondIndex)
                        .ToList().SortCards().Take(1));
                    combination = new Combination(Rank.TwoPairs, cardsOfCombination.ToArray());
                    return true;
                }
                cardsOfCombination.AddRange(_cards.Where(c => c.Kind != (Kind)index).ToList().SortCards().Take(3));
                combination = new Combination(Rank.OnePair, cardsOfCombination.ToArray());
                return true;
            }

            combination = null;
            return false;
        }
    }

}
