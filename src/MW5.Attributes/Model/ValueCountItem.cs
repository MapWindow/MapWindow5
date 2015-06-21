namespace MW5.Attributes.Model
{
    public class ValueCountItem
    {
        public ValueCountItem(string value, int count)
        {
            Value = value;
            Count = count;
        }

        public int Count { get; private set; }
        public string Value { get; private set;}
    }
}
