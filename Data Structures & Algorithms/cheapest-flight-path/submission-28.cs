/* In the previous solution I used FIFO queue which is essentially BFS over expanded state graph.
Expanded state graph: when graph requires extra info beyond the node to determine future possibilities.
i.e., (node+flightsUsed) is a vertex in the new, expanded graph.

Instead of doing layered BFS, which explores the graph based on flightsUsed ordering, 
I will explore the graph using min cost ordering using minHeap i.e., Dijkstra algorithm

Advantages of Dijkstra algo:
1. State finalization: when a node, flightsUsed combination is popped from the future states, its final.
2. Early termination: when a destination node is popped from future states, 
we can terminate since no future valid destination state can be cheaper
*/
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[][] state = new int[n][];
        for (int i = 0; i < n; ++i)
        {
            state[i] = new int[k+2];
            Array.Fill(state[i], int.MaxValue);
        }

        // Create a graph structure
        Dictionary<int,List<(int,int)>> adjList = new();

        for (int i = 0; i < n; ++i)
        {
            adjList[i] = new List<(int,int)>();
        }

        for (int i = 0; i < flights.Length; ++i)
        {
            int origin = flights[i][0];
            int dest = flights[i][1];
            int cost = flights[i][2];
            adjList[origin].Add((dest, cost));
        }

        // PQ
        PriorityQueue<(int, int), int> pq = new();
        pq.Enqueue((src, 0), 0);
        state[src][0] = 0;

        while (pq.TryDequeue(out (int currDest, int flightsUsed) minCostState, out int cost))
        {
            if (minCostState.currDest == dst) return cost;
            foreach ((int nextDest, int flightLegCost) in adjList[minCostState.currDest])
            {
                if (minCostState.flightsUsed < k+1 && cost+flightLegCost < state[nextDest][minCostState.flightsUsed+1])
                {
                    state[nextDest][minCostState.flightsUsed+1] = cost +flightLegCost;
                    pq.Enqueue((nextDest, minCostState.flightsUsed+1), cost+flightLegCost);
                }
            }
        }

        return -1;
    }
}
