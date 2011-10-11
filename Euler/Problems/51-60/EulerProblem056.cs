using System;
using System.Linq;
using System.Numerics;

namespace Euler.Problems {

	public class EulerProblem056 : Problem {
		public EulerProblem056()
			: base(null, null, null) {
			SolutionResponse = 972;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var tempMax = 0;
			for (var i = 1; i < 100; i++) {
				for (var j = 2; j < 100; j++) {
					BigInteger xy = i;
					for (var k = 0; k < j-1; k++) {
						xy *= i;
					}
					var sumDigits = SumDigits(xy);
					if (sumDigits > tempMax) tempMax = sumDigits;
				}	
			}
			return tempMax;
		}

		public int SumDigits(BigInteger t) {
			return t.ToString().Aggregate(0, (current, c) => current + Int32.Parse(c.ToString()));
		}
	}
}
