using System;
using System.Collections.Generic;
using System.Threading;
using Euler.Problems;

namespace Euler {
	public enum RunModes {
		Test,
		Solution
	}

	public class EulerProblemEngine {
		private const int Minute = 60000;
		private Dictionary<Type, TimeSpan> _ProblemRunTimes = new Dictionary<Type, TimeSpan>();
		private List<Problem> ProblemsToSolve = new List<Problem> { 
          new EulerProblem001(), new EulerProblem002(), new EulerProblem003(), new EulerProblem004(), new EulerProblem005(),
					new EulerProblem006(), new EulerProblem007(), new EulerProblem008(), new EulerProblem009(), new EulerProblem010(),
          new EulerProblem011(), new EulerProblem012(), new EulerProblem013(), new EulerProblem014(), new EulerProblem015(),
					new EulerProblem016(), new EulerProblem017(), new EulerProblem018(), new EulerProblem019(), new EulerProblem020(), 
          new EulerProblem021(), new EulerProblem022(), new EulerProblem023(), new EulerProblem024(), new EulerProblem025(),
          new EulerProblem026(), new EulerProblem027(), new EulerProblem028(), new EulerProblem029(), new EulerProblem030(),
          new EulerProblem031(), new EulerProblem032(), new EulerProblem033(), new EulerProblem034(), new EulerProblem035(),
          new EulerProblem036(), new EulerProblem037(), new EulerProblem038(), new EulerProblem039(), new EulerProblem040(),
          new EulerProblem041(), new EulerProblem042(), new EulerProblem043(), new EulerProblem044(), new EulerProblem045(),
					new EulerProblem046(), new EulerProblem047(), new EulerProblem048(), new EulerProblem049(), new EulerProblem050(),
          new EulerProblem067() };

		public bool Logging { get; set; }

		public void Run(RunModes runMode) {
			foreach (Problem problem in ProblemsToSolve) {
				Console.WriteLine(problem.GetType());
				Run(problem, runMode, true);
				Console.WriteLine();
			}
		}

		public void Run(Problem problemToSolve, RunModes runMode, bool batchMode = false) {
			problemToSolve.RunMode = runMode;
			problemToSolve.Logging = Logging;

			Thread problemThread = new Thread(problemToSolve.Run);

			DateTime start = DateTime.Now;
			problemThread.Start();

			bool useTimer = batchMode;
			bool tooSlow = false;
			Timer EulerTimer = new Timer(
				(obj) => {
					if (useTimer) {
						if (problemThread.ThreadState == ThreadState.Running) {
							useTimer = false;
							tooSlow = true;
							Console.WriteLine(String.Format("{0} - Too Slow", problemToSolve.GetType()));
							problemThread.Abort();
						}
					}
				}, null, Minute, Minute);
			problemThread.Join();

			if (!tooSlow) {
				RunResponse response = problemToSolve.RunResponse;
				var elapsed = DateTime.Now - start;

				_ProblemRunTimes.Add(problemToSolve.GetType(), elapsed);
				var correct = response.Response != null && response.Solution != null &&
				              response.Response.Equals(response.Solution);
				if (!batchMode) {
					Console.WriteLine(String.Format("{0}.{1}.{2}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds));
					Console.WriteLine(correct);
				}
			}
		}
	}
}
