using System;
using System.Collections.Generic;
using System.Numerics;

namespace Euler.BobsMath {
	public class Fraction {
		public BigInteger Numerator;
		public BigInteger Denominator;

		public Fraction(BigInteger numerator, BigInteger denominator) {
			Numerator = numerator;
			Denominator = denominator;
		}

		public Fraction(BigInteger numerator, Fraction denominator) {
			Numerator = numerator * denominator.Denominator;
			Denominator = denominator.Numerator;
		}

		public bool MoreDigitsInNumerator
		{
			get { return Numerator.ToString().Length > Denominator.ToString().Length; }
			
		}

		public void Simplify() {
			var gcd = GreatestCommonDenominator.Get(Numerator, Denominator);
			Numerator /= gcd;
			Denominator /= gcd;
		}

		public static Fraction operator +(Fraction lhs, BigInteger rhs) {
			return lhs + new Fraction(rhs, 1);
		}

		public static Fraction operator +(BigInteger lhs, Fraction rhs) {
			return new Fraction(lhs, 1) + rhs;
		}

		public static Fraction operator +(Fraction lhs, Fraction rhs) {
			var lcm = LeastCommonMultiple.Get(lhs.Denominator, rhs.Denominator);
			var f = new Fraction(lhs.Numerator * lcm / lhs.Denominator + rhs.Numerator * lcm / rhs.Denominator, lcm);
			f.Simplify();
			return f;
		}

		public override string ToString() {
			return string.Format("{0}/{1}", Numerator, Denominator);
		}
	}
}
