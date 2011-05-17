﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
          new EulerProblem18(), new EulerProblem19(), 
          new EulerProblem20(), new EulerProblem21(), new EulerProblem22(), new EulerProblem23(), new EulerProblem24(),
          new EulerProblem67() };

        public bool Logging { get; set; }

        public void Run(RunModes runMode){
          foreach(Problem problem in ProblemsToSolve)
            Run(problem, runMode);
        }

        public void Run(Problem problemToSolve, RunModes runMode)
        {
            DateTime start = DateTime.Now;
            RunResponse response = problemToSolve.Run(runMode, Logging);            
            var elapsed = DateTime.Now - start;
            
            _ProblemRunTimes.Add(problemToSolve.GetType(), elapsed);
            //if(Logging)
                Console.WriteLine(String.Format("{0}.{1}.{2}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds));
            Console.ReadLine();
        }
    }
}
