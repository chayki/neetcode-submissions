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
// Can we simplify further?
// first element of preoder range is always the root, once we pick the root the remaining preorder array can have only left, only right or both. First element of the remaining array is again the root.
// Preorder structure aligns with the Tree construction process. i.e., construct the root, then left subtree, then right subtree i.e, root left, right
// so we can montonically increase preorder index and construct the tree recursively.
// we know the the next element in the preorder array is root of some subtree, whether its left or right is determined by the size of the subtree which inturn depends on inorder boundaries
public class Solution {
    Dictionary<int,int> inorderDictionary = new();
    int preorderIndex = 0; 
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        for (int i = 0; i < inorder.Length; ++i)
        {
            inorderDictionary[inorder[i]] = i;
        }
        return BuildTreeDFS(preorder, 0, inorder.Length-1);
    }

    private TreeNode BuildTreeDFS(int[] preorder, int l, int r)
    {
        if (l > r) return null;

        TreeNode root = new TreeNode(preorder[preorderIndex++]);

        int rootIndex = inorderDictionary[root.val];

        root.left = BuildTreeDFS(preorder, l, rootIndex-1);
        root.right = BuildTreeDFS(preorder, rootIndex+1, r);
        return root;
    }
}
