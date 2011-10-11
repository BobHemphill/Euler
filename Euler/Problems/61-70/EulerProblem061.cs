using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem061 : Problem {
		public EulerProblem061()
			: base(null, null, null) {
			SolutionResponse = 28684;
		}

		static readonly Dictionary<long, long> triangles = new Dictionary<long, long>();
		static readonly Dictionary<long, long> squares = new Dictionary<long, long>();
		static readonly Dictionary<long, long> pentas = new Dictionary<long, long>();
		static readonly Dictionary<long, long> hexas = new Dictionary<long, long>();
		static readonly Dictionary<long, long> heptas = new Dictionary<long, long>();
		static readonly Dictionary<long, long> octos = new Dictionary<long, long>();

		readonly List<FigurateDelegateWrapper> figurates = new List<FigurateDelegateWrapper>{
		                                            		new FigurateDelegateWrapper { hash = triangles, Generate = Triangle.Generate},
																										new FigurateDelegateWrapper { hash = squares, Generate = Square.Generate},
																										new FigurateDelegateWrapper { hash = pentas, Generate = Pentagonal.Generate},
																										new FigurateDelegateWrapper { hash = hexas, Generate = Hexagonal.Generate},
																										new FigurateDelegateWrapper { hash = heptas, Generate = Heptangonal.Generate},
																										new FigurateDelegateWrapper { hash = octos, Generate = Octangonal.Generate},
		                                            	};

		public long FindFigurateSum(List<Dictionary<long, long>> localFigurates, List<long> figurateValues, long min, long max) {
			if (localFigurates.Count == 1) {
				foreach (var KVP in localFigurates[0]) {
					if (KVP.Value < min || KVP.Value >= max) continue;
					if (figurateValues.Contains(KVP.Value)) continue;

					long next = Int64.Parse(KVP.Value.ToString().Substring(2, 2));
					long first = Int64.Parse(figurateValues[0].ToString().Substring(0, 2));
					if(next!=first) continue;
					return KVP.Value + figurateValues.Sum();
				}
				return 0;
			}
			else {
				foreach (var localFigurate in localFigurates.ToList()) {
					localFigurates.Remove(localFigurate);
					var removed = localFigurates.ToList();

					foreach (var KVP in localFigurate.Where(kvp => kvp.Value >= min && kvp.Value < max)) {
						if (figurateValues.Contains(KVP.Value)) continue;

						long next = Int64.Parse(KVP.Value.ToString().Substring(2, 2));
						long nextSeedMin = next * 100;
						long nextSeedMax = (next + 1) * 100;

						figurateValues.Add(KVP.Value);
						var ret = FindFigurateSum(removed, figurateValues, nextSeedMin, nextSeedMax);
						if (ret > 0) {
							return ret;
						}
						figurateValues.Remove(KVP.Value);
					}
					localFigurates.Add(localFigurate);
				}
				return 0;
			}
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			GenerateDictionaries();

			foreach (var octoKVP in octos) {
				long next = Int64.Parse(octoKVP.Value.ToString().Substring(2, 2));
				long seedMin = next * 100;
				long seedMax = (next + 1) * 100;

				var localFigurates = new List<Dictionary<long, long>> { heptas, hexas, pentas, squares, triangles };
				var figurateValues = new List<long>{octoKVP.Value};
				var ret = FindFigurateSum(localFigurates, figurateValues, seedMin, seedMax);
				if (ret > 0) return ret;
				//foreach (var heptaKVP in heptas.Where(kvp => kvp.Value >= heptaSeedMin && kvp.Value < heptaSeedMax)) {
				//  if (heptaKVP.Value < heptaSeedMin || heptaKVP.Value >= heptaSeedMax) continue;
				//  if (heptaKVP.Value == octoKVP.Value) continue;

				//  long hexa = Int64.Parse(heptaKVP.Value.ToString().Substring(2, 2));
				//  long hexaSeedMin = hexa * 100;
				//  long hexaSeedMax = (hexa + 1) * 100;

				//  foreach (var hexaKVP in hexas) {
				//    if (hexaKVP.Value < hexaSeedMin || heptaKVP.Value >= hexaSeedMax) continue;
				//    if (hexaKVP.Value == octoKVP.Value || hexaKVP.Value == heptaKVP.Value) continue;

				//    long penta = Int64.Parse(hexaKVP.Value.ToString().Substring(2, 2));
				//    long pentaSeedMin = penta * 100;
				//    long pentaSeedMax = (penta + 1) * 100;

				//    foreach (var pentaKVP in pentas) {
				//      if (pentaKVP.Value < pentaSeedMin || pentaKVP.Value >= pentaSeedMax) continue;
				//      if (pentaKVP.Value == octoKVP.Value || pentaKVP.Value == heptaKVP.Value || pentaKVP.Value == hexaKVP.Value) continue;

				//      long square = Int64.Parse(pentaKVP.Value.ToString().Substring(2, 2));
				//      long squareSeedMin = square * 100;
				//      long squareSeedMax = (square + 1) * 100;

				//      foreach (var squareKVP in squares) {
				//        if (squareKVP.Value < squareSeedMin || squareKVP.Value >= squareSeedMax) continue;
				//        if (squareKVP.Value == octoKVP.Value || squareKVP.Value == heptaKVP.Value || squareKVP.Value == hexaKVP.Value || squareKVP.Value == pentaKVP.Value) continue;

				//        long triangle = Int64.Parse(squareKVP.Value.ToString().Substring(2, 2));
				//        long triangleSeedMin = triangle * 100;
				//        long triangleSeedMax = (triangle + 1) * 100;

				//        foreach (var triangleKVP in triangles) {
				//          if (triangleKVP.Value < triangleSeedMin || triangleKVP.Value >= triangleSeedMax) continue;
				//          if (triangleKVP.Value == octoKVP.Value || triangleKVP.Value == heptaKVP.Value || triangleKVP.Value == hexaKVP.Value || triangleKVP.Value == pentaKVP.Value || triangleKVP.Value == squareKVP.Value) continue;

				//          return triangleKVP.Value + squareKVP.Value + pentaKVP.Value + hexaKVP.Value + heptaKVP.Value + octoKVP.Value;
				//        }
				//      }
				//    }
				//  }
				//}
			}
			return 0;
		}

		IEnumerable<KeyValuePair<long, long>> GetFilteredKeyValuePairs(Dictionary<long, long> dict, long min, long max) {
			return dict.Where(kvp => kvp.Value >= min && kvp.Value < max);
		}

		void GenerateDictionaries() {
			foreach (var figurate in figurates) {
				long i = 1;
				long seq;
				do {
					seq = figurate.Generate(i);
					if (seq >= 1000 && seq < 10000) {
						figurate.hash.Add(i, seq);
					}
					i++;
				} while (seq < 10000);
			}
		}
	}

	public delegate long Figurate(long n);
	public class FigurateDelegateWrapper {
		public Dictionary<long, long> hash { get; set; }
		public Figurate Generate { get; set; }
	}

	public class CyclicSet : List<long> {
		public bool IsCyclic;
	}
}
