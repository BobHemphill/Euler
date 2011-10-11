using System;
using System.Linq;
using System.Collections.Generic;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem060 : Problem {
		public EulerProblem060()
			: base(null, null, null) {
			SolutionResponse = (long)26033;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			Primes.InitPrimes(10000);

			var primeList = Primes.AllPrimes.Where(p => p != 2 && p != 5).ToList();

			var twoTuples = GetTwoTuplesList(primeList).ToList();
			var threeTuples = GetThreeTuplesList(twoTuples, primeList).ToList();
			var fourTuples = GetFourTuplesList(threeTuples, primeList).ToList();
			var fiveTuples = GetFiveTuplesList(fourTuples, primeList);

			if (fiveTuples.Count > 0) {
				if (Logging) {
					Console.WriteLine(fiveTuples.First());
				}
				return fiveTuples.First().Sum;
			}
			return 0;
		}

		public List<PrimeTuple> GetTwoTuplesList(List<long> primeList) {
			var primeTuples = new List<PrimeTuple>();
			for (int i = 0; i < primeList.Count; i++) {
				for (int j = 0; j < primeList.Count; j++) {
					var primeTuple = new PrimeTuple { First = primeList[i], Second = primeList[j] };
					if (!primeTuple.IsTwoPrimeTuple()) continue;
					if (primeTuples.Count(pt => pt.First == primeTuple.Second && pt.Second == primeTuple.First) < 1)
						primeTuples.Add(primeTuple);
				}
			}
			return primeTuples.OrderBy(pt => pt.Sum).ToList();
		}

		public List<PrimeTuple> GetThreeTuplesList(List<PrimeTuple> twoTuples, List<long> primeList) {
			var primeTuples = new List<PrimeTuple>();
			foreach (var twoTuple in twoTuples) {
				for (int i = 0; i < primeList.Count; i++) {
					if (primeList[i] <= twoTuple.Max) continue;
					var primeTuple = new PrimeTuple { First = twoTuple.First, Second = twoTuple.Second, Third = primeList[i] };
					if (!primeTuple.IsThreePrimeTuple()) continue;
					primeTuples.Add(primeTuple);
				}
			}
			return primeTuples.OrderBy(pt => pt.Sum).ToList();
		}

		public List<PrimeTuple> GetFourTuplesList(List<PrimeTuple> threeTuples, List<long> primeList) {
			var primeTuples = new List<PrimeTuple>();
			foreach (var threeTuple in threeTuples) {
				for (int i = 0; i < primeList.Count; i++) {
					if (primeList[i] <= threeTuple.Max) continue;
					var primeTuple = new PrimeTuple { First = threeTuple.First, Second = threeTuple.Second, Third = threeTuple.Third, Fourth = primeList[i] };
					if (!primeTuple.IsFourPrimeTuple()) continue;
					primeTuples.Add(primeTuple);
				}
			}
			return primeTuples.OrderBy(pt => pt.Sum).ToList();
		}

		public List<PrimeTuple> GetFiveTuplesList(List<PrimeTuple> fourTuples, List<long> primeList) {
			var primeTuples = new List<PrimeTuple>();
			foreach (var fourTuple in fourTuples) {
				for (int i = 0; i < primeList.Count; i++) {
					if (primeList[i] <= fourTuple.Max) continue;
					var primeTuple = new PrimeTuple { First = fourTuple.First, Second = fourTuple.Second, Third = fourTuple.Third, Fourth = fourTuple.Fourth, Fifth = primeList[i] };
					if (!primeTuple.IsFivePrimeTuple()) continue;
					primeTuples.Add(primeTuple);
				}
			}
			return primeTuples.OrderBy(pt => pt.Sum).ToList();
		}
	}

	public class PrimeTuple {
		public long First { get; set; }
		public long Second { get; set; }
		public long Third { get; set; }
		public long Fourth { get; set; }
		public long Fifth { get; set; }

		public long Sum { get { return First + Second + Third + Fourth + Fifth; } }
		public long Max { get { return Math.Max(Fifth, Math.Max(Fourth, Math.Max(Third, Math.Max(First, Second)))); } }

		public override string ToString() {
			return string.Format("{0}.{1}.{2}.{3}.{4}->{5}", First, Second, Third, Fourth, Fifth, Sum);
		}

		public bool IsTwoPrimeTuple() {
			return Primes.IsPrimeInLine(Int64.Parse(First.ToString() + Second.ToString())) &&
						 Primes.IsPrimeInLine(Int64.Parse(Second.ToString() + First.ToString()));
		}

		public bool IsThreePrimeTuple() {
			return /*IsTwoPrimeTuple() &&*/
				Primes.IsPrimeInLine(Int64.Parse(First.ToString() + Third.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Second.ToString() + Third.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Third.ToString() + First.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Third.ToString() + Second.ToString()));
		}

		public bool IsFourPrimeTuple() {
			return /*IsThreePrimeTuple() &&*/
				Primes.IsPrimeInLine(Int64.Parse(First.ToString() + Fourth.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Second.ToString() + Fourth.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Third.ToString() + Fourth.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Fourth.ToString() + First.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Fourth.ToString() + Second.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Fourth.ToString() + Third.ToString()));
		}

		public bool IsFivePrimeTuple() {
			return /*IsFourPrimeTuple() &&*/
				Primes.IsPrimeInLine(Int64.Parse(First.ToString() + Fifth.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Second.ToString() + Fifth.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Third.ToString() + Fifth.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Fourth.ToString() + Fifth.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Fifth.ToString() + First.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Fifth.ToString() + Second.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Fifth.ToString() + Third.ToString())) &&
				Primes.IsPrimeInLine(Int64.Parse(Fifth.ToString() + Fourth.ToString()));
		}
	}
}
