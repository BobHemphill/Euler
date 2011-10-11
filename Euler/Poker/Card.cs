namespace Euler.Poker {
	public class Card {
		int value;
		public int Value { get { return IsHigh ? value : 1; } set { this.value = value; } }
		public Suits Suit { get; set; }
		public bool IsHigh { get; set; }

		public Card(string text) {
			Value = CardValueConverter.FromString(text[0].ToString());
			Suit = SuitsConverter.FromString(text[1].ToString());
			IsHigh = true;
		}

		public override string ToString() {
			return CardValueConverter.ToString(Value) + SuitsConverter.ToString(Suit);
		}
	}
}
