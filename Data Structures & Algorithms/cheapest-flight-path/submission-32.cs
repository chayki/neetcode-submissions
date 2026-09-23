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
        // Create state
        // Time complexity - O(n*(k+2)) = O(nk)
        // Space complexity - O(nk)
        int[][] state = new int[n][];
        for (int i = 0; i < n; ++i)
        {
            state[i] = new int[k+2];
            Array.Fill(state[i], int.MaxValue);
        }

        /* Create a graph structure
        Time - O(n+E)
        Space - O(n+E)
        */
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

/* Relaxation in the expanded graph:
Take an edge from (node, flightsUsed) -> (node, flightsUsed+1) and check if curr state's cost + edge cost improves the best known cost to that next state */

/* How many times an expanded edge can be relaxed?
A flight route can be relaxed as many times as the number of flights.
If there are k+1 flights, a single route can be relaxed k times. */


/*
Time complexity:
Creating state - o(nk)
Creating graph - O(n+E)
Priority Queue - each original edge can participate in relaxation at upto k+1 flight-count layers
So each original edge can be considered for relaxation at O(k) flight-count layers, giving O(kE) relaxation attempts.
A successful relaxation causes a PQ enqueue, so there are at most O(kE) enqueues.
Each PQ enqueue/dequeue costs a log factor
so Dijkstra processing time: O(kE log kE)
total time: O(nk) + O(n+E) + O(kE logkE) = O(nk+n+E+kElogKE) = O(nk + E+ kElogkE)
dominant complexity term kElogkE, hence O(kElogkE)

Space complexity:
Priority Queue - each successful expanded edge relaxation results in an enqueue, so total space O(kE)
State - O(nk)
Graph - O(n+E)
Total: O(kE) +O(nk) +O(n+E) = O(kE+nk+E)
*/
