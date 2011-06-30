﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
	public static class Primes {
		private static List<long> _Primes = null;
		public static List<long> AllPrimes { get { if (_Primes == null) InitPrimes(); return _Primes; } }
		private const long UPPERLIMIT = 1000000;

		public static void Clear() {
			if (_Primes != null) _Primes.Clear();
			UniquePrimeFactorsCache.Clear();
		}

		public static void InitPrimes() {
			InitPrimes(UPPERLIMIT);
		}

		public static void InitPrimes(long upperLimit) {
			if (_Primes != null) {
				_Primes.Clear();
			}
			else {
				_Primes = new List<long>();
			}

			_Primes.Add(2);
			for (long i = 3; i < upperLimit; i += 2) {
				_Primes.Add(i);
			}

			PairPrimes(_Primes, upperLimit);
		}

		public static void TrimPrimes(long lowerValue, long UpperValue) {
			_Primes.RemoveAll(p => p < lowerValue || p > UpperValue);
		}

		static void PairPrimes(List<long> primes, long upperLimit) {
			int index = 0;
			int primeCount = _Primes.Count;
			long squareRootUpperLimit = (long)Math.Sqrt(upperLimit);
			long prime = _Primes[index];
			while (prime <= squareRootUpperLimit) {
				_Primes.RemoveAll(item => item != prime && item % prime == 0);
				primeCount = _Primes.Count;
				index++;
				if (index >= primeCount) break;
				prime = _Primes[index];
			}
		}

		public static bool IsPrime(long number) {
			if (_Primes == null)
				InitPrimes(UPPERLIMIT);

			return _Primes.Contains(number);
		}


		public static long PrimeAtIndex(int index) {
			if (_Primes == null)
				InitPrimes(UPPERLIMIT);

			return _Primes[index];
		}

		public static long SumAllPrimes() {
			return SumAllPrimes(UPPERLIMIT);
		}

		public static long SumAllPrimes(long upperLimit) {
			if (_Primes == null)
				InitPrimes(upperLimit);

			return _Primes.Sum();
		}

		private static readonly Dictionary<long, List<long>> UniquePrimeFactorsCache = new Dictionary<long, List<long>>();
		public static IEnumerable<long> UniquePrimeFactors(long number, bool initPrimes = true) {
			if (initPrimes)
				InitPrimes(number);

			var upperLimit = number;
			var divisors = new List<long>();
			if (IsPrime(number)) { divisors.Add(number); }
			else {
				foreach (var prime in AllPrimes) {
					if (prime > upperLimit) break;
					if (number % prime != 0) continue;
					divisors.Add(prime);
					var tempUpperLimit = number / prime;
					if (UniquePrimeFactorsCache.ContainsKey(tempUpperLimit)) {
						divisors.AddRange(UniquePrimeFactorsCache[tempUpperLimit]);
						break;
					}
					if (tempUpperLimit > prime && IsPrime(tempUpperLimit))
						divisors.Add(number / prime);
					upperLimit = tempUpperLimit - 1;
				}
			}
			divisors = divisors.Distinct().ToList();
			if (!UniquePrimeFactorsCache.ContainsKey(number)) UniquePrimeFactorsCache.Add(number, divisors);
			return divisors;
		}

		public static IEnumerable<long> AllPrimeFactors(long number, bool initPrimes = true) {
			if (initPrimes)
				InitPrimes(number);
			List<long> factors = UniquePrimeFactors(number, false).ToList();

			foreach (long factor in factors.ToList()) {
				List<long> tempFactors = AllPrimeFactors(number / factor, false).ToList();
				factors.AddRange(tempFactors.Where(item => item == factor));
			}
			return factors;
		}

		public static bool IsTruncatable(long number) {
			var temp = number.ToString();
			if (temp.Contains("0") || temp.Contains("4") || temp.Contains("6") || temp.Contains("8") || (temp.Contains("2") && !(temp.Count(i => i == '2') == 1 && temp[0] == '2'))) return false;
			var upperLimit = temp.Length;
			for (int i = 1; i < upperLimit; i++) {
				if (!IsPrime(Int64.Parse(temp.Substring(i)))) return false;
				if (!IsPrime(Int64.Parse(temp.Substring(0, upperLimit - i)))) return false;
			}
			return true;
		}
	}
}
