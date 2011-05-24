using System;
using System.Linq;
using System.Collections.Generic;

namespace Euler.Problems {

  public class EulerProblem31 : Problem {
    public EulerProblem31()
      : base(null, null, 200) {
      SolutionResponse = 73682;
    }
    
    public List<BritishCurrency> currencies = new List<BritishCurrency>{BritishCurrency.L2,BritishCurrency.L,BritishCurrency.p50, BritishCurrency.p20, BritishCurrency.p10, BritishCurrency.p5, BritishCurrency.p2, BritishCurrency.p};
    
    public override object Run(RunModes runMode, object input, bool Logging) {
      int total = (int)input;

      int combinations = 0;
      foreach(BritishCurrency bc in currencies){
        combinations += GetCombinations(total, bc, Logging);
      }

      return combinations;
    }

    private int GetCombinations(int p, BritishCurrency bc, bool logging) {
      int combinations=0;
      bool mod = p%((int)bc) == 0;
      int divisor = p / ((int)bc);
      if(mod) combinations++;
      
      if( currencies.Count(item=> (int)item< (int)bc) > 0 ){
        for(int i = divisor-((mod)?1:0); i >=1; i--) {
          foreach(BritishCurrency c in currencies.Where(item=>((int)item)<((int)bc)).OrderByDescending(item=>(int)item)) {
            combinations += GetCombinations(p - i * (int)bc, c, logging);
          }          
        }
      }
   
      return combinations;
    }  
  }

  public enum BritishCurrency{
    p = 1,
    p2 = 2, 
    p5 = 5,
    p10 = 10,
    p20 = 20,
    p50 = 50,
    L = 100,
    L2 = 200
  }
}
