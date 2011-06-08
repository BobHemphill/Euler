using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
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
      var primes = Primes.AllPrimes;

      foreach(long prime in primes){
				var permutations = Permutations.GenerateRotations(prime).Distinct();
        var addPrime = true;
        foreach(var permutation in permutations){
          if( !Primes.IsPrime(permutation)){
            addPrime = false;      
            break;
          }               
        }
        if(addPrime)
          CircularPrimes.Add(prime);
      }
      return CircularPrimes.Count;
    }    
  }
}
