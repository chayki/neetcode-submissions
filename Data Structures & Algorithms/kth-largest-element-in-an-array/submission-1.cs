public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        //1. Create a minHeap (key index, priority val) of size k
        //2. for i = 0 to k-1, insert into minHeap
        //3. for i = k+1 to n, 
        //      if priority > top elements 
        //          insert the element and remove the top
        //      else ignore
        // return top

        PriorityQueue<int,int> minHeap = new PriorityQueue<int,int>();
        for (int i = 0; i < k; ++i)
        {
            minHeap.Enqueue(i,nums[i]);
        }
        for (int i = k; i < nums.Length; ++i)
        {
            if (minHeap.TryPeek(out _, out int priority) && priority < nums[i])
            {
                minHeap.Enqueue(i, nums[i]);
                minHeap.Dequeue();
            }
        }
        
        return nums[minHeap.Peek()];
    }
}
