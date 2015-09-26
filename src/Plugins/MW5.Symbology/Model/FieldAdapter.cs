// -------------------------------------------------------------------------------------------
// <copyright file="FieldAdapter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Symbology.Model
{
    /// <summary>
    /// A wrapper for field selection in label style dialog.
    /// </summary>
    internal class FieldAdapter
    {
        private readonly string _message = string.Empty;

        public FieldAdapter(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg)) throw new ArgumentNullException("msg");
            _message = msg;
        }

        public FieldAdapter(IAttributeField fld)
        {
            if (fld == null) throw new ArgumentNullException("fld");
            Field = fld;
        }

        public bool Empty
        {
            get { return Field == null; }
        }

        public IAttributeField Field { get; private set; }

        public override string ToString()
        {
            return Empty ? _message : Field.Name;
        }
    }
}