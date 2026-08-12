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
// Possibilies:
// 1. both nodes exist on the same path from root to a leaf node - one of these two nodes is the LCA
// 2. nodes exists on differnt root to leaf paths - the node at which those bifurcates is the LCA

// Do DFS which visits every path from left to right
// while unwraping check if the current node is one of p or q, if yes bubble up that node
// any node can be a point of bifurcation, so while unwrapping check i

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        return LCADFS(root, p, q);
    }

    public TreeNode LCADFS(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null) return null;
        
        TreeNode left = LCADFS(root.left, p, q);
        TreeNode right = LCADFS(root.right, p, q);

        if (root == p || root == q) 
        {
            return root;
        }
        else if (left != null && right != null) return root;
        else if (left != null) return left;
        else if (right != null) return right;
        else return null;
    }
}
