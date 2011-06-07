using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem50 : Problem {
		public EulerProblem50()
			: base((long)1000, (long)953, (long)1000000) {
			SolutionResponse = (long)997651;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			Primes.InitPrimes((long)input);

			var maxRunCount = 0;
			long maxPrime = 0;
			var orderedPrimes = Primes.AllPrimes.OrderBy(p => p).ToList();

			for (int i = 1; i < orderedPrimes.Count; i++) {
				for (int j = 0; j < Math.Min(orderedPrimes.Count, 4); j++) {
					var runCount = 0;
					long runSum = 0;
					var k = j;
					while (true) {
						runSum += orderedPrimes[k];
						runCount++;
						if (runSum == orderedPrimes[i]) {
							if (runCount > maxRunCount) {
								maxRunCount = runCount;
								maxPrime = runSum;
							}
							break;
						}
						if (runSum > orderedPrimes[i]) {
							break;
						}
						k++;
					}
				}
			}
			if (Logging) Console.WriteLine(maxRunCount);
			return maxPrime;
		}
	}
}
