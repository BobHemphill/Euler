using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem15 : Problem {
		public EulerProblem15()
			: base(null, null, 20) {
				SolutionResponse = 137846528820;
		}

		private static readonly Dictionary<int, Dictionary<int, long>> HopsDictionary = new Dictionary<int, Dictionary<int, long>>();
		public override object Run(RunModes runMode, object input, bool Logging) {
			return FindPaths(0, 0, (int)input);
		}

		private static long FindPaths(int i, int j, int gridSize) {
			if (i == gridSize || j == gridSize) return 1;

			if (HopsDictionary.ContainsKey(i) && HopsDictionary[i].ContainsKey(j)) return HopsDictionary[i][j];

			long rightPathHops = FindPaths(i + 1, j, gridSize);
			AddToHopDictionary(i + 1, j, rightPathHops);
			long downPathHops = FindPaths(i, j + 1, gridSize);
			AddToHopDictionary(i, j + 1, downPathHops);
			AddToHopDictionary(i, j, rightPathHops + downPathHops);
			return rightPathHops + downPathHops;
		}

		private static void AddToHopDictionary(int i, int j, long hops) {
			if (!HopsDictionary.ContainsKey(i)) HopsDictionary.Add(i, new Dictionary<int, long>());

			if (!HopsDictionary[i].ContainsKey(j)) HopsDictionary[i].Add(j, hops);
		}
	}
}
