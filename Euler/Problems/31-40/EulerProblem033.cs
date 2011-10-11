using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem033 : Problem {
		public EulerProblem033()
			: base(null, null, null) {
				SolutionResponse = 100;
		}

		public List<Fraction> WeirdFractions = new List<Fraction>();
		public override object Run(RunModes runMode, object input, bool Logging) {
			for (int i = 10; i < 100; i++) {
				for (int j = i+1; j < 100; j++) {
					var numDigit1 = i / 10;
					var numDigit2 = i % 10;
					var denomDigit1 = j / 10;
					var denomDigit2 = j % 10;

					if ((numDigit1 == denomDigit2 && denomDigit1 != 0 && (double)numDigit2 / (double)denomDigit1 == (double)i / (double)j) ||
							(numDigit2 == denomDigit1 && denomDigit2 != 0 && (double)numDigit1 / (double)denomDigit2 == (double)i / (double)j) ||
							(numDigit2 == denomDigit2 && denomDigit1 != 0 && (double)numDigit1 / (double)denomDigit1 == (double)i / (double)j && numDigit2 != 0)) {
								WeirdFractions.Add(new Fraction(i, j));
					}
				}
			}
			var numerator = WeirdFractions.Aggregate((BigInteger)1, (product, item) => product * item.Numerator);
			var denominator = WeirdFractions.Aggregate((BigInteger)1, (product, item) => product * item.Denominator);
			var gcd = GreatestCommonDenominator.Get(new List<BigInteger> { numerator, denominator });
			return denominator / gcd;
		}
	}	
}
