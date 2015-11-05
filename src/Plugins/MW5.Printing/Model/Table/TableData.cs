// -------------------------------------------------------------------------------------------
// <copyright file="TableData.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Model.Table
{
    /// <summary>
    /// Holds data for the table
    /// </summary>
    [DataContract]
    public class TableData : IEnumerable<RowData>
    {
        private const char LineSeparator = '\n';
        private const char CellSeparator = '\t';
        private List<RowData> _rows = new List<RowData>();
        private List<Column> _columns = new List<Column>();

        /// <summary>
        /// Gets the list of columns.
        /// </summary>
        public List<Column> Columns
        {
            get { return _columns; }
        }

        public RowData this[int index]
        {
            get
            {
                if (index < 0 || index >= _rows.Count)
                {
                    throw new IndexOutOfRangeException("Invalid row index");
                }

                return _rows[index];
            }
        }

        public int RowCount
        {
            get { return _rows.Count; }
        }

        /// <summary>
        /// Returns maximum length of row
        /// </summary>
        public int RowLength
        {
            get { return this.Max(row => row.Count); }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<RowData> GetEnumerator()
        {
            return _rows.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRow(RowData row)
        {
            _rows.Add(row);
        }

        [DataMember]
        private string XmlColumns 
        {
            get { return SerializeColumns(); }
            set
            {
                _columns = new List<Column>();
                DeserializeColumns(value);
            }
        }

        [DataMember]
        private string XmlData
        {
            get { return SerializeData(); }
            set
            {
                _rows = new List<RowData>();
                DeserializeData(value);
            }
        }

        /// <summary>
        /// Clears all the data including columns.
        /// </summary>
        public void ClearAll()
        {
            _columns.Clear();

            ClearRows();
        }

        public void ClearRows()
        {
            _rows.Clear();
        }

        /// <summary>
        /// Deserializes the columns.
        /// </summary>
        public void DeserializeColumns(string columnState)
        {
            var doc = XDocument.Parse(columnState);

            var list =
                doc.Descendants("Column")
                    .Select(
                        item =>
                        new Column("")
                            {
                                RelWidth = (int)item.Attribute("RelWidth"),
                                Width = (int)item.Attribute("Width"),
                                WidthType = (ColumnWidthType)((int)item.Attribute("WidthType"))
                            });

            _columns = list.ToList();
        }

        /// <summary>
        /// Deserializes the data.
        /// </summary>
        public void DeserializeData(string data)
        {
            ClearRows();

            var rows = data.Split(new[] { LineSeparator }, StringSplitOptions.None);

            foreach (var row in rows)
            {
                if (!string.IsNullOrEmpty(row))
                {
                    var values = row.Split(CellSeparator);
                    AddRow(new RowData(values));

                    string s = "";

                    foreach (var item in values)
                    {
                        s += item;
                    }
                }
            }

            Normalize();
        }

        public void Initialize(int rowCount, int colCount)
        {
            ClearRows();

            if (rowCount < 1 || colCount < 1 || rowCount > 100 || colCount > 100)
            {
                throw new ArgumentException("Unexpected number of rows of columns for table");
            }

            for (int i = 0; i < rowCount; i++)
            {
                AddRow(new RowData(new string[colCount]));
            }

            for (int i = 0; i < colCount; i++)
            {
                _columns.Add(new Column("Column " + i));
            }

            FillWithDefaultValues();
        }

        /// <summary>
        /// Serializes the columns.
        /// </summary>
        public string SerializeColumns()
        {
            var doc =
                new XDocument(new XElement("Columns",
                    _columns.Select(
                        item =>
                        new XElement("Column", new XAttribute("RelWidth", item.RelWidth),
                            new XAttribute("Width", item.Width), new XAttribute("WidthType", (int)item.WidthType)))));
            return doc.ToString();
        }

        /// <summary>
        /// Serializes the data.
        /// </summary>
        public string SerializeData()
        {
            var b = new StringBuilder();

            int count = _rows.Count;

            for (int i = 0; i < count; i++)
            {
                var item = this[i];

                for (int j = 0; j < item.Count; j++)
                {
                    b.Append(item[j]);

                    if (j < item.Count - 1)
                    {
                        b.Append(CellSeparator);
                    }
                }

                if (i < count - 1)
                {
                    b.Append(LineSeparator);
                }
            }

            return b.ToString();
        }

        /// <summary>
        /// Returns a readable representation of table
        /// </summary>
        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var row in this)
            {
                foreach (var value in row)
                {
                    result.Append(value);
                    result.Append(CellSeparator);
                }
                result.Append(LineSeparator);
            }

            return result.ToString();
        }

        /// <summary>
        /// Fills the table with incrementally increasing values.
        /// </summary>
        private void FillWithDefaultValues()
        {
            for (int i = 0; i < RowCount; i++)
            {
                var r = this[i];

                for (int j = 0; j < r.Count; j++)
                {
                    r[j] = (i + 1) + (j + 1).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        /// <summary>
        /// Ensures that all rows have the same number of columns
        /// </summary>
        private void Normalize()
        {
            int rowLength = RowLength;

            foreach (var item in this.Where(row => row.Count < RowLength))
            {
                int toAdd = rowLength - item.Count;

                for (int i = 0; i < toAdd; i++)
                {
                    item.Add("");
                }
            }
        }
    }
}