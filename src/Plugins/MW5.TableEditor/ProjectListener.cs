using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.TableEditor
{
    public class ProjectListener
    {
        private readonly IAppContext _context;
        private readonly TableEditorPlugin _plugin;
        private readonly IMessageService _messageService;

        public ProjectListener(IAppContext context, TableEditorPlugin plugin, IMessageService messageService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (messageService == null) throw new ArgumentNullException("messageService");
            _context = context;
            _plugin = plugin;
            _messageService = messageService;

            _plugin.BeforeRemoveLayer += BeforeRemoveLayer;
        }

        private void BeforeRemoveLayer(object sender, LayerRemoveEventArgs e)
        {
            var form = _plugin.Form;
            if (form == null || form.Layer.Handle != e.LayerHandle)
            {
                return;
            }

            if (form.HasChanges)
            {
                var result = _messageService.AskWithCancel("Do you want to save changes in attribute table of the layer?");
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

                if (result == DialogResult.Yes)
                {
                    form.SaveChanges();
                }
            }
        }
    }
}
