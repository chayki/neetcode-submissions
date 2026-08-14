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
// iterative solution using stack.
// Instead of recusion stack, we use stack datastructure on heap
// if the top node of the stack has left child, push that on to the stack.
// if no left child , pop the stack process it and push right child if exists
public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> stack = new();
        var currNode = root;
        stack.Push(currNode);
        while (stack.Count > 0 && k > 0)
        {
            currNode = stack.Peek();
            if (currNode.left != null) 
            {
                stack.Push(currNode.left);
                currNode.left = null;
            }
            else
            {
                stack.Pop();
                --k;
                if (currNode.right != null) 
                {
                    stack.Push(currNode.right);
                    currNode.right = null;
                }
            }
        }

        return currNode.val;
    }
}
