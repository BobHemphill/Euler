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
  }
}
