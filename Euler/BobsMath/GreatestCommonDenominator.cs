using System;
using System.Collections.Generic;
using System.Linq;
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
	}
}
