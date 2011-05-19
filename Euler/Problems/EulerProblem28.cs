using System;
using System.Linq;
using Euler.BobsMath;
using System.Collections.Generic;

namespace Euler.Problems {

	public class EulerProblem28 : Problem {
		public EulerProblem28()
			: base(5, 101, 1001) {
				SolutionResponse = 669171001;
		}

		public override object Run(RunModes runMode, object input, bool Logging)
		{
			var sum = 1;
			var lastDiagonal = 1;
			var lastDiagonalIncrement = 2;
			var max = (int) input;
			for (int i = 1; i <= max/2; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					lastDiagonal += lastDiagonalIncrement;
					sum += lastDiagonal;
				}
				lastDiagonalIncrement += 2;
			}
			return sum;
		}		
	}
}
