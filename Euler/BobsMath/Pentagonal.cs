using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public static class Pentagonal {
    public static bool IsPentagonal(long n){
      double upper = ((1 + Math.Sqrt(1 + 24 * n)) / 6);
      return(FloatingPointEquals.IsEqualToLongWithPrecision(upper, (long)upper, 5));
    }
    
    public static long Generate(long n){
      return n*(3* n-1) / 2;
    }        
  }
}
