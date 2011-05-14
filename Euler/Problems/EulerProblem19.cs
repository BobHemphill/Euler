using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;

namespace Euler.Problems {

  public class EulerProblem19 : Problem {
    public EulerProblem19()
      : base(null, null, null) {
      SolutionResponse = 171;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {      
      return CountCenturySundaysOnFirstOfMonth(Logging);
    }

    private object CountCenturySundaysOnFirstOfMonth(bool Logging) {
      int sum = 0;
      for(int year=1901;year<=2000; year++){
        for(int month = 1; month <= 12; month++) {
          if( (new DateTime(year, month, 1)).DayOfWeek==DayOfWeek.Sunday)
            sum++;
        }
      }
      return sum;
    }    
  }
}
