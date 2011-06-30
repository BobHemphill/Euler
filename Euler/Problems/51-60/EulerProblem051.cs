using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem051 : Problem {
		public EulerProblem051()
			: base(7, (long)56003, 8) {
			SolutionResponse = (long)121313;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			int replacePrimeFamilyCount = (int)input;
			Primes.InitPrimes();
			Primes.TrimPrimes(9, 1000000);
			var primeList = Primes.AllPrimes.OrderBy(p=>p);
			int primeInitLength = 0;
			foreach (var start in primeList) {
				var stringStart = start.ToString();
				var stringStartLength = stringStart.Length;
				if (stringStartLength > primeInitLength) {
					Primes.InitPrimes((long) Math.Pow(10, stringStartLength));
					Primes.TrimPrimes((long) (Math.Pow(10, stringStartLength - 1)-1), (long) Math.Pow(10, stringStartLength));
					primeInitLength = stringStartLength;
				}
				for (int indecesToReplace = 1; indecesToReplace < stringStartLength; indecesToReplace++) {
					var indeces = Combinations.ChooseStringIndeces(indecesToReplace, stringStartLength);
					foreach (var index in indeces) {
						var permutations = Permutations.GenerateReplacements(stringStart, index);
						if (permutations.Count() >= replacePrimeFamilyCount && permutations.Count(Primes.IsPrime) >= replacePrimeFamilyCount) return permutations.Min();						
					}					
				}				
			}
			return 0;
		}
	}
}
