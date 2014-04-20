// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddLayersForm.cs" company="TopX Geo-ICT, The Netherlands">
//   MPL
// </copyright>
// <summary>
//   Form to select and open geospatial data
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MapWindow.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class AddLayersForm : Syncfusion.Windows.Forms.MetroForm
    {
        public AddLayersForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Override the on shown event to get this form in the center of its parent
        /// </summary>
        /// <param name="e">
        /// The event arguments
        /// </param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.Owner == null || this.StartPosition != FormStartPosition.Manual)
            {
                return;
            }

            var offset = this.Owner.OwnedForms.Length * 38;  // approx. 10mm
            var p = new Point(this.Owner.Left + (this.Owner.Width / 2) - (this.Width / 2) + offset, this.Owner.Top + (this.Owner.Height / 2) - (this.Height / 2) + offset);
            this.Location = p;
        }
    }
}
