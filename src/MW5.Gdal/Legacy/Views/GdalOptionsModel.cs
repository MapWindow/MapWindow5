namespace MW5.Gdal.Legacy.Views
{
    public class GdalOptionsModel
    {
        public GdalOptionsModel(string mainOptions, string additionalOptions)
        {
            MainOptions = mainOptions;
            AdditionalOptions = additionalOptions;
        }

        public string Caption { get; set; }

        public string MainOptions { get; set;}

        public string AdditionalOptions { get; set; }
    }
}
