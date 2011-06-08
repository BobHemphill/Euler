using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem020: Problem {
    public EulerProblem020()
      : base(10, (long)27, 100) {
        SolutionResponse = (long)648;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      return SumDigitsOfFactorial((int)input, Logging);
    }

    private long SumDigitsOfFactorial(int input, bool Logging) {
      return Factorial.CalculateBigInt(input).SumOfDigits();
    }    
  }
}
