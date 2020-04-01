using System;
using System.Collections.Generic;

namespace Problems.SystemDesign
{
    /**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */

    //https://leetcode.com/problems/design-twitter/
    public class Tweet:IComparable<Tweet>
    {
        public readonly int Id;
        public readonly DateTime TimeStamp;

        public Tweet(int id)
        {
            Id = id;
            TimeStamp = DateTime.Now;
        }

        public int CompareTo(Tweet other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return TimeStamp.CompareTo(other.TimeStamp);
        }
    }

    public class User
    {
        public readonly int Id;
        private HashSet<int> _followeeIds;
        private List<Tweet> _tweets;

        public User(int id)
        {
            Id = id;
            _followeeIds = new HashSet<int>();
            _tweets = new List<Tweet>();
        }

        public void PostTweet(int tweetId)
        {
            _tweets.Add(new Tweet(tweetId));
        }

        public void Follow(int followeeId)
        {
            if(followeeId == Id) return;
            _followeeIds.Add(followeeId);
        }

        public void Unfollow(int followeeId)
        {
            _followeeIds.Remove(followeeId);
        }

        public IEnumerable<int> GetFollowees()
        {
            return _followeeIds;
        }

        public IEnumerable<Tweet> GetRecentTweets(int n)
        {
            for (var i = _tweets.Count - 1; i >= _tweets.Count - n && i >=0 ; i--)
                yield return _tweets[i];
        }
    }

    public class Twitter
    {
        /** Initialize your data structure here. */
        private Dictionary<int, User> _users;
        public Twitter() {
            _users = new Dictionary<int, User>();
        }
    
        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (! _users.ContainsKey(userId)) _users.Add(userId, new User(userId));
            
            _users[userId].PostTweet(tweetId);
        }
    
        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId, int n=10)
        {
            if (!_users.ContainsKey(userId)) return new List<int>();
            var allTweets = new List<Tweet>(_users[userId].GetRecentTweets(n));
            foreach (var followee in _users[userId].GetFollowees())
            {
                allTweets.AddRange(_users[followee].GetRecentTweets(n));
            }
            allTweets.Sort();
            
            var recentTweets = new List<int>();
            for (var i = allTweets.Count - 1; i >= 0 && i >= allTweets.Count - n; i--)
            {
                recentTweets.Add(allTweets[i].Id);
            }

            return recentTweets;
        }
    
        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId) {
            if (! _users.ContainsKey(followerId)) _users.Add(followerId, new User(followerId));
            if (! _users.ContainsKey(followeeId)) _users.Add(followeeId, new User(followeeId));

            _users[followerId].Follow(followeeId);
        }
    
        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId) {
            if (! _users.ContainsKey(followerId)) return;
            
            _users[followerId].Unfollow(followeeId);
        }
    }
}