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
// Queue based approach
// Do a level order traversal by each level and keep track of the levels visited
public class Solution {
    public int MaxDepth(TreeNode root) {
        int maxDepth = 0;
        if (root == null) return maxDepth;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelCount = queue.Count;
            while (levelCount > 0)
            {
                TreeNode currNode = queue.Dequeue();
                if (currNode.left != null) queue.Enqueue(currNode.left);
                if (currNode.right != null) queue.Enqueue(currNode.right);
                --levelCount;
            }
            ++maxDepth;
        }

        return maxDepth;
    }
}
