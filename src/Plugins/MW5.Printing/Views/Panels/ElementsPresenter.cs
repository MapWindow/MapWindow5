// -------------------------------------------------------------------------------------------
// <copyright file="ElementsPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Views.Panels
{
    internal class ElementsPresenter : CommandDispatcher<ElementsDockPanel, ElementsCommand>, IDockPanelPresenter
    {
        private LayoutControl _layoutControl;

        public ElementsPresenter(ElementsDockPanel view)
            : base(view)
        {
        }

        public Control GetInternalObject()
        {
            return View;
        }

        public override void RunCommand(ElementsCommand command)
        {
            switch (command)
            {
                case ElementsCommand.MoveUp:
                    _layoutControl.MoveSelectionUp();
                    UpdateSelectionFromMap();
                    break;
                case ElementsCommand.MoveDown:
                    _layoutControl.MoveSelectionDown();
                    UpdateSelectionFromMap();
                    break;
                case ElementsCommand.Remove:
                    _layoutControl.DeleteSelected();
                    UpdateSelectionFromMap();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        public void SetLayoutControl(LayoutControl layoutControl)
        {
            View.layoutListBox1.LayoutControl = layoutControl;
            _layoutControl = layoutControl;
        }

        public void UpdateSelectionFromMap()
        {
            View.layoutListBox1.UpdateSelectionFromMap();
        }
    }
}