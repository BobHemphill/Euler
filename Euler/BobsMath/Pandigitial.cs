using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
	public static class Pandigital {
		public class PandigitalWrapper {
			public int Multiplier;
			public int Multiplicand;
			public int Product;
			public int PandigitalCount;

			public PandigitalWrapper(int multiplier, int multiplicand, int product, int pandigitalCount) {
				Multiplier = multiplier;
				Multiplicand = multiplicand;
				Product = product;
				PandigitalCount = pandigitalCount;
			}

			public bool IsPandigital() {
				return Pandigital.IsPandigital(Multiplier.ToString() + Multiplicand.ToString() + Product.ToString(), PandigitalCount);
			}
		}

		public static bool IsPandigital(string number, int pandigitalCount) {
			if (number.Length != pandigitalCount) return false;
			for (int i = 1; i <= pandigitalCount; i++) {
				if (!number.Contains(i.ToString()[0])) return false;
			}
			return true;		
		}
	}
}
