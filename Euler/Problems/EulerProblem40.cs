using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem40 : Problem {
    public EulerProblem40()
      : base(null, null, 1000000) {
      SolutionResponse = 210;
    }

    public List<int> CValues = new List<int>();
    public override object Run(RunModes runMode, object input, bool Logging) {      
      return FindIndex(1) *
      FindIndex(10) *
      FindIndex(100) *
      FindIndex(1000) *
      FindIndex(10000) *
      FindIndex(100000) *
      FindIndex(1000000);
    }

    public int FindIndex(int index){
      int upperLimit = 9+1;
      
      if(index < upperLimit)
        return index;

      int modFactor = 1;
      while(true){
        modFactor++;
        int modOffset = upperLimit%modFactor;
        int tensOffset = (int)Math.Pow(10, modFactor-1);
        int offset = (index - upperLimit) / modFactor + tensOffset;
        int offsetIndex = (index-modOffset) % modFactor;
        upperLimit += 9 * tensOffset * modFactor;
        if(index < upperLimit)
          return Int32.Parse(offset.ToString()[offsetIndex].ToString());
      }      
    }
  }
}
