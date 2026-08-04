public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (k == 1) return nums;
        Window window = new Window(nums, 0, k-2);
        int[] result = new int[nums.Length-k+1];
        int i = 0;
        for (int right = k-1; right < nums.Length; ++right)
        {
            window.AddToWindow(right);
            result[i] = window.GetMax();
            window.RemoveFromWindow(i);
            ++i;
        }
        return result;
    }

    public class Window
    {
        LinkedList<int> deque = new LinkedList<int>();
        int[] nums;
        public Window(int[] nums, int start, int end)
        {
            this.nums = nums;
            for (int i = start; i <= end; ++i)
            {
                this.AddToWindow(i);
            }
        }

        public void AddToWindow(int index)
        {
             while (deque.Count > 0 && deque.Last.Value < nums[index])
             {
                deque.RemoveLast();
             }
             deque.AddLast(nums[index]);
        }

        public void RemoveFromWindow(int index)
        {
            if (deque.First.Value == nums[index]) // element to remove is max of the window
            {
                deque.RemoveFirst();
            }
        }

        public int GetMax()
        {
            return deque.Count > 0 ? deque.First.Value : int.MinValue;
        }
    }
}