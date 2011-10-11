using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Euler.BobsMath {
  public static class LeastCommonMultiple {

		public static BigInteger FromIEnumerable(IEnumerable<BigInteger> factors) {
      return factors.Aggregate((BigInteger)1, (lcm, item)=> lcm*item);
    }  
    public static long FromPrimeFactorDictionary(Dictionary<long, int> primeFactors) {
      long lcm = 1;
      foreach (KeyValuePair<long, int> primeFactorKVP in primeFactors) {
        for (int i = 0; i < primeFactorKVP.Value; i++) {
          lcm *= primeFactorKVP.Key;
        }
      }
      return lcm;
    }

		public static BigInteger Get(BigInteger a, BigInteger b) {
			return a*b/GreatestCommonDenominator.Get(a, b);
		}

    public static long FromFirstXIntegers(int upperLimit){
      Primes.InitPrimes(upperLimit + 1);

      Dictionary<long, int> primeFactorCountHash = new Dictionary<long,int>();
      for(int i = 2;i<=upperLimit;i++){
        var primeFactors = Primes.AllPrimeFactors(i, false);
        
        foreach(long primeFactor in primeFactors.Distinct()){
          int primeFactorCount = primeFactors.Count(item=>item==primeFactor);
          if(!primeFactorCountHash.ContainsKey(primeFactor)){
            primeFactorCountHash.Add(primeFactor, primeFactorCount);
          }
          else if(primeFactorCountHash[primeFactor] < primeFactorCount){
            primeFactorCountHash[primeFactor] = primeFactorCount;
          }
        }
      }

      return FromPrimeFactorDictionary(primeFactorCountHash);
    }
  }
}
