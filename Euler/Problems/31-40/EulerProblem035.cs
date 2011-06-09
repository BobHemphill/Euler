using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem035 : Problem {
    public EulerProblem035()
      : base((long)100, 13, (long)1000000) {
      SolutionResponse = 55;
    }

    public List<long> CircularPrimes = new List<long>();
    public override object Run(RunModes runMode, object input, bool Logging) {
      Primes.InitPrimes((long)input);
			var primes = Primes.AllPrimes.Where(p => {
				var s = p.ToString();
				return !s.Contains("0") && !s.Contains("2") && !s.Contains("4") &&
							 !s.Contains("6") && !s.Contains("8");
			}).ToList();
			primes.Insert(0, 2);

      foreach(long prime in primes){
				if (CircularPrimes.Contains(prime)) continue;
				var permutations = Permutations.GenerateRotations(prime).Distinct();
        var addPrime = permutations.All(Primes.IsPrime);
      	if(addPrime)
					CircularPrimes.AddRange(permutations);
      }
      return CircularPrimes.Count;
    }    
  }
}
