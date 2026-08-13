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

// number of good nodes in a tree rooted at a node = number of good nodes in left + number of good nodes in right + 1 (if root.val >= max)
public class Solution {
    private int goodNodes = 0;
    public int GoodNodes(TreeNode root) {
        if (root == null) return goodNodes;
        return GoodNodesDFS(root, root.val);
    }

    public int GoodNodesDFS(TreeNode node, int max)
    {
        if (node == null) return 0;
        int res = 0;
        res = (node.val >= max) ? 1 : 0;
        max = Math.Max(max, node.val);
        res+=GoodNodesDFS(node.left, max);
        res+=GoodNodesDFS(node.right, max);
        return res;
    }
}
