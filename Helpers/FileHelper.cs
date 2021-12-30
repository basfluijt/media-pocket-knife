namespace MediaSorter.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    public static class FileHelper
    {
        public enum MediaType
        {
            Image = 2,
            Video = 1,
            None = 0
        }

        private const string IncludedImageExtensions = ".jpg,.jpeg,.png,.tif,.tiff,.bmp,.gif,.eps,.raw";
        private const string IncludedVideoExtensions = ".mp4,.mov,.wmv,.flv,.avi,.avchd,.webm,.mkv,.3gp";

        private static IEnumerable<string> ImageExtensions => IncludedImageExtensions.Split(',').ToList();
        private static IEnumerable<string> VideoExtensions => IncludedVideoExtensions.Split(',').ToList();

        public static List<string> FilterMediaFiles(IEnumerable<string> unfilteredList)
        {
            return unfilteredList
                .Where(file => ImageExtensions.Any(i => file.ToLower().EndsWith(i)) || VideoExtensions.Any(i => file.ToLower().EndsWith(i)))
                .ToList();
        }

        public static MediaType GetMediaType(string mediaPath)
        {
            return ImageExtensions.Any(mediaPath.Contains) ? MediaType.Image
                : VideoExtensions.Any(mediaPath.Contains) ? MediaType.Video
                : MediaType.None;
        }
    }
}