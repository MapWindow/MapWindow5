// -------------------------------------------------------------------------------------------
// <copyright file="CategoriesPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Views
{
    /// <summary>
    /// Handles commands of categories sub view (generation of categories, etc).
    /// </summary>
    [LayoutWithRegions]
    public class CategoriesPresenter : SubViewPresenter<CategoriesSubView, CategoriesCommand, CategoriesSubViewModel>
    {
        private readonly IAppContext _context;

        #region Constructors

        public CategoriesPresenter(CategoriesSubView subView, IAppContext context)
            : base(subView)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            subView.CategoryStyleClicked += ChangeCategoryStyle;
            subView.CategoryNameChanged += () => FireRedraw(true);
        }

        #endregion

        #region Events

        public event Action LockView;

        public event Action RedrawLegend;

        public event Action RedrawMap;

        public event Action UnlockView;

        #endregion

        #region Properties

        public IWin32Window ViewAsParent
        {
            get
            {
                var userControl = View as UserControl;
                return userControl != null ? userControl.ParentForm : null;
            }
        }

        #endregion

        #region Public Methods

        public override void RunCommand(CategoriesCommand command)
        {
            switch (command)
            {
                case CategoriesCommand.ChangeColorScheme:
                    FormHelper.EditColorSchemes(_context, SchemeTarget.Vector, ViewAsParent);
                    return;
                case CategoriesCommand.CategoryRemove:
                    View.RemoveSelectedCategory();
                    break;
                case CategoriesCommand.CategoryClear:
                    Model.FeatureSet.Categories.Clear();
                    Model.Metadata.CategoriesClassification = View.Classification;
                    View.UpdateView();
                    break;
                case CategoriesCommand.CategoryAppearance:
                    if (_context.ShowDefaultStyleDialog(Model.Layer.Handle, true, ViewAsParent))
                    {
                        View.InvalidateView();
                    }
                    break;
                case CategoriesCommand.CategoryGenerate:
                    GenerateCategories();
                    break;
            }

            FireRedraw();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Applies color scheme chosen in the image combo to categories
        /// </summary>
        private void ApplyColorScheme2Categories()
        {
            var fs = View.FeatureSet;

            if (fs.Categories.Count == 0)
            {
                return;
            }

            var metadata = View.Metadata;
            metadata.CategoriesColorScheme = View.SelectedColorScheme;
            var scheme = metadata.CategoriesColorScheme.ToColorScheme();

            fs.Categories.ApplyColorScheme(View.RandomColors ? SchemeType.Random : SchemeType.Graduated, scheme);

            var categories = fs.Categories;
            if (View.SetGradient)
            {
                foreach (var options in categories.Select(t => t.Style))
                {
                    options.Fill.SetGradient(options.Fill.Color, 75);
                    options.Fill.Type = FillType.Gradient;
                }
            }
            else
            {
                var color = fs.Style.Fill.Color2;

                foreach (var options in categories.Select(t => t.Style))
                {
                    options.Fill.Color2 = color;
                    options.Fill.Type = FillType.Solid;
                }
            }
        }

        /// <summary>
        /// Sets symbols with variable size for point categories 
        /// </summary>
        private void ApplyVariablePointSize()
        {
            int minSize = View.MinPointSize;
            int maxSize = View.MaxPointSize;

            var fs = Model.FeatureSet;

            if (!View.UseVariableSize || (minSize == maxSize)) return;

            var categories = fs.Categories;

            switch (fs.GeometryType)
            {
                case GeometryType.Point:
                case GeometryType.MultiPoint:
                    {
                        double step = (maxSize - minSize) / ((double)categories.Count - 1);
                        for (int i = 0; i < categories.Count; i++)
                        {
                            categories[i].Style.Marker.Size = minSize + Convert.ToInt32(i * step);
                        }
                    }
                    break;
                case GeometryType.Polyline:
                    {
                        double step = (maxSize + minSize) / (double)categories.Count;
                        for (int i = 0; i < categories.Count; i++)
                        {
                            categories[i].Style.Line.Width = minSize + Convert.ToInt32(i * step);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Changes the style of the selected category
        /// </summary>
        private void ChangeCategoryStyle()
        {
            var ct = View.SelectedCategory;

            if (ct == null)
            {
                return;
            }

            using (var form = _context.GetSymbologyForm(Model.Layer.Handle, ct.Style, true))
            {
                form.Text = "Category drawing options";

                if (_context.View.ShowChildView(form))
                {
                    View.InvalidateView();
                    FireRedraw();
                }
            }
        }

        private void FireLockView(bool value)
        {
            var handler = value ? LockView : UnlockView;
            if (handler != null)
            {
                handler();
            }
        }

        private void FireRedraw(bool legend = false)
        {
            var handler = legend ? RedrawLegend: RedrawMap;
            if (handler != null)
            {
                handler();
            }
        }

        private bool CheckUniqueValuesCount(out bool showWaiting)
        {
            showWaiting = false;

            var fs = Model.FeatureSet;

            if (View.Classification != Classification.UniqueValues)
            {
                return true;
            }

            var set = new HashSet<object>();
            for (int i = 0; i < fs.Features.Count; i++)
            {
                var val = fs.Table.CellValue(View.FieldIndex, i);
                set.Add(val);
            }

            if (set.Count > 300)
            {
                showWaiting = true;

                string s = string.Format("The chosen field = {1}.\nThe number of unique values = {0}.\n" + 
                                         "Large number of categories negatively affects performance.\nDo you want to continue?", 
                                            set.Count, "[" + View.FieldName.Trim().ToUpper() + "]");

                if (!MessageService.Current.Ask(s))
                {
                    return false;;
                }
            }

            set.Clear();

            return true;
        }

        /// <summary>
        /// Generates shapefile categories
        /// </summary>
        private void GenerateCategories()
        {
            int index = View.FieldIndex;
            if (index == -1)
            {
                return;
            }

            bool showWaiting;

            if (!CheckUniqueValuesCount(out showWaiting))
            {
                return;
            }

            Lock(showWaiting, true);

            // generating
            var categories = Model.FeatureSet.Categories;
            categories.Generate(index, View.Classification, View.NumCategories);
            categories.Caption = "Categories: " + Model.FeatureSet.Fields[index].Name;

            ApplyColorScheme2Categories();

            if (View.UseVariableSize)
            {
                ApplyVariablePointSize();
            }

            categories.ApplyExpressions();

            SaveSettings();

            View.UpdateView();

            Lock(showWaiting, false);
        }

        private void Lock(bool showWaiting, bool value)
        {
            if (showWaiting)
            {
                FireLockView(value);
            }
            else
            {
                View.Lock(value);
            }
        }

        private void SaveSettings()
        {
            // saving the settings
            var metadata = View.Metadata;
            metadata.CategoriesClassification = View.Classification;
            metadata.CategoriesFieldName = View.Name;
            metadata.CategoriesSizeRange = View.MaxPointSize - View.MinPointSize;
            metadata.CategoriesCount = View.NumCategories;
            metadata.CategoriesRandomColors = View.RandomColors;
            metadata.CategoriesUseGradient = View.SetGradient;
            metadata.CategoriesVariableSize = View.UseVariableSize;
        }

        #endregion
    }
}