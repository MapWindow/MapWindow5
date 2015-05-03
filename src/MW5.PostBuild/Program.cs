using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace MW5.PostBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateManifest();

            RemoveOcx();
        }

        private static void RemoveOcx()
        {
            File.Delete("mapwingis.ocx");
            File.Delete("plugins\\mapwingis.ocx");
        }

        private static void UpdateManifest()
        {
            const string path = "Native.MW5.Api.manifest";
            const string oldFilename = "name=\"MapWinGIS.ocx\"";
            const string newFilename = "name=\"MapWinGis\\MapWinGIS.ocx\"";

            var s = File.ReadAllText(path);
            if (!string.IsNullOrWhiteSpace(s))
            {
                File.WriteAllText(path, s.Replace(oldFilename, newFilename));
                Console.WriteLine("Text was replaced");
            }
        }
    }
}
