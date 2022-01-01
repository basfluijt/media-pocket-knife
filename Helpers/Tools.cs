namespace MediaSorter.Helpers
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;

    public static class Tools
    {
        public static decimal Map(this decimal value, decimal fromSource, decimal toSource, decimal fromTarget, decimal toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }

        public static Image ResizeImage(string imagePath, Size size)
        {

            if (string.IsNullOrWhiteSpace(imagePath) || imagePath.Contains("_tempImage"))
                return null;
            
            using (FileStream fs =new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (Image image = Image.FromStream(fs))
                {
                    //Get the image current width  
                    var sourceWidth = image.Width;
            
                    //Get the image current height  
                    var sourceHeight = image.Height;
                    float nPercent = 0;
                    float nPercentW = 0;
                    float nPercentH = 0;
            
                    //Calulate  width with new desired size  
                    nPercentW = size.Width / (float)sourceWidth;
            
                    //Calculate height with new desired size  
                    nPercentH = size.Height / (float)sourceHeight;
                    nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;
            
                    //New Width  
                    var destWidth = (int)(sourceWidth * nPercent);
            
                    //New Height  
                    var destHeight = (int)(sourceHeight * nPercent);
                    var b = new Bitmap(destWidth, destHeight);
                
                    using (var g = Graphics.FromImage(b))
                    {
                        g.InterpolationMode = InterpolationMode.Default;
            
                        // Draw image with new width and height  
                        g.DrawImage(image, 0, 0, destWidth, destHeight);
                        g.Dispose();                   
                    }
                    image.Dispose();
                    fs.Dispose();
                    
                    return b;
                }
            }

        }
    }
}