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
// The same range validity checks can also be executed using BFS
public class Solution {
    public bool IsValidBST(TreeNode root) {
        if (root == null) return true;
        Queue<(int? low, int? high)> rangeQueue = new Queue<(int?, int?)>();
        Queue<TreeNode> queue = new();

        queue.Enqueue(root);
        rangeQueue.Enqueue((null, null));

        while (queue.Count > 0)
        {
            TreeNode currNode = queue.Dequeue();
            (int? low, int? high) range = rangeQueue.Dequeue();
            if ((range.low != null && currNode.val <= range.low) || (range.high != null && currNode.val >= range.high)) return false;

            if (currNode.left != null)
            {
                queue.Enqueue(currNode.left);
                rangeQueue.Enqueue((range.low, currNode.val));
            }

            if (currNode.right != null)
            {
                queue.Enqueue(currNode.right);
                rangeQueue.Enqueue((currNode.val, range.high));
            }
        }

        return true;
    }
}
