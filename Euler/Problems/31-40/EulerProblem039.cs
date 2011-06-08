using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem039 : Problem {
    public EulerProblem039()
      : base(null, null, 1000) {
      SolutionResponse = 840;
    }

    public List<int> CValues = new List<int>();
    public override object Run(RunModes runMode, object input, bool Logging) {
      int upperLimit = (int)input;
      int maxX = 0;
      int maxSolutions = 0;
      bool temp;
      for(int i=1;i<=upperLimit;i++){
        var tempSolutions = 0;
        CValues.Clear();
        if( i==120) temp=true;
        for(int b =1; b<=upperLimit;b++){
          for(int c =1; c<=upperLimit;c++){
            var leftSide = -1 * b*b + b*i + c*i -b*c;
            var rightSide = i*i/2;

            if( leftSide==rightSide){
              int a = i-b-c;
              if( a>0 && !CValues.Contains(c) && a*a+b*b==c*c){
                tempSolutions++;
                CValues.Add(c);
              }
            }
          }
        }
        if( tempSolutions>maxSolutions){
          maxX = i;
          maxSolutions = tempSolutions;
        }
      }
      return maxX;
    }
  }
}
