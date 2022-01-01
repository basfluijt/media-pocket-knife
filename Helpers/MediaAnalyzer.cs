namespace MediaSorter.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.WindowsAPICodePack.Shell;
    using OpenCvSharp;
    using File = TagLib.File;
    using Size = System.Drawing.Size;

    // using File = TagLib.File;

    public static class MediaAnalyzer
    {
        internal static event SetProgressBarValues InitProgressBar;
        internal static event UpdateProgressBar ProcessProgressBar;

        public static List<MediaItem> GatherMediaInformation(List<string> SourceFiles)
        {
            var resultList = new List<MediaItem>();
            OnInitProgressBar(1, SourceFiles.Count, 1, $@"READING DATA FOR {SourceFiles.Count} MEDIA ITEMS", 1);

            foreach (var file in SourceFiles)
            {
                var fileInfo = new FileInfo(file);
                var fileTagLib = File.Create(file);
                var fileCodepack = ShellObject.FromParsingName(file); // Used to get the real DateTime when media was shot (image/video)

                var mediaType = FileHelper.GetMediaType(file);
                var creationDate = fileCodepack?.Properties?.System?.ItemDate?.Value;
                var sourceName = fileCodepack?.Properties?.System?.ApplicationName?.Value;
                var imageSize = mediaType == FileHelper.MediaType.Image ? new Size(fileTagLib.Properties.PhotoWidth, fileTagLib.Properties.PhotoHeight) : Size.Empty;
                var imageOrientation = fileTagLib.Properties.PhotoWidth > fileTagLib.Properties.PhotoHeight ? Orientation.Horizontal : Orientation.Vertical;

                resultList.Add(new MediaItem
                {
                    Date = creationDate ?? fileInfo.LastWriteTimeUtc,
                    Extension = fileInfo.Extension,
                    Directory = fileInfo.Directory,
                    Path = file,
                    Size = fileInfo.Length,
                    FileName = fileInfo.Name,
                    FullFileName = fileInfo.FullName,
                    MediaType = mediaType,
                    Source = sourceName,
                    ImageSize = imageSize,
                    ImageOrientation = imageOrientation
                });

                OnProcessProgressBar();
            }

            return resultList;
        }

        public static float CalcBlurriness(Mat src)
        {
            var Gx = new Mat();
            var Gy = new Mat();

            Cv2.Sobel(src, Gx, MatType.CV_64F, 1, 0);
            Cv2.Sobel(src, Gy, MatType.CV_64F, 0, 1);

            var normGx = Cv2.Norm(Gx);
            var normGy = Cv2.Norm(Gy);
            var sumSq = normGx * normGx + normGy * normGy;

            return (float)(1.0 / (sumSq / (src.Size().Height * src.Size().Width) + 1e-6)) * 10000;
        }

        private static void OnInitProgressBar(int minValue, int maxValue, int stepSize, string labelText, int bgColor)
        {
            InitProgressBar?.Invoke(minValue, maxValue, stepSize, labelText, bgColor);
        }

        private static void OnProcessProgressBar()
        {
            ProcessProgressBar?.Invoke();
        }

        internal delegate void SetProgressBarValues(int minValue, int maxValue, int stepSize, string labelText, int bgColor);

        internal delegate void UpdateProgressBar();
    }
}