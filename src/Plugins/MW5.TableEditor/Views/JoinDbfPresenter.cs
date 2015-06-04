using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Views
{
    public class JoinDbfPresenter : BasePresenter<IJoinDbfView, JoinDbfModel>
    {
        public JoinDbfPresenter(IJoinDbfView view) : base(view)
        {
            view.TryJoin += view_TryJoin;
        }

        private void view_TryJoin()
        {
            if (View.FieldTo == null || View.FieldFrom == null)
            {
                return;
            }

            int rowCount, joinRowCount;

            if (Model.Table.TryJoin(Model.External, View.FieldTo.Name, View.FieldFrom.Name, out rowCount, out joinRowCount))
            {
                View.SetRowCount(rowCount, joinRowCount);
            }
        }

        private bool Validate()
        {
            if (!View.SelectedFields.Any())
            {
                MessageService.Current.Info("No fields are selected for the join.");
                return false;
            }

            if (View.FieldTo == null || View.FieldFrom == null)
            {
                MessageService.Current.Info("Key fields aren't selected.");
                return false;
            }

            return true;
        }

        private bool PerformJoin()
        {
            if (!Validate()) return false;

            var fields = View.SelectedFields.Select(f => f.Name);

            if (Model.EditJoin != null)
            {
                if (!Model.Table.StopJoin(Model.EditJoin.JoinIndex))
                {
                    Logger.Current.Warn("Failed to stop join: " + Model.EditJoin.Filename);
                    return false;
                }
            }
            
            bool result = Model.Table.Join(Model.External, View.FieldTo.Name, View.FieldFrom.Name, Model.Filename, "", fields);
            if (!result)
            {
                MessageService.Current.Warn("Failed to join tables.");
            }

            return result;
        }

        public override bool ViewOkClicked()
        {
            return PerformJoin();
        }
    }
}
