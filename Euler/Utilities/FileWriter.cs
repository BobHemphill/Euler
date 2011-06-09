using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Utilities {
  public class FileWriter {
    const string Path = "..\\..\\..\\Statistics\\";
    public static void WriteStatisticsToFile(string fileName, string title, string body) {
      using(System.IO.StreamWriter file = new System.IO.StreamWriter(Path + fileName + ".txt")) {
        file.Write(GetFileSection(title, body));        
      }
    }

    public static string GetFileSection(string title, string body){
      const string borderFormat = "*****";
      const string start = "Start";
      const string end = "End";
      return borderFormat + start + " " + title + borderFormat + Environment.NewLine +
             body + Environment.NewLine + 
             borderFormat + end + " " + title + borderFormat + Environment.NewLine;
    }
  }
}
