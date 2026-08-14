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
// instead of type conversion and treating int.MinValue and int.MaxValue as boundary conditions pass null as the boundary and only validate boundary condition when its non null
public class Solution {
    public bool IsValidBST(TreeNode root) {
        return IsValidBSTDFS(root, null, null);
    }

    public bool IsValidBSTDFS(TreeNode node, int? low, int? high)
    {
        if (node == null) return true;
        
        // check boundary condition only when boundary is not null
        // if the node value is outside the boundaries inclusively return false;
        if ((low != null && node.val <= low) || (high != null && node.val >= high)) return false;

        // node is withing the boundaries, proceed to check for left and right sub trees.
        bool isValidLeft = IsValidBSTDFS(node.left, low, node.val);
        bool isValidRight = IsValidBSTDFS(node.right, node.val, high);

        // if both trees are valid return true else false
        if (isValidLeft && isValidRight) return true;
        else return false;
    }
}
