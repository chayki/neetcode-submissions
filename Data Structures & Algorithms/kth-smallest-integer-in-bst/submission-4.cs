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
// Morris traversal
public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        
        var currNode = root;
        while (currNode != null && k > 0)
        {
            if (currNode.left != null) // there is a left node find the inorder predecessor and connect the right to the currNode
            {
                // find inorder predecessor
                var inorderPred = currNode.left;
                while (inorderPred.right != null)
                {
                    inorderPred = inorderPred.right;
                }
                inorderPred.right = currNode;
                currNode = currNode.left;
                inorderPred.right.left = null;
            }
            else
            {
                --k;
                if (k == 0) break;
                currNode = currNode.right;
            }
        }

        return currNode.val;
    }
}
