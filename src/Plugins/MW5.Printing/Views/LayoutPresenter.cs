// -------------------------------------------------------------------------------------------
// <copyright file="LayoutPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Printing.Services;
using MW5.Plugins.Printing.Views.Abstract;

namespace MW5.Plugins.Printing.Views
{
    internal class LayoutPresenter : BasePresenter<ILayoutView, TemplateModel>
    {
        private readonly IAppContext _context;

        public LayoutPresenter(IAppContext context, ILayoutView view)
            : base(view)
        {
            _context = context;
            if (context == null) throw new ArgumentNullException("context");

            View.LayoutControl.NewElement += OnNewElement;
            View.LayoutControl.ElementDoubleClicked += OnElementDoubleClicked;
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            return true;
        }

        protected override void Initialize()
        {
            var settings = InitPrinterSettings();

            View.LayoutControl.Initialize(settings, _context.Map);

            if (Model.HasTemplate)
            {
                var serializer = new LayoutSerializer();
                serializer.LoadLayout(_context, View.LayoutControl, Model.TemplateName, Model.Extents);
            }
            else
            {
                View.LayoutControl.AddMapElement(Model.Scale, Model.Extents);
            }
        }

        private PrinterSettings InitPrinterSettings()
        {
            var settings = PrinterManager.PrinterSettings;
            settings.DefaultPageSettings.Landscape = Model.PaperOrientation == Orientation.Horizontal;
            settings.DefaultPageSettings.PaperSize = PaperSizes.PaperSizeByFormatName(Model.PaperFormat, settings);
            return settings;
        }

        /// <summary>
        /// Edits the table.
        /// </summary>
        private bool EditTable(LayoutTable table, bool newTable)
        {
            var model2 = new TableViewModel(table, newTable);
            if (_context.Container.Run<TablePresenter, TableViewModel>(model2))
            {
                table.UpdateWidth(GdiPlusHelper.TempGraphics, false);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Opens element specific editing dialog for the element
        /// </summary>
        private void OnElementDoubleClicked(object sender, LayoutElementEventArgs e)
        {
            switch (e.Element.Type)
            {
                case ElementType.Table:
                    {
                        if (EditTable(e.Element as LayoutTable, false))
                        {
                            return;
                        }
                        break;
                    }
            }

            e.Cancel = true;
        }

        /// <summary>
        /// Initializes element added by user manually.
        /// </summary>
        private void OnNewElement(object sender, LayoutElementEventArgs e)
        {
            switch (e.Element.Type)
            {
                case ElementType.Table:
                    {
                        if (!OpenTableDialog(e.Element as LayoutTable))
                        {
                            e.Cancel = true;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Initializes a table added by user.
        /// </summary>
        private bool OpenTableDialog(LayoutTable table)
        {
            var model = new CreateTableModel();
            if (_context.Container.Run<CreateTablePresenter, CreateTableModel>(model))
            {
                table.Data.Initialize(model.RowCount, model.ColumnCount);

                return EditTable(table, true);
            }

            return false;
        }
    }
}