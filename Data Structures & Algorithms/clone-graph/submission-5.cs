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


/*
    Receive Original Node
            |
    Is it already cloned?
            |
        Return clone
            |
    Crete a clone
            |
    Add original - clone mapping immediately
            |
    Clone neighbors
            |
    Return clone

*/

/* I will perform a DFS from the original node. For every original node, I need to create exactly one cloned node
so I will maintain a dictionary mapping from each original node to its clone.
When DFS visits a node, I will check if its already cloned. If yes, will return the cloned one.
This will ensure the program wont run into infinite recursion in cyclic graph and also ensures that multiple edges pointing 
to the same node reuse the same node.
if a node has not been cloned yet, I will create a clone of it and add that immediately to the mapping before recursing to the neighbours.
This is important because a cycle may lead back to the same node.

Finally, recursively clone every neighbor and add the returned cloned node to current clone's neighbour list.

*/

/*
Time complexity:
I have to clone each node and edge
In an undirected graph number of edges would be 2E since I need to store both forward and reverse edges.
So total complexity = O(V+2E) = O(V+E)

Space complexity:
I have to store all the nodes and their edges = O(V+E)
Auxiliary space:
Dictionary<Node,Node> - O(v)
Recursion Stack - O(v)
So O(V) auxiliary space
*/
