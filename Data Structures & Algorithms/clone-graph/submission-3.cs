/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        Dictionary<Node, Node> nodeMapping = new();
        return this.CloneGraphDFS(node, nodeMapping);
    }

    public Node CloneGraphDFS(Node node, Dictionary<Node,Node> nodeMapping)
    {
        if (node == null) return null;
        // The state represents the node to be visited
        // Is valid state?
        if (nodeMapping.ContainsKey(node)) return nodeMapping[node];
        var newNode = new Node() { val = node.val, neighbors = new List<Node>()};
        nodeMapping.Add(node, newNode);
        
        // iterate through all the choices
        foreach (var neighbor in node.neighbors)
        {
            newNode.neighbors.Add(CloneGraphDFS(neighbor, nodeMapping));
        }

        return newNode;
    }
}

// I will launch a DFS from the given node and recursively visit all neighbours. When I visit a node I will create a clone of it.
// I will maintain a dictionary mapping from old node to the cloned node.
// When I visit a node, I will check if its already visited by checking the dictionary. If its already visited, create that edge
// between the cloned nodes.
// The DFS will reach a base case when the node is already visisted.
