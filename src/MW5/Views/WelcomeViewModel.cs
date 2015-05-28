using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Views
{
    public class WelcomeViewModel
    {
        public WelcomeViewModel(List<string> recentProjects)
        {
            RecentProjects = recentProjects;
        }

        public List<string> RecentProjects { get; private set; }
    }
}
