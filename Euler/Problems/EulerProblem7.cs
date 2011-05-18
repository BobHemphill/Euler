using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem7 : Problem {
		public EulerProblem7()
			: base(6, 13, 10001) {
				SolutionResponse = 104743;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			Primes.InitPrimes(1000000);
			return Primes.PrimeAtIndex((int) input - 1);
		}
	}
}
