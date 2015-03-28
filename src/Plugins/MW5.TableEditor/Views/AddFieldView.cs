using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.UI;
using MW5.UI.Helpers;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class AddFieldView : MapWindowView, IAddFieldView
    {
        public AddFieldView(IAppView appView):
            base(appView)
        {
            InitializeComponent();

            cboFieldType.AddItemsFromEnum<AttributeType>();
            cboFieldType.SetValue(AttributeType.String);
        }

        public string FieldName
        {
            get { return txtFieldName.Text; }
        }

        public int FieldWidth
        {
            get { return (int)fldWidth.Value; }
        }

        public int FieldPrecision
        {
            get { return (int)fldPrecision.Value; }
        }

        public AttributeType FieldType
        {
            get { return cboFieldType.GetValue<AttributeType>(); }
        }

        public void UpdateView()
        {
            // empty
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }
}
