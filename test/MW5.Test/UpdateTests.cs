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
using System.Reflection;
using MW5.Helpers;
using MW5.Shared;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MW5.Test
{
    /// <summary>
    ///     Test the update service
    /// </summary>
    [TestFixture]
    public class UpdateTests
    {
        /// <summary>
        ///     Compare the file versions.
        /// </summary>
        [Test]
        public void CompareVersions()
        {
            var currentAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Debug.WriteLine("currentAssemblyVersion: " + currentAssemblyVersion);

            // parse json string:
            var jsonVersion = Version.Parse("1.0.1.0");
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
        ///     Download the installer.
        /// </summary>
        [Test]
        public async void DownloadInstaller()
        {
            const string Url = @"http://www.mapwindow.org/dokuwiki-2011-05-25a.tgz";
            var filename = Path.GetTempFileName();
            Debug.WriteLine(filename);
            await DownloadHelper.DownloadBinaryAsync(Url, filename);
            var fileInfo = new FileInfo(filename);
            Debug.WriteLine("File size: " + fileInfo.Length);
            Assert.IsTrue(fileInfo.Length > 0);
            Debug.WriteLine("Saved as " + filename);
        }

        /// <summary>
        ///     Get  the version number of MapWindow 5
        /// </summary>
        [Test]
        public void GetVersionNumber()
        {
            // Use MW5 assembly not this test assembly:
            Debug.WriteLine(typeof(UpdateTests).Assembly.GetName().Version);
        }

        /// <summary>
        ///     Make the jsonfile to hold the latest version numbers
        /// </summary>
        [Test]
        public void MakeJsonfile()
        {
            var installers = new Dictionary<string, UpdaterHelper.InstallerInfo>
                                 {
                                     {
                                         "Stable-x64",
                                         new UpdaterHelper.InstallerInfo
                                             {
                                                 Versionnumber = new Version(5, 0, 0, 0),
                                                 Description =
                                                     "New stable version with some cool new features",
                                                 DownloadUrl =
                                                     "http://download-codeplex.sec.s-msft.com/Download/Release?ProjectName=mapwindow5&DownloadId=1492837&FileTime=130885516303300000&Build=21031",
                                                 Name = "MapWindow-v5.0.1.0.exe",
                                                 Cpu = "x64"
                                             }
                                     },
                                     {
                                         "Beta-x64",
                                         new UpdaterHelper.InstallerInfo
                                             {
                                                 Versionnumber = new Version(5, 0, 1, 1),
                                                 Description = "Bugfixes and small enhancements",
                                                 DownloadUrl =
                                                     "http://download-codeplex.sec.s-msft.com/Download/Release?ProjectName=mapwindow5&DownloadId=1492837&FileTime=130885516303300000&Build=21031",
                                                 Name = "MapWindow-v5.0.1.1.exe",
                                                 Cpu = "x64"
                                             }
                                     },
                                     {
                                         "Stable-x86",
                                         new UpdaterHelper.InstallerInfo
                                             {
                                                 Versionnumber = new Version(5, 0, 0, 0),
                                                 Description =
                                                     "New stable version with some cool new features",
                                                 DownloadUrl =
                                                     "http://download-codeplex.sec.s-msft.com/Download/Release?ProjectName=mapwindow5&DownloadId=1492837&FileTime=130885516303300000&Build=21031",
                                                 Name = "MapWindow-v5.0.1.0.exe",
                                                 Cpu = "x86"
                                             }
                                     },
                                     {
                                         "Beta-x86",
                                         new UpdaterHelper.InstallerInfo
                                             {
                                                 Versionnumber = new Version(5, 0, 1, 1),
                                                 Description = "Bugfixes and small enhancements",
                                                 DownloadUrl =
                                                     "http://download-codeplex.sec.s-msft.com/Download/Release?ProjectName=mapwindow5&DownloadId=1492837&FileTime=130885516303300000&Build=21031",
                                                 Name = "MapWindow-v5.0.1.1.exe",
                                                 Cpu = "x86"
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

        /// <summary>
        ///     Read the jsonfile from GIT which holds the latest version numbers
        /// </summary>
        [Test]
        public async void ReadJsonfile()
        {
            var result = await DownloadHelper.DownloadSerializedJSONDataAsync<Dictionary<string, UpdaterHelper.InstallerInfo>>("http://www.mapwindow.org/mw5-update.json");
            Assert.AreEqual("New stable version with some cool new features", result["Stable-x64"].Description, "Could not read description");
        }
    }
}