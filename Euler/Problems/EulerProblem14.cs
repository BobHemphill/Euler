using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem14 : Problem {
		public EulerProblem14()
			: base(14, (long)9, 1000000) {
			SolutionResponse = (long)837799;
		}

		private static Func<long, long> EvenFunc = (long i) => { return (i / 2); };
		private static Func<long, long> OddFunc = (long i) => { return (3 * i + 1); };
		private static Func<long, long> ChainFunc = (long i) => { return (i % 2 == 0) ? EvenFunc(i) : OddFunc(i); };

		static readonly Dictionary<long, long> ChainLengthDictionary = new Dictionary<long, long>();

		public override object Run(RunModes runMode, object input, bool Logging) {
			var upperLimit = (int)input;
			long maxSeed = 0;
			long maxChain = 0;
			for (long i = 1; i < upperLimit; i++) {
				long temp = ChainLength(i, Logging);
				if (temp > maxChain) {
					maxChain = temp;
					maxSeed = i;
				}
				if (Logging) {
					Console.Write(String.Format(":{0}", temp));
					Console.WriteLine();
				}
			}
			if (Logging) {
				Console.WriteLine();
				Console.WriteLine();
			}
			return maxSeed;
		}

		private static long ChainLength(long i, bool logging) {
			if (i <= 1) {
				if (logging)
					Console.Write("1");
				return 1;
			}
			if (logging)
				Console.Write(String.Format("{0}=>", i));
			if (ChainLengthDictionary.ContainsKey(i)) {
				if (logging)
					Console.Write(String.Format(" -{0}- ", ChainLengthDictionary[i] - 1));
				return ChainLengthDictionary[i];
			}


			long intermediateChainLength = 1 + ChainLength(ChainFunc(i), logging);
			ChainLengthDictionary.Add(i, intermediateChainLength);
			return intermediateChainLength;
		}
	}
}
