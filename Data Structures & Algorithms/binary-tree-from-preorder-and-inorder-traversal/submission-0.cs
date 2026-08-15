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
// Preorder - root element can be known with certainity but can't know left and right subtree sizes
// Inorder - if we know the root, left and right subtree sizes can be known
public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int n = preorder.Length;
        return BuildTreeDFS(preorder, inorder, (0, n-1), (0, n-1));
    }

    public TreeNode BuildTreeDFS(
        int[] preorder,
        int[] inorder,
        (int start, int end) preRange,
        (int start, int end) inRange)
    {
        if (preRange.start > preRange.end) return null;
        TreeNode root = new TreeNode(preorder[preRange.start]);
        if (preRange.start == preRange.end) return root;
        
        int rootInOrderIndex = 0;
        for (int i = inRange.start; i <= inRange.end; ++i)
        {
            if (inorder[i] == root.val)
            {
                rootInOrderIndex = i;
                break;
            }
        }

        int leftSize = rootInOrderIndex-inRange.start;
        int rightSize = inRange.end-rootInOrderIndex;
        // left subtree
        preRange.start+=1;
        preRange.end = preRange.start+leftSize-1;
        inRange.end = inRange.start+leftSize-1;
        root.left = BuildTreeDFS(preorder, inorder, preRange, inRange);

        // right subtree
        preRange.start = preRange.end+1;
        preRange.end = preRange.start+rightSize-1;

        inRange.start = rootInOrderIndex+1;
        inRange.end = inRange.start+rightSize-1;
        root.right = BuildTreeDFS(preorder, inorder,preRange, inRange);
        return root;
    }
}
