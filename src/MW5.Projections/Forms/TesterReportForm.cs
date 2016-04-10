// -------------------------------------------------------------------------------------------
// <copyright file="TesterReportForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Projections.Enums;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Projections.Forms
{
    public partial class TesterReportForm : MapWindowForm
    {
        // Data grid view columns
        private const int CMN_FILENAME = 0;
        private const int CMN_PROJECTION = 1;
        private const int CMN_OPERATION = 2;
        private const int CMN_NEW_NAME = 3;
        private const int CMN_ERROR = 4;

        /// <summary>
        /// Creates a new instance of the frmTesterReport class
        /// </summary>
        public TesterReportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the number of mismatched files
        /// </summary>
        public int MismatchedCount
        {
            get { return listView1.Items.Count; }
        }

        /// <summary>
        /// Adds new file to the report
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <param name="projection">Projection name</param>
        /// <param name="operation">Operation that was applied to the file</param>
        /// <param name="newName">The new name of the file (in case of reprojection)</param>
        public void AddFile(string filename, string projection, ProjectionOperaion operation, string newName)
        {
            string s = operation.ToString();
            switch (operation)
            {
                case ProjectionOperaion.AbsenceIgnored:
                    s = "Absence ignored";
                    break;
                case ProjectionOperaion.MismatchIgnored:
                    s = "Mismatch ignored";
                    break;
                case ProjectionOperaion.FailedToReproject:
                    s = "Failed to reproject";
                    break;
            }

            var item = listView1.Items.Add(Path.GetFileName(filename));
            item.SubItems.Add(projection == "" ? "none" : projection);
            item.SubItems.Add(s);
            item.SubItems.Add(Path.GetFileName(newName));

            if (operation == ProjectionOperaion.Skipped || operation == ProjectionOperaion.FailedToReproject)
            {
                item.SubItems.Add(MapConfig.GdalReprojectionErrorMsg);
            }
            else
            {
                item.SubItems.Add("");
            }

            listView1.Refresh();
            ListViewHelper.AutoResizeColumns(listView1);

            Application.DoEvents();
        }

        /// <summary>
        /// Shows the report window as non-modal form
        /// </summary>
        /// <param name="proj">Project projection</param>
        public void InitProgress(ISpatialReference proj)
        {
            Text = @"Reprojecting";
            label1.Text = @"Reprojection of files is performed.";
            SetProjectProjection(proj, ReportType.Loading);
            lblProjection.Visible = false;
            Show();
        }

        /// <summary>
        /// Shows the report as modal dialog
        /// </summary>
        /// <param name="proj">Project projection</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public void ShowReport(ISpatialReference proj, string message, ReportType type)
        {
            Text = type == ReportType.Loading ? "Projection checking results" : "Projection assignment results";
            SetProjectProjection(proj, type);
            ShowReportCore(proj, message);
            ShowDialog();
        }

        /// <summary>
        /// Displays project projection
        /// </summary>
        /// <param name="proj">The proj.</param>
        /// <param name="reportType">Type of the report.</param>
        private void SetProjectProjection(ISpatialReference proj, ReportType reportType)
        {
            string suffix = "Target projection: ";

            if (proj == null || proj.IsEmpty)
            {
                lblProjection.Text = suffix + @"not defined";
            }
            else
            {
                lblProjection.Text = suffix + proj.Name;
            }
        }

        /// <summary>
        /// Performs common actions for report showing which don't depend on the report type (layer loading or assignment of projection)
        /// </summary>
        /// <param name="proj"></param>
        /// <param name="message"></param>
        private void ShowReportCore(ISpatialReference proj, string message)
        {
            if (message == "")
            {
                message = "The following files were affected because of the projection mismatch or absence:";
            }

            label1.Text = message;
            lblProjection.Visible = true;
            lblFile.Visible = false;
            progressBar1.Visible = false;
            button1.Visible = true;
            if (Visible)
            {
                Visible = false;
            }
        }

        #region ICallback Members

        public void ShowFilename(string filename)
        {
            lblFile.Text = @"File: " + filename;
            lblFile.Visible = true;
            progressBar1.Visible = true;
            Refresh();
            Application.DoEvents();
        }

        public void ClearFilename()
        {
            lblFile.Visible = false;
            progressBar1.Visible = false;
        }

        public void Progress(string KeyOfSender, int Percent, string Message)
        {
            progressBar1.Value = Percent;
        }

        public void Error(string KeyOfSender, string ErrorMsg)
        {
            // do nothing
            //throw new NotImplementedException();
        }

        #endregion

        private void TesterReportForm_Load(object sender, System.EventArgs e)
        {
            // Fixing CORE-160
            CaptionFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
    }
}