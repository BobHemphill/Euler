using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem053 : Problem {
		public EulerProblem053()
			: base(null, null, new EulerProblem053Input(100, 1000000)) {
			SolutionResponse = 4075;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var eulerProblem053Input = (EulerProblem053Input)input;
			var upperLimit = eulerProblem053Input.UpperLimit;

			var retValue = 0;
			for (int i = 1; i <= upperLimit; i++) {
				for (int j = 1; j <= i; j++) {
					if (Combinations.CombinationsAreGreater(i, j, eulerProblem053Input.Threshold))
						retValue++;
				}
			}
			return retValue;
		}
	}

	public class EulerProblem053Input {
		public int UpperLimit { get; set; }
		public int Threshold { get; set; }

		public EulerProblem053Input(int UpperLimit, int Threshold) {
			this.UpperLimit = UpperLimit;
			this.Threshold = Threshold;
		}
	}
}
