namespace MW5.Api.Concrete
{
    public class CompareByValueBase
    {
        public static bool operator ==(CompareByValueBase id1, CompareByValueBase id2)
        {
            bool null1 = ReferenceEquals(id1, null);
            bool null2 = ReferenceEquals(id2, null);
            if (null1 && null2)
            {
                return true;
            }
            if (null1 != null2)
            {
                return false;
            }
            return id1.Equals(id2);
        }

        public static bool operator !=(CompareByValueBase id1, CompareByValueBase id2)
        {
            bool null1 = ReferenceEquals(id1, null);
            bool null2 = ReferenceEquals(id2, null);
            if (null1 && null2)
            {
                return false;
            }
            if (null1 != null2)
            {
                return true;
            }
            return !id1.Equals(id2);
        }
    }
}
