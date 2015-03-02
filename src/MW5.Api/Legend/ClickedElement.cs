namespace MW5.Api.Legend
{
    /// <summary>
    /// The element of legend that was clicked
    /// </summary>
    public class ClickedElement
    {
        public int CategoryIndex { get; set; }
        public int ChartFieldIndex { get; set; }
        public bool Charts { get; set; }
        public bool CheckBox { get; set; }
        public bool ColorBox { get; set; }
        public bool ExpansionBox { get; set; }
        public int GroupIndex { get; set; }
        public bool Label { get; set; }
        public bool LabelsIcon { get; set; }

        public void Nullify()
        {
            ColorBox = false;
            CheckBox = false;
            ExpansionBox = false;
            Charts = false;
            Label = false;
            ChartFieldIndex = -1;
            CategoryIndex = -1;
            GroupIndex = -1;
        }
    }
}