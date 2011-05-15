using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem5 : Problem {
    public EulerProblem5()
      : base(10, 2520, 20) {
      SolutionResponse = 232792560;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      return LeastCommonMultiple.FromFirstXIntegers((int)input);
    }    
  }
}
