/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
// Stack based approach
// when we do BFS, every path we travel down the tree till leaf should be present on the stack
// maxDepth is the max count of stack element during its life time.
// keep pushing on to the stack when any of the children are present, otherwise pop the element repeat the same for the parent.
// one a child is pushed on to the stack we have to break its link to the parent otherwise it will be pushed again when the parent is processed.
public class Solution {
    public int MaxDepth(TreeNode root) {
        int maxDepth = 0;
        if (root == null) return maxDepth;
        Stack<TreeNode> stack = new();
        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode topNode = stack.Peek();

            if (topNode.left != null)
            {
                stack.Push(topNode.left);
                topNode.left = null;
            }
            else if (topNode.right != null)
            {
                stack.Push(topNode.right);
                topNode.right = null;
            }
            else
            {
                maxDepth = Math.Max(maxDepth, stack.Count);
                stack.Pop();
            }
        }

        return maxDepth;
    }
}
