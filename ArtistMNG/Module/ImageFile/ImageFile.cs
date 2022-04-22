using System;
using System.Drawing;

namespace ArtistMNG.Module.ImageFile
{
    public static class ImageFile
    {
        public static Image SetImageFromFolder(string fileName)
        {
            return Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Image", fileName));
        }
        public static Image SetIconFromFolder(string fileName)
        {
            return Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Icon", fileName));
        }
    }
}
