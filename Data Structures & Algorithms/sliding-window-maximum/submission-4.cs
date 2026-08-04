// Brute force:
// For each window, maximum needs to be computed.
// total complexity = no of windows * window size
// = O((n-w)*w)
// if window size is half the complexity would be O(n^2)

// Optimized approach
// as the window changes we need an efficient way to figure out maximum.
// as elements are getting inserted and deleted, a max heap can give the maximum in constant time while logn effort spend to insert or delete
// Total complexity would be O(n-w * logn) = O(nlogn)
// space complexity O(n)
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (k == 1) return nums;
        PriorityQueue<int,int> maxQueue = new PriorityQueue<int,int>(Comparer<int>.Create((x,y) => y.CompareTo(x)));
        int[] result = new int[nums.Length-k+1];
        for (int i = 0;  i < k-1; ++i)
        {
            maxQueue.Enqueue(nums[i], nums[i]);
        }

        int j = 0;
        int left = 0, right = k-1;
        while (right < nums.Length)
        {
            maxQueue.Enqueue(nums[right], nums[right]);
            result[j] = maxQueue.Peek();
            maxQueue.Remove(nums[left], out _, out _);
            ++left;
            ++right;
            ++j;
        }

        return result;
    }
}
