using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem043 : Problem {
		public EulerProblem043()
			: base(null, null, null) {
				SolutionResponse = "16695334890";
		}

		public override object Run(RunModes runMode, object input, bool Logging) {			
			Primes.InitPrimes(500);
			List<string> pandigitals = Permutations.Generate("9876543210").ToList();
			List<string> pandigitalsIndexProperty = new List<string>();
			bool notIndexProperty = false;
			foreach (var pandigital in pandigitals) {
				notIndexProperty = false;
				for (int i = 0; i < 7; i++) {
					if (Int64.Parse(pandigital.Substring(i+1, 3)) % Primes.AllPrimes[i] != 0) {
						notIndexProperty = true;
						break;						
					}
				}
				if (!notIndexProperty)
					pandigitalsIndexProperty.Add(pandigital);				
			}
			var bigIntList = pandigitalsIndexProperty.Select(item => new BigInt(item)).ToList();
			return new BigInt("").SumBigIntNumbers(bigIntList).Value;
		}
	}
}
