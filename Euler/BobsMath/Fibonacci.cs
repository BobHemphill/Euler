using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public class Fibonacci {
    public static IEnumerable<int> Sequence(int upperLimit){
      List<int> sequence = new List<int>();
      int fibCur = 1;
      int fibPrev = 1;

      sequence.Add(fibPrev);
      while(fibCur < upperLimit) {
        sequence.Add(fibCur);

        int temp = fibCur;
        fibCur += fibPrev;
        fibPrev = temp;        
      }
      return sequence;
    }

		public static IEnumerable<BigInt> Sequence(BigInt upperLimit) {
			List<BigInt> sequence = new List<BigInt>();
			BigInt fibCur = new BigInt("1");
			BigInt fibPrev = new BigInt("1");

			sequence.Add(fibPrev);
			while (fibCur.CompareTo(upperLimit) < 0) {
				sequence.Add(fibCur);

				BigInt temp = new BigInt(fibCur.Value);
				fibCur = new BigInt("").SumBigIntNumbers(new List<BigInt> { fibCur, fibPrev });
				fibPrev = new BigInt(temp.Value);
			}
			return sequence;
		}
  }
}
