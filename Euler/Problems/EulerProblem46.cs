using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem46 : Problem {
		public EulerProblem46()
			: base(null, null, null) {
			SolutionResponse = 5777;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			Primes.InitPrimes();

			int i = 9;			
			while(true) {
				bool foundOddComposite = false;
				if (Primes.IsPrime(i)) { i += 2; continue; }
				long sqrt = (long)Math.Sqrt(i);
				for (int j = 1; j < sqrt; j++) {
					long diff = i - 2*j*j;
					if( Primes.IsPrime(diff)) {
						foundOddComposite = true;
						break;
					}
				}
				if (!foundOddComposite)
					return i;
				i += 2;
			}
		}
	}
}
