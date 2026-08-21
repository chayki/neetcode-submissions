public class Solution {
    public static int coolingInterval;
    public int LeastInterval(char[] tasks, int n) {
        coolingInterval = n;
        // Create a freq map of tasks
        // Seed maxHeap with item frequencies
        // Create a queue for waitlist
        // if maxHeap count > 0
        //  If queue.Count > 0
        //      while queue front schedule time eq curr time
        //          dequeue and add to the maxHeap
        //  Remove max freq item
        //  compute the remaining freq
        //  if remaining freq > 0
        //      compute the next schedule time and add to wait queue
        // 
        // schedule remaining tasks from the wait queue

        // Create a freq map of tasks
        Dictionary<char,int> frequency = new();
        foreach (char c in tasks)
        {
            if (!frequency.ContainsKey(c)) frequency.Add(c,0);
            frequency[c]+=1;
        }

        // Seed maxHeap with item frequencies
        PriorityQueue<char,Task> maxHeap = new(Comparer<Task>.Create((a,b) => b.RemainingFreq.CompareTo(a.RemainingFreq)));
        foreach(KeyValuePair<char,int> kvp in frequency)
        {
            maxHeap.Enqueue(kvp.Key, new Task(kvp.Key, kvp.Value));
        }

        // Create a queue for waitlist
        Queue<Task> queue = new Queue<Task>();
        int currTime = 1;
        while (maxHeap.Count > 0 || queue.Count > 0)
        {
            while (queue.Count > 0 && queue.Peek().UpcomingScheduleTime == currTime)
            {
                var dequeuedTask = queue.Dequeue();
                maxHeap.Enqueue(dequeuedTask.Key, dequeuedTask);
            }

            if (maxHeap.TryDequeue(out char key, out Task topFreqTask))
            {
                topFreqTask.ScheduleTaskAt(currTime);
                if (topFreqTask.RemainingFreq > 0) queue.Enqueue(topFreqTask);
            }


            ++currTime;
        }

        return currTime-1;
    }

    public class Task
    {
        public char Key {get; private set;}
        public int RemainingFreq {get; private set;}
        public int UpcomingScheduleTime {get; private set;}
        
        public Task(char key, int remainingFreq)
        {
            this.Key = key;
            this.RemainingFreq = remainingFreq;
        }

        public void ScheduleTaskAt(int time)
        {
            this.RemainingFreq-=1;
            this.UpcomingScheduleTime = (time+coolingInterval+1);
        }
    }

}
