using System;
using System.ComponentModel;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class AttributeField: IAttributeField
    {
        private readonly Field _field;
        private int _index = -1;

        public AttributeField()
        {
            _field = new Field();
        }

        internal AttributeField(Field field, int index)
        {
            if (field == null)
            {
                throw new NullReferenceException("Field reference is null.");
            }

            _field = field;
            _index = index;
        }

        public int Index
        {
            get { return _index; }
        }

        public AttributeType Type
        {
            get { return (AttributeType) _field.Type; }
            set { _field.Type = (FieldType) value; }
        }

        public string Name
        {
            get { return _field.Name; }
            set { _field.Name = value; }
        }

        public int Precision
        {
            get { return _field.Precision; }
            set { _field.Precision = value; }
        }

        public int Width
        {
            get { return _field.Width; }
            set { _field.Width = value; }
        }

        public bool Visible
        {
            get { return _field.Visible; }
            set { _field.Visible = value; }
        }

        public string Alias
        {
            get { return _field.Alias; }
            set { _field.Alias = value; }
        }

        public object InternalObject
        {
            get { return _field; }
        }

        public string LastError
        {
            get { return _field.ErrorMsg[_field.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _field.Key; }
            set { _field.Key = value; }
        }

        [Browsable(false)]
        public string DisplayName
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Alias) ? Alias : Name;
            }
        }
    }
}