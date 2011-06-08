using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem037 : Problem {
		public EulerProblem037()
			: base(null,null,null) {
				SolutionResponse = (long)748317;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var truncatable = Primes.AllPrimes.Where(item => item > 10 && Primes.IsTruncatable(item)).ToList();
			return truncatable.Sum();
		}
	}
}
