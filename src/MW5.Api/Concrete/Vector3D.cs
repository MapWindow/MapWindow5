using System;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class Vector3D: IComWrapper
    {
        private readonly Vector _vector;

        public Vector3D(Vector vector)
        {
            _vector = vector;
            if (vector == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public object InternalObject
        {
            get { return _vector; }
        }

        public string LastError
        {
            get { return _vector.ErrorMsg[_vector.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _vector.Key; }
            set { _vector.Key = value; }
        }

        public void Normalize()
        {
            _vector.Normalize();
        }

        public double Dot(Vector3D vector)
        {
            return _vector.Dot(vector.GetInternal());
        }

        public Vector3D CrossProduct(Vector3D vector)
        {
            return new Vector3D(_vector.CrossProduct(vector.GetInternal()));
        }

        public double I
        {
            get { return _vector.i; }
            set { _vector.i = value; }
        }

        public double J
        {
            get { return _vector.j; }
            set { _vector.j = value; }
        }

        public double K
        {
            get { return _vector.k; }
            set { _vector.k = value; }
        }
    }
}
