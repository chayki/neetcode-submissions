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
// DFS
public class Solution {
    List<int> result = new();
    public List<int> RightSideView(TreeNode root) {
        RightSideViewDFS(root, 0);
        return result;
    }

    public void RightSideViewDFS(TreeNode currNode, int depth)
    {
        //if (depth < result.Count) return; // right mode node is computed already
        if (currNode == null) return;
        if (depth == result.Count) result.Add(currNode.val);
        if (currNode.right != null) RightSideViewDFS(currNode.right, depth+1);
        if (currNode.left != null) RightSideViewDFS(currNode.left, depth+1);
    }
}
