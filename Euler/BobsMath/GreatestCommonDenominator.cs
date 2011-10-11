using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Euler.BobsMath {
	public static class GreatestCommonDenominator {
		public static int Get(IEnumerable<int> numbers) {
			int minStart = numbers.Min();
			foreach (var factor in Factors.GetFactors(minStart).OrderByDescending(item=>item) ) {
				if (numbers.All(item => (item % factor)==0)) return (int)factor;
			}
			return 1;
		}

		public static int Get(IEnumerable<BigInteger> numbers) {
			BigInteger minStart = numbers.Min();
			foreach (var factor in Factors.GetFactors(minStart).OrderByDescending(item => item)) {
				if (numbers.All(item => (item % factor) == 0)) return (int)factor;
			}
			return 1;
		}

		public static BigInteger Get(BigInteger a, BigInteger b) {
			var minValue = a > b ? b : a;
			var maxValue = a > b ? a : b;

			return maxValue % minValue == 0 ? minValue : Get(minValue, maxValue%minValue);
		}
	}
}
