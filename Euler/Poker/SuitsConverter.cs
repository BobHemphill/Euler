using System.ComponentModel;

namespace Euler.Poker {
	public static class SuitsConverter {
		public static Suits FromString(string value) {
			switch (value) {
				case "C":
				case "c":
					return Suits.Clubs;
				case "D":
				case "d":
					return Suits.Diamonds;
				case "H":
				case "h":
					return Suits.Hearts;
				case "S":
				case "s":
					return Suits.Spades;
				default:
					throw new InvalidEnumArgumentException(value);
			}
		}

		public static string ToString(Suits suit) {
			switch (suit) {
				case Suits.Clubs:
					return "C";
				case Suits.Diamonds:
					return "D";
				case Suits.Hearts:
					return "H";
				case Suits.Spades:
					return "S";
				default:
					throw new InvalidEnumArgumentException(suit.ToString());
			}
		}
	}
}
