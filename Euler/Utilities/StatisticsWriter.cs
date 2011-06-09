using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Utilities {
  public class StatisticsWriter {

    private List<Statistics> Stats;
    public StatisticsWriter() {
      Stats = new List<Statistics>();
    }

    public void Add(Statistics stat) { Stats.Add(stat); }

    public void Dump(BatchModes batchMode) {
      switch(batchMode) {
        case BatchModes.All:
          FileWriter.WriteStatisticsToFile(batchMode.ToString(), "All Statistics", FormatAllStatistics());
          FileWriter.WriteStatisticsToFile(BatchModes.Wrong.ToString(), "Wrong Statistics", FormatStatistics(item=>!item.Correct));
          FileWriter.WriteStatisticsToFile(BatchModes.Correct.ToString(), "Correct Statistics", FormatStatistics(item => item.Correct));
          FileWriter.WriteStatisticsToFile(BatchModes.Slow.ToString(), "Slow Statistics", FormatOrderedStatistics(false, item => item.SolutionTime, 10));
          FileWriter.WriteStatisticsToFile(BatchModes.Fast.ToString(), "Fast Statistics", FormatOrderedStatistics(true, item => item.SolutionTime, 10));
          break;
        case BatchModes.Wrong:
          FileWriter.WriteStatisticsToFile(batchMode.ToString(), "Wrong Statistics", FormatStatistics(item=>!item.Correct));
          break;
        case BatchModes.Correct:
          FileWriter.WriteStatisticsToFile(batchMode.ToString(), "Correct Statistics", FormatStatistics(item=>item.Correct));
          break;
        case BatchModes.Slow:
          FileWriter.WriteStatisticsToFile(batchMode.ToString(), "Slow Statistics", FormatOrderedStatistics(false, item=>item.SolutionTime, 10));
          break;
        case BatchModes.Fast:
          FileWriter.WriteStatisticsToFile(batchMode.ToString(), "Fast Statistics", FormatOrderedStatistics(true, item => item.SolutionTime, 10));
          break;
      }
    }

    private string FormatStatistics(Func<Statistics, bool> criteria){
      return FormatStatistics(Stats.Where(criteria));
    }

    private string FormatOrderedStatistics(bool asc, Func<Statistics, object> criteria, int takeCount) {
      IEnumerable<Statistics> stats;
      if(asc){
        stats= Stats.OrderBy(criteria);
      }
      else {
        stats= Stats.OrderByDescending(criteria);
      }

      return FormatStatistics(stats.Take(takeCount));
    }

    private string FormatStatistics(IEnumerable<Statistics> stats) {
      return stats.Aggregate("", (current, stat) => current += stat.ToString() + Environment.NewLine);
    }
     
    private string FormatAllStatistics(){
      return FileWriter.GetFileSection("Wrong Statistics", FormatStatistics(item=>!item.Correct)) + Environment.NewLine +
              FileWriter.GetFileSection("Correct Statistics", FormatStatistics(item => item.Correct)) + Environment.NewLine +
              FileWriter.GetFileSection("Slow Statistics", FormatOrderedStatistics(false, item => item.SolutionTime, 10)) + Environment.NewLine +
              FileWriter.GetFileSection("Fast Statistics", FormatOrderedStatistics(true, item => item.SolutionTime, 10));
    }
  }

  public class Statistics {
    public Type ProblemType;
    public object Solution;
    public TimeSpan SolutionTime;
    public bool Correct;

    public Statistics(Type ProblemType, object Solution, TimeSpan SolutionTime, bool Correct) {
      this.ProblemType = ProblemType;
      this.Solution = Solution;
      this.SolutionTime = SolutionTime;
      this.Correct = Correct;
    }

    public override string ToString() {
      return ProblemType.ToString() + Environment.NewLine +
              Solution + Environment.NewLine +
              String.Format("{0}.{1}.{2}", SolutionTime.Minutes, SolutionTime.Seconds, SolutionTime.Milliseconds) + Environment.NewLine +
              Correct.ToString() + Environment.NewLine;
    }
  }
}
