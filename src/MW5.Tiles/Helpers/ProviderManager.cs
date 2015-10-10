using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Tiles.Helpers
{
    /// <summary>
    /// A wrapper class to access settings from TileProviders.xml file
    /// </summary>
    public class ProviderManager
    {
        // marks whether an error has occured
        private static int errorCount = 0;

        #region LINQ to XML
        /// <summary>
        /// Reads settings from the file
        /// </summary>
        /// <param name="tiles">Reference to the tiles class</param>
        public static void Read(TileManager tiles)
        {
            if (tiles == null)
                throw new ArgumentNullException("Reference to the tiles wasn't passed");

            XElement root = XElement.Load(GetFilename());
            string ns = root.GetDefaultNamespace().NamespaceName;

            var list = from p in root.Descendants(XName.Get("DefaultProvider", ns))
                            where p.Attribute("Selected").Value != "0" select p;

            // setting versions
            foreach (var item in list)
            {
                var p = (TileProvider)Convert.ToInt32(item.Attribute("Id").Value);

                int index = tiles.Providers.get_IndexByProvider(p);
                tiles.Providers[index].Version = item.Attribute("Version").Value;
            }

            // updating custom providers
            tiles.Providers.Clear(false);
            var list2 = from p in root.Descendants(XName.Get("TmsProvider", ns))
                       where p.Attribute("Selected").Value != "0" 
                       select new {
                           Id = Convert.ToInt32(p.Attribute("Id").Value),
                           Name = p.Attribute("Name").Value,
                           Url = p.Attribute("UrlPattern").Value,
                           Projection = Convert.ToInt32(p.Attribute("Projection").Value)
                       };

            foreach (var item in list2)
            {
                tiles.Providers.AddCustom(item.Id, item.Name, item.Url, (TileProjection)item.Projection, 0, 17);
            }
        }
        
        /// <summary>
        /// Saves the state of nodes of providers tree view
        /// </summary>
        public static void SaveTreeState(TreeView tree)
        {
            if (tree.Nodes.Count == 0)
                return;

            try
            {
                Dictionary<string, bool> state = new Dictionary<string, bool>();

                TreeNode node = tree.Nodes[0];
                foreach (TreeNode g in node.Nodes)
                {
                    state.Add(g.Text, g.IsExpanded);
                }

                XElement el = XElement.Load(GetFilename());
                string ns = el.GetDefaultNamespace().NamespaceName;

                var list = from g in el.Descendants(XName.Get("TileGroup", ns)) select g;

                foreach (var item in list)
                {
                    string name = item.Attribute("Name").Value;
                    if (state.ContainsKey(name))
                    {
                        item.Attribute("Expanded").Value = state[name] ? "1" : "0";
                    }
                }
                el.Save(GetFilename());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Reads providers from the settings
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public static void FillProviderTree(TreeView tree, int selectedProvider)
        {
            tree.Nodes.Clear();
            TreeNode node = tree.Nodes.Add("Providers");
            node.Expand();
            
            XElement root = XElement.Load(GetFilename());
            string ns = root.GetDefaultNamespace().NamespaceName;

            var list = from p in root.Descendants(XName.Get("TileGroup", ns)) select p;
            foreach (var g in list)
            {
                string id = g.Attribute("Id").Value;
                var providers = from p in root.Descendants(XName.Get("DefaultProvider", ns)) 
                                where p.Attribute("GroupId").Value == id &&
                                      p.Attribute("Selected").Value != "0" select p;

                var custom = from p in root.Descendants(XName.Get("TmsProvider", ns))
                             where p.Attribute("GroupId").Value == id && 
                                   p.Attribute("Selected").Value != "0" 
                             select p;

                if (providers.Any() || custom.Any())
                {
                    TreeNode group = node.Nodes.Add(g.Attribute("Name").Value);

                    foreach (var item in providers)
                    {
                        var n = new TreeNode(item.Attribute("Name").Value)
                                    {
                                        Tag = Convert.ToInt32(item.Attribute("Id").Value)
                                    };
                        group.Nodes.Add(n);

                        if ((int)n.Tag == selectedProvider)
                            tree.SelectedNode = n;
                    }

                    foreach (var item in custom)
                    {
                        var n = new TreeNode(item.Attribute("Name").Value) { Tag = Convert.ToInt32(item.Attribute("Id").Value) };
                        group.Nodes.Add(n);

                        if ((int)n.Tag == selectedProvider)
                            tree.SelectedNode = n;
                    }

                    if (g.Attribute("Expanded").Value != "0")
                        group.Expand();
                }
            }
        }

        /// <summary>
        /// Validates XML file with settings against a schema
        /// </summary>
        /// <returns>True if the file is valid and false otherwise</returns>
        public static bool Validate()
        {
            XDocument doc = XDocument.Load(GetFilename());
            var set = new XmlSchemaSet();
            set.Add(null, GetSchemaName());

            var del = new ValidationEventHandler(ValidationHandler);
            errorCount = 0;
            doc.Validate(set, del);
            return errorCount == 0;
        }

        static void ValidationHandler(object o, ValidationEventArgs e)
        {
            Debug.WriteLine(e.Message);
            errorCount++;
        }
        #endregion

        #region XML DOM Validation
        /// <summary>
        /// Tries to open XML document with settings
        /// </summary>
        private static bool ValidateByDom()
        {
            string path = GetSchemaName();
            XmlReaderSettings settings = null;

            if (File.Exists(path))
            {
                settings = new XmlReaderSettings { ValidationType = System.Xml.ValidationType.Schema };
                settings.Schemas.Add(null, path);
                settings.ValidationEventHandler += settings_ValidationEventHandler;
            }

            errorCount = 0;
            XmlReader reader = XmlReader.Create(GetFilename(), settings);
            while (reader.Read()) { };  // first run the validation; 
            // it protects from situation when the process is broken half way through

            return errorCount == 0;
        }

        /// <summary>
        /// Logs information on XML schema errors
        /// </summary>
        static void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            Debug.WriteLine(e.Message);
            errorCount++;
        }
        #endregion

        private static string GetFilename()
        {
            string filename = Application.StartupPath + @"\tileproviders.xml";
            if (!File.Exists(filename))
                throw new FileNotFoundException("Tile settings were not found: " + filename);
            return filename;
        }

        private static string GetSchemaName()
        {
            string filename = Application.StartupPath + @"\tileproviders.xsd";
            if (!File.Exists(filename))
                throw new FileNotFoundException("Validation schema wasn't found: " + filename);
            return filename;
        }
    }
}
