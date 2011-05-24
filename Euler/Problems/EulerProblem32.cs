using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Problems {

	public class EulerProblem32 : Problem {
		public EulerProblem32()
			: base(null, null, 9) {
			SolutionResponse = 45228;
		}

		public List<int> Pandigitals = new List<int>();
		public override object Run(RunModes runMode, object input, bool Logging) {
			int pandigitalCheckAmount = (int)input;
			for (int i = 1; i < 98; i++) {
				for (int j = 123; j < 9876; j++) {
					var check = new PandigitalWrapper(i, j, i * j, 9);
					if (check.IsPandigital() && !Pandigitals.Contains(check.Product))
						Pandigitals.Add(check.Product);
				}
			}
			return Pandigitals.Sum();		
		}		
	}

	public class PandigitalWrapper {
		public int Multiplier;
		public int Multiplicand;
		public int Product;
		public int PandigitalCount;

		public PandigitalWrapper(int multiplier, int multiplicand, int product, int pandigitalCount) {
			Multiplier = multiplier;
			Multiplicand = multiplicand;
			Product = product;
			PandigitalCount = pandigitalCount;
		}

		public bool IsPandigital() {
			var temp = Multiplier.ToString() + Multiplicand.ToString() + Product.ToString();
			if (temp.Length != PandigitalCount) return false;
			for (int i = 1; i <= PandigitalCount; i++) {
				if (!temp.Contains(i.ToString()[0])) return false;
			}
			return true;
		}
	}
}
