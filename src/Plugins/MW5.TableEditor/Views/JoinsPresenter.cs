using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Attributes.Helpers;
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

            View.JoinDoubleClicked += () => RunCommand(JoinsCommand.EditJoin);
        }

        public override void RunCommand(JoinsCommand command)
        {
            switch (command)
            {
                case JoinsCommand.Join:
                    if (JoinHelper.AddJoin(_context, Model))
                    {
                        View.UpdateView();
                    }
                    break;
                case JoinsCommand.EditJoin:
                    if (JoinHelper.EditJoin(_context, Model, View.SelectedJoin))
                    {
                        View.UpdateView();
                    }
                    break;
                case JoinsCommand.Stop:
                    if (JoinHelper.StopJoin(Model, View.SelectedJoin))
                    {
                        View.UpdateView();
                    }
                    break;
                case JoinsCommand.StopAll:
                    JoinHelper.StopAllJoins(Model);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
