using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public static class Palindrome {
    public static bool IsPalindrome(string n){
      int upperLimit = (n.Length%2==0) ? n.Length/2-1:n.Length/2;

      for(int i=0;i<=upperLimit;i++){
        if(n[i]!=n[n.Length-1-i]) return false;
      }

      return true;
    }
  }
}
