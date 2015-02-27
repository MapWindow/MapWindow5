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

        public string Filename
        {
            get { return _table.JoinFilename[_joinIndex]; }
        }
        public string FromField
        {
            get { return _table.JoinFromField[_joinIndex]; }
        }
        public string ToField
        {
            get { return _table.JoinToField[_joinIndex]; }
        }
    }
}
