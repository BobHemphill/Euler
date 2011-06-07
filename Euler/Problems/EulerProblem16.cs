using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem16 : Problem {
		public EulerProblem16()
			: base(15, (long)26, 1000) {
			SolutionResponse = (long)1366;
		}

		private static readonly Dictionary<int, Dictionary<int, long>> HopsDictionary = new Dictionary<int, Dictionary<int, long>>();
		public override object Run(RunModes runMode, object input, bool Logging) {
			return BigInt.Exp(2, (int)input).SumOfDigits();
		}
	}
}
