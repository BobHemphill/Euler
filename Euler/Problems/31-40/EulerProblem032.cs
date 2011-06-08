using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem032 : Problem {
		public EulerProblem032()
			: base(null, null, 9) {
			SolutionResponse = 45228;
		}

		public List<int> Pandigitals = new List<int>();
		public override object Run(RunModes runMode, object input, bool Logging) {
			int pandigitalCheckAmount = (int)input;
			for (int i = 1; i < 98; i++) {
				for (int j = 123; j < 9876; j++) {
					var check = new Pandigital.PandigitalWrapper(i, j, i * j, 9);
					if (check.IsPandigital() && !Pandigitals.Contains(check.Product))
						Pandigitals.Add(check.Product);
				}
			}
			return Pandigitals.Sum();		
		}		
	}	
}
