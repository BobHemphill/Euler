using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem021: Problem {
    private Dictionary<int, int> _LongToSumOfProperFactorsHash = new Dictionary<int, int>();
    private List<int> _AmicableNumbers = new List<int>();
    public EulerProblem021()
      : base(null, null, 10000) {
      SolutionResponse = 31626;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      return SumOfAmicableParis((int)input, Logging);
    }

    private int SumOfAmicableParis(int input, bool Logging) {
      Primes.InitPrimes(input);
      for(int i = 2; i < input; i++) {
        if(Primes.IsPrime(i)) continue;

        int sumFactorsI;
        int sumFactorsAmicableI;
        if(_LongToSumOfProperFactorsHash.ContainsKey(i))
          sumFactorsI = _LongToSumOfProperFactorsHash[i];
        else{
          sumFactorsI = (int)Factors.SumFactors(i, true);
          _LongToSumOfProperFactorsHash.Add(i, sumFactorsI);
        }

        if(_LongToSumOfProperFactorsHash.ContainsKey(sumFactorsI))
          sumFactorsAmicableI = _LongToSumOfProperFactorsHash[sumFactorsI];
        else{
          sumFactorsAmicableI = (int)Factors.SumFactors(sumFactorsI, true);
          _LongToSumOfProperFactorsHash.Add(sumFactorsI, sumFactorsAmicableI);
        }

        if( i==sumFactorsAmicableI && i!=sumFactorsI ){
          if( !_AmicableNumbers.Contains(i) ){
            _AmicableNumbers.Add(i);
            _AmicableNumbers.Add(sumFactorsI);
          }
        }        
      }
      return _AmicableNumbers.Sum();
    }
  }
}
