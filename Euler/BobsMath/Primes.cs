using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public static class Primes {
    private static List<long> _Primes=null;
		public static List<long> AllPrimes { get { if (_Primes == null) InitPrimes(); return _Primes; } }
    private const long UPPERLIMIT=1000000;

    public static void Clear(){ if(_Primes!=null) _Primes.Clear(); }

		public static void InitPrimes()
		{
			InitPrimes(UPPERLIMIT);
		}

  	public static void InitPrimes(long upperLimit){
      
      _Primes = new List<long>();
      _Primes.Add(2);
      //long pairLimit = UPPERLIMIT * 10;      
      for(long i=3;i<upperLimit;i+=2){
        //if(i >= pairLimit) {
        //  PairPrimes(_Primes, pairLimit);
        //  pairLimit*=5;
        //}
        _Primes.Add(i);
      }

      PairPrimes(_Primes, upperLimit);
    }

    static void PairPrimes(List<long> primes, long upperLimit){
      int index = 0;
      int primeCount = _Primes.Count;
      long squareRootUpperLimit = (long)Math.Sqrt(upperLimit);
      long prime = _Primes[index];
      while(prime <= squareRootUpperLimit) {
        _Primes.RemoveAll(item => item != prime && item % prime == 0);
        primeCount = _Primes.Count;
        index++;
        if(index >= primeCount) break;
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
        InitPrimes(number);

			var upperLimit = number;
			var divisors = new List<long>();
			if (IsPrime(number)) { divisors.Add(number); return divisors; }

    	foreach (var prime in AllPrimes) {
				if (prime > upperLimit) break;
				if (number % prime != 0) continue;
				divisors.Add(prime);
				var tempUpperLimit = number / prime;
				if (tempUpperLimit > prime && IsPrime(tempUpperLimit))
					divisors.Add(number / prime);
				upperLimit = tempUpperLimit - 1;
    	}
			
			return divisors;
    }
    
    public static IEnumerable<long> AllPrimeFactors(long number, bool initPrimes=true){
      if(initPrimes)
				InitPrimes(number);
      List<long> factors = UniquePrimeFactors(number, false).ToList();

      foreach(long factor in factors.ToList()) {
        List<long> tempFactors = AllPrimeFactors(number/factor, false).ToList();        
        factors.AddRange(tempFactors.Where(item=>item==factor));
      }
      return factors;
    }    

		public static bool IsTruncatable(long number) {
			var temp = number.ToString();
			var upperLimit = temp.Length;
			for (int i = 1; i < upperLimit; i++) {
				if (!IsPrime(Int64.Parse(temp.Substring(i)))) return false;
				if (!IsPrime(Int64.Parse(temp.Substring(0, upperLimit-i)))) return false;
			}
			return true;
		}
  }
}
