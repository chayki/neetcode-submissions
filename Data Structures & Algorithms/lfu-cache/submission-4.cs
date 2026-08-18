public class LFUCache {
    Dictionary<int, (LinkedListNode<Node> node, int freq)> dict = new();
    Dictionary<int, LinkedList<Node>> freqMap = new();
    private int capacity;
    private int minFreq = 0;
    public LFUCache(int capacity) {
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!dict.ContainsKey(key)) return -1;
        UpdateFrequency(dict[key].node, dict[key].freq);
        return dict[key].node.Value.Value;
    }
    
    public void Put(int key, int value) {
        if (!dict.ContainsKey(key)) // new key
        {
            if (dict.Keys.Count == capacity) EvictLeastFreqRecentlyUsed();
            var node = new Node(key, value);
            if (!freqMap.ContainsKey(1)) freqMap[1] = new LinkedList<Node>();
            freqMap[1].AddFirst(node);
            dict.Add(key, (freqMap[1].First, 1));
            minFreq = 1;
        }
        else
        {
            (LinkedListNode<Node> node, int freq) = dict[key];
            node.Value.Value = value;
             UpdateFrequency(node, freq);
        }
    }

    private void EvictLeastFreqRecentlyUsed()
    {
        var node = freqMap[minFreq].Last;
        if(freqMap[minFreq].Count > 1) 
            freqMap[minFreq].RemoveLast();
        else
        {
            freqMap[minFreq].Remove(node);
            freqMap.Remove(minFreq);
        }
            
        dict.Remove(node.Value.Key);
    }

    private void UpdateFrequency(LinkedListNode<Node> node, int currFreq)
    {
        if (freqMap[currFreq].Count == 1)
        {
            freqMap[currFreq].Remove(node);
            freqMap.Remove(currFreq);
            if (minFreq == currFreq) minFreq++;
        }
        else
        {
            freqMap[currFreq].Remove(node);
        }

        int newFreq = currFreq+1;
        if (!freqMap.ContainsKey(newFreq)) freqMap.Add(newFreq, new LinkedList<Node>());
        freqMap[newFreq].AddFirst(node);
        dict[node.Value.Key] = (node, newFreq);
    }
}

public class Node
{
    public int Key {get; init;}
    public int Value {get; set;}
    public Node(int key, int val)
    {
        this.Key = key;
        this.Value = val;
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */