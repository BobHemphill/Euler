using System;	

namespace Euler.BobsMath {
	public static class Square {
		public static bool IsSquare(long n) {
			double upper = (Math.Sqrt(n));
			return (FloatingPointEquals.IsEqualToLongWithPrecision(upper, (long)upper, 5));
		}

		public static long Generate(long n) {
			return n * n;
		}
	}
}
