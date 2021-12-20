namespace MediaSorter.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    public static class FileHelper
    {
        private const string IncludedImageExtentions = ".jpg,.jpeg,.png,.tif,.tiff,.bmp,.gif,.eps,.raw";
        private const string IncludedVideoExtentions = ".mp4,.mov,.wmv,.flv,.avi,.avchd,.webm,.mkv,.3gp";

        public static List<string> FilterMediaFiles(List<string> unfilteredList)
        {
            var imageExtentions = IncludedImageExtentions.Split(',');
            var videoExtentions = IncludedVideoExtentions.Split(',');

            return unfilteredList
                .Where(file => imageExtentions.Any(i => file.ToLower().EndsWith(i)) || videoExtentions.Any(i => file.ToLower().EndsWith(i)))
                .ToList();
        }
    }
}