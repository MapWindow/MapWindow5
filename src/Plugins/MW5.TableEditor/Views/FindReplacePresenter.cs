using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class FindReplacePresenter: BasePresenter<IFindReplaceView, FindReplaceModel>
    {
        public FindReplacePresenter(IFindReplaceView view) : base(view)
        {
            view.Find += OnFind;
            view.ReplaceAll += OnReplaceAll;
            view.Replace += OnReplace;
        }

        private bool ValidateSearchString()
        {
            if (string.IsNullOrWhiteSpace(Model.SearchInfo.Token))
            {
                MessageService.Current.Info("Search string is empty.");
                return false;
            }

            return true;
        }

        private void OnReplace()
        {
            View.UpdateSearchInfo();

            if (!ValidateSearchString()) return;

            if (!Model.Grid.Replace(Model.SearchInfo))
            {
                MessageService.Current.Info("No more occurrences of the string were found to replace.");
            }
        }

        private void OnReplaceAll()
        {
            View.UpdateSearchInfo();

            if (!ValidateSearchString()) return;
            
            int count = Model.Grid.ReplaceAll(Model.SearchInfo);

            if (count == 0)
            {
                MessageService.Current.Info("No instance of the search were found to replace");
            }
            else
            {
                MessageService.Current.Info("Number of values replaced: " + count);
            }
        }

        private void OnFind()
        {
            View.UpdateSearchInfo();

            if (!ValidateSearchString()) return;

            var info = Model.SearchInfo;

            if (!Model.Grid.FindNext(info))
            {
                if (info.Count == 1)
                {
                    MessageService.Current.Info("Only one instance of the search string was found.");
                }
                else if (info.Count > 1)
                {
                    if (MessageService.Current.Ask("All the records have been searched. " + Environment.NewLine +
                                                    "Do you want to restart the search?"))
                    {
                        info.RestartSearch = true;
                        Model.Grid.FindNext(info);
                    }
                }
                else
                {
                    MessageService.Current.Info("No records were found that satisfy criteria.");
                }
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
