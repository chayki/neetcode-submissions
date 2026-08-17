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

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        if (root == null) return "-";
        List<string> result = new List<string>();
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var currNode = queue.Dequeue();
            if (currNode != null)
            {
                result.Add(currNode.val.ToString());
                queue.Enqueue(currNode.left);
                queue.Enqueue(currNode.right);
            }
            else
            {
                result.Add("-"); 
            }
        }

        return string.Join(",", result);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        var vals = data.Split(",");
        if (vals[0] == "-") return null;
        var root = new TreeNode(int.Parse(vals[0]));
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        
        int i = 1;
        while (queue.Count > 0 && i < vals.Length)
        {
            var currNode = queue.Dequeue();
            var val = vals[i++];
            if (val != "-") 
            { 
                currNode.left = new TreeNode(int.Parse(val));
                queue.Enqueue(currNode.left);
            }

            if (i < vals.Length)
            {
                val = vals[i++];
                if (val != "-") 
                {
                    currNode.right = new TreeNode(int.Parse(val));
                    queue.Enqueue(currNode.right);
                }
            }
        }

        return root;
    }
}
