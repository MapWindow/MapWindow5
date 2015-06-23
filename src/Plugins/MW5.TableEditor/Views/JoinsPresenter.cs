using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Attributes.Views;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class JoinsPresenter: ComplexPresenter<IJoinsView, JoinsCommand, IAttributeTable>
    {
        private readonly IAppContext _context;

        public JoinsPresenter(IAppContext context, IJoinsView view) : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

            View.JoinDoubleClicked += EditJoin;
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
            var model = new JoinViewModel(Model);
            
            if (_context.Container.Run<JoinTablePresenter, JoinViewModel>(model))
            {
                View.UpdateView();
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

            var model = new JoinViewModel(Model, join);

            if (_context.Container.Run<JoinTablePresenter, JoinViewModel>(model))
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

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
