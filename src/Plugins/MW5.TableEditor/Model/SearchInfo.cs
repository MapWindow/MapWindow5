using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.TableEditor.Model
{
    public class SearchInfo
    {
        public SearchInfo()
        {
            Count = 0;
            RowIndex = 0;
            ColumnIndex = 0;
            Token = string.Empty;
        }

        public int Count { get; private set; }
        public int RowIndex { get; private set; }
        public int ColumnIndex { get; private set; }
        public string Token { get; set; }

        public void StartNewSearch(string token)
        {
            RowIndex = 0;
            ColumnIndex = 0;
            Count = 0;
            Token = token.ToLower();
        }

        public void AddNewMatch(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            Count++;
        }
    }
}
