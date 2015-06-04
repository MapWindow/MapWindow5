using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class JoinExcelView : JoinExcelViewBase, IJoinExcelView
    {
        public JoinExcelView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            //var books = XlsImportHelper.GetWorkbooks("");
            //cboWorkBooks.DataSource = books.Distinct().ToList();
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }
    }

    public class JoinExcelViewBase: MapWindowView<FieldJoin> {}
}
