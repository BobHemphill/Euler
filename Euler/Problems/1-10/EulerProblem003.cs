using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem003 : Problem {
    public EulerProblem003()
      : base(null, null, (long)600851475143) {
        SolutionResponse = (long)6857;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      return Factors.GetFactors((long)input).Where(fac=>Primes.IsPrime(fac)).Max();
    }
  }  
}
