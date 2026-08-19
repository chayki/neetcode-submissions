public class LFUCache {
    Dictionary<int, LinkedListNode<CacheItem>> dict = new();
    Dictionary<int, LinkedList<CacheItem>> freqLists = new();
    private int capacity;
    private int minFreq = 0;
    
    public LFUCache(int capacity) {
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (capacity == 0 || !dict.ContainsKey(key)) return -1;
        var node = dict[key];
        UpdateFrequency(node);
        var cacheItem = node.Value;
        return cacheItem.Value;
    }
    
    public void Put(int key, int value) {
        if (capacity == 0) return;
        if (dict.ContainsKey(key))
        {
            var node = dict[key];
            var cacheItem = node.Value;
            cacheItem.Value = value;
            UpdateFrequency(node);
        }
        else
        {
            if (dict.Keys.Count == this.capacity) EvictLeastFreqRecentItem();
            minFreq = 1;
            if (!freqLists.ContainsKey(minFreq)) freqLists.Add(minFreq, new LinkedList<CacheItem>());
            freqLists[1].AddFirst(new CacheItem(key,value));
            dict.Add(key, freqLists[1].First);
        }
    }

    private void UpdateFrequency(LinkedListNode<CacheItem> node)
    {
        var cacheItem = node.Value;
        var currFreq = cacheItem.Freq;
        var newFreq = currFreq+1;
        freqLists[currFreq].Remove(node);
        if (freqLists[currFreq].Count == 0)
        {
            freqLists.Remove(currFreq);
            if (currFreq == minFreq) ++minFreq;
        }

        cacheItem.Freq = newFreq;
        if (!freqLists.ContainsKey(newFreq)) freqLists.Add(newFreq, new LinkedList<CacheItem>());
        dict[cacheItem.Key] = freqLists[newFreq].AddFirst(cacheItem);
    }

    private void EvictLeastFreqRecentItem()
    {
        var node = freqLists[minFreq].Last;
        dict.Remove(node.Value.Key);
        freqLists[minFreq].RemoveLast();
        if (freqLists[minFreq].Count == 0) freqLists.Remove(minFreq);
    }
}

public class CacheItem
{
    public int Key {get; init;}
    public int Value {get; set;}
    public int Freq {get; set;}

    public CacheItem(int key, int value)
    {
        this.Key = key;
        this.Value = value;
        this.Freq = 1;
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */