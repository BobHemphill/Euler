using System;
using Euler.Problems;

namespace Euler {
	class Program {		
		static void Main(string[] args) {
			new EulerProblemEngine { Logging = false }.Run(new EulerProblem053(), RunModes.Solution, BatchModes.None);
      Console.ReadLine();
		}							    																	
	}
}
