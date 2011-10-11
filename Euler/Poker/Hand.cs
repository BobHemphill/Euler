using System.Collections.Generic;
using System.Linq;

namespace Euler.Poker {
	public class Hand {
		public List<Card> Cards { get; set; }

		private HandRanks rank;
		public HandRanks Rank {
			get { return rank; }
		}

		public List<int> ValueRanks { get; set; }

		public Hand(IEnumerable<Card> Cards) {
			this.Cards = Cards.OrderBy(c => c.Value).ToList();
			EvaluateHand();
		}

		private void EvaluateHand() {
			if (IsFiveOfAKind()) {
				rank = HandRanks.FiveOfAKind;
				ValueRanks = new List<int> { Cards[0].Value };
			}
			else if (IsFlush() && IsStraight()) {
				rank = HandRanks.StraightFlush;
				ValueRanks = new List<int> { Cards.Max(c => c.Value) };
			}
			else if (IsFourOfAKind()) {
				rank = HandRanks.FourOfAKind;
			}
			else if (IsFullHouse()) {
				rank = HandRanks.FullHouse;
			}
			else if (IsFlush()) {
				rank = HandRanks.Flush;
				ValueRanks = Cards.OrderByDescending(c => c.Value).Select(c => c.Value).ToList();
			}
			else if (IsStraight()) {
				rank = HandRanks.Straight;
				ValueRanks = new List<int> { Cards.Max(c => c.Value) };
			}
			else if (IsThreeOfAKind()) {
				rank = HandRanks.ThreeOfAKind;
			}
			else if (IsTwoPair()) {
				rank = HandRanks.TwoPair;
			}
			else if (IsPair()) {
				rank = HandRanks.Pair;
			}
			else {
				rank = HandRanks.HighCard;
				ValueRanks = Cards.OrderByDescending(c => c.Value).Select(c => c.Value).ToList();
			}
		}

		bool IsFiveOfAKind() {
			return Cards[0].Value == Cards[1].Value &&
						 Cards[0].Value == Cards[2].Value &&
						 Cards[0].Value == Cards[3].Value &&
						 Cards[0].Value == Cards[4].Value;
		}

		bool IsFourOfAKind() {
			if (Cards[0].Value == Cards[1].Value &&
					Cards[0].Value == Cards[2].Value &&
					Cards[0].Value == Cards[3].Value) {
				ValueRanks = new List<int> { Cards[0].Value };
				return true;
			}
			if (Cards[1].Value == Cards[2].Value &&
					Cards[1].Value == Cards[3].Value &&
					Cards[1].Value == Cards[4].Value) {
				ValueRanks = new List<int> { Cards[1].Value };
				return true;
			}
			return false;
		}

		bool IsFullHouse() {
			if (Cards[0].Value == Cards[1].Value &&
					Cards[0].Value == Cards[2].Value &&
					Cards[3].Value == Cards[4].Value) {
				ValueRanks = new List<int> { Cards[0].Value };
				return true;
			}
			if (Cards[0].Value == Cards[1].Value &&
					Cards[2].Value == Cards[3].Value &&
					Cards[2].Value == Cards[4].Value) {
				ValueRanks = new List<int> { Cards[2].Value };
				return true;
			}
			return false;
		}

		bool IsFlush() {
			return Cards[0].Suit == Cards[1].Suit &&
						 Cards[0].Suit == Cards[2].Suit &&
						 Cards[0].Suit == Cards[3].Suit &&
						 Cards[0].Suit == Cards[4].Suit;
		}

		bool IsStraight() {
			return (Cards[0].Value + 1 == Cards[1].Value &&
							Cards[1].Value + 1 == Cards[2].Value &&
							Cards[2].Value + 1 == Cards[3].Value &&
							Cards[3].Value + 1 == Cards[4].Value) ||
							IsLowStraight();
		}

		bool IsLowStraight() {
			if (Cards[4].Value == 14 && Cards[0].Value == 2 &&
					Cards[0].Value + 1 == Cards[1].Value &&
					Cards[1].Value + 1 == Cards[2].Value &&
					Cards[2].Value + 1 == Cards[3].Value) {
				Cards[0].IsHigh = false;
				return true;
			}
			return false;
		}

		bool IsThreeOfAKind() {
			if (Cards[0].Value == Cards[1].Value &&
					Cards[0].Value == Cards[2].Value) {
				ValueRanks = new List<int> { Cards[0].Value };
				return true;
			}
			if (Cards[1].Value == Cards[2].Value &&
					Cards[1].Value == Cards[3].Value) {
				ValueRanks = new List<int> { Cards[1].Value };
				return true;
			}
			if (Cards[2].Value == Cards[3].Value &&
					Cards[2].Value == Cards[4].Value) {
				ValueRanks = new List<int> { Cards[2].Value };
				return true;
			}
			return false;
		}

		bool IsTwoPair() {
			if (Cards[0].Value == Cards[1].Value &&
					Cards[2].Value == Cards[3].Value) {
				ValueRanks = new List<int> { Cards[2].Value, Cards[0].Value, Cards[4].Value };
				return true;
			}
			if (Cards[0].Value == Cards[1].Value &&
					Cards[3].Value == Cards[4].Value) {
				ValueRanks = new List<int> { Cards[3].Value, Cards[0].Value, Cards[2].Value };
				return true;
			}
			if (Cards[1].Value == Cards[2].Value &&
					Cards[3].Value == Cards[4].Value) {
				ValueRanks = new List<int> { Cards[3].Value, Cards[1].Value, Cards[0].Value };
				return true;
			}
			return false;
		}

		bool IsPair() {
			if (Cards[0].Value == Cards[1].Value) {
				ValueRanks = new List<int> { Cards[0].Value, Cards[4].Value, Cards[3].Value, Cards[2].Value };
				return true;
			}
			if (Cards[1].Value == Cards[2].Value) {
				ValueRanks = new List<int> { Cards[1].Value, Cards[4].Value, Cards[3].Value, Cards[0].Value };
				return true;
			}
			if (Cards[2].Value == Cards[3].Value) {
				ValueRanks = new List<int> { Cards[2].Value, Cards[4].Value, Cards[1].Value, Cards[0].Value };
				return true;
			}
			if (Cards[3].Value == Cards[4].Value) {
				ValueRanks = new List<int> { Cards[3].Value, Cards[2].Value, Cards[1].Value, Cards[0].Value };
				return true;
			}
			return false;
		}

		public bool Wins(Hand opponent) {
			if (Rank > opponent.Rank) return true;
			if (Rank < opponent.Rank) return false;

			for (int i = 0; i < ValueRanks.Count; i++) {
				if (ValueRanks[i] > opponent.ValueRanks[i]) return true;
				if (ValueRanks[i] < opponent.ValueRanks[i]) return false;
			}
			return false;
		}
	}
}
