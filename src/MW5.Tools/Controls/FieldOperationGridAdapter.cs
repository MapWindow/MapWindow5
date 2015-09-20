// -------------------------------------------------------------------------------------------
// <copyright file="FieldOperationGridAdapter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Tools.Controls
{
    /// <summary>
    /// A data structure to choose group operation for a given field.
    /// </summary>
    internal class FieldOperationGridAdapter
    {
        private IAttributeField _field;

        public FieldOperationGridAdapter(IAttributeField field)
        {
            if (field == null) throw new ArgumentNullException("field");

            _field = field;
        }

        [DisplayName(" ")]
        public object Delete { get; set; }

        /// <remarks>
        /// GridGroupControl doesn't 
        /// http ://www.syncfusion.com/forums/54409/data-binding-custom-object-ilist-with-descendant-objects-in-the-list</remarks>
        [DisplayName("Field name")]
        public IAttributeField Field
        {
            get { return _field as AttributeField; }
            set { _field = value; }
        }

        [DisplayName("Operation")]
        public GroupOperation GroupOperation { get; set; }
    }
}