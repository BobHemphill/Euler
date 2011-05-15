using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public class BigInt {
    public readonly string Value;
    public BigInt(string value) {
      Value = value;
    }
    public BigInt Product(int multiplier){
      List<BigInt> products = new List<BigInt>();
      for(int i=0;i<multiplier;i++){
        products.Add(new BigInt(Value));
      }

      return SumBigIntNumbers(products);
    }
    
    public BigInt SumBigIntNumbers(List<BigInt> stringNumbers) {
      var maxIndex = stringNumbers.Max(s => s.Value.Length) - 1;
      long carry = 0;
      BigInt result = new BigInt("");
      for(int i=0;i<=maxIndex;i++) {
        result = new BigInt(AddStringAtIndex(stringNumbers, i, ref carry).Value + result.Value);       
      }
      result = new BigInt(carry.ToString() + result.Value);
      return result;
    }

    private BigInt AddStringAtIndex(IEnumerable<BigInt> stringNumbers, int index, ref long carry) {
      long sum = carry % 10;
      carry = carry / 10;

      sum += stringNumbers.Where(stringNumber => stringNumber.Value.Length > index).Sum(stringNumber => Int32.Parse(stringNumber.Value[stringNumber.Value.Length - 1 - index].ToString()));

      carry += sum / 10;

      return new BigInt(sum.ToString().Last().ToString());
    }

    public long SumOfDigits() {
      return Value.Sum(item => Int32.Parse(item.ToString()));
    }
  }
}
