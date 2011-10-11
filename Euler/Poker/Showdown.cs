using System.Collections.Generic;

namespace Euler.Poker {
	public class Showdown {
		public Hand Player1 { get; set; }
		public Hand Player2 { get; set; }

		public Showdown(string text) {
			var textHands = text.Split(new[] { ' ' });
			Player1 = new Hand(new List<Card> { new Card(textHands[0]), new Card(textHands[1]), new Card(textHands[2]), new Card(textHands[3]), new Card(textHands[4]) });
			Player2 = new Hand(new List<Card> { new Card(textHands[5]), new Card(textHands[6]), new Card(textHands[7]), new Card(textHands[8]), new Card(textHands[9]) });
		}

		public bool Player1Wins() {
			return Player1.Wins(Player2);
		}
	}
}
