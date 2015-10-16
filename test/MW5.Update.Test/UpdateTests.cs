// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateTests.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Test the update service
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using MW5.Shared;

namespace MW5.Update.Test
{

    /// <summary>
    ///     Test the update service
    /// </summary>
    [TestClass]
    public class UpdateTests
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Compare the file versions.
        /// </summary>
        [TestMethod]
        public void CompareVersions()
        {
            var currentAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Debug.WriteLine("currentAssemblyVersion: " + currentAssemblyVersion);

            // parse json string:
            var jsonVersion = System.Version.Parse("1.0.1.0");
            Debug.WriteLine("jsonVersion: " + jsonVersion);

            // Compare
            var result = jsonVersion.CompareTo(currentAssemblyVersion);

            switch (result)
            {
                case -1:
                    Debug.WriteLine("json version is older");
                    break;
                case 0:
                    Debug.WriteLine("versions are equal");
                    break;
                case 1:
                    Debug.WriteLine("A new version is available");
                    break;
            }
        }

        /// <summary>
        ///     Deserialize the json string back to the InstallerInfo struct
        /// </summary>
        [TestMethod]
        public void DeserializeJson()
        {
            const string Json =
                "{\"Stable\":{\"Versionnumber\":\"1.0.1.0\",\"Description\":\"New stable version with some cool new features\"},\"Beta\":{\"Versionnumber\":\"1.0.0.9\",\"Description\":\"Bugfixes and small enhancements\"}}";
            var availableInstallers = JsonConvert.DeserializeObject<Dictionary<string, UpdaterHelper.InstallerInfo>>(Json);
            Assert.AreEqual("1.0.1.0", availableInstallers["Stable"].Versionnumber);
            Assert.AreEqual("1.0.0.9", availableInstallers["Beta"].Versionnumber);
        }

        /// <summary>
        ///     Download the installer.
        /// </summary>
        [TestMethod]
        public void DownloadInstaller()
        {
            // TODO: Get url from json file:
            const string Url = @"https://mapwingis.codeplex.com/SourceControl/latest#src/MapWinGIS.h";

            // Create the webrequest:
            var webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.Method = "GET";

            // Execute the request:
            var webResponse = (HttpWebResponse)webRequest.GetResponse();

            // Save the response in a temporary file
            var filename = Path.ChangeExtension(Path.GetTempFileName(), ".exe");
            using (var output = File.OpenWrite(filename))
            {
                using (var input = webResponse.GetResponseStream())
                {
                    if (input == null)
                    {
                        return;
                    }

                    input.CopyTo(output);
                    Debug.WriteLine("Downloaded file saved as " + filename);
                }
            }
        }

        /// <summary>
        ///     Read the jsonfile from GIT which holds the latest version numbers
        /// </summary>
        [TestMethod]
        public void ReadJsonfile()
        {
            // The file to get:
            const string Url = @"https://mapwindow5.codeplex.com/SourceControl/latest#src/SolutionItems/mw5-update.json";

            // Create the webrequest:
            var webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.Method = "GET";

            // Execute the request:
            var webResponse = (HttpWebResponse)webRequest.GetResponse();

            // Deserialise to local data structure
            using (var stream = webResponse.GetResponseStream())
            {
                if (stream == null)
                {
                    Debug.WriteLine("Could not read " + Url);
                    return;
                }

                string content = null;
                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                    var serializer = new JsonSerializer();
                    var availableInstallers =
                        (Dictionary<string, UpdaterHelper.InstallerInfo>)
                        serializer.Deserialize(reader, typeof(Dictionary<string, UpdaterHelper.InstallerInfo>));
                    Assert.AreEqual("1.0.1.0", availableInstallers["Stable"].Versionnumber);
                    Assert.AreEqual("1.0.0.9", availableInstallers["Beta"].Versionnumber);
                    Debug.WriteLine("The online JSON file was correctly read.");
                }
            }
        }

        /// <summary>
        ///     Get  the version number of MapWindow 5
        /// </summary>
        [TestMethod]
        public void GetVersionNumber()
        {
            // Use MW5 assembly not this test assembly:
            Debug.WriteLine(typeof(UpdateTests).Assembly.GetName().Version);
        }

        /// <summary>
        ///     Make the jsonfile to hold the latest version numbers
        /// </summary>
        [TestMethod]
        public void MakeJsonfile()
        {
            var installers = new Dictionary<string, UpdaterHelper.InstallerInfo>
                                 {
                                     {
                                         "Stable-x64", 
                                         new UpdaterHelper.InstallerInfo
                                             {
                                                 Versionnumber = new Version(5,0,0), 
                                                 Description = "New stable version with some cool new features",
                                                 DownloadUrl = "https://mapwindow5.codeplex.com/downloads/get/1492837",
                                                 Cpu = "x64"
                                             }
                                     }, 
                                     {
                                         "Beta-x64", 
                                         new UpdaterHelper.InstallerInfo
                                             {
                                                 Versionnumber = new Version(5,0,1),
                                                 Description = "Bugfixes and small enhancements",
                                                 DownloadUrl = "https://mapwindow5.codeplex.com/downloads/get/1492837",
                                                 Cpu = "x64"
                                             }
                                     }
                                 };

            var json = JsonConvert.SerializeObject(installers);
            Debug.WriteLine(json);
            Assert.IsTrue(json.Contains("{\"Stable"));

            // Write string to a file
            File.WriteAllText(@"d:\mw5-update.json", json);
            Assert.IsTrue(File.Exists(@"d:\mw5-update.json"));
            Debug.WriteLine("JSON file is written");
        }

        #endregion
    }
}