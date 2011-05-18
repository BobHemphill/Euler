using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem9 : Problem {
		public EulerProblem9()
			: base(25, 60, 1000) {
				SolutionResponse = 31875000;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var tripletSquaredProduct = (int) input;
			long solution = tripletSquaredProduct*tripletSquaredProduct;
			for (int a = 3; a < tripletSquaredProduct; a++) {
				for (int b = a + 1; b < tripletSquaredProduct; b++) {
					if (((2*tripletSquaredProduct*a) + (2*tripletSquaredProduct*b) + (-2*a*b)) == solution) {
						return (a*b*(int) Math.Sqrt(a*a + b*b));
					}
				}
			}
			return 0;
		}
	}	
}
