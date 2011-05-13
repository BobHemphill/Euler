using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public abstract class Problem
    {
        public readonly object TestInput;
        public readonly object TestResponse;
        public readonly object SolutionInput;
        public object SolutionResponse { get; protected set; }

        public Problem(object testInput, object testResponse, object solutionInput)
        {
            TestInput = testInput;
            TestResponse = testResponse;
            SolutionInput = solutionInput;
        }

        public RunResponse Run(RunModes runMode, bool logging)
        {
            object input = (runMode == RunModes.Solution) ? SolutionInput : TestInput;
            object response = Run(runMode, input, logging);
            object solution = (runMode == RunModes.Solution) ? SolutionResponse : TestResponse;

            Console.WriteLine(String.Format("{0}", response));
            return new RunResponse(input, response, solution);
        }

        public abstract object Run(RunModes runMode, object input, bool Logging);
    }
}
