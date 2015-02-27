using System;

namespace MW5.Api.Helpers
{
    internal static class ArrayHelper
    {
        internal static void CheckCopyTo(Array array, int arrayIndex, int collectionSize)
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
