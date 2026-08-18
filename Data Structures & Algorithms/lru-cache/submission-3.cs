public class LRUCache {
    LinkedList<Node> lruList = new LinkedList<Node>();
    Dictionary<int,LinkedListNode<Node>> dict = new();
    private int capacity;
    public LRUCache(int capacity) {
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        // return if the key is not present
        if (!dict.ContainsKey(key)) return -1;
        
        // get the node and return is value;
        LinkedListNode<Node> node = dict[key];
        
        // move the node to first
        this.MoveNodeToFirst(node);
        return node.Value.Value;
    }
    
    public void Put(int key, int value) {
        // add the key if does not exist and add the node to the front of DLL
        if (!dict.ContainsKey(key))
        {
            var node = this.lruList.AddFirst(new Node(key, value));
            dict[key] = node;
            if (dict.Keys.Count > this.capacity) RemoveLRU();
        }
        else
        {
            var node = dict[key];
            node.Value.Value = value;
            MoveNodeToFirst(node);
        }
        // if the key already exsists, update the node value and move to the front of the DLL
    }

    private void MoveNodeToFirst(LinkedListNode<Node> node)
    {
        this.lruList.Remove(node);
        this.lruList.AddFirst(node);
    }

    private void RemoveLRU()
    {
        var lruNode = this.lruList.Last;
        this.lruList.RemoveLast();
        dict.Remove(lruNode.Value.Key);
    }
}

public class Node
{
    public int Key {get; init;}
    public int Value {get; set;}
    public Node Prev {get; set;} = null;
    public Node Next {get; set;} = null;

    public Node (int key, int val)
    {
        this.Key = key;
        this.Value = val;
    }
}
