using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views
{
    public class AddFieldPresenter: BasePresener<IAddFieldView, IFeatureSet>
    {
        private readonly IAddFieldView _view;
        private IFeatureSet _featureSet;

        public AddFieldPresenter(IAddFieldView view) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");

            _view = view;
            view.OkClicked += ViewOkClicked;
        }

        private FeatureField Field
        {
            get
            {
                var fld = new FeatureField
                {
                    Name = _view.FieldName,
                    Type = _view.FieldType,
                    Width = _view.FieldWidth,
                    Precision = _view.FieldPrecision
                };
                return fld;
            }
        }

        private void ViewOkClicked()
        {
            _featureSet.Fields.Add(Field);
            _view.Close();
            _success = true;
        }

        public override bool Run(IFeatureSet fs, bool modal = true)
        {
            if (fs == null)
            {
                throw new ArgumentNullException("fs");
            }

            if (!fs.EditingTable)
            {
                throw new InvalidOperationException("Fields can be added only after edit mode is started for the table.");
            }

            _featureSet = fs;
            
            _view.ShowView();

            return _success;
        }
    }
}
