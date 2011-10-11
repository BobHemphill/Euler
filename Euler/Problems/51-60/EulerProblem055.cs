using System;
using System.Collections.Generic;
using System.Numerics;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem055 : Problem {
		public EulerProblem055()
			: base(null, null, null) {
			SolutionResponse = 249;
		}

		readonly Dictionary<BigInteger, int> PathCache = new Dictionary<BigInteger, int>();
		public override object Run(RunModes runMode, object input, bool Logging) {
			var count = 0;

			for (var i = 1; i < 10000; i++) {
				var iteration = 1;
				if (IsLychrel(i, ref iteration)) count++;
				if (!PathCache.ContainsKey(i)) {
					PathCache.Add(i, iteration);
				}
			}

			return count;
		}

		bool IsLychrel(BigInteger i, ref int iteration) {
			var temp = i.ToString();
			var reverseLong = GetReverseLong(temp);
			var l = i + reverseLong;
			var reverseL = l.ToString();

			if (iteration > 50) {
				if (!PathCache.ContainsKey(i))
					PathCache.Add(i, iteration);
				return true;
			}

			if (Palindrome.IsPalindrome(reverseL)) {
				if (!PathCache.ContainsKey(i))
					PathCache.Add(i, iteration);
				return false;
			}

			if (PathCache.ContainsKey(i)) {
				iteration += PathCache[i];
				return iteration >= 50;
			}
			
			iteration++;			
			return IsLychrel(l, ref iteration);
		}

		static BigInteger GetReverseLong(string temp)
		{
			var charArray = temp.ToCharArray();
			Array.Reverse(charArray);
			var reverseString = new string(charArray);
			var reverseLong = BigInteger.Parse(reverseString);
			return reverseLong;
		}
	}
}
