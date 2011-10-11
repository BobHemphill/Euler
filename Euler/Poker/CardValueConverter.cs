using System;
using System.ComponentModel;

namespace Euler.Poker {
	public static class CardValueConverter {
		public static int FromString(string number) {
			int value;
			if (Int32.TryParse(number, out value))
				return value;

			switch (number) {
				case "T":
				case "t":
					return 10;
				case "J":
				case "j":
					return 11;
				case "Q":
				case "q":
					return 12;
				case "K":
				case "k":
					return 13;
				case "A":
				case "a":
					return 14;
				default:
					throw new InvalidEnumArgumentException(number);
			}
		}

		public static string ToString(int value) {
			switch (value) {
				case 10:
					return "T";
				case 11:
					return "J";
				case 12:
					return "Q";
				case 13:
					return "K";
				case 1:
				case 14:
					return "A";
				default:
					return value.ToString();
			}
		}
	}
}
