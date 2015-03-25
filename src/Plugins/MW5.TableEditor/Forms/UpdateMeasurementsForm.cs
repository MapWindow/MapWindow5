using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Utils;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>The form to update the area, perimeter and length fields</summary>
    public partial class UpdateMeasurementsForm : MapWindowForm
    {
        /// <summary>What is the shapefile type</summary>
        private short _shapefileType;

        /// <summary>The current shapefile</summary>
        private readonly ShapefileWrapper _boShapefile;

        /// <summary>The datatable with shapedata</summary>
        private readonly DataTable _dt;

        /// <summary>The units of measurements</summary>
        private readonly UnitsOfMeasurement _unitsOfMeasurement;

        /// <summary>Initializes a new instance of the <see cref="UpdateMeasurementsForm"/> class.</summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="shapefile">The shapefile.</param>
        public UpdateMeasurementsForm(DataTable dataTable, ShapefileWrapper shapefile)
        {
            InitializeComponent();

            _dt = dataTable;

            _boShapefile = shapefile;

            _unitsOfMeasurement = new UnitsOfMeasurement();

            InitForm();
        }

        /// <summary>Initialize the form</summary>
        private void InitForm()
        {
            GetShapefileType();

            // Set labels:
            lblLayername.Text = string.Format("Layer name: {0}", _boShapefile.ShapefileName);
            var geoprojection = _boShapefile.Shapefile.GeoProjection;
            lblProjection.Text = string.Format("Projection: {0}", geoprojection.Name);
            lblShapefileUnits.Text = string.Format("Units: {0}",
                _unitsOfMeasurement.GetUnitsFromProj4(geoprojection.ExportToProj4()));

            // Show group boxes:
            AreaGroupbox.Visible = _shapefileType == 1;
            PerimeterGroupbox.Visible = _shapefileType == 1;
            if (_shapefileType == 2)
            {
                LengthGroupbox.Visible = true;

                // Move group box to location"
                LengthGroupbox.Location = AreaGroupbox.Location;
            }

            // Fill Comboboxes and set RadioButtons:
            var fields = GetFields();

            // Area
            var selectedArea = FillCombobox(AreaAttributesCombo, fields, "area");
            SetRadioButton(selectedArea, AreaNewRadio, AreaExistingRadio);

            // Perimeter
            var selectedPerimeter = FillCombobox(PerimeterAttributesCombo, fields, "perimeter");
            SetRadioButton(selectedPerimeter, PerimeterNewRadio, PerimeterExistingRadio);

            // Length
            var selectedLength = FillCombobox(LengthAttributesCombo, fields, "length");
            SetRadioButton(selectedLength, LengthNewRadio, LengthExistingRadio);
            if (_shapefileType == 1)
            {
                LengthNoneRadio.Checked = true;
            }

            FillCalculatedUnits();
        }

        /// <summary>Fill Combobox</summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="fieldName">The field name.</param>
        /// <returns>The selected value</returns>
        private static int FillCombobox(ComboBox comboBox, IEnumerable<Field> fields, string fieldName)
        {
            var selectedValue = -1;
            comboBox.Items.Clear();

            // Fill combobox:
            foreach (var field in fields.Where(field => field.Type == FieldType.DOUBLE_FIELD))
            {
                comboBox.Items.Add(field.Name);
                if (field.Name.ToLower() == fieldName)
                {
                    selectedValue = comboBox.Items.Count - 1;
                }
            }

            comboBox.SelectedIndex = selectedValue;
            return selectedValue;
        }

        /// <summary>Set radio button</summary>
        /// <param name="selectedValue">The selected value.</param>
        /// <param name="radioButtonNew">The radio button new.</param>
        /// <param name="radioButtonExisting">The radio button existing.</param>
        private static void SetRadioButton(int selectedValue, RadioButton radioButtonNew,
            RadioButton radioButtonExisting)
        {
            // Set radio buttons:
            if (selectedValue == -1)
            {
                radioButtonNew.Checked = true;
            }
            else
            {
                radioButtonExisting.Checked = true;
            }
        }

        /// <summary>Get the shapefile type</summary>
        private void GetShapefileType()
        {
            switch (_boShapefile.Shapefile.ShapefileType)
            {
                case ShpfileType.SHP_POLYGON:
                case ShpfileType.SHP_POLYGONM:
                case ShpfileType.SHP_POLYGONZ:
                    _shapefileType = 1;
                    break;
                case ShpfileType.SHP_POLYLINE:
                case ShpfileType.SHP_POLYLINEM:
                case ShpfileType.SHP_POLYLINEZ:
                    _shapefileType = 2;
                    break;
                default:
                    _shapefileType = 0;
                    break;
            }
        }

        /// <summary>Fill the calcutated units combobox</summary>
        private void FillCalculatedUnits()
        {
            try
            {
                if (_shapefileType == 2)
                {
                    // Polylines
                    string[] cboItems =
                    {
                        "Centimeters", "Feet", "Inches", "Kilometers", "Meters", "Miles",
                        "Millimeters", "Yards"
                    };
                    CalculateUnitsCombo.DataSource = cboItems;
                    CalculateUnitsCombo.SelectedIndex = 4; // Meters
                }
                else
                {
                    // Polygons
                    string[] cboItems =
                    {
                        "Acres", "Centimeters Squared", "Feet Squared", "Hectares", "Inches Squared",
                        "Kilometers Squared", "Meters Squared", "Miles Squared", "Millimeters Squared", "Yards Squared"
                    };
                    CalculateUnitsCombo.DataSource = cboItems;
                    CalculateUnitsCombo.SelectedIndex = 3; // Hectares;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in fillCalculatedUnits: " + ex);
            }
        }

        /// <summary>Gets all the fields of a shapefile</summary>
        /// <returns>A list with the fields</returns>
        private IEnumerable<Field> GetFields()
        {
            var fields = new List<Field>();
            for (var i = 0; i < _boShapefile.Shapefile.NumFields; i++)
            {
                var field = _boShapefile.Shapefile.get_Field(i);
                fields.Add(field);
            }

            return fields;
        }

        /// <summary>Click event of update button</summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private void BtnUpdateClick(object sender, EventArgs e)
        {
            // Calculate or not:
            if (!AreaNoneRadio.Checked)
            {
                var selectedItem = string.Empty;
                if (AreaAttributesCombo.SelectedItem != null)
                {
                    selectedItem = AreaAttributesCombo.SelectedItem.ToString();
                }

                CalculateMeasurement(
                    MeasurementTypes.Area,
                    selectedItem,
                    AreaNewRadio.Checked,
                    AreaNewText.Text,
                    (int) Math.Round(AreaPrecision.Value),
                    (int) Math.Round(AreaWidth.Value));
            }

            if (!PerimeterNoneRadio.Checked)
            {
                var selectedItem = string.Empty;
                if (PerimeterAttributesCombo.SelectedItem != null)
                {
                    selectedItem = PerimeterAttributesCombo.SelectedItem.ToString();
                }

                CalculateMeasurement(
                    MeasurementTypes.Perimeter,
                    selectedItem,
                    PerimeterNewRadio.Checked,
                    PerimeterNewText.Text,
                    (int) Math.Round(PerimeterPrecision.Value),
                    (int) Math.Round(PerimeterWidth.Value));
            }

            if (!LengthNoneRadio.Checked)
            {
                var selectedItem = string.Empty;
                if (LengthAttributesCombo.SelectedItem != null)
                {
                    selectedItem = LengthAttributesCombo.SelectedItem.ToString();
                }

                CalculateMeasurement(
                    MeasurementTypes.Length,
                    selectedItem,
                    LengthNewRadio.Checked,
                    LengthNewText.Text,
                    (int) Math.Round(LengthPrecision.Value),
                    (int) Math.Round(LengthWidth.Value));
            }

            // Done
            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Refresh();

            // Close the form:
            Close();
        }

        /// <summary>Calculate the area, perimeter or length</summary>
        /// <param name="measurementType">The measurement type.</param>
        /// <param name="currentFieldname">The current fieldname.</param>
        /// <param name="newField">Create a new field.</param>
        /// <param name="newFieldName">The new field name.</param>
        /// <param name="precision">The precision.</param>
        /// <param name="width">The width.</param>
        private void CalculateMeasurement(MeasurementTypes measurementType
            , string currentFieldname, bool newField, string newFieldName, int precision, int width)
        {
            int columnID;

            // Create new field?
            if (newField)
            {
                if (string.IsNullOrEmpty(newFieldName))
                {
                    MessageBox.Show(@"The new field name wasn't correct. Do that first");
                    return;
                }

                ShapeData.AddDataColumn(
                    _dt,
                    newFieldName,
                    "Double",
                    precision.ToString(),
                    width);
                columnID = _dt.Columns.Count - 1;
            }
            else
            {
                columnID = _boShapefile.Shapefile.Table.get_FieldIndexByName(currentFieldname) + 1;
            }

            Calculate(measurementType, columnID, precision);
        }

        /// <summary>The calculate method.</summary>
        /// <param name="measurementType">What to calculate.</param>
        /// <param name="fieldIndex">The field index.</param>
        /// <param name="fieldPrecision">The field precision.</param>
        public void Calculate(MeasurementTypes measurementType,
            int fieldIndex,
            int fieldPrecision)
        {
            try
            {
                // Use units:
                _unitsOfMeasurement.MeasurementType = measurementType;
                var shapefileUnits = lblShapefileUnits.Text.Replace("Units: ", string.Empty).Trim();
                _unitsOfMeasurement.MapUnits = _unitsOfMeasurement.StringToUom(shapefileUnits);
                var orgMapUnits = _unitsOfMeasurement.MapUnits;
                _unitsOfMeasurement.CalculatedUnits =
                    _unitsOfMeasurement.StringToUom(CalculateUnitsCombo.SelectedItem.ToString());

                var utils = new MapWinGIS.Utils();
                var numShapes = _boShapefile.Shapefile.NumShapes;

                // Init progress bar:
                progressBar1.Minimum = 0;
                progressBar1.Maximum = numShapes;
                progressBar1.Value = 0;
                progressBar1.Step = 10;

                var reprojectShapefile = new Shapefile();
                var useOldCalculation = false;
                if (_unitsOfMeasurement.MapUnits == UnitOfArea.DecimalDegrees)
                {
                    reprojectShapefile = ReprojectShapefileToUtm(_boShapefile.Shapefile);

                    // If the reprojected shapefile has less shapes than the original,
                    // it means the data spans more than 1 UTM zone.
                    // In that case use the old calculation methods:
                    if (reprojectShapefile.NumShapes < numShapes)
                    {
                        useOldCalculation = true;
                    }
                }

                for (var i = 0; i < numShapes; i++)
                {
                    var measurement = 0.0;

                    // Reset map units because it might have been changed in the reprojection option:
                    _unitsOfMeasurement.MapUnits = orgMapUnits;

                    if (measurementType == MeasurementTypes.Length)
                    {
                        if (_unitsOfMeasurement.MapUnits == UnitOfArea.DecimalDegrees)
                        {
                            // Use the intermediate reprojected to UTM shapefile:
                            if (useOldCalculation)
                            {
                                // Issue #2302: Null shape generates exception:
                                var shp = _boShapefile.Shapefile.get_Shape(i);
                                if (shp == null)
                                {
                                    continue;
                                }

                                measurement = GetLenghtLatLong(shp);
                            }
                            else
                            {
                                // Issue #2302: Null shape generates exception:
                                var shp = reprojectShapefile.get_Shape(i);
                                if (shp == null)
                                {
                                    continue;
                                }

                                measurement = shp.Length;
                                _unitsOfMeasurement.MapUnits = UnitOfArea.Meters;
                            }
                        }
                        else
                        {
                            // Issue #2302: Null shape generates exception:
                            var shp = _boShapefile.Shapefile.get_Shape(i);
                            if (shp == null)
                            {
                                continue;
                            }

                            measurement = shp.Length;
                        }
                    }

                    if (measurementType == MeasurementTypes.Area)
                    {
                        if (_unitsOfMeasurement.MapUnits == UnitOfArea.DecimalDegrees)
                        {
                            // Use the intermediate reprojected to UTM shapefile:                         
                            if (useOldCalculation)
                            {
                                // Issue #2302: Null shape generates exception:
                                var shp = _boShapefile.Shapefile.get_Shape(i);
                                if (shp == null)
                                {
                                    continue;
                                }

                                // TODO: restore
                                //measurement = MapWinGeoProc.Utils.Area(ref shp, UnitOfMeasure.DecimalDegrees);
                            }
                            else
                            {
                                // Issue #2302: Null shape generates exception:
                                var shp = reprojectShapefile.get_Shape(i);
                                if (shp == null)
                                {
                                    continue;
                                }

                                measurement = shp.Area;
                                _unitsOfMeasurement.MapUnits = UnitOfArea.Meters;
                            }
                        }
                        else
                        {
                            // Issue #2302: Null shape generates exception:
                            var shp = _boShapefile.Shapefile.get_Shape(i);
                            if (shp == null)
                            {
                                continue;
                            }

                            measurement = shp.Area;
                        }
                    }

                    if (measurementType == MeasurementTypes.Perimeter)
                    {
                        if (_unitsOfMeasurement.MapUnits == UnitOfArea.DecimalDegrees)
                        {
                            // Use the intermediate reprojected to UTM shapefile:
                            if (useOldCalculation)
                            {
                                // Issue #2302: Null shape generates exception:
                                var shp = _boShapefile.Shapefile.get_Shape(i);
                                if (shp == null)
                                {
                                    continue;
                                }

                                measurement = GetLenghtLatLong(shp);
                            }
                            else
                            {
                                // Issue #2302: Null shape generates exception:
                                var shp = reprojectShapefile.get_Shape(i);
                                if (shp == null)
                                {
                                    continue;
                                }

                                measurement = utils.get_Perimeter(shp);
                                _unitsOfMeasurement.MapUnits = UnitOfArea.Meters;
                            }
                        }
                        else
                        {
                            // Issue #2302: Null shape generates exception:
                            var shp = _boShapefile.Shapefile.get_Shape(i);
                            if (shp == null)
                            {
                                continue;
                            }

                            measurement = utils.get_Perimeter(shp);
                        }
                    }

                    // Use units:
                    measurement = _unitsOfMeasurement.ConvertUnits(measurement);

                    // Round value:
                    measurement = Math.Round(measurement, fieldPrecision);
                    _dt.Rows[i][fieldIndex] = measurement;

                    if (i%progressBar1.Step == 0)
                    {
                        progressBar1.PerformStep();
                        Application.DoEvents();
                    }
                }

                reprojectShapefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in Calculate {0}: \n{1}", measurementType, ex.Message), ex);
            }
        }

        /// <summary>Reproject to UTM</summary>
        /// <param name="sf">The shapefile</param>
        /// <returns>The reprojeted shapefile</returns>
        private static Shapefile ReprojectShapefileToUtm(IShapefile sf)
        {
            // Get UTM zone:
            var utmProjection = GetUtmZoneProjection(sf.Extents.xMin);

            var count = 0;
            var reprojectShapefile = sf.Reproject(utmProjection, ref count);
            if (reprojectShapefile == null)
            {
                throw new Exception("The reproject result is null: " + sf.get_ErrorMsg(sf.LastErrorCode));
            }

            if (count == 0)
            {
                var globalSettings = new GlobalSettings();
                throw new Exception("No shapes have been reprojected: " + globalSettings.GdalReprojectionErrorMsg);
            }

            return reprojectShapefile;
        }

        /// <summary>Get the UTm projection based on the longitude</summary>
        /// <param name="longitude">The longitude.</param>
        /// <returns>The UTM projection</returns>
        private static GeoProjection GetUtmZoneProjection(double longitude)
        {
            var utmProjection = new GeoProjection();

            var utmZone = (int) Math.Ceiling((longitude + 180)/6);
            var utmProjectionstring = "+proj=utm +zone=" + utmZone + " +datum=WGS84";
            if (!utmProjection.ImportFromProj4(utmProjectionstring))
            {
                throw new Exception("Failed to initialize new projection");
            }

            return utmProjection;
        }

        /// <summary>Calculate the length of a line in degrees</summary>
        /// <param name="line">The line.</param>
        /// <returns>The length in meters</returns>
        private static double GetLenghtLatLong(IShape line)
        {
            // Loop trough all linestrings and determin length            
            try
            {
                double length = 0;

                // -2 else out of bounds!!
                for (var i = 0; i <= line.numPoints - 2; i++)
                {
                    length += LatLongDistance(
                        line.get_Point(i).x, line.get_Point(i).y, line.get_Point(i + 1).x, line.get_Point(i + 1).y);
                }

                return length;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetLenghtLatLong: \n" + ex);
            }
        }

        /// <summary>The lat long distance. </summary>
        /// <param name="longP1">The first longitude </param>
        /// <param name="latP1">The first latitude</param>
        /// <param name="longP2">The second longitude</param>
        /// <param name="latP2">The second latitude</param>
        /// <returns>The distance in lat long.</returns>
        private static double LatLongDistance(double longP1, double latP1, double longP2, double latP2)
        {
            try
            {
                // http:// Www.uwgb.edu/dutchs/UsefulData/UTMFormulas.HTM  
                // http:// Www.csgnetwork.com/gpsdistcalc.html  
                // Constants, assume WGS84/NAD83:
                const double Flattening = 1/298.257223563;
                const double Equatorialradius = 6378.137; // km

                // Convert to radials:
                var lat1 = Deg2Rad(latP1);
                var lon1 = Deg2Rad(longP1);
                var lat2 = Deg2Rad(latP2);
                var lon2 = Deg2Rad(longP2);

                var F = (lat1 + lat2)/2.0;
                var G = (lat1 - lat2)/2.0;
                var L = (lon1 - lon2)/2.0;

                var sinG = Math.Sin(G);
                var cosG = Math.Cos(G);
                var sinL = Math.Sin(L);
                var cosL = Math.Cos(L);
                var sinF = Math.Sin(F);
                var cosF = Math.Cos(F);

                var S = sinG*sinG*cosL*cosL + cosF*cosF*sinL*sinL;
                var C = cosG*cosG*cosL*cosL + sinF*sinF*sinL*sinL;
                var W = Math.Atan2(Math.Sqrt(S), Math.Sqrt(C));
                var R = Math.Sqrt(S*C)/W;
                var H1 = (3*R - 1.0)/(2.0*C);
                var H2 = (3*R + 1.0)/(2.0*S);
                var D = 2*W*Equatorialradius;
                var distance = D*
                               (1 + Flattening*H1*sinF*sinF*cosG*cosG
                                - Flattening*H2*cosF*cosF*sinG*sinG);

                return distance;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LLDistance: \n" + ex);
            }
        }

        /// <summary>Convert degree to radials.</summary>
        /// <param name="deg">The degree.</param>
        /// <returns>The value in radials. </returns>
        private static double Deg2Rad(double deg)
        {
            return deg*Math.PI/180.0;
        }
    }
}