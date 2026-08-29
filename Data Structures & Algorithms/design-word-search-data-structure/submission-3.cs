public class WordDictionary {
    private Dictionary<int, List<Node>> levelMap;
    private Node root;

    public WordDictionary() {
        levelMap = new Dictionary<int, List<Node>>();
        root = new Node('#');
    }
    
    public void AddWord(string word) {
        // I will iterate through each character of the word and check if the character is already part of the children and proceed to next character if yes. Otherwise, I will add a new node for this character to the trie and to the levelMap mapping level to the nodes.

        var currNode = root;
        for (int i = 0; i < word.Length; ++i)
        {
            if (!currNode.Children.ContainsKey(word[i])) 
            {
                var childNode = new Node(word[i]);
                currNode.Children.Add(word[i], childNode);
            }
            currNode = currNode.Children[word[i]];
        }
        currNode.IsEndOfWord = true;
    }
    
    public bool Search(string word) {
        return SearchDFS(word, 0, root);
    }

    // This method will be searching all possible paths using DFS
    // if the character pointed by wordIndex is '.', I will iterate through all the nodes at the level and launcha a DFS for each n ode
    // if the character pointed by wordIndex is not '.', I will prune the DFS if the character is not matching with the node.
    // Base case will be reached when the DFS reached last character and its a . or equal to the node
    // state: wordIndex, level of the prefixTree, 
    public bool SearchDFS(string word, int wordIndex, Node node)
    {
        if (wordIndex == word.Length) return node.IsEndOfWord;
        if (node == null) return false;
        if (string.IsNullOrEmpty(word)) return node.IsEndOfWord;
        //if (wordIndex == word.Length-1) return node.Value == '.' &&|| node.Children.ContainsKey(word[wordIndex]);

        if (word[wordIndex] == '.')
        {
            foreach (var childNode in node.Children.Values)
            {
                if(SearchDFS(word, wordIndex+1, childNode)) return true;
            }
        }
        else
        {
            if (node.Children.ContainsKey(word[wordIndex]))
            {
                if(SearchDFS(word, wordIndex+1, node.Children[word[wordIndex]])) return true;
            }
        }
        return false;
        
    }
}

public class Node
{
    public bool IsEndOfWord {get; set;}
    public char Value {get; private set;}
    public Dictionary<char,Node> Children {get; private set;}
    public Node(char c)
    {
        this.Value = c;
        this.Children = new Dictionary<char,Node>();
    }
}

// I will build a trie data structure from the list of words in the input.
// Navigating trie is different from navigating a tree. Navigating a trie requires a shift from standard tree traversal: you do not look at where you currently stand, you look at direction available ahead of you.
// Space complexity:
// O(total number of nodes in the Trie)
// In the worst case no words share a prefix, so total space O(N*L) whree N - totalwords, L - average length of a word
// Time complexity:
// At the worst case a word will have two dots.
// O(L) - when to dots
// when there two dots, total branches to explore 26*26
// each branch can go as deep as length of the word at the worst case
// O(26^2*L) - since 26*26 is a constant, the time complexity scales linearly