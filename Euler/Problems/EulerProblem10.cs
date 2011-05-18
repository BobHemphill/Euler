using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem10 : Problem {
		public EulerProblem10()
			: base((long)10, 17, (long)2000000) {
				SolutionResponse = 142913828922;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			return Primes.SumAllPrimes((long) input);


		}
	}
}
