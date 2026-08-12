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
// Last approach did not take the advantage of BST propery.
// if both p and q are less than the current node, go left
// if both p and q are greater than the current node go right
// otherwise the possibilities are
// current node is the bifurcation point - one node on left and the other on right, then the current node is the LCA
// one of the nodes equal to the current node - that is the LCA
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || p == null || q == null) return null;
        if (Math.Max(p.val, q.val) < root.val)
            return LowestCommonAncestor(root.left, p, q);
        else if (Math.Min(p.val, q.val) > root.val)
            return LowestCommonAncestor(root.right, p, q);
        else
            return root;
    }
}
