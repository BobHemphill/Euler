using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.BobsMath;

namespace Euler.Utilities {
  public static class ClearCache {
    public static void Clear(){ 
      Primes.Clear();
    }
  }
}
