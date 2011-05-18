using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public static class Primes {
    private static List<long> _Primes=null;
    private const long UPPERLIMIT=1000000;

    public static void InitPrimes(long upperLimit){
      _Primes = new List<long>();
      _Primes.Add(2);
      for(long i=3;i<upperLimit;i+=2){
        _Primes.Add(i);
      }

      int index = 0;
      int primeCount = _Primes.Count;
      long squareRootUpperLimit = (long)Math.Sqrt(upperLimit);
      long prime = _Primes[index];
      while(prime <= squareRootUpperLimit) {
        _Primes.RemoveAll(item => item != prime && item % prime == 0);
        primeCount = _Primes.Count;
        index++;
        if( index>=primeCount) break;
        prime = _Primes[index];             
      }
    }

    public static bool IsPrime(long number){
      if(_Primes==null)
        InitPrimes(UPPERLIMIT);

      return _Primes.Contains(number);
    }

		public static long PrimeAtIndex(int index) {
			if (_Primes == null)
				InitPrimes(UPPERLIMIT);

			return _Primes[index];
		}

		public static long SumAllPrimes() {
			return SumAllPrimes(UPPERLIMIT);
		}

  	public static long SumAllPrimes(long upperLimit) {
			if (_Primes == null)
				InitPrimes(upperLimit);

			return _Primes.Sum();
		}

    public static IEnumerable<long> UniquePrimeFactors(long number, bool initPrimes = true) {
      if(initPrimes) 
        InitPrimes((long)Math.Sqrt(number));
      var factors = Factors.GetFactors(number);
      return factors.Where(item=>IsPrime(item));
    }
    
    public static IEnumerable<long> AllPrimeFactors(long number, bool initPrimes=true){
      if(initPrimes)
        InitPrimes((long)Math.Sqrt(number));
      List<long> factors = UniquePrimeFactors(number, false).ToList();

      foreach(long factor in factors.ToList()) {
        List<long> tempFactors = AllPrimeFactors(number/factor, false).ToList();        
        factors.AddRange(tempFactors.Where(item=>item==factor));
      }
      return factors;
    }    
  }
}
