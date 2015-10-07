// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WelcomeViewModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the WelcomeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MW5.Views
{
    public class WelcomeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomeViewModel"/> class.
        /// </summary>
        /// <param name="recentProjects">The recent projects, to show on the welcome screen</param>
        public WelcomeViewModel(IEnumerable<string> recentProjects)
        {
            // PM: Check if the recent project still exist:
            RecentProjects = new List<string>();
            foreach (var recentProject in recentProjects.Where(File.Exists))
            {
                RecentProjects.Add(recentProject);
            }

            // RecentProjects = recentProjects;
        }

        public List<string> RecentProjects { get; private set; }
    }
}