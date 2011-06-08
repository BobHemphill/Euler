using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem012 : Problem {
		public EulerProblem012()
			: base(5, (long)28, 500) {
				SolutionResponse = (long)76576500;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			int triangleIndex = 1;
			var numberOfDivisors = (int) input;
			while (!HasAtLeastNumberOfDivisors(numberOfDivisors, GenerateTriangle(triangleIndex))) {
				triangleIndex++;
			}

			return GenerateTriangle(triangleIndex);
		}

		static long GenerateTriangle(int triangleIndex) {
			var triangleNumber = 0;
			for (var i = 1; i <= triangleIndex; i++) {
				triangleNumber += i;
			}
			return triangleNumber;
		}

		static bool HasAtLeastNumberOfDivisors(int numberOfDivisors, long triangleNumber) {
			return Factors.GetFactors(triangleNumber).Count() >= numberOfDivisors;
		}	
	}
}
