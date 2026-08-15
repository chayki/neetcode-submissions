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
// Can we optimize further? yes. 
// In solution1, for each root found in preorder we are iterating through the inorder array to find the root index - overall time complexity O(n^2)
// we can improve this by populating into hashmap
public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int n = preorder.Length;
        Dictionary<int,int> inorderDictionary = new();
        for (int i = 0; i < inorder.Length; ++i)
        {
            inorderDictionary.Add(inorder[i],i);
        }

        return BuildTreeDFS(preorder, inorderDictionary, (0, n-1), (0, n-1));
    }

    public TreeNode BuildTreeDFS(
        int[] preorder,
        Dictionary<int,int> inorderDictionary,
        (int start, int end) preRange,
        (int start, int end) inRange)
    {
        if (preRange.start > preRange.end) return null;
        TreeNode root = new TreeNode(preorder[preRange.start]);
        if (preRange.start == preRange.end) return root;
        
        int rootInOrderIndex = inorderDictionary[root.val];
        

        int leftSize = rootInOrderIndex-inRange.start;
        int rightSize = inRange.end-rootInOrderIndex;
        // left subtree
        preRange.start+=1;
        preRange.end = preRange.start+leftSize-1;
        inRange.end = inRange.start+leftSize-1;
        root.left = BuildTreeDFS(preorder, inorderDictionary, preRange, inRange);

        // right subtree
        preRange.start = preRange.end+1;
        preRange.end = preRange.start+rightSize-1;

        inRange.start = rootInOrderIndex+1;
        inRange.end = inRange.start+rightSize-1;
        root.right = BuildTreeDFS(preorder, inorderDictionary,preRange, inRange);
        return root;
    }
}
