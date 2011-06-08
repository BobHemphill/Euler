using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem045 : Problem {
    public EulerProblem045()
      : base(283, null, 285) {
        SolutionResponse = (long)1533776805;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      int minIndex = (int)input + 1;      
      while(true){
        long tri =  Triangle.Generate(minIndex);
        if( Pentagonal.IsPentagonal(tri) && Hexagonal.IsHexagonal(tri)) 
          return tri;
        minIndex++;
      }      
    }
  }
}
