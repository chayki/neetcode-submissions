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
// 
public class Solution {
    public bool IsValidBST(TreeNode root) {
        (bool isValidBST, int? min, int? max) = IsValidBSTDFS(root);
        return isValidBST;
    }

    private (bool, int?, int?) IsValidBSTDFS(TreeNode node)
    {
        if (node == null) return (true, null, null);
        (bool isValidBST, int? min, int? max) leftSubtree = IsValidBSTDFS(node.left);
        (bool isValidBST, int? min, int? max) rightSubtree = IsValidBSTDFS(node.right);

          if (!leftSubtree.isValidBST || !rightSubtree.isValidBST)
        {
            return (false, null, null);
        }

        bool isLeftValid = node.val > (leftSubtree.max ?? (long)node.val-1);
        bool isRightValid = node.val < (rightSubtree.min ?? (long)node.val+1);
        if (isLeftValid && isRightValid)
        {
            return (true, leftSubtree.min ?? node.val, rightSubtree.max ?? node.val);
        }
        else
        {
            return (false, null, null);
        }
    }
}
