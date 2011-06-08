﻿using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem006 : Problem {
		public EulerProblem006()
      : base(10, (long)2640, 100) {
				SolutionResponse = (long)25164150;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			long sigmaX = 1;
			long sigma_XSquared = 1;
			var limit = (int)input;
			for (int i = 2; i <= limit; i++) {
				sigma_XSquared += (long)Math.Pow(i, 2);
				sigmaX += i;
			}
			return ((long)Math.Pow(sigmaX, 2)) - sigma_XSquared;
		}
	}
}
