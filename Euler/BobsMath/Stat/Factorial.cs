using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public static class Factorial {
    public static long Calculate(int i){
      long fact=1;
      for(int j=i;j>1;j--)
        fact*=j;
      return fact;
    }

    public static BigInt CalculateBigInt(int i){
      BigInt result = new BigInt(i.ToString());
      for(int j = i-1; j > 1; j--)
        result = result.Product(j);
      return result;
    }
  }
}
