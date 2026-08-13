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
// Every node from the root to the node x should be less than x then x is considered good node.
// Explore all the paths keep track of the max in the path
// if any upcoming node is lesser or equal to the max its not a good node
public class Solution {
    private int goodNodes = 0;
    public int GoodNodes(TreeNode root) {
        if (root == null) return goodNodes;
        GoodNodesDFS(root, -101);
        return goodNodes;
    }

    public void GoodNodesDFS(TreeNode node, int max)
    {
        if (node == null) return;
        if (node.val >= max) ++goodNodes;
        GoodNodesDFS(node.left, Math.Max(node.val, max));
        GoodNodesDFS(node.right, Math.Max(node.val, max));
    }
}
