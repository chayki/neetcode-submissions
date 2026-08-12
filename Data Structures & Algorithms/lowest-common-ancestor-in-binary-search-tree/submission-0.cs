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

public class Solution {
    bool bothNodesFound = false;
    TreeNode lca = null;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        return LCADFS(root, p, q);
    }

    public TreeNode LCADFS(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null) return null;
        
        TreeNode left = LCADFS(root.left, p, q);
        TreeNode right = LCADFS(root.right, p, q);

        if (root == p || root == q) return root;
        else if (left != null && right != null) return root;
        else if (left != null) return left;
        else if (right != null) return right;
        else return null;
    }
}
