// -------------------------------------------------------------------------------------------
// <copyright file="ProjectionInfoPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Projections.Enums;
using MW5.Projections.Forms;
using MW5.Projections.Views.Abstract;

namespace MW5.Projections.Views
{
    public class ProjectionInfoPresenter : ComplexPresenter<IProjectionInfoView, DialectsCommand, ProjectionInfoModel>
    {
        private readonly IAppContext _context;

        public ProjectionInfoPresenter(IProjectionInfoView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            View.EditDialect += () => RunCommand(DialectsCommand.EditDialect);
        }

        /// <summary>
        /// Runs the command.
        /// </summary>
        public override void RunCommand(DialectsCommand command)
        {
            switch (command)
            {
                case DialectsCommand.AddDialect:
                    {
                        string proj = string.Empty;
                        if (EnterProjection(null, ref proj))
                        {
                            Model.Dialects.Add(new ProjectionDialect(proj));
                            View.SelectedDialect = Model.Dialects.Last();
                        }
                    }
                    break;
                case DialectsCommand.RemoveDialect:
                    if (View.SelectedDialect == null) return;

                    if (MessageService.Current.Ask("Remove the selected dialect?"))
                    {
                        int index = Model.Dialects.IndexOf(View.SelectedDialect);
                        Model.Dialects.Remove(View.SelectedDialect);
                        
                        if (index >= Model.Dialects.Count)
                        {
                            index = Model.Dialects.Count - 1;
                        }

                        if (index >= 0 && Model.Dialects.Any())
                        {
                            View.SelectedDialect = Model.Dialects[index];
                        }
                        else
                        {
                            View.UpdateView();
                        }
                    }
                    break;
                case DialectsCommand.ClearDialects:
                    if (!Model.Dialects.Any()) return;

                    if (MessageService.Current.Ask("Remove all the dialects?"))
                    {
                        Model.Dialects.Clear();
                        View.UpdateView();
                    }
                    break;
                case DialectsCommand.EditDialect:
                    {
                        var dl = View.SelectedDialect;
                        if (dl == null) return;

                        string proj = dl.Definition;
                        if (EnterProjection(dl, ref proj))
                        {
                            dl.Definition = proj;
                            
                            int index = Model.Dialects.IndexOf(dl);
                            if (index != -1)
                            {
                                Model.Dialects[index] = dl;
                            }
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            SaveDialects();

            return true;
        }

        /// <summary>
        /// Opens dialog to enter new or edit existing projection string.
        /// </summary>
        private bool EnterProjection(ProjectionDialect selectedDialect, ref string defaultValue)
        {
            var dialects = Model.Dialects.Where(d => d != selectedDialect).Select(d => d.Definition);

            using (var form = new EnterProjectionForm(Model.CoordinateSystem, dialects, _context.Projections))
            {
                form.textBox1.Text = defaultValue ?? string.Empty;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    defaultValue = form.textBox1.Text;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Saves dialects to the database.
        /// </summary>
        private void SaveDialects()
        {
            if (Model.CoordinateSystem == null || _context.Projections == null)
            {
                return;
            }

            var cs = Model.CoordinateSystem;
            cs.Dialects.Clear();

            cs.Dialects.AddRange(Model.Dialects.Select(d => d.Definition));

            _context.Projections.SaveDialects(cs);
        }
    }
}