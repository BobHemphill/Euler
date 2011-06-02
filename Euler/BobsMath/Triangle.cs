using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public static class Triangle {
    public static bool IsTriangle(long n) {
      double upper = ((-1 + Math.Sqrt(1 + 8 * n)) / 2);
      return(FloatingPointEquals.IsEqualToLongWithPrecision(upper, (long)upper, 5));
    }

    public static long Generate(long n) {
      return n * (n + 1) / 2;
    }
  }
}
