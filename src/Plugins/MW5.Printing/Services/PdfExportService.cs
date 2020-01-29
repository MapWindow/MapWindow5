// -------------------------------------------------------------------------------------------
// <copyright file="PdfExportService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Services;
using MW5.Shared;
using Syncfusion.XPS;

namespace MW5.Plugins.Printing.Services
{
    internal class PdfExportService
    {
        private readonly ITempFileService _fileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfExportService"/> class.
        /// </summary>
        public PdfExportService(ITempFileService fileService)
        {
            if (fileService == null) throw new ArgumentNullException("fileService");
            _fileService = fileService;
        }

        /// <summary>
        /// Exports current layout to PDF by printing to temp XPS file first.
        /// </summary>
        public void ExportToPdf(LayoutControl layoutControl, IWin32Window parent)
        {
            try
            {
                string pdfFilename = GetPdfFilename(parent);
                if (string.IsNullOrWhiteSpace(pdfFilename)) return;

                string tempFilename = _fileService.GetTempFilename(".xps");
                var service = new PrintingService();

                if (service.HasNativePDFPrinter)
                    service.PrintToPdfFile(layoutControl.Pages, layoutControl.PrinterSettings, layoutControl.LayoutElements, pdfFilename);
                else
                {
                    service.EndPrint += (s, args) => Task.Factory.StartNew(() => ConvertToPdf(tempFilename, pdfFilename));

                    service.PrintToXpsFile(layoutControl.Pages, layoutControl.PrinterSettings, layoutControl.LayoutElements,
                        tempFilename);
                }
            }
            catch (Exception ex)
            {
                const string msg = @"An error during PDF export";
                Logger.Current.Error(msg, ex);
                MessageService.Current.Warn(msg + ": " + ex.Message);
            }
        }

        /// <summary>
        /// Converts XPS file to PDF.
        /// </summary>
        private void ConvertToPdf(string xpsFilename, string pdfFilename)
        {
            if (!File.Exists(xpsFilename)) return;

            // wait until file is released
            GcHelper.Collect(1000);

            try
            {
                var converter = new XPSToPdfConverter();

                converter.Settings.EmbedCompleteFont = true;

                var document = converter.Convert(xpsFilename);

                document.Save(pdfFilename);
                document.Close(true);
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to convert to PDF: " + ex.Message);
                return;
            }

            OpenPdfResult(pdfFilename);
        }

        /// <summary>
        /// Opens the PDF result.
        /// </summary>
        private void OpenPdfResult(string pdfFilename)
        {
            try
            {
                if (MessageService.Current.Ask(
                        "Exported to PDF successfully. Do you want to open the reasulting document?"))
                {
                    Process.Start(pdfFilename);
                }
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to open PDF document: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the PDF filename.
        /// </summary>
        private string GetPdfFilename(IWin32Window parent)
        {
            using (var dlg = new SaveFileDialog { Filter = @"PDF documents (*.pdf)|*.pdf" })
            {
                if (dlg.ShowDialog(parent) == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }

            return string.Empty;
        }
    }
}