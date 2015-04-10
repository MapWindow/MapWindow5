using System;

namespace MW5.Shared
{
    public static class ArrayHelper
    {
        public static void CheckCopyTo(Array array, int arrayIndex, int collectionSize)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("");
            }
            if (collectionSize > array.Length - arrayIndex)
            {
                throw new ArgumentException("Array size is too small.");
            }
        }
    }
}
