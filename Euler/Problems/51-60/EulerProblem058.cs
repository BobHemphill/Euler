using System;
using System.Collections.Generic;
using Euler.BobsMath;

namespace Euler.Problems {
	public class EulerProblem058 : Problem {
		public EulerProblem058()
			: base((double)63, 7, (double)10) {
			SolutionResponse = 26241;
		}
		
		public override object Run(RunModes runMode, object input, bool Logging) {
			double percentage = (double)input;

			long primeCount = 0;
			long diagonalCount = 1;
			int layer = 0;
			
			do {
				layer++;
				AddLayer(ref primeCount, ref diagonalCount, layer, Logging);
			} while ((double) primeCount/(double) diagonalCount*100.0 >= percentage);
			return layer*2 + 1;
		}

		static void AddLayer(ref long primeCount, ref long diagonalCount, int layer, bool logging) {
			var last = GetLastLayerCorner(layer - 1);
			
			if (logging)
				Console.Write(String.Format("Layer{0} ---> ", layer));
			for (int i = 0; i <= 3; i++) {
				CheckCornerAddIncrement(ref last, ref primeCount, layer, logging);
			}
			diagonalCount += 4;
			if (logging) {
				Console.Write(String.Format("---> {0}", (double)primeCount / (double)diagonalCount * 100.0));
				Console.WriteLine();
			}
		}

		static void CheckCornerAddIncrement(ref long last, ref long primeCount, int layer, bool logging) {
			last += layer * 2;
			if (logging)
				Console.Write(String.Format("{0}, ", last));
			if (Primes.IsPrimeInLine(last)) primeCount++;
		}

		static Dictionary<int, long> LastCornerCache = new Dictionary<int, long>();
		static long GetLastLayerCorner(int layer) {
			if (layer == 0) return 1;
			if (LastCornerCache.ContainsKey(layer)) return LastCornerCache[layer];
			var lastLayerCorner = GetLastLayerCorner(layer - 1) + layer*2*4;
			if (!LastCornerCache.ContainsKey(layer))
				LastCornerCache.Clear();
				LastCornerCache.Add(layer, lastLayerCorner);
			return lastLayerCorner;
		}
	}
}
