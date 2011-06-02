using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem47 : Problem {
		public EulerProblem47()
			: base(3, 644, 4) {
				SolutionResponse = 134043;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			int runAndNumberDistinctPrimeFactors = (int) input;			
			Primes.InitPrimes();

			int i = 2;
			int startRun = 0;
			int runCount = 0;
			
			while (true) {
				if (Primes.UniquePrimeFactors(i, false).Count() == runAndNumberDistinctPrimeFactors) {
					if (runCount == 0)
						startRun = i;
					runCount++;
				}
				else {
					startRun = 0;
					runCount = 0;
				}

				if (runCount == runAndNumberDistinctPrimeFactors)
					return startRun;
				i++;
			}
		}
	}
}
