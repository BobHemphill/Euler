using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.Problems;
using Euler.BobsMath;

namespace Euler {
	class Program {		
		static void Main(string[] args) {
			new EulerProblemEngine { Logging = false }.Run(new EulerProblem010(), RunModes.Solution);
      Console.ReadLine();
		}							    																	
	}
}
