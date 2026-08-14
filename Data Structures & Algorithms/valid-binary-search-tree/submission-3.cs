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
// Simpler approach is to pass down the range that the subtree is expected to fit in and return false when there's a misfit.
// DFS based approach
public class Solution {
    public bool IsValidBST(TreeNode root) {
        return IsValidBSTDFS(root, int.MinValue, int.MaxValue);
    }

    public bool IsValidBSTDFS(TreeNode root, long low, long high)
    {
        if (root == null) return true;
        if (root.val < low || root.val > high) return false;

        bool isValidLeft = IsValidBSTDFS(root.left, low, (long)root.val-1);
        bool isValidRight = IsValidBSTDFS(root.right, (long)root.val+1, high);

        if (isValidLeft && isValidRight) return true;
        else return false;
    }
}
