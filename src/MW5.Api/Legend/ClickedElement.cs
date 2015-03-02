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
            this.ColorBox = false;
            this.CheckBox = false;
            this.ExpansionBox = false;
            this.Charts = false;
            this.Label = false;
            this.ChartFieldIndex = -1;
            this.CategoryIndex = -1;
            this.GroupIndex = -1;
        }
    }
}