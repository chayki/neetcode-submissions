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

// what is the repetitive work here?
// the same path sum is computed repeatedly for different node pairs.
// ex: consider the node pairs = 10,5 - 20-5 visited
// -5,5 - 20-5 visited
// 15,5 - 20-5 visited
// instead of recomputing the sum, compute once and reuse.
public class Solution {
    int globalMaxPathSum = -1500;
    public int MaxPathSum(TreeNode root) {
        MaxPathSumDFS(root);
        return globalMaxPathSum;
    }

    public int MaxPathSumDFS(TreeNode currNode)
    {
        if (currNode == null) return 0;
        int leftMaxSum = Math.Max(MaxPathSumDFS(currNode.left),0);
        int rightMaxSum = Math.Max(MaxPathSumDFS(currNode.right),0);
        int passThroughSum = currNode.val + leftMaxSum + rightMaxSum;
        globalMaxPathSum = Math.Max(globalMaxPathSum, passThroughSum);
        return currNode.val + Math.Max(leftMaxSum, rightMaxSum);
    }
}
