using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class JoinsPresenter: ComplexPresenter<IJoinsView, JoinsCommand, IAttributeTable>
    {
        private const string OpenDialogFilter = "Dbf tables (*.dbf)|*.dbf|Excel workbooks (*.xls, *.xlsx)|*.xls;*.xlsx|CSV files (*.csv)|*.csv|All|*.csv;*.dbf;*.xls;*.xlsx";

        private readonly IAppContext _context;
        private readonly IFileDialogService _dialogService;

        public JoinsPresenter(IAppContext context, IJoinsView view, IFileDialogService dialogService) : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (dialogService == null) throw new ArgumentNullException("dialogService");

            _context = context;
            _dialogService = dialogService;
        }

        public override void Initialize()
        {
            
        }

        public override void RunCommand(JoinsCommand command)
        {
            switch (command)
            {
                case JoinsCommand.Join:
                    Join();
                    break;
                case JoinsCommand.EditJoin:
                    EditJoin();
                    View.UpdateView();
                    break;
                case JoinsCommand.Stop:
                    StopSelectedJoin();
                    break;
                case JoinsCommand.StopAll:
                    if (MessageService.Current.Ask("Do you want to stop all joins?"))
                    {
                        Model.StopAllJoins();
                        View.UpdateView();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        /// <summary>
        /// Open dialog to choose a single datasource and join it.
        /// </summary>
        private void Join()
        {
            string filename;
            if (!_dialogService.Open(OpenDialogFilter, out filename, 4))
            {
                return;
            }

            filename = filename.ToLower();

            if (IsDbf(filename))
            {
                var model = new JoinDbfModel(Model, filename);
                if (!model.IsValid) return;

                if (_context.Container.Run<JoinDbfPresenter, JoinDbfModel>(model))
                {
                    View.UpdateView();
                }
            }
            else
            {
                MessageService.Current.Info("About to perform Excel join.");
            }
        }

        /// <summary>
        /// Opens dialog to edit currently selected join.
        /// </summary>
        private void EditJoin()
        {
            var join = View.SelectedJoin;

            if (join == null)
            {
                MessageService.Current.Info("No join is selected.");
                return;
            }

            if (!IsDbf(join.Filename))
            {
                MessageService.Current.Info("Editing of the join isn't available for this type of datasource.");
            }
            
            var model = new JoinDbfModel(Model, join.Filename, join);
            if (!model.IsValid) return;

            if (_context.Container.Run<JoinDbfPresenter, JoinDbfModel>(model))
            {
                View.UpdateView();
            }
        }

        /// <summary>
        /// Stops currently selected join.
        /// </summary>
        private void StopSelectedJoin()
        {
            var join = View.SelectedJoin;

            if (join == null)
            {
                MessageService.Current.Info("No join is selected.");
                return;
            }

            string filename = join.Filename;

            if (!MessageService.Current.Ask("Do you want to stop the join: " + filename + "?"))
            {
                return;
            }

            if (Model.StopJoin(join.JoinIndex))
            {
                MessageService.Current.Info("The join was stopped: " + filename);
            }

            View.UpdateView();
        }

        private bool IsDbf(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return false;
            }

            return filename.ToLower().EndsWith(".dbf");
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
