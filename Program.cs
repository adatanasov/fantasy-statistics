using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace fantasy_statistics
{
    public class Program
    {
        static readonly HttpClient client = new HttpClient();
        
        public static void Main(string[] args)
        {
            Response data = Program.GetData();
            StringBuilder sb = Program.ReadData(data);
            File.WriteAllText($"statistics-{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.csv", sb.ToString(), Encoding.UTF8);

            Console.WriteLine("Great success!");
        }

        private static Response GetData()
        {
            string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
            string responseBody = client.GetStringAsync(url).Result;

            var response = JsonConvert.DeserializeObject<Response>(responseBody);      

            return response;   
        }

        private static StringBuilder ReadData(Response data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Team,Position,Name,MinutesPlayed,Form,TotalPoints,Price,PointsPerCost,Bonus,GoalsScored,Assists,GoalsConceded,CleanSheets,Saves,PenaltiesSaved,PointsPerGame,PenaltiesOrder,PenaltiesMissed,YellowCards,RedCards");

            int length = data.Players.Length;
            for (int i = 0; i < length; i++)
            {
                sb.Append($"{data.Players[i].Team.ToString()}");
                sb.Append($",{data.Players[i].Position.ToString()}");
                sb.Append($",{data.Players[i].FirstName} {data.Players[i].SecondName}");
                sb.Append($",{data.Players[i].MinutesPlayed}");
                sb.Append($",{data.Players[i].Form}");
                sb.Append($",{data.Players[i].TotalPoints}");
                sb.Append($",{data.Players[i].NowCost/10}");
                sb.Append($",{data.Players[i].TotalPoints/(data.Players[i].NowCost/10):0.00}");
                sb.Append($",{data.Players[i].Bonus}");
                sb.Append($",{data.Players[i].GoalsScored}");
                sb.Append($",{data.Players[i].Assists}");
                sb.Append($",{data.Players[i].GoalsConceded}");
                sb.Append($",{data.Players[i].CleanSheets}");
                sb.Append($",{data.Players[i].Saves}");
                sb.Append($",{data.Players[i].PenaltiesSaved}");
                sb.Append($",{data.Players[i].PointsPerGame}");
                sb.Append($",{data.Players[i].PenaltiesOrder}");
                sb.Append($",{data.Players[i].PenaltiesMissed}");
                sb.Append($",{data.Players[i].YellowCards}");
                sb.AppendLine($",{data.Players[i].RedCards}");
            }

            return sb;
        }
    }
}