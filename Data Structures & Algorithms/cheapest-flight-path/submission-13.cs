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

        Queue<(int destination, int flightCount)> queue = new();
        state[src][0] = 0;
        queue.Enqueue((src,0));
        
        HashSet<int> nextAirports = new();
        while (queue.Count > 0)
        {
            (int currAirport, int flightCount) = queue.Dequeue();
        
            if (flightCount < k+1)
            {
                nextAirports.Clear();
                int nextFlightsUsed = flightCount+1;
                foreach ((int nextAirport, int nextLegCost) in adjList[currAirport])
                {
                    int nextCost = state[currAirport][flightCount]+nextLegCost;
                    if (state[nextAirport][nextFlightsUsed] <= nextCost) continue;
                    state[nextAirport][nextFlightsUsed] = nextCost;
                    //queue.Enqueue((nextAirport, flightCount+1));
                    nextAirports.Add(nextAirport);
                }

                foreach (int nextAirport in nextAirports)
                {
                    queue.Enqueue((nextAirport, nextFlightsUsed));
                }   
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
Queue processing: for each airport and flightCount combi I am exploring all the outgoing edges from the airport atleast once
Result computation: O(k+1)
*/

