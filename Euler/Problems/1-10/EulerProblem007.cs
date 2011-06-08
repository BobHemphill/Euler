using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem007 : Problem {
		public EulerProblem007()
      : base(6, (long)13, 10001) {
        SolutionResponse = (long)104743;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			Primes.InitPrimes(1000000);
			return Primes.PrimeAtIndex((int) input - 1);
		}
	}
}
