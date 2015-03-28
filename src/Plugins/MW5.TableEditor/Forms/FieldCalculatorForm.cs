// ********************************************************************************************************
// <copyright file="frmFieldCalculator.cs" company="TopX Geo-ICT">
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
// The Initial Developer of this version is Jeen de Vegt.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 March 2012  Jeen de Vegt    Inital coding
// ********************************************************************************************************

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Legacy;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
  ///  Form-class for performing calculations
  /// </summary>
  public partial class FieldCalculatorForm : MapWindowForm
  {
    /// <summary>Values to show on form</summary>
    private static string _pntShape = "ShapeX ShapeY ShapeZ";

    /// <summary>Values to show on form</summary>
    private static string _polyShape = "ShapeXFirst ShapeYFirst ShapeZFirst ShapeXLast ShapeYLast ShapeZLast";

    /// <summary>Values to show on form</summary>
    private static string _oper = "+ - * / % \\ ^ |x| ! > >= < <= = <>";

    /// <summary>Values to show on form</summary>
    private static string _boolOp = "and or not xor nand nor nxor";

    /// <summary>Values to show on form</summary>
    private static string _gonFun = "atn(x) cos(x) sin(x) tan(x) acos(x) asin(x) cosh(x) sinh(x) tanh(x) acosh(x) asinh(x) atanh(x) csc(x) sec(x) cot(x) acsc(x) asec(x) acot(x) csch(x) sech(x) coth(x) acsch(x) asech(x) acoth(x) rad(x) deg(x) grad(x)";

    /// <summary>Values to show on form</summary>
    private static string _mathFun = "abs(x) cbr(x) comb(n,k) dec(x) exp(x) fact(x) fix(x) gcd(a,b,...) int(x) lcm(a,b,...) ln(x) logN(x,n) mod(a,b) perm(n,k) rnd(x) root(x,n) round(x,d) sgn(x) sqr(x)";

    /// <summary>Values to show on form</summary>
    private static string _statFun = "min(a,b,...) max(a,b,...) mcd(a,b,...) mcm(a,b,...) Sum(a,b,...) Mean(a,b,...) Meanq(a,b,...) Meang(a,b,...) Var(a,b,...) Varp(a,b,...) Stdev(a,b,...) Stdevp(a,b,...) Step(x,a)";

    /// <summary>Values to show on form</summary>
    private static string _timeFun = "Year(d) date# DateSerial(a,m,d) Day(d) Hour(d) Minute(d) Month(d) now# Second(d) time# TimeSerial(h,m,s)";

    /// <summary>Values to show on form</summary>
    private static string _otherFun = "Psi(x) AiryA(x) AiryB(x) BesselI(x,n) BesselJ(x,n) BesselK(x,n) BesselY(x,n) beta(a,b) betaI(x,a,b) CBinom(k,n,x) Ci(x) Clip(x,a,b) CNorm(x,m,d) CPoisson(x,k) DBinom(k,n,x) digamma(x) psi(x) DNorm(x,μ,σ) DPoisson(x,k) Ei(x) Ein(x,n) Elli1(x) Elli2(x) Erf(x) FresnelC(x) FresnelS(x) gamma(x) gammai(a,x) gammaln(x) HypGeom(x,a,b,c) I0(x) J0(x) K0(x) PolyCh(x,n) PolyHe(x,n) PolyLa(x,n) PolyLe(x,n) Si(x) WAM(t,fo,fm,m) WEXP(t,p,a) WEXPB(t,p,a) WFM(t,fo,fm,m) WLIN(t,p,d) WPARAB(t,p) WPULSE(t,p,d) WPULSEF(t,p,a) WRAISE(t,p) WRECT(t,p,d) WRING(t,p,a,fm) WRIPPLE(t,p,a) WSAW(t,p) WSQR(t,p) WSTEPS(t,p,n) WTRAPEZ(t,p,d) WTRI(t,p) Y0(x) zeta(x)";

    /// <summary>Values to show on form</summary>
    private static string _constants = "PI# pi# pi2# pi3# pi4# e# eu# phi# g# G# R# eps# mu# c# q# me# mp# mn# K# h# A#";

    /// <summary>Values to show on form</summary>
    private static string[] _categories = { "Shapes", "Operators", "Booleans", "Maths", "Angles", "Statistics", "Time", "Other", "Constants" };

    /// <summary>The datagridview</summary>
    private DataGridView _dataGridView;

    /// <summary>The shapefile</summary>
    private ShapefileWrapper _shpFile;

    /// <summary>Status indicating whether TextEditor has to be shown</summary>
    private bool _showTextEditor = false;

    /// <summary>Initializes a new instance of the frmFieldCalculator class</summary>
    /// <param name = "shapefileWrapper">The shapefile.</param>
    /// <param name = "gridView">The gridview.</param>
    /// <param name = "selectedColumnIndex">The index of the selected column.</param>
    public FieldCalculatorForm(ShapefileWrapper shapefileWrapper, DataGridView gridView, int selectedColumnIndex)
    {
      InitializeComponent();

      _dataGridView = gridView;
      _shpFile = shapefileWrapper;

      InitializeFieldValues((DataTable)gridView.DataSource, shapefileWrapper, selectedColumnIndex);
    }

    /// <summary>Gets or sets a value indicating whether TextEditor has to be shown</summary>
    public bool ShowTextEditor
    {
      get
      {
        return _showTextEditor;
      }

      set
      {
        _showTextEditor = value;
      }
    }

    /// <summary>Initialize the fields on the form</summary>
    /// <param name = "dt">The datatable.</param>
    /// <param name = "shapefileWrapper">The shapefile.</param>
    /// <param name = "selectedColumnIndex">The index of the selected column.</param>
    private void InitializeFieldValues(DataTable dt, ShapefileWrapper shapefileWrapper, int selectedColumnIndex)
    {
      string[] columnNames = ShapeData.GetVisibleFieldNames(dt);

      foreach (string colName in columnNames)
      {
        FieldsListView.Items.Add(colName);
      }

      DestFieldComboBox.Items.AddRange(columnNames);

      if (DestFieldComboBox.Items.Count > 0)
      {
        DestFieldComboBox.SelectedIndex = selectedColumnIndex;
      }

      PopulateTreeView(shapefileWrapper);
    }

    /// <summary>Populate the treeview</summary>
    /// <param name = "shapefileWrapper">The shapefile.</param>
    private void PopulateTreeView(ShapefileWrapper shapefileWrapper)
    {
      foreach (string category in _categories)
      {
        string[] subs;

        switch (category)
        {
          case "Shapes":
            if (shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_MULTIPOINT
                || shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_MULTIPOINTM
                || shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_MULTIPOINTZ
                || shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_POINT
                || shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_POINTM
                || shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_POINTZ)
            {
              subs = _pntShape.Split(' ');
              PopulateTreeView(category, subs);
            }
            else if (shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_POLYLINE
                || shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_POLYLINEM
                || shapefileWrapper.Shapefile.ShapefileType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
            {
              subs = _polyShape.Split(' ');
              PopulateTreeView(category, subs);
            }

            break;
          case "Operators":
            subs = _oper.Split(' ');
            PopulateTreeView(category, subs);
            break;
          case "Booleans":
            subs = _boolOp.Split(' ');
            PopulateTreeView(category, subs);
            break;
          case "Maths":
            subs = _mathFun.Split(' ');
            PopulateTreeView(category, subs);
            break;
          case "Angles":
            subs = _gonFun.Split(' ');
            PopulateTreeView(category, subs);
            break;
          case "Statistics":
            subs = _statFun.Split(' ');
            PopulateTreeView(category, subs);
            break;
          case "Time":
            subs = _timeFun.Split(' ');
            PopulateTreeView(category, subs);
            break;
          case "Other":
            subs = _otherFun.Split(' ');
            PopulateTreeView(category, subs);
            break;
          case "Constants":
            subs = _constants.Split(' ');
            PopulateTreeView(category, subs);
            break;
          default:
            break;
        }
      }
    }

    /// <summary>Populate the treeview</summary>
    /// <param name = "category">The category.</param>
    /// <param name = "subs">The subs.</param>
    private void PopulateTreeView(string category, string[] subs)
    {
      TreeNode node = lstFunctions.Nodes.Add(category);

      foreach (string subNode in subs)
      {
        node.Nodes.Add(subNode);
      }
    }

    /// <summary>Add the text in the fieldlist to the formula</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void FieldsListView_DoubleClick(object sender, EventArgs e)
    {
      if (FieldsListView.SelectedItems.Count > 0)
      {
        string value = string.Format("[{0}]", FieldsListView.SelectedItems[0].Text);
        AddTextToComputation(value);
      }
    }

    /// <summary>Add the text to the formula</summary>
    /// <param name = "value">The value to add.</param>
    private void AddTextToComputation(string value)
    {
      string formulaTxt = ComputationTextBox.Text;

      if (ComputationTextBox.SelectionLength > 0)
      {
        string beforeS = formulaTxt.Substring(0, ComputationTextBox.SelectionStart);
        string afterS = formulaTxt.Substring(ComputationTextBox.SelectionStart + ComputationTextBox.SelectionLength);

        formulaTxt = beforeS + value + afterS;
      }
      else
      {
        formulaTxt = formulaTxt != string.Empty ? formulaTxt + " " + value : formulaTxt + value;
      }

      ComputationTextBox.Text = formulaTxt;
    }

    /// <summary>Add the text to the formula</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void btnAdd_Click(object sender, EventArgs e)
    {
      AddTextToComputation("+");
    }

    /// <summary>Add the text to the formula</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void btnSubtract_Click(object sender, EventArgs e)
    {
      AddTextToComputation("-");
    }

    /// <summary>Add the text to the formula</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void btnMultiply_Click(object sender, EventArgs e)
    {
      AddTextToComputation("*");
    }

    /// <summary>Add the text to the formula</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void btnDivide_Click(object sender, EventArgs e)
    {
      AddTextToComputation("/");
    }

    /// <summary>Add the text to the formula</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void btnConcat_Click(object sender, EventArgs e)
    {
      AddTextToComputation("&");
    }

    /// <summary>Perform the calculation</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void btnOK_Click(object sender, EventArgs e)
    {
      if (ComputationTextBox.Text != string.Empty)
      {
        MathParser mathParser = new MathParser();

        // Make sure all open parenthesis are closed to avoid stack overrun in parser
        ComputationTextBox.Text = CloseParenthesis(ComputationTextBox.Text);

        try
        {
          bool retVal = mathParser.StoreExpression(ComputationTextBox.Text);
          if (!retVal)
          {
            MessageBox.Show("Could not parse computation equation: Invalid Syntax");
            return;
          }
        }
        catch
        {
          MessageBox.Show("Could not parse computation equation: Invalid Syntax");
          return;
        }

        if (CalculateValues(mathParser))
        {
          DialogResult result = MessageBox.Show("The calculation has completed. Would you like to close the Field Calculator now?", "TableEditor", MessageBoxButtons.YesNo);
          if (result == DialogResult.Yes)
          {
            Close();
          }
        }
      }
    }

    /// <summary>Get the id of the column to write the results to</summary>
    /// <returns>List of fieldnames</returns>
    private int GetResultColumn()
    {
      int retVal = -1;

      for (int i = 0; i < _dataGridView.Columns.Count; i++)
      {
        if (DestFieldComboBox.SelectedItem.ToString() == _dataGridView.Columns[i].Name)
        {
          retVal = i;
          break;
        }
      }

      return retVal;
    }

    /// <summary>Calculate the values for the fields</summary>
    /// <param name = "mathParser">The class which performs the calculations.</param>
    /// <returns>The status of the calculation</returns>
    private bool CalculateValues(MathParser mathParser)
    {
      int destFieldCol = GetResultColumn();
      if (destFieldCol == -1)
      {
        MessageBox.Show("An Invalid Field was selected in the Field Calculator Tool.");
        return false;
      }

      return DoCalculations(mathParser, destFieldCol);     
    }

    /// <summary>Calculate the values for the fields</summary>
    /// <param name = "mathParser">The class which performs the calculations.</param>
    /// <param name = "destFieldCol">The colums to write the results to.</param>
    /// <returns>The status of the calculation</returns>
    private bool DoCalculations(MathParser mathParser, int destFieldCol)
    {
      bool retVal = true;
      bool settingAll = _dataGridView.SelectedRows.Count == 0;
      MapWinGIS.Shape shp;

      foreach (DataGridViewRow row in _dataGridView.Rows)
      {
        if (row.Selected || settingAll)
        {
          try
          {
            for (int i = 1; i <= mathParser.VarTop; i++)
            {
              for (int j = 0; j < _dataGridView.ColumnCount; j++)
              {
                try
                {
                  var shapeID = Convert.ToInt32(row.Cells[0].Value);
                  switch (mathParser.get_VarName(i).ToLower())
                  {
                    case "shapex":
                    case "shapexfirst":
                      mathParser.set_VarValue(i, _shpFile.Shapefile.get_Shape(shapeID).get_Point(0).x);
                      break;
                    case "shapey":
                    case "shapeyfirst":
                      mathParser.set_VarValue(i, _shpFile.Shapefile.get_Shape(shapeID).get_Point(0).y);
                      break;
                    case "shapez":
                    case "shapezfirst":
                      mathParser.set_VarValue(i, _shpFile.Shapefile.get_Shape(shapeID).get_Point(0).Z);
                      break;
                    case "shapexlast":
                      shp = _shpFile.Shapefile.get_Shape(shapeID);
                      mathParser.set_VarValue(i, shp.get_Point(shp.numPoints - 1).x);
                      break;
                    case "shapeylast":
                      shp = _shpFile.Shapefile.get_Shape(shapeID);
                      mathParser.set_VarValue(i, shp.get_Point(shp.numPoints - 1).y);
                      break;
                    case "shapezlast":
                      shp = _shpFile.Shapefile.get_Shape(shapeID);
                      mathParser.set_VarValue(i, shp.get_Point(shp.numPoints - 1).Z);
                      break;
                    default:
                      if (_dataGridView.Columns[j].Name.ToLower() == mathParser.get_VarName(i).ToLower())
                      {
                        mathParser.set_VarValue(i, Convert.ToDouble(row.Cells[j].Value));
                      }

                      break;
                  }
                }
                catch (Exception ex)
                {
                  //MapWinUtility.Logger.Dbg("DEBUG: " + ex.ToString());
                }
              }
            }

            string val = mathParser.Eval().ToString();
            row.Cells[destFieldCol].Value = val;
          }
          catch
          {
            MessageBox.Show("The data is an invalid type for the destination table cell.");
            retVal = false;
          }
        }
      }

      return retVal;
    }

    /// <summary>Adds missing parenthesis</summary>
    /// <param name = "text">The text to be checked.</param>
    /// <returns>The resulting string</returns>
    private string CloseParenthesis(string text)
    {
      char[] textChars = text.ToCharArray();

      int openCount = textChars.Count(elm => elm == '(');
      int closeCount = textChars.Count(elm => elm == ')');
      int totalCount = openCount - closeCount;

      for (int i = 0; i < totalCount; i++)
      {
        text += ")";
      }

      return text;
    }

    /// <summary>Close the form</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    /// <summary>Switch to texteditor</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      ShowTextEditor = true;

      Close();
    }

    /// <summary>Add text to forumula</summary>
    /// <param name = "sender">The sender of the event.</param>
    /// <param name = "e">The arguments.</param>
    private void lstFunctions_DoubleClick(object sender, EventArgs e)
    {
      if (lstFunctions.SelectedNode.Level > 0)
      {
        AddTextToComputation(lstFunctions.SelectedNode.Text);
      }
    }
  }
}
