using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.TableEditor.Views
{
    public class JoinDbfModel
    {
        private bool _valid;
        private IAttributeTable _table;

        public JoinDbfModel(IAttributeTable table, string filename)
        {
            if (table == null) throw new ArgumentNullException("table");

            Table = table;
            Filename = filename;

            OpenTable();
        }

        public JoinDbfModel(IAttributeTable table, string filename, FieldJoin editJoin)
            : this(table, filename)
        {
            EditJoin = editJoin;
        }

        private void OpenTable()
        {
            _table = new AttributeTable();
            if (!_table.Open(Filename))
            {
                MessageService.Current.Info("Failed to open table:" + Filename);
                _valid = false;
                return;
            }

            _valid = true;
        }

        public bool IsValid { get { return _valid; } }

        public IAttributeTable Table { get; set; }
        public string Filename { get; set; }
        public FieldJoin EditJoin { get; set; }

        public IAttributeTable External
        {
            get { return _table; }
        }
    }
}
