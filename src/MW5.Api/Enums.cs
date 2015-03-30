namespace MW5.Api
{
    public enum AttributeType
    {
        String = 0,
        Integer = 1,
        Double = 2
    }

    public enum GeometryType
    {
        None = 0,
        Point = 1,
        Polyline = 2,
        Polygon = 3,
        MultiPoint = 4
    }

    public enum ZValueType
    {
        None,
        M,
        Z
    }

    public enum MapProjection
    {
        Custom = -1,
        None = 0,
        Wgs84 = 1,
        GoogleMercator = 2
    }

    public enum LayerType
    {
        Invalid = -1,
        Shapefile = 0,
        Image = 1,
        VectorLayer = 2,
        Grid = 3,
    }

    public enum SpatialRelation
    {
        Contains = 0,
        Crosses = 1,
        Disjoint = 2,
        Equals = 3,
        Intersects = 4,
        Overlaps = 5,
        Touches = 6,
        Within = 7,
    }

    public enum BufferCap
    {
        Round = 0,
        Flat = 1,
        Square = 2,
    }

    public enum BufferJoin
    {
        Round = 0,
        Mitre = 1,
        Bevel = 2,
    }

    public enum ClipOperation
    {
        Difference = 0,
        Intersection = 1,
        SymDifference = 2,
        Union = 3,
        Clip = 4,
    }

    public enum GradientBounds
    {
        WholeLayer = 0,
        PerShape = 1,
    }

    public enum GradientType
    {
        Linear = 0,
        Rectangular = 1,
        Circle = 2,
    }

    public enum FillType
    {
        Solid = 0,
        Hatch = 1,
        Gradient = 2,
        Picture = 3,
    }

    public enum VertexType
    {
        Square = 0,
        Circle = 1,
    }

    public enum VectorMarkerType
    {
        Regular = 0,
        Cross = 1,
        Star = 2,
        Circle = 3,
        Arrow = 4,
        Flag = 5,
    }

    public enum MarkerType
    {
        Vector = 0,
        FontCharacter = 1,
        Bitmap = 2,
    }

    public enum FrameType
    {
        Rectangle = 0,
        RoundedRectangle = 1,
        PointedRectangle = 2,
    }

    public enum VectorMarker
    {
        Square = 0,
        Circle = 1,
        Diamond = 2,
        TriangleUp = 3,
        TriangleDown = 4,
        TriangleLeft = 5,
        TriangleRight = 6,
        Cross = 7,
        XCross = 8,
        Star = 9,
        Pentagon = 10,
        ArrowUp = 11,
        ArrowDown = 12,
        ArrowLeft = 13,
        ArrowRight = 14,
        Asterisk = 15,
        Flag = 16,
    }

    public enum CategoryValue
    {
        SingleValue = 0,
        Range = 1,
        Expression = 2,
    }

    public enum Classification
    {
        NaturalBreaks = 0,
        UniqueValues = 1,
        EqualIntervals = 2,
        EqualCount = 3,
        StandardDeviation = 4,
        EqualSumOfValues = 5,
    }

    public enum ColorRampType
    {
        Random = 0,
        Graduated = 1,
    }

    public enum StyleElement
    {
        Default = 0,
        Fill = 1,
        Fill2 = 2,
        Lines = 3,
        FillBackground = 4,
    }

    public enum PredefinedColors
    {
        FallLeaves = 0,
        SummerMountains = 1,
        Desert = 2,
        Glaciers = 3,
        Meadow = 4,
        ValleyFires = 5,
        DeadSea = 6,
        Highway1 = 7,
        Rainbow = 8,
        ReversedRainbow = 9,
    }

    public enum InterpolationType
    {
        Bilinear = 3,
        Bicubic = 4,
        None = 5,
        HighQualityBilinear = 6,
        HighQualityBicubic = 7,
    }

    public enum ImageFormat
    {
        Bmp = 0,
        Gif = 1,
        UseFileExtension = 2,
        Tiff = 3,
        Jpeg = 4,
        Png = 5,
        Ppm = 7,
        Ecw = 8,
        Jpeg2000 = 9,
        Sid = 10,
        Pnm = 11,
        Pgm = 12,
        Bil = 13,
        Adf = 14,
        Grd = 15,
        Img = 16,
        Asc = 17,
        Bt = 18,
        Map = 19,
        Lf2 = 20,
        Kap = 21,
        Dem = 22,
        Ntf = 23,
        NetCdf = 24,
        Vrt = 25,
    }

    public enum ImageSourceType
    {
        Uninitialized = 0,
        DiskBased = 1,
        InMemory = 2,
        GdalRaster = 3,
        GdiPlus = 4,
    }

    public enum InRamState
    {
        Disk = 0,
        InRamBuffer = 1,
        InRam = 2
    };

    public enum CoordinateSystemParameter
    {
        SemiMajor = 0,
        SemiMinor = 1,
        InverseFlattening = 2,
        PrimeMeridian = 3,
        AngularUnit = 4,
    }

    public enum ProjectionParameter
    {
        LatitudeOfOrigin = 0,
        CentralMeridian = 1,
        ScaleFactor = 2,
        FalseEasting = 3,
        FalseNorthing = 4,
        LongitudeOfOrigin = 5,
    }

    public enum Wgs84Projection
    {
        Wgs84_World_Mercator = 3395,
        Wgs84_PDC_Mercator = 3832,
        Wgs84_Pseudo_Mercator = 3857,
        Wgs84_Mercator_41 = 3994,
        Wgs84_World_Equidistant_Cylindrical = 4087,
        Wgs84_UPS_North_EN = 5041,
        Wgs84_UPS_South_EN = 5042,
        Wgs84_UTM_grid_system_northern_hemisphere = 32600,
        Wgs84_UTM_zone_1N = 32601,
        Wgs84_UTM_zone_2N = 32602,
        Wgs84_UTM_zone_3N = 32603,
        Wgs84_UTM_zone_4N = 32604,
        Wgs84_UTM_zone_5N = 32605,
        Wgs84_UTM_zone_6N = 32606,
        Wgs84_UTM_zone_7N = 32607,
        Wgs84_UTM_zone_8N = 32608,
        Wgs84_UTM_zone_9N = 32609,
        Wgs84_UTM_zone_10N = 32610,
        Wgs84_UTM_zone_11N = 32611,
        Wgs84_UTM_zone_12N = 32612,
        Wgs84_UTM_zone_13N = 32613,
        Wgs84_UTM_zone_14N = 32614,
        Wgs84_UTM_zone_15N = 32615,
        Wgs84_UTM_zone_16N = 32616,
        Wgs84_UTM_zone_17N = 32617,
        Wgs84_UTM_zone_18N = 32618,
        Wgs84_UTM_zone_19N = 32619,
        Wgs84_UTM_zone_20N = 32620,
        Wgs84_UTM_zone_21N = 32621,
        Wgs84_UTM_zone_22N = 32622,
        Wgs84_UTM_zone_23N = 32623,
        Wgs84_UTM_zone_24N = 32624,
        Wgs84_UTM_zone_25N = 32625,
        Wgs84_UTM_zone_26N = 32626,
        Wgs84_UTM_zone_27N = 32627,
        Wgs84_UTM_zone_28N = 32628,
        Wgs84_UTM_zone_29N = 32629,
        Wgs84_UTM_zone_30N = 32630,
        Wgs84_UTM_zone_31N = 32631,
        Wgs84_UTM_zone_32N = 32632,
        Wgs84_UTM_zone_33N = 32633,
        Wgs84_UTM_zone_34N = 32634,
        Wgs84_UTM_zone_35N = 32635,
        Wgs84_UTM_zone_36N = 32636,
        Wgs84_UTM_zone_37N = 32637,
        Wgs84_UTM_zone_38N = 32638,
        Wgs84_UTM_zone_39N = 32639,
        Wgs84_UTM_zone_40N = 32640,
        Wgs84_UTM_zone_41N = 32641,
        Wgs84_UTM_zone_42N = 32642,
        Wgs84_UTM_zone_43N = 32643,
        Wgs84_UTM_zone_44N = 32644,
        Wgs84_UTM_zone_45N = 32645,
        Wgs84_UTM_zone_46N = 32646,
        Wgs84_UTM_zone_47N = 32647,
        Wgs84_UTM_zone_48N = 32648,
        Wgs84_UTM_zone_49N = 32649,
        Wgs84_UTM_zone_50N = 32650,
        Wgs84_UTM_zone_51N = 32651,
        Wgs84_UTM_zone_52N = 32652,
        Wgs84_UTM_zone_53N = 32653,
        Wgs84_UTM_zone_54N = 32654,
        Wgs84_UTM_zone_55N = 32655,
        Wgs84_UTM_zone_56N = 32656,
        Wgs84_UTM_zone_57N = 32657,
        Wgs84_UTM_zone_58N = 32658,
        Wgs84_UTM_zone_59N = 32659,
        Wgs84_UTM_zone_60N = 32660,
        Wgs84_UPS_North_NE = 32661,
        Wgs84_BLM_14N_ftUS = 32664,
        Wgs84_BLM_15N_ftUS = 32665,
        Wgs84_BLM_16N_ftUS = 32666,
        Wgs84_BLM_17N_ftUS = 32667,
        Wgs84_UTM_grid_system_southern_hemisphere = 32700,
        Wgs84_UTM_zone_1S = 32701,
        Wgs84_UTM_zone_2S = 32702,
        Wgs84_UTM_zone_3S = 32703,
        Wgs84_UTM_zone_4S = 32704,
        Wgs84_UTM_zone_5S = 32705,
        Wgs84_UTM_zone_6S = 32706,
        Wgs84_UTM_zone_7S = 32707,
        Wgs84_UTM_zone_8S = 32708,
        Wgs84_UTM_zone_9S = 32709,
        Wgs84_UTM_zone_10S = 32710,
        Wgs84_UTM_zone_11S = 32711,
        Wgs84_UTM_zone_12S = 32712,
        Wgs84_UTM_zone_13S = 32713,
        Wgs84_UTM_zone_14S = 32714,
        Wgs84_UTM_zone_15S = 32715,
        Wgs84_UTM_zone_16S = 32716,
        Wgs84_UTM_zone_17S = 32717,
        Wgs84_UTM_zone_18S = 32718,
        Wgs84_UTM_zone_19S = 32719,
        Wgs84_UTM_zone_20S = 32720,
        Wgs84_UTM_zone_21S = 32721,
        Wgs84_UTM_zone_22S = 32722,
        Wgs84_UTM_zone_23S = 32723,
        Wgs84_UTM_zone_24S = 32724,
        Wgs84_UTM_zone_25S = 32725,
        Wgs84_UTM_zone_26S = 32726,
        Wgs84_UTM_zone_27S = 32727,
        Wgs84_UTM_zone_28S = 32728,
        Wgs84_UTM_zone_29S = 32729,
        Wgs84_UTM_zone_30S = 32730,
        Wgs84_UTM_zone_31S = 32731,
        Wgs84_UTM_zone_32S = 32732,
        Wgs84_UTM_zone_33S = 32733,
        Wgs84_UTM_zone_34S = 32734,
        Wgs84_UTM_zone_35S = 32735,
        Wgs84_UTM_zone_36S = 32736,
        Wgs84_UTM_zone_37S = 32737,
        Wgs84_UTM_zone_38S = 32738,
        Wgs84_UTM_zone_39S = 32739,
        Wgs84_UTM_zone_40S = 32740,
        Wgs84_UTM_zone_41S = 32741,
        Wgs84_UTM_zone_42S = 32742,
        Wgs84_UTM_zone_43S = 32743,
        Wgs84_UTM_zone_44S = 32744,
        Wgs84_UTM_zone_45S = 32745,
        Wgs84_UTM_zone_46S = 32746,
        Wgs84_UTM_zone_47S = 32747,
        Wgs84_UTM_zone_48S = 32748,
        Wgs84_UTM_zone_49S = 32749,
        Wgs84_UTM_zone_50S = 32750,
        Wgs84_UTM_zone_51S = 32751,
        Wgs84_UTM_zone_52S = 32752,
        Wgs84_UTM_zone_53S = 32753,
        Wgs84_UTM_zone_54S = 32754,
        Wgs84_UTM_zone_55S = 32755,
        Wgs84_UTM_zone_56S = 32756,
        Wgs84_UTM_zone_57S = 32757,
        Wgs84_UTM_zone_58S = 32758,
        Wgs84_UTM_zone_59S = 32759,
        Wgs84_UTM_zone_60S = 32760,
        Wgs84_UPS_South_NE = 32761,
    }

    public enum FeatureSourceType
    {
        Uninitialized = 0,
        DiskBased = 1,
        InMemory = 2,
    }

    public enum LabelAlignment
    {
        TopLeft = 0,
        TopCenter = 1,
        TopRight = 2,
        CenterLeft = 3,
        Center = 4,
        CenterRight = 5,
        BottomLeft = 6,
        BottomCenter = 7,
        BottomRight = 8,
    }

    public enum LinearGradient
    {
        Horizontal = 0,
        Vertical = 1,
        ForwardDiagonal = 2,
        BackwardDiagonal = 3,
        None = 4,
    }

    public enum LabelOrientation
    {
        Horizontal = 0,
        Parallel = 1,
        Perpindicular = 2,
    }

    public enum LabelPosition
    {
        Center = 0,
        Centroid = 1,
        InteriorPoint = 2,
        FirstSegment = 3,
        LastSegment = 4,
        MiddleSegment = 5,
        LongestSegement = 6,
        None = 7,
    }

    public enum PersistenceType
    {
        None = 0,
        Standard = 1,
        Xml = 2,
        Dbf = 3,
        XmlOverwrite = 4,
    }

    public enum VerticalPosition
    {
        AboveParentLayer = 0,
        AboveAllLayers = 1,
    }

    public enum AutoToggle
    {
        Auto = 0,
        True = 1,
        False = 2,
    }

    public enum MapCursor
    {
        ZoomIn = 0,
        ZoomOut = 1,
        Pan = 2,
        Selection = 3,
        None = 4,
        // TODO: add separate cursor for area and distance (in wrapper)
        Measure = 5,
        AddShape = 6,
        EditShape = 8,
        SplitByPolyline = 9,
        Identify = 10,
        MoveShapes = 11,
        RotateShapes = 12,
        SelectByPolygon = 13,
        EraseByPolygon = 14,
        SplitByPolygon = 15,
        ClipByPolygon = 16,
    }

    public enum KnownExtents
    {
        SiliconValley = -3,
        Greenwich = -2,
        None = -1,
        World = 0,
        Afghanistan = 1,
        AlandIslands = 2,
        Albania = 3,
        Algeria = 4,
        AmericanSamoa = 5,
        Andorra = 6,
        Angola = 7,
        Anguilla = 8,
        Antigua = 9,
        Argentina = 10,
        Armenia = 11,
        Aruba = 12,
        Australia = 13,
        Austria = 14,
        Azerbaijan = 15,
        Bahamas = 16,
        Bahrain = 17,
        Bangladesh = 18,
        Barbados = 19,
        Belarus = 20,
        Belgium = 21,
        Belize = 22,
        Benin = 23,
        Bermuda = 24,
        Bhutan = 25,
        Bolivia = 26,
        BosniaAndHerzegovina = 27,
        Botswana = 28,
        Brazil = 29,
        BritishVirginIslands = 30,
        Brunei = 31,
        Bulgaria = 32,
        BurkinaFaso = 33,
        Burundi = 34,
        Cambodia = 35,
        Cameroon = 36,
        Canada = 37,
        CapeVerde = 38,
        CaymanIslands = 39,
        CentralAfricanRepublic = 40,
        Chad = 41,
        Chile = 42,
        China = 43,
        CocosIslands = 44,
        Colombia = 45,
        Comoros = 46,
        Congo = 47,
        CookIslands = 48,
        CostaRica = 49,
        Croatia = 50,
        Cuba = 51,
        Cyprus = 52,
        CzechRepublic = 53,
        Denmark = 54,
        Djibouti = 55,
        Dominica = 56,
        DominicanRepublic = 57,
        DrCongo = 58,
        Ecuador = 59,
        Egypt = 60,
        ElSalvador = 61,
        EquatorialGuinea = 62,
        Eritrea = 63,
        Estonia = 64,
        Ethiopia = 65,
        FaeroeIslands = 66,
        FalklandIslands = 67,
        Fiji = 68,
        Finland = 69,
        France = 70,
        FrenchGuiana = 71,
        FrenchPolynesia = 72,
        Gabon = 73,
        Gambia = 74,
        Georgia = 75,
        Germany = 76,
        Ghana = 77,
        Gibraltar = 78,
        GreatBritain = 79,
        Greece = 80,
        Greenland = 81,
        Grenada = 82,
        Guadeloupe = 83,
        Guam = 84,
        Guatemala = 85,
        Guernsey = 86,
        Guinea = 87,
        GuineaBissau = 88,
        Guyana = 89,
        Haiti = 90,
        Honduras = 91,
        Hungary = 92,
        Iceland = 93,
        India = 94,
        Indonesia = 95,
        Iran = 96,
        Iraq = 97,
        Ireland = 98,
        IsleOfMan = 99,
        Israel = 100,
        Italy = 101,
        IvoryCoast = 102,
        Jamaica = 103,
        Japan = 104,
        Jersey = 105,
        Jordan = 106,
        Kazakhstan = 107,
        Kenya = 108,
        Kiribati = 109,
        Kuwait = 110,
        Kyrgyzstan = 111,
        Laos = 112,
        Latvia = 113,
        Lebanon = 114,
        Lesotho = 115,
        Liberia = 116,
        Libya = 117,
        Liechtenstein = 118,
        Lithuania = 119,
        Luxembourg = 120,
        Macao = 121,
        Macedonia = 122,
        Madagascar = 123,
        Malawi = 124,
        Malaysia = 125,
        Maldives = 126,
        Mali = 127,
        Malta = 128,
        MarshallIslands = 129,
        Martinique = 130,
        Mauritania = 131,
        Mauritius = 132,
        Mayotte = 133,
        Mexico = 134,
        Micronesia = 135,
        Moldova = 136,
        Monaco = 137,
        Mongolia = 138,
        Montenegro = 139,
        Montserrat = 140,
        Morocco = 141,
        Mozambique = 142,
        Namibia = 143,
        Nauru = 144,
        Nepal = 145,
        Netherlands = 146,
        NewCaledonia = 147,
        NewZealand = 148,
        Nicaragua = 149,
        Niger = 150,
        Nigeria = 151,
        Niue = 152,
        NorfolkIsland = 153,
        NorthKorea = 154,
        NorthernMarianaIslands = 155,
        Norway = 156,
        OccupiedPalestinianTerritory = 157,
        Oman = 158,
        Pakistan = 159,
        Palau = 160,
        Panama = 161,
        PapuaNewGuinea = 162,
        Paraguay = 163,
        Peru = 164,
        Philippines = 165,
        Pitcairn = 166,
        Poland = 167,
        Portugal = 168,
        PuertoRico = 169,
        Qatar = 170,
        ReunionIsland = 171,
        Romania = 172,
        Russia = 173,
        Rwanda = 174,
        SaintBarthelemy = 175,
        SaintMartinFrenchPart = 176,
        Samoa = 177,
        SanMarino = 178,
        SaoTomeAndPrincipe = 179,
        SaudiArabia = 180,
        Senegal = 181,
        Serbia = 182,
        Seychelles = 183,
        SierraLeone = 184,
        Singapore = 185,
        Slovakia = 186,
        Slovenia = 187,
        SolomonIslands = 188,
        Somalia = 189,
        SouthAfrica = 190,
        SouthKorea = 191,
        Spain = 192,
        SriLanka = 193,
        StHelena = 194,
        StKittsAndNevis = 195,
        StLucia = 196,
        StPierreAndMiquelon = 197,
        StVincent = 198,
        Sudan = 199,
        Suriname = 200,
        SvalbardAndJanMayen = 201,
        Swaziland = 202,
        Sweden = 203,
        Switzerland = 204,
        Syria = 205,
        Tajikistan = 206,
        Tanzania = 207,
        Thailand = 208,
        TimorLeste = 209,
        Togo = 210,
        Tokelau = 211,
        Tonga = 212,
        TrinidadAndTobago = 213,
        Tunisia = 214,
        Turkey = 215,
        Turkmenistan = 216,
        TurksAndCaicosIslands = 217,
        Tuvalu = 218,
        Uganda = 219,
        Ukraine = 220,
        UnitedArabEmirates = 221,
        Uruguay = 222,
        UsVirginIslands = 223,
        Usa = 224,
        Uzbekistan = 225,
        Vanuatu = 226,
        Venezuela = 227,
        Vietnam = 228,
        WallisAndFutuna = 229,
        WesternSahara = 230,
        Yemen = 231,
        Zambia = 232,
        Zimbabwe = 233,
    }

    public enum SystemCursor
    {
        MapDefault = 0,
        AppStarting = 1,
        Arrow = 2,
        Cross = 3,
        Help = 4,
        Beam = 5,
        No = 6,
        SizeAll = 7,
        SizeNesw = 8,
        SizeNs = 9,
        SizeNwse = 10,
        SizeWe = 11,
        UpArrow = 12,
        Wait = 13,
        UserDefined = 14,
        Hand = 15,
    }

    public enum ResizeBehavior
    {
        Classic = 0,
        Modern = 1,
        Intuitive = 2,
        Warp = 3,
        KeepScale = 4,
    }

    public enum UnitsOfMeasure
    {
        DecimalDegrees = 0,
        Milimeters = 1,
        Centimeters = 2,
        Inches = 3,
        Feets = 4,
        Yards = 5,
        Meters = 6,
        Miles = 7,
        Kilometers = 8,
    }

    public enum ZoomBarVerbosity
    {
        ZoomOnly = 0,
        Full = 1,
        None = 2,
    }

    public enum ScalebarUnits
    {
        Metric = 0,
        American = 1,
        GoogleStyle = 2,
    }

    public enum TileProvider
    {
        None = -1,
        OpenStreetMap = 0,
        OpenCycleMap = 1,
        OpenTransportMap = 2,
        BingMaps = 3,
        BingSatellite = 4,
        BingHybrid = 5,
        GoogleMaps = 6,
        GoogleSatellite = 7,
        GoogleHybrid = 8,
        GoogleTerrain = 9,
        HereMaps = 10,
        HereSatellite = 11,
        HereHybrid = 12,
        HereTerrain = 13,
        Rosreestr = 21,
        OpenHumanitarianMap = 22,
        MapQuestAerial = 23,
        ProviderCustom = 1024,
    }

    public enum FileOpenStrategy
    {
        NotSupported = -1,
        AutoDetect = 0,
        RgbImage = 1,
        DirectGrid = 2,
        ProxyForGrid = 3,
        VectorLayer = 4,
        VectorDatasource = 5,
    }

    public enum DeleteTarget
    {
        None = 0,
        Shape = 1,
        Part = 2,
        Vertex = 3,
    }

    public enum UndoOperation
    {
        AddShape = 0,
        RemoveShape = 1,
        EditShape = 2,
        MoveShapes = 3,
        RotateShapes = 4,
    }

    public enum MeasuringAction
    {
        PointAdded = 0,
        PointRemoved = 1,
        MesuringStopped = 2,
    }

    public enum AngleDisplay
    {
        Azimuth = 0,
        RussianRhumb = 1,
        ClockwiseBearing = 2,
        CounterClockwiseBearing = 3,
        None = 4,
    }

    public enum AreaDisplay
    {
        Metric = 0,
        Hectars = 1,
        None = 2,
    }

    public enum EditorBehavior
    {
        VertexEditor = 0,
        PartEditor = 1,
    }

    public enum EditorState
    {
        None = 0,
        Digitize = 1,
        Edit = 2,
        DigitizeUnbound = 3,
        Overlay = 4,
    }

    public enum LayerSelectionMode
    {
        AllLayers = 0,
        NoLayer = 1,
        ActiveLayer = 2,
    }

    public enum LengthDisplay
    {
        None = 0,
        Metric = 1,
    }

    public enum EditorValidation
    {
        Basic = 0,
        CheckWithGeos = 1,
        FixWithGeos = 2,
    }

    public enum EditorOverlay
    {
        AddPart = 0,
        RemovePart = 1,
    }

    public enum CacheType
    {
        Ram = 0,
        Disk = 1,
        Both = 2,
    }

    public enum TileProjection
    {
        SphericalMercator = 0,
        Amersfoort = 1,
    }

    public enum TileProjectionStatus
    {
        Native = 0,
        Compatible = 1,
        EmptyOrInvalid = 2,
    }

    public enum ProxyAuthentication
    {
        Basic = 0,
        Ntlm = 1,
    }

    public enum OpenStrategy
    {
        NotSupported = -1,
        AutoDetect = 0,
        RgbImage = 1,
        DirectGrid = 2,
        ProxyForGrid = 3,
        VectorLayer = 4,
        VectorDatasource = 5,
    }

    public enum SupportType
    {
        Gdal = 0,
        GdalOverviews = 1,
    }

    public enum SaveResult
    {
        NoChanges = 0,
        AllSaved = 1,
        SomeSaved = 2,
        NoneSaved = 3,
    }

    public enum SaveType
    {
        GeometryOnly = 0,
        AttributesOnly = 1,
        SaveAll = 2,
    }

    public enum LayerCapability
    {
        RandomRead = 0,
        SequentialWrite = 1,
        RandomWrite = 2,
        FastSpatialFilter = 3,
        FastFeatureCount = 4,
        FastGetExtent = 5,
        CreateField = 6,
        DeleteField = 7,
        ReorderFields = 8,
        AlterFieldDefn = 9,
        Transactions = 10,
        DeleteFeature = 11,
        FastSetNextByIndex = 12,
        StringsAsUtf8 = 13,
        IgnoreFields = 14,
        CreateGeomField = 15,
    }

    public enum VectorSourceType
    {
        Uninitialized = 0,
        File = 1,
        DbTable = 2,
        Query = 3,
    }

    public enum DatasourceCapability
    {
        CreateLayer = 0,
        DeleteLayer = 1,
        CreateGeomFieldAfterCreateLayer = 2,
        CreateDataSource = 3,
        DeleteDataSource = 4,
    }

    public enum ValidationMode
    {
        NoValidation = 0,
        TryFixProceedOnFailure = 1,
        TryFixSkipOnFailure = 2,
        TryFixAbortOnFailure = 3,
        AbortOnErrors = 4,
    }

    public enum GdalDriverMetadata
    {
        Longname = 0,
        Helptopic = 1,
        Mimetype = 2,
        Extension = 3,
        Extensions = 4,
        Creationoptionlist = 5,
        Openoptionlist = 6,
        Creationdatatypes = 7,
        Subdatasets = 8,
        Open = 9,
        Create = 10,
        Createcopy = 11,
        Virtualio = 12,
        LayerCreationoptionlist = 13,
        OgrDriver = 14,
    }

    public enum DataType
    {
        InvalidDataType = -1,
        ShortDataType = 0,
        LongDataType = 1,
        FloatDataType = 2,
        DoubleDataType = 3,
        UnknownDataType = 4,
        ByteDataType = 5,
    }

    public enum GridSourceType
    {
        Uninitialized = 0,
        GdalBased = 1,
        Native = 2,
    }

    public enum GridProxyMode
    {
        Auto = 0,
        UseProxy = 1,
        NoProxy = 2,
    }

    public enum GridFormat
    {
        InvalidGridFileType = -1,
        Ascii = 0,
        Binary = 1,
        Esri = 2,
        GeoTiff = 3,
        Sdts = 4,
        PAux = 5,
        PciDsk = 6,
        DTed = 7,
        Bil = 8,
        Ecw = 9,
        MrSid = 10,
        Flt = 11,
        Dem = 12,
        UseExtension = 13,
    }

    public enum GridSchemeRetrieval
    {
        Auto = 0,
        DiskBased = 1,
        DiskBasedForProxy = 2,
        GdalColorTable = 3,
    }

    public enum GridSchemeGeneration
    {
        Gradient = 0,
        UniqueValues = 1,
        UniqueValuesOrGradient = 2,
    }

    public enum GridColoringType
    {
        Hillshade = 0,
        Gradient = 1,
        Random = 2,
    }

    public enum GridGradientModel
    {
        Logorithmic = 0,
        Linear = 1,
        Exponential = 2,
    }

    public enum GdalError
    {
        None = 0,
        AppDefined = 1,
        OutOfMemory = 2,
        FileIo = 3,
        OpenFailed = 4,
        IllegalArg = 5,
        NotSupported = 6,
        AssertionFailed = 7,
        NoWriteAccess = 8,
        UserInterrupt = 9,
        ObjectNull = 10,
        Undefined = 11,
    }

    public enum GdalErrorType
    {
        None = 0,
        Debug = 1,
        Warning = 2,
        Failure = 3,
        Fatal = 4,
        Undefined = 5,
    }

    public enum LocalizedStrings
    {
        Hectars = 0,
        Meters = 1,
        Kilometers = 2,
        SquareKilometers = 3,
        SquareMeters = 4,
        MapUnits = 5,
        SquareMapUnits = 6,
        Miles = 7,
        Feet = 8,
        Latitude = 9,
        Longitude = 10,
    }

    public enum CollisionMode
    {
        AllowCollisions = 0,
        LocalList = 1,
        GlobalList = 2,
    }

    public enum GridProxyFormat
    {
        BmpProxy = 0,
        TiffProxy = 1,
    }

    public enum RasterOverviewCreation
    {
        Auto = 0,
        Yes = 1,
        No = 2,
    }

    public enum TiffCompression
    {
        Auto = -1,
        Jpeg = 0,
        Lzw = 1,
        Packbits = 2,
        Deflate = 3,
        Ccittrle = 4,
        Ccittfax3 = 5,
        Ccittfax4 = 6,
        None = 7,
    }

    public enum GdalResamplingMethod
    {
        None = 0,
        Nearest = 1,
        Gauss = 2,
        Bicubic = 3,
        Average = 4,
    }

    public enum OgrEncoding
    {
        Utf8 = 0,
        Ansi = 1,
    }

    public enum PixelOffsetMode
    {
        Default = 0,
        HighPerformance = 1,
        HighQuality = 2,
    }

    public enum MapSelectionMode
    {
        Intersection = 0,
        Inclusion = 1,
    }

    public enum DiagramType
    {
        Bar = 0,
        Pie = 1,
    }

    public enum DiagramValuesStyle
    {
        Horizontal = 0,
        Vertical = 1,
    }

    public enum IdentifierMode
    {
        AllLayers = 0,
        SingleLayer = 1,
        AllLayerStopOnFirst = 2,
    }

    public enum MeasuringType
    {
        Distance = 0,
        Area = 1,
    }

    public enum LineType
    {
        Simple = 0,
        Marker = 1,
    }

    public enum GroupOperation
    {
        Sum = 0,
        Min = 1,
        Max = 2,
        Avg = 3,
        WeightedAvg = 4,
        Mode = 5,
    }

    public enum FieldOperationValidity
    {
        Valid = 0,
        FieldNotFound = 1,
        NotSupported = 2,
    }

    public enum ValidationType
    {
        Input = 0,
        Output = 1,
    }

    public enum ValidationStatus
    {
        WasntValidated = 0,
        Valid = 1,
        InvalidFixed = 2,
        InvalidSkipped = 3,
        InvalidReturned = 4,
        OperationAborted = 5,
    }

    public enum ZoomBehavior
    {
        Default = 0,
        UseTileLevels = 1,
    }

    public enum CoordinatesDisplay
    {
        None = 0,
        Auto = 1,
        Degrees = 2,
        MapUnits = 3,
    }

    public enum RedrawType
    {
        All = 1,
        SkipDataLayers = 2,
        Minimal = 3,
        SkipAllLayers = 4,
    }

    public enum DrawReferenceList
    {
        ScreenReferencedList = 0,
        SpatiallyReferencedList = 1,
    }

    public enum TableValueType
    {
        Double = 0,
        String = 1,
        Boolean = 2,
        FloatArray = 3,
    }

    /// <summary>
    /// Defines the operation that will be used to update the existing selection
    /// </summary>
    public enum SelectionOperation
    {
        New = 0,          // old selection will be lost
        Add = 1,          // new shapes will be added to the old selection
        Exclude = 2,      // new shapes will be excluded from old selection
        Invert = 3        // bew shapes will be inverted in case they are in the existing selection
    }
}
