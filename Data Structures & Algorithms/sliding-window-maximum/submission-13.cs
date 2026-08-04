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

// important learning
// when an element falls out of the window, it can be at the middle of the heap. If the element is deleted when its not at the top, its going to take O(n) time
// so dont delete when the element is out of the window immediately, only delete when it comes to the top while processing.

// Can we optimize further?
// possible cases when window changes
// new max joins the window - can be compared against existing max and can be updated
// element other than max leaves out of the window - does not matter, max is still the max
// max leaves the window, we need second max - second max is the second maximum element occurrs in when travelled monotonically from left to right, any other element does not matter
// how about double ended queue?
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (k == 1) return nums;
        PriorityQueue<int,int> maxQueue = new PriorityQueue<int,int>(Comparer<int>.Create((x,y) => y.CompareTo(x)));
        int[] result = new int[nums.Length-k+1];
        for (int i = 0;  i < k-1; ++i)
        {
            maxQueue.Enqueue(i, nums[i]);
        }

        int j = 0;
        int left = 0, right = k-1;
        while (right < nums.Length)
        {
            maxQueue.Enqueue(right, nums[right]);
            int value;
            while (maxQueue.TryPeek(out int index, out value) && index < left)
            {
                maxQueue.Dequeue();
            }
            result[j] = value;
            ++left;
            ++right;
            ++j;
        }

        return result;
    }
}
