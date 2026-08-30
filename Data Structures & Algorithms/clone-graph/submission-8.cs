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
        if (node == null) return null;
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);
        Dictionary<Node, Node> nodeMapping = new();
        nodeMapping.Add(node, new Node() {val = node.val, neighbors = new List<Node>()});

        while (queue.Count > 0)
        {
            var originalNode = queue.Dequeue();
            foreach (var neighbor in originalNode.neighbors)
            {
                if (!nodeMapping.ContainsKey(neighbor)) 
                {
                    nodeMapping.Add(neighbor, new Node() { val = neighbor.val, neighbors = new List<Node>()});
                    queue.Enqueue(neighbor);
                }

                var clonedNode = nodeMapping[originalNode];
                var clonedNeighbor = nodeMapping[neighbor];
                clonedNode.neighbors.Add(clonedNeighbor);
            }
        }

        return nodeMapping[node];
    }
}

/* I will traverse the graph using BFS. For each node in the original graph, I need to clone it exactly once.
So I will create a mapping from original node to the cloned node. This will ensure the program dont run into infinite recursion.
Also multiple edges pointing to the node will reuse the same node.

After cloning the node, I will immediately add it to the dictionary before recursing to the neighbors.
Challenge: edges can't be added to the new node immediately because we dont have cloned nodes.
Soln: BFS proceeds level by level. When n+1 level is processed, nodes upto nth level would have already been cloned.
So when a node is processed, add edges pointing to the cloned nodes. Add other neighbours to the queue. 


The above solution failed since its not like a tree where each level will be processed before the next level. An edge to a node can 
come from any number of nodes even from the nodes of the same level. So there's a possibility that same node gets added to the queue
multiple times before getting cloned*/

/* Adding both forward and backward edges once is counter intuitive. Instead, keep adding edges as the nodes from original graph are processed.
i.e., when a node is visited, create a clone, iterate throug all the neighbors, create clone for each of those and clone the outgoing edges.
Let the reverse edges cloned naturally when the neighbors are visited from the queue. */
