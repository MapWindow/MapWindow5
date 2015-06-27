// -------------------------------------------------------------------------------------------
// <copyright file="ProjectionMismatchView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Projections.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;

namespace MW5.Projections.Views
{
    public partial class ProjectionMismatchView : ProjectionMismatchViewBase, IProjectionMismatchView
    {
        public ProjectionMismatchView()
        {
            InitializeComponent();

            btnDetails.Click += (s, e) => Invoke(DetailsClicked);
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            if (Model.IsMismatch)
            {
                Text = "Projection mismatch";
                lblMessage.Text = "Coordinate system or projection of the layer is different from the coodinate system of the project. To ensure correct display of the layer a reprojection may be needed. Choose 'Reproject' to run it. Choose 'Ignore' to display layer without reprojection and 'Skip' to cancel the opening of this particular layer. 'Cancel' will stop the whole loading process.";
            }
            else
            {
                btnReproject.Text = "Assign";
                Text = "Projection is missing";
                lblMessage.Text = "Coordinate system and projection of the layer is unknown. Choose 'Assign' to assign coordinate system of the project to this layer (it may lead to incorrect display if coordinate system is wrong). Choose 'Ignore' to display layer without reprojection and 'Skip' to cancel the opening of this particular layer. 'Cancel' will stop the whole loading process.";
            }

            btnDetails.Visible = Model.IsMismatch;

            DisplayDatasourceInfo();
        }

        private void DisplayDatasourceInfo()
        {
            string filename = Model.LayerSource.Filename;
            lblFilename.Text = "Filename: " + filename;

            if (File.Exists(filename))
            {
                var info = new FileInfo(filename);
                lblSize.Text = "Size: " + NumericHelper.FormatFileSize(info.Length);
            }
            else
            {
                lblSize.Text = "Size: not defined";
            }
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }

        public event Action DetailsClicked;

        private void OnIgnoreClick(object sender, EventArgs e)
        {
            if (Model.IsMismatch)
            {
                Model.MismatchBehavior = ProjectionMismatch.IgnoreMismatch;
            }
            else
            {
                Model.AbsenceBehavior = ProjectionAbsence.IgnoreAbsence;
            }

            SaveCheckboxes();

            DialogResult = DialogResult.OK;
        }

        private void OnReprojectClick(object sender, EventArgs e)
        {
            if (Model.IsMismatch)
            {
                Model.MismatchBehavior = ProjectionMismatch.Reproject;
            }
            else
            {
                Model.AbsenceBehavior = ProjectionAbsence.AssignFromProject;
            }

            SaveCheckboxes();

            DialogResult = DialogResult.OK;
        }

        private void OnSkipClick(object sender, EventArgs e)
        {
            if (Model.IsMismatch)
            {
                Model.MismatchBehavior = ProjectionMismatch.SkipFile;
            }
            else
            {
                Model.AbsenceBehavior = ProjectionAbsence.SkipFile;
            }

            SaveCheckboxes();

            
            DialogResult = DialogResult.OK;
        }

        private void SaveCheckboxes()
        {
            Model.DontShow = chkDontShow.Checked;
            Model.UseAnswerLater = chkUseAnswerLater.Checked;
        }
    }

    public class ProjectionMismatchViewBase : MapWindowView<ProjectionMismatchModel>
    {
    }
}