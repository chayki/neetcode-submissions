public class PrefixTree {
    private Node root;
    
    public PrefixTree() {
        root = new Node('#');
    }
    
    public void Insert(string word) {
        if (string.IsNullOrEmpty(word)) return;
        int n = word.Length;
        var currNode = root;
        for(int i = 0; i < n; ++i)
        {
            int charIndex = word[i]-'a';
            if (currNode.Children[charIndex] == null) currNode.Children[charIndex] = new Node(word[i]);
            currNode = currNode.Children[charIndex];
        }

        currNode.IsEndOfWord = true;
    }
    
    public bool Search(string word) {
        if (string.IsNullOrEmpty(word)) return false;
        var currNode = root;
        for (int i = 0; i < word.Length; ++i)
        {
            int charIndex = word[i]-'a';
            if (currNode.Children[charIndex] == null) return false;
            currNode = currNode.Children[charIndex];
        }

        return currNode.IsEndOfWord;
    }
    
    public bool StartsWith(string prefix) {
        if (string.IsNullOrEmpty(prefix)) return false;
        var currNode = root;
        for (int i = 0; i < prefix.Length; ++i)
        {
            int charIndex = prefix[i]-'a';
            if (currNode.Children[charIndex] == null) return false;
            currNode = currNode.Children[charIndex];
        }
        return true;
    }
}

public class Node
{
    public char Value {get; private set;}

    public Node[] Children {get; private set;}

    public bool IsEndOfWord {get; set;}
    
    public Node(char c, bool isEndOfWord = false)
    {
        this.Value = c;
        this.IsEndOfWord = isEndOfWord;
        this.Children = new Node[26];
    }

}

// I will create a Trie datastructure with a custom defined type Node housing the character, 
// a boolean flag indicating whether its an end of word
// and references to children nodes
