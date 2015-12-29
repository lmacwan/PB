using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurityBridge.Umbraco
{
    public class Utility
    {
        public const string NEWLINE = "<<nl>>";

        public static int GetSpanEquivalent(string span)
        {
            var cols = span.Contains("Less")
                         ? 3
                         : span.Contains("More")
                             ? 9
                             : span.Contains("Full")
                                 ? 12
                                 : 6;
            return cols;
        }

        public static string GetOlHtml(string text, List<string> namesList)
        {
            var value = string.Empty;
            if (namesList == null)
            {
                namesList = new List<string>();
            }
            List<List<string>> olList = GetOlList(text);
            int index = 0;
            olList.ForEach(ol =>
            {
                var listName = (namesList.Count - 1) >= index ? namesList.ElementAt(index++) : string.Empty;
                ol.ForEach(li =>
                {
                    li = string.Format("<li>{0}</li>", li);
                });
                string list = string.Format("<ol>{0}{1}</ol>", listName, string.Join("", ol));
                value += list;
            });
            return value;
        }

        private static List<List<string>> GetOlList(string text)
        {
            List<List<string>> value = new List<List<string>>();
            var pArray = GetPList(text);
            pArray.ForEach(i =>
            {
                List<string> oList = i.Split(new string[] { NEWLINE }, StringSplitOptions.RemoveEmptyEntries).ToList();
                value.Add(oList);
            });
            return value;
        }

        public static string GetPHtml(string text)
        {
            var pArray = GetPList(text);
            if (pArray.Any())
            {
                pArray.ForEach(i =>
                {
                    i = "</p><p>" + i;
                });
                var firstP = pArray.First();
                firstP = firstP.Replace("</p>", "");
                var lastP = pArray.Last();
                lastP = lastP.Replace("<p>", "");
                return string.Join("", pArray);
            }
            return text;
        }

        private static List<string> GetPList(string text)
        {
            var pArray = text.Split(new string[] { "<<nl>>" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return pArray.ToList();
        }
    }
}