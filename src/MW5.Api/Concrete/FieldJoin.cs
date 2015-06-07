using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using MapWinGIS;

namespace MW5.Api.Concrete
{
    public class FieldJoin
    {
        private readonly Table _table;
        private readonly int _joinIndex;

        public FieldJoin(Table table, int joinIndex)
        {
            _table = table;
            _joinIndex = joinIndex;
        }

        [DisplayName("Filename")]
        public string DisplayName
        {
            get
            {
                string path = _table.JoinFilename[_joinIndex];
                return Path.GetFileName(path);
            }
        }

        [Browsable(false)]
        public string Filename
        {
            get { return _table.JoinFilename[_joinIndex]; }
        }

        [DisplayName("From field")]
        public string FromField
        {
            get { return _table.JoinFromField[_joinIndex]; }
        }

        [DisplayName("To field")]
        public string ToField
        {
            get { return _table.JoinToField[_joinIndex]; }
        }

        [Browsable(false)]
        public int JoinIndex
        {
            get { return _joinIndex; }
        }

        [Browsable(false)]
        public IEnumerable<string> Fields
        {
            get
            {
                var s =_table.JoinFields[_joinIndex];
                return s.Split(',');
            }
        }

        [DisplayName("Fields")]
        public string FieldsCsv
        {
            get
            {
                var s = _table.JoinFields[_joinIndex];
                return string.IsNullOrWhiteSpace(s) ? "<all>" : s;
            }
        }

        [Browsable(false)]
        public string Options
        {
            get
            {
                return _table.JoinOptions[_joinIndex];
            }
        }
    }
}
