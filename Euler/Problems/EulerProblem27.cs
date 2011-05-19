using System;
using System.Linq;
using Euler.BobsMath;
using System.Collections.Generic;

namespace Euler.Problems {

	public class EulerProblem27 : Problem {
		public EulerProblem27()
			: base(50, 41, 1000) {
				SolutionResponse = -59231;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var signs = new List<int> { 1, -1 };			
			var max = (int)input;
			Primes.InitPrimes(max);
			var bPrimes = Primes.AllPrimes;
			var maxIndex = 0;
			var maxProduct = new QuadraticCoefficients(0,0);
			Primes.InitPrimes();
			var SquareHash = new Dictionary<int, long>();
			for (int i = 0; i <= max; i++){
				SquareHash.Add(i, (long)Math.Pow(i,2));
			}

			for (int a = -1 * max + 1; a < max; a+=2) {
				foreach (var prime in bPrimes) {
					foreach (var sign in signs)
					{
						var b = prime*sign;
						bool isPrime;
						var tempIndex = 0;
						do {
							var quad = SquareHash[tempIndex] + tempIndex * a + b;
							tempIndex++;
							isPrime = Primes.IsPrime(quad);
						} while (isPrime);

						if (tempIndex > maxIndex) {
							maxIndex = tempIndex;
							maxProduct = new QuadraticCoefficients(a, (int)b);
						}
					}
				}				
			}
			if(Logging)
				Console.WriteLine(String.Format("{0}:{1}", maxProduct.A, maxProduct.B));
			return maxProduct.A* maxProduct.B;
		}
	}

	public class QuadraticCoefficients {
		public int A;
		public int B;

		public QuadraticCoefficients(int a, int b) {
			A = a;
			B = b;
		}

		public long SolveQuadratic(int n) {
			return (long)(Math.Pow(n, 2) + n * A + B);
		}
	}
}
