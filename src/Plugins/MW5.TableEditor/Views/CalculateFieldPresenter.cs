using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class CalculateFieldPresenter: BasePresenter<ICalculateFieldView, IFeatureSet>
    {
        public CalculateFieldPresenter(ICalculateFieldView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            if (!Validate())
            {
                return false;
            }

            return ParseAndCalculate();
        }

        public override void Initialize()
        {

        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(View.Expression))
            {
                MessageService.Current.Info("Expression is empty");
                return false;
            }

            if (View.TargetFieldIndex == -1)
            {
                MessageService.Current.Info("Target field wasn't selected.");
                return false;
            }

            return true;
        }

        private bool ParseAndCalculate()
        {
            var parser = new MathParser();

            try
            {
                if (!parser.StoreExpression(View.Expression))
                {
                    MessageService.Current.Info("Could not parse computation equation: Invalid Syntax");
                    return false;
                }
            }
            catch
            {
                MessageService.Current.Warn("Could not parse computation equation: Invalid Syntax");
                return false;
            }

            return parser.CalculateForFeatureSet(_model, View.TargetFieldIndex);
        }
    }
}
