// -------------------------------------------------------------------------------------------
// <copyright file="FieldTypeWrapper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using MW5.Api.Interfaces;

namespace MW5.Attributes.Model
{
    public class FieldTypeWrapper
    {
        private readonly IAttributeField _field;

        public FieldTypeWrapper(IAttributeField field)
        {
            if (field == null) throw new ArgumentNullException("field");
            _field = field;
        }

        public string Name
        {
            get { return _field.Name; }
        }

        [DisplayName(" ")]
        public string Type
        {
            get { return _field.Abbreviation; }
        }

        [Browsable(false)]
        public int Index
        {
            get { return _field.Index; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}