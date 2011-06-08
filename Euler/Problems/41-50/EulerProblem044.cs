using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem044 : Problem {
    public EulerProblem044()
      : base(null, null, 10000) {
      SolutionResponse = (long)5482660;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {      
      int maxIndex=(int)input; 
      
      for(int i = 1; i < maxIndex; i++) {
        for(int j = 1; j < i-1 ; j++) {
          var pentI = Pentagonal.Generate(i);
          var pentJ = Pentagonal.Generate(j);
          if(i>j && Pentagonal.IsPentagonal(pentI - pentJ))
            if( Pentagonal.IsPentagonal( pentI + pentJ)) {                    
              return pentI-pentJ;
          } 
        }            
      }        
      return 0;
    }
  }
}
