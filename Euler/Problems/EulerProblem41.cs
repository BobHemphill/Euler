using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem41 : Problem {
		public EulerProblem41()
			: base(null, null, null) {
			SolutionResponse = (long)7652413;
		}
		
		public override object Run(RunModes runMode, object input, bool Logging) {
			Primes.InitPrimes((long)Math.Sqrt(987654321));
			List<long> permutations = Permutations.Generate(123456789).OrderByDescending(item=>item).ToList();

			foreach (long permutation in permutations)
				if (Primes.AllPrimes.All(item=> (permutation!=item && permutation%item!=0) || permutation==item))
					return permutation;
			permutations = Permutations.Generate(12345678).OrderByDescending(item => item).ToList();

			foreach (long permutation in permutations)
				if (Primes.AllPrimes.All(item => (permutation != item && permutation % item != 0) || permutation == item))
					return permutation;

			permutations = Permutations.Generate(1234567).OrderByDescending(item => item).ToList();
			foreach (long permutation in permutations)
				if (Primes.AllPrimes.All(item => (permutation != item && permutation % item != 0) || permutation == item))
					return permutation;
			return 1;
		}
	}
}
