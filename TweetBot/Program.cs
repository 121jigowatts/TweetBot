using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var APIKey = "";
            var APISecret = "";
            var AccessToken = "";
            var AccessTokenSecret = "";
            var tokens = CoreTweet.Tokens.Create(APIKey, APISecret, AccessToken, AccessTokenSecret);

            var text = "";
            tokens.Statuses.Update(new { status = text });
        }
    }
}
