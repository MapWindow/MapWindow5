// ********************************************************************************************************
// <copyright file="frmUpdateMeasurements.cs" company="TopX Geo-ICT">
//     Copyright (c) 2012 TopX Geo-ICT. All rights reserved.
// </copyright>
// ********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version is Paul Meems.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 May 2012    Paul Meems      Inital coding
// ********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.utils;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>The form to update the area, perimeter and length fields</summary>
  public partial class UpdateMeasurementsForm : Form
  {
    /// <summary>The current shapefile</summary>
    private readonly ShapefileWrapper boShapefile;

    /// <summary>The units of measurements</summary>
    private readonly UnitsOfMeasurement unitsOfMeasurement;

    /// <summary>The datatable with shapedata</summary>
    private readonly DataTable dt;

    /// <summary>What is the shapefile type</summary>
    private short shapefileType;

    /// <summary>Initializes a new instance of the <see cref="UpdateMeasurementsForm"/> class.</summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="shapefile">The shapefile.</param>
    public UpdateMeasurementsForm(DataTable dataTable, ShapefileWrapper shapefile)
    {
      InitializeComponent();

      this.dt = dataTable;

      this.boShapefile = shapefile;

      this.unitsOfMeasurement = new UnitsOfMeasurement();

      this.InitForm();
    }

    /// <summary>Initialize the form</summary>
    private void InitForm()
    {
      this.GetShapefileType();

      // Set labels:
      this.lblLayername.Text = string.Format("Layer name: {0}", this.boShapefile.ShapefileName);
      var geoprojection = this.boShapefile.ShapeFile.GeoProjection;
      this.lblProjection.Text = string.Format("Projection: {0}", geoprojection.Name);
      this.lblShapefileUnits.Text = string.Format("Units: {0}", this.unitsOfMeasurement.GetUnitsFromProj4(geoprojection.ExportToProj4()));

      // Show group boxes:
      this.AreaGroupbox.Visible = this.shapefileType == 1;
      this.PerimeterGroupbox.Visible = this.shapefileType == 1;
      if (this.shapefileType == 2)
      {
        this.LengthGroupbox.Visible = true;

        // Move group box to location"
        this.LengthGroupbox.Location = this.AreaGroupbox.Location;
      }

      // Fill Comboboxes and set RadioButtons:
      var fields = this.GetFields();

      // Area
      var selectedArea = FillCombobox(this.AreaAttributesCombo, fields, "area");
      SetRadioButton(selectedArea, this.AreaNewRadio, this.AreaExistingRadio);

      // Perimeter
      var selectedPerimeter = FillCombobox(this.PerimeterAttributesCombo, fields, "perimeter");
      SetRadioButton(selectedPerimeter, this.PerimeterNewRadio, this.PerimeterExistingRadio);

      // Length
      var selectedLength = FillCombobox(this.LengthAttributesCombo, fields, "length");
      SetRadioButton(selectedLength, this.LengthNewRadio, this.LengthExistingRadio);
      if (this.shapefileType == 1)
      {
        this.LengthNoneRadio.Checked = true;
      }

      this.FillCalculatedUnits();
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
    private static void SetRadioButton(int selectedValue, RadioButton radioButtonNew, RadioButton radioButtonExisting)
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
      switch (this.boShapefile.ShapeFile.ShapefileType)
      {
        case ShpfileType.SHP_POLYGON:
        case ShpfileType.SHP_POLYGONM:
        case ShpfileType.SHP_POLYGONZ:
          this.shapefileType = 1;
          break;
        case ShpfileType.SHP_POLYLINE:
        case ShpfileType.SHP_POLYLINEM:
        case ShpfileType.SHP_POLYLINEZ:
          this.shapefileType = 2;
          break;
        default:
          this.shapefileType = 0;
          break;
      }
    }

    /// <summary>Fill the calcutated units combobox</summary>
    private void FillCalculatedUnits()
    {
      try
      {
        if (this.shapefileType == 2)
        {
          // Polylines
          string[] cboItems = 
                    {
                        "Centimeters", "Feet", "Inches", "Kilometers", "Meters", "Miles",
                        "Millimeters", "Yards"
                    };
          this.CalculateUnitsCombo.DataSource = cboItems;
          this.CalculateUnitsCombo.SelectedIndex = 4; // Meters
        }
        else
        {
          // Polygons
          string[] cboItems = 
                    {
                        "Acres", "Centimeters Squared", "Feet Squared", "Hectares", "Inches Squared", 
                        "Kilometers Squared", "Meters Squared", "Miles Squared", "Millimeters Squared", "Yards Squared"
                    };
          this.CalculateUnitsCombo.DataSource = cboItems;
          this.CalculateUnitsCombo.SelectedIndex = 3; // Hectares;
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
      for (var i = 0; i < this.boShapefile.ShapeFile.NumFields; i++)
      {
        var field = this.boShapefile.ShapeFile.get_Field(i);
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
      if (!this.AreaNoneRadio.Checked)
      {
        var selectedItem = string.Empty;
        if (this.AreaAttributesCombo.SelectedItem != null)
        {
          selectedItem = this.AreaAttributesCombo.SelectedItem.ToString();
        }

        this.CalculateMeasurement(
            UnitsOfMeasurement.MeasurementTypes.Area,
            selectedItem,
            this.AreaNewRadio.Checked,
            this.AreaNewText.Text,
            (int)Math.Round(this.AreaPrecision.Value),
            (int)Math.Round(this.AreaWidth.Value));
      }

      if (!this.PerimeterNoneRadio.Checked)
      {
        var selectedItem = string.Empty;
        if (this.PerimeterAttributesCombo.SelectedItem != null)
        {
          selectedItem = this.PerimeterAttributesCombo.SelectedItem.ToString();
        }

        this.CalculateMeasurement(
            UnitsOfMeasurement.MeasurementTypes.Perimeter,
            selectedItem,
            this.PerimeterNewRadio.Checked,
            this.PerimeterNewText.Text,
            (int)Math.Round(this.PerimeterPrecision.Value),
            (int)Math.Round(this.PerimeterWidth.Value));
      }

      if (!this.LengthNoneRadio.Checked)
      {
        var selectedItem = string.Empty;
        if (this.LengthAttributesCombo.SelectedItem != null)
        {
          selectedItem = this.LengthAttributesCombo.SelectedItem.ToString();
        }

        this.CalculateMeasurement(
            UnitsOfMeasurement.MeasurementTypes.Length,
            selectedItem,
            this.LengthNewRadio.Checked,
            this.LengthNewText.Text,
            (int)Math.Round(this.LengthPrecision.Value),
            (int)Math.Round(this.LengthWidth.Value));
      }

      // Done
      this.progressBar1.Value = this.progressBar1.Maximum;
      this.progressBar1.Refresh();

      // Close the form:
      this.Close();
    }

    /// <summary>Calculate the area, perimeter or length</summary>
    /// <param name="measurementType">The measurement type.</param>
    /// <param name="currentFieldname">The current fieldname.</param>
    /// <param name="newField">Create a new field.</param>
    /// <param name="newFieldName">The new field name.</param>
    /// <param name="precision">The precision.</param>
    /// <param name="width">The width.</param>
    private void CalculateMeasurement(UnitsOfMeasurement.MeasurementTypes measurementType
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
            this.dt,
            newFieldName,
            "Double",
            precision.ToString(),
            width);
        columnID = this.dt.Columns.Count - 1;
      }
      else
      {
        columnID = this.boShapefile.ShapeFile.Table.get_FieldIndexByName(currentFieldname) + 1;
      }

      this.Calculate(measurementType, columnID, precision);
    }

    /// <summary>The calculate method.</summary>
    /// <param name="measurementType">What to calculate.</param>
    /// <param name="fieldIndex">The field index.</param>
    /// <param name="fieldPrecision">The field precision.</param>
    public void Calculate(
        UnitsOfMeasurement.MeasurementTypes measurementType,
        int fieldIndex,
        int fieldPrecision)
    {
      try
      {
        // Use units:
        this.unitsOfMeasurement.MeasurementType = measurementType;
        var shapefileUnits = this.lblShapefileUnits.Text.Replace("Units: ", string.Empty).Trim();
        this.unitsOfMeasurement.MapUnits = this.unitsOfMeasurement.StringToUom(shapefileUnits);
        var orgMapUnits = this.unitsOfMeasurement.MapUnits;
        this.unitsOfMeasurement.CalculatedUnits = this.unitsOfMeasurement.StringToUom(this.CalculateUnitsCombo.SelectedItem.ToString());

        var utils = new Utils();
        var numShapes = this.boShapefile.ShapeFile.NumShapes;

        // Init progress bar:
        this.progressBar1.Minimum = 0;
        this.progressBar1.Maximum = numShapes;
        this.progressBar1.Value = 0;
        this.progressBar1.Step = 10;

        var reprojectShapefile = new Shapefile();
        var useOldCalculation = false;
        if (this.unitsOfMeasurement.MapUnits == UnitsOfMeasurement.UnitOfArea.DecimalDegrees)
        {
          reprojectShapefile = ReprojectShapefileToUtm(this.boShapefile.ShapeFile);

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
          this.unitsOfMeasurement.MapUnits = orgMapUnits;

          if (measurementType == UnitsOfMeasurement.MeasurementTypes.Length)
          {
            if (this.unitsOfMeasurement.MapUnits == UnitsOfMeasurement.UnitOfArea.DecimalDegrees)
            {
              // Use the intermediate reprojected to UTM shapefile:
              if (useOldCalculation)
              {
                // Issue #2302: Null shape generates exception:
                var shp = this.boShapefile.ShapeFile.get_Shape(i);
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
                this.unitsOfMeasurement.MapUnits = UnitsOfMeasurement.UnitOfArea.Meters;
              }
            }
            else
            {
              // Issue #2302: Null shape generates exception:
              var shp = this.boShapefile.ShapeFile.get_Shape(i);
              if (shp == null)
              {
                continue;
              }

              measurement = shp.Length;
            }
          }

          if (measurementType == UnitsOfMeasurement.MeasurementTypes.Area)
          {
            if (this.unitsOfMeasurement.MapUnits == UnitsOfMeasurement.UnitOfArea.DecimalDegrees)
            {
              // Use the intermediate reprojected to UTM shapefile:                         
              if (useOldCalculation)
              {
                // Issue #2302: Null shape generates exception:
                var shp = this.boShapefile.ShapeFile.get_Shape(i);
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
                this.unitsOfMeasurement.MapUnits = UnitsOfMeasurement.UnitOfArea.Meters;
              }
            }
            else
            {
              // Issue #2302: Null shape generates exception:
              var shp = this.boShapefile.ShapeFile.get_Shape(i);
              if (shp == null)
              {
                continue;
              }

              measurement = shp.Area;
            }
          }

          if (measurementType == UnitsOfMeasurement.MeasurementTypes.Perimeter)
          {
            if (this.unitsOfMeasurement.MapUnits == UnitsOfMeasurement.UnitOfArea.DecimalDegrees)
            {
              // Use the intermediate reprojected to UTM shapefile:
              if (useOldCalculation)
              {
                // Issue #2302: Null shape generates exception:
                var shp = this.boShapefile.ShapeFile.get_Shape(i);
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
                this.unitsOfMeasurement.MapUnits = UnitsOfMeasurement.UnitOfArea.Meters;
              }
            }
            else
            {
              // Issue #2302: Null shape generates exception:
              var shp = this.boShapefile.ShapeFile.get_Shape(i);
              if (shp == null)
              {
                continue;
              }

              measurement = utils.get_Perimeter(shp);
            }
          }

          // Use units:
          measurement = this.unitsOfMeasurement.ConvertUnits(measurement);

          // Round value:
          measurement = Math.Round(measurement, fieldPrecision);
          this.dt.Rows[i][fieldIndex] = measurement;

          if (i % this.progressBar1.Step == 0)
          {
            this.progressBar1.PerformStep();
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

      var utmZone = (int)Math.Ceiling((longitude + 180) / 6);
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
        const double Flattening = 1 / 298.257223563;
        const double Equatorialradius = 6378.137; // km

        // Convert to radials:
        var lat1 = Deg2Rad(latP1);
        var lon1 = Deg2Rad(longP1);
        var lat2 = Deg2Rad(latP2);
        var lon2 = Deg2Rad(longP2);

        var F = (lat1 + lat2) / 2.0;
        var G = (lat1 - lat2) / 2.0;
        var L = (lon1 - lon2) / 2.0;

        var sinG = Math.Sin(G);
        var cosG = Math.Cos(G);
        var sinL = Math.Sin(L);
        var cosL = Math.Cos(L);
        var sinF = Math.Sin(F);
        var cosF = Math.Cos(F);

        var S = sinG * sinG * cosL * cosL + cosF * cosF * sinL * sinL;
        var C = cosG * cosG * cosL * cosL + sinF * sinF * sinL * sinL;
        var W = Math.Atan2(Math.Sqrt(S), Math.Sqrt(C));
        var R = Math.Sqrt(S * C) / W;
        var H1 = (3 * R - 1.0) / (2.0 * C);
        var H2 = (3 * R + 1.0) / (2.0 * S);
        var D = 2 * W * Equatorialradius;
        var distance = D *
                       (1 + Flattening * H1 * sinF * sinF * cosG * cosG
                        - Flattening * H2 * cosF * cosF * sinG * sinG);

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
      return deg * Math.PI / 180.0;
    }
  }
}
