using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem41 : Problem {
    public EulerProblem41()
      : base(null, null, null) {
        SolutionResponse = null;
    }

    public List<int> CValues = new List<int>();
    public override object Run(RunModes runMode, object input, bool Logging) {
     Primes.InitPrimes((long)Math.Pow(10, 9));

     foreach(long prime in Primes.AllPrimes.OrderByDescending(item=>item))
      if( Pandigital.IsPandigital(prime.ToString(), prime.ToString().Length))
        return prime;
     return 1;
    }    
  }
}
