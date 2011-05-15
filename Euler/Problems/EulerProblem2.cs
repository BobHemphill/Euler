using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem2 : Problem {
    public EulerProblem2()
      : base(null, null, 4000000) {
        SolutionResponse = 4613732;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      return Fibonacci.Sequence((int)input).Where(item => item % 2 == 0).Sum();
    }
  }
}
