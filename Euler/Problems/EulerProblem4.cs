using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem4 : Problem {
    public EulerProblem4()
      : base(2, 9009, 3) {
        SolutionResponse = 906609;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
      return FindPalindromes((int)input).Max();
    }

    IEnumerable<int> FindPalindromes(int compositeDigitLength) {
      List<int> palindromes = new List<int>();
      for(var i = (int)Math.Pow(10, compositeDigitLength) - 1; i > (int)Math.Pow(10, compositeDigitLength - 1); i--) {
        for(var j = (int)Math.Pow(10, compositeDigitLength) - 1; j > (int)Math.Pow(10, compositeDigitLength - 1); j--) {
          if(IsPalidrome(i * j))
            palindromes.Add(i * j);
        }
      }
      return palindromes;
    }

    bool IsPalidrome(long palidrome) {
      string palidromeString = palidrome.ToString();
      for(int i = 0; i < palidromeString.Length / 2; i++) {
        if(palidromeString[i] != palidromeString[palidromeString.Length - 1 - i])
          return false;
      }
      return true;
    }
  }
}
