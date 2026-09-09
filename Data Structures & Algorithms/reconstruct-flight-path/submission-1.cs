public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        var result = new List<string>();
        if (tickets.Count == 0) return result;
        Dictionary<string,List<(string,int)>> adjList = new();
        bool[] visited = new bool[tickets.Count];

        // prepare adj list
        for (int i = 0; i < tickets.Count; ++i)
        {
            var origin = tickets[i][0];
            var dest = tickets[i][1];

            if (!adjList.ContainsKey(origin)) adjList.Add(origin, new List<(string,int)>());
            adjList[origin].Add((dest, i));
        }

        // sort the edges for those to be visited lexicographically
        foreach (var kvp in adjList)
        {
            kvp.Value.Sort();
        }

        ReverseEulerTraversal(adjList, "JFK", result, visited);
        result.Reverse();
        return result;
    }

    public void ReverseEulerTraversal(
        Dictionary<string,List<(string,int)>> adjList,
        string airport,
        List<string> result,
        bool[] visited)
    {
        if (!adjList.ContainsKey(airport)) 
        {
            result.Add(airport);
            return;
        }

        foreach ((string dest, int routeId) in adjList[airport])
        {
            if (visited[routeId]) continue;
            visited[routeId] = true;
            ReverseEulerTraversal(adjList, dest, result, visited);
        }
        result.Add(airport);
    }
}
/* I will start a DFS from the source node "JFK". For each of the unvisited edge (destination airport) from the current node(origin airport), 
I will pick lexicographically smallest airport to visite next. I will repeat this process until all the possible edges are explored.
I will maintain a result list to add the nodes as and when those are finalized to be visited next */

/* Euler's path is a path that starts and ends at a node in a connected directional graph and visits all the edges exactly once */

/* To find Euler's path in a graph, I will start at the start node and continue exploring the graph using DFS.
If I stuck at a node, I will check if all edges are visited in the global state. 
If yes, termingate the algo
If no, backtrack to explore unvisited edges. While I back track I will remove the remove the nodes from the result and re-add the edges to unvisited list*/

/* I will start at a node and explore the graph using DFS. 
If I reach a node for which all the outgoing edges were explored already, that node can be finalized and added to the result before backtracking to explore other unvisited edges. 
I will repeat this process until all the edges are visited. Euler path/cycle would be reverse version of the result*/ 
