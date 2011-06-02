using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public static class FloatingPointEquals {
    public static bool IsEqualToLongWithPrecision(double x, long y, int precision){
      double e = 1/Math.Pow(10, precision);

      return( (x-y > -e) && (x-y)<e );
    }
  }
}
