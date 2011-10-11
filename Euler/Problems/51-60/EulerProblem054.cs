using Euler.Poker;

namespace Euler.Problems {

	public class EulerProblem054 : Problem {
		public EulerProblem054()
			: base(null, null, null) {
			SolutionResponse = 376;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			int player1Wins = 0;
			using (System.IO.StreamReader file = new System.IO.StreamReader("..\\..\\..\\InputFiles\\poker.txt")) {
				while(!file.EndOfStream) {
					var text = file.ReadLine();
					if (new Showdown(text).Player1Wins())
						player1Wins++;
				}
			}
			return player1Wins;
		}
	}						
}
