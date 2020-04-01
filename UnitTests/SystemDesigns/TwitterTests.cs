using Problems.SystemDesign;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class TwitterTests
    {
        [Fact]
        public void Tweetings()
        {
            var twitter = new Twitter();
            twitter.Follow(2, 1);
            twitter.Follow(3, 1);
            twitter.Follow(4, 1);
            
            twitter.PostTweet(1, 1);
            twitter.PostTweet(2, 2);
            twitter.PostTweet(3, 3);
            twitter.PostTweet(4, 4);
            
            twitter.Follow(5,2);
            twitter.Follow(5,3);
            twitter.Follow(5,4);
            twitter.Follow(5,1);


            Assert.Equal(new[]{4,3,2,1}, twitter.GetNewsFeed(5));
            
            twitter.Unfollow(5,1);
            
            Assert.Equal(new[]{4,3,2}, twitter.GetNewsFeed(5));
        }
    }
    
}