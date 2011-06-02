using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public class BigInt : IComparable {
		public string Value { get; private set; }
		public static int MaxIndex { get; set; }
    public BigInt(string value) {
      Value = value;
    }

		public BigInt(string seed, int repeat) {
			Value = "";
			if (seed == "") return;
			for (int i = 0; i < repeat; i++) {
				Value += seed;
			}
		}
    public BigInt Product(int multiplier){
      List<BigInt> products = new List<BigInt>();
      for(int i=0;i<multiplier;i++){
        products.Add(new BigInt(Value));
      }

      return SumBigIntNumbers(products);
    }
    
		public static BigInt Exp(int x, int y) {
			if (x == 0) return new BigInt("0");
			if (y == 0) return new BigInt("1");
			BigInt ret = new BigInt(x.ToString());
			for (int i = 0; i < y-1; i++) {
				ret = ret.Product(x);
			}
			return ret;
		}

  	public BigInt SumBigIntNumbers(List<BigInt> stringNumbers) {
      var maxIndex = (MaxIndex!=0) ? MaxIndex : stringNumbers.Max(s => s.Value.Length) - 1;
      long carry = 0;
      BigInt result = new BigInt("");
      for(int i=0;i<=maxIndex;i++) {
        result = new BigInt(AddStringAtIndex(stringNumbers, i, ref carry).Value + result.Value);       
      }

    	var carryBigInt = new BigInt(carry.ToString());
			carryBigInt.StripLeadingZeros();
			result = new BigInt(carryBigInt.Value + result.Value);
			result.StripLeadingZeros();
      return result;
    }

		public void StripLeadingZeros() {
			int index = 0;
			while(index<Value.Length-1) {
				if (Value[index] != '0')
					break;
				index++;
			}

			Value = Value.Substring(index, Value.Length - index);
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

		public override bool Equals(object that) {
			var bigIntThat = that as BigInt;

			if (bigIntThat == null) return false;
			return CompareTo(that) == 0;
		}

		public override int GetHashCode() {
			return Value.GetHashCode();
		}

  	public int CompareTo(object that) {
  		var bigIntThat = that as BigInt;

			if (bigIntThat == null) return 1;

			StripLeadingZeros();
			bigIntThat.StripLeadingZeros();

			if (string.IsNullOrWhiteSpace(Value) && string.IsNullOrWhiteSpace(bigIntThat.Value)) return 0;
			if (Value.Length > bigIntThat.Value.Length) return 1;
			if (Value.Length < bigIntThat.Value.Length) return -1;

			for (int index = 0; index < Value.Length; index++) {
				if (Value[index] > bigIntThat.Value[index]) return 1;
				if (Value[index] < bigIntThat.Value[index]) return -1;
			}
  		return 0;
  	}

		public override string ToString() {
			return Value;
		}
  }
}
