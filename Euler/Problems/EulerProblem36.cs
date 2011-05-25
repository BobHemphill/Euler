using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

  public class EulerProblem36 : Problem {
    public EulerProblem36()
      : base(null, null, 1000000) {
        SolutionResponse = 872187;
    }

    public override object Run(RunModes runMode, object input, bool Logging) {
     var sum = 0;
     for(int i = 0;i<1000000;i++){
      if( Palindrome.IsPalindrome(i.ToString()))
        if(Palindrome.IsPalindrome(ConvertToBase(i,2)))
          sum+=i;
     }
     
     return sum;
    }

    private string ConvertToBase(int i, int convertToBase) {
      if( i<convertToBase ) return i.ToString();

      var exp=0;
      while((int)Math.Pow(convertToBase, exp+1) <= i) exp++;

      
      var tempString = "";
      var newI = i;
      for(int index = exp; index > 0; index--) {
        int bigEnd = (int)Math.Pow(convertToBase, index);
        tempString += (newI / bigEnd).ToString();
        newI -= bigEnd * (newI / bigEnd);
      }
      tempString += newI.ToString();     
      return tempString; 
    }
  }
}
