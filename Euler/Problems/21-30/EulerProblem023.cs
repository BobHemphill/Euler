using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem023 : Problem {
		public EulerProblem023()
      : base((long)25, (long)301, (long)28123) {
        SolutionResponse = (long)4179871;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			return SumNumbersNotSumOfTwoAbundantNumbers((long)input, Logging);
		}

		private long SumNumbersNotSumOfTwoAbundantNumbers(long input, bool Logging) {
			List<long> abundantNumbers = new List<long>();
			Dictionary<long, long> abundantSums = new Dictionary<long, long>();
			List<long> numbers = new List<long>();
			
			for (long i = 1; i <= input; i++) {				
				if (Factors.GetNumberFactorType(i) == NumberFactorTypes.Abundant) {
					abundantNumbers.Add(i);
					foreach (var abundantNumber in abundantNumbers) {
						if (!abundantSums.ContainsKey(abundantNumber + i))
							abundantSums.Add(abundantNumber + i, i);
					}
				}

				if (abundantSums.ContainsKey(i)) continue;
				numbers.Add(i);
			}
			return numbers.Distinct().Sum();
		}
	}
}
