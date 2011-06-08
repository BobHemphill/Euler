using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem025 : Problem {
		public EulerProblem025()
			: base(3, 12, 1000) {
			SolutionResponse = 4782;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var fibUpperLimit = new BigInt("9", (int) input );
			var fibSequence = Fibonacci.Sequence(fibUpperLimit).ToList();

			if(Logging)
				foreach (var i in fibSequence) {
					Console.WriteLine(i);
				}
			return fibSequence.IndexOf(fibSequence.First(item => item.Value.Length == (int)input)) + 1;
		}				
	}
}
