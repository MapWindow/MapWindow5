using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class AddFieldPresenter: BasePresenter<IAddFieldView, IFeatureSet>
    {
        private readonly IAddFieldView _view;
        private IFeatureSet _featureSet;

        public AddFieldPresenter(IAddFieldView view) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");

            _view = view;
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

        public override bool ViewOkClicked()
        {
            _featureSet.Fields.Add(Field);
            return true;
        }

        public override void Init(IFeatureSet fs)
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
        }
    }
}
