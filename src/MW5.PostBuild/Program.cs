// -------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MW5.PostBuild
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UpdateManifest();

            RemoveOcx();
        }

        private static void RemoveOcx()
        {
            try
            {
                File.Delete("mapwingis.ocx");
                File.Delete("plugins\\mapwingis.ocx");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to remove mapwingis.ocx: " + ex.Message);
            }
        }

        private static void UpdateManifest()
        {
            const string path = "Native.MW5.Api.manifest";
            const string oldFilename = "name=\"MapWinGIS.ocx\"";
            const string newFilename = "name=\"MapWinGis\\MapWinGIS.ocx\"";

            try
            {
                var s = File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(s))
                {
                    var regex = new Regex(oldFilename, RegexOptions.IgnoreCase);
                    var newText = regex.Replace(s, newFilename);

                    File.WriteAllText(path, newText);

                    Console.WriteLine("Text was replaced");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update manifest: " + ex.Message);
            }
        }
    }
}