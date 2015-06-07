using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Views
{
    public class JoinViewModel
    {
        private readonly IAttributeTable _table;
        private List<string> _options = new List<string>();

        public JoinViewModel(IAttributeTable table)
        {
            if (table == null) throw new ArgumentNullException("table");

            Table = table;
        }

        public JoinViewModel(IAttributeTable table, FieldJoin editJoin)
            : this(table)
        {
            if (table == null) throw new ArgumentNullException("table");
            if (editJoin == null) throw new ArgumentNullException("editJoin");
            _table = table;
            Join = editJoin;

            string filename = PathHelper.GetAbsolutePath(editJoin.Filename, table.Filename);
            OpenDatasource(filename);

        }

        #region Properties

        public FieldJoin Join { get; set; }

        public string Filename { get; private set; }

        public IAttributeTable Table { get; set; }

        public IAttributeTable External { get; private set; }

        public JoinSourceType SourceType { get; private set; }

        public bool Editing
        {
            get { return Join != null; }
        }

        public IEnumerable<string> Options
        {
            get { return _options; }
        }

        public string SelectedOption { get; set; }

        #endregion

        /// <summary>
        /// Opens datasource with specified name (checks extension and loads list of options).
        /// </summary>
        public bool OpenDatasource(string filename)
        {
            if (!IdentifyDatasource(filename))
            {
                return false;
            }

            Filename = filename;

            if (LoadOptions()) return true;

            MessageService.Current.Info("Failed to open datasource:" + Filename);
            return false;
        }

        private bool LoadOptions()
        {
            _options.Clear();

            switch (SourceType)
            {
                case JoinSourceType.Dbf:
                    _options = new List<string>() { Path.GetFileNameWithoutExtension(Filename) };
                    break;
                case JoinSourceType.Xls:
                    _options = XlsImportHelper.GetWorkbooks(Filename);
                    break;
                case JoinSourceType.Csv:
                    //string options = ", (comma)", "| (vertical bar)", "; (semicolon)", ": (colon)", "- (hyphen)", "= (equals)", "\' (apostrophe)", "Tab"
                    _options = new List<string> { ",", "|", ";", ":", "-", "=", "\'", "Tab" };
                    break;
                default:
                    return false;
            }

            if (Join != null)
            {
                RestoreSelectedOption(Join.Options);
            }

            return _options.Any();
        }

        private void RestoreSelectedOption(string options)
        {
            if (string.IsNullOrWhiteSpace(options))
            {
                return;
            }
            
            var values = options.Split('=');
            if (values.Count() == 2)
            {
                var value = values[1].ToLower();
                foreach (var option in Options)
                {
                    if (option.ToLower().StartsWith(value))
                    {
                        SelectedOption = option;
                        break;
                    }
                }
            }
        }

        public bool ReloadExternal()
        {
            var table = new AttributeTable();
            if (ReloadExternal(table))
            {
                External = table;
                return true;
            }

            return false;
        }

        public bool ReloadExternal(IAttributeTable table, string joinOptions)
        {
            External = table;

            RestoreSelectedOption(joinOptions);

            return ReloadExternal(table);
        }

        private bool ReloadExternal(IAttributeTable table)
        {
            switch (SourceType)
            {
                case JoinSourceType.Dbf:
                    if (!table.Open(Filename))
                    {
                        return false;
                    }
                    break;
                case JoinSourceType.Xls:
                    {
                        var dt = XlsImportHelper.GetData(Filename, SelectedOption);
                        if (dt == null) return false;
                        DbfImportHelper.FillMapWinGisTable(dt, table);
                    }
                    break;
                case JoinSourceType.Csv:
                    {
                        var dt = CsvImportHelper.GetData(Filename, SelectedOption);
                        if (dt == null) return false;
                        DbfImportHelper.FillMapWinGisTable(dt, table);
                    }
                    break;
                default:
                    return false;
            }

            return true;
        }

        private bool IdentifyDatasource(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return false;
            }

            string ext = Path.GetExtension(filename.ToLower());

            switch (ext)
            {
                case ".xls":
                case ".xlsx":
                    SourceType = JoinSourceType.Xls;
                    return true;
                case ".csv":
                    SourceType = JoinSourceType.Csv;
                    return true;
                case ".dbf":
                    SourceType = JoinSourceType.Dbf;
                    return true;
            }

            return false;
        }

        public string GetOptionsString()
        {
            switch (SourceType)
            {
                case JoinSourceType.Dbf:
                    return "";
                case JoinSourceType.Xls:
                    return "worksheet=" + SelectedOption;
                case JoinSourceType.Csv:
                    return "separator=" + SelectedOption;
            }

            return string.Empty;
        }
    }
}
