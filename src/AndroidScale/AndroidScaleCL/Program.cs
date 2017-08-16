using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using System.IO;

namespace AndroidScaleCL
{
    public class Program
    {
        static void Main(string[] args)
        {
            //36 = 54
            var source_path = @"D:\DataSets\FontAwesomeImport\star.png";  
            string[] scales = { "drawable-mdpi", "drawable-hdpi", "drawable-xhdpi", "drawable-xxhdpi", "drawable-xxxhdpi" };
            double [] pixels_per_dp = { 1.0, 1.5, 2.0, 3.0, 4.0 };
            double[] disired_dp_sizes = { 18, 28, 36 };
            for (int scale_index = 0; scale_index < scales.Length; scale_index++)
            {
                for (int dp_index = 0; dp_index < disired_dp_sizes.Length; dp_index++)
                {
                    int width = (int)(disired_dp_sizes[dp_index] * pixels_per_dp[scale_index]);
                    int height = (int)(disired_dp_sizes[dp_index] * pixels_per_dp[scale_index]);
                    var image = new Bitmap(source_path);
                    var target_dir = @"D:\DataSets\FontAwesomeExport\" + scales[scale_index];
                    var target_path = @"D:\DataSets\FontAwesomeExport\" + scales[scale_index] + @"\ic_fa_star_" + disired_dp_sizes[dp_index] + "dp.png";
                    Directory.CreateDirectory(target_dir);
                    using (var sourceImage = new MagickImage(image))
                    { //texture is of type Stream
                        sourceImage.Resize(width, height);
                        sourceImage.Write(target_path);
                    }
                    image.Dispose();
                }
            }
        }
    }
}
