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
// height of a binary tree at root = number of edges in the longest path from root to leaf
// diameter = (1 + height of left binary tree) + (1 + height of right binary tree);
// so instead of counting edges for the height calculation, count nodes
public class Solution {
    public int DiameterOfBinaryTree(TreeNode root) {
        int res = 0;
        DFS(root, ref res);
        return res;
    }

    private int DFS(TreeNode root, ref int res)
    {
        if (root == null) return 0;
        int leftHeight = DFS(root.left, ref res);
        int rightHeight = DFS(root.right, ref res);
        res = Math.Max(res, leftHeight+rightHeight);
        return 1+Math.Max(leftHeight, rightHeight);
    }
}
