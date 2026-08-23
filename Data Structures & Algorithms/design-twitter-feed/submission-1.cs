// 1. Create a dictionary of hashsets to store the followees
// 2. Follow/Unfollow methods keep the above list upto date
// 3. To determine the chronological ordering accompany each tweetid with monotonically
// increasing counter
// 4. For each user store list of tweets as a linked list with head pointing to the most recent tweet
// 5. Create max heap and hydrate with all the head nodes.
// 6. Keep poping the max heap and reinsert next node from the same queue as that of popped element
public class Twitter {
    private int counter;    
    private Dictionary<int,HashSet<int>> followeeMap = new();
    private Dictionary<int,Tweet> tweetMap = new();

    public Twitter() {
        this.counter = 0;
    }
    
    public void PostTweet(int userId, int tweetId) {
        if (!tweetMap.ContainsKey(userId)) tweetMap.Add(userId, null);
        var tweet = new Tweet(tweetId, counter);
        tweet.Next = tweetMap[userId];
        tweetMap[userId] = tweet;
        ++counter;
    }
    
    public List<int> GetNewsFeed(int userId) {
        // 10 most recent tweet ids
        // user + other posts
        // most recent to least recent
        
        // create a maxHeap of tweets ordered by counter
        var result = new List<int>();
        PriorityQueue<int, Tweet> maxHeap = new(Comparer<Tweet>.Create((x,y) => y.Counter.CompareTo(x.Counter)));

        // add user's latest tweet to the maxHeap
        if (tweetMap.TryGetValue(userId, out Tweet userTweet) && userTweet != null)
        {
            maxHeap.Enqueue(userTweet.TweetId, userTweet);
        }

        // add recent tweet of each follower to the maxHeap
        if (followeeMap.TryGetValue(userId, out HashSet<int> followees) && followees != null)
        {
            foreach (var followee in followeeMap[userId])
            {
                if (tweetMap.TryGetValue(followee, out Tweet followeeTweet) && followeeTweet != null)
                {
                    maxHeap.Enqueue(followeeTweet.TweetId, followeeTweet);
                }
            }
        }

        // maxHeap has all the recent tweets from all the followees including the follower
        int feedTweetCount = 0;
        while (feedTweetCount < 10 && maxHeap.TryDequeue(out int tweetId, out Tweet tweet))
        {
            result.Add(tweetId);
            ++feedTweetCount;
            var nextTweet = tweet.Next;
            if (nextTweet != null) maxHeap.Enqueue(nextTweet.TweetId, nextTweet);
        }

        return result;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!followeeMap.ContainsKey(followerId)) followeeMap.Add(followerId, new HashSet<int>());
        followeeMap[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (followeeMap.ContainsKey(followerId)) followeeMap[followerId].Remove(followeeId);   
    }
}

public class Tweet
{
    public int TweetId {get; private set;}
    public int Counter {get; private set;}
    public Tweet Next {get; set;}
    public Tweet(int tweetId, int counter)
    {
        this.TweetId = tweetId;
        this.Counter = counter;
    }
}
