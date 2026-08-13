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
// loop invariant
// after processing ith level in BFS
// 1. The goodNodes contain the number of good nodes upto ith level
// 2. Queue contains (i+1)th level nodes and max upto the parents
public class Solution {
    public int GoodNodes(TreeNode root) {
        if (root == null) return 0;
        int goodNodes = 0;
        Queue<int> maxQueue = new();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        maxQueue.Enqueue(root.val);
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            int max = maxQueue.Dequeue();
            if (max <= node.val) ++goodNodes;

            if (node.left != null) 
            {
                queue.Enqueue(node.left);
                maxQueue.Enqueue(Math.Max(max, node.val));
            }
            if (node.right != null)
            {
                queue.Enqueue(node.right);
                maxQueue.Enqueue(Math.Max(max,node.val));
            }
        }
        return goodNodes;
    }
}
