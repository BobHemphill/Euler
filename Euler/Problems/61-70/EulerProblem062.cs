using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem062 : Problem {
		public EulerProblem062()
			: base(null, null, null) {
			SolutionResponse = null;
		}

		public static Dictionary<int, List<long>> CubesDictionary = new Dictionary<int, List<long>>();

		public override object Run(RunModes runMode, object input, bool Logging) {
			var currentSeed = 345;
			while (true) {
				var nextSeed = SeedCubes(currentSeed);

				var foundPermsMaster = CubesDictionary[currentSeed].ToList();
				foreach (var cube in CubesDictionary[currentSeed]) {
					var count = 0;
					var foundPerms = new List<long>();
					foreach (var cube2 in foundPermsMaster) {
						if (Permutations.IsPermutations(cube, cube2) && !foundPerms.Contains(cube)) {
							count++;
							foundPerms.Add(cube);
						}
						if (count == 5) return cube;
					}
					foundPermsMaster.RemoveAll(foundPerms.Contains);
				}
				currentSeed = nextSeed;
			}
		}

		int SeedCubes(int seed) {
			var cube = (long)Math.Pow(seed, 3);
			var length = cube.ToString().Length;
			int tempLength;
			int tempSeed = seed;
			CubesDictionary.Add(tempSeed, new List<long>());
			do {
				var tempCube = (long)Math.Pow(seed, 3);
				tempLength = tempCube.ToString().Length;
				if (tempLength == length)
					CubesDictionary[tempSeed].Add(tempCube);
				seed++;
			} while (tempLength == length);
			return seed;
		}
	}
}
