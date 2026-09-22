public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int maxFlights = k+1;
        int airports = n;

        int[][] state = new int[n][];
        for (int i = 0; i < n; ++i)
        {
            state[i] = new int[maxFlights+1];
            Array.Fill(state[i], int.MaxValue);
        }


        // create adjacency list for the flights
        Dictionary<int,List<(int,int)>> adjList = new();

        for (int i = 0; i < n; ++i)
        {
            adjList.Add(i, new List<(int,int)>());
        }

        for (int i = 0; i < flights.Length; ++i)
        {
            int source = flights[i][0];
            int destination = flights[i][1];
            adjList[source].Add((destination, flights[i][2]));
        }

        Queue<int> queue = new();
        state[src][0] = 0;
        queue.Enqueue(src);
        HashSet<int> nextAirports = new();
        int flightCount = 0;
        while (queue.Count > 0 && flightCount < k+1)
        {
            int levelSize = queue.Count;
            ++flightCount;
            nextAirports.Clear();
            while (levelSize > 0)
            {
                int currAirport = queue.Dequeue();
    
                foreach ((int nextAirport, int nextLegCost) in adjList[currAirport])
                {
                    int nextCost = state[currAirport][flightCount-1]+nextLegCost;
                    if (state[nextAirport][flightCount] <= nextCost) continue;
                    state[nextAirport][flightCount] = nextCost;
                    nextAirports.Add(nextAirport);
                }

                --levelSize;
            }

            foreach (int nextAirport in nextAirports)
            {
                queue.Enqueue(nextAirport);
            }
            
        }

        int minCost = int.MaxValue;
        for (int i = 0; i < state[0].Length; ++i)
        {
            if (state[dst][i] < minCost) minCost = state[dst][i];
        }

        return minCost == int.MaxValue ? -1 : minCost;
    }
}

/* Time complexity:
Creating state : O(nk)
Creating adjlist : O(n) + O(Flights) : 
Queue processing: each airport,flightCount combi enqueued and dequeued exactly once so O(nk)
For each dequeued airport, I iterate through all the outgoing flights i.e., outdegree(airport).
in the state array for each flightCount layer, across all n airports I iterate through O(E) outgoing flights
so the total complexity is O(k*E)
Result computation: O(k+1)

total time = nk(state) + n+E (adjList) + nk (queue ops) + kE (edge processing)

space complexity:
state: O(nk)
adjList: O(n+E)
queue: O(nk)
*/

