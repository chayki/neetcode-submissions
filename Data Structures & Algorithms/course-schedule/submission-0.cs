public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        if (numCourses == 0) return false;
        if (prerequisites.Length == 0) return true;
        
        var predecessors = new List<int>[numCourses];
        var outDegree = new int[numCourses];
        int completedCourses = 0;

        for (int i = 0; i < numCourses; ++i)
        {
            predecessors[i] = new List<int>();
        }

        foreach (var prereq in prerequisites)
        {
            predecessors[prereq[1]].Add(prereq[0]);
            outDegree[prereq[0]]+=1;
        }

        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; ++i)
        {
            if (outDegree[i] == 0) queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            var courseId = queue.Dequeue();
            completedCourses+=1;
            foreach (var predecessor in predecessors[courseId])
            {
                outDegree[predecessor]-=1;
                if (outDegree[predecessor] == 0) queue.Enqueue(predecessor);
            }
        }

        return completedCourses == numCourses;
    }
}

/* I will use a reverse topological sort. I start with all the sink nodes - nodes whos out-degree is zero.
When I remove a sink, I remove its incoming edges logically by decrementing the out-degree of its predecessors.
Any predecessor whose out-degree becomes zero is ready to be processed. If I can process process all nodes, the graph is acyclic.
Otherwise remaining nodes form/depend on a cycle. */

/* I will iterate through the prerequisites array and build out-degree array for each node and node to incoming edge mapping in 2d array. While I iterate indegree array and add 0 degree nodes to the queue. I will dequeue a node and decrease outdegree for all the nodes predecessor nodes and add those nodes whose outdegree becomes zero to the queue. I wil repeat the process while queue count > 0 . I will keep track of the global processed nodes count and increment it whenever I process a node from the queue. On completion of the entire process, if processed nodes eq to numCourses will return true else will return false */
