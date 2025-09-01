using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace fantasy_statistics
{
    public class Program
    {
        static readonly HttpClient client = new HttpClient();
        
        public static void Main(string[] args)
        {
            dynamic data = Program.GetRawData();
            StringBuilder sb = Program.ReadData(data);
            File.WriteAllText($"statistics-{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.csv", sb.ToString(), Encoding.UTF8);

            Console.WriteLine("Great success!");
        }

        private static dynamic GetRawData()
        {
            string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
            string responseBody = client.GetStringAsync(url).Result;

            var response = JsonConvert.DeserializeObject<dynamic>(responseBody);      

            return response;   
        }

        private static StringBuilder ReadData(dynamic data)
        {
            StringBuilder sb = new StringBuilder();

            // Try to get the elements token from the dynamic object
            JToken elementsToken = null;
            try
            {
                // If data is already a JToken/JObject
                if (data is JToken)
                {
                    var j = (JToken)data;
                    elementsToken = j["elements"];
                }
                else
                {
                    // Fallback: attempt to access property dynamically
                    elementsToken = JToken.FromObject(data)["elements"];
                }
            }
            catch
            {
                // If anything goes wrong, try dynamic access
                try { elementsToken = data.elements; } catch { elementsToken = null; }
            }

            if (elementsToken == null)
            {
                return sb; // no elements found
            }

            JArray elements = elementsToken as JArray;
            if (elements == null)
            {
                try { elements = JArray.FromObject(elementsToken); }
                catch { return sb; }
            }

            // Collect all unique property names (preserve order discovered)
            var headers = new List<string>();
            foreach (var child in elements.Children<JObject>())
            {
                foreach (var prop in child.Properties())
                {
                    if (!headers.Contains(prop.Name)) headers.Add(prop.Name);
                }
            }

            // Sort headers alphabetically (case-insensitive)
            headers.Sort(StringComparer.OrdinalIgnoreCase);

            // Write header
            sb.AppendLine(string.Join(",", headers));

            // Write each element row
            foreach (var child in elements.Children<JObject>())
            {
                var row = new List<string>();
                foreach (var h in headers)
                {
                    JToken valToken;
                    string val = string.Empty;
                    if (child.TryGetValue(h, out valToken) && valToken != null && valToken.Type != JTokenType.Null)
                    {
                        val = valToken.Type == JTokenType.String ? valToken.ToString() : valToken.ToString(Newtonsoft.Json.Formatting.None);
                    }

                    // If header == "team", attempt to convert numeric team id to Team enum name
                    if (h == "team" && valToken != null)
                    {
                        try
                        {
                            int teamId = 0;
                            if (valToken.Type == JTokenType.Integer)
                                teamId = valToken.Value<int>();
                            else
                                int.TryParse(valToken.ToString(), out teamId);

                            if (Enum.IsDefined(typeof(Team), teamId))
                                val = ((Team)teamId).ToString();
                        }
                        catch
                        {
                            // leave val as-is on error
                        }
                    }

                    // If header == "element_type", attempt to convert numeric id to Position enum name
                    if (h == "element_type" && valToken != null)
                    {
                        try
                        {
                            int posId = 0;
                            if (valToken.Type == JTokenType.Integer)
                                posId = valToken.Value<int>();
                            else
                                int.TryParse(valToken.ToString(), out posId);

                            if (Enum.IsDefined(typeof(Position), posId))
                                val = ((Position)posId).ToString();
                        }
                        catch
                        {
                            // leave val as-is on error
                        }
                    }

                    // Escape according to CSV rules
                    if (val.Contains("\"") )
                    {
                        val = val.Replace("\"", "\"\"");
                    }
                    if (val.Contains(",") || val.Contains("\"") || val.Contains("\n") || val.Contains("\r"))
                    {
                        val = "\"" + val + "\"";
                    }

                    row.Add(val);
                }

                sb.AppendLine(string.Join(",", row));
            }

            return sb;
        }
    }
}