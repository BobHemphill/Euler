using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
	public static class ParseName {
		private const int ASCII_CAPITAL_A = 65;
		private const int ASCII_CAPITAL_Z = 90;

		public static int Calculate(string name) {
			return name.Sum(item => ((int)item >= ASCII_CAPITAL_A && (int)item <= ASCII_CAPITAL_Z) ? (int)item - ASCII_CAPITAL_A + 1 : 0);
		}
	}
}
