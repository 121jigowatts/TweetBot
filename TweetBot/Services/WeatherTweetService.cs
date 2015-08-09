using Codeplex.Data;
using System;
using System.Net;
using System.Text;

namespace TweetBot.Services
{
    public class WeatherTweetService
    {
        const string NO_VALUE = "---";
        public string GetWeatherText() 
        {

            var req = WebRequest.Create("http://weather.livedoor.com/forecast/webservice/json/v1?city=130010");

            using (var res = req.GetResponse())
            using (var s = res.GetResponseStream())
            {
                dynamic json = DynamicJson.Parse(s);

                //天気(今日)
                dynamic today = json.forecasts[0];

                string dateLabel = today.dateLabel;
                string date = today.date;
                string telop = today.telop;
                Console.WriteLine(string.Format("{0} ({1}) {2}",dateLabel,date,telop));
                
                
                var sbTempMax = new StringBuilder();                
                dynamic todayTemperatureMax = today.temperature.max;
                if (todayTemperatureMax != null)
                {
                    sbTempMax.AppendFormat("{0}℃", todayTemperatureMax.celsius);
                }
                else
                {
                    sbTempMax.Append(NO_VALUE);
                }
                Console.WriteLine("最高気温 {0}",sbTempMax.ToString());

                var sbTempMin = new StringBuilder();
                dynamic todayTemperatureMin = today.temperature.min;
                if (todayTemperatureMin != null)
                {
                    sbTempMin.AppendFormat("{0}℃", todayTemperatureMin.celsius);
                }
                else
                {
                    sbTempMin.Append(NO_VALUE);
                }
                Console.WriteLine("最低気温 {0}",sbTempMin.ToString());

                return string.Format("{0} {1}  最高気温 {2} 最低気温 {3} #自動",date,telop,sbTempMax.ToString(),sbTempMin.ToString());
            }
            
        }

    }
}
