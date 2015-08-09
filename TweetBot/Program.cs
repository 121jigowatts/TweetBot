using System;
using System.IO;
using System.Text;
using TweetBot.Services;

namespace TweetBot
{
    class Program
    {
        static string GetFilePath()
        {
            var currentDir = System.IO.Directory.GetCurrentDirectory();
            return System.IO.Path.Combine(currentDir, "tb.log");            
        }

        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter(GetFilePath(), true, Encoding.GetEncoding("Shift-JIS")))
            using (TextWriter syncWriter = TextWriter.Synchronized(sw))
            {
                System.Diagnostics.Debug.WriteLine("File path : {0}", GetFilePath());
                try
                {
                    if (args.Length != 4)
                    {
                        syncWriter.WriteLine("{0} [Error] args.Length:{1}",DateTime.Now.ToString(), args.Length.ToString());
                        return;
                    }

                    var APIKey = args[0];
                    var APISecret = args[1];
                    var AccessToken = args[2];
                    var AccessTokenSecret = args[3];
                    var tokens = CoreTweet.Tokens.Create(APIKey, APISecret, AccessToken, AccessTokenSecret);
                    syncWriter.WriteLine("{0} [Normal]",DateTime.Now.ToString());

                    var service = new WeatherTweetService();
                    var text = service.GetWeatherText();
                    System.Diagnostics.Debug.WriteLine(text);
                    tokens.Statuses.Update(status => text);
                }
                catch (Exception ex)
                {
                    syncWriter.WriteLine("{0} [Error] Message:{1}",DateTime.Now.ToString(), ex.Message);

                }
            }

        }
    }
}
