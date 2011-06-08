using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem010 : Problem {
		public EulerProblem010()
      : base((long)10, (long)17, (long)2000000) {
        SolutionResponse = (long)142913828922;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			return Primes.SumAllPrimes((long) input);


		}
	}
}
