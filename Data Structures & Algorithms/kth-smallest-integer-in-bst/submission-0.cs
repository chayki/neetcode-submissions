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

// Inorder traversal of the tree travels the tree nodes in an ascending order
// kth smallest element is the kth element from the begining.
// As and when kth smallest element is found exit from the inorder traversal

// we need to keep track of how many visited as the traversal progresses.
public class Solution {
    bool terminateSearch = false;
    int kthSmallestElement = -1;
    public int KthSmallest(TreeNode root, int k) {
        InorderTraversal(root, ref k);
        return kthSmallestElement;
    }

    private void InorderTraversal(TreeNode node, ref int k)
    {
        if (k == 0) return;
        if (node == null) return; // empty node, return
        InorderTraversal(node.left, ref k);
        --k;

        if (k == 0) 
        {
            kthSmallestElement = node.val;
            return;
        }
        InorderTraversal(node.right, ref k);
    }
}
