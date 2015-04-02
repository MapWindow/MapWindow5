using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Services;
using MW5.UI;

namespace MW5.Services.Serialization.Utility
{
    public class ImageSerializationService
    {
        private readonly ITempFileService _tempFileService;

        public ImageSerializationService(ITempFileService tempFileService)
        {
            if (tempFileService == null) throw new ArgumentNullException("tempFileService");
            _tempFileService = tempFileService;
        }

        /// <summary>
        ///  Converts in-memory image to string representation
        /// </summary>
        /// <param name="img">Image to be converted</param>
        /// <param name="type">Returns type of image</param>
        /// <returns>String representation of image</returns>
        public string ConvertImageToString(object img, out string type)
        {
            type = string.Empty;

            if (img == null)
            {
                return string.Empty;
            }

            string path = _tempFileService.GetTempFilename(".png");

            try
            {
                //find the type of image it is
                if (img is Icon)
                {
                    type = "Icon";
                    Icon image = (Icon)img;
                    using (Stream outStream = File.OpenWrite(path))
                    {
                        image.Save(outStream);
                        outStream.Close();
                    }
                }
                else if (img is Bitmap)
                {
                    type = "Bitmap";
                    Image image = (Bitmap)img;
                    image.Save(path);
                }

                using (Stream inStream = File.OpenRead(path))
                {
                    using (var reader = new BinaryReader(inStream))
                    {
                        long numbytes = reader.BaseStream.Length;
                        byte[] bytes = reader.ReadBytes(Convert.ToInt32(numbytes));
                        return Convert.ToBase64String(bytes);
                    }
                }
                
            }
            catch (Exception e)
            {
                Debug.Print("Failed to serialize image: " + e.Message);
            }
            
            return string.Empty;
        }

        /// <summary>
        /// Creates in-memory image from it's string representation.
        /// </summary>
        public object ConvertStringToImage(string image, string type)
        {
            if (string.IsNullOrWhiteSpace(image) || string.IsNullOrWhiteSpace(type))
            {
                return null;
            }

            var path = _tempFileService.GetTempFilename(".png");
            
            try
            {
                using (var outStream = File.OpenWrite(path))
                {
                    byte[] mybyte = Convert.FromBase64String(image);
                    outStream.Write(mybyte, 0, mybyte.Length);
                    outStream.Close();
                }
                
                switch (type)
                {
                    case "Icon":
                        var icon = new Icon(path);
                        return icon;
                    case "Bitmap":
                        var bmp = new Bitmap(path);
                        return bmp;
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Failed to deserialize image: " + ex.Message);
            }

            return null;
        }
    }
}
