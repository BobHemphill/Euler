using System;
using System.Collections.Generic;
using Euler.Problems;

namespace Euler
{
    public enum RunModes
    {
        Test,
        Solution
    }
    public class EulerProblemEngine
    {
        private Dictionary<Type, TimeSpan> _ProblemRunTimes = new Dictionary<Type, TimeSpan>();
        private List<Problem> ProblemsToSolve = new List<Problem> { 
          new EulerProblem1(), new EulerProblem2(), new EulerProblem3(), new EulerProblem4(), new EulerProblem5(),
					new EulerProblem6(), new EulerProblem7(), new EulerProblem8(), new EulerProblem9(), new EulerProblem10(),
          new EulerProblem18(), new EulerProblem19(), 
          new EulerProblem20(), new EulerProblem21(), new EulerProblem22(), new EulerProblem23(), new EulerProblem24(), new EulerProblem25(),
          new EulerProblem67() };

        public bool Logging { get; set; }

        public void Run(RunModes runMode) {        	
					foreach (Problem problem in ProblemsToSolve) {
						Console.WriteLine(problem.GetType());
						Run(problem, runMode);
						Console.WriteLine();
					}					
        }

        public void Run(Problem problemToSolve, RunModes runMode)
        {
            DateTime start = DateTime.Now;
            RunResponse response = problemToSolve.Run(runMode, Logging);            
            var elapsed = DateTime.Now - start;
            
            _ProblemRunTimes.Add(problemToSolve.GetType(), elapsed);           
            Console.WriteLine(String.Format("{0}.{1}.{2}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds));						
						Console.WriteLine(response.Response != null && response.Solution != null && response.Response.Equals(response.Solution));
        }
    }
}
