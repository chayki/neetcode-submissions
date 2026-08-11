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
// The diameter 
// 1. May start at some node and end at leaf
// 2. May pass through some node to the right subtree

// 1. Calculate the max diameter passing through every node (Diameter passing through node = maxLength of left subtree + maxLength of right subtree)
public class Solution {
    int maxDiameter = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        HeightOfBinaryTreeDfs(root);
        return maxDiameter;
    }

    public int HeightOfBinaryTreeDfs(TreeNode root)
    {
        if (root == null) return 0;
        int diameter = 0;
        int leftSubTreeHeight = 0;
        int rightSubTreeHeight = 0;
        int height = 0;
        
        if (root.left != null) 
        {
            leftSubTreeHeight = HeightOfBinaryTreeDfs(root.left);
            diameter +=  leftSubTreeHeight+1;
            height = Math.Max(height, leftSubTreeHeight+1);
        }
        if (root.right != null) 
        {
            rightSubTreeHeight = HeightOfBinaryTreeDfs(root.right);
            diameter += rightSubTreeHeight+1;
            height = Math.Max(height, rightSubTreeHeight+1);
        }

        maxDiameter = Math.Max(diameter, maxDiameter);
        return height;
    }
}
