using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem052 : Problem {
		public EulerProblem052()
			: base(2, 125874, 6) {
			SolutionResponse = 142857;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var multPermutation = (int) input;

			var start = 1;
			while(true) {
				if (start.ToString().Length != (start * multPermutation).ToString().Length) {
					start = (int) Math.Pow(10, start.ToString().Length);
					continue;
				}
				if (!Permutations.UniqueDigits(start)) {
					start++; 
					continue;
				}
				var permutations = Permutations.Generate(start);
				var missingMultiple = false;
				for (int i = 1; i <= multPermutation; i++) {
					if (!permutations.Contains(start*i)) {
						missingMultiple = true; 
						break;
					}
				}
				if (!missingMultiple) return start;
				start++;
			}			
		}
	}
}
