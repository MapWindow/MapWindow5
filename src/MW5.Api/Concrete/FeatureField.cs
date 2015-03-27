using System;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class FeatureField: IFeatureField
    {
        private readonly Field _field;

        public FeatureField()
        {
            _field = new Field();
        }

        internal FeatureField(Field field)
        {
            if (field == null)
            {
                throw new NullReferenceException("Field reference is null.");
            }

            _field = field;
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
    }
}