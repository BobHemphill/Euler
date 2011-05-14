using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem20: Problem {
    public EulerProblem20()
      : base(10, 27, 100) {
      SolutionResponse = 648;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      return SumDigitsOfFactorial((int)input, Logging);
    }

    private long SumDigitsOfFactorial(int input, bool Logging) {
      return Factorial.CalculateBigInt(input).SumOfDigits();
    }    
  }
}
