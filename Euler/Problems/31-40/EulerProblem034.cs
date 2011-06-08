using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem034 : Problem {
		public EulerProblem034()
			: base(null, null, null) {
			SolutionResponse = 40730;
		}

		public List<Fraction> WeirdFractions = new List<Fraction>();
		public override object Run(RunModes runMode, object input, bool Logging) {
			var sum = 0;
			for (int i = 3; i < 1000000; i++) {
				if (i == 145) sum+=0;
				if (i.ToString().Select(item => Factorial.Calculate(Int32.Parse(item.ToString()))).Sum() == i)
					sum += i;
			}
			return sum;
		}
	}
}
