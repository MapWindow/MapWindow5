using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BL.BO
{
    public abstract class BaseSettings
    {

        string directoryPath = string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                                .Split('\\').Reverse().Skip(3).Reverse().Aggregate((a, b) => a + "\\" + b)
                                , "\\", "Settings");

        protected static bool IsInitialized = false;

        public BaseSettings(string name)
        {
        }


        // Constructor.
        public BaseSettings(string name, object obj)
        {
            if(!IsInitialized)
            {
                string settingFile = directoryPath + name;
                InitializeItems(settingFile, obj);

                IsInitialized = true;
            }   
        }

        private bool InitializeItems(string settingFile, object obj)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(obj.GetType());
                using (StreamReader sr = new StreamReader(settingFile))
                {
                    obj = reader.Deserialize(sr);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save()
        {
            return false;
        }
    }
}
