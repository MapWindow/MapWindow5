// -------------------------------------------------------------------------------------------
// <copyright file="ImageRegistrationModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.ImageRegistration.Model;
using MW5.Plugins.Services;

namespace MW5.Plugins.ImageRegistration.Views
{
    internal class ImageRegistrationModel
    {
        private readonly BindingList<PointPair> _points;
        private string _imageName;
        private IImageSource _image;

        public ImageRegistrationModel()
        {
            _points = new BindingList<PointPair>();
            StdError = double.NaN;
        }

        public string ImageFilename
        {
            get { return _imageName; }
        }

        public bool ImageLoaded
        {
            get { return !string.IsNullOrWhiteSpace(ImageFilename);  }
        }

        public IList<PointPair> Points
        {
            get { return _points; }
        }

        public IEnumerable<PointPair> ActivePoints
        {
            get { return _points.Where(p => p.Active); }
        }

        public bool NeedsNewPoint
        {
            get { return _points.Count == 0 || _points.Last().Complete; }
        }

        public void ClearErrors()
        {
            foreach (var pnt in Points)
            {
                pnt.Deviation = double.NaN;
            }

            StdError = double.NaN;
        }

        public void UpdateAllPoints()
        {
            for (int i = 0; i < Points.Count; i++)
            {
                // this will cause the update of UI
                Points[i] = Points[i];
            }
        }

        public bool Registered { get; set; }

        public double StdError { get; set; }

        public bool CanClose
        {
            get { return Points.Count == 0 || Registered; }
        }

        public IImageSource Image
        {
            get { return _image; }
        }

        public IImageSource OpenRaster(IWin32Window parent)
        {
            string filename = OpenFileDialog(parent);
            if (string.IsNullOrWhiteSpace(filename))
            {
                return null;
            }

            if (!RemovePreviousWorldFile(filename))
            {
                return null;
            }

            Registered = false;
            _imageName = filename;
            _image = BitmapSource.Open(filename, false);

            CheckImageFormat();

            return _image;
        }

        private void CheckImageFormat()
        {
            if (_image.ImageFormat == ImageFormat.Bmp)
            {
                MessageService.Current.Info("Image registration for BMP format currently is not supported.");

                _image.Dispose();
                _image = null;
                _imageName = string.Empty;
            }
        }

        private string OpenFileDialog(IWin32Window parent)
        {
            using (var dlg = new OpenFileDialog { Filter = GeoSource.RasterFilter, Title = "Choose Image to Register" })
            {
                if (dlg.ShowDialog(parent) == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }

            return string.Empty;
        }

        private IEnumerable<string> GetProjectionFilenames(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) yield break;

            yield return filename + "w";

            string ext = Path.GetExtension(filename);
            if (ext.Length == 4)
            {
                yield return Path.ChangeExtension(filename, ext.Substring(1, 1) + ext.Substring(3,1) + "w");
            }

            yield return Path.ChangeExtension(filename, ".wld");

            yield return Path.ChangeExtension(filename, ".prj");
        }

        private bool RemovePreviousWorldFile(string filename)
        {
            if (filename.ToLower().EndsWith(".tif"))
            {
                // do nothing, we won't be applying empty tranform
                return true;
            }

            var names = GetProjectionFilenames(filename).ToList();

            if (!names.Any(File.Exists)) return true;

            string msg = string.Format("The world file for the image already exists.{0}Do you want to remove it?", Environment.NewLine);

            var result = MessageService.Current.AskWithCancel(msg);

            if (result == DialogResult.Cancel)
            {
                return false;
            }

            if (result == DialogResult.Yes)
            {
                foreach (var name in names)
                {
                    try
                    {
                        if (File.Exists(name))
                        {
                            File.Delete(name);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageService.Current.Info("Failed to remove file: " + ex.Message);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}