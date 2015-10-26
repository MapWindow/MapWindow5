// -------------------------------------------------------------------------------------------
// <copyright file="FileDialogHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Windows.Forms;

namespace MW5.Plugins.Printing.Helpers
{
    internal static class FileDialogHelper
    {
        public static string GetBitmapFilename(string elementName, IWin32Window parent)
        {
            var sfd = new SaveFileDialog
                          {
                              FileName = elementName,
                              Filter =
                                  "Portable Network Graphics (*.png)|*.png|Joint Photographic Experts Group (*.jpg)|*.jpg|Microsoft Bitmap (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|Tagged Image File (*.tif)|*.tif",
                              FilterIndex = 1,
                              AddExtension = true
                          };

            if (sfd.ShowDialog(parent) == DialogResult.Cancel)
            {
                return string.Empty;
            }

            return sfd.FileName;
        }
    }
}