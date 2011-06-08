using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem048 : Problem {
		public EulerProblem048()
			: base(10, "10405071317", 1000) {
				SolutionResponse = "9110846700";
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			int upperLimit = (int) input;
			BigInt.MaxIndex = 9;
			BigInt sumSquares = new BigInt("");
			for (int i = 1; i <= upperLimit; i++) {
				BigInt prod = BigInt.Exp(i, i);
				sumSquares = sumSquares.SumBigIntNumbers(new List<BigInt>{sumSquares, prod});			
			}

			return sumSquares.Value;
		}
	}
}
