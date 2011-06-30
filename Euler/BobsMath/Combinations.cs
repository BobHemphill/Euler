using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.BobsMath {
	public static class Combinations {
		public static Dictionary<IndexDictionaryKey, IEnumerable<IEnumerable<int>>> IndexDictionary = new Dictionary<IndexDictionaryKey, IEnumerable<IEnumerable<int>>>();
		public static IEnumerable<IEnumerable<int>> ChooseStringIndeces(int indecesToReplace, int stringStartLength) {
			var key = new IndexDictionaryKey(indecesToReplace, stringStartLength);
			if (IndexDictionary.ContainsKey(key))
				return IndexDictionary[key];

			var indexCombination = new List<string>();
			for (int i = 0; i < stringStartLength; i++) {
				indexCombination.Add(i.ToString());
			}

			var combinations = new List<string>();
			Choose("", indecesToReplace, indexCombination, combinations);

			var value = combinations.Select(i => i.Select(c => Int32.Parse(c.ToString())));
			IndexDictionary.Add(key, value);

			return value;
		}

		public static void Choose(string seed, int chooseAmount, List<string> combinationMembers, List<string> combinations) {
			if (seed.Length == chooseAmount) {
				if (DistinctCombination(combinations, seed))
					combinations.Add(seed);
				return;
			}
			if (combinationMembers.Count() == 1) {
				var tempSeed = seed + combinationMembers[0];
				if ((DistinctCombination(combinations, tempSeed)))
					combinations.Add(tempSeed);
			}
			int index = 0;
			foreach (var combinationMember in combinationMembers) {
				Choose(seed + combinationMember, chooseAmount, combinationMembers.Where((item, i) => i != index).ToList(), combinations);
				index++;
			}
		}

		private static bool DistinctCombination(List<string> combinations, string seed) {
			return !(combinations.Exists(i => seed.All(c => i.Contains(c))));
		}

		public static long Choose(int c, int r, long threshold = 0) {
			long retValue = 1;
			if (c == r) return 1;
			if (r > c) throw new ArgumentException("Cannot choose more elements than in a set");
			var r1 = c - r;
			var rMax = (int)Math.Max(r, r1);
			var rMin = (int)Math.Min(r, r1);
			
			var rNum = new List<int>();
			for (int i = c; i > rMax; i--) {
				rNum.Add(i);
			}

			var rDenom = new List<int>();
			for (int i = 2; i <= rMin; i++) {
				rDenom.Add(i);
			}
			ReduceLists(rNum, rDenom);
			foreach (long i in rNum) {
				var temp = i;
				retValue *= temp;
				retValue = Reduce(rDenom, retValue);
				if (threshold != 0 && retValue > threshold) {
					int count = rDenom.Count;
					if (count == 0) {
						return threshold + 1;
					}

					for (int j = 0; j < count; j++) {
						var rTemp = rDenom[0];
						retValue /= rTemp;
						rDenom.Remove(rTemp);
					}
					if (retValue > threshold) {
						return threshold + 1;
					}
				}
			}
			foreach (var i in rDenom) {
				retValue /= i;
			}
			return retValue;
		}

		public static bool CombinationsAreGreater(int c, int r, long threshold) {
			return Choose(c, r, threshold) > threshold;
		}

		static void ReduceLists(List<int> rNum, List<int> rDenom) {
			Primes.InitPrimes(rNum.Max());
			var count = rDenom.Count;
			for (int i = 0; i < count; i++) {
				var rDenomTemp = rDenom[0];
				var primeFactors = Primes.AllPrimeFactors(rDenomTemp, false).Select(prime => (int)prime).ToList();
				rDenom.Remove(rDenomTemp);
				rDenom.AddRange(primeFactors);
			}
			while(rNum.Count(rNumTemp=> rDenom.Any(rDenomTemp=>rNumTemp%rDenomTemp==0)) > 0) {
				var numTemp = rNum.First(rNumTemp => rDenom.Any(rDenomTemp => rNumTemp%rDenomTemp == 0));
				var denomTemp = rDenom.First(rDenomTemp => numTemp % rDenomTemp == 0);

				var dividend = numTemp/denomTemp;
				rNum.Remove(numTemp);
				rDenom.Remove(denomTemp);
				if( dividend!=1) {
					rNum.Add(dividend);
				}
			}
		}

		static long Reduce(List<int> rList, long multiplicand) {
			Func<int, bool> predicate = (rTemp) => multiplicand % rTemp == 0;

			while (rList.Count(predicate) > 0) {
				var multTemp = rList.First(predicate);
				multiplicand /= multTemp;
				rList.Remove(multTemp);
			}

			return multiplicand;
		}
	}

	public class IndexDictionaryKey {
		public int IndecesToReplace { get; private set; }
		public int StartLength { get; private set; }

		public IndexDictionaryKey(int IndecesToReplace, int StartLength) {
			this.IndecesToReplace = IndecesToReplace;
			this.StartLength = StartLength;
		}

		public override bool Equals(object obj) {
			var that = obj as IndexDictionaryKey;
			if (that == null) return false;

			return this.StartLength == that.StartLength && this.IndecesToReplace == that.IndecesToReplace;
		}

		public override int GetHashCode() {
			return IndecesToReplace ^ StartLength;
		}
	}
}
