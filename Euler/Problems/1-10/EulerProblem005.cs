﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem005 : Problem {
    public EulerProblem005()
      : base(10, (long)2520, 20) {
        SolutionResponse = (long)232792560;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      return LeastCommonMultiple.FromFirstXIntegers((int)input);
    }    
  }
}
