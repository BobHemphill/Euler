using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem049 : Problem {
		public EulerProblem049()
			: base(null, null, "148748178147") {
			SolutionResponse = "296962999629";
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			Primes.InitPrimes(10000);
			string givenSolution = input.ToString();
			var fourDigitPrimes = Primes.AllPrimes.Where(item => item > 999 && item < 10000).ToList();
			foreach (var prime in fourDigitPrimes) {
				var permutationPrimes = Permutations.Generate(prime).Where(Primes.IsPrime).Where(p => p.ToString().Length == 4).Distinct().OrderBy(p => p).ToList();
				int count = permutationPrimes.Count();
				if (count < 3) continue;

				string concatPrimes = "";
				if (Logging) {
					for (int i = 0; i < count; i++) {
						concatPrimes += permutationPrimes[i].ToString();
					}
					Console.WriteLine(concatPrimes);
				}

				for (int i = 0; i < count - 2; i++) {
					for (int j = i + 1; j < count - 1; j++) {
						var diff = permutationPrimes[j] - permutationPrimes[i];
						concatPrimes = permutationPrimes[i].ToString() + permutationPrimes[j].ToString();
						for (int k = j + 1; k < count; k++) {
							if (permutationPrimes[k] - permutationPrimes[j] == diff) {
								concatPrimes += permutationPrimes[k].ToString();
								if (givenSolution != concatPrimes) {
									Console.WriteLine();
									return concatPrimes;
								}
							}
						}
					}
				}
			}
			Console.WriteLine();
			return givenSolution;
		}
	}
}
