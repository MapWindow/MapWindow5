using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Model
{
    public class SearchInfo
    {
        private string _token;
        private MatchType _matchType;
        private bool _caseSensitive;
        private int _fieldIndex;

        public SearchInfo()
        {
            Count = 0;
            Token = string.Empty;
            ReplaceWith = string.Empty;
            MatchType = MatchType.Contains;
            CaseSensitive = true;
            FieldIndex = -1;
        }

        public string ReplaceWith { get; set; }
                
        public string Token 
        {
            get { return _token; }
            set
            {
                if (_token != value) NewSearch = true;
                _token = value;
            }
        }

        public MatchType MatchType
        {
            get { return _matchType; }
            set
            {
                if (_matchType != value) NewSearch = true;
                _matchType = value;
            }
        }

        public bool CaseSensitive
        {
            get { return _caseSensitive; }
            set
            {
                if (_caseSensitive != value) NewSearch = true;
                _caseSensitive = value;
            }
        }

        public int FieldIndex
        {
            get { return _fieldIndex; }
            set
            {
                if (_fieldIndex != value) NewSearch = true;
                _fieldIndex = value;
            }
        }

        public bool NewSearch { get; set; }
        public bool Finished { get; set; }
        public bool RestartSearch { get; set; }
        public int Count { get; set; }
        public int StartRowIndex { get; set; }
        public int StartColumnIndex { get; set; }

        public void Clear()
        {
            NewSearch = false;
            Finished = false;
            RestartSearch = false;
            Count = 0;
        }

        public bool Match(string value)
        {
            if (CaseSensitive)
            {
                switch (MatchType)
                {
                    case MatchType.Contains:
                        return value.Contains(Token);
                    case MatchType.Match:
                        return value.Equals(Token);
                    case MatchType.Start:
                        return value.StartsWith(Token);
                }
            }
            else
            {
                switch (MatchType)
                {
                    case MatchType.Contains:
                        return value.ContainsIgnoreCase(Token);
                    case MatchType.Match:
                        return value.EqualsIgnoreCase(Token);
                    case MatchType.Start:
                        return value.StartsWithIgnoreCase(Token);
                }
            }

            return false;
        }
    }
}
