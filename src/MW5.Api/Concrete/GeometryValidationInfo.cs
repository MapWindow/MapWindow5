using System;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class GeometryValidationInfo: IComWrapper
    {
        private IShapeValidationInfo _info;

        internal GeometryValidationInfo(IShapeValidationInfo info)
        {
            _info = info;
            if (info == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public string ClassName
        {
            get { return _info.ClassName; }
        }

        public string MethodName
        {
            get { return _info.MethodName; }
        }

        public string ParameterName
        {
            get { return _info.ParameterName; }
        }

        public ValidationType ValidationType
        {
            get { return (ValidationType)_info.ValidationType; }
        }

        public ValidationMode ValidationMode
        {
            get { return (ValidationMode)_info.ValidationMode; }
        }

        public bool IsValid
        {
            get { return _info.IsValid; }
        }

        public ValidationStatus Status
        {
            get { return (ValidationStatus)_info.Status; }
        }

        public bool WasValidated
        {
            get { return _info.WasValidated; }
        }

        public int StillInvalidCount
        {
            get { return _info.StillInvalidCount; }
        }

        public int WereInvalidCount
        {
            get { return _info.WereInvalidCount; }
        }

        public int FixedCount
        {
            get { return _info.FixedCount; }
        }

        public int SkippedCount
        {
            get { return _info.SkippedCount; }
        }

        public object InternalObject
        {
            get { return _info; }
        }

        public string LastError
        {
            get { return ErrorHelper.NO_ERROR; }
        }

        public string Tag
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }
    }
}
