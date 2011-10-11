using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Euler.BobsMath {
  public static class Factors {
		public static IEnumerable<BigInteger> GetFactors(BigInteger number) {
      return GetFactors(number, false);
    }

		public static IEnumerable<BigInteger> GetFactors(BigInteger number, bool proper) {
      var upperLimit = number;
			var divisors = new List<BigInteger>();

      for(BigInteger i = 1; i <= upperLimit; i++) {
        if(number % i != 0) continue;
        divisors.Add(i);
        var tempUpperLimit = number / i;
        if(tempUpperLimit > i )
          divisors.Add(number / i);
        upperLimit = tempUpperLimit - 1;
      }
      if(proper)
        divisors.Remove(number);
      return divisors;
    }

		public static BigInteger SumFactors(long number) {
      return SumFactors(number, false);
    }
		public static BigInteger SumFactors(long number, bool proper) {
      return GetFactors(number, proper).Aggregate((BigInteger)0, (current, i)=>i+current);
    }

		public static NumberFactorTypes GetNumberFactorType(long number) {
			var sumFactors = SumFactors(number, true);
			return (sumFactors == number) ? NumberFactorTypes.Perfect :
				(sumFactors<number) ? NumberFactorTypes.Deficient : NumberFactorTypes.Abundant;
		}
  }  

	public enum NumberFactorTypes {
		Deficient =1,
		Perfect =2,
		Abundant=3		
	}
}
