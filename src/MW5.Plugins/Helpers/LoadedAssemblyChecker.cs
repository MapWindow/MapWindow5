using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Helpers
{
    /// <summary>
    /// Check if assemblies are loaded multiple times into a application domain. This is
    /// in most cases an error which is not so easy to find.
    /// </summary>
    /// <remarks>
    /// Borrows from here: http://geekswithblogs.net/akraus1/articles/74319.aspx
    /// </remarks>
    public class LoadedAssemblyChecker
    {
        private class AssemblyInfo
        {
            readonly string _myName;
            readonly string _myLocation;
            
            public string Name
            {
                get { return _myName; }
            }
 
            public string Location
            {
                get { return _myLocation; }
            }
 
            public AssemblyInfo(string name, string location)
            {
                _myName = name;
                _myLocation = location;
            }
        }
 
        /// <summary>
        /// Check the current Application domain if there are assemblies loaded multiple times.
        /// </summary>
        /// <returns>Dictionary which contains as key the assembly name which is loaded multiple times and as key
        /// as string list with the locations from where it was loaded.When no conflict has
        /// been determined an emtpy list is returned.</returns>
        public static IDictionary<string, IList<string>> GetConflictingAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var totalList = new List<AssemblyInfo>();

            foreach (Assembly assembly in assemblies.Where(a => !a.IsDynamic))
            {
                var info = new AssemblyInfo(assembly.GetName().Name, assembly.Location);
                totalList.Add(info);
            }
 
            var conflictingList = new Dictionary<string, IList<string>>();

            for (int i = 0; i < totalList.Count; i++)
            {
                var curInfo = totalList[i];
                for (int j = i + 1; j < totalList.Count; )
                {
                    var secondInfo = totalList[j];
                    if (String.Compare(curInfo.Name, secondInfo.Name, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (!conflictingList.ContainsKey(curInfo.Name))
                        {
                            var locations = new List<string>();
                            conflictingList.Add(curInfo.Name, locations);
                            conflictingList[curInfo.Name].Add(curInfo.Location);
                        }

                        conflictingList[curInfo.Name].Add(secondInfo.Location);
                        totalList.Remove(secondInfo);
                    }
                    else j++;
                }
            }

            return conflictingList;
        }
    }
}
