using System;
using System.Linq;

namespace Euler.Problems {

	public class EulerProblem30 : Problem {
		public EulerProblem30()
			: base(4, 19316, 5) {
				SolutionResponse = 443839;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var exp = (int)input;

			var result = 0;
			for(int i = 10;i<1000000;i++) {
				if( i==GetSumOfDigitsToExp(i, exp)) {
					result += i;
				}
			}
			return result;
		}

		int GetSumOfDigitsToExp(int i, int exp) {
			var intString = i.ToString();
			return intString.Sum(t => (int)Math.Pow(Int32.Parse(t.ToString()), exp));
		}
	}
}
