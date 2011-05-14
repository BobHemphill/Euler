using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.DataStructures {
  public class IntegerTree {
    public IntegerTreeNode Root;
    public List<IntegerTreeNode> Nodes { get; private set; }
    private Dictionary<int, int> IndexToRowHash = new Dictionary<int, int>();

    public int Rows { get; private set; }

    public IntegerTree(List<int> values) {
      Nodes = values.Select(item => new IntegerTreeNode() { Value = item }).ToList();

      Root = Nodes.FirstOrDefault();
      SetIndexDictionary();      
    }

    private int GetRowFromIndex(int index) {
      return GetRowFromIndex(1, index + 1);
    }

    private int GetRowFromIndex(int row, int index) {
      if(index <= row) return row;
      return GetRowFromIndex(row + 1, index - row);
    }

    public void PrintTreeIndeces() {
      int tempRow = 1;
      for(int i = 0; i < Nodes.Count; i++) {
        int row = IndexToRowHash[i];
        if(tempRow != row) {
          Console.WriteLine();
          tempRow = row;
        }
        Console.Write(String.Format("{0} ", row));
      }
      Console.WriteLine();
    }
    public void PrintTree() {
      int tempRow = 1;
      for(int i = 0; i < Nodes.Count; i++) {
        int row = IndexToRowHash[i];
        if(tempRow != row) {
          Console.WriteLine();
          tempRow = row;
        }
        Console.Write(String.Format("{0} ", Nodes[i].Value));
      }
      Console.WriteLine();
    }

    private void BuildTree() {
      SetIndexDictionary();
      for(int i = 0; i < Nodes.Count; i++) {
        if(HasLeftChild(i))
          Nodes[i].LeftChild = Nodes[GetLeftChildIndex(i)];
        if(HasRightChild(i))
          Nodes[i].RightChild = Nodes[GetRightChildIndex(i)];
      }
    }

    private void SetIndexDictionary() {
      for(int i = 0; i < Nodes.Count; i++) {
        IndexToRowHash.Add(i, GetRowFromIndex(i));
      }
    }

    private int GetLeftChildIndex(int index) {
      int temp = index + IndexToRowHash[index];
      return (temp < Nodes.Count) ? temp : -1;
    }
    private bool HasLeftChild(int index) {
      return GetLeftChildIndex(index) != -1;
    }

    private int GetRightChildIndex(int index) {
      int temp = index + IndexToRowHash[index] + 1;
      return (temp < Nodes.Count) ? temp : -1;
    }
    private bool HasRightChild(int index) {
      return GetRightChildIndex(index) != -1;
    }

    private int SumLeft(int index, int sum, bool logging) {
      int temp = Nodes[index].Value;
      sum += temp;
      bool hasLeftChild = HasLeftChild(index);
      if(!hasLeftChild) {
        PathSums.Add(sum);
        if(logging) {
          Console.Write(String.Format("{0} ", sum));
        }
        return temp;
      }
      return temp + FindMaxSum(GetLeftChildIndex(index), sum, logging);
    }

    private int SumRight(int index, int sum, bool logging) {
      int temp = Nodes[index].Value;
      sum += temp;
      bool hasRightChild = HasRightChild(index);
      if(!hasRightChild) {
        //Only Necessary if Tree is not level
        //PathSums.Add(sum);
        //if(logging) {
        //  Console.Write(String.Format("{0} ", sum));
        //}
        return temp;
      }
      return temp + FindMaxSum(GetRightChildIndex(index), sum, logging);
    }

    private Dictionary<int, int> IndexToMaxHash = new Dictionary<int, int>();
    private List<int> PathSums = new List<int>();
    public int FindMaxSum(bool logging) {
      int rtn = FindMaxSum(0, 0, logging);
      if(logging) {
        Console.WriteLine();
      }
      return rtn;
    }
    public int FindMaxSum(int index, int sum, bool logging) {
      if( IndexToMaxHash.ContainsKey(index))
        return IndexToMaxHash[index];
      int sumLeft = SumLeft(index, sum, logging);
      int sumRight = SumRight(index, sum, logging);

      int maxSum = Math.Max(sumLeft, sumRight);
      IndexToMaxHash.Add(index, maxSum);
      return maxSum;
    }
  }
}
