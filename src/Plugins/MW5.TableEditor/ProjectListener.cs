using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Views;

namespace MW5.Plugins.TableEditor
{
    public class ProjectListener
    {
        private readonly IAppContext _context;
        private readonly TableEditorPlugin _plugin;
        private readonly IMessageService _messageService;
        private readonly TableEditorPresenter _presenter;

        public ProjectListener(IAppContext context, TableEditorPlugin plugin, IMessageService messageService,
            TableEditorPresenter presenter)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (messageService == null) throw new ArgumentNullException("messageService");
            _context = context;
            _plugin = plugin;
            _messageService = messageService;
            _presenter = presenter;

            _plugin.BeforeRemoveLayer += BeforeRemoveLayer;
        }

        private void BeforeRemoveLayer(object sender, LayerRemoveEventArgs e)
        {
            if (!_presenter.HasLayer(e.LayerHandle))
            {
                return;
            }

            if (_presenter.HasChanges)
            {
                var result = _messageService.AskWithCancel("Do you want to save changes in attribute table of the layer?");
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

                if (result == DialogResult.Yes)
                {
                    _presenter.RunCommand(TableEditorCommand.SaveChanges);
                }
            }
        }
    }
}
