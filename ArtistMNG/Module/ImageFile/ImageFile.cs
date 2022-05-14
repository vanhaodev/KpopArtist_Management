using System;
using System.Drawing;

namespace ArtistMNG.Module.ImageFile
{
    public static class ImageFile
    {
        /// <summary>
        /// Get ảnh từ folder Image
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Image SetImageFromFolder(string fileName)
        {
            return Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Image", fileName));
        }
        /// <summary>
        /// Get ảnh từ folder icon
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Image SetIconFromFolder(string fileName)
        {
            return Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Icon", fileName));
        }
        /// <summary>
        /// Set icon app bằng ảnh từ folder icon
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Icon SetWindowIcon(string fileName)
        {
            return Icon.ExtractAssociatedIcon(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Icon", fileName));
        }
    }
}
