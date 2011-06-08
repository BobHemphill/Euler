using System;
using System.Linq;
using Euler.BobsMath;
using System.Collections.Generic;

namespace Euler.Problems {

	public class EulerProblem029 : Problem {
		public EulerProblem029()
			: base(5, 15, 100) {
				SolutionResponse = 9183;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var upperLimit = (int) input;
			var distinctExponentials = new List<BigInt>();
			for (int a = 2; a <= upperLimit; a++) {
				var bigIntA = new BigInt(a.ToString());
				for (int b = 2; b <= upperLimit; b++) {
					bigIntA = bigIntA.Product(a);
					distinctExponentials.Add(bigIntA);
				}
			}

			return distinctExponentials.Distinct().Count();
		}
	}
}
