using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.DataStructures {
  public class IntegerTreeNode {
    public int Value;

    public IntegerTreeNode Root;

    public IntegerTreeNode LeftParent;
    public IntegerTreeNode RightParent;

    public IntegerTreeNode LeftChild;
    public IntegerTreeNode RightChild;

    public IntegerTreeNode LeftSibling;
    public IntegerTreeNode RightSibling;
  }
}
