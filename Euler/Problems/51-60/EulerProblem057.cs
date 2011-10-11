using System;
using System.Collections.Generic;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem057 : Problem {
		public EulerProblem057()
			: base(null, null, null) {
			SolutionResponse = null;
		}

		public static Dictionary<int, Fraction> GetDenominatorCache = new Dictionary<int, Fraction> { { 1, new Fraction(2, 1) } };
		public override object Run(RunModes runMode, object input, bool Logging) {
			var moreNumeratorsThanDenominators = 0;
			Fraction fraction;
			for (var i = 1; i <= 1000; i++) {
				fraction = 1 + new Fraction(1, GetDenominator(i));
				if (Logging) {
					Console.WriteLine(String.Format("{0} --> {1}", i, fraction));
				}
				if (!fraction.MoreDigitsInNumerator) continue;
				moreNumeratorsThanDenominators++;
			}
			return moreNumeratorsThanDenominators;
		}

		static Fraction GetDenominator(int iteration) {
			if (GetDenominatorCache.ContainsKey(iteration)) return GetDenominatorCache[iteration];
			//if(iteration==1) return new Fraction(2,1);
			var denominator = 2 + new Fraction(1, GetDenominator(iteration - 1));
			denominator.Simplify();
			GetDenominatorCache.Add(iteration, denominator);
			return denominator;
		}
	}
}
