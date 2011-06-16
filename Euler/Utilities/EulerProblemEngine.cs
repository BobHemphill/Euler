using System;
using System.Collections.Generic;
using System.Threading;
using Euler.Problems;
using Euler.Utilities;

namespace Euler {	
	public class EulerProblemEngine {
		private const int Minute = 60000;		
    private const string SlowString = "Too Slow";
    private StatisticsWriter StatisticsWriter;
    private Dictionary<BatchModes, List<Problem>> ProblemsToSolve;
    public bool Logging { get; set; }

    private static List<Problem> AllProblems = new List<Problem> { 
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
					new EulerProblem051(),
          new EulerProblem067() };
    private static List<Problem> SlowProblems = new List<Problem> { 
          new EulerProblem027(), new EulerProblem035(), new EulerProblem047(), new EulerProblem048() };
    private static List<Problem> WrongProblems = new List<Problem> { 
          new EulerProblem037() };

    public EulerProblemEngine() {
      StatisticsWriter = new StatisticsWriter();
      ProblemsToSolve = new Dictionary<BatchModes, List<Problem>>();
      ProblemsToSolve.Add(BatchModes.All, AllProblems);
      ProblemsToSolve.Add(BatchModes.Slow, SlowProblems);
      ProblemsToSolve.Add(BatchModes.Wrong, WrongProblems);
    }		

    public void Run(BatchModes batchMode = BatchModes.All) {
      var tempBatchMode = (batchMode == BatchModes.Correct || batchMode == BatchModes.Fast || batchMode== BatchModes.None) ? BatchModes.All : batchMode;
      foreach(Problem problem in ProblemsToSolve[tempBatchMode]) {
        Run(problem, RunModes.Solution, batchMode);
        ClearCache.Clear();
				Console.WriteLine();
			}
      StatisticsWriter.Dump(batchMode);
		}

		public void Run(Problem problemToSolve, RunModes runMode, BatchModes batchMode = BatchModes.None) {
			problemToSolve.RunMode = runMode;
			problemToSolve.Logging = Logging;

			Thread problemThread = new Thread(problemToSolve.Run);

			DateTime start = DateTime.Now;
			problemThread.Start();

			bool useTimer = batchMode!=BatchModes.None;
			bool tooSlow = false;
			Timer EulerTimer = new Timer(
				(obj) => {
					if (useTimer) {
						if (problemThread.ThreadState == ThreadState.Running) {
							useTimer = false;
							tooSlow = true;
							Console.WriteLine(String.Format("{0} - {1}", problemToSolve.GetType(), SlowString));
              var stat = new Statistics(problemToSolve.GetType(), SlowString, new TimeSpan(0, 1, 0), false);
              StatisticsWriter.Add(stat);
							problemThread.Abort();
						}
					}
				}, null, Minute, Minute);
			problemThread.Join();

			if (!tooSlow) {
        useTimer = false;
				RunResponse response = problemToSolve.RunResponse;
				var elapsed = DateTime.Now - start;
				var correct = response.Response != null && response.Solution != null &&
				              response.Response.Equals(response.Solution);
        var stat = new Statistics(problemToSolve.GetType(), response.Response, elapsed, correct);
        StatisticsWriter.Add(stat);
				//if (!batchMode) {
				  Console.WriteLine(stat);	
				//}                
			}      
		}
	}
}
