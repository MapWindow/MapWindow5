using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.ShapeEditor.Views.Abstract;

namespace MW5.Plugins.ShapeEditor.Views
{
    public class AttributePresenter : BasePresenter<IAttributeView, AttributeViewModel>
    {
        public AttributePresenter(IAttributeView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            return Save();
        }
        
        private bool Save()
        {
            var values = View.Values;

            var table = Model.Layer.FeatureSet.Table;

            var fields = table.Fields;
            for (int i = 0; i < fields.Count; i++)
            {
                if (values.ContainsKey(i))
                {
                    var fld = fields[i];

                    if (!ApplyValue(table, fld, i, values[i]))
                    {
                        View.FocusInvalidTextBox(i);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ApplyValue(AttributeTable table, IAttributeField fld, int fieldIndex, string text)
        {
            switch (fld.Type)
            {
                case AttributeType.String:
                    {
                        table.EditCellValue(fieldIndex, Model.ShapeIndex, text);
                        break;
                    }
                case AttributeType.Integer:
                    {
                        if (!Int32.TryParse(text, out int val))
                        {
                            MessageService.Current.Info("Failed to parse integer value: " + text);
                            return false;
                        }

                        table.EditCellValue(fieldIndex, Model.ShapeIndex, val);
                        break;
                    }
                case AttributeType.Double:
                    {
                        if (!Double.TryParse(text, out double val))
                        {
                            MessageService.Current.Info("Failed to parse double value: " + text);
                            return false;
                        }

                        table.EditCellValue(fieldIndex, Model.ShapeIndex, val);
                        break;
                    }
                case AttributeType.Boolean:
                    {
                        if (!Boolean.TryParse(text, out bool val))
                        {
                            MessageService.Current.Info("Failed to parse boolean value: " + text);
                            return false;
                        }

                        table.EditCellValue(fieldIndex, Model.ShapeIndex, val);
                        break;
                    }
                case AttributeType.Date:
                    {
                        if (!DateTime.TryParse(text, out DateTime val))
                        {
                            MessageService.Current.Info("Failed to parse datetime value: " + text);
                            return false;
                        }

                        table.EditCellValue(fieldIndex, Model.ShapeIndex, val);
                        break;
                    }
            }

            return true;
        }
    }
}
