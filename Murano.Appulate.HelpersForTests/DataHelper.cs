using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Murano.Appulate.HelpersForTests
{
    public static class DataHelper
    {
        public static List<string> GetAuthData(string pathToFile)
        {
            List<string> res;
            if (!File.Exists(pathToFile))
            {
                throw new NullReferenceException("File isn`t found.");
            }
            using (var fr = File.OpenRead(pathToFile))
            {
                using (var streamReader = new StreamReader(fr, Encoding.UTF8, true))
                {
                    string line;
                    List<string> lines = new List<string>();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    if (lines.Count != 2)
                    {
                        throw new Exception("File contains unnecessary data");
                    }
                    res = lines;
                }
            }
            return res;
        }
    }
}
