// The challenge here is to support O(1) get min operation
// we can't maintain a min variable because when an element popped is min we need to update it with next min in the remaining stack
// So similar to stack of elements , we need to maintain stack of minimums as well.
// when the top element is popped from the stack, the top element of min stack will also be popped
// when an element is pushed on to the stack, minimum of new head of stack and the current head of minstack will be pushed to the min stack
// Time complexity - O(1)
// Space complexity - O(n)
public class MinStack {

    private ListNode stackHead = null;
    private ListNode minStackHead = null;

    public MinStack() {
        
    }
    
    public void Push(int val) {
        ListNode stackNode = new ListNode(val);
        ListNode minStackNode = new ListNode(Math.Min(minStackHead?.Val ?? int.MaxValue, val));
        stackNode.Next = stackHead;
        stackHead = stackNode;
        minStackNode.Next = minStackHead;
        minStackHead = minStackNode;
    }
    
    public void Pop() {
        stackHead = stackHead?.Next;
        minStackHead = minStackHead?.Next;
    }
    
    public int Top() {
        return stackHead.Val;
    }
    
    public int GetMin() {
        return minStackHead.Val;
    }
}

public class ListNode
{
    public int Val {get; init;}

    public ListNode Next {get; set;}

    public ListNode(int val)
    {
        this.Val = val;
    }
}
