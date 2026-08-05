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
